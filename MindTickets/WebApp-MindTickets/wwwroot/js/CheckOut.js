// Call the function to read the JSON object from the cookie
var MembershipJson = readJsonFromCookie("MembershipJson");
var UserJson = readJsonFromCookie("UserJson");
var TaxJson = readJsonFromCookie("TaxJson");
var TransJson = readJsonFromCookie("TransActionJson");


const BaseModel = {
    uban: "",
    amount: 0,
    description: "",
    sender: "",
    transactionId: "",    
}

function CheckOutController() {
    this.ViewName = "CheckOut";


    this.InitView = function () {
        console.log("Init view");
        this.LoadCart();
        

        $("#btnSunpe").click(function () {
            var view = new CheckOutController();
            view.showModal();
        })

        $("#btnPaypal").click(function () {
            var view = new CheckOutController();            
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Paypal Disponible Próximamente!'                
            })
        })

        $("#btnSave").click(function () {
            var view = new CheckOutController();
            view.sendToSUNPE();
        })
        /*
        
        this.Receipt();
        */

    }

    this.LoadCart = function () {
        this.RecoverTax();
        var trans = this.TransactionID();
        var user = JSON.parse(UserJson);
        var membership = JSON.parse(MembershipJson);
        var tax = JSON.parse(TaxJson);
        var userId = 109800987;

        const targetTitle = $('#title');
        let title = membership.name;
        targetTitle.text("Subscripción: "+title);
       
        const targetTicket = $('#tickets');
        let ticket = membership.tickets;
        targetTicket.text(ticket);

        const targetEvents = $('#events');
        let event = membership.events; 
        targetEvents.text(event);

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
        let Username = "Cristian Salazar";//user.fullName + " " + user.lastName;
        buyer.text("Nombre: " + Username);

        const targetEmail = $('#email');
        let email = "csalazar@yahoo.com";//user.email;
        targetEmail.text("Email: " + email);



        var transaction = {            
            idTransaction: trans,
            membID: membership.id,
            cedula: userId,
            userEmail: "ks@nime.com",
            totalAmount: cost,
            taxApplied: taxApplied,
            finalAmount: total,
            status: "Ok",
            provider: "SUNPE",
            merchant: "DevMinds S.A"

        }

        var jsonString = JSON.stringify(transaction);
        document.cookie = "TransActionJson=" + encodeURIComponent(jsonString) + "; expires=Fri, 31 Dec 9999 23:59:59 GMT; path=/";

        return dataSunpe = {
            uban: "",
            amount: total,
            description: title,
            sender: email,
            transactionId: trans,            
        }

        
        
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

    // Testing Area //
    this.showModal = function (model = dataSunpe) {
        $("#txtUban").val(model.uban)
        $("#txtAmount").val(model.amount)
        $("#txtDescription").val(model.description)
        $("#txtSender").val(model.sender)
        $("#txtTransaction").val(model.transactionId)
        $("#modalData").modal("show")
    }


    this.sendToSUNPE = function () {
        var sunpe = {};
        sunpe.uban = $("#txtUban").val();
        sunpe.amount = $("#txtAmount").val();
        sunpe.description = $("#txtDescription").val();
        sunpe.sender = $("#txtSender").val();        
        sunpe.transactionId = $("#txtTransaction").val();
        sunpe.status = "Aceptada";

        console.log("SUNPE --> " + JSON.stringify(sunpe));

        var ctrlActions = new ControlActions();
        var urlService = "SUNPE/SENDTEF";

        ctrlActions.PostToAPI(urlService, sunpe, function () {
            console.log("Data enviada al API");
            $("#modalData").modal("hide");
        });    
        this.CreateTransaction();

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

    this.ExchangeRate = function () {
        $.ajax({
            "url": 'https://localhost:7042/api/TaxClient/RetrieveById?id=3',
            method: 'GET',
            success: function (data) {
                console.log("TaxDATA --> " + JSON.stringify(data));
                var jsonString = JSON.stringify(data);
                document.cookie = "ERJson=" + encodeURIComponent(jsonString) + "; expires=Fri, 31 Dec 9999 23:59:59 GMT; path=/";
            }
        })
    }   

    this.CreateTransaction = function () {
        var trans = JSON.parse(TransJson);
        console.log(trans);
        var ctrlActions = new ControlActions();
        var urlService = "TransactionClient/Create";

        ctrlActions.PostToAPI(urlService, trans, function () {
            console.log("Trasaction --> Data enviada al API");

        });
    };

}


// Modal Handling //
function showModal(model = dataSunpe) {
    $("#txtUban").val(model.uban)
    $("#txtAmount").val(model.amount)
    $("#txtDescription").val(model.description)
    $("#txtSender").val(model.sender)
    $("#modalData").modal("show")

}

$(document).ready(function () {
    var view = new CheckOutController();
    view.InitView();
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