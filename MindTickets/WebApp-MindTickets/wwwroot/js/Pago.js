function PagoController() {
    this.ViewName = "Pago";

    this.InitView = function () {
        console.log("Pago view init");
        this.LoadCart();
    }

    this.LoadCart = function () {
        const targetTitle = $('#title');
        let title = localStorage.getItem("Name");
        targetTitle.text(title);
        const targetTitle = $('#tickets');
        let title = localStorage.getItem("Name");
        targetTitle.text(title);
    }
}
$(document).ready(function () {
    var view = new PagoController();
    view.InitView();
});