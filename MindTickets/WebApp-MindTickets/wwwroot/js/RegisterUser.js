$(document).ready(function () {

});

function RegisterUserController() {
    this.ViewName = "RegisterUser";
    this.ApiUrl = "RegisterUser";

    this.InitView = function () {
        console.log("RegisterUserInit");
        $("#btn_register").click(function () {
            var view = new RegisterUserController();
            view.RegisterUser();
        });
    }

    this.RegisterUser = function () {
        alert("Registrado correctamente");


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
                "province": "",
                "canton": "",
                "district": "",
                "exactAddress": ""
            }
        };

        var id = $("#inputId").val();
        var fullName = $("#inputName").val();
        var lastName = $("#inputLastName").val();
        var email = $("#inputEmail").val();
        var phone = $("#inputPhone").val();
        var province = $("#inputAddress1").val();
        var canton = $("#inputAddress2").val();
        var district = $("#inputAddress3").val();
        var exactAddress = $("#inputAddress4").val();
        var password = $("#inputPassword1").val();
        var authenticatedOTP = $("#inputCodeOTP").val();
        var userType = $("#inputTypeUser").val();
        var idImage = $("#ProfilePicture").val();
        var Password2 = $("#inputPassword2").val();

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
        var urlService = "User/CreateUser";
        ctrlActions.PostToAPI(urlService, user, function () {
            console.log("Data enviada al API");
        });
        console.log("User --> " + JSON.stringify(user));
    }


}

$(document).ready(function () {
    var myWidget = cloudinary.createUploadWidget({
        cloudName: 'csalazarg',
        uploadPreset: 'hz2ilnkl'
    }, (error, result) => {
        if (!error && result && result.event === 'success') {
            console.log('Imagen subida: ', result.info);
            ImageUrl = result.info.secure_url;
            $('#ProfilePicture').attr('src', ImageUrl);
        }
    });

    $('#btnImagen').on('click', function () {
        myWidget.open();
    });
});

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
            $('#ProfilePicture').attr('src', ImageUrl);
        }
    });
}
*/
$(document).ready(function () {
    var view = new RegisterUserController();
    view.InitView();
});
