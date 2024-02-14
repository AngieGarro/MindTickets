// Clase JS controlador de la vista
// Membership.csthml

// Esta función define el nombre de la clase en JS



function MembershipController() {
    this.ViewName = "Membership";
    this.ApiService = "MembershipClient"

    var membershipList = [];
    this.memberships = [];

    this.InitView = function () {
        console.log("Membership view init");


        // Invocamos la función de carga de la tabla y tarjetas luego de cargada la página
        this.LoadCards();
        //this.LoadTable();
        


        

        // Buttons //
        $(document).on('click', '#btnBuy', function (evt) {
            window.location.href = ("https://localhost:7176/checkout");
            return false;
        }); 
                
    }

    $(document).ready(function () {
        $('#tblMemberships').DataTable({
            responsive: true,
            "ajax": {
                "url": 'https://localhost:7042/api/MembershipClient/RetrieveAll',
                "type": "GET",
                "datatype": "json"
            },
            "columns": [
                { "data": "clave" },
                {
                    "defaultContent": '<button class="btn btn-primary btn-editar btn-sm mr-2"></button>' +
                        '<button class="btn btn-danger btn-eliminar btn-sm "></button>',
                    "orderable": false,
                    "searchable": false,
                    "width": "80px"
                }
            ],
            order: [[0, "desc"]],
            dom: "Bfrtip",
            buttons: [
                {
                    text: 'Exportar Excel',
                    extend: 'excelHtml15',
                    title: '',
                    filename: 'Reporte Membresías',
                    exportOptions: {
                        columns: [1, 2]
                    }
                }, 'pageLength'
            ],
            language: {
                url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
            },
        });
    });


    
    // Retrieve All Memberships - Página de Membresías //
    this.LoadCards = function () {

        var ctrlActions = new ControlActions();
        var urlService = "MembershipClient/RetrieveAll";

        // Función que llama lo que se encuentra en la base de datos y crea HTML Cards
        ctrlActions.GetToApi(urlService, function (data) {
            //console.log(JSON.stringify(data));
            data.forEach(function (data) {
                $("#membership-cards").append(`<div class="memb_card" id="${data.id}">                
                            <h3 class="card-title">${data.membershipName}</h3>
                            <p>${data.description}</p>
                            <i class="bi bi-ticket-detailed"></i>  <p> Cantidad de ticket: ${data.ticketLimit}</p>                                                      
                            <i class="bi bi-calendar2-event"></i> <p>Cantidad de eventos: ${data.eventLimit}</p>
                            <i class="bi bi-bank"></i><p>Comisión: ₡${data.commission}</p>
                            <i class="bi bi-ticket-detailed"></i>  <p>Costo: ₡${data.price}</p>                     

                            <div class="buttons-container">
                                <button type="button" class="btn btn-secondary" id="btnBuy">Comprar</button>
                            </div>  
                </div>`)
            })
        })
    }


    



    this.LoadTable = function () {
        
        var ctrlActions = new ControlActions();        
        var urlService = ctrlActions.GetUrlApiService(this.ApiService + "/RetrieveAll");
        
        console.log(test);
        
            var columns = [];
            columns[0] = { 'data': 'Id' };
            columns[1] = { 'data': 'MembershipName' };
            columns[2] = { 'data': 'Description' };
            columns[3] = { 'data': 'TicketLimit' };
            columns[4] = { 'data': 'Commission' };
            columns[5] = { 'data': 'EventLimit' };
            columns[6] = { 'data': 'Price' };

            $("#tblMemberships").DataTable({
                "ajax": {
                    "url": urlService,
                    "dataSrc": ""
                },
                "columns": columns
            });        
    }

    /* Admin Dashboard Table Creation */
    const GetMembTable = 


    //  CRUD Functions  //

    this.EditMembership = (membership) => {
        var ctrlActions = new ControlActions();
        var urlService = "MembershipClient/Update";

        ctrlActions.PutToAPI(urlService, membership, function () {
            console.log("Membresía enviada al API para actualizar");
        });
    };

    this.CreateMembership = (membership) => {
        var ctrlActions = new ControlActions();
        var urlService = "MembershipClient/Create";
        ctrlActions.PostToAPI(urlService, membership, function () {
            console.log("Membresía enviada al API");
        });
    };

    this.DeleteMembership = (idmembership) => {
        console.log("Delete");
        var ctrlActions = new ControlActions();
        ctrlActions.DeleteToAPI(this.ApiService + "/Delete", idmembership);
    }; 
}



$(document).ready(function () {
    var view = new MembershipController();
    view.InitView();
});