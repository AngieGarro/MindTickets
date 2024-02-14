const BaseModel = {
    id: 0,
    eventName: "",
    description: "",
    date: 0,
    time: 0
}


function Events() {

    this.InitView = function () {
        console.log("Events view init");

        this.LoadEvents();

        $("#btnSend").click(function () {
            var view = new MessagesController();
            view.Create();
        })
    }

    this.LoadEvents = function () {    
        
        tablaData = $('#tbdata').DataTable({
            responsive: true,
            "ajax": {
                "url": "https://localhost:7042/api/Events/RetrieveAllEvents",
                "dataSrc": "",
                "type": "GET",
                "datatype": "json"
            },
            "columns": [
                { "data": "id" },
                { "data": "eventName" },
                { "data": "modality", "visible": false, "searchable": false },
                { "data": "logo", "visible": false, "searchable": false },
                { "data": "slogan", "visible": false, "searchable": false },
                { "data": "dateAndTime" },
                { "data": "description", "visible": false, "searchable": false },
                { "data": "restrictions", "visible": false, "searchable": false },
                { "data": "organizerName", "visible": false, "searchable": false },
                { "data": "creatorId", "visible": false, "searchable": false },
                { "data": "eventPhoneNumber" },
                { "data": "eventEmail" },
                { "data": "eventWebSite" },
                { "data": "eventCategory" },
                
            ],
            order: [[0, "asc"]],
            dom: "Bfrtip",
            language: {
                url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
            },
        });
    }
}

$(document).ready(function () {
    var view = new Events();
    view.InitView();
});


