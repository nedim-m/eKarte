var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/let/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "naziv", "width": "15%" },
            { "data": "datumLeta", "width": "15%" },
            { "data": "aerodromOd.naziv", "width": "15%" },
            { "data": "aerodromDo.naziv", "width": "15%" },

            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                               
                                <a href="/Admin/let/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer;width:100px;'>
                                    <i class='far fa-edit'></i> Edit
                                </a>
                                     &nbsp;
                                <a onclick=Delete("/Admin/let/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer;width:100px;'>
                                    <i class='far fa-trash-alt'></i> Delete
                                </a>
                                <a href="/Admin/detaljiLeta/Index/${data}" class='btn btn-info text-white' style='cursor:pointer;width:100px;'>
                                                                    Posada              
                                </a>
                                  
                                   
                            </div>
                         `;


                }, "width": "40%"

            }
        ],
        "language": {
            "emptyTable": "Nema  zapisa."
        },
        "width": "100%"
    });
}
function Delete(url) {
    swal({
        title: "Da li ste sigurni da želite izbrisati?",
        text: "Nečete moći vratiti sadržaj!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Da, izbriši!",
        closeOnconfirm: true
    }, function () {

        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();

                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}