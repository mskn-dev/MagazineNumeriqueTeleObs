
Partial Class Article
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Context.Session("redacteur") = Nothing AndAlso Context.Session("admin") = Nothing Then
            Response.Redirect("./index.aspx")
        Else
            Dim user = FichierCentral.GetUserByEmail(Session("usermail"))
            Session("completename") = user.Nom + " " + user.Prenom
            Context.Session.Timeout = 120
        End If
    End Sub
End Class
