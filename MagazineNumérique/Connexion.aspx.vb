
Partial Class Connexion
    Inherits System.Web.UI.Page

    Sub SeConnecter(ByVal sender As Object, _
                         ByVal e As EventArgs)

        Dim clickedButton As Button = sender
        'clickedButton.Attributes("class") = "displayNone"

        Dim mail As String = email.Value
        Dim mdp As String = motDePasse.Value
        Dim user As FichierCentral = FichierCentral.GetUserByEmail(mail)

        If user IsNot Nothing Then
            If Membership.ValidateUser(user.Login, mdp) Then
                Context.Session.Add("userid", user.UserId)
                Context.Session.Add("username", user.Login)
                Context.Session.Add("completename", user.Prenom + " " + user.Nom)
                Context.Session.Add("usermail", user.Email)
                Context.Session.Add("userpk", user.PK)
                Context.Session.Add("userabonnemnt", user.PkAbonnemnt)
                Context.Session.Add("userprofil", user.PkProfil)
                Context.Session.Timeout = 120
                Response.Redirect("./index.aspx")
            Else
                errorConnexion.Style("display") = "block"
            End If


        End If





    End Sub
End Class
