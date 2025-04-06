Public Class TextHandler
    'Inherits BaseScreen
    Public Shared TXT As String = ""
    Public Shared REC As Rectangle
    Public Shared Sub SetText(ByVal st As String, ByVal siz As Integer, ByVal x As Integer, ByVal y As Integer, ByVal TC As Color, ByVal TBG As Color, ByVal ReturnKey As Integer)
        TXT = st
        FontSize = siz
        PosText(x, y)
        TextC = TC
        TextBGC = TBG
        Limit = ReturnKey
    End Sub
    Public Shared Sub PosText(ByVal x As Integer, ByVal y As Integer)
        REC = New Rectangle(x, y, 0, 0)
        REC.Width = 5 * FontSize * (TXT.Length + 1) + 2 + TXT.Length
        Dim lines As Integer = REC.Width / Limit
        REC.Height = 7 * FontSize * lines + 2
        REC.Width = 5 * FontSize * (5 * FontSize * TXT.Length / Limit)
    End Sub
    Public Shared Sub ReadText(ByVal t As Boolean, ByVal sp As Integer)
        BookMark = 0
        SPD = 0
        Speed = sp
        Read = t
    End Sub
    'Public Sub New()
    '    Name = "Text"
    '    State = ScreenState.Active
    'End Sub
    'Public Shared Anitime As Integer = 0
    'Public Overrides Sub Update()
    '    'Example of how to control your updates
    '    Anitime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
    '    If Anitime > 10 Then
    '        Anitime = 0
    '        If Read Then
    '            SPD += 1
    '            If SPD = Speed Then
    '                SPD = 0
    '                If BookMark < TXT.Length Then
    '                    BookMark += 1
    '                End If
    '            End If
    '        End If
    '        aminate += 1
    '        If aminate = 20 Then
    '            aminate = 0
    '        End If
    '    End If
    'End Sub
    Public Shared Speed As Integer = 1
    Public Shared SPD As Integer = 0
    Public Shared BookMark As Integer = 0
    Public Shared Read As Boolean = False
    Public Shared FontSize As Integer = 10
    Public Shared FontType As String = "Px5"
    Public Shared TextC As Color = Color.Black
    Public Shared TextBGC As Color = Color.White
    Public Shared Limit As Integer = 1000
    Public Shared Linecount As Integer
    Dim aminate As Integer = 0
    Public Shared Border As Integer = 1 '0 = no border
    'Public Overrides Sub Draw()
    '    Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
    '    If Read Then
    '        'Border
    '        Select Case Border
    '            Case 1
    '                Globals.SpriteBatch.Draw(Textures.Null, REC, TextBGC)
    '        End Select
    '        Dim lnn As Integer = 0
    '        Dim perline As Integer = 0
    '        For q As Integer = 0 To BookMark - 1
    '            If FontType = "Px5" Then
    '                If 5 * FontSize * q - lnn * (Limit / 5 * FontSize) > Limit Then
    '                    lnn += 1
    '                    perline = 0
    '                End If
    '                perline += 1
    '                Globals.SpriteBatch.Draw(Fonts.PXfont, New Rectangle(TextHandler.REC.X + perline * (5 * FontSize) + perline + 1, TextHandler.REC.Y + 1 + (lnn * 7 * FontSize), 5 * FontSize, 7 * FontSize), New Rectangle(TextHandler.Convert(TXT.Substring(q, 1)), 1, 5, 7), TextC)
    '            ElseIf FontType = "Px7" Then
    '                Globals.SpriteBatch.Draw(Fonts.PXfont, New Rectangle(q * FontSize, TextHandler.REC.Y, FontSize, FontSize), New Rectangle(0, 0, 0, 0), TextC)
    '            End If
    '        Next
    '        If aminate < 11 Then
    '            Globals.SpriteBatch.Draw(Fonts.PXfont, New Rectangle(TextHandler.REC.X + BookMark * (5 * FontSize) + BookMark + 1, TextHandler.REC.Y + 1, 5 * FontSize, 7 * FontSize), New Rectangle(48, 1, 5, 7), TextC)
    '        Else
    '            Globals.SpriteBatch.Draw(Fonts.PXfont, New Rectangle(TextHandler.REC.X + BookMark * (5 * FontSize) + BookMark + 1, TextHandler.REC.Y + 1, 5 * FontSize, 7 * FontSize), New Rectangle(54, 1, 5, 7), TextC)
    '        End If
    '    End If
    '    Globals.SpriteBatch.End()
    'End Sub
    Public Shared Function Convert(ByVal st As String)
        Select Case Asc(st)
            Case 32 To 126
                Return Asc(st) * 6
            Case Else
                Select Case st
                    Case "α" 'A
                        Return 0
                    Case "β" 'B
                        Return 6
                    Case "λ" 'X
                        Return 12
                    Case "Δ" 'Y
                        Return 18
                    Case "˄" 'Up
                        Return 24
                    Case "˅" 'Down
                        Return 30
                    Case "˂" 'Left
                        Return 36
                    Case "˃" 'Right
                        Return 42
                    Case "♂" 'Lshulder
                        Return 60
                    Case "♀" 'Rshoulder
                        Return 66
                    Case "Σ" 'Rtrig
                        Return 72
                    Case "÷" 'Ltrig
                        Return 78
                    Case "°" 'Menu?
                        Return 82
                    Case Else
                        Return Nothing
                End Select
        End Select
    End Function
    Public Shared Function KeyBindNames(ByVal ky As Integer)
        Select Case ky
            Case 9
                Return "Tab"
            Case 13
                Return "Enter"
            Case 27
                Return "Escape"
            Case 32
                Return "Space"
            Case 33
                Return "Exclaim"
            Case 34
                Return "Quote"
            Case 35
                Return "Pound"
            Case 36
                Return "Cache"
            Case 37
                Return "Left Arrow"
            Case 38
                Return "Up Arrow"
            Case 39
                Return "Right Arrow"
            Case 40
                Return "Down Arrow"
            Case 41
                Return "Close Parenthesis"
            Case 42
                Return "Asterisk"
            Case 43
                Return "Plus"
            Case 44
                Return "Comma"
            Case 45
                Return "Minus"
            Case 46
                Return "Period"
            Case 47
                Return "Slash"
            Case 48
                Return "0"
            Case 49
                Return "1"
            Case 50
                Return "2"
            Case 51
                Return "3"
            Case 52
                Return "4"
            Case 53
                Return "5"
            Case 54
                Return "6"
            Case 55
                Return "7"
            Case 56
                Return "8"
            Case 57
                Return "9"
            Case 58
                Return "Colon"
            Case 59
                Return "Semi-Colon"
            Case 60
                Return "Less"
            Case 61
                Return "Equal"
            Case 62
                Return "Greater"
            Case 63
                Return "Question"
            Case 64
                Return "At"
            Case 65
                Return "A"
            Case 66
                Return "B"
            Case 67
                Return "C"
            Case 68
                Return "D"
            Case 69
                Return "E"
            Case 70
                Return "F"
            Case 71
                Return "G"
            Case 72
                Return "H"
            Case 73
                Return "I"
            Case 74
                Return "J"
            Case 75
                Return "K"
            Case 76
                Return "L"
            Case 77
                Return "M"
            Case 78
                Return "N"
            Case 79
                Return "O"
            Case 80
                Return "P"
            Case 81
                Return "Q"
            Case 82
                Return "R"
            Case 83
                Return "S"
            Case 84
                Return "T"
            Case 85
                Return "U"
            Case 86
                Return "V"
            Case 87
                Return "W"
            Case 88
                Return "X"
            Case 89
                Return "Y"
            Case 90
                Return "Z"
            Case 91
                Return "Open Bracket"
            Case 92
                Return "Backslash"
            Case 93
                Return "Close Bracket"
            Case 94
                Return "Hat"
            Case 95
                Return "Underscore"
            Case 96
                Return "Apostrophe"
            Case 112
                Return "F1"
            Case 113
                Return "F2"
            Case 114
                Return "F3"
            Case 115
                Return "F4"
            Case 116
                Return "F5"
            Case 117
                Return "F6"
            Case 118
                Return "F7"
            Case 119
                Return "F8"
            Case 120
                Return "F9"
            Case 121
                Return "F10"
            Case 122
                Return "F11"
            Case 123
                Return "Open Brace"
            Case 124
                Return "Pipe"
            Case 125
                Return "Close Brace"
            Case 126
                Return "Tilde"
            Case 160
                Return "Left Shift"
            Case Else
                'Console.WriteLine(ky & " " & ChrW(ky))
                Return ChrW(ky) & " (Unknown)"
        End Select
    End Function
End Class