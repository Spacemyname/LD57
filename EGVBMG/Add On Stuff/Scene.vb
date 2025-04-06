Public Class Scene
    Public Shared Function ChangeMap(n As String, Optional x As Integer = 0)
        Select Case n
            Case "TEST"

            Case "Demo"
                Return "Stage.DrawBGO = True"
                'Stage.Background = BGC(" \ Djelvian Escape I\Demo Street.png")
                'Stage.BackgroundCU = BGC("\Djelvian Escape I\BlankStreet.png")
                'Stage.Looped = False
                'Stage.Bounds = New Vector2(2000, 21750)
                ''SkyBox
                'addSkyBoxEntity(-1000, "ATMOSPHERE", 0)
                'addSkyBoxEntity(-509, "SUN", 0)
                'addSkyBoxEntity(-999, "GROUND", 0)
                ''BG plants
                'For q As Integer = 0 To 500
                '    addParticle(-4, 1, Color.White, New Vector2(2000 + RNG.Free(0, 20000), 0))
                'Next
                ''Entities
                'addEntity(-9, "Gate1", 1840)
                ''NPC1
                'Dim spch As New List(Of String)
                'spch.Add("Helo Comrade!" & vbCrLf & "Good Day, Yes?")
                'addNPC(2, "NPC1", 3000, 1, 15, 0, spch)
                ''NPC2
                'For q As Integer = 0 To 10
                '    spch = New List(Of String)
                '    spch.Add("Helo Comrade! Good Day For hunting shiny stone, Yes Comrade?")
                '    addNPC(2, "NPC" & q, 6000 + RNG.Free(1000, 12000), 1, 15, 6000 + RNG.Free(1000, 12000), spch)
                'Next
                ''Plant Variety
                'For q As Integer = 0 To 100
                '    addParticle(4, 1, Color.White, New Vector2(2000 + RNG.Free(0, 20000), 630))
                'Next
                ''Grass
                'For q As Integer = 0 To 100
                '    addParticle(4, 3, Color.White, New Vector2(2000 + RNG.Free(0, 20000), 630))
                'Next
                '"
            Case Else

        End Select
    End Function
End Class