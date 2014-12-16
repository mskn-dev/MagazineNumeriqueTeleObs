$(function () {

    if (window.location.pathname == "/Article.aspx") {
        if ($.urlParam("id") != "") {
            getArticleById($.urlParam("id"));
        }
    }
   
    if (typeof Utilisateur_ConnecteEstAbonne != "undefined") {
        if (Utilisateur_ConnecteEstAbonne != "undefined" && (Utilisateur_ConnecteEstAbonne || Utilisateur_ConnecteProfil ==1 || Utilisateur_ConnecteProfil ==2)) {
            $("#lienAbonne").show();
            $("#lienLecteur").hide();
            $("#lienAbonneV").show();
            $("#lienLecteurV").hide();
        }
        else {
            $("#lienLecteur").show();
            $("#lienAbonne").hide();
            $("#lienLecteurV").show();
            $("#lienAbonneV").hide();
        }
    }  
});


function setArticlesOnPage(result,idContent) {
    var articles = result;

    for (var i = 0; i < articles.length; i++) {
        if (articles[i].VideoUrl != null) {
            var modeleArticleVideo = $("#modeleArticleVideo").clone();
            var modeleArticleVideo = $("#modeleArticleVideo").clone();
            var article = $(modeleArticleVideo).find("#ArticleVideo");
            var contenuArticle = $(article).find("#contenuArticleVideo");
            var infoRedactionArticle = $(article).find("#infoRedactionVideo");

            $(article).find("#videoArticle").attr('src', '//' + articles[i].VideoUrl);

            $(contenuArticle).find("#titreArticleVideo").append(articles[i].TitreArticle);
            $(contenuArticle).find("#titreArticleVideo").find("#lienArticle").attr("href", "./Article.aspx?id=" + result[i].Pk + "");
            //$(contenuArticle).find("#textArticleImage").find("#textArticle").html(articles[i].TextArticle);
            //$(contenuArticle).find("#textArticleImage").find("#textArticle").show();
            $(contenuArticle).find("#textArticleVideo").find("#lienAbonneV").attr("href", "./Article.aspx?id=" + result[i].Pk + "");

            $(infoRedactionArticle).find("#dateCreationAV").html(articles[i].DateCreation.toLocaleDateString());
            $(infoRedactionArticle).find("#redacteurAV").html(articles[i].Redacteur);

            $("#" + idContent).append(article);
        }
        else if (articles[i].ImageUrl != null) {
            var modeleArticleImage = $("#modeleArticleImage").clone();
            var article = $(modeleArticleImage).find("#ArticleImage");
            var contenuArticle = $(article).find("#contenuArticleImage");
            var infoRedactionArticle = $(article).find("#infoRedactionImage");

            $(article).find("#imageArticle").attr('src', '../' + articles[i].ImageUrl);

            $(contenuArticle).find("#titreArticleImage").append(articles[i].TitreArticle);
            $(contenuArticle).find("#titreArticleImage").find("#lienArticle").attr("href", "./Article.aspx?id=" + result[i].Pk + "");
            //$(contenuArticle).find("#textArticleImage").find("#textArticle").html(articles[i].TextArticle);
            //$(contenuArticle).find("#textArticleImage").find("#textArticle").show();
            $(contenuArticle).find("#textArticleImage").find("#lienAbonne").attr("href", "./Article.aspx?id=" + result[i].Pk + "");

            $(infoRedactionArticle).find("#dateCreationAI").html(articles[i].DateCreation.toLocaleDateString());
            $(infoRedactionArticle).find("#redacteurAI").html(articles[i].Redacteur);

            $("#"+idContent).append(article);
        }
    }
}

function getArticleById(id) {

    var KO = function (result) {

    }

    var OK = function (result) {
        setSingleArticleOnPage(result);
    }

    var oAjax = new AjaxCall();
    oAjax.WebService = oAjax.URL_ARTICLES;
    oAjax.WebMethod = "GetArticlesByPk";
    oAjax.AddParameter("pkArticle", id);
    oAjax.Call(OK, KO);
}

function setSingleArticleOnPage(result) {
    var article = result;

    var articleDiv = $("#articleDiv");
    var articleMedia = $("#mediaArticle");  
    var textArticleDiv = $("#textArticleDiv");
    var titreArticle = $(textArticleDiv).find("#titreArticle");
    var textArticle = $(textArticleDiv).find("#textArticle");
    var infosRedac = $(textArticleDiv).find("#redactionInfos");
    var dateArticle = $(infosRedac).find("#date");
    var redacteur = $(infosRedac).find("#redacteur");

    if (article.VideoUrl !=null) {
        articleMedia.html("<iframe class='embed-responsive-item' src='//" + article.VideoUrl + "' width='500' height='281'></iframe>");
    } else if (article.ImageUrl != null) {
        articleMedia.html("<img src='../" + article.ImageUrl + "' class='img-responsive'>");
    }

    $(titreArticle).html(article.TitreArticle);
    $(textArticle).html(article.TextArticle);
    $(dateArticle).html(article.DateCreation.toLocaleDateString());
    $(redacteur).html(article.Redacteur);
    $(articleDiv).fadeIn('slow');
    
}


