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