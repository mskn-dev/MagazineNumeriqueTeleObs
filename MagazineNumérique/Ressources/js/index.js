$(function () {
    getArticlesUne();
});

function getArticlesUne() {

    var KO = function (result) {
        
    }

    var OK = function (result) {
        setArticleOnCaroussel(result);
    }

    var oAjax = new AjaxCall();
    oAjax.WebService = oAjax.URL_ARTICLES;
    oAjax.WebMethod = "GetArticlesUne";
    oAjax.Call(OK, KO);
}

function setArticleOnCaroussel(result) {
    var articles = result;

    for (var i = 0; i < articles.length; i++) {
        var j = i + 1;
        //var modeleCaroussel = $("#modeleCaroussel").clone();
        var liCaroussel = $("#liCaroussel"+j);
        var imageCaroussel = $(liCaroussel).find("#imageCaroussel" + j);
        var motTitreCaroussel = $(liCaroussel).find("#motTitreCaroussel" + j);
        //var titreCaroussel = $(liCaroussel).find("#titreCaroussel" + j);
        //var motTitre = articles[i].TitreArticle.trim(" ");
        $(liCaroussel).attr("data-title",articles[i].TitreArticle);
        $(motTitreCaroussel).html(articles[i].TitreArticle);
        //$(titreCaroussel).html(articles[i].TitreArticle)
        
        $(liCaroussel).attr('id', 'articlesUne' + articles[i].Pk);

        $(liCaroussel).show();
        
    }

}