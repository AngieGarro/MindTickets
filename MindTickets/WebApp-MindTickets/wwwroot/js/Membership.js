const BaseModel = {
    id: 0,
    membershipName: "",
    description: "",
    ticketLimit: 0,
    eventLimit: 0,
    commission: 0,
    price: 0
}

function MembershipController() {
    this.ViewName = "Membership";
    this.ApiService = "MembershipClient"

    this.memberships = [];

    this.InitView = function () {
        console.log("Membership view init");


        // Invocamos la función de carga de la tabla y tarjetas luego de cargada la página
        //this.LoadCards();

        // Buttons //


    }

}

// Retrieve All Memberships - Página de Membresías //
this.LoadCards = function () {

    var ctrlActions = new ControlActions();
    var urlService = "MembershipClient/RetrieveAll";

    // Función que llama lo que se encuentra en la base de datos y crea HTML Cards
    ctrlActions.GetToApi(urlService, function (data) {
        //console.log(JSON.stringify(data));
        data.forEach(function (data) {
            $("#membership-cards").append(`<div class="memb_card">                
                            <h3 class="card-title" id="title">${data.membershipName}</h3>
                            <p>${data.description}</p>
                            <i class="bi bi-ticket-detailed"></i>  <p> Cantidad de ticket: ${data.ticketLimit}</p>                                                      
                            <i class="bi bi-calendar2-event"></i> <p>Cantidad de eventos: ${data.eventLimit}</p>
                            <i class="bi bi-bank"></i><p>Comisión: ₡${data.commission}</p>
                            <i class="bi bi-ticket-detailed"></i>  <p id="price">Costo: ${data.price}</p>                     
                            <p id="membid" hidden="hidden">${data.id}</p>

                            <div class="buttons-container">
                                <button type="button" class="btn btn-secondary" id="btnBuy">Comprar</button>
                            </div>  
                </div>`)
        })
    })
}


$(document).ready(function () {
    var view = new MembershipController();
    view.InitView();
});


// Membership in Admin Table //
$(document).ready(function () {

    tablaData = $('#tbdata').DataTable({
        responsive: true,
        "ajax": {
            "url": 'https://localhost:7042/api/MembershipClient/RetrieveAll',
            "dataSrc": "",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id" },
            { "data": "membershipName" },
            { "data": "description", "visible": false, "searchable": false },
            { "data": "ticketLimit" },
            { "data": "eventLimit" },
            { "data": "commission" },
            { "data": "price" },
            {
                "defaultContent": '<button class="btn btn-primary btnEdit btn-sm mr-2"><i class="bi bi-pencil"></i></button>' +
                    '<button class="btn btn-danger btnDelete btn-sm"><i class="bi bi-trash"></i></button>',
                "orderable": false,
                "searchable": false,
                "width": "80px"
            }
        ],
        order: [[0, "asc"]],
        dom: "Bfrtip",
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
    });
});

// Base for Modal //
function showModal(model = BaseModel) {
    $("#txtId").val(model.id)
    $("#txtNombre").val(model.membershipName)
    $("#txtDesc").val(model.description)
    $("#txtTicket").val(model.ticketLimit)
    $("#txtEvent").val(model.eventLimit)
    $("#txtComm").val(model.commission)
    $("#txtPrice").val(model.price)

    $("#modalData").modal("show")
}

$("#btnNew").click(function () {
    showModal();
})

// Save changes in Modal // 
$("#btnSave").click(function () {
    var membership = {};
    membership.id = $("#txtId").val();
    membership.membershipName = $("#txtNombre").val();
    membership.description = $("#txtDesc").val();
    membership.ticketLimit = $("#txtTicket").val();
    membership.eventLimit = $("#txtEvent").val();
    membership.commission = $("#txtComm").val();
    membership.price = $("#txtPrice").val();

    if (membership.id == 0) {
        var ctrlActions = new ControlActions();
        var urlService = "MembershipClient/Create";

        ctrlActions.PostToAPI(urlService, membership, function () {
            console.log("Data enviada al API");
            $("#modalData").modal("hide");
        });
    } else {
        var ctrlActions = new ControlActions();
        var urlService = "MembershipClient/Update";

        ctrlActions.PutToAPI(urlService, membership, function () {
            console.log("Data enviada al API - Update");
            $("#modalData").modal("hide");
        });
    }

    console.log("membership --> " + JSON.stringify(membership));

})

let selectedRow;
$("#tbdata tbody").on("click", ".btnEdit", function () {
    if ($(this).closest("tr").hasClass("child")) {
        selectedRow = $(this).closest("tr").prev();
    } else {
        selectedRow = $(this).closest("tr");
    }
    const data = tablaData.row(selectedRow).data();
    showModal(data);
})

$("#tbdata tbody").on("click", ".btnDelete", function () {
    if ($(this).closest("tr").hasClass("child")) {
        selectedRow = $(this).closest("tr").prev();
    } else {
        selectedRow = $(this).closest("tr");
    }
    const data = tablaData.row(selectedRow).data();
    console.log(data);
    /*
    let deleteID = parseInt(data.id);
    console.log(deleteID);
    console.log(typeof deleteID);
    */
    var ctrlActions = new ControlActions();
    var urlService = "MembershipClient/Delete";
    var url = "https://localhost:7042/api/MembershipClient/DeleteID";

    ctrlActions.DeleteToAPI(urlService, data, function () {
        console.log("Data enviada al API - Delete");
    })
})


// Buy process // 
$(document).on('click', '#btnBuy', function (evt) {

    var card = $(this).closest('.memb_card');

    var body = {
        id: card.find("#membid").text(),
        name: card.find("#title").text(),
        description: card.find("#description").text(),
        tickets: card.find("#tickets").text(),
        events: card.find("#events").text(),
        commision: card.find("#commision").text(),
        price: card.find("#price").text(),

    };
    var jsonMString = JSON.stringify(body);
    console.log("card --> " + JSON.stringify(body));
    console.log("jsonObject --> " + JSON.stringify(jsonMString));
    document.cookie = "MembershipJson=" + encodeURIComponent(jsonMString) + "; expires=Fri, 31 Dec 9999 23:59:59 GMT; path=/";
    console.log("JSON object saved in cookie.");
    console.log(document.cookie);

    window.location.href = '/Home/Checkout/';

    console.log("Compra --> " + JSON.stringify(body));

});

// Retrieve All Memberships - Página de Membresías //
$(document).ready(function () {

    var ctrlActions = new ControlActions();
    var urlService = "MembershipClient/RetrieveAll";

    // Función que llama lo que se encuentra en la base de datos y crea HTML Cards
    ctrlActions.GetToApi(urlService, function (data) {
        //console.log(JSON.stringify(data));
        data.forEach(function (data) {
            $("#membership-cards").append(`<div class="memb_card">                
                            <h3 class="card-title" id="title">${data.membershipName}</h3>
                            <p id="description">${data.description}</p>
                            <i class="bi bi-ticket-detailed"></i>  <p id="tickets"> Cantidad de ticket: ${data.ticketLimit}</p>                                                      
                            <i class="bi bi-calendar2-event"></i> <p id="events">Cantidad de eventos: ${data.eventLimit}</p>
                            <i class="bi bi-bank"></i><p id="commision">Comisión: ₡${data.commission}</p>
                            <i class="bi bi-ticket-detailed"></i>  <p id="price">${data.price}</p>                     
                            <p id="membid" hidden="hidden">${data.id}</p>

                            <div class="buttons-container">
                                <button type="button" class="btn btn-secondary" id="btnBuy">Comprar</button>
                            </div>  
                </div>`)
        })
    })
});

// Cookie Handling //

// Call the function to read the JSON object from the cookie
var MembObject = readJsonFromCookie();

function readJsonFromCookie() {
    // Get the cookie value
    var cookieName = "MembershipJson=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var cookieArray = decodedCookie.split(';');
    var jsonValue = null;

    for (var i = 0; i < cookieArray.length; i++) {
        var cookie = cookieArray[i].trim();
        if (cookie.indexOf(cookieName) === 0) {
            jsonValue = cookie.substring(cookieName.length, cookie.length);
            break;
        }
    }

    if (jsonValue) {
        // Parse the JSON string into an object
        var jsonObject = JSON.parse(jsonValue);
        console.log("JSON object retrieved from cookie:", jsonObject);
        return jsonObject;
    } else {
        console.log("JSON object not found in cookie.");
        return null;
    }
}