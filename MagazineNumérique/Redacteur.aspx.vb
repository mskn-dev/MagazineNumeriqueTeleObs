Imports CuteWebUI

Partial Class Redacteur
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        listeCategoriesMedia.DataSource = Articles.GetCategoriesMedia
        listeCategoriesMedia.DataBind()
        If Context.Session("redacteur") = Nothing AndAlso Context.Session("admin") = Nothing Then
            Response.Redirect("./index.aspx")
        Else
            Dim user = FichierCentral.GetUserByEmail(Session("usermail"))
            Session("completename") = user.Nom + " " + user.Prenom
            Context.Session.Timeout = 120
        End If
    End Sub


    Protected Sub validerCreationArticle(ByVal sender As Object, ByVal e As EventArgs) Handles boutonValider.ServerClick

        Dim o As New Articles
        Dim c As New Articles.IxCategorieMedia

        o.TitreArticle = titreInput.Value
        o.LoginCreation = Session("username")
        o.PkRedacteur = Session("userpk")
        c.PkCategorieMedia = listeCategoriesMedia.Value
        c.CategorieMedia = listeCategoriesMedia.Items.FindByValue(listeCategoriesMedia.Value).Text
        o.CategorieMedia = c
        o.PhraseAcroche = accrocheInput.Value
        o.TextArticle = contenuInput.Value
        o.EstArticleUne = inputUne.Checked

        If imageInput.HasFile Then
            o.ImageUrl = "/Articles/Images/" + imageInput.FileName
            imageInput.SaveAs(HttpContext.Current.Server.MapPath("~/Articles/Images") + "/" + imageInput.FileName)
        End If
        If videoInput.HasFile Then
            o.VideoUrl = "/Articles/Videos/" + videoInput.FileName
            videoInput.SaveAs(HttpContext.Current.Server.MapPath("~/Articles/Images") + "/" + videoInput.FileName)
        End If

        o.CreerArticle()
    End Sub

End Class
