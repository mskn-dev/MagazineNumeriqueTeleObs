<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Article.aspx.vb" Inherits="Article" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="articleDiv" class="center-block-article-single displayNone row single-portfolio">
        <div id="mediaArticle" style="margin-top: 10%;" class="col-md-6">
        </div><!-- End .col-md-7 --> 

        <div id="textArticleDiv" class="col-md-6">
            <div class="portfolio-item-details">
                <h2 id="titreArticle" class="portfolio-title"></h2>
                <div id="textArticle">

                </div>

                <ul id="redactionInfos" class="portfolio-details-list">
                    <li id="date"></li>
                    <li id="redacteur"></li>
                </ul>
            </div><!-- End .portfolio-item-details -->
        </div><!-- End .col-md-5 -->
        <script type="text/javascript" src="Ressources/js/articles.js"></script>
    </div>
</asp:Content>

