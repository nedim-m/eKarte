var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/bus/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "naziv", "width": "10%" },
            { "data": "model", "width": "10%" },
            { "data": "proizvodjac", "width": "10%" },
            { "data": "godinaProizvodnje", "width": "10%" },
            { "data": "registracijskaOznaka", "width": "10%" },
            { "data": "kapacitet", "width": "10%" },
            { "data": "tipBusa.naziv", "width": "10%" },
            { "data": "kompanija.naziv", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                               
                                <a href="/Admin/bus/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer;width:100px;'>
                                    <i class='far fa-edit'></i> Edit
                                </a>
                                    &nbsp;
                                <a onclick=Delete("/Admin/bus/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer;width:100px;'>
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