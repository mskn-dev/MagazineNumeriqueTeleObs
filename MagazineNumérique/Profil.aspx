<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Profil.aspx.vb" Inherits="Profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class=""  id="content" role="main">
        <div class="center-block-abonnement col-md-8 col-xs-8 panel panel-default">
            <div class="panel-heading">
                <h4 id="titlePanelAbonnement" class=" text-center title-tele-obs">Modifier le profil</h4>
            </div>
            <div id="bodyModifInfoAbonne" class="m-top-md panel panel-default">
                <div class="panel panel-heading no-background no-border">
                    Informations du profil
                </div>
                <div class="center-block-abonnement panel panel-body">
                    <div class="col-md-12 col-xs-12 input-group">
                        <span class="input-group-addon">Nom*</span>
                        <input id="nomInput" type="text" required="required" class="form-control" placeholder="Votre Nom" onblur="verifierInputRempli(this);"/>
                        <span class="displayNone text-center text-danger error-input"> Veuillez remplir le champ Nom !</span>
                    </div>
                    <div class="col-md-12 col-xs-12 input-group">
                        <span class="input-group-addon">Prénom*</span>
                        <input id="prenomInput" type="text" required="required" class="form-control" placeholder="Votre Prénom" onblur="verifierInputRempli(this);"/>
                        <span class="displayNone text-center text-danger error-input"> Veuillez remplir le champ Prenom !</span>
                    </div>
                    <div class="col-md-12 col-xs-12 input-group">
                        <span class="input-group-addon">Email*</span>
                        <input disabled="disabled" id="emailInput" type="email" required="required" class="form-control" placeholder="Votre Email"/>
                    </div>
                     <div class="col-md-12 col-xs-12 input-group">
                        <span class="input-group-addon">Ancien Mot de passe*</span>
                        <input id="ancienMdpInput" type="password" required="required" class="form-control" placeholder="******" onblur="verifierInputRempli(this);"/>
                        <span class="displayNone text-center text-danger error-input"> Veuillez remplir le champ Ancien mot de passe !</span>
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
            </div>
            <div id="panelChoixAbonnement" class="displayNone panel panel-default">
                <div class="panel panel-heading no-background no-border">
                    Choix abonnement
                </div>
                <div class="center-block-abonnement panel panel-body">
                     <div id="divAbonnements" class="col-md-12 col-xs-12 input-group">
                        
                    </div>
                    <span class="displayNone text-center text-danger error-input"> Vous devez choisir un abonnement !</span>
                </div>
                <div class="text-center alert-info">* Veuillez choisir un abonnement.</div>
            </div>
            <div id="boutonValider" class=" m-top-md m-bottom-md col-md-12 col-xs-12 text-center">
                <button onclick="validerModifProfil(this);" type="button" class="btn btn-md btn-warning">Modifier</button>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="Ressources/js/profil.js"></script>
</asp:Content>

