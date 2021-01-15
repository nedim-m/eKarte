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
            { "data": "stanica.grad.naziv", "width": "20%" },
            { "data": "stanica.adresa", "width": "20%" },
            { "data": "stanica.telefon", "width": "10%" },
            { "data": "stanica.naziv", "width": "20%" },
            { "data": "dolazakaVrijeme", "width": "15%" },

            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                               
                                
                       
                                 <a onclick=Delete("/Admin/stanicaLinija/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer;width:100px;'>
                                    <i class="far fa-times-circle"></i> Ukloni
                                </a>
                           
                            </div>
                         `;


                }, "width": "15%"

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
                    location.reload();
                  
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}