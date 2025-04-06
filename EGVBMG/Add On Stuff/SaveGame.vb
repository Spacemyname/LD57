Public Class SaveGame
    Public Shared Save As String = "SAVE"
    Public Shared SaveData() As String
    Public Shared Sub UpdateSave()
        If IO.File.Exists(Environment.CurrentDirectory & "\" & Save & "\Savegame.ecroso") Then
            SaveData = IO.File.ReadAllLines(Environment.CurrentDirectory & "\" & Save & "\Savegame.ecroso")
        Else
            IO.Directory.CreateDirectory(Environment.CurrentDirectory & "\" & Save & "\Savegame.ecroso")
            IO.File.Create(Environment.CurrentDirectory & "\" & Save & "\Savegame.ecroso").Dispose()
            IO.File.WriteAllLines(Environment.CurrentDirectory & "\" & Save & "\Savegame.ecroso", SaveData)
        End If
    End Sub
End Class