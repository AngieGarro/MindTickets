// Call the function to read the JSON object from the cookie
var MembershipJson = readJsonFromCookie("MembershipJson");
var UserJson = readJsonFromCookie("UserJson");
var TaxJson = readJsonFromCookie("TaxJson");
var EventJson = readJsonFromCookie("EventJson");
var CheckOutTicket = readJsonFromCookie("CheckOutTicketJson");



function EventsDetailsController() {
    this.ViewName = "EventsDetails";
    this.ApiService = "Events"

    this.InitView = function () {
        console.log("Events view init");
        this.LoadCartEvent();
    }

    $("#payTicket").click(function () {
        var view = new EventsDetailsController();
        view.ToCheckOut();
    })

  
    //CheckOut Tickets
    this.LoadCartEvent = function () {
        this.RecoverTax();
        var trans = this.TransactionID();
        var user = JSON.parse(UserJson);
        var event = JSON.parse(CheckOutTicketJson);
        var tax = JSON.parse(TaxJson);


        const targetTitle = $('#eventName');
        let title = event.eventName;
        targetTitle.text(title);

        const targetTicket = $('#eventDate');
        let ticket = event.eventDate;
        targetTicket.text(ticket);

        const targetCost = $('#cost');
        let cost = parseFloat(membership.price);
        targetCost.text("Costo: ₡" + cost);

        const targetTax = $('#tax');
        let iv = parseFloat(tax.amount);
        let taxApplied = parseFloat(iv * cost);
        targetTax.text("Impuesto: ₡" + taxApplied);

        const targetTotal = $('#total');
        let total = taxApplied + cost;
        targetTotal.text("Total: ₡" + total);

        const buyer = $('#name');
        let Username = user.fullName + " " + user.lastName;
        buyer.text("Nombre: " + Username);

        const targetEmail = $('#email');
        let email = user.email;
        targetEmail.text("Email: " + email);


        return dataSunpe = {
            uban: "",
            amount: total,
            description: title,
            sender: email,
            transactionId: trans,
        }
        console.log("Modal --> " + JSON.stringify(dataSunpe));

    }
    this.ToCheckOut = function () {
        alert("clicked");
        var event = JSON.parse(EventJson);

        $("#getCheckedButton").click(function () {
            var checkedCheckboxes = $(".form-check-input:checked");
            var result = "";

            checkedCheckboxes.each(function () {
                result += $(this).val() + " ";
            });

            var body = {
                id: event.id,
                name: ("#eventName").text(),
                description: ("#descriptionEvent").text(),
                ticketType: result,
                ticketSeat: ("#stretchable-card").text()
            };

            var jsonMString = JSON.stringify(body);
            document.cookie = "CheckOutTicketJson=" + encodeURIComponent(jsonMString) + "; expires=Fri, 31 Dec 9999 23:59:59 GMT; path=/";
            console.log("JSON object saved in cookie.");
            console.log(document.cookie);
            console.log("Compra --> " + JSON.stringify(body));
            window.location.href = '/Home/CheckOutTicket/';
            
        })
    }

    this.RecoverTax = function () {
        $.ajax({
            "url": 'https://localhost:7042/api/TaxClient/RetrieveById?id=1',
            method: 'GET',
            success: function (data) {
                console.log("TaxDATA --> " + JSON.stringify(data));
                var jsonString = JSON.stringify(data);
                document.cookie = "TaxJson=" + encodeURIComponent(jsonString) + "; expires=Fri, 31 Dec 9999 23:59:59 GMT; path=/";
            }
        })
    }

    this.TransactionID = function () {
        const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
        const length = 10;
        let transactionID = '';
        for (let i = 0; i < length; i++) {
            const randomIndex = Math.floor(Math.random() * characters.length);
            transactionID += characters.charAt(randomIndex);
        }
        return transactionID;
    }

    this.SendToTransaction = function () {
        // To Be done!  
    }   

}


$(document).on('click', '#btnDetails', function (evt) {

    var card = $(this).closest('.card');

    var body = {
        id: card.find("#eventId").text(),
    };
    var jsonEString = JSON.stringify(body);
    console.log("card --> " + JSON.stringify(body));
    console.log("jsonObject --> " + JSON.stringify(jsonEString));
    document.cookie = "EventJson=" + encodeURIComponent(jsonEString) + "; expires=Fri, 31 Dec 9999 23:59:59 GMT; path=/";
    console.log("JSON object saved in cookie.");
    console.log(document.cookie);

    window.location.href = '/GestorDashboard/SelectEvent/';

    console.log("Event --> " + JSON.stringify(body));

});
// Retrieve All Events - Página de Detalle del Evento //
$(document).ready(function () {
    var EventObject = JSON.parse(EventJson);
    var eventId = EventObject.id;
    console.log(eventId);
    var URL = "https://localhost:7042/api/DetailsEvents/RetrieveByIdDetailsEvents?Id=" + eventId;
    $.ajax({
        "url": URL,
        method: 'GET',
        success: function (data) {

            var desiredEvent = data;
            console.log(desiredEvent);
            if (desiredEvent) {
                // Update the HTML with the retrieved product data
                $('#eventName').text(desiredEvent.eventName);
                $('#descriptionEvent').text(desiredEvent.description);
                $('#priceVIP').text(desiredEvent.priceTicketVIP);
                $('#priceRegular').text(desiredEvent.priceTicketRegular);
                $('#priceEspecial').text(desiredEvent.priceTicketSpecial);
                $('#eventImage').attr('src', desiredEvent.logo);

            } else {
                console.log('Event not found');
            }
            console.log(desiredEvent.eventName)
        }
    })
});

// Retrieve Information on Cookies
function readJsonFromCookie(cookieName) {
    // Get the cookie value
    var name = cookieName + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var cookieArray = decodedCookie.split(';');
    var jsonValue = null;

    for (var i = 0; i < cookieArray.length; i++) {
        var cookie = cookieArray[i].trim();
        if (cookie.indexOf(name) === 0) {
            return cookie.substring(name.length, cookie.length);
            break;
        }
    }
    return null;

    if (jsonValue) {
        // Parse the JSON string into an object
        var jsonObject = JSON.parse(jsonValue);
        console.log("JSON object retrieved from cookie:", jsonObject);
        return jsonObject;
    } else {
        console.log("JSON object not found in cookie.");
        return null;
    }

}
/*
$(document).on('click', '#payTicket', function (evt) {

        var event = JSON.parse(EventJson);

        $("#getCheckedButton").click(function () {
            var checkedCheckboxes = $(".form-check-input:checked");
            var result = "";

            checkedCheckboxes.each(function () {
                result += $(this).val() + " ";
            });

            var body = {
                id: event.id,
                name: ("#eventName").text(),
                description: ("#descriptionEvent").text(),
                ticketType: result,
                ticketSeat: ("#stretchable-card").text()
            };

            var jsonMString = JSON.stringify(body);
            document.cookie = "CheckOutTicketJson=" + encodeURIComponent(jsonMString) + "; expires=Fri, 31 Dec 9999 23:59:59 GMT; path=/";
            console.log("JSON object saved in cookie.");
            console.log(document.cookie);

            window.location.href = '/Home/CheckOutTicket/';
            console.log("Compra --> " + JSON.stringify(body));
        })
});
*/