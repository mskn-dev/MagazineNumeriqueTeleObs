<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Redacteur.aspx.vb" Inherits="Redacteur" %>
<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class=""  id="content" role="main">
        <div id="divRedacteur" class="panel panel-default center-block-redacteur col-md-8 col-xs-8">
            <div id="titreRedacteur" class="panel panel-heading">
                <h4 class="text-center title-tele-obs">Articles</h4>
            </div>
            <div id="panelRedacteur" class="panel panel-body">
                <div id="ajoutArticles" class="panel panel-default">
                    <div class="panel panel-heading">
                        Ajouter 
                    </div>
                    <div class="panel panel-body">
                        <div class="col-md-12 col-xs-12 text-center">
                            <label class="col-md-12">
                                <input runat="server" type="checkbox" name="abonnement" id="inputUne"/>
                                <span id="abonnement">C'est article à la Une ?</span>
                            </label>
                        </div>
                         <div id="selectCategoriesMedia" class="col-md-12 col-xs-12 input-group">
                            <span class="input-group-addon">Catégorie*</span>
                            <select runat="server" datatextfield="CategorieMedia" datavaluefield="PkCategorieMedia" id="listeCategoriesMedia" class="col-md-12 form-control" onblur="verifierInputRempli(this);">
                            </select>
                            <span id="erreurSelect" runat="server" class="displayNone text-center text-danger error-input"> Vous ne pouvez pas créer d'articles sans catégorie</span>
                        </div>
                        <div class="col-md-12 col-xs-12 input-group">
                            <span class="input-group-addon">Titre*</span>
                            <input runat="server" id="titreInput" type="text" class="form-control" placeholder="Le titre de votre article" onblur="verifierInputRempli(this);"/>
                            <span class="displayNone text-center text-danger error-input"> Vous ne pouvez pas créer d'articles sans titre</span>
                        </div>
                        <div class="col-md-12 col-xs-12 input-group">
                            <span class="input-group-addon">Phrase d'accorche</span>
                            <input runat="server" id="accrocheInput" type="text" class="form-control" placeholder="Le titre de votre article"/>
                        </div>
                        <div class="col-md-12 col-xs-12 input-group">
                            <span class="input-group-addon">Contenu*</span>
                            <textarea runat="server" id="contenuInput" rows="6" class="form-control" placeholder="Votre Contenu ici" onblur="verifierInputRempli(this);"></textarea>
                            <span class="displayNone text-center text-danger error-input"> Vous ne pouvez pas créer d'article sans contenu !</span>
                        </div>
                        <div id="imageInputDiv" class="col-md-12 col-xs-12 input-group">
                            <span class="input-group-addon">Image</span>
                            <div class="col-md-8 no-padding">
                                <asp:FileUpload runat="server" id="imageInput"  type="file" accept="image/*" class="form-control"/>
                            </div>
                            <asp:Button ID="imageValider" runat="server" Text="Valider" CssClass="displayNonei m-left-md btn-upload btn btn-md btn-success"></asp:Button>
                        </div>
                        <div id="videoInputDiv" class="col-md-12 col-xs-12 input-group">
                            <span class="input-group-addon">Vidéo</span>
                            <div class="col-md-8 no-padding">
                                <asp:FileUpload runat="server" id="videoInput"  type="file" accept="video/*" class="form-control"/>
                            </div>
                            <asp:Button ID="videoValider" runat="server" Text="Valider" CssClass="displayNonei m-left-md btn-upload btn btn-md btn-success"></asp:Button>
                        </div>
                        <div id="divValider" class=" displayNone m-top-md m-bottom-md col-md-12 col-xs-12 text-center">
                            <button runat="server"  id="boutonValider" type="button" class="btn btn-md btn-success">Créer article</button>
                        </div>
                    </div>
                </div>
                <div id="modifArticles" class="panel panel-default">
                    <div class="panel panel-heading">
                        Modifier / Supprimer 
                    </div>
                    <div class="panel panel-body">
                         <div id="selectArticles" class="col-md-12">
                                <label class="col-md-12">Liste des Articles </label> 
                                <div class="col-md-6">
                                    <select id="listeArticles" class="col-md-6 form-control">
                                        <option value ="0"> Choisissez un article</option>
                                    </select>
                                </div>
                                <div class="displayNone col-md-6" id="bouttonModifRedacteur">
                                    <button onclick="supprimerArticle();" type="button" class="btn btn-xs btn-danger">Supprimer</button>
                                </div>
                            </div>
                    </div>
                </div>

            </div>
            <div id="footerArticles" class="panel panel-footer">

            </div>
        </div>
        <script type="text/javascript" src="Ressources/js/redacteur.js"></script>
    </div>
</asp:Content>

