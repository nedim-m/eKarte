
// Tabs
function openLink(evt, linkName) {
    var i, x, tablinks;
    x = document.getElementsByClassName("myLink");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablink");
    for (i = 0; i < x.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" w3-blue", "");
    }
    document.getElementById(linkName).style.display = "block";
    evt.currentTarget.className += " w3-blue";
}

// Click on the first tablink on load
document.getElementsByClassName("tablink")[0].click();

function getResult() {
    var od = $("#aerodromOdId").val();
    var doA = $("#aerodromDoId").val();
    
    var datL = $("#datumletId").val();
    var kLase = $('input[name="klasa"]:checked').val();
    if ($("#povratnaLetId").prop("checked"))
        var PovL = $("#povratnaLetId").val();
    else
        var PovL = null;

   

    var url = "/Klijent/Search/GetAll?aerodromOd=" + od + "&aerodromDo=" + doA + "&povratnaLet=" + PovL + "&datumlet=" + datL + " &klase=" + kLase;
    
  
    $.get(url, function (result) {
     
        $("#resultId").html(result);
       
    })
        .fail(function () {
            aler("Greska na serveru. Pokušajte ponovo!");
        });
       
        
    

}


function getResult2() {
    var od = $("#StanicaPocetnaId").val();
    var doB = $("#StanicaZadnjaId").val();

    var datB = $("#datumBusId").val();
    var vrste = $('input[name="vrsta"]:checked').val();
    if ($("#povratnaBusId").prop("checked"))
        var PovB = $("#povratnaBusId").val();
    else
        var PovB = null;



    var url = "/Klijent/Search/GetAllLinije?StanicaPocetna=" + od + "&StanicaZadnja=" + doB + "&povratnaBus=" + PovB + "&datumBus=" + datB + " &vrste=" + vrste;
   
  
    $.get(url, function (result) {

      
        $("#resultId").html(result);

    })
        .fail(function () {
            aler("Greska na serveru. Pokušajte ponovo!");
        });

}

