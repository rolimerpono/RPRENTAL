
var objDataTable;
document.addEventListener("DOMContentLoaded", function () {   
  
    
    objDataTable = $('#tbl_Rooms').DataTable(
        {
            "ajax": {
                url: '/Room/GetAll'
            },
            "columns": [

                { data: 'rooM_ID', visible: false },
                { data: 'rooM_NAME', "width": "15%" },
                { data: 'description', "width": "20%" },
                { data: 'rooM_PRICE', "width": "5%" },
                { data: 'maX_OCCUPANCY', "width": "5%" },
                { data: 'imagE_URL', "width": "5%" },
                {
                    data: 'rooM_ID',
                    "width": "5%",
                    "render": function (data, type, row) {
                        return '<button class="btn btn-primary btn-sm select-edit-btn w-100">Edit</button>';
                    }
                },
                {
                    data: 'rooM_ID',
                    "width": "5%",
                    "render": function (data, type, row) {
                        return '<button class="btn btn-danger btn-sm select-delete-btn w-100">Delete</button>';
                    }
                }

            ],
            "columnDefs":
                [
                    { "className": "text-start", "targets": "_all" },
                    {
                        "targets": [2], "className": "dt-nowrap", "render": function (data, type, row) {
                            return type === 'display' && data.length > 100 ? // Adjust the threshold as needed
                                '<span title="' + data + '">' + data.substr(0, 100) + '...</span>' : data;
                        }
                    } // Hide extra text in the 'description'
                ],
                fixedColumns: true,
                scrollY: true
                
    });
 

    //SELECT ROW BTN EDIT CLICK
    $("#tbl_Rooms").on("click", ".select-edit-btn", function () {
        var rowData = objDataTable.row($(this).closest('tr')).data();

        var data = { ROOM_ID: rowData.rooM_ID };
        $.ajax(
            {
                type: "GET",
                url: "/Room/Update",
                contentType: "application/json; charset=utf=8",
                data: data,
                success: function (result) {                  
                    $("#modal-edit-content").html(result);
                    $("#modal-edit").modal("show");
                },
                error: function (xhr, status, error) {
                    console.log("Error: " + error);
                }   
            });         
   
    });

    $(".btn-add").click(function () {

        $.ajax(
            {
                type: "GET",
                url: "/Room/Create",
                contentType: "application/json; charset=utf=8",
                success: function (result) {           
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
                showToast.Success(response.message);
            },
            error: function (xhr, status, error) {             
                showToast.Error(error);
            }

        })

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
                showToast.Success(response.message);
              
            },
            error: function (xhr, status, error) {
                showToast.Error(response.message);
            }           

        })  

    });
    //END EDIT



    //SELECT ROW BTN DELETE CLICK
    $("#tbl_Rooms").on("click", ".select-delete-btn", function () {
        var rowData = objDataTable.row($(this).closest('tr')).data();
        $("#rooM_ID").val(rowData.rooM_ID);
        $("#modal-delete").modal("show");
    });


    $(".btn-delete").click(function () {

        var objRoomData = $("#deleteform").serialize();

        $.ajax({
            type: "POST",
            url: "/Room/Delete",
            data: objRoomData,
            success: function (response) {
                objDataTable.ajax.reload();
                $("#modal-delete").modal("hide");
                showToast.Success(response.message);
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }

        })

    });
    //END EDIT


    var showToast = {
        Success: function (message) {
            var toaster = document.getElementById("toaster");
            toaster.innerText = message;
            toaster.style.display = "block";
            toaster.style.backgroundColor = "#006400";
            toaster.style.opacity = 1; // Ensure the toaster is fully visible
            setTimeout(function () {
                toaster.style.opacity = 0; // Start fading out
                setTimeout(function () {
                    toaster.style.display = "none";
                    toaster.style.opacity = 1; // Reset opacity for future use
                }, 500); // Wait for fade out transition to complete (500ms)
            }, 3000); // Duration set to 3 seconds (3000 milliseconds)
        },
        Error: function (message) {
            var toaster = document.getElementById("toaster");
            toaster.innerText = message;
            toaster.style.display = "block";
            toaster.style.backgroundColor = "red";
            toaster.style.opacity = 1; // Ensure the toaster is fully visible
            setTimeout(function () {
                toaster.style.opacity = 0; // Start fading out
                setTimeout(function () {
                    toaster.style.display = "none";
                    toaster.style.opacity = 1; // Reset opacity for future use
                }, 500); // Wait for fade out transition to complete (500ms)
            }, 3000); // Duration set to 3 seconds (3000 milliseconds)
        }
    };


       
});


  






