// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
function conflict(e) {
    var country = document.forms["searchProperties"]["Request.Country"].value;
    var category = document.forms["searchProperties"]["Request.Category"].value;
    var sources = document.forms["searchProperties"]["Request.Sources"].value;


    if (sources != "") {
        if (country != "" || category != "") {
            alert("You cannot mix Sources search parameter with Country or Category parameters!");
            return false;
        }
    }
    else {
        return true;
    }
}


function EverythingInputNeeded(e) {
    var keywords = document.forms["searchProperties"]["Request.Keywords"].value;
    var sources = document.forms["searchProperties"]["Request.Sources"].value;
    if (sources == "" &&
        keywords =="") {
        alert("You need to add Keywords or Sources search parameters!");
        return false;
    }
    return true;
}


function topArticlesInputNeeded(e) {
    var country = document.forms["searchProperties"]["Request.Country"].value;
    var category = document.forms["searchProperties"]["Request.Category"].value;
    var sources = document.forms["searchProperties"]["Request.Sources"].value;
    var keywords = document.forms["searchProperties"]["Request.Keywords"].value;
    if (sources == "" &&
        country == "" &&
        keywords == "" &&
        category == "") {
        alert("You need to add Keywords, Country, Sources,or Category search parameters!");
        return false;
    }
    return true;
}


// Write your JavaScript code