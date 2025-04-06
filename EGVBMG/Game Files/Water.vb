Public Class Water
    Inherits BaseScreen
    Public Shared Deepness As Integer = 0
    Public Shared PlayerPos As Vector2 = New Vector2(602, 200)
    Public Shared PlayerVel As Vector2 = Vector2.Zero
    Public Shared Breath As Integer = 20
    Public Shared BreathMax As Integer = 20
    Public Shared FishCollection As New List(Of Fish)
    Public Shared MenuOpen As Boolean = True
    Public Shared DeepMax As Integer = 3200000
    Public Shared FishPage As Integer = -1
    Public Shared FishCollected As Integer = -1
    Public Shared Scale As Integer = 4
    Public Shared Playersize As Point = New Point(10 * Scale, 19 * Scale)
    Public Shared DMGcd As Integer = 100
    Public Shared Bubbles(50) As Bubble
    Public Shared Bubct As Integer = 0
    Public Shared LayerTitleCD As Integer = 0
    Public Shared GrabCD As Integer = 0
    Public Shared Amination As Integer = 0
    'Lanternfish=Herring
    Public Shared FishNames() As String = {"Mackerel", "Requiem", "Whale Shark", "Lanternfish", "Anchovy", "Salmon", "Flyingfish", "Halfbeak", "Sauries", "Dolphinfish", "Pomfret", "Barracuda", "Tuna",'Epipelagic
        "Lanternfish", "Opah", "Ridgehead", "Hatchetfish",'mesopelagic
        "Bristlemouth", "Anglerfish", "Viperfish", "Telescopefish", "Hammerjaw", "Daggertooth", "Pelican Eel", "Flabby Whalefish", _ 'Bathypelagic
        "Rattail", "Brotula", _ 'Benthopelagic
        "Flatfish", "Hagfish", "Eelpout", "Stingray", "Lumpfish", "Batfish"} 'BENTHICC
    Public Shared FishDescriptions() As String = {"Lamniformes are a species of shark that are commonly known as mackerel sharks." & vbCrLf & " Famous Lamniformes include; The Great White Shark, The Goblin Shark, and the Megamouth Shark." &
        vbCrLf & "You can distinguish a Lamniform from similar species by; The Anal Fin, Double Dorsal Fin," & vbCrLf & " Penta-Slit Gills, Eyes without Nicitating Membranes, and Hind-Optical Jawline." &
        vbCrLf & "Lamniformes dominated the Oceanic Ecosystems after undrgoing Intense Prominent Radiation throughout" & vbCrLf & " The Cretaceous Period. There are currently 15 species of Lamniformes.",'lamniform
        "Carcharhinidae are migrating, live-bearing sharks that enjoy warm waters." & vbCrLf & "Species of Carcharhinidae include; Bull Sharks, Lemon Sharks, Backtip Sharks, Whitetip Reef Sharks." &
        vbCrLf & "Unique characteristics of Carcharhinidae include; Circular Eyes, A couple of Gill Slits located behind the Pectoral Fin Base." & vbCrLf &
        "These fish enjoy tropical vacations, and they generate more sharks from Spring to Autumn." & vbCrLf & "These are the Top Five Sharks in Competitive Human Eating, and are also French." & vbCrLf &
        "They are dramatically quick thanks to their torpedo shaped bodies, and enjoy nap time.",'Carcharinidae
        "Rhincodontidae are Obtuse and unhurried beasts of the Ocean. They are the largest of all fish." & vbCrLf & "They hold a LOT of size records and have their own Genus called Rhincodon." & vbCrLf &
        "They never inhabit waters under 21C/70F and live on permanent vacation, living to 130 years old." & vbCrLf & "They only feed on Plankton and smaller fish due to not being able to catch other food." &
        vbCrLf & "Their teeth are shaped into bristles to filter food, and can regenerate parts of injured fins or surface wounds.",'Rhincodontidae
        "Myctophidae are the most diverse and widespread type of fish in existence. They look sad and pathetic." & vbCrLf & "They are covered in Silvery Deciduous Cucloid Scales, have gigantic heads, but no forehead." &
        vbCrLf & "They have a Gas Bladder that allows them to stay at particular DEPTHS without maintining lift." &
        vbCrLf & "Few can weild specialised photophores on the caudal peduncle, near their eyes called 'headlights' and luminous patches." & vbCrLf & "This can emit light to camouflage or see the road ahead.",'Myctophidae
        "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "",
        "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "",
        "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "",
        "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "",
        "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "",
        "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "",
        "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "",
        "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "",
        "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "",
        "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & ""}
    Private AniTime As Double = 0
    Public Sub New()
        Name = "Water"
        State = ScreenState.Active
        FishCollection = New List(Of Fish)
        Dim f As New Fish 'Mackerel
        f.Pos = New Vector2(800, 500)
        f.Collected = False
        f.MidDepth = 800
        f.Speed = 3
        FishCollection.Add(f)
        'Requiem
        f = New Fish
        f.Pos = New Vector2(600, 1500)
        f.Collected = False
        f.MidDepth = 1750
        f.Speed = 4
        FishCollection.Add(f)
        'Whale Shark
        f = New Fish
        f.Pos = New Vector2(600, 2200)
        f.Collected = False
        f.MidDepth = 2300
        f.Speed = 8
        FishCollection.Add(f)
        'Herring 'Lanternfish in case I DNF
        f = New Fish
        f.Pos = New Vector2(600, 3000)
        f.Collected = False
        f.MidDepth = 3300
        f.Speed = 10
        FishCollection.Add(f)
        'Anchovy
        f = New Fish
        f.Pos = New Vector2(600, 2200)
        f.Collected = False
        f.MidDepth = 5600
        f.Speed = 8
        FishCollection.Add(f)
        'Salmon
        f = New Fish
        f.Pos = New Vector2(600, 2200)
        f.Collected = False
        f.MidDepth = 7200
        f.Speed = 8
        FishCollection.Add(f)
        'Flyingfish
        'Halfbeak
        'Sauries
        'Dolphinfish
        'Pomfret
        'Barracuda
        'Tuna
        'Lanternfish
        For q As Integer = 0 To Bubbles.Length - 1
            Bubbles(q) = New Bubble
        Next
        'For q As Integer = 0 To FishCollection.Count - 1
        '    FishCollection(q).Collected = True
        'Next
    End Sub
    Dim Rpressed As Boolean = False
    Dim Lpressed As Boolean = False
    Public Overrides Sub HandleInput()
        If MenuOpen Then
            If Not Input.GA_Left Then Lpressed = False
            If Not Input.GA_Right Then Rpressed = False
            If Input.GA_Left And Not Lpressed Then
                If FishPage > -1 Then FishPage -= 1
                Lpressed = True
            End If
            If Input.GA_Right And Not Rpressed Then
                If FishPage < FishCollection.Count - 1 Then FishPage += 1
                Rpressed = True
            End If
            If Input.GA_Forward Then
                MenuOpen = False
            End If
        Else
            If Input.GA_Up Then
                PlayerVel.Y -= 2
            End If
            If Input.GA_Left Then
                PlayerVel.X -= 2
            End If
            If Input.GA_Down Then
                PlayerVel.Y += 2
            End If
            If Input.GA_Right Then
                PlayerVel.X += 2
            End If
            If Input.GA_Forward Then
                GrabCD = 10
                For q As Integer = 0 To FishCollection.Count - 1
                    If Maths.Distance(New Vector2(FishCollection(q).Pos.X, FishCollection(q).Pos.Y), New Vector2(PlayerPos.X + 10, PlayerPos.Y + Deepness + 20)) < 30 And Not FishCollection(q).Collected Then
                        Select Case q
                            Case 0
                                If FishCollection(0).Pos.X < 946 Or FishCollection(0).Pos.Y < 730 Then
                                    FishCollection(q).Collected = True
                                    FishCollected += 1
                                    BreathMax *= 2.5
                                    Breath = BreathMax
                                End If
                            Case 1
                                If FishCollection(1).Pos.X < 48 Or FishCollection(1).Pos.X > 320 And FishCollection(1).Pos.X < 548 Or FishCollection(1).Pos.X > 820 And FishCollection(1).Pos.X < 1048 Or FishCollection(1).Pos.X > 1320 Then
                                    FishCollection(q).Collected = True
                                    FishCollected += 1
                                    BreathMax *= 4
                                    Breath = BreathMax
                                End If
                            Case 2
                                If 1 = 1 Then
                                    FishCollection(q).Collected = True
                                    FishCollected += 1
                                    BreathMax *= 4
                                    Breath = BreathMax
                                End If
                            Case 3
                                If 1 = 1 Then
                                    FishCollection(q).Collected = True
                                    FishCollected += 1
                                    BreathMax *= 4
                                    Breath = BreathMax
                                End If
                        End Select
                    End If
                Next
            End If
        End If
        If Input.GA_Backward Then
            If MenuOpen Then End
            If Not MenuOpen Then
                MenuOpen = True
                IO.File.Create(My.Application.Info.DirectoryPath & "/Save.txt").Dispose()
                IO.File.WriteAllText(My.Application.Info.DirectoryPath & "/Save.txt", FishCollected)
            End If
        End If
    End Sub
    Public Overrides Sub Update()
        If Not MenuOpen Then AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If AniTime > 2 Then
            AniTime = 0
            PlayerPos += PlayerVel
            If PlayerPos.Y > 300 Then
                If Deepness < DeepMax Then
                    Deepness += 1
                    PlayerPos.Y = 300
                End If
            Else
                If Deepness > 0 Then
                    Deepness -= 1
                    PlayerVel.X /= 2
                    PlayerPos.Y = 300
                End If
            End If
            If Deepness > 0 Then
                DMGcd -= 1
                If DMGcd = 0 Then
                    DMGcd = 100
                    Breath -= (Deepness / 500)
                    If Breath < 0 Then Breath = 0
                End If
                If PlayerPos.Y + Deepness > FishCollection(FishCollected + 1).MidDepth + 200 Then Breath -= 1
            Else
                Breath = BreathMax
            End If
            If PlayerPos.X < 0 Then
                PlayerPos.X = 0
                PlayerVel.X = 0
            End If
            If PlayerPos.X > 1280 - Playersize.X Then
                PlayerPos.X = 1280 - Playersize.X
                PlayerVel.X = 0
            End If
            If PlayerVel.Y < -10 Then PlayerVel.Y = -10
            If PlayerVel.Y > 10 Then PlayerVel.Y = 10
            For q As Integer = 0 To FishCollection.Count - 1
                If q < 3 Then
                    If FishCollection(q).Pos.Y < FishCollection(q).MidDepth Then FishCollection(q).Pos.Y += FishCollection(q).Speed
                    If FishCollection(q).Pos.Y > FishCollection(q).MidDepth Then FishCollection(q).Pos.Y -= FishCollection(q).Speed
                End If
                Select Case q
                    Case 0
                        Select Case FishCollection(q).Behavior
                            Case 0
                                FishCollection(q).Pos.X -= FishCollection(q).Speed
                                If FishCollection(q).Pos.X < 0 Then FishCollection(q).Behavior += 1
                            Case 1
                                FishCollection(q).Pos.X += FishCollection(q).Speed
                                If FishCollection(q).Pos.X > 2000 Then FishCollection(q).Behavior -= 1
                        End Select
                    Case 1
                        Select Case FishCollection(q).Behavior
                            Case 0
                                FishCollection(q).Pos.X -= FishCollection(q).Speed
                                If FishCollection(q).Pos.X < -200 Then FishCollection(q).Behavior += 1
                            Case 1
                                FishCollection(q).Pos.X += FishCollection(q).Speed
                                If FishCollection(q).Pos.X > 2000 Then FishCollection(q).Behavior -= 1
                        End Select
                    Case 2
                        Select Case FishCollection(q).Behavior
                            Case 0
                                FishCollection(q).Pos.X -= FishCollection(q).Speed
                                If FishCollection(q).Pos.X < -200 Then FishCollection(q).Behavior += 1
                                FishCollection(q).Pos.Y += FishCollection(q).Speed
                            Case 1
                                FishCollection(q).Pos.X += FishCollection(q).Speed
                                If FishCollection(q).Pos.X > 2000 Then FishCollection(q).Behavior += 1
                                FishCollection(q).Pos.Y += FishCollection(q).Speed
                            Case 2
                                FishCollection(q).Pos.X -= FishCollection(q).Speed
                                If FishCollection(q).Pos.X < -200 Then FishCollection(q).Behavior += 1
                                FishCollection(q).Pos.Y += FishCollection(q).Speed
                            Case 3
                                FishCollection(q).Pos.X += FishCollection(q).Speed
                                If FishCollection(q).Pos.X > 2000 Then FishCollection(q).Behavior += 1
                                FishCollection(q).Pos.Y -= FishCollection(q).Speed
                            Case 4
                                FishCollection(q).Pos.X -= FishCollection(q).Speed
                                If FishCollection(q).Pos.X < -200 Then FishCollection(q).Behavior += 1
                                FishCollection(q).Pos.Y -= FishCollection(q).Speed
                            Case 5
                                FishCollection(q).Pos.X += FishCollection(q).Speed
                                If FishCollection(q).Pos.X > 2000 Then FishCollection(q).Behavior = 0
                                FishCollection(q).Pos.Y -= FishCollection(q).Speed
                        End Select
                    Case 3
                        Select Case FishCollection(q).Behavior
                            Case 0
                                FishCollection(q).Pos.X -= FishCollection(q).Speed
                                If FishCollection(q).Pos.X < 640 Then FishCollection(q).Behavior = RNG.Free(3, 5)
                                FishCollection(q).Pos.Y -= FishCollection(q).Speed
                            Case 1
                                FishCollection(q).Pos.X -= FishCollection(q).Speed
                                If FishCollection(q).Pos.X < 50 Then FishCollection(q).Behavior = RNG.Free(3, 5)
                                FishCollection(q).Pos.Y += FishCollection(q).Speed
                            Case 2
                                FishCollection(q).Pos.X -= FishCollection(q).Speed
                                If FishCollection(q).Pos.X < 50 Then FishCollection(q).Behavior = RNG.Free(3, 5)
                            Case 3
                                FishCollection(q).Pos.X += FishCollection(q).Speed
                                If FishCollection(q).Pos.X > 640 Then FishCollection(q).Behavior = RNG.Free(0, 2)
                                FishCollection(q).Pos.Y -= FishCollection(q).Speed
                            Case 4
                                FishCollection(q).Pos.X += FishCollection(q).Speed
                                If FishCollection(q).Pos.X > 1200 Then FishCollection(q).Behavior = RNG.Free(0, 2)
                                FishCollection(q).Pos.Y += FishCollection(q).Speed
                            Case 5
                                FishCollection(q).Pos.X += FishCollection(q).Speed
                                If FishCollection(q).Pos.X > 1200 Then FishCollection(q).Behavior = RNG.Free(0, 2)
                        End Select
                        If FishCollection(q).Pos.Y < 3000 Then FishCollection(q).Pos.Y = 3000
                        If FishCollection(q).Pos.Y > 3200 Then FishCollection(q).Pos.Y = 3200
                        If FishCollection(q).Pos.X < 0 Then FishCollection(q).Pos.X = 0
                        If FishCollection(q).Pos.X > 1280 Then FishCollection(q).Pos.X = 1280
                End Select

            Next
            Bubbles(Bubct).Pos = PlayerPos
            Bubct += 1
            If Bubct = Bubbles.Length - 1 Then Bubct = 0
            For q As Integer = 0 To Bubbles.Length - 1
                Bubbles(q).Pos.Y -= RNG.Free(1, 3)
                Bubbles(q).Pos.X += RNG.Free(-1, 1)
            Next
            If 20 < Deepness And Deepness < 50 Then
                LayerTitleCD = 100
            ElseIf 2400 < Deepness And Deepness < 2550 Then
                LayerTitleCD = 100
            End If
            If LayerTitleCD > 0 Then LayerTitleCD -= 1
            If GrabCD > 0 Then GrabCD -= 1
        End If
    End Sub

    Public Overrides Sub Draw()
        Amination += 1
        If Amination > 60 Then Amination = 0
        Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(0, 0, Globals.BackBuffer.Width, Globals.BackBuffer.Height), Color.Black)
        Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(0, 0 - Deepness, Globals.BackBuffer.Width, Globals.BackBuffer.Height / 3), Color.CornflowerBlue)
        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(0, 240 - Deepness, Globals.BackBuffer.Width, 1000), New Rectangle(717, 0, 3, 720), New Color(140, 221, 255))
        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(0, 1500 - Deepness, Globals.BackBuffer.Width, -Globals.BackBuffer.Height), New Rectangle(717, 0, 3, 720), New Color(0, 1074 - Deepness, 10127 - Deepness))
        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(0, 1500 - Deepness, Globals.BackBuffer.Width, Globals.BackBuffer.Height), New Rectangle(717, 0, 3, 720), New Color(0, 1074 - Deepness, 10127 - Deepness))




        If MenuOpen Then

            If FishPage > -1 Then 'Fish Menu
                Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(0, 0, Globals.BackBuffer.Width, Globals.BackBuffer.Height), New Color(0, 0, 0) * 0.4F)
                GameObj.DrawLetter(New Vector2(426, 80), FishNames(FishPage), Color.Cyan, 0, 2)
                If FishCollection(FishPage).Collected Then GameObj.DrawLetter(New Vector2(26, 580), FishDescriptions(FishPage), Color.Cyan, 0, 1)
                Dim collecolour As Color = Color.Black
                If FishCollection(FishPage).Collected Then collecolour = Color.White
                Select Case FishPage
                    Case 0
                        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(640, 360, 49 * Scale, 23 * Scale), New Rectangle(50, 2, 49, 23), collecolour, 0, New Vector2(24.5, 11.5), SpriteEffects.None, 0)
                    Case 1
                        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(640, 360, 49 * Scale, 23 * Scale), New Rectangle(54, 30, 49, 23), collecolour, 0, New Vector2(24.5, 11.5), SpriteEffects.None, 0)
                    Case 2
                        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(640, 360, 49 * Scale, 23 * Scale), New Rectangle(55, 58, 49, 26), collecolour, 0, New Vector2(24.5, 13), SpriteEffects.None, 0)
                    Case 3
                        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(640, 360, 26 * Scale, 10 * Scale), New Rectangle(62, 86, 26, 10), collecolour, 0, New Vector2(24.5, 13), SpriteEffects.None, 0)
                    Case 4

                    Case 5

                    Case 6

                    Case 7

                    Case 8

                    Case 9


                End Select
            Else 'Regular Menu
                Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X, PlayerPos.Y, Playersize.X, Playersize.Y), New Rectangle(19, 0, 9, 19), Color.White)
                Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X - Scale, PlayerPos.Y, 5 * Scale, -42 * Scale), New Rectangle(35, 1, 5, 42), Color.White)
                Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X - Scale, PlayerPos.Y - (42 * Scale), 5 * Scale, -42 * Scale), New Rectangle(35, 1, 5, 42), Color.White)
                Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(0, 0, Globals.BackBuffer.Width, Globals.BackBuffer.Height), New Color(0, 0, 0) * 0.4F)
                GameObj.DrawLetter(New Vector2(50, 360), "Press A to Start playing the game", Color.Cyan, 0, 1)
                GameObj.DrawLetter(New Vector2(801, 360), "Press Right to look at your fish collection", Color.Cyan, 0, 1)
                GameObj.DrawLetter(New Vector2(426, 580), "Press B to Save & Quit playing the game", Color.Cyan, 0, 1)
                'Press Right to look at your fish collection
                'Press B to Quit
            End If
        Else 'Game
            If PlayerVel.X > 5 Then
                Select Case Amination
                    Case 0 To 19
                        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X, PlayerPos.Y, 16 * Scale, 11 * Scale), New Rectangle(3, 123, 16, 11), Color.White)
                    Case 20 To 40
                        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X, PlayerPos.Y, 16 * Scale, 11 * Scale), New Rectangle(2, 95, 16, 11), Color.White)
                    Case Else
                        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X, PlayerPos.Y, 16 * Scale, 11 * Scale), New Rectangle(17, 21, 16, 11), Color.White)
                End Select
            ElseIf PlayerVel.X < -5 Then
                Select Case Amination
                    Case 0 To 19
                        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X, PlayerPos.Y, 16 * Scale, 11 * Scale), New Rectangle(2, 108, 16, 11), Color.White)
                    Case 20 To 40
                        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X, PlayerPos.Y, 16 * Scale, 11 * Scale), New Rectangle(3, 136, 16, 11), Color.White)
                    Case Else
                        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X, PlayerPos.Y, 16 * Scale, 11 * Scale), New Rectangle(17, 34, 16, 11), Color.White)
                End Select
            ElseIf GrabCD > 0 Then
                Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X, PlayerPos.Y, Playersize.X, Playersize.Y), New Rectangle(2, 14, 10, 19), Color.White)
            Else
                Select Case Amination
                    Case 0 To 19
                        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X, PlayerPos.Y, Playersize.X, Playersize.Y), New Rectangle(1, 73, 10, 19), Color.White)
                    Case 20 To 40
                        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X, PlayerPos.Y, Playersize.X, Playersize.Y), New Rectangle(13, 73, 10, 19), Color.White)
                    Case Else
                        Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X, PlayerPos.Y, Playersize.X, Playersize.Y), New Rectangle(19, 0, 10, 19), Color.White)
                End Select
            End If
            Select Case Amination
                Case 0 To 19
                    Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X - Scale, PlayerPos.Y, 5 * Scale, -42 * Scale), New Rectangle(35, 1, 5, 42), Color.White)
                    Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X - Scale, PlayerPos.Y - (42 * Scale), 5 * Scale, -42 * Scale), New Rectangle(35, 1, 5, 42), Color.White)
                Case 20 To 40
                    Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X - Scale, PlayerPos.Y, 5 * Scale, -42 * Scale), New Rectangle(1, 149, 5, 42), Color.White)
                    Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X - Scale, PlayerPos.Y - (42 * Scale), 5 * Scale, -42 * Scale), New Rectangle(1, 149, 5, 42), Color.White)
                Case Else
                    Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X - Scale, PlayerPos.Y, 5 * Scale, -42 * Scale), New Rectangle(1, 193, 5, 42), Color.White)
                    Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(PlayerPos.X - Scale, PlayerPos.Y - (42 * Scale), 5 * Scale, -42 * Scale), New Rectangle(1, 193, 5, 42), Color.White)
            End Select


            'Particles
            For q As Integer = 0 To Bubbles.Length - 1
                If RNG.Fixed(0, 100, 5467 + q, True) > 50 Then
                    Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(Bubbles(q).Pos.X, Bubbles(q).Pos.Y, 7, 7), New Rectangle(0, 62, 7, 7), Color.White)
                Else
                    Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(Bubbles(q).Pos.X, Bubbles(q).Pos.Y, 9, 9), New Rectangle(9, 62, 9, 9), Color.White)
                End If
            Next


            For q As Integer = 0 To FishCollection.Count - 1
                If Not FishCollection(q).Collected Then
                    Select Case q
                        Case 0
                            Select Case FishCollection(q).Behavior
                                Case 0
                                    Select Case Amination
                                        Case 0 To 19
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 23 * Scale), New Rectangle(242, 10, 49, 23), Color.White, 0, New Vector2(24.5, 11.5), SpriteEffects.None, 0)
                                        Case 20 To 40
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 23 * Scale), New Rectangle(50, 2, 49, 23), Color.White, 0, New Vector2(24.5, 11.5), SpriteEffects.None, 0)
                                        Case Else
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 23 * Scale), New Rectangle(315, 9, 49, 23), Color.White, 0, New Vector2(24.5, 11.5), SpriteEffects.None, 0)
                                    End Select
                                Case 1
                                    Select Case Amination
                                        Case 0 To 19
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 23 * Scale), New Rectangle(242, 10, 49, 23), Color.White, 0, New Vector2(24.5, 11.5), SpriteEffects.FlipHorizontally, 0)
                                        Case 20 To 40
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 23 * Scale), New Rectangle(50, 2, 49, 23), Color.White, 0, New Vector2(24.5, 11.5), SpriteEffects.FlipHorizontally, 0)
                                        Case Else
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 23 * Scale), New Rectangle(315, 9, 49, 23), Color.White, 0, New Vector2(24.5, 11.5), SpriteEffects.FlipHorizontally, 0)
                                    End Select
                            End Select
                        Case 1
                            Select Case FishCollection(q).Behavior
                                Case 0
                                    Select Case Amination
                                        Case 0 To 19
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 23 * Scale), New Rectangle(246, 38, 49, 23), Color.White, 0, New Vector2(24.5, 11.5), SpriteEffects.None, 0)
                                        Case 20 To 40
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 23 * Scale), New Rectangle(54, 30, 49, 23), Color.White, 0, New Vector2(24.5, 11.5), SpriteEffects.None, 0)
                                        Case Else
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 23 * Scale), New Rectangle(319, 37, 49, 23), Color.White, 0, New Vector2(24.5, 11.5), SpriteEffects.None, 0)
                                    End Select
                                Case 1
                                    Select Case Amination
                                        Case 0 To 19
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 23 * Scale), New Rectangle(246, 38, 49, 23), Color.White, 0, New Vector2(24.5, 11.5), SpriteEffects.FlipHorizontally, 0)
                                        Case 20 To 40
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 23 * Scale), New Rectangle(54, 30, 49, 23), Color.White, 0, New Vector2(24.5, 11.5), SpriteEffects.FlipHorizontally, 0)
                                        Case Else
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 23 * Scale), New Rectangle(319, 37, 49, 23), Color.White, 0, New Vector2(24.5, 11.5), SpriteEffects.FlipHorizontally, 0)
                                    End Select
                            End Select
                        Case 2
                            Select Case FishCollection(q).Behavior Mod 2
                                Case 0
                                    Select Case Amination
                                        Case 0 To 19
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 26 * Scale), New Rectangle(247, 65, 49, 26), Color.White, 0, New Vector2(24.5, 13), SpriteEffects.None, 0)
                                        Case 20 To 40
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 26 * Scale), New Rectangle(55, 58, 49, 26), Color.White, 0, New Vector2(24.5, 13), SpriteEffects.None, 0)
                                        Case Else
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 26 * Scale), New Rectangle(320, 65, 49, 26), Color.White, 0, New Vector2(24.5, 13), SpriteEffects.None, 0)
                                    End Select
                                Case 1
                                    Select Case Amination
                                        Case 0 To 19
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 26 * Scale), New Rectangle(247, 65, 49, 26), Color.White, 0, New Vector2(24.5, 13), SpriteEffects.FlipHorizontally, 0)
                                        Case 20 To 40
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 26 * Scale), New Rectangle(55, 58, 49, 26), Color.White, 0, New Vector2(24.5, 13), SpriteEffects.FlipHorizontally, 0)
                                        Case Else
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 49 * Scale, 26 * Scale), New Rectangle(320, 65, 49, 26), Color.White, 0, New Vector2(24.5, 13), SpriteEffects.FlipHorizontally, 0)
                                    End Select
                            End Select
                        Case 3
                            Select Case FishCollection(q).Behavior
                                Case 0 To 2
                                    Select Case Amination
                                        Case 0 To 19
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 26 * Scale, 10 * Scale), New Rectangle(254, 94, 26, 10), Color.White, 0, New Vector2(24.5, 13), SpriteEffects.None, 0)
                                        Case 20 To 40
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 26 * Scale, 10 * Scale), New Rectangle(62, 86, 26, 10), Color.White, 0, New Vector2(24.5, 13), SpriteEffects.None, 0)
                                        Case Else
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 26 * Scale, 10 * Scale), New Rectangle(327, 93, 26, 10), Color.White, 0, New Vector2(24.5, 13), SpriteEffects.None, 0)
                                    End Select
                                Case 3 To 5
                                    Select Case Amination
                                        Case 0 To 19
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 26 * Scale, 10 * Scale), New Rectangle(254, 94, 26, 10), Color.White, 0, New Vector2(24.5, 13), SpriteEffects.FlipHorizontally, 0)
                                        Case 20 To 40
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 26 * Scale, 10 * Scale), New Rectangle(62, 86, 26, 10), Color.White, 0, New Vector2(24.5, 13), SpriteEffects.FlipHorizontally, 0)
                                        Case Else
                                            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(FishCollection(q).Pos.X, FishCollection(q).Pos.Y - Deepness, 26 * Scale, 10 * Scale), New Rectangle(327, 93, 26, 10), Color.White, 0, New Vector2(24.5, 13), SpriteEffects.FlipHorizontally, 0)
                                    End Select
                            End Select
                        Case 4

                        Case 5

                        Case 6

                        Case 7

                        Case 8

                    End Select
                End If

            Next

            'Obstackles
            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(948, 750 - Deepness, 83 * Scale, 47 * Scale), New Rectangle(108, 0, 83, 47), Color.White)

            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(48, 1700 - Deepness, 68 * Scale, 58 * Scale), New Rectangle(119, 70, 68, 58), Color.White)
            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(548, 1700 - Deepness, 68 * Scale, 58 * Scale), New Rectangle(119, 70, 68, 58), Color.White)
            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(1048, 1700 - Deepness, 68 * Scale, 58 * Scale), New Rectangle(119, 70, 68, 58), Color.White)

            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(0, 2200 - Deepness, 35 * Scale, 112 * Scale), New Rectangle(135, 144, 35, 112), Color.White)
            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(300, 2200 - Deepness, 35 * Scale, 112 * Scale), New Rectangle(135, 144, 35, 112), Color.White)
            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(800, 2200 - Deepness, 35 * Scale, 112 * Scale), New Rectangle(135, 144, 35, 112), Color.White)
            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(1100, 2200 - Deepness, 35 * Scale, 112 * Scale), New Rectangle(135, 144, 35, 112), Color.White)





            GameObj.DrawLetter(New Vector2(0, 51), "Depth: " & Deepness, Color.Cyan, 13, 1)
            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(0, 0, 510, 50), New Rectangle(0, 50, 51, 5), Color.White)
            Globals.SpriteBatch.Draw(Textures.Sprites, New Rectangle(0, 0, 510 * (Breath / BreathMax), 50), New Rectangle(0, 56, 51, 5), Color.White)

            If LayerTitleCD > 0 Then
                Select Case Deepness
                    Case 0 To 100
                        GameObj.DrawLetter(New Vector2(486, 400), "EPIPELAGIC ZONE", Color.Black, 0, 2)
                        GameObj.DrawLetter(New Vector2(485, 401), "EPIPELAGIC ZONE", Color.Black, 0, 2)
                        GameObj.DrawLetter(New Vector2(484, 400), "EPIPELAGIC ZONE", Color.Black, 0, 2)
                        GameObj.DrawLetter(New Vector2(485, 399), "EPIPELAGIC ZONE", Color.Black, 0, 2)
                        GameObj.DrawLetter(New Vector2(485, 400), "EPIPELAGIC ZONE", Color.Cyan, 0, 2)
                    Case 2400 To 5000
                        GameObj.DrawLetter(New Vector2(448, 400), "MESOPELAGIC ZONE", Color.Cyan, 0, 2)
                    Case 5000 To 8000
                        GameObj.DrawLetter(New Vector2(540, 360), "BATHYPELAGIC ZONE", Color.Cyan, 0, 2)
                    Case 8000 To 10000
                        GameObj.DrawLetter(New Vector2(540, 360), "BENTHOPELAGIC ZONE", Color.Cyan, 0, 2)
                    Case 10001 To 1000000000
                        GameObj.DrawLetter(New Vector2(540, 360), "BENTHIC ZONE", Color.Cyan, 0, 2)
                End Select
            End If

            GameObj.DrawLetter(New Vector2(0, 250), "Lanternfish:" & FishCollection(3).Pos.ToString & FishCollection(3).Behavior, Color.Cyan, 0, 1)
        End If
    End Sub
End Class