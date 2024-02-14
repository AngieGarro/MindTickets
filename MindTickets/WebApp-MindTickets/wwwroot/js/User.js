const BaseModel = {
    id: 0,
    fullName: "",
    lastName: "",
    email: "",
    phone: "",
    password: "",
    idPicture: "",
    idImage: "",
    userType:"Administrador"
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

$(document).ready(function () {

    tablaData = $('#tbdata').DataTable({
        responsive: true,
        "ajax": {
            "url": 'https://localhost:7042/api/User/RetrieveAll',
            "dataSrc": "",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id" },
            { "data": "fullName" },
            { "data": "lastName",},
            { "data": "email" },
            { "data": "phone" },
            { "data": "password", "visible": false, "searchable": false },
            { "data": "idPicture", "visible": false, "searchable": false },            
            { "data": "idImage", "visible": false, "searchable": false },
            { "data": "userType" },
            { "data": "authenticatedOTP", "visible": false, "searchable": false },
            { "data": "token", "visible": false, "searchable": false }, 
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
        tablaData.ajax.reload();
    }, 30000);
});

function showModal(model = BaseModel) {
    $("#txtId").val(model.id)
    $("#txtName").val(model.fullName)
    $("#txtLastN").val(model.lastName)
    $("#txtCorreo").val(model.email)
    $("#txtPwd").val(model.password) 
    $("#modalData").modal("show")
}

$("#btnNew").click(function () {
    showModal();
})

$("#btnSave").click(function () {

    var user = {
        "id": "",
        "fullName": "",
        "lastName": "",
        "email": "",
        "phone": "",
        "password": "",
        "idPicture": "",
        "authenticatedOTP": 0,
        "idImage": "",
        "userType": "",
        "location": {
            "id": 0,
            "province": "Alajuela",
            "canton": "Grecia",
            "district": "Grecia",
            "exactAddress": "8 kilómetros este de la entrada a Grecia"
        }
    }

    console.log(JSON.stringify(user));
    var id = 88888888;
    var fullName = $("#txtName").val();
    var lastName = $("#txtLastN").val();
    var email = $("#txtCorreo").val();
    var phone = "6478-8712";
    var province = "Alajuela";
    var canton = "Grecia";
    var district = "Grecia";
    var exactAddress = "8 kilómetros este de la entrada a Grecia";
    var password = $("#txtPwd").val();
    var authenticatedOTP = 99999
    var userType = "Administrador";
    var idImage = "";    

    user.id = id;
    user.fullName = fullName;
    user.lastName = lastName;
    user.email = email;
    user.phone = phone;
    user.location.province = province;
    user.location.canton = canton;
    user.location.district = district;
    user.location.exactAddress = exactAddress;
    user.password = password;
    user.authenticatedOTP = authenticatedOTP;
    user.userType = userType;
    user.idImage = idImage;

    var ctrlActions = new ControlActions();
    var urlService = "User/CreateNewAdmi";
    ctrlActions.PostToAPI(urlService, user, function () {
        console.log("Data enviada al API");
        $("#modalData").modal("hide");
    });   

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
    console.log(data.id);
    
    let deleteID = parseInt(data.id);
    console.log(deleteID);
    console.log(typeof deleteID);
    
    var ctrlActions = new ControlActions();
    var urlService = "User/Delete";
    var url = "https://localhost:7042/api/User/Delete";

    ctrlActions.DeleteToAPI(urlService, deleteID, function () {
        console.log("Data enviada al API - Delete");
    })
})
