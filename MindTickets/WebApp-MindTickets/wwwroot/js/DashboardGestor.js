var UserJson = readJsonFromCookie("UserJson");

function DashboardGestor() {

    this.InitView = function () {
        console.log("DashboardGestor view init");

        this.LoadMyMembership();
        this.LoadMyEvents();
        this.LoadCount();

        $("#btnCreate").click(function () {
            var view = new DashboardGestor();
            view.CreateEvent();
        })

        /*
        $("#btnImagen").click(function () {
            alert("imagen");
            var view = new DashboardGestor();
            view.Cloudinary();
        })
        */
      
      
    }

    this.LoadMyMembership = function () {
        var user = JSON.parse(UserJson);
        var userID = 205670543;//user.id;
        var urlRet = "https://localhost:7042/api/MembershipClient/RetrieveMyMembership?id=" + userID;

        $.ajax({
            url: urlRet,            
            method: 'GET',            
            success: function (data) {

                console.log("UserDATA --> " + JSON.stringify(data));                
                var jsonMemb = data;

                if (jsonMemb) {
                    // Update the HTML with the retrieved product data
                    $('#txtMembership').text(jsonMemb.membershipName);
                    $('#totalEvents').text(jsonMemb.eventLimit);
                    $('#totalTickets').text(jsonMemb.ticketLimit);
                    

                } else {
                    console.log('User not found');
                }
            }
        })


    }

    this.CreateEvent = function () {
        var event = {

            "id": 0,
            "eventName": "",
            "modality": "",
            "logo": "",
            "slogan": "",
            "dateAndTime": "",
            "time": "",
            "location": {
                "id": 0,
                "province": "",
                "canton": "",
                "district": "",
                "exactAddress": ""
            },
            "description": "",
            "restrictions": "",
            "ticketType": {
                "id": 0,
                "vip": 0,
                "priceTicketVIP": 0,
                "regular": 0,
                "priceTicketRegular": 0,
                "special": 0,
                "priceTicketSpecial": 0,
                "free": 0,
                "priceTicketFree": 0
            },
            "organizerName": "",
            "creatorId": 0,
            "eventPhoneNumber": "",
            "eventEmail": "",
            "eventWebSite": "",
            "eventCategory": ""
        }

        //var event = {};
         var eventName = $("#eventName").val();
         var modality = $("#eventModality").val();
        var logo = $("#BannerPicture").val();
         var slogan = $("#eventSlogan").val();
        var dateAndTime = $("#eventDate").val();
        var time = $("#eventTime").val();

        /* Location */
         var province = $("#txtProvince").val();
         var canton = $("#txtCanton").val();
         var district = $("#txtDistrict").val();
         var exactAddress = $("#txtExactAdd").val();

         var description = $("#eventDescription").val();
         var restrictions = $("#inputRestrictions").val();

        /* Ticket */
         var vip = $("#cantidadVIP").val();        
         var priceTicketVIP = $("#costoVIP").val();
         var special = $("#cantidadEspecial").val();
         var priceTicketSpecial = $("#costoEspecial").val();
         var regular = $("#cantidadRegular").val();
         var priceTicketRegular = $("#costoRegular").val();        
         var free = $("#cantidadGratis").val();
         var priceTicketFree = 0; 

        /* Event Details */
         var organizerName = $("#organizerName").val();
         var creatorId = $("#organizerID").val();
         var eventPhoneNumber = $("#eventPhone").val();
         var eventEmail = $("#eventEmail").val();
         var eventWebsite = $("#eventWeb").val();
         var eventCategory = $("#eventCategory").val();

        event.eventName = eventName;
        event.modality = modality;
        event.logo = logo;
        event.slogan = slogan;
        event.dateAndTime = dateAndTime;
        event.time = time;
        event.location.province = province;
        event.location.canton = canton;
        event.location.district = district;
        event.location.exactAddress = exactAddress;
        event.description = description;
        event.restrictions = restrictions;
        event.ticketType.vip = vip;
        event.ticketType.priceTicketVIP = priceTicketVIP;
        event.ticketType.regular = regular;
        event.ticketType.priceTicketRegular = priceTicketRegular;
        event.ticketType.special = special;
        event.ticketType.priceTicketSpecial = priceTicketSpecial;
        event.ticketType.free = free;
        event.ticketType.priceTicketFree = priceTicketFree;
        event.organizerName = organizerName;
        event.creatorId = creatorId;
        event.eventPhoneNumber = eventPhoneNumber;
        event.eventEmail = eventEmail;
        event.eventWebSite = eventWebsite;
        event.eventCategory = eventCategory;


        console.log("Event --> " + JSON.stringify(event));

        var ctrlActions = new ControlActions();
        var serviceToCreate = "Events/CreateEvent";

        ctrlActions.PostToAPI(serviceToCreate, event, function () {
            console.log("Data enviada al API");
        });


    }

    this.LoadCount = function () {
        var cedula = 205670543;// userObject.id;

        var URL = "https://localhost:7042/api/Events/RetrieveCountEvents?id=" + cedula;
        console.log(URL);

        $.ajax({
            url: URL,
            type: "GET",
            success: function (data) {
                $("#totalEvents").text(data);
            }

        });

    }

    

    /*
    this.Cloudinary = function () {
        myWidget.open();
        var myWidget = cloudinary.createUploadWidget({
            cloudName: 'csalazarg',
            uploadPreset: 'hz2ilnkl'
        }, (error, result) => {
            if (!error && result && result.event === 'success') {
                console.log('Imagen subida: ', result.info);
                ImageUrl = result.info.secure_url;
                $('#BannerPicture').attr('src', ImageUrl);
            }
        });
    }
   */
    this.LoadMyEvents = function () {

        var userID = 205670543;
        var urlRet = "https://localhost:7042/api/Events/RetrieveMyEvents?id=" + userID;
        console.log(urlRet);
        tablaData = $('#tbdata').DataTable({
            responsive: true,
            "ajax": {
                "url": urlRet,
                "dataSrc": "",
                "type": "GET",
                "datatype": "json"
            },
            "columns": [
                { "data": "id" },
                { "data": "eventName" },
                { "data": "modality", "visible": false, "searchable": false },
                { "data": "logo", "visible": false, "searchable": false },
                { "data": "slogan", "visible": false, "searchable": false },
                {"data": "dateAndTime" },
                { "data": "description", "visible": false, "searchable": false },
                { "data": "restrictions", "visible": false, "searchable": false },
                { "data": "organizerName", "visible": false, "searchable": false },
                { "data": "creatorId", "visible": false, "searchable": false },
                { "data": "eventPhoneNumber" },
                { "data": "eventEmail" },
                { "data": "eventWebSite" },
                { "data": "eventCategory" },              
                {
                    "defaultContent": '<button class="btn btn-primary btnEdit btn-sm mr-2"><i class="bi bi-pencil"></i></button>',
                        
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
    }
}


$(document).ready(function () {
    var view = new DashboardGestor();
    view.InitView();
});


// Retrieve Information on Cookies
function readJsonFromCookie(cookieName) {
    // Get the cookie value
    var name = cookieName + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var cookieArray = decodedCookie.split(';');
    var jsonValue = null;

    for (var i = 0; i < cookieArray.length; i++) {
        var cookie = cookieArray[i].trim();
        if (cookie.indexOf(name) === 0) {
            return cookie.substring(name.length, cookie.length);
            break;
        }
    }
    return null;

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

/*-------------- Events Section --------------*/
// Modal Functions
function showModal(model = BaseModel) {
    $("#txtId").val(model.id)
    $("#txtName").val(model.eventName)
    $("#txtDescription").val(model.description)
    $("#eventDate").val(model.date)
    $("#eventTime").val(model.time)

    $("#modalData").modal("show")
}

let selectedRow;
$("#tbdata tbody").on("click", ".btnEdit", function () {
    if ($(this).closest("tr").hasClass("child")) {
        selectedRow = $(this).closest("tr").prev();
    } else {
        selectedRow = $(this).closest("tr");
    }
    const data = tablaData.row(selectedRow).data();
    console.log("tax --> " + JSON.stringify(data));
    showModal(data);
})

$("#btnSave").click(function () {
    var event = {};
    event.id = $("#txtId").val();
    event.eventName = $("#txtName").val();
    event.description = $("#txtDescription").val();
    event.date = $("#eventDate").val();
    event.time = $("#eventTime").val();

    var ctrlActions = new ControlActions();
    var urlService = "Events/UpdateEvent";

    ctrlActions.PutToAPI(urlService, event, function () {
        console.log("Data enviada al API - Update");
        $("#modalData").modal("hide");
    });

    console.log("membership --> " + JSON.stringify(event));

})


// Cloudinary
$(document).ready(function () {
    var myWidget = cloudinary.createUploadWidget({
        cloudName: 'csalazarg',
        uploadPreset: 'hz2ilnkl'
    }, (error, result) => {
        if (!error && result && result.event === 'success') {
            console.log('Imagen subida: ', result.info);
            ImageUrl = result.info.secure_url;
            $('#BannerPicture').attr('src', ImageUrl);
        }
    });

    $('#btnImagen').on('click', function () {
        myWidget.open();
    });
});