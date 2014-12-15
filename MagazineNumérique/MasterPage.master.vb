
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Public Property Connected As Boolean = IIf(Context.Session("username") <> Nothing, True, False)
    Public Property UserId As String = If(Connected, Context.Session("userid").ToString, Nothing)
    Public Property UserLogin As String = IIf(Connected, Context.Session("username"), Nothing)
    Public Property UserEmail As String = If(Connected, Context.Session("usermail"), Nothing)
    Public Property UserName As String = IIf(Connected, Context.Session("completename"), Nothing)
    Public Property UserPk As Long = IIf(Connected, Context.Session("userpk"), Nothing)
    Public Property UserAbonne As Boolean = IIf(Connected And Context.Session("userabonnemnt") <> Nothing, True, False)
    Public Property UserPkAbonnement As Integer = IIf(UserAbonne, Context.Session("userabonnemnt"), Nothing)
    Public Property UserProfil As Integer = If(Connected, Context.Session("userprofil"), Nothing)

    Public Property EstRedacteur As Boolean = IIf(UserProfil = 2, True, False)
    Public Property EstAdmin As Boolean = IIf(UserProfil = 1, True, False)



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If EstAdmin Then
            Session("admin") = True
            Context.Session.Timeout = 120
        ElseIf EstRedacteur Then
            Session("redacteur") = True
            Context.Session.Timeout = 120
        Else
            Session("lecteur") = True
            Context.Session.Timeout = 120
        End If
    End Sub
End Class

