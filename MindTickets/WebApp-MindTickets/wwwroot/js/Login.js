function LoginController() {

    this.apiService = "Login";

    //var data;
    let Email = $("#txt_email").val();
    let Password = $("#txt_pswrd").val();


    this.InitView = function () {

        $("#btnLogin").click(function () {

            var view = new LoginController();
            view.IniciarSesion();
        });
    }

    this.IniciarSesion = function () {
      
        if (Email === "" || Password === "") {
            alert("Campos requeridos")
    
        } else {
            var ctrlActions = new ControlActions();
            var serviceToCreate = this.apiService + `/Login?correo=${Email}&clave=${Password}`;

            ctrlActions.PostToAPILogin(serviceToCreate)
            console.log("Procesando");

            /** 
            if (!serviceToCreate) {
                console.log(data);
                alert("Bienvenido a MindTickets")
                window.location.href = "https://localhost:7161/home/HomePage";
                //var view = new LoginController();
                //view.retrieveByEmail(Email);
            } else {
                console.log("Respuesta desconocida");
                console.log("ERROR");
            }
                .then(function (responseText) {
                    switch (responseText) {
                        case "Bienvenido":
                            Swal.fire({
                                icon: 'success',
                                title: 'Bienvenido'
                            });
                            var view = new LoginController();
                            view.retrieveByEmail(Email);
                            break;
                        default:
                            console.log("Respuesta desconocida");
                    }
                })
                .catch(function () {
                    console.log("ERROR");
                    
                });*/
        }
    };

    // Retrieve Information on Cookies
   /* function readJsonFromCookie(cookieName) {
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
    this.retrieveByEmail = function (Email) {
        var ctrlActions = new ControlActions();
        var urlService = this.apiService + "/RetrieveByEmail?correo=" + encodeURIComponent(Email);
    };
*/
}

$(document).ready(function () {
    var view = new LoginController();
    view.InitView();
});