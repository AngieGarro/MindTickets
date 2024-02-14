function DashboardClient() {
    this.ViewName = "Dashboard Client";

    this.InitView = function () {        

        this.LoadMyFutureEvents();
        this.LoadMyPastEvents();
        this.Cloudinary();
        

        $("#btnImagen").click(function () {
            alert("imagen");
            console.log("pressed");
            var view = new DashboardClient();
            view.Cloudinary();
        })

        $("#btnUpadePWD").click(function () {            
            var view = new DashboardClient();
            view.ResetPassword();
            
        })
        
    }

    this.LoadMyFutureEvents = function () {

        console.log("LoadMyFutureEvents");

        var cedula = userObject.id;
        
        var URL = "https://localhost:7042/api/Ticket/RetrieveMyFutureEvents?id=" + cedula;
        console.log(URL);
        // Función que llama lo que se encuentra en la base de datos y crea HTML Cards

        $.ajax({
            url: URL,
            type: "GET",
            //dataType: "json",
            // data: JSON.stringify({ email: Email }), // Enviar el objeto con propiedad 'email'
            //contentType: "application/json",
            success: function (data) {
                data.forEach(function (data) {
                    $("#tickets-cards").append(`<div class="tick_card">                
                            <div class="card mb-3" style="max-width: 540px;">
	                            <div class="row g-0">
		                            <div class="col-md-4">
			                            <img src="${data.logo}" class="img-fluid rounded-start" style="height:100%" />
		                            </div>
		                        <div class="col-md-8">
			                <div class="card-body">
				                    <h2 class="card-title">${data.eventName}</h2>
				                    <p class="card-text"><small class="text-body-secondary">Ubicacion: ${data.exactAddress}</small></p>
                                    <p class="card-text"><small class="text-body-secondary">${data.province},${data.canton}</small></p>
				                    <h5>${data.eventTime}</h5>				

				            <div class="row">
					            <div class="col-sm-6 mb-3 mb-sm-0">
						            <div class="card">
							            <div class="card-body" style="background-color:darkseagreen">
								            <h5 class="card-title">${data.ticketSeatInfo}</h5>
								            <p class="card-text">${data.seatNumber}</p>
								            <br />
							            </div>
						            </div>
					            </div>					
				            </div>`)
                });

            }
        });
        

    }

    this.LoadMyPastEvents = function () {        

        var cedula = userObject.id;

        var URL = "https://localhost:7042/api/Ticket/RetrieveMyPastEvents?id=" + cedula;
        console.log(URL);        

        $.ajax({
            url: URL,
            type: "GET",
            //dataType: "json",
            // data: JSON.stringify({ email: Email }), // Enviar el objeto con propiedad 'email'
            //contentType: "application/json",
            success: function (data) {
                data.forEach(function (data) {
                    $("#history-cards").append(`<div class="tick_card">                
                            <div class="card mb-3" style="max-width: 540px;">
	                            <div class="row g-0">
		                            <div class="col-md-4">
			                            <img src="${data.logo}" class="img-fluid rounded-start" style="height:100%" />
		                            </div>
		                        <div class="col-md-8">
			                <div class="card-body">
				                    <h2 class="card-title">${data.eventName}</h2>
				                    <p class="card-text"><small class="text-body-secondary">Ubicacion: ${data.exactAddress}</small></p>
                                    <p class="card-text"><small class="text-body-secondary">${data.province},${data.canton}</small></p>
				                    <h5>${data.eventTime}</h5>				

				            <div class="row">
					            <div class="col-sm-6 mb-3 mb-sm-0">
						            <div class="card">
							            <div class="card-body" style="background-color:darkseagreen">
								            <h5 class="card-title">${data.ticketSeatInfo}</h5>
								            <p class="card-text">${data.seatNumber}</p>
								            <br />
							            </div>
						            </div>
					            </div>					
				            </div>`)
                });

            }
        });

    }

    this.Cloudinary = function () {
        myWidget.open();
        var myWidget = cloudinary.createUploadWidget({
            cloudName: 'csalazarg',
            uploadPreset: 'hz2ilnkl'
        }, (error, result) => {
            if (!error && result && result.event === 'success') {
                console.log('Imagen subida: ', result.info);
                ImageUrl = result.info.secure_url;
                $('#ProfilePicture').attr('src', ImageUrl);
            }
        });
    }

    this.ResetPassword = function () {
        alert("Actualizando Clave");
        var Email = userObject.email;
        var Password = $("#txtNewPWD").val();
        var updatePWD = "https://localhost:7042/api/Auth/PasswordReset?pwrd=" + encodeURIComponent(Password) + "&email=" + encodeURIComponent(Email);

        var password2 = $("#txtConfirmPWD").val();
        console.log(Password, password2);

        if (Password === password2) {
            $.ajax({
                url: updatePWD,
                type: "PUT",
                //dataType: "json",
                //data: JSON.stringify(user),
                //contentType: "application/json",
                success: function (response) {
                    // Manejar la respuesta exitosa de la API aquí
                    $("#resultado").html("Respuesta: " + JSON.stringify(response));
                },
                error: function (xhr, status, error) {
                    // Manejar errores aquí de manera más informativa
                    console.error("Error en la solicitud: " + error);
                    if (xhr.responseText) {
                        console.error("Respuesta del servidor: " + xhr.responseText);
                    }
                }
            });
        } else {
            console.log("Las contraseñas no coinciden");
        }

    }
    

}

// Load User´s profile
$(document).ready(function () {
        
    $.ajax({
        "url": 'https://localhost:7042/api/User/RetrieveAll',
        method: 'GET',
        success: function (data) {
            
            var desiredUserId = userObject.id;
            var desiredUser = data.find(function (data) {
                return data.id === desiredUserId;
            });

            console.log("UserDATA --> " + JSON.stringify(data));
            var jsonObject = desiredUser;
            


            var jsonString = JSON.stringify(jsonObject); 
            console.log("jsonObject --> " + JSON.stringify(jsonObject));
            
            document.cookie = "UserJson=" + encodeURIComponent(jsonString) + "; expires=Fri, 31 Dec 9999 23:59:59 GMT; path=/";
            console.log("JSON object saved in cookie.");


            if (desiredUser) {
                // Update the HTML with the retrieved product data
                $('#txtId').val(desiredUser.id);
                $('#txtNombre').val(desiredUser.fullName);
                $('#txtLastName').val(desiredUser.lastName);
                $('#txtCorreo').val(desiredUser.email);
                $('#txTelefono').val(desiredUser.phone);
                $('#txtRol').val(desiredUser.userType);
                $('#txtClaveActual').val(desiredUser.password);
                $('#ProfilePicture').attr('src', desiredUser.idPicture);
                
            } else {
                console.log('User not found');
            }
        }
    })    
});


// Save Changes in user profile.
$("#btnSaveChanges").click(function () {
    readJsonFromCookie();
    var user = {};
    user.id = userObject.id;
    user.fullName = $("#txtNombre").val();
    user.lastName = $("#txtLastName").val();
    user.email = $("#txtCorreo").val(); 
    user.phone = $("#txTelefono").val();
    user.password = userObject.password;
    user.idPicture = userObject.idPicture;
    user.idImage = userObject.idImage;
    user.userType = userObject.userType;    

    var ctrlActions = new ControlActions();
    var urlService = "User/Update";

    ctrlActions.PutToAPI(urlService, user, function () {        
    })   

})



function readJsonFromCookie() {
        // Get the cookie value
        var cookieName = "UserJson=";
        var decodedCookie = decodeURIComponent(document.cookie);
        var cookieArray = decodedCookie.split(';');
        var jsonValue = null;

        for (var i = 0; i < cookieArray.length; i++) {
            var cookie = cookieArray[i].trim();
            if (cookie.indexOf(cookieName) === 0) {
                jsonValue = cookie.substring(cookieName.length, cookie.length);
                break;
            }
        }

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

// Call the function to read the JSON object from the cookie
var userObject = readJsonFromCookie();


/* Calendar View */
$(document).ready(function () {
    // Sample event dates (replace with your own dates)
    var eventDates = ["2023-08-10", "2023-08-15", "2023-08-20", "2023-08-25"];

    // Get the current year and month
    var currentDate = new Date();
    var currentYear = currentDate.getFullYear();
    var currentMonth = currentDate.getMonth();

    // Display the calendar for the current month
    displayCalendar(currentYear, currentMonth);

    // Display the previous month's calendar
    $("#prevMonth").click(function () {
        currentMonth--;
        if (currentMonth < 0) {
            currentMonth = 11;
            currentYear--;
        }
        displayCalendar(currentYear, currentMonth);
    });

    // Display the next month's calendar
    $("#nextMonth").click(function () {
        currentMonth++;
        if (currentMonth > 11) {
            currentMonth = 0;
            currentYear++;
        }
        displayCalendar(currentYear, currentMonth);
    });

    function displayCalendar(year, month) {
        var firstDay = new Date(year, month, 1).getDay();
        var lastDate = new Date(year, month + 1, 0).getDate();

        $("#calendar").empty();

        for (var i = 0; i < firstDay; i++) {
            $("#calendar").append("<div class='day'></div>");
        }

        for (var i = 1; i <= lastDate; i++) {
            var date = new Date(year, month, i);
            var dateString = date.toISOString().split("T")[0];

            var dayElement = $("<div class='day'>" + i + "</div>");

            if (eventDates.includes(dateString)) {
                dayElement.append("<div class='event'>Event</div>");
            }

            $("#calendar").append(dayElement);
        }
    }
});

/*
$(document).ready(function () {
    var cedula = userObject.id;
    var ctrlActions = new ControlActions();
    var URL = "https://localhost:7042/api/Ticket/RetrieveMyFutureEvents?id=" + cedula;

    // Función que llama lo que se encuentra en la base de datos y crea HTML Cards

    $.ajax({
        url: URL,
        type: "GET",
        //dataType: "json",
        // data: JSON.stringify({ email: Email }), // Enviar el objeto con propiedad 'email'
        //contentType: "application/json",
        success: function (data) {
            data.forEach(function (data) {
                $("#tickets-cards").append(`<div class="tick_card">                
                            <div class="card mb-3" style="max-width: 540px;">
	                            <div class="row g-0">
		                            <div class="col-md-4">
			                            <img src="${data.logo}" class="img-fluid rounded-start" style="height:100%" />
		                            </div>
		                        <div class="col-md-8">
			                <div class="card-body">
				                    <h2 class="card-title">${data.eventName}</h2>
				                    <p class="card-text"><small class="text-body-secondary">Ubicacion: Estadio Nacional</small></p>
                                    <p class="card-text"><small class="text-body-secondary">${data.province},${data.exactAddress}</small></p>
				                    <h5>${data.eventTime}</h5>				

				            <div class="row">
					            <div class="col-sm-6 mb-3 mb-sm-0">
						            <div class="card">
							            <div class="card-body" style="background-color:darkseagreen">
								            <h5 class="card-title">${data.ticketSeatInfo}</h5>
								            <p class="card-text">${data.seatNumber}</p>
								            <br />
							            </div>
						            </div>
					            </div>					
				            </div>`)
            });

        }
    });
});
*/

$(document).ready(function () {
    var view = new DashboardClient();
    view.InitView();
});