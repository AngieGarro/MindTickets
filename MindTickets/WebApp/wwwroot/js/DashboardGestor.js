$(document).ready(function () {
    // Elemento contenedor
	const container = $("#container-Gestor");

    // Cambiando el contenido del contenedor y modificando las vistas
    $("#CreateEvent").click(function () {
        $('html, body').animate({ scrollTop: 0 }, '200');
        container.empty();
        container.append(EventList);
        var view = new EventsAllController();
        view.InitView();
    });

    const EventList = `<div class="container-createEvent">
					   <h2>Crear Evento</h2>
					   <br/>
					   <form>
					    <div class="form-group row">
						    <label for="staticEmail" class="col-sm-2 col-form-label">Nombre del Evento</label>
						    <div class="col-sm-10">
		                    <input type="text" readonly="" class="form-control-plaintext" id="staticEmail" value="email@example.com">
                        </div>
                        <div class="form-group row">
						    <label for="staticEmail" class="col-sm-2 col-form-label">Detalles del Evento</label>
						    <div class="col-sm-10">
		                    <input type="text" readonly="" class="form-control-plaintext" id="staticEmail" value="email@example.com">
                        </div>
                        <div class="form-group row">
						    <label for="staticEmail" class="col-sm-2 col-form-label">Restricciones</label>
						    <div class="col-sm-10">
		                    <input type="text" readonly="" class="form-control-plaintext" id="staticEmail" value="email@example.com">
                        </div>
                        <div class="form-group row">
						    <label for="staticEmail" class="col-sm-2 col-form-label">Nombre completo del organizador</label>
						    <div class="col-sm-10">
		                    <input type="text" readonly="" class="form-control-plaintext" id="staticEmail" value="email@example.com">
                        </div>
						<br/>
						<button type="button" class="btn btn-outline-success">Crear</button>
						<br/>
						<br/>
						<a type="button" class="btn btn-outline-primary asp-page="/GestorDashboard">Volver</a>
						</form>
						</div>`;

});

