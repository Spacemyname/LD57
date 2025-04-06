Public Class TestScreen
    Inherits BaseScreen
    Private TestText As String = "We can't have nice things!"
    Private TextPos As New Vector2(20, 195)
    Private IsAlive As Boolean = True
    Private LifeSpan As Double = 0
    Public Sub New()
        Name = "TestScreen"
    End Sub
    Public Overrides Sub Update()
        If LifeSpan < 5000 Then
            LifeSpan += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        Else
            IsAlive = False
        End If

        If IsAlive = False Then
            Me.State = ScreenState.ShutDown
        End If
    End Sub
    Public Overrides Sub Draw()
        GameObj.DrawLetter(TextPos, TestText, Color.Red, 6, 4)
    End Sub
End Class
