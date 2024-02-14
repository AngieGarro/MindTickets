if (!getToken()) {
    goHome();
}


const buildProfile = (usr) => {
    $('.perfil').append(`<img src="data:image/png;base64,${usr.foto}" alt="Foto de perfil">`)
    nombreCompleto = `${usr.nombre} ${usr.primerApellido}${usr.segundoApellido && ` ${usr.segundoApellido}`}`
    $('#datos-list').append(`
    <h1 class="user-name">${nombreCompleto.toUpperCase()}</h1>
    <li><strong>Correo electronico:</strong> ${usr.correo}</li>
    <li><strong>Celular:</strong> ${parsePhone(usr.celular)}</li>
    <li><strong>Fecha de registro:</strong> ${parseDate(usr.fechaRegistro)}</li>
    `)
}


const encodearTildes = (str) => {
    const nuevoTexto = str.normalize('NFC');
    return nuevoTexto;
}

$(document).ready(() => {



    $(".opt-card").click((el) => {
        const targetId = el.target.id;
        if (content[targetId]) {
            ModalOverlay(content[targetId].form, content[targetId].handler, false);
        }

    });
    $(".opt-card *").click((el) => {
        $(el.currentTarget).closest(".opt-card").trigger("click");
    });

})

const confirmarEleccion = (text_content) => {

    return `
<div class="conf-card">
<h1>¿Desea continuar?</h1>
<p class="inside-text">${text_content}<p>
<button class="btn btn-danger" id="cancel-btn">Cancelar</button>
<button class="btn btn-info" id="cont-btn">Continuar</button>
</div>
`}

const confirmarOTPCambio = `<div class="form-group op-card-cam">
<div id="alert-container"></div>
  <h2>Confirmación de Código</h2>
  <input class="form-control" type="number" placeholder="Inserta el código enviado" id="otp-input">
<button class="btn btn-info" id="cont-btn-pass">Validar</button>
</div>
`


const enviarOTPCambio = `
<div class="op-card-cam">
    <h2>Escoja su medio de autenticación</h2>
    <select class="form-select" id="contact-method-select">
        <option value="SMS">Mensaje de Texto</option>
        <option value="EMAIL">Correo Electrónico</option>
    </select>  
    <button class="btn btn-info" id="cont-btn-pass">Continuar</button>
</div>
`;


const cambiarContrasennaPerfil = `
<div class="op-card-cam">
<div id="alert-container"></div>
 <h2>Nueva Contraseña</h2>
<div class="input-group">
    <input class="form-control" type="password" placeholder="Ingrese su contraseña..." id="input_contrasena">
    <button class="btn btn-primary" type="button" id="password_visibility">Ver</button>
</div>
<button class="btn btn-info" id="cont-btn-pass">Continuar</button>
</div>
`;




const editarUsuarioForm = `
<div class="edit-usr-cont">
<form>
<fieldset>
    
    <div class="form-group image-input-container">
        <div class="image-wrapper">
            <label for="image-upload" class="image-placeholder"></label>
            <img class="image-preview" src="" alt="Image preview">
            <input type="file" class="form-control-file d-none" id="image-upload" accept="image/*">
        </div>
        <label for="" class="form-label mt-2">Seleccione Imagen de Perfil</label>
    </div>

    <label class="col-form-label col-form-label-lg" for="">Nombre</label>
    <input class="form-control" type="text" placeholder="Ingrese Nombre" id="in-nombre">         

    <label class="col-form-label col-form-label-lg" for="">Primer Apellido</label>
    <input class="form-control" type="text" placeholder="Ingrese Primer Apellido" id="in-ape1">  

    <div class="form-check form-switch mt-3">
        <input class="form-check-input" type="checkbox" id="sw-el-ape2">
        <label class="form-check-label" for="flexSwitchCheckDefault">Eliminar Segundo Apellido</label>
    </div>

    <label class="col-form-label col-form-label-lg" for="">Segundo Apellido</label>
    <input class="form-control" type="text" placeholder="Ingrese Segundo Apellido" id="in-ape2">  
    <small id="" class="form-text text-muted">OPCIONAL.</small>
    
</fieldset>
<button id="btn-submit" type="button" class="btn btn-primary mt-4">Actualizar</button>
</form>

</div>
`;

const reiniciarCorreoHandler = () => {
    $("#cancel-btn").click(() => {
        handleCloseModal();
    })

    $('#cont-btn').click(() => {
        var ctrl = new ControlActions();
        var service = "Usuario/ResetContactMethods?type=email";
        ctrl.PutToAPI(service, {}, function (res) {
            console.log(res);
            if (res.error) {

            } else {
                location.reload();
                removeToken();
            }
        })
    })
}

const reiniciarCelularHandler = () => {
    $("#cancel-btn").click(() => {
        handleCloseModal();
    })

    $('#cont-btn').click(() => {
        var ctrl = new ControlActions();
        var service = "Usuario/ResetContactMethods?type=phone";
        ctrl.PutToAPI(service, {}, function (res) {
            console.log(res);
            if (res.error) {

            } else {
                location.reload();
                removeToken();
            }
        })
    })
}

const validarUsuarioContrasenaHandler = () => {
    let allowClose = true;


    $("#overlay").click(() => {
        if (allowClose) handleCloseModal();
    })

    $('#cont-btn-pass').click(() => {
        var otp = {};
        otp.medioContacto = $('#contact-method-select').val();
        otp.tipo = "CAMB";

        var ctrl = new ControlActions();
        var service = "OTP/Create";

        ctrl.PostToAPI(service, otp, function (res) {
            console.log(res);
            if (res.error) {

            } else {
                allowClose = false;
                confirmarOTPHandler(otp.medioContacto);
            }
        })
    })
}

const confirmarOTPHandler = (medioContacto) => {
    $('#inside-container').html(confirmarOTPCambio);
    numberInputLimiter($('#otp-input'), 999999, 6);

    $('#cont-btn-pass').click(() => {
        const otp = {};
        otp.medioContacto = medioContacto;
        otp.tipo = "CAMB";
        let codigo = $("#otp-input").val();

        if (!codigo) { codigo = 0; }

        var ctrl = new ControlActions();
        var service = `OTP/Validate?codigo=${codigo}`;

        ctrl.PostToAPI(service, otp, function (res) {
            console.log(res);
            if (res.error) {
                showAlertBox(res.error, 'danger', $(`#alert-container`));
            } else if (res.fatal) {
                messageCard("Perfil.", "¡Oh no!", res.fatal, $("#overlay"), "bg-danger");
                removeToken();
            } else {
                cambiarContrasenaHandler();
            };
        })
    })
}

const cambiarContrasenaHandler = () => {
    $('#inside-container').html(cambiarContrasennaPerfil);
    passwordInputVisibility($('#input_contrasena'), $('#password_visibility'));

    var ctrl = new ControlActions();
    var service = `Contrasena/Create`;


    $('#cont-btn-pass').click(() => {
        ctrl.PostToAPI(service, { valor: $('#input_contrasena').val() }, function (res) {
            console.log(res);
            if (res.error) {
                showAlertBox(res.error, 'danger', $(`#alert-container`));
            } else {
                location.reload();

            };
        })
    })


}

const editarUsuarioHandler = () => {
    $("#overlay").click(() => {
        handleCloseModal();
    })

    var imageSelected = "";
    var currentImage = null;

    $('.image-placeholder').click(function (e) {
        if (e.target == this && !imageSelected) {
            e.preventDefault();
            $('#image-upload').trigger('click');
        }
    });

    $('#image-upload').change(function () {
        var file = this.files[0];

        if (file && file.type.match(/^image\//)) {
            var reader = new FileReader();
            reader.onload = function () {
                $('.image-placeholder').remove();
                $('.image-preview').attr('src', reader.result).show();
                currentImage = reader.result.split(',')[1];
            }
            reader.readAsDataURL(file);
            imageSelected = true;
        }
        //$(this).val('');
    });

    $('.image-wrapper').on('click', '.image-preview', function (e) {
        if (imageSelected) {
            e.preventDefault();
            $('#image-upload').trigger('click');
        }
    });

    $('.image-preview').on('load', function () {
        imageSelected = true;
    });

    $('#image-upload').on('click', function () {
        $(this).val('');
    });

    $('#sw-el-ape2').change(() => {
        if ($('#sw-el-ape2').prop('checked')) {
            $('#in-ape2').val("")
            $('#in-ape2').prop('disabled', true)
        } else {
            $('#in-ape2').prop('disabled', false)
        }
    })

    $('#btn-submit').click(() => {
        let nombreVal = $('#in-nombre').val();
        let priApVal = $('#in-ape1').val();
        let segApVal = $('#sw-el-ape2').prop('checked') ? null : $('#in-ape2').val();
        let fotoVal = currentImage;
        const req = { nombre: nombreVal, primerApellido: priApVal, segundoApellido: segApVal, foto: fotoVal };

        var ctrl = new ControlActions();
        var service = "Usuario/Update";
        console.log(req)
        ctrl.PutToAPI(service, req, function (res) {
            console.log(res);
            if (res.error) {

            } else {
                location.reload();
            }
        })
    })

}

const content = {
    'editar-datos': {
        form: editarUsuarioForm,
        handler: editarUsuarioHandler
    },
    'cambiar-pass': {
        form: enviarOTPCambio,
        handler: validarUsuarioContrasenaHandler
    },
    'resetear-email': {
        form: confirmarEleccion(`Al reiniciar su correo eletrónico será devuelto a la pantalla de inicio de sesión; deberá ingresar exitosamente y confirmar con su nuevo email.`),
        handler: reiniciarCorreoHandler
    },
    'resetear-tel': {
        form: confirmarEleccion(encodearTildes(`Al reiniciar su número telefónico ser&aacute; devuelto a la pantalla de inicio de sesi&oacute;n; deberá ingresar exitosamente y confirmar con su nuevo número telefónico.`)),
        handler: reiniciarCelularHandler
    }
}
