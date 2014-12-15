<%@ Page Title="Connexion" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Connexion.aspx.vb" Inherits="Connexion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class=""  id="content" role="main">
        <div class="no-bottom-margin center-block-connexion col-md-5 col-xs-5 panel panel-default">
            <div class="panel-heading">
                <h4 id="titlePanelConnextion" class=" text-center title-tele-obs">Se connecter</h4>
            </div>
            <div class="center_block_TeleObs panel panel-body">
                <div id="divConnexion" class="col-md-12 col-xs-12">
                    <input runat="server" type="email" name="email" id="email" class=" m-bottom-md form-control" placeholder="Votre Email"/>
                    <input runat="server" type="password" name="motDePasse" id="motDePasse" class="form-control" placeholder="Votre Mot de passe"/>
                </div>
            </div>
            <div class="text-center alert alert-info">Veuillez remplir vos informations de connexion.</div>
            <div id="boutonValider" class=" panel-footer text-center">
                <asp:Button Text="Connexion" id="bouttonConnexion" runat="server" onclick="SeConnecter" type="button" class="btn btn-md btn-success" />
            </div>
            <div runat="server" id="errorConnexion" class="panel-footer displayNone"><div class=" text-center alert alert-danger">Vos informations de connexion sont érronés !</div></div>
        </div>       
    </div>
</asp:Content>

