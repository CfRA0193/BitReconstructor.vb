Imports System.IO
Imports System.Text
Imports Bwl.Framework

Module Main
    Private _consoleAppBase As ConsoleAppBase
    Private _authorString = " by Artem Drobanov (DrAF)"
    Private _N As IntegerSetting

    Private Sub LogoOut()
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("")
        Console.WriteLine(" B i t ")
        Console.WriteLine(" D E C O N S T R U C T O R ")
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
        If args.Length = 0 Then
            Console.WriteLine(" BitDeconstructor.Console <input file> [ <scrambling key> ]")
            Return
        End If
        If args.Length = 1 Then
            Dim fileName = args(0)
            Console.WriteLine(" Processing: {0}...", Path.GetFileName(fileName), _N.Value)
            BitDeconstructor.Deconstruction(fileName, _N.Value, Nothing)
            Console.WriteLine(" All Done!")
        Else
            Dim fileName = args(0)
            Dim key = Encoding.UTF8.GetBytes(args(1))
            Dim keyBase64 = Convert.ToBase64String(key)
            File.WriteAllText(String.Format("{0}{1}", fileName, BitScrambler.Ext), keyBase64)
            Console.WriteLine(" Processing with scrambling: {0}...", Path.GetFileName(fileName), _N.Value)
            BitDeconstructor.Deconstruction(fileName, _N.Value, key)
            Console.WriteLine(" All Done!")
        End If
    End Sub
End Module
