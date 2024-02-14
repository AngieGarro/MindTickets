function ResetPasswordController() {

    this.ViewName = "ResetPassword";
    this.ApiUrl = "ResetPassword";

    this.InitView = function () {
        console.log("ResetPasswordInit");
        $("#btnUpdate").click(function () {
            var view = new ResetPasswordController();
            view.ResetPassword();
        });
    } 

    this.ResetPassword = function () {
        alert("Coma cereal");
        var user = {};
        user.Email = $("#txt_email").val();
        user.Password = $("#txt_password").val();
        console.log(user.Email);
        console.log(user.Password);
        console.log(JSON.stringify(user));
        $.ajax({
            url: "https://localhost:7042/api/User/ResetPassword",
            type: "PUT",
            dataType: "json",
            data: JSON.stringify(user),
            contentType: "application/json",
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
    
}

$(document).ready(function () {
    var view = new ResetPasswordController();
    view.InitView();
})