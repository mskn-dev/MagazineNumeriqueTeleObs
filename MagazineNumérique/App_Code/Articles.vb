Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class Articles

    Public Property Pk As Long
    Public Property PkRedacteur As Long
    Public Property Redacteur As String
    Public Property CategorieMedia As New IxCategorieMedia
    Public Property TitreArticle As String
    Public Property PhraseAcroche As String
    Public Property TextArticle As String
    Public Property EstArticleUne As Boolean
    Public Property ImageUrl As String
    Public Property VideoUrl As String
    Public Property DateCreation As DateTime
    Public Property LoginCreation As String
    Public Property DateModification As DateTime
    Public Property LoginModification As String
    Public Property DateSuppression As DateTime
    Public Property LoginSuppression As String


    Public Structure IxCategorieMedia
        Public Property PkCategorieMedia As Integer
        Public Property CategorieMedia As String
    End Structure

    Public Shared Function GetCategoriesMedia() As List(Of IxCategorieMedia)
        Dim o As List(Of IxCategorieMedia) = New List(Of IxCategorieMedia)

        Dim sql As New SqlCommand
        sql.CommandText = "sp_select_categories_medias"
        sql.CommandType = CommandType.StoredProcedure
        sql.Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("THYP_ConnectionString").ConnectionString)
        sql.Connection.Open()
        Dim reader As SqlDataReader = sql.ExecuteReader
        While reader.Read()
            Dim obj As New IxCategorieMedia
            obj.PkCategorieMedia = reader("PK_IX_CATEGORIES_MEDIA")
            obj.CategorieMedia = reader("CATEGORIE_MEDIA")
            o.Add(obj)
        End While
        sql.Connection.Close()

        Return o
    End Function

    Public Function CreerArticle() As Boolean
        Try
            Dim sql As New SqlCommand
            sql.CommandText = "sp_creer_article"
            sql.CommandType = CommandType.StoredProcedure
            sql.Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("THYP_ConnectionString").ConnectionString)
            sql.Parameters.AddWithValue("PK_IX_CATEGORIES_MEDIA", Me.CategorieMedia.PkCategorieMedia)
            sql.Parameters.AddWithValue("PK_FICHIER_CENTRAL", Me.PkRedacteur)
            sql.Parameters.AddWithValue("TITRE_ARTICLE", Me.TitreArticle)
            sql.Parameters.AddWithValue("ACCROCHE_ARTICLE", Me.PhraseAcroche)
            sql.Parameters.AddWithValue("TEXT_ARTICLE", Me.TextArticle)
            sql.Parameters.AddWithValue("LOGIN_CREATION", Me.LoginCreation)
            sql.Parameters.AddWithValue("EST_ARTICLE_PREMIERE_PAGE", Me.EstArticleUne)
            sql.Parameters.AddWithValue("CHEMIN_IMAGE", Me.ImageUrl)
            sql.Parameters.AddWithValue("CHEMIN_VIDEO", Me.VideoUrl)
            sql.Connection.Open()
            sql.ExecuteNonQuery()
            sql.Connection.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    Public Shared Function GetAllArticles() As List(Of Articles)
        Dim o As List(Of Articles) = New List(Of Articles)
        Dim sql As New SqlCommand
        sql.CommandText = "sp_select_articles"
        sql.CommandType = CommandType.StoredProcedure
        sql.Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("THYP_ConnectionString").ConnectionString)
        sql.Connection.Open()
        Dim reader As SqlDataReader = sql.ExecuteReader
        While reader.Read
            o.Add(Articles.GetDataByRow(reader))
        End While
        sql.Connection.Close()
        Return o
    End Function

    Public Shared Function GetDataByRow(reader As SqlDataReader) As Articles
        Dim o As New Articles
        Dim c As New IxCategorieMedia
        o.Pk = reader("PK_ARTICLE")
        o.TitreArticle = reader("TITRE_ARTICLE")
        o.LoginCreation = reader("LOGIN_CREATION")
        o.PkRedacteur = reader("PK_FICHIER_CENTRAL")
        o.Redacteur = reader("REDACTEUR")
        o.PhraseAcroche = reader("ACCROCHE_ARTICLE")
        o.TextArticle = reader("TEXT_ARTICLE")
        o.DateCreation = reader("DATE_CREATION")
        o.DateModification = IIf(reader("DATE_MODIFICATION") IsNot DBNull.Value, reader("DATE_MODIFICATION"), Nothing)
        o.LoginModification = IIf(reader("LOGIN_MODIFICATION") IsNot DBNull.Value, reader("LOGIN_MODIFICATION"), Nothing)
        o.DateSuppression = IIf(reader("DATE_SUPPRESSION") IsNot DBNull.Value, reader("DATE_SUPPRESSION"), Nothing)
        o.LoginSuppression = IIf(reader("LOGIN_SUPPRESSION") IsNot DBNull.Value, reader("LOGIN_SUPPRESSION"), Nothing)
        o.EstArticleUne = reader("EST_ARTICLE_PREMIERE_PAGE")
        c.PkCategorieMedia = reader("PK_IX_CATEGORIES_MEDIA")
        c.CategorieMedia = reader("CATEGORIE_MEDIA")
        o.CategorieMedia = c
        o.ImageUrl = IIf(reader("CHEMIN_IMAGE") IsNot DBNull.Value, reader("CHEMIN_IMAGE"), Nothing)
        o.VideoUrl = IIf(reader("CHEMIN_VIDEO") IsNot DBNull.Value, reader("CHEMIN_VIDEO"), Nothing)
        Return o
    End Function

    Public Shared Function GetArticlesByCategories(pkCategorie As Integer) As List(Of Articles)
        Dim o As List(Of Articles) = New List(Of Articles)
        Dim sql As New SqlCommand
        sql.CommandText = "sp_select_articles_par_cat"
        sql.CommandType = CommandType.StoredProcedure
        sql.Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("THYP_ConnectionString").ConnectionString)
        sql.Parameters.AddWithValue("PK_IX_CATEGORIES_MEDIA", pkCategorie)
        sql.Connection.Open()
        Dim reader As SqlDataReader = sql.ExecuteReader
        While reader.Read
            o.Add(Articles.GetDataByRow(reader))
        End While
        sql.Connection.Close()
        Return o
    End Function

    Public Shared Function GetArticlesByPk(pkArticle As Long) As Articles
        Dim o As Articles = New Articles
        Dim sql As New SqlCommand
        sql.CommandText = "sp_select_articles_par_pk"
        sql.CommandType = CommandType.StoredProcedure
        sql.Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("THYP_ConnectionString").ConnectionString)
        sql.Parameters.AddWithValue("PK_ARTICLE", pkArticle)
        sql.Connection.Open()
        Dim reader As SqlDataReader = sql.ExecuteReader
        While reader.Read
            o = Articles.GetDataByRow(reader)
        End While
        sql.Connection.Close()
        Return o
    End Function

    Public Shared Function GetArticlesUne() As List(Of Articles)
        Dim o As List(Of Articles) = New List(Of Articles)
        Dim sql As New SqlCommand
        sql.CommandText = "sp_select_articles_a_la_une"
        sql.CommandType = CommandType.StoredProcedure
        sql.Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("THYP_ConnectionString").ConnectionString)
        sql.Connection.Open()
        Dim reader As SqlDataReader = sql.ExecuteReader
        While reader.Read
            o.Add(Articles.GetDataByRow(reader))
        End While
        sql.Connection.Close()
        Return o
    End Function

    Public Sub Update()
        Dim sql As New SqlCommand
        sql.CommandText = "sp_update_article"
        sql.CommandType = CommandType.StoredProcedure
        sql.Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("THYP_ConnectionString").ConnectionString)
        sql.Parameters.AddWithValue("PK_ARTICLE", Me.Pk)
        sql.Parameters.AddWithValue("TITRE_ARTICLE", Me.TitreArticle)
        sql.Parameters.AddWithValue("LOGIN_CREATION", Me.LoginCreation)
        sql.Parameters.AddWithValue("PK_FICHIER_CENTRAL", Me.PkRedacteur)
        sql.Parameters.AddWithValue("REDACTEUR", Me.Redacteur)
        sql.Parameters.AddWithValue("ACCROCHE_ARTICLE", Me.PhraseAcroche)
        sql.Parameters.AddWithValue("TEXT_ARTICLE", Me.TextArticle)
        sql.Parameters.AddWithValue("DATE_CREATION", Me.DateCreation)
        sql.Parameters.AddWithValue("DATE_MODIFICATION", Me.DateModification)
        sql.Parameters.AddWithValue("LOGIN_MODIFICATION", Me.LoginModification)
        sql.Parameters.AddWithValue("DATE_SUPPRESSION", Me.DateSuppression)
        sql.Parameters.AddWithValue("LOGIN_SUPPRESSION", Me.LoginSuppression)
        sql.Parameters.AddWithValue("EST_ARTICLE_PREMIERE_PAGE", Me.EstArticleUne)
        sql.Parameters.AddWithValue("PK_IX_CATEGORIES_MEDIA", Me.CategorieMedia.PkCategorieMedia)
        sql.Parameters.AddWithValue("CATEGORIE_MEDIA", Me.CategorieMedia.CategorieMedia)
        sql.Parameters.AddWithValue("CHEMIN_IMAGE", Me.ImageUrl)
        sql.Parameters.AddWithValue("CHEMIN_VIDEO", Me.VideoUrl)
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
Public Class ArticlesWebServices
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetArticlesUne() As List(Of Articles)
        Return Articles.GetArticlesUne()
    End Function

    <WebMethod()> _
    Public Function GetArticlesByPk(pkArticle As Long) As Articles
        Return Articles.GetArticlesByPk(pkArticle)
    End Function

    <WebMethod()> _
    Public Function GetAllArticles() As List(Of Articles)
        Return Articles.GetAllArticles()
    End Function

    <WebMethod()> _
    Public Function CreerArticle(article As Articles) As Boolean
        Return article.CreerArticle()
    End Function

    <WebMethod()> _
    Public Function GetCategoriesMedia() As List(Of Articles.IxCategorieMedia)
        Return Articles.GetCategoriesMedia
    End Function

    <WebMethod()> _
    Public Function GetArticlesByCategories(pkCategorie As Integer) As List(Of Articles)
        Return Articles.GetArticlesByCategories(pkCategorie)
    End Function

End Class