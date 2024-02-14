$(document).ready(function () {
	// Elemento contenedor
	const container = $("#container");

	// Cambiando el contenido del contenedor y modificando las vistas
	$("#btnMembresias").click(function () {
		$('html, body').animate({ scrollTop: 0 }, '200');
		container.empty();
		container.append(membershipList);
		var view = new MembershipController();
		view.InitView();
	});

	$("#btnDelete").click(function () {
		var view = new MembershipController();
		view.DeleteMembership();
	});

	const membershipList = `<div class="report-table"">                                     
                    <h1 class="system_Dashboard_h1">Membresías del Sistema</h1>
                    <div id="memblist_container"></div>
                </div>`;
});