Public Class Save
    Public Shared currsavloc As String = "Save"
    Public Shared loc As String = My.Application.Info.DirectoryPath & "\" & currsavloc
    Public Shared Sub ChangeSavLoc(ByVal savenm As String)
        currsavloc = savenm
        loc = My.Application.Info.DirectoryPath & "\" & currsavloc
    End Sub
    Public Shared Sub Nuke()
        IO.Directory.Delete(loc, True)
    End Sub
    Public Shared Sub Save()
        If Not IO.Directory.Exists(loc) Then IO.Directory.CreateDirectory(loc)
        If Not IO.Directory.Exists(loc & "/Creatures") Then IO.Directory.CreateDirectory(loc & "/Creatures")
        If Not IO.Directory.Exists(loc & "/Backgrounds") Then IO.Directory.CreateDirectory(loc & "/Backgrounds")
    End Sub
    Public Shared Sub Load()
        If IO.Directory.Exists(loc & "/Creatures") Then

        End If
        If IO.Directory.Exists(loc & "/Backgrounds") Then

        End If
    End Sub
End Class
