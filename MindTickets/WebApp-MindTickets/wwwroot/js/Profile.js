function Profile() {
    this.ViewName = "Profile";

    this.InitView = function () {

        /*
        $("#btnImagen").click(function () {
            alert("imagen");
            console.log("pressed");
            var view = new Profile();
            view.Cloudinary();
        })
        */
        $("#btnUpadePWD").click(function () {
            var view = new Profile();
            view.ResetPassword();

        });

        $("#btnSaveChanges").click(function () {
            var view = new Profile();
            view.updateProfile();

        });       

    }


    this.updateProfile = function () {
        readJsonFromCookie();
        var user = {};
        user.id = userObject.id;
        user.fullName = $("#txtNombre").val();        
        user.lastName = $("#txtLastName").val();
        user.email = $("#txtCorreo").val();
        user.phone = $("#txTelefono").val();
        user.password = userObject.password;
        user.idPicture = userObject.idPicture;
        user.idImage = userObject.idImage;
        user.userType = userObject.userType;

        var ctrlActions = new ControlActions();
        var urlService = "User/Update";

        ctrlActions.PutToAPI(urlService, user, function (response) {
            if (response) {
                Swal.fire(
                    'Cambio Completado!',
                    'Información Actualizada!',
                    'success'
                )
                callBackFunction(data);
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
                $('#ProfilePicture').attr('src', ImageUrl);
            }
        });
    }
    */
    this.ResetPassword = function () {
        alert("Actualizando Clave");
        var Email = userObject.email;
        var Password = $("#txtNewPWD").val();
        var updatePWD = "https://localhost:7042/api/Auth/PasswordReset?pwrd=" + encodeURIComponent(Password) + "&email=" + encodeURIComponent(Email);

        var password2 = $("#txtConfirmPWD").val();
        console.log(Password, password2);

        if (Password === password2) {
            $.ajax({
                url: updatePWD,
                type: "PUT",
                //dataType: "json",
                //data: JSON.stringify(user),
                //contentType: "application/json",
                success: function (response) {
                    // Manejar la respuesta exitosa de la API aquí
                    $("#resultado").html("Respuesta: " + JSON.stringify(response));
                },
                error: function (xhr, status, error) {
                    // Manejar errores aquí de manera más informativa
                    console.error("Error en la solicitud: " + error);
                    if (xhr.responseText) {
                        console.error("Respuesta del servidor: " + xhr.responseText);
                    }
                }
            });
        } else {
            console.log("Las contraseñas no coinciden");
        }

    }
}




$(document).ready(function () {
    var view = new Profile();
    view.InitView();
});

// Call the function to read the JSON object from the cookie
var userObject = readJsonFromCookie();

function readJsonFromCookie() {
    // Get the cookie value
    var cookieName = "UserJson=";
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

// Load User´s profile
$(document).ready(function () {

    $.ajax({
        "url": 'https://localhost:7042/api/User/RetrieveAll',
        method: 'GET',
        success: function (data) {

            var desiredUserId = userObject.id;
            var desiredUser = data.find(function (data) {
                return data.id === desiredUserId;
            });

            console.log("UserDATA --> " + JSON.stringify(data));
            var jsonObject = desiredUser;



            var jsonString = JSON.stringify(jsonObject);
            console.log("jsonObject --> " + JSON.stringify(jsonObject));

            document.cookie = "UserJson=" + encodeURIComponent(jsonString) + "; expires=Fri, 31 Dec 9999 23:59:59 GMT; path=/";
            console.log("JSON object saved in cookie.");


            if (desiredUser) {
                // Update the HTML with the retrieved product data
                $('#txtId').val(desiredUser.id);
                $('#txtNombre').val(desiredUser.fullName);
                $('#display-name-user').text(desiredUser.fullName + " " + desiredUser.lastName);
                $("#profile-picture").attr('src', desiredUser.idPicture);
                $('#txtLastName').val(desiredUser.lastName);
                $('#txtCorreo').val(desiredUser.email);
                $('#txTelefono').val(desiredUser.phone);
                $('#txtRol').val(desiredUser.userType);
                $('#txtClaveActual').val(desiredUser.password);
                $('#ProfilePicture').attr('src', desiredUser.idPicture);

            } else {
                console.log('User not found');
            }
        }
    })
});

$(document).ready(function () {
    var myWidget = cloudinary.createUploadWidget({
        cloudName: 'csalazarg',
        uploadPreset: 'hz2ilnkl'
    }, (error, result) => {
        if (!error && result && result.event === 'success') {
            console.log('Imagen subida: ', result.info);
            ImageUrl = result.info.secure_url;
            $('#cloudinaryImage').attr('src', ImageUrl);
        }
    });

    $('#btnImagen').on('click', function () {
        myWidget.open();
    });
});
/*
// Save Changes in user profile.
$("#btnSaveChanges").click(function () {
    readJsonFromCookie();
    var user = {};
    user.id = userObject.id;
    user.fullName = $("#txtNombre").val();
    user.lastName = $("#txtLastName").val();
    user.email = $("#txtCorreo").val();
    user.phone = $("#txTelefono").val();
    user.password = userObject.password;
    user.idPicture = userObject.idPicture;
    user.idImage = userObject.idImage;
    user.userType = userObject.userType;

    var ctrlActions = new ControlActions();
    var urlService = "User/Update";

    ctrlActions.PutToAPI(urlService, user, function () {
    })

})
*/