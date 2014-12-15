var infosArticle = new Object();
$(function () {
    $("#ContentPlaceHolder1_listeCategoriesMedia").prepend("<option value=''>Choisissez une catégorie</option>");

    $("#ContentPlaceHolder1_listeCategoriesMedia").change(function () {
        $(this).find('option').each(function () {
            if($(this).is(':selected'))
                $(this).prop('selected', 'selected');
            else
                $(this).prop('selected', 'selected');
        });
    })

    $("#ContentPlaceHolder1_titreInput").focusout(function () { showValider(); });
    $("#ContentPlaceHolder1_listeCategoriesMedia").focusout(function () { showValider(); });
    $("#ContentPlaceHolder1_contenuInput").focusout(function () { showValider(); });
   
    getAllArticles();
});

function showValider() {
    if (verifierInputRempli(undefined, undefined, "ContentPlaceHolder1_listeCategoriesMedia") && verifierInputRempli(undefined, undefined, "ContentPlaceHolder1_titreInput") && verifierInputRempli(undefined, undefined, "ContentPlaceHolder1_contenuInput")) {
        $("#divValider").show();
    }
    else
        $("#divValider").hide();
}

function getAllArticles() {

    var KO = function (result) {

    }

    var OK = function (result) {
        var select = $("#listeArticles");
        for (var i = 0; i < result.length; i++) {
            var option = "<option value='" + result[i].Pk + "'>" + result[i].TitreArticle + "</option>"
            $(select).append(option);
        }
    }

    var oAjax = new AjaxCall();
    oAjax.WebService = oAjax.URL_ARTICLES;
    oAjax.WebMethod = "GetAllArticles";
    oAjax.Call(OK, KO);
}