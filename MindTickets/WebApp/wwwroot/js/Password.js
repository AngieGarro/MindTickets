function PasswordView() {

    this.ViewName = "PasswordView";
    this.ApiUrl = "";

    this.InitView = function () {
        $("#btnUpdate").click(function () {
            var view = new PasswordView();
            view.UpdatePassword();
        });
    }


    this.UpdatePassword = function () {
        var pswd = {};
        pswd.Email = $("#txt_email").val();
        pswd.Password = $("#txt_pswd").val();
        if (Email != "" && Password != "") {
            var ctrlActions = new ControlActions();
            ctrlActions.PutToAPI("User/ProcessPWS", pswd, function () {
                Swal.fire({
                    title: 'Contraseña actualizada',
                    text: 'En pocos minutos recibirás un email con su contraseña temporal.',
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

    }
}
//Instanciamiento inicial, siempre se ejecuta cuando la pagina termina de cargar.
$(document).ready(function () {
    var view = new PasswordView();
    view.InitView();
})