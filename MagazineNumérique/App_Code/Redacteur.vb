Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient
Imports System.Data

Public Class Redacteur
    Inherits FichierCentral

    Public Shared Function CreerRedacteur(nom As String, prenom As String, email As String, motDePasse As String) As Boolean

        Dim login As String = nom.ToLower + "." + prenom.ToLower
        If Membership.GetUserNameByEmail(email) Is Nothing Then

            Dim nouvelUtilisateur As MembershipUser = Membership.CreateUser(login, motDePasse, email)
            Dim userId As Guid = nouvelUtilisateur.ProviderUserKey

            Dim sql As New SqlCommand
            sql.CommandText = "sp_nouveau_redacteur"
            sql.CommandType = CommandType.StoredProcedure
            sql.Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("THYP_ConnectionString").ConnectionString)
            sql.Parameters.AddWithValue("ID_USER", userId)
            sql.Parameters.AddWithValue("PK_IX_PROFILES", 2)
            sql.Parameters.AddWithValue("LOGIN", login)
            sql.Parameters.AddWithValue("NOM", nom)
            sql.Parameters.AddWithValue("PRENOM", prenom)
            sql.Parameters.AddWithValue("EMAIL", email)
            sql.Connection.Open()
            sql.ExecuteNonQuery()
            sql.Connection.Close()

            Return True
        Else
            Return Nothing
        End If
    End Function

    Public Shared Function GetRedacteurs() As List(Of Redacteur)
        Dim listRedacteurs As List(Of Redacteur) = New List(Of Redacteur)
        Dim sql As New SqlCommand
        sql.CommandText = "sp_select_redacteurs"
        sql.CommandType = CommandType.StoredProcedure
        sql.Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("THYP_ConnectionString").ConnectionString)
        sql.Connection.Open()
        Dim reader As SqlDataReader = sql.ExecuteReader
        While reader.Read
            listRedacteurs.Add(Redacteur.GetDataByRow(reader))
        End While
        sql.Connection.Close()
        Return listRedacteurs
    End Function

    Public Shared Function GetDataByRow(reader As SqlDataReader) As Redacteur
        Dim o As New Redacteur
        o.PK = reader("PK_FICHIER_CENTRAL")
        o.UserId = reader("ID_USER")
        o.PkProfil = reader("PK_IX_PROFILES")
        o.Login = reader("LOGIN")
        o.Nom = reader("NOM")
        o.Prenom = reader("PRENOM")
        o.Email = reader("EMAIL")
        o.DateCreation = reader("DATE_CREATION_PROFILE")
        Return o
    End Function

    Public Shared Function SupprimerRedacteurs(userId As Guid) As Boolean
        Dim user = Membership.GetUser(userId)
        If user IsNot Nothing Then
            Dim redacteur = New FichierCentral(user.Email)
            redacteur.Delete()
            Membership.DeleteUser(user.UserName)
            Return True
        Else
            Return False
        End If
    End Function

End Class

' Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class RedacteurWebServices
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function CreerRedacteur(nom As String, prenom As String, email As String, motDePasse As String) As Boolean
        Return Redacteur.CreerRedacteur(nom, prenom, email, motDePasse)
    End Function

    <WebMethod()> _
    Public Function GetRedacteurs() As List(Of Redacteur)
        Return Redacteur.GetRedacteurs()
    End Function

    <WebMethod()> _
    Public Function SupprimerRedacteur(userId As String) As Boolean
        Dim ProviderKey = New Guid(userId)
        Return Redacteur.SupprimerRedacteurs(ProviderKey)
    End Function

End Class