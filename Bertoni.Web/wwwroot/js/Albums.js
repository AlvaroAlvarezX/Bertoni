//$(document).ready(function () {
//    $('#Album').DataTable();
//});
$('#Album').change(function () {
    var albumId = $('#Album').val();
   // alert('Clicked on ' + albumId);
    
    var tableId = "tableta";
    $('#tableta tbody').html('');
    var url = $('#baseUrlHolder')[0].innerHTML.trim();
    var fullURL = url + 'GetPhotos?albumId=' + albumId;

        

    var a = 5;
    //https://localhost:44347/api/Albumes/GetAlbumes
    var response;
    $.ajax({
        url: fullURL,

        // data: data,
        type: 'GET',
        // data: JSON.stringify({var:'val'}), // send data in the request body
        // contentType: "application/json; charset=utf-8",  // if sending in the request body
        //contentType: 'application/json; charset=utf-8',
       
        async: true
    
    }).done(function (data, textStatus, jqXHR) {
        // because dataType is json 'data' is guaranteed to be an object
        response = data;

        if (response !== null) {

            DrawTable(response);
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        // the response is not guaranteed to be json
        if (jqXHR.responseJSON) {
            // jqXHR.reseponseJSON is an object
            showFailure('Failed to communicate with the service. ')
            console.log('failed with json data');
        }
        else {
            showFailure('Failed to communicate with the service. ')
            console.log('failed with unknown data');
        }
    }).always(function (dataOrjqXHR, textStatus, jqXHRorErrorThrown) {
        // $.LoadingOverlay("hide");
    });

});



function DrawTable(photos) {

    for (var i = 0; i < photos.length; i++) {

        var html = '';
        var p = photos[i];
        html += "<tr>";

        html += "<td>" + p.id  + "</td>";
        html += "<td>" + p.title + " </td>";
        html += "<td> <a  target='_blank' href='" + p.thumbnailURL + "'>    <img width='50px' height='50px' src='" +  p.thumbnailURL + "'/></a></td>";
        html += "<td> <button class='form-control' onclick='LoadComments(" + p.albumID + ")' >Show</button></td>";

        html += "</tr>";

        $('#tableta tbody').append(html)
    }

}

function LoadComments(photoId) {

    var url = $('#baseUrlHolder')[0].innerHTML.trim();
   
    var fullURL = url + 'GetComments?postId=' + photoId;
    $('#Comments').html('');


    var a = 5;
    //https://localhost:44347/api/Albumes/GetAlbumes
    var response;
    $.ajax({
        url: fullURL,

        // data: data,
        type: 'GET',
        // data: JSON.stringify({var:'val'}), // send data in the request body
        // contentType: "application/json; charset=utf-8",  // if sending in the request body
        //contentType: 'application/json; charset=utf-8',

        async: true

    }).done(function (data, textStatus, jqXHR) {
        // because dataType is json 'data' is guaranteed to be an object
        response = data;
        for (var i = 0; i < data.length; i++) {
            $('#Comments').append('<li> <strong> By ' + data[i].name + '(' + data[i].email + ') </strong>: \n' +  data[i].body + ' </li>')
        }

    }).fail(function (jqXHR, textStatus, errorThrown) {
        // the response is not guaranteed to be json
        if (jqXHR.responseJSON) {
            // jqXHR.reseponseJSON is an object
            showFailure('Failed to communicate with the service. ')
            console.log('failed with json data');
        }
        else {
            showFailure('Failed to communicate with the service. ')
            console.log('failed with unknown data');
        }
    }).always(function (dataOrjqXHR, textStatus, jqXHRorErrorThrown) {
        // $.LoadingOverlay("hide");
    });

}


