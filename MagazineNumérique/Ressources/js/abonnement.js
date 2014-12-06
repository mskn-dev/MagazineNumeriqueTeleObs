$(function () {
    getIxAbonnements();

});

function verifierInputEmail(input) {
    var mail = $(input).val();
    if (verifierInputRempli(undefined, mail, $(input).attr('id'))) {
        var regEx = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (mail.match(regEx) != null) {
            $(input).parent().removeClass("has-error");
            $(input).parent().addClass("has-success");
        }
        else {
            $(input).parent().removeClass("has-success");
            $(input).parent().addClass("has-error");
            $(input).parent().find(".error-input").css("display", "table-caption");
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
        }
        else {
            $("#mdpInput").parent().removeClass("has-success");
            $("#mdpInput").parent().addClass("has-error");
            $("#mdpInput").parent().find(".error-input").css("display", "table-caption");
            $("#confirmMdpInput").parent().removeClass("has-success");
            $("#confirmMdpInput").parent().addClass("has-error");
            $("#confirmMdpInput").parent().find(".error-input").css("display", "table-caption");
        }
    }
}

function getIxAbonnements() {

    var KO = function (result) {

    }

    var OK = function (result) {
        
        var $div = $("#divAbonnements");
        for (var i = 0; i < result.length; i++) {
            var htmlString = "";
            htmlString = "<div class='radio'><label><input type='radio' name='abonnement' id='" + result[i].Abonnement + "' value='" + result[i].Pk + "'/>";
            htmlString += "<span id='abonnement'>" + result[i].Abonnement + "</span><span id='prixAbonnement'> (" + result[i].Prix + "€)</span></label><div>";
            $div.append(htmlString);
        }
        
    }

    var oAjax = new AjaxCall();
    oAjax.WebService = oAjax.URL_ABONNEMENT;
    oAjax.WebMethod = "getIxAbonnement";
    oAjax.Call(OK, KO);
}
