var dataTable;


$(document).ready(function () {
    loadDataTable();
   
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/stanicalinija/GetAllStanicaNaLiniji",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "stanicaPolaziste.naziv", "width": "15%" },
            { "data": "stanicaPolaziste.grad.naziv", "width": "10%" },
            { "data": "polazakVrijeme", "width": "10%" },
            { "data": "stanicaOdrediste.naziv", "width": "15%" },
            { "data": "stanicaOdrediste.grad.naziv", "width": "10%" },
            { "data": "dolazakVrijeme", "width": "10%" },
            { "data": "cijena", "width": "10%" },

            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                               
                                
                       
                                 <a onclick=Delete("/Admin/stanicaLinija/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer;'>
                                    <i class="far fa-times-circle"></i>
                                </a>
                           
                            </div>
                         `;


                }, "width": "10%"

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

