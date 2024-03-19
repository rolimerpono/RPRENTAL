
var objDataTable;
document.addEventListener("DOMContentLoaded", function () {   
  
    
    objDataTable = $('#tbl_Rooms').DataTable(
        {
            "ajax": {
                url: '/Room/GetAll'
            },
            "columns": [

                { data: 'rooM_ID', "width": "5%" },
                { data: 'rooM_NAME', "width": "5%" },
                { data: 'description', "width": "15%" },
                { data: 'rooM_PRICE', "width": "5%" },
                { data: 'maX_OCCUPANCY', "width": "5%" },
                { data: 'imagE_URL', "width": "5%" },
                {
                    data: null,
                    "width": "5%",
                    "render": function (data, type, row) {
                        return '<button class="btn btn-primary btn-sm select-row w-100">Edit</button>';
                    }
                },
                {
                    data: null,
                    "width": "5%",
                    "render": function (data, type, row) {
                        return '<button class="btn btn-danger btn-sm delete-btn w-100">Delete</button>';
                    }
                }

            ],
            "columnDefs":
                [
                    { "className": "dt-left", "targets": "_all" },
                    {
                        "targets": [2], "className": "dt-nowrap", "render": function (data, type, row) {
                            return type === 'display' && data.length > 100 ? // Adjust the threshold as needed
                                '<span title="' + data + '">' + data.substr(0, 100) + '...</span>' : data;
                        }
                    } // Hide extra text in the 'description' and 'imagE_URL' columns
                ],
            fixedColumns: true,
            scrollY: true


        });
 

    //EDIT
    $("#tbl_Rooms").on("click", ".select-row", function () {
        var rowData = objDataTable.row($(this).closest('tr')).data();

        var data = { ROOM_ID: rowData.rooM_ID };
        $.ajax(
            {
                type: "GET",
                url: "/Room/Update",
                contentType: "application/json; charset=utf=8",
                data: data,
                success: function (result) {
                    console.log(result);
                    $("#modal-edit-content").html(result);
                    $("#modal-edit").modal("show");
                },
                error: function (xhr, status, error) {
                    console.log("Error: " + error);
                }   
            });         
   
    });


    $(".btn-edit").click(function () {

        var objRoomData = $("#editform").serialize();

        $.ajax({
            type: "POST",
            url: "/Room/Update",
            data: objRoomData,
            success: function (response) {                      
                objDataTable.ajax.reload();
                $("#modal-edit").modal("hide");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }           

        })  

    });
    //END EDIT

    $(".btn-add").click(function () {

        $.ajax(
            {
                type: "GET",
                url: "/Room/Create",
                contentType: "application/json; charset=utf=8",              
                success: function (result) {
                    console.log(result);
                    $("#modal-add-content").html(result);
                    $("#modal-add").modal("show");
                },
                error: function (xhr, status, error) {
                    console.log("Error: " + error);
                }
            });    
    });





    $(".btn-save").click(function () {

        var objRoomData = $("#saveform").serialize();

        $.ajax({
            type: "POST",
            url: "/Room/Create",
            data: objRoomData,
            success: function (response) {
                objDataTable.ajax.reload();
                $("#modal-add").modal("hide");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }

        })

    });

 
       
});


