// Clase JS controlador de la vista
// EventsAll.csthml
function EventsAllController() {
    this.ViewName = "EventsAll";
    this.ApiService = "Events"

    this.InitView = function () {
        console.log("Events view init");

        //Va a contener el create de todos los elementos del evento:
        $("#btnCreate").click(function () {
            var view = new EventsAllController();
            view.RegisterEvent();
        })

        //Display Data
        this.LoadEvents();
    }
}

$(document).ready(function () {
    // Elemento contenedor
    const container = $("#container");

    // Cambiando el contenido del contenedor y modificando las vistas
    $("#btnEvents").click(function () {
        $('html, body').animate({ scrollTop: 0 }, '200');
        container.empty();
        container.append(membershipList);
        var view = new MembershipController();
        view.InitView();
    });

    const membershipList = `<div class="card-body">                                     
                    <h1 class="system_membership_h1">Todos los Eventos</h1>
                    <div id="memblist_container"></div>
                </div>`;
});