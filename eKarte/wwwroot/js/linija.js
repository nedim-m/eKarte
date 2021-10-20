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
            { "data": "vozac1.ime", "width": "10%" },
            { "data": "kondukter.ime", "width": "10%" },
            { "data": "bus.naziv", "width": "10%" },
            { "data": "stanicaPocetna.grad.naziv", "width": "10%" },
            { "data": "stanicaZadnja.grad.naziv", "width": "10%" },
            { "data": "polazakVrijeme", "width": "10%" },
            { "data": "dolazakVrijeme", "width": "10%" },
            { "data": "osnovnaCijenaLinije", "width": "10%" },
            { "data": "svakodnevna", "width":"10%"},


            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                               
                                <a href="/Admin/linija/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer;width:100px;'>
                                    <i class='far fa-edit'></i> Edit
                                </a>
                                    
                                <a onclick=Delete("/Admin/linija/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer;width:100px;'>
                                    <i class='far fa-trash-alt'></i> Delete
                                </a>

                                 <a href="/Admin/StanicaLinija/Insert/${data}" class='btn btn-info text-white' style='cursor:pointer;width:100px;'>
                                    <i class='far fa-edit'></i> Stanice
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
