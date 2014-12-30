$(function () {


   
 
    var KO = function (result) {

    }

    var OK = function (result) {
        var articles = new Array();

        for (var i = 0; i < result.length; i++) {
            articles.push({label:result[i].TitreArticle, value:result[i].Pk});
        }

        $("#rechercheArticles").autocomplete({
            source: articles,
            //select: function () {
            //    alert($("#rechercheArticles").val());
            //}
            focus: function (event, ui) {
                $(this).val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                redirectToArticle(ui.item.value);
                return false;
            }
        });

        $('.ui-autocomplete').css('margin-left', '1%');

    }

    var oAjax = new AjaxCall();
    oAjax.WebService = oAjax.URL_ARTICLES;
    oAjax.WebMethod = "GetAllArticles";
    oAjax.Call(OK, KO);
});

function redirectToArticle(idArticle) {
    location.replace('./Article.aspx?id=' + idArticle);
}