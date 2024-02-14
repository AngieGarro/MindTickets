$(document).ready(function () {

    $("#120").click(function () {
        //$("#descripcion1").slideToggle("slow");
        function LoadSeats() {
            var apiUrl = "https://localhost:7042/api/Stage/RetrieveById"; 
            var IdEvent = 1;
            var IdStage = 1;
            var SectorId = 1;

            $.ajax({
                url: apiUrl,
                type: "GET",
                data: {
                    IdEvent: IdEvent,
                    IdStage: IdStage,
                    SectorId: SectorId
                },
                dataType: "json",
                success: function (response) {
                    populateSeats(response); // Llama a populateSeats con la respuesta del API
                },
                error: function (error) {
                    console.error("Error al cargar los asientos:", error);
                },
            });
        }
        function populateSeats(seats) {
            var seatMap = $(".seat-map");
            seatMap.empty(); // Limpia el contenido existente

            seats.forEach(function (seat) {
                var seatDiv = $('<div class="seat">' + seat.seatNumber + '</div>');
                seatMap.append(seatDiv); // Agregar el elemento <div> al contenedor de asientos
            });
        }

        $(document).ready(function () {
            LoadSeats(); // Carga los asientos al cargar la página
        });
    });
    $("#sector2").click(function () {
        // $("#descripcion2").slideToggle("slow");
        alert("hola");
    });
    $("#boton3").click(function () {
        //$("#descripcion3").slideToggle("slow");
        alert("hola");
    });
    $("#btnDatePicker").click(function () {
        alert("hola2");
        $("#datepicker").datepicker();
    });

    

    function displaySectorNames(seatData) {
        seatData.forEach(seat => {
            alert(seat.sectorName); // Muestra el nombre del sector en una alerta
        });
    }

    fetchData();

});


//Script para minimizar los fomularios
$(document).ready(function () {
    var formulario1 = $("#form1");
    var formulario2 = $("#formulario2");

    $("#minimizar").click(function () {
        formulario1.fadeOut("slow", function () {
            formulario2.fadeIn("slow");
        });
    });

    $("#restaurar").click(function () {
        formulario2.fadeOut("slow", function () {
            formulario1.fadeIn("slow");
        });
    });





});

        