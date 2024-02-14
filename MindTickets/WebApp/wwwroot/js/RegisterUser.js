
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
        alert("Dormir ya");
        var user = {};
        user.Id = $("#id").val();
        user.FullName = $("#fullName").val();
        user.LastName = $("#lastName").val();
        user.Email = $("#email").val();
        user.Phone = $("#phone").val();
        user.Address = $("#address").val();
        user.Password = $("#password").val();
        user.Password2 = $("#password2").val();
        /*user.IDPicture = $("#idPicture").val();
        user.AuthenticatedEmail = $("#authenticatedEmail").val();
        user.IDImage = $("#idImage").val();
        user.AuthenticatedPhone = $("#authenticatedPhone").val();
       /* var id = $("#id").val();
        var fullName = $("#fullName").val();
        var lastName = $("#lastName").val();
        var email = $("#email").val();
        var phone = $("#phone").val();
        var address = $("#address").val();
        var password = $("#password").val();
        var password2 = $("#password2").val();*/
        /*var idPicture = $("#idPicture").val();
        var authenticatedEmail = $("#authenticatedEmail").val();
        var idImage = $("#idImage").val();
        var authenticatedPhone = $("#authenticatedPhone").val();
        */


        if (password == password2) {
            var u = {};
            u.Id = $("#id").val();
            u.FullName = $("#fullName").val();
            u.LastName = $("#lastName").val();
            u.Email = $("#email").val();
            u.Phone = $("#phone").val();
            u.Address = $("#address").val();
            u.Password = $("#password").val();
            u.Password2 = $("#password2").val();
            u.IDPicture = $("#idPicture").val();
            u.AuthenticatedEmail = $("#authenticatedEmail").val();
            u.IDImage = $("#idImage").val();
            u.AuthenticatedPhone = $("#authenticatedPhone").val();


            /* if (fullName != "" && lastName != "" && email != "" && phone != "" && address != "" && password != "" && password2 != "" && idPicture != "" && authenticatedEmail != "" && idImage != "" && authenticatedPhone != "") {
 
                 var ctrlActions = new ControlActions();
                 ctrlActions.PostToAPI("Usuario/create", u, function () {
 
                     Swal.fire({
                         title: 'Usuario creado',
                         text: 'En pocos minutos recibirás un email y un SMS de confirmación.',
                         icon: 'success',
                         confirmButtonText: 'Ok'
                     })
                 });
             } else {
                 Swal.fire({
                     title: 'Verifica los datos',
                     text: 'Todos los espacios deben ser completados',
                     icon: 'info',
                     confirmButtonText: 'Ok'
                 })
             }
 
 
         } else {
             Swal.fire({
                 title: 'Contrasenas no coindicen',
                 text: 'Las contrasenas deben coincidir',
                 icon: 'info',
                 confirmButtonText: 'Ok'
             })*/
        }
        $.ajax({
            url: "https://localhost:7042/api/User/CreateUser",
            type: "POST",
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
    }//

    this.ValidPass = function () {
        var input = $("#password").val();
        var reg = new RegExp("^(?=.* [a - z])(?=.* [A - Z])(?=.*\d)(?=.* [@$!%*?&])[A - Za - z\d@$!%*?&]{ 8,}$");

        if (!reg.IsMatch(input)) {
            Swal.fire({
                title: 'Intenta otro password',
                text: 'Debe incluir letras Mayúsculas, Minúsculas, números y símbolos.',
                icon: 'info',
                confirmButtonText: 'Ok'
            })
        } else {
            Swal.fire({
                title: 'Password Aceptado',
                icon: 'info',
                confirmButtonText: 'Ok'
            })
        }
    }


}//

//Instanciamiento inicial, siempre se ejecuta cuando la pagina termina de cargar.
$(document).ready(function () {
    var view = new RegisterUserController();
    view.InitView();
})

