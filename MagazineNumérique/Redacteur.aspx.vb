Imports CuteWebUI

Partial Class Redacteur
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            listeCategoriesMedia.DataSource = Articles.GetCategoriesMedia
            listeCategoriesMedia.DataBind()
            listeCategoriesMedia.Items.Insert(0, "choisissez votre catégorie ")
        End If
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
        Dim ArticlesCaroussel = Articles.GetArticlesUne()
        Dim idCaroussel3 = ArticlesCaroussel(2).Pk
        'Dim UneChoisie As String = ""
        'If Une1.Checked Then
        '    UneChoisie = Une1.Value
        'ElseIf Une2.Checked Then
        '    UneChoisie = Une2.Value
        'ElseIf Une3.Checked Then
        '    UneChoisie = Une3.Value
        'End If

        o.TitreArticle = titreInput.Value
        o.LoginCreation = Session("username")
        o.PkRedacteur = Session("userpk")
        c.PkCategorieMedia = listeCategoriesMedia.SelectedIndex
        c.CategorieMedia = listeCategoriesMedia.SelectedItem.Text
        o.CategorieMedia = c
        o.PhraseAcroche = accrocheInput.Value
        o.TextArticle = contenuInput.Value
        o.EstArticleUne = inputUne.Checked
        If o.EstArticleUne Then
            o.VideoUrl = Nothing
        Else
            o.VideoUrl = IIf(videoInput.Value = "", Nothing, videoInput.Value)
        End If


        If imageInput.HasFile Then
            o.ImageUrl = "/Articles/Images/" + imageInput.FileName
            If o.EstArticleUne Then
                imageInput.SaveAs(HttpContext.Current.Server.MapPath("~/Articles/Images/Caroussel") + "/" + "Caroussel3.jpg")
                ArticlesCaroussel(2).EstArticleUne = False
                ArticlesCaroussel(2).Update()
            End If
            imageInput.SaveAs(HttpContext.Current.Server.MapPath("~/Articles/Images") + "/" + imageInput.FileName)
        End If
        'If videoInput.HasFile Then
        '    o.VideoUrl = "/Articles/Videos/" + videoInput.FileName
        '    If o.EstArticleUne Then
        '        videoInput.SaveAs(HttpContext.Current.Server.MapPath("~/Articles/Videos/Caroussel") + "/" + videoInput.FileName)
        '    End If
        '    videoInput.SaveAs(HttpContext.Current.Server.MapPath("~/Articles/Videos") + "/" + videoInput.FileName)
        'End If

        o.CreerArticle()
    End Sub

End Class
