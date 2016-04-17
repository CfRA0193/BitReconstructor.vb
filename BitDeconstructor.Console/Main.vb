Imports System.IO
Imports Bwl.Framework

Module Main
    Private _consoleAppBase As ConsoleAppBase
    Private _authorString = " by Artem Drobanov (DrAF)"
    Private _N As IntegerSetting

    Private Sub LogoOut()
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine(" B i t")
        Console.WriteLine(" D E C O N S T R U C T O R    ")
        Console.WriteLine(" " + My.Application.Info.Version.ToString())
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.WriteLine(_authorString)
        Console.ForegroundColor = ConsoleColor.Gray
        Console.WriteLine()
    End Sub

    Sub Main(args As String())
        _consoleAppBase = New ConsoleAppBase()
        _N = New IntegerSetting(_consoleAppBase.RootStorage, "N", 3)
        _consoleAppBase.RootStorage.SaveSettings(False)
        LogoOut()
        For i = 0 To args.Length - 1
            Dim fileName = args(i)
            Console.WriteLine(" Processing {0}: {1} / {2} (N:{3})", Path.GetFileName(fileName), (i + 1), args.Length, _N.Value)
            If File.Exists(fileName) Then
                BitDeconstructor.Deconstruction(fileName, _N.Value)
            End If
        Next
    End Sub
End Module
