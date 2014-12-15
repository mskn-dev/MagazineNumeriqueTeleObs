<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Admin.aspx.vb" Inherits="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class=""  id="content" role="main">
        <div id="divAdmin" class="panel panel-default center-block-redacteur col-md-8 col-xs-8">
            <div id="titreAdmin" class="panel panel-heading">
                <h4 class="text-center title-tele-obs">Rédacteurs</h4>
            </div>
            <div id="panelAdmin" class="panel panel-body">
                <div id="ajoutRedacteur" class="panel panel-default">
                    <div class="panel panel-heading">
                        Ajouter  
                    </div>
                    <div class="panel panel-body">
                        <div class="center-block-abonnement panel panel-body">
                            <div class="col-md-12 col-xs-12 input-group">
                                <span class="input-group-addon">Nom*</span>
                                <input id="nomInput" type="text" required="required" class="form-control" placeholder="Nom du rédacteur" onblur="verifierInputRempli(this);"/>
                                <span class="displayNone text-center text-danger error-input"> Veuillez remplir le champ Nom !</span>
                            </div>
                            <div class="col-md-12 col-xs-12 input-group">
                                <span class="input-group-addon">Prénom*</span>
                                <input id="prenomInput" type="text" required="required" class="form-control" placeholder="Prénom du rédacteur" onblur="verifierInputRempli(this);"/>
                                <span class="displayNone text-center text-danger error-input"> Veuillez remplir le champ Prenom !</span>
                            </div>
                            <div class="col-md-12 col-xs-12 input-group">
                                <span class="input-group-addon">Email*</span>
                                <input id="emailInput" type="email" required="required" class="form-control" placeholder="Email du rédacteur" onblur="verifierInputEmail(this);"/>
                                <span class="displayNone text-center text-danger error-input"> le champ Email n'est pas valide !</span>

                            </div>
                            <div class="col-md-12 col-xs-12 input-group">
                                <span class="input-group-addon">Mot de passe*</span>
                                <input id="mdpInput" type="password" required="required" class="form-control" placeholder="******" onblur="verifierInputMdp();"/>
                                <span class="displayNone text-center text-danger error-input"> le champ Mot de passe n'est pas valide !</span>
                            </div>
                            <div class="col-md-12 col-xs-12 input-group">
                                <span class="input-group-addon">Confirmation*</span>
                                <input id="confirmMdpInput" type="password" required="required" class="form-control" placeholder="******" onblur="verifierInputMdp();"/>
                                <span class="displayNone text-center text-danger error-input"> le champ Confirmation doit correspondre au champ mot de passe !</span>
                            </div>
                        </div>
                        <div class="text-center alert-info">* Veuillez remplir tous les champs.</div>
                        <div id="boutonValider" class=" m-top-md m-bottom-md col-md-12 col-xs-12 text-center">
                            <button onclick="validerAjoutRedacteur(this);" type="button" class="btn btn-md btn-success">Valider</button>
                        </div>
                    </div>
                </div>
                    <div id="modifRedacteur" class="panel panel-default">
                        <div class="panel panel-heading">
                            Modifier / Supprimer 
                        </div>
                        <div class="panel panel-body">
                            <div id="selectRedacteurs" class="col-md-12">
                                <label class="col-md-12">Liste des rédacteurs  </label> 
                                <div class="col-md-6">
                                    <select id="listeRedacteurs" class="col-md-6 form-control">
                                        <option value ="0"> Choisissez un rédacteur</option>
                                    </select>
                                </div>
                                <div class="displayNone col-md-6" id="bouttonModifRedacteur">
                                    <button onclick="supprimerRedacteur();" type="button" class="btn btn-xs btn-danger">Supprimer</button>
                                </div>
                            </div>
                        </div>
                    </div>
                <div id="footerArticles" class="panel panel-footer">

                </div>
            </div>
        </div>
        <script type="text/javascript" src="Ressources/js/admin.js"></script>
    </div>
</asp:Content>

