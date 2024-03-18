
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
                        return '<button class="btn btn-primary btn-sm edit-btn w-100">Edit</button>';
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
 

    $("#tbl_Rooms").on("click", ".edit-btn", function () {
        var rowData = objDataTable.row($(this).closest('tr')).data();
            

        $("#id").val(rowData.rooM_ID);
        $("#roomName").val(rowData.rooM_NAME);
        $("#description").val(rowData.description);
        $("#price").val(rowData.rooM_PRICE); 
        $("#occupancy").val(rowData.maX_OCCUPANCY);     
        $("#imageUrl").val(rowData.imagE_URL);  

        $("#image-container").html("<img src='" + rowData.imagE_URL + "' alt='Room Image' class='img-fluid rounded border'>");

        $("#EditModal").modal("show");
    });


    $("#btnSave").click(function () {

        var objRoomData = $("#EditForm").serialize();

        $.ajax({
            type: "POST",
            url: "/Room/Update",
            data: objRoomData,
            success: function (response) {                      
                objDataTable.ajax.reload();
                $("#EditModal").modal("hide");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);

            }           

        })  

    }) 


   
       
});


