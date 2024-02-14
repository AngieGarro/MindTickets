//Aplica para realizar el cierre de sesión
document.addEventListener('DOMContentLoaded', function () {
    var cerrarSesionBtn = document.getElementById('cerrarSesionBtn');

    cerrarSesionBtn.addEventListener('click', function () {
        $.ajax({
            url: 'https://localhost:7042/api/Auth/Logout', // Reemplaza esta URL con la ruta correcta de tu API de cierre de sesión
            type: 'POST', // Método HTTP utilizado por la API
            success: function (data) {
                console.log('Sesión cerrada exitosamente');
            },
            error: function (error) {
                console.error('Error al cerrar sesión', error);
            }
        });
    });
});

document.addEventListener('DOMContentLoaded', function () {
    var loginForm = document.getElementById('loginForm');

    loginForm.addEventListener('submit', function (event) {
        event.preventDefault();

        var Email = document.getElementById('Email').value;
        var Password = document.getElementById('Password').value;

        $.ajax({
            url: 'https://localhost:7042/api/Auth/ValidateUser', // Reemplaza esta URL con la ruta correcta de tu API de inicio de sesión
            type: 'POST', // Método HTTP utilizado por la API
            data: { Email: Email, Password: Password },
            success: function (data) {
                console.log('Inicio de sesión exitoso');
                // Aquí puedes realizar otras acciones que desees después de iniciar sesión.
            },
            error: function (error) {
                console.error('Error al iniciar sesión', error);
            }
        });
    });
});