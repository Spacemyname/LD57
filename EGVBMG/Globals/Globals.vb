Public Class Globals
    Public Shared Content As ContentManager
    Public Shared Graphics As GraphicsDeviceManager
    Public Shared SpriteBatch As SpriteBatch
    Public Shared GameTime As GameTime
    Public Shared WindowFocused As Boolean
    Public Shared GameSize As Vector2
    Public Shared BackBuffer As RenderTarget2D
    Public Shared Debugging As Boolean
    Public Shared ScreenPos As Vector2
    Public Shared ScreenShakeCD As Integer
    Public Shared Lastscreenshaketype As Integer
    Public Shared ScreenMargins As Vector2

    Public Shared Sub Screenshake(shaketype As Integer)
        Lastscreenshaketype = shaketype
        Select Case shaketype
            Case -1
                ScreenPos = New Vector2(0, 0)
            Case 0 'Sideways
                ScreenPos.X = RNG.Free(-4, 4)
            Case 1 'All directions
                ScreenPos = New Vector2(RNG.Free(-4, 4), RNG.Free(-4, 4))
            Case 2 'Down only
                ScreenPos.Y = RNG.Free(0, 4)
        End Select
    End Sub
End Class
