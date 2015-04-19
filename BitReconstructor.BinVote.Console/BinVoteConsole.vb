Imports System.IO
Imports BitReconstructor.BinVote

Module BinVoteConsole
    Private Sub LogoOut()
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("")
        Console.WriteLine("▒▓▒▒▒▒▒▒▒     ▒███▒  ▓▓▒▓░    ")
        Console.WriteLine("███████████   █████  ████▓    ")
        Console.WriteLine("████████████   ░▒░   ████▒    ")
        Console.WriteLine("█████  ▓████  ▓▓▓▓▓  ██████▒  ")
        Console.WriteLine("█████ ▓███▓   █████  ██████▓  ")
        Console.WriteLine("█████ ████▓   █████  ██████▓  ")
        Console.WriteLine("█████ ▓▓████░ █████  ████▒    ")
        Console.WriteLine("█████   ▓███▓ █████  █████░   ")
        Console.WriteLine("█████ ██████▒ █████  ▒██████  ")
        Console.WriteLine("█████ █████▒  █████   ░█████  ")
        Console.WriteLine("▒▒▒▒▒ ▒▒▒░    ▒▒▒▒▒      ▒▓▒  ")
        Console.WriteLine("R E C O N S T R U C T O R")
        Console.ForegroundColor = ConsoleColor.Gray
    End Sub

    Private Function ShortTest(inputsCount As Integer) As Boolean
        Dim allOk As Boolean
        Dim result = BinVoteTest.ShortTest(inputsCount, allOk)
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("Inputs: {0,6}", inputsCount)
        Console.WriteLine("Performance: {0:0.00} Mb/s", result / (1024 * 1024))
        Console.ForegroundColor = ConsoleColor.Gray
        Return allOk
    End Function

    Private Class BinVoteTask
        Public Sub New()
        End Sub
        Public Sub New(filename As String, streams As Stream())
            Me.Filename = filename
            Me.Streams = streams
        End Sub
        Public Property Filename As String
        Public Property Streams As Stream()
    End Class

    Private Function GetBinVoteTask(args As String()) As BinVoteTask
        If args.Length >= BinVote.StreamsCountMin Then
            Dim task = New BinVoteTask() With {.Filename = args(0)}
            Dim streams = New List(Of Stream)
            For Each arg In args
                If File.Exists(arg) Then
                    streams.Add(File.Open(arg, FileMode.Open))
                End If
            Next
            task.Streams = streams.ToArray()
            Return task
        End If
        Return Nothing
    End Function

    Private Sub ProgressUpdatedHandler(progress As Single)
        Console.Write(vbCr + "Progress: {0:0.00} %", progress * 100.0F)
    End Sub

    Sub Main(args As String())
        LogoOut() : Console.WriteLine()
        ShortTest(args.Length) : Console.WriteLine()
        Dim task = GetBinVoteTask(args)
        If task IsNot Nothing Then
            Dim outputName = "BitReconstructor." + task.Filename
            If File.Exists(outputName) Then
                File.SetAttributes(outputName, FileAttributes.Normal)
                File.Delete(outputName)
            End If
            Dim output = File.Open(outputName, FileMode.CreateNew)
            Console.WriteLine("Output:   {0}", outputName)
            Try
                BinVote.Process(task.Streams, output, AddressOf ProgressUpdatedHandler)
            Catch ex As Exception
                Console.WriteLine("Error: {0}", ex.ToString())
            End Try
            output.Close()
            For Each s In task.Streams
                s.Close()
            Next
        Else
            Console.WriteLine("Nothing to do!")
            Console.WriteLine("Please, pass at least 3 input files as arguments!")
        End If
        Console.WriteLine(vbCrLf + "All Done!")
    End Sub
End Module
