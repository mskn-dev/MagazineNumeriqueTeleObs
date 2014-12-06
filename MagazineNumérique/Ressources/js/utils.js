function verifierInputRempli(input,contenu,idInput) {
    if (contenu == undefined) {
        var contenu = $(input).val();
    }
    if (input == undefined) {
        input = ("#" + idInput);
    }
    if (contenu != ""){
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



