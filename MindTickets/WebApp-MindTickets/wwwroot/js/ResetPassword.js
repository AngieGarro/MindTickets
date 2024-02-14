function ResetPasswordController() {

    this.ViewName = "ResetPassword";
    this.ApiUrl = "Auth";

    this.InitView = function () {
        console.log("ResetPasswordInit");
        $("#btnUpdate").click(function () {
            var view = new ResetPasswordController();
            view.ResetPassword();
        });

        $("#SendEmail").click(function () {
            var view = new ResetPasswordController();
            view.ResetByEmail();
        });
    } 

    /** 
    this.ResetByEmail = function () {
        alert("Enviando Email");
        var user = {};
        user.Email = $("#txt_email").val();

        var ctrlAction = new ControlActions();
        var serviceToCreate = "Auth/GenerateEmail";
        ctrlAction.PostToAPI(serviceToCreate,user, function () {

            console.log("Send Data to the API");
            console.log("Msj --> " + JSON.stringify(user));

        });
    }

    this.ResetPassword = function () {
        alert("Actualizando Clave");;
        var user = {};
        user.Email = $("#txt_email").val();
        user.Password = $("#txt_password").val();
        var Password2 = $("#txt_password2").val();
        if (user.Password == Password2) {

            var ctrlAction = new ControlActions();
            var serviceToCreate = "Auth/ProcessPWS";
            ctrlAction.PostToAPI(serviceToCreate, user, function () {

                console.log("Send Data to the API");
                console.log("Msj --> " + JSON.stringify(user));

            });
        }
    }

  */
    this.ResetByEmail = function () {
        alert("Enviando Email");
        var Email = $("#txt_email").val();
        var resetLink = "https://localhost:7042/api/Auth/GenerateEmail?email=" + Email;
        $.ajax({
            url: resetLink,
            type: "POST",
            //dataType: "json",
           // data: JSON.stringify({ email: Email }), // Enviar el objeto con propiedad 'email'
            //contentType: "application/json",
            success: function (response) {
                // Manejar la respuesta exitosa de la API aquí
                $("#resultado").html("Respuesta: " + JSON.stringify(response));
            },
            error: function (xhr, status, error) {
                // Manejar errores aquí
                console.error("Error en la solicitud: " + error);
            }
        });
    }
    
    this.ResetPassword = function () {
        alert("Actualizando Clave");
        var Email = $("#txt_email").val();
        var Password = $("#txt_password").val();
        var updatePWD = "https://localhost:7042/api/Auth/ProcessPWS?pwrd=" + encodeURIComponent(Password) + "&email=" + encodeURIComponent(Email);
        

        var password2 = $("#txt_password2").val();

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
    var view = new ResetPasswordController();
    view.InitView();
})