
Partial Class Abonnement
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Context.Session("userid") <> Nothing Then
            Response.Redirect("./index.aspx")
        End If
    End Sub

End Class
