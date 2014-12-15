Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient
Imports System.Data

Public Class Lecteur
    Inherits FichierCentral

    Public Shared Function CreerAbonne(nom As String, prenom As String, email As String, motDePasse As String, pkIxAbonnement As Integer) As Boolean
        Dim login As String = nom.ToLower + "." + prenom.ToLower
        If Membership.GetUserNameByEmail(email) Is Nothing Then

            Dim nouvelUtilisateur As MembershipUser = Membership.CreateUser(login, motDePasse, email)
            Dim userId As Guid = nouvelUtilisateur.ProviderUserKey
            Dim dateDebutAbonnement As DateTime = Date.Now
            Dim dateFinAbonnement As DateTime = Nothing
            If pkIxAbonnement = 1 Then
                dateFinAbonnement = dateDebutAbonnement.AddMonths(1)
            ElseIf pkIxAbonnement = 2 Then
                dateFinAbonnement = dateDebutAbonnement.AddYears(1)
            End If
            Dim PkAbonnement As Long = Abonnements.CreerAbonnement(dateDebutAbonnement, dateFinAbonnement, pkIxAbonnement)

            Dim sql As New SqlCommand
            sql.CommandText = "sp_nouvel_abonne"
            sql.CommandType = CommandType.StoredProcedure
            sql.Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("THYP_ConnectionString").ConnectionString)
            sql.Parameters.AddWithValue("ID_USER", userId)
            sql.Parameters.AddWithValue("PK_IX_PROFILES", 3)
            sql.Parameters.AddWithValue("LOGIN", login)
            sql.Parameters.AddWithValue("NOM", nom)
            sql.Parameters.AddWithValue("PRENOM", prenom)
            sql.Parameters.AddWithValue("EMAIL", email)
            sql.Parameters.AddWithValue("PK_IX_ABONNEMENTS", pkIxAbonnement)
            sql.Parameters.AddWithValue("PK_ABONNEMENT", PkAbonnement)
            sql.Connection.Open()
            sql.ExecuteNonQuery()
            sql.Connection.Close()
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
Public Class LecteurWebServices
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function CreerAbonne(nom As String, prenom As String, email As String, motDePasse As String, pkIxAbonnement As Integer) As Boolean
        Return Lecteur.CreerAbonne(nom, prenom, email, motDePasse, pkIxAbonnement)
    End Function

End Class