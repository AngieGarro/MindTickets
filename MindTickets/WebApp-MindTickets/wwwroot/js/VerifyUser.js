function VerifyUserController() {

    this.ViewName = "VerifyUser";
    this.ApiUrl = "VerifyUser";

    this.InitView = function () {
        console.log("VerifyInit");
        $("#btnVerify").click(function () {
            var view = new VerifyUserController();
            view.VerifyUser();
        });
    }

    this.VerifyUser = function () {
        alert("Verificando Cuenta");
        var Token = $("#txt_Token").val()
        var validate = "https://localhost:7042/api/Auth/ValidateToken?userToken=" + Token;
        /** 
                var ctrlAction = new ControlActions();
                var serviceToCreate = "Auth/ValidateToken";
                ctrlAction.PostToAPI(serviceToCreate, Token, function () {
                    alert("Autenticado")
                    console.log("Send Data to the API");
                    console.log("Msj --> " + JSON.stringify(Token));
                });
                */

        $.ajax({
            url: validate,
            type: "POST",
            //dataType: "json",
            //data: response.JSON(Token),
            //contentType: "application/json"
            success: function (response) {
                if (response === "User authenticated") {
                    // Token válido
                    alert("User authenticated");
                } else if (response === "Token incorrecta") {
                    // Token incorrecto
                    alert("Token incorrecta");
                } else {
                    // Otro resultado (puede ser un diccionario en tu caso)
                    alert("Token incorrecta: " + response);
                }
            },
            error: function (xhr, status, error) {
                // Manejar errores aquí
                console.error("Error en la solicitud: " + error);
            }
        }); 
    };

}

    $(document).ready(function () {
        var view = new VerifyUserController();
        view.InitView();
    })
