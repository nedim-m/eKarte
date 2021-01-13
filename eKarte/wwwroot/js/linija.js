var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/linija/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "naziv", "width": "10%" },
            { "data": "vozac1.ime", "width": "10%" },
            { "data": "vozac2.ime", "width": "10%" },
            { "data": "kondukter.ime", "width": "10%" },
            { "data": "bus.naziv", "width": "10%" }, 
            { "data": "osnovnaCijenaLinije", "width": "10%" },                   
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                               
                                <a href="/Admin/linija/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer;width:100px;'>
                                    <i class='far fa-edit'></i> Edit
                                </a>
                                    &nbsp;
                                <a onclick=Delete("/Admin/linija/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer;width:100px;'>
                                    <i class='far fa-trash-alt'></i> Delete
                                </a>
                            </div>
                         `;


                }, "width": "30%"

            }
        ],
        "language": {
            "emptyTable": "Nema zapisa"
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