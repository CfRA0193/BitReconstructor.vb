Imports System.IO

Public Class FileSelector
    Private _writeMode As Boolean

    Public Property Filename As String
        Get
            Return _fileTextBox.Text
        End Get
        Set(value As String)
            _fileTextBox.Text = value
        End Set
    End Property

    Public Property ToUse As Boolean
        Get
            Return _toUseCheckBox.Checked
        End Get
        Set(value As Boolean)
            _toUseCheckBox.Checked = value
        End Set
    End Property

    Public Property WriteMode As Boolean
        Get
            Return _writeMode
        End Get
        Set(value As Boolean)
            _writeMode = value
            If value Then
                _toUseCheckBox.Text = "[ Target / Целевой ]"
            Else
                _toUseCheckBox.Text = String.Format("[ Source / Источник ] №{0}", Number)
            End If
        End Set
    End Property

    Public Property Number As Integer

    Public Sub New()
        InitializeComponent()
        WriteMode = False
        TrimFilenameAndRecolor()
    End Sub

    Public Sub SelectFile()
        If WriteMode Then
            Dim sfd = New SaveFileDialog
            With sfd
                .RestoreDirectory = True
                .AddExtension = True
                .DefaultExt = ".*"
                .Filter = "All files (*.*)|*.*"
            End With
            If sfd.ShowDialog() = DialogResult.OK Then
                _toUseCheckBox.Checked = True
                _fileTextBox.Text = sfd.FileName
            Else
                _toUseCheckBox.Checked = False
            End If
        Else
            Dim ofd = New OpenFileDialog
            With ofd
                .RestoreDirectory = True
                .AddExtension = True
                .DefaultExt = ".*"
                .Filter = "All files (*.*)|*.*"
            End With
            If ofd.ShowDialog() = DialogResult.OK Then
                _toUseCheckBox.Checked = True
                _fileTextBox.Text = ofd.FileName
            Else
                _toUseCheckBox.Checked = False
            End If
        End If
    End Sub

    Private Sub TrimFilenameAndRecolor()
        _fileTextBox.Text = _fileTextBox.Text.Trim()
        If _fileTextBox.Text = String.Empty Then
            _fileTextBox.BackColor = Color.AliceBlue
        Else
            If File.Exists(_fileTextBox.Text) Then
                _fileTextBox.BackColor = Color.DarkSeaGreen
            Else
                _fileTextBox.BackColor = Color.Salmon
            End If
        End If
    End Sub

    Private Sub _selectButton_Click(sender As Object, e As EventArgs) Handles _selectButton.Click
        SelectFile() : TrimFilenameAndRecolor()
    End Sub

    Private Sub _toUseCheckBox_Click(sender As Object, e As EventArgs) Handles _toUseCheckBox.Click
        TrimFilenameAndRecolor()
    End Sub

    Private Sub _fileTextBox_TextChanged(sender As Object, e As EventArgs) Handles _fileTextBox.TextChanged
        TrimFilenameAndRecolor()
    End Sub
End Class
