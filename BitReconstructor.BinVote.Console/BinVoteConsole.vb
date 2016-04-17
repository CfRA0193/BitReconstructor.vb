Imports System.IO

Module BinVoteConsole
    Private Const _outputNameSpecified = True

    Private Sub LogoOut()
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("                              ")
        Console.WriteLine(" ▒▓▒▒▒▒▒▒▒     ▒███▒  ▓▓▒▓░   ")
        Console.WriteLine(" ███████████   █████  ████▓   ")
        Console.WriteLine(" ████████████   ░▒░   ████▒   ")
        Console.WriteLine(" █████  ▓████  ▓▓▓▓▓  ██████▒ ")
        Console.WriteLine(" █████ ▓███▓   █████  ██████▓ ")
        Console.WriteLine(" █████ ████▓   █████  ██████▓ ")
        Console.WriteLine(" █████ ▓▓████░ █████  ████▒   ")
        Console.WriteLine(" █████   ▓███▓ █████  █████░  ")
        Console.WriteLine(" █████ ██████▒ █████  ▒██████ ")
        Console.WriteLine(" █████ █████▒  █████   ░█████ ")
        Console.WriteLine(" ▒▒▒▒▒ ▒▒▒░    ▒▒▒▒▒      ▒▓▒ ")
        Console.WriteLine(" R E C O N S T R U C T O R    ")
        Console.WriteLine(" " + My.Application.Info.Version.ToString())
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.WriteLine(BinVote.AuthorString)
        Console.ForegroundColor = ConsoleColor.Gray
        Console.WriteLine()
    End Sub

    Private Sub MessageOutHandler(message As String, textColor As ConsoleColor)
        Console.ForegroundColor = textColor
        Console.WriteLine(" " + message)
        Console.ForegroundColor = ConsoleColor.Gray
    End Sub

    Private Sub ProgressUpdatedHandler(progress As Single)
        Console.Write(vbCr + " Progress:  {0:0.00} %", progress * 100.0F)
    End Sub

    Sub Main(args As String())
        LogoOut()
        'Dim files = New String() {"D:\Temp\ "}
        If BinVote.Process(args, _outputNameSpecified, True, AddressOf MessageOutHandler, AddressOf ProgressUpdatedHandler) Then
            Console.WriteLine(vbCrLf + " Processing: OK!")
        Else
            Console.WriteLine(vbCrLf + " Processing: ERROR!")
        End If
    End Sub
End Module
