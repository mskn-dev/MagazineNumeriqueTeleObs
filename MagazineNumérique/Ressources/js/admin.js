$(function () {
    getlisteRedacteurs();

    $("#listeRedacteurs").change(function () {
        if ($(this).find('option').is(":selected")) {
            if ($(this).val() != 0) {
                $("#bouttonModifRedacteur").fadeIn("slow");
            }
        }
    });
});

function supprimerRedacteur() {
    var userIdRedacteur = $("#listeRedacteurs").find('option:selected').val();

    var OK = function (result) {
        if (result) {
            TeleObsError("Supprimer Rédacteur", "Le rédacteur a été supprimé", "alert-info");
            setTimeout(function () { location.replace("../Admin.aspx") }, 3000);
        }
        else {
            TeleObsError("Supprimer Rédacteur", "Le rédacteur n'a pas pu être supprimé", "alert-danger");
            setTimeout(function () { location.replace("../Admin.aspx") }, 3000);
        }

    }

    var KO = function (result) {


    }

    var oAjax = new AjaxCall();
    oAjax.WebService = oAjax.URL_REDACTEUR;
    oAjax.AddParameter("userId", userIdRedacteur)
    oAjax.WebMethod = "SupprimerRedacteur";
    oAjax.Call(OK, KO);

}

function getlisteRedacteurs(){

    var KO = function (result) {

    }

    var OK = function (result) {
        var select = $("#listeRedacteurs");
        for (var i = 0; i < result.length; i++) {
            var option = "<option value='" + result[i].UserId + "'>" + result[i].Nom + " " + result[i].Prenom + "</option>"
            $(select).append(option);
        }
    }

    var oAjax = new AjaxCall();
    oAjax.WebService = oAjax.URL_REDACTEUR;
    oAjax.WebMethod = "GetRedacteurs";
    oAjax.Call(OK, KO);
}


function getValuesFromFields() {

    if (verifierInputMdp() && verifierInputEmail() && verifierInputRempli(undefined, undefined, "mdpInput") && verifierInputRempli(undefined, undefined, "confirmMdpInput") && verifierInputRempli(undefined, undefined, "nomInput") && verifierInputRempli(undefined, undefined, "prenomInput")) {
        var redacteur = new Object();

        redacteur.nom = $("#nomInput").val();
        redacteur.prenom = $("#prenomInput").val();
        redacteur.email = $("#emailInput").val();
        redacteur.motDePasse = $("#mdpInput").val();
 
        return redacteur;
    }
    else
        return false;
}




function validerAjoutRedacteur(div) {

    var obj = getValuesFromFields();

    if (obj) {

        var KO = function (result) {

        }

        var OK = function (result) {
            if (result){
                TeleObsError("Création rédacteur", "Le rédacteur a été crée avec succès", "alert-success");
                setTimeout(function () { location.replace("../Admin.aspx") }, 3000);
            }
            else {
                TeleObsError("Création rédacteur", "Le rédacteur n'a pas pu être crée, il existe peût être déja ! ", "alert-danger");
                setTimeout(function () { location.replace("../Admin.aspx") }, 3000);
            }
        }

        var oAjax = new AjaxCall();
        oAjax.WebService = oAjax.URL_REDACTEUR;
        oAjax.WebMethod = "CreerRedacteur";
        oAjax.AddParameter("nom", obj.nom);
        oAjax.AddParameter("prenom", obj.prenom);
        oAjax.AddParameter("email", obj.email);
        oAjax.AddParameter("motDePasse", obj.motDePasse);
        oAjax.Call(OK, KO);
    }
}

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