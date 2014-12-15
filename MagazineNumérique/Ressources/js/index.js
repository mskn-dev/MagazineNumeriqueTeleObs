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
    var article = result;
}