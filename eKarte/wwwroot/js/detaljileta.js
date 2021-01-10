var dataTable;
var dataTable2;



$(document).ready(function () {
    loadDataTable();
    loadDataTable2();
    
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/detaljileta/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ime", "width": "20%" },
            { "data": "prezime", "width": "20%" },
            { "data": "tipOsoblja.naziv", "width": "20%" },
            { "data": "spol.naziv", "width": "20%" },

            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                               
                               
                                <a onclick=Insert("/Admin/detaljiLeta/Upsert/${data}") class='btn btn-success text-white' style='cursor:pointer;width:100px;'>
                                    <i class="fas fa-check"></i> Dodaj
                                </a>
                            </div>
                         `;


                }, "width": "20%"

            }
        ],
        "language": {
            "emptyTable": "Nema  zapisa."
        },
        "width": "100%"
    });
}


function loadDataTable2() {

    dataTable2 = $('#tblData2').DataTable({
        "ajax": {
            "url": "/admin/detaljileta/GetAllNaLetu",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "osoblje.ime", "width": "20%" },
            { "data": "osoblje.prezime", "width": "20%" },
            { "data": "osoblje.tipOsoblja.naziv", "width": "20%" },
            { "data": "osoblje.spol.naziv", "width": "20%" },

            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                               
                               
                                <a onclick=Delete("/Admin/detaljiLeta/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer;width:100px;'>
                                    <i class="far fa-times-circle"></i> Ukloni
                                </a>
                            </div>
                         `;


                }, "width": "20%"

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
        title: "Da li želite uklonit ovu osobu iz posade!",
        text: "",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Da, ukloni!",
        closeOnconfirm: true
    }, function () {

        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                    dataTable2.ajax.reload();

                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}


function Insert(url) {
    $.ajax({
        type: 'POST',
        url: url,
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
                dataTable2.ajax.reload();
                

            }
            else {
                swal({
                    title: "Maximalno posade",
                    text: "",
                    type: "warning",
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Uredu!",
                    closeOnconfirm: true
                }) 
                    
            }
        }
    });

}
