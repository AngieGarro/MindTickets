$(document).ready(function () {

    $("#120").click(function () {
        $(".mapdiv path").click(function () {
            $(this).toggleClass("selected-path");
        });
        $(document).ready(function () {
            LoadSeats();
        });

    });

    $("#121").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#11").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#12").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#113").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#114").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#116").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#115").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#117").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#118").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#119").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#121").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#122").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#123").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#124").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });
    });
    $("#125").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });
    });
    $("#126").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });
    });
    //-----
    $("#101").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#102").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#FFA").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#FCC").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#FBB").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#203").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#211").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#202").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#201").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#226").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#225").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#224").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#223").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#222").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });
    });
    $("#220").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });
    });
    $("#221").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });
    });
    //--------
    $("#219").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#218").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#217").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#216").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#215").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#214").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#213").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });
    $("#212").click(function () {

        $(document).ready(function () {
            LoadSeats();
        });

    });


    function displaySectorNames(seatData) {
        seatData.forEach(seat => {
            alert(seat.sectorName);
        });
    }

    //fetchData();

    function toggleFill(element) {
        var svgElement = element.find("path");
        if (svgElement.attr("fill") === "#ff0000") {
            svgElement.removeAttr("fill");
        } else {
            svgElement.attr("fill", "#ff0000");
        }
    }

    /* Funcion para estirar la tabla al hacer scroll */
   

});

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
            populateSeats(response);
        },
        error: function (error) {
            console.error("Error al cargar los asientos:", error);
        },
    });
}
function populateSeats(seats) {
    var selectedSeats = [];
    var seatMap = $(".seat-map");
    seatMap.empty();

    var seatMapContainer = $(".seat-map-container");

    if (!seatMapContainer.hasClass("open")) {
        seatMapContainer.addClass("open");
        seatMapContainer.slideDown("slow", function () {
            var containerOffset = seatMapContainer.offset().top;
            $("html, body").animate({
                scrollTop: containerOffset
            }, "slow");
        });
    }

    seats.forEach(function (seat) {
        var seatDiv = $('<div class="seat">' + seat.seatNumber + '</div>');
        seatDiv.click(function () {

            var isSelected = $(this).toggleClass("selected-seat");

            var seatNumber = seat.seatNumber;
            var seatCard = $("#stretchable-card");


            // Muestra el card y ajusta su contenido
            //seatCard.show();
            seatCard.slideDown(400);
            // Agregar o quitar el número de asiento del array de asientos seleccionados
            var index = selectedSeats.indexOf(seatNumber);
            if (isSelected) {
                if (index === -1) {
                    selectedSeats.push(seatNumber);
                }
            } else {
                if (index !== -1) {
                    selectedSeats.splice(index, 1);
                }
            }

            
            updateCart(selectedSeats);

        });
        seatMap.append(seatDiv); // Agrega los asientos al div
    });
}

function updateCart(selectedSeats) {
    // Obtener el elemento del carrito
    var cartElement = $(".cartData");

    // Limpiar el contenido anterior
    cartElement.empty();

    // Crear elementos "card" para cada número de asiento seleccionado
    selectedSeats.forEach(function (seatNumber) {
        var card = $(
            '<tr class="table-row">' +
            '<td>' + seatNumber + '</td>' +
            '<td>123 colones</td>' +
            '<td id="Eliminar" class="text-right py-0 align-middle ">' +
            ' <svg xmlns="http://www.w3.org/2000/svg" class="icon icon-tabler icon-tabler-trash-x-filled" width="20" height="20" viewBox="0 0 24 24" stroke-width="1.5" stroke="#2c3e50" fill="none" stroke-linecap="round" stroke-linejoin="round"> ' +
            ' < path stroke = "none" d = "M0 0h24v24H0z" fill = "none" />' +
            ' <path d="M20 6a1 1 0 0 1 .117 1.993l-.117 .007h-.081l-.919 11a3 3 0 0 1 -2.824 2.995l-.176 .005h-8c-1.598 0 -2.904 -1.249 -2.992 -2.75l-.005 -.167l-.923 -11.083h-.08a1 1 0 0 1 -.117 -1.993l.117 -.007h16zm-9.489 5.14a1 1 0 0 0 -1.218 1.567l1.292 1.293l-1.292 1.293l-.083 .094a1 1 0 0 0 1.497 1.32l1.293 -1.292l1.293 1.292l.094 .083a1 1 0 0 0 1.32 -1.497l-1.292 -1.293l1.292 -1.293l.083 -.094a1 1 0 0 0 -1.497 -1.32l-1.293 1.292l-1.293 -1.292l-.094 -.083z" stroke-width="0" fill="currentColor" /> ' +
            ' <path d="M14 2a2 2 0 0 1 2 2a1 1 0 0 1 -1.993 .117l-.007 -.117h-4l-.007 .117a1 1 0 0 1 -1.993 -.117a2 2 0 0 1 1.85 -1.995l.15 -.005h4z" stroke-width="0" fill="currentColor" /> ' +
            ' </svg > ' +
            '</td>' +
            '</tr>'
        );

        card.find(".icon").click(function () {

            var rowIndex = card.index();
            selectedSeats.splice(rowIndex, 1);
            var seatNumber = card.find("td:first-child").text();
            var seatDiv = $('.seat:contains("' + seatNumber + '")');
            seatDiv.removeClass("selected-seat");
            card.remove();

        });

        cartElement.append(card); // Agregar la tarjeta al carrito
    });
}