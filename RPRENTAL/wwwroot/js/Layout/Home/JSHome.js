$(document).ready(function () {    


    $.ajax({
        type: "GET",
        url: "/Home/Index",         
        success: function (result) {
            $("#page-list-content").html(result);            
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });   
    
});


