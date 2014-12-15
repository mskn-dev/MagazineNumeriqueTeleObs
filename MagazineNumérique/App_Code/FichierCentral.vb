Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient
Imports System.Data

Public Class FichierCentral

    Public Property PK As Long
    Public Property UserId As Guid
    Public Property PkProfil As Integer
    Public Property Nom As String
    Public Property Prenom As String
    Public Property Login As String
    Public Property Email As String
    Public Property DateCreation As DateTime
    Public Property Abonnement As String
    Public Property PkCategorieAbonnement As Nullable(Of Integer)
    Public Property PkAbonnemnt As Nullable(Of Long)

    Public Sub New()

    End Sub

    Public Sub New(email As String)
        Dim obj As FichierCentral = FichierCentral.GetUserByEmail(email)
        Me.PK = obj.PK
        Me.UserId = obj.UserId
        Me.PkProfil = obj.PkProfil
        Me.Nom = obj.Nom
        Me.Prenom = obj.Prenom
        Me.Login = obj.Login
        Me.Email = obj.Email
        Me.DateCreation = obj.DateCreation
        Me.Abonnement = obj.Abonnement
        Me.PkCategorieAbonnement = obj.PkCategorieAbonnement
        Me.PkAbonnemnt = obj.PkAbonnemnt
    End Sub

    Public Shared Function GetUserByEmail(email As String) As FichierCentral
        Dim obj As New FichierCentral
        Dim sql As New SqlCommand
        sql.CommandText = "sp_select_fichier_central_by_email"
        sql.CommandType = CommandType.StoredProcedure
        sql.Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("THYP_ConnectionString").ConnectionString)
        sql.Parameters.AddWithValue("EMAIL", email)
        sql.Connection.Open()
        Dim reader As SqlDataReader = sql.ExecuteReader
        While reader.Read()
            obj.GetByDataRow(reader)
        End While
        sql.Connection.Close()
        Return obj
    End Function

    Private Sub GetByDataRow(reader As SqlDataReader)
        Me.PK = reader("PK_FICHIER_CENTRAL")
        Me.UserId = reader("ID_USER")
        Me.PkProfil = reader("PK_IX_PROFILES")
        Me.Login = reader("LOGIN")
        Me.Nom = reader("NOM")
        Me.Prenom = reader("PRENOM")
        Me.Email = reader("EMAIL")
        Me.DateCreation = reader("DATE_CREATION_PROFILE")
        Me.PkCategorieAbonnement = IIf(reader("PK_IX_ABONNEMENTS") IsNot DBNull.Value, reader("PK_IX_ABONNEMENTS"), Nothing)
        Me.PkAbonnemnt = IIf(reader("PK_ABONNEMENT") IsNot DBNull.Value, reader("PK_ABONNEMENT"), Nothing)
    End Sub

    Public Sub Update()
        Dim sql As New SqlCommand
        sql.CommandText = "sp_update_fichier_central"
        sql.CommandType = CommandType.StoredProcedure
        sql.Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("THYP_ConnectionString").ConnectionString)
        sql.Parameters.AddWithValue("ID_USER", Me.UserId)
        sql.Parameters.AddWithValue("NOM", Me.Nom)
        sql.Parameters.AddWithValue("PRENOM", Me.Prenom)
        sql.Parameters.AddWithValue("EMAIL", Me.Email)
        sql.Parameters.AddWithValue("PK_ABONNEMENT", Me.PkAbonnemnt)
        sql.Parameters.AddWithValue("PK_IX_ABONNEMENTS", Me.PkCategorieAbonnement)
        sql.Connection.Open()
        sql.ExecuteNonQuery()
        sql.Connection.Close()
    End Sub

    Public Sub Delete()
        Dim sql As New SqlCommand
        sql.CommandText = "sp_delete_fichier_central"
        sql.CommandType = CommandType.StoredProcedure
        sql.Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("THYP_ConnectionString").ConnectionString)
        sql.Parameters.AddWithValue("ID_USER", Me.UserId)
        sql.Connection.Open()
        sql.ExecuteNonQuery()
        sql.Connection.Close()
    End Sub

End Class


' Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class FichierCentralWebServices
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetUserByEmail(email As String) As FichierCentral
        Return FichierCentral.GetUserByEmail(email)
    End Function

    <WebMethod()> _
    Public Sub UpdateUser(user As FichierCentral, ancienPass As String, nouveauPass As String)
        Dim membershipUser = Membership.GetUser(user.UserId)
        membershipUser.ChangePassword(ancienPass, nouveauPass)
        Membership.UpdateUser(membershipUser)
        user.Update()
    End Sub

End Class