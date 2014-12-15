$(function () {
    getAllArticlesActus();
});

function getAllArticlesActus() {

    var KO = function (result) {

    }

    var OK = function (result) {
        setArticlesOnPage(result, "actusContent");
    }

    var oAjax = new AjaxCall();
    oAjax.WebService = oAjax.URL_ARTICLES;
    oAjax.WebMethod = "GetArticlesByCategories";
    oAjax.AddParameter("pkCategorie", 3);
    oAjax.Call(OK, KO);
}
