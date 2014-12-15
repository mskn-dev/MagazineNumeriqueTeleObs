$(function () {
    getIxAbonnements();
});

function verifierInputEmail(input) {
    if (input == undefined)
        input = $("#emailInput");

    var mail = $(input).val();
    if (verifierInputRempli(undefined, mail, $(input).attr('id'))) {
        var regEx = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (mail.match(regEx) != null) {
            $(input).parent().removeClass("has-error");
            $(input).parent().addClass("has-success");
            return true;
        }
        else {
            $(input).parent().removeClass("has-success");
            $(input).parent().addClass("has-error");
            $(input).parent().find(".error-input").css("display", "table-caption");
            return false;
        }
    }
}

function verifierInputMdp() {
    var mdp = $("#mdpInput").val();
    var cofirmMdp = $("#confirmMdpInput").val();

    if (verifierInputRempli(undefined, mdp, "mdpInput") && verifierInputRempli(undefined, cofirmMdp, "confirmMdpInput")) {
        if (mdp == cofirmMdp) {
            $("#mdpInput").parent().removeClass("has-error");
            $("#mdpInput").parent().addClass("has-success");
            $("#confirmMdpInput").parent().removeClass("has-error");
            $("#confirmMdpInput").parent().addClass("has-success");
            return true;
        }
        else {
            $("#mdpInput").parent().removeClass("has-success");
            $("#mdpInput").parent().addClass("has-error");
            $("#mdpInput").parent().find(".error-input").css("display", "table-caption");
            $("#confirmMdpInput").parent().removeClass("has-success");
            $("#confirmMdpInput").parent().addClass("has-error");
            $("#confirmMdpInput").parent().find(".error-input").css("display", "table-caption");
            return false;
        }
    }
}
function verifChoixAbonnement() {
    var choix = "";
    $(".abonnementRadio").each(function () {
        if ($(this).find('input').is(":checked"))
            choix = true;
    });

    if (!choix) {
        $("#divAbonnements").parent().find(".error-input").css("display", "block");
        return false;
    }
    else{
        $("#divAbonnements").parent().find(".error-input").hide();
        return true;
    }

}

function getIxAbonnements() {

    var KO = function (result) {

    }

    var OK = function (result) {
        
        var $div = $("#divAbonnements");
        for (var i = 0; i < result.length; i++) {
            var htmlString = "";
            htmlString = "<div class='radio abonnementRadio'><label><input type='radio' name='abonnement' id='" + result[i].Abonnement + "' value='" + result[i].Pk + "'/>";
            htmlString += "<span id='abonnement'>" + result[i].Abonnement + "</span><span id='prixAbonnement'> (" + result[i].Prix + "€)</span></label><div>";
            $div.append(htmlString);
        }
        
    }

    var oAjax = new AjaxCall();
    oAjax.WebService = oAjax.URL_ABONNEMENT;
    oAjax.WebMethod = "GetIxAbonnement";
    oAjax.Call(OK, KO);
}

function getValuesForm() {
    if (verifierInputMdp() && verifierInputEmail() && verifierInputRempli(undefined, undefined, "mdpInput") && verifierInputRempli(undefined, undefined, "confirmMdpInput") && verifierInputRempli(undefined, undefined, "nomInput") && verifierInputRempli(undefined, undefined, "prenomInput") && verifChoixAbonnement()) {
        var lecteur = new Object();

        lecteur.nom = $("#nomInput").val();
        lecteur.prenom = $("#prenomInput").val();
        lecteur.email = $("#emailInput").val();
        lecteur.motDePasse = $("#mdpInput").val();
        $(".abonnementRadio").each(function () {
            if ($(this).find('input').is(":checked"))
                lecteur.pkIxAbonnement = $(this).find('input').val();
        });


        return lecteur
    }
    else
        return false;
}

function validerAbonnement(boutton) {
   
    var obj = getValuesForm();

    if (!obj)
        return;
    else {
        $(boutton).html(getWaitImage(20, 20));
        $(boutton).removeAttr('onclick');

        var KO = function (result) {

        }

        var OK = function (result) {
            $("#panelChoixAbonnement").hide();
            $("#boutonValider").hide();
            $("#titlePanelAbonnement").html("Abonnement effectué !");
            var htmlString = "";
            htmlString += "<div class='alert alert-success text-center'>Votre compte a bien éte crée.</div>";
            htmlString += "<div class='text-center'>Vous allez être redirigé dans un instant.</div><div>" + getWaitImage(50, 50) + "</div>";
            $("#bodyInfoAbonne").html(htmlString);

            setTimeout(function () {
                location.replace('../index.aspx');
            },5000);
        }

        var oAjax = new AjaxCall();
        oAjax.WebService = oAjax.URL_LECTEUR;
        oAjax.WebMethod = "CreerAbonne";
        oAjax.AddParameter("nom", obj.nom);
        oAjax.AddParameter("prenom", obj.prenom);
        oAjax.AddParameter("email", obj.email);
        oAjax.AddParameter("motDePasse", obj.motDePasse);
        oAjax.AddParameter("pkIxAbonnement", obj.pkIxAbonnement);
        oAjax.Call(OK, KO);
    }
   
}
