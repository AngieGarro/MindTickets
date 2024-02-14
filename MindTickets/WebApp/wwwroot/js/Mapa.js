//Contiene la funcion para inicializar el mapa.
function iniciarMap() {
    var coord = { lat: 9.748917, lng: -83.753428 };
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 10,
        center: coord
    });
    var marker = new google.maps.Marker({
        position: coord,
        map: map
    });
    initAutocomplete();
}

function initAutocomplete() {
    let autoComplete;
    const input = document.getElementById('place-input');

    autoComplete = new google.maps.places.AutoComplete(input);
    autoComplete.addListener('place_changed', function () {
        const place = autoComplete.getPlace();
        map.setCenter(place.geometry.location);
        marker.setPosition(place.geometry.location);
    });
}

//Para autocompletar el registro del usuario.
function fillInAddress() {
    // Get the place details from the autocomplete object.
    const place = autocomplete.getPlace();
    let address1 = "";

    // Get each component of the address from the place details,
    // and then fill-in the corresponding field on the form.
    // place.address_components are google.maps.GeocoderAddressComponent objects
    // which are documented at http://goo.gle/3l5i5Mr
    for (const component of place.address_components) {
        // @ts-ignore remove once typings fixed
        const componentType = component.types[0];

        switch (componentType) {
            case "street_number": {
                address1 = `${component.long_name} ${address1}`;
                break;
            }
            case "route": {
                address1 += component.short_name;
                break;
            }
            case "locality":
                document.querySelector("#locality").value = component.long_name;
                break;
            case "administrative_area_level_1": {
                document.querySelector("#state").value = component.short_name;
                break;
            }
            case "country":
                document.querySelector("#country").value = component.long_name;
                break;
        }
    }

    address1Field.value = address1;
    postalField.value = postcode;
    // After filling the form with address components from the Autocomplete
    // prediction, set cursor focus on the second address line to encourage
    // entry of subpremise information such as apartment, unit, or floor number.
    address2Field.focus();
}

window.initAutocomplete = initAutocomplete;