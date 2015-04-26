Imports System.IO
Imports BitReconstructor.BinVote

Module BinVoteConsole
    Private Sub LogoOut()
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine(" ")
        Console.WriteLine(" ▒▓▒▒▒▒▒▒▒     ▒███▒  ▓▓▒▓░    ")
        Console.WriteLine(" ███████████   █████  ████▓    ")
        Console.WriteLine(" ████████████   ░▒░   ████▒    ")
        Console.WriteLine(" █████  ▓████  ▓▓▓▓▓  ██████▒  ")
        Console.WriteLine(" █████ ▓███▓   █████  ██████▓  ")
        Console.WriteLine(" █████ ████▓   █████  ██████▓  ")
        Console.WriteLine(" █████ ▓▓████░ █████  ████▒    ")
        Console.WriteLine(" █████   ▓███▓ █████  █████░   ")
        Console.WriteLine(" █████ ██████▒ █████  ▒██████  ")
        Console.WriteLine(" █████ █████▒  █████   ░█████  ")
        Console.WriteLine(" ▒▒▒▒▒ ▒▒▒░    ▒▒▒▒▒      ▒▓▒  ")
        Console.WriteLine(" R E C O N S T R U C T O R")
        Console.ForegroundColor = ConsoleColor.Gray
        Console.WriteLine()
    End Sub

    Private Sub MessageOutHandler(message As String, textColor As ConsoleColor)
        Console.ForegroundColor = textColor
        Console.WriteLine(" " + message)
        Console.ForegroundColor = ConsoleColor.Gray
    End Sub

    Private Sub ProgressUpdatedHandler(progress As Single)
        Console.Write(vbCr + " " + "Progress:  {0:0.00} %", progress * 100.0F)
    End Sub

    Sub Main(args As String())
        LogoOut() : BinVote.Process(args, AddressOf MessageOutHandler, AddressOf ProgressUpdatedHandler)
    End Sub
End Module
