<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Actus.aspx.vb" Inherits="Actus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="modeleArticleVideo" class="displayNone">
         <article id="ArticleVideo" class="col-md-6 article red wow fadeInUpBig animated" style="visibility: visible; -webkit-animation: fadeInUpBig;">
            <div id="videoArticle" class="article-media-container embed-responsive embed-responsive-16by9">
                <iframe class="embed-responsive-item" src="//player.vimeo.com/video/17668930?color=ffffff" width="500" height="281" allowfullscreen=""></iframe>
            </div><!-- End .article-media-container -->
            <div id="contenuArticleVideo" class="article-meta-container">
                <span class="article-icon"><i class="fa fa-file-video-o"></i></span>
                <h2 id="titreArticleVideo"><a id="lienArticleVideo" href="single.html" title="Lorem ipsum dolor sit amet.">Lorem ipsum dolor sit amet.</a></h2>
                <p id="textArticleVideo">Omnis officia, quibusdam tempore. Aspernatur dolores quibusdam, illo fuga similique rem itaque molestiae labore omnis, rerum ullam debitis, alias adipisci corporis. Quidem, ea nemo aperiam minus! Qui, vero sed. Laborum. <a href="single.html" class="readmore" title="Lorem ipsum dolor sit amet.">Readmore</a></p>
                <div id="infoRedactionVideo" class="article-meta clearfix">
                    <div id="dateCreationAV" class="article-meta-box article-date">in <span>18 July, 2014</span> at <span>4:30 pm</span></div>
                    <div id="redacteurAV" class="article-meta-box article-author">by <a href="#">Eon Dean</a></div>
                </div><!-- End .article-meta -->
            </div><!-- End .article-meta-container -->
        </article><!-- End .article -->    
    </div>
    <div id="modeleArticleImage" class="displayNone">
        <article id="ArticleImage" class="col-md-6 article lightblue wow fadeInUpBig animated" style="visibility: visible; -webkit-animation: fadeInUpBig;">
            <div class="article-media-container">
                <img id="imageArticle" src="#"/>
            </div><!-- End .article-media-container -->
            <div id="contenuArticleImage" class="article-meta-container">
                <span class="article-icon"><i class="fa fa-file-image-o"></i></span>
                <h2 id="titreArticleImage"><a id="lienArticle" href="#"></a></h2>
                <p id="textArticleImage">
                    <span id="textArticle" class="displayNone"></span>
                    <a id="lienAbonne" href="#" class="displayNone readmore">Lire l'article</a>
                    <button id="lienLecteur" type="button" class="btn btn-danger btn-xs add-popover red" data-toggle="popover" data-placement="right" title="" data-content="Vous devez être abonné, pour lire les articles !" data-original-title="Abonnez vous">lire l'article</button>
                </p>
                <div id="infoRedactionImage" class="article-meta clearfix">
                    <div id="dateCreationAI" class="article-meta-box article-date"></div>
                    <div id="redacteurAI" class="article-meta-box article-author"></div>
                </div><!-- End .article-meta -->
            </div><!-- End .article-meta-container -->
        </article><!-- End .article -->
    </div>

    <div class=""  id="content" role="main">
        <div class="panel panel-default center-block-article col-md-10 col-xs-10">
            <div id="titreRedacteur" class="panel panel-heading">
                <h4 class="text-center title-tele-obs">Actus</h4>
            </div>
            <div id="actusContent" class="col-md-12 articles-container">
                
            </div>
        </div>
        <script type="text/javascript" src="Ressources/js/articles.js"></script>
        <script type="text/javascript" src="Ressources/js/actus.js"></script>
    </div>
</asp:Content>

