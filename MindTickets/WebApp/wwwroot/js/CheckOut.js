function CheckOutController() {
    this.ViewName = "CheckOut";

    localStorage.setItem("Name", "Gratuita");
    localStorage.setItem("Tickets", "10");
    localStorage.setItem("Events", "5");
    localStorage.setItem("Costo", "10000");
    localStorage.setItem("Tax", "13%");
    localStorage.setItem("Total", "11300");
    localStorage.setItem("UserName", "Cristian");
    localStorage.setItem("Email", "csalazarg@ucenfotec.ac.cr");


    this.InitView = function () {
        console.log("CheckOut view init");
        //this.RecoverTax();
        this.LoadCart();
    }

    this.LoadCart = function () {
        
        const targetTitle = $('#title');
        let title = localStorage.getItem("Name");
        targetTitle.text("Subscripción: "+title);
       
        const targetTicket = $('#tickets');
        let ticket = localStorage.getItem("Tickets");
        targetTicket.text("Tickets: "+ticket);

        const targetEvents = $('#events');
        let event = localStorage.getItem("Events");
        targetEvents.text("Eventos: "+event);

        const targetCost = $('#cost');
        let cost = localStorage.getItem("Costo");
        targetCost.text("Costo: " + cost);

        const targetTax = $('#tax');
        let tax = localStorage.getItem("Tax");
        targetTax.text("Impuesto: " + tax);

        const targetTax = $('#tax');
        let tax = localStorage.getItem("Tax");
        targetTax.text("Impuesto: " + tax);

        const targetEmail = $('#email');
        let email = localStorage.getItem("Email");
        targetEmail.text("Email: " + email);
    }

    this.RecoverTax = function () {
        var ctrlActions = new ControlActions();
        var urlService = "TaxClient/RetrieveTax";
    }

}

$(document).ready(function () {
    var view = new CheckOutController();
    view.InitView();
});