<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ProgrammeTv.aspx.vb" Inherits="ProgrammeTv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class=""  id="content" role="main">
        <div class="center-block-programme-tv panel panel-default col-md-10 col-xs-10">
            <div id="" class="panel panel-heading">
                <h4 class="text-center title-tele-obs">Programme TV</h4>
            </div>
            <div class="text-center">
                <iframe class="iframe-programme-tv" src="http://www.programme-tv.net/widget-tv/programme-tele.html?size=960x755&bouquet=1&title=212121&title_rollover=009DDF&bg=f4f4f4" frameborder="0" scrolling="no"></iframe><noframes>Votre navigateur ne supporte pas le format iframe</noframes>
            </div>
        </div>
    </div>
</asp:Content>

