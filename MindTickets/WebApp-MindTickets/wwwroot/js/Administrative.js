const BaseModel = {
    id: 0,
    membershipName: "",
    description: "",
    ticketLimit: 0,
    eventLimit: 0,
    commission: 0,
    price: 0
}

const BaseModelTax = {
    idTax: 0,
    TaxName: "",
    Amount: 0
}

function UserController() {
    this.ViewName = "User";
    this.ApiService = "User"

    this.users = [];

    this.InitView = function () {
        console.log("User view init");
    }
}


$(document).ready(function () {
    var view = new UserController();
    view.InitView();
});


/*
    Administrative
*/

// Load table
$(document).ready(function () {

    tablaData = $('#tbdata').DataTable({
        responsive: true,
        "ajax": {
            "url": 'https://localhost:7042/api/TaxClient/RetrieveAll',
            "dataSrc": "",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id" },
            { "data": "taxName" },
            { "data": "amount"},            
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

    setInterval(function () {
        $('#tbdata').DataTable().ajax.reload();        
    }, 30000);
});

function showModalTax(modelTax = BaseModelTax) {
    $("#txtId").val(modelTax.id)
    $("#txtName").val(modelTax.taxName)
    $("#txtAmount").val(modelTax.amount)

    $("#modalDataTax").modal("show")
}

$("#btnNewT").click(function () {
    showModalTax();
})

$("#btnSaveT").click(function () {
    var tax = {};
    tax.id = $("#txtId").val();
    tax.taxname = $("#txtNombre").val();
    tax.amount = $("#txtAmount").val();
    

    if (tax.id == 0) {
        var ctrlActions = new ControlActions();
        var urlService = "TaxClient/Create";

        ctrlActions.PostToAPI(urlService, tax, function () {
            console.log("Data enviada al API");
            $("#modalDataTax").modal("hide");
        });
    } else {
        var ctrlActions = new ControlActions();
        var urlService = "TaxClient/Update";

        ctrlActions.PutToAPI(urlService, tax, function () {
            console.log("Data enviada al API - Update");
            $("#modalDataTax").modal("hide");
        });
    }

    console.log("tax --> " + JSON.stringify(tax));

})

let selectedRowTax;
$("#tbdata tbody").on("click", ".btnEdit", function () {
    if ($(this).closest("tr").hasClass("child")) {
        selectedRowTax = $(this).closest("tr").prev();
    } else {
        selectedRowTax = $(this).closest("tr");
    }
    const data = tablaData.row(selectedRowTax).data();
    console.log("tax --> " + JSON.stringify(data));
    showModalTax(data);
})

$("#tbdata tbody").on("click", ".btnDelete", function () {
    if ($(this).closest("tr").hasClass("child")) {
        selectedRowTax = $(this).closest("tr").prev();
    } else {
        selectedRowTax = $(this).closest("tr");
    }
    const data = tablaData.row(selectedRowTax).data();
    console.log(data);
   
    var ctrlActions = new ControlActions();
    var urlService = "TaxClient/Delete";    

    ctrlActions.DeleteToAPI(urlService, data, function () {
        console.log("Data enviada al API - Delete");
    })
})





/*
    Memberships 
 */
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