var pkUser = Utilisateur_ConnectePk;
var userId = Utilisateur_ConnecteId;
var estAbonne = Utilisateur_ConnecteEstAbonne;
var pkAbonnement = Utilisateur_ConnectePkAbonnement;
var emailUser = Utilisateur_ConnecteMail;
var profilUser = Utilisateur_ConnecteProfil;

$(function () {
    getIxAbonnements();
    getUserByEmail(emailUser);
});

function getUserByEmail(email) {

    var KO = function (result) {

    }

    var OK = function (result) {
        var $div = $("#bodyModifInfoAbonne");
        var nom = result.Nom;
        var prenom = result.Prenom;
        var email = result.Email;
        var pkTypeAbonnement = result.PkCategorieAbonnement;
        var abonnement = (pkTypeAbonnement == 1 ? "Mensuel" : "Annuel");

        $($div).find("#nomInput").val(nom);
        $($div).find("#prenomInput").val(prenom);
        $($div).find("#emailInput").val(email);
        if (profilUser == 3) {
            $("#panelChoixAbonnement").show();
            $("#divAbonnements").find("#" + abonnement).prop('checked', true);
        }
    }


    var oAjax = new AjaxCall();
    oAjax.WebService = oAjax.URL_FICHIER_CENTRAL;
    oAjax.WebMethod = "GetUserByEmail";
    oAjax.AddParameter("email", email);
    oAjax.Call(OK, KO);
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
    else {
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

function validerModifProfil(button) {
    if (verifierInputRempli(undefined, undefined, "mdpInput") && verifierInputRempli(undefined, undefined, "confirmMdpInput") && verifierInputRempli(undefined, undefined, "nomInput") && verifierInputRempli(undefined, undefined, "prenomInput") && verifChoixAbonnement()) {
        var $div = $("#bodyModifInfoAbonne");
        var user = new Object();
        user.Nom = $($div).find("#nomInput").val();
        user.Prenom = $($div).find("#prenomInput").val();
        user.Email = $($div).find("#emailInput").val();
        $("#divAbonnements").find('input').each(function(){
            if ($(this).is(":checked"))
                user.PkCategorieAbonnement = $(this).val();
        });
        user.PkAbonnemnt = pkAbonnement;
        user.UserId = userId;
        var ancienMdp = $($div).find("#ancienMdpInput").val();
        var nouveauMdp = $($div).find("#mdpInput").val();
        var KO = function (result) {

        }

        var OK = function (result) {
            location.replace("./index.aspx");
        }

        var oAjax = new AjaxCall();
        oAjax.WebService = oAjax.URL_FICHIER_CENTRAL;
        oAjax.WebMethod = "UpdateUser";
        oAjax.AddParameter("user", user);
        oAjax.AddParameter("ancienPass", ancienMdp);
        oAjax.AddParameter("nouveauPass", nouveauMdp);
        oAjax.Call(OK, KO);
    }
}