// Clase JS controlador de la vista
function EventsAllController() {
    this.ViewName = "EventsAll";
    this.ApiService = "Events"

    this.InitView = function () {
        console.log("Events view init");
    }
}
// Retrieve All Events - Página de Membresías //
$(document).ready(function () {

    var ctrlActions = new ControlActions();
    var urlService = "Events/RetrieveAllEvents";

    // Función que llama lo que se encuentra en la base de datos y crea HTML Cards
    ctrlActions.GetToApi(urlService, function (data) {
        console.log(JSON.stringify(data));
        data.forEach(function (data) {
            $("#cards").append(`<div class="card" style="width: 18rem;"> 
                        <img src="${data.logo}" class="card-img-top" style="width:285px; height:250px;">
                         <div class="card-body">
                            <h5 class="card-title" id="title">${data.eventName}</h5>
                            <p class="card-text">${data.description}</p>
                             <div class="buttons-container">
                                <a href="https://localhost:7161/GestorDashboard/SelectEvent" id="btnDetails" class="btn btn-primary">Ver Detalles</a>
                             </div> 
                         </div>
                          <p id="eventId" hidden="hidden">${data.id}</p>
                </div>`)
        })
    })
});
