function verifierInputRempli(input,contenu,idInput) {
    if (input == undefined) {
        input = ("#" + idInput);
    }
    if (contenu == undefined) {
        var contenu = $(input).val();
    }
    if (contenu != "") {
        $(input).parent().removeClass("has-error");
        $(input).parent().addClass("has-success");
        $(input).parent().find(".error-input").hide();
        return true;
    } 
    else {
        $(input).parent().removeClass("has-success");
        $(input).parent().addClass("has-error");
        $(input).parent().find(".error-input").css("display", "table-caption");
        return false;
    }
}

function getWaitImage(largeur, hauteur) {
    return "<img class='center-block' src='../Ressources/img/loader.gif' style='width:" + largeur + "px;height:" + hauteur + "px;' />";
}

function TeleObsError(titre, contenu, Classcolor) {
    if (Classcolor == undefined)
        Classcolor = "alert-danger";
    var htmlString = "";
    htmlString += "<div class='center-block-redacteur panel panel-default col-md-8 col-xs-8'><div class='panel panel-heading'>" + titre + "</div>";
    htmlString += '<div class="panel-body"><div class="alert ' + Classcolor + '">' + contenu + '</div>';
    htmlString += "<div>" + getWaitImage(50, 50) + "</div></div></div>";
    $("#content").html(htmlString);
}

$.urlParam = function (name) {
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    if (results == null) {
        return null;
    }
    else {
        return results[1] || 0;
    }
}

