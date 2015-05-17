Imports System.Text
Imports System.Threading
Imports Bwl.Framework
Imports BitReconstructor.BinVote

Public Class MainForm
    Inherits FormAppBase

    Private Shadows _logger As Logger = AppBase.RootLogger
    Private Shadows _storage As SettingsStorage = AppBase.RootStorage

    Private _workerThread As Thread = Nothing
    Private _threadWorking As Boolean

    Private _outputNameSpecified As Boolean

    Private Sub MessageOutHandler(message As String, textColor As ConsoleColor)
        Select Case textColor
            Case ConsoleColor.Gray
                _logger.AddMessage(message)
            Case ConsoleColor.Green
                _logger.AddInformation(message)
            Case ConsoleColor.Yellow
                _logger.AddWarning(message)
            Case ConsoleColor.Red
                _logger.AddError(message)
        End Select
    End Sub

    Private Sub ProgressUpdatedHandler(progress As Single)
        Me.Invoke(Sub() _processProgressBar.Value = progress * 100.0F)
    End Sub

    Private Function GetArgs() As String()
        Dim args As New List(Of String)
        FileSelector1.Filename = FileSelector1.Filename.Trim()
        FileSelector2.Filename = FileSelector2.Filename.Trim()
        FileSelector3.Filename = FileSelector3.Filename.Trim()
        FileSelector4.Filename = FileSelector4.Filename.Trim()
        FileSelector5.Filename = FileSelector5.Filename.Trim()
        FileSelector6.Filename = FileSelector6.Filename.Trim()
        If FileSelector1.ToUse Then args.Add(FileSelector1.Filename)
        If FileSelector2.ToUse Then args.Add(FileSelector2.Filename)
        If FileSelector3.ToUse Then args.Add(FileSelector3.Filename)
        If FileSelector4.ToUse Then args.Add(FileSelector4.Filename)
        If FileSelector5.ToUse Then args.Add(FileSelector5.Filename)
        If FileSelector6.ToUse Then args.Add(FileSelector6.Filename) : _outputNameSpecified = True Else _outputNameSpecified = False
        Return args.ToArray()
    End Function

    Private Sub ProcessingThread()
        MessageOutHandler("{", ConsoleColor.Gray)
        If BinVote.Process(GetArgs(), _outputNameSpecified, AddressOf MessageOutHandler, AddressOf ProgressUpdatedHandler) Then
            MessageOutHandler("Processing: OK!", ConsoleColor.Gray)
        Else
            MessageOutHandler("Processing: ERROR!", ConsoleColor.Gray)
        End If
        MessageOutHandler("}", ConsoleColor.Gray)
        _threadWorking = False
    End Sub

    Private Sub _processButton_Click(sender As Object, e As EventArgs) Handles _processButton.Click
        If Not _threadWorking Then
            _workerThread = New Thread(AddressOf ProcessingThread)
            _threadWorking = True
            With _workerThread
                .Name = "BinVote.Process"
                .Priority = ThreadPriority.Lowest
                .IsBackground = True
                .Start()
            End With
            _logger.AddMessage("BinVote.Process")
        End If
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.Title.ToString() + " [" + My.Application.Info.Version.ToString() + "]"
    End Sub
End Class
