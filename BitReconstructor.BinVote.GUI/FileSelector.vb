Imports System.IO

Public Class FileSelector
    Private _writeMode As Boolean

    Public Property Filename As String
        Get
            Return _fileTextBox.Text
        End Get
        Set(value As String)
            _fileTextBox.Text = value : FilenameProcessing()
        End Set
    End Property

    Public Property ToUse As Boolean
        Get
            Return _toUseCheckBox.Checked
        End Get
        Set(value As Boolean)
            _toUseCheckBox.Checked = value : FilenameProcessing()
        End Set
    End Property

    Public Property InUse As Boolean
        Get
            Return _inUseCheckBox.Checked
        End Get
        Set(value As Boolean)
            _inUseCheckBox.Checked = value : If Not value Then FileSize = 0 : FilenameProcessing()
        End Set
    End Property

    Public Property FileSize As Integer
        Get
            _fileSizeTextBox.Text = _fileSizeTextBox.Text.Trim()
            Return If(_fileSizeTextBox.Text <> String.Empty, Convert.ToInt32(_fileSizeTextBox.Text), 0)
        End Get
        Set(value As Integer)
            _fileSizeTextBox.Text = If(value <> 0, value.ToString(), String.Empty)
        End Set
    End Property

    Public Property WriteMode As Boolean
        Get
            Return _writeMode
        End Get
        Set(value As Boolean)
            _writeMode = value
            _toUseCheckBox.Text = If(value, "[ Target / Целевой ]", String.Format("[ Source / Источник ] №{0}", Number))
            FilenameProcessing()
        End Set
    End Property

    Public Property Number As Integer

    Public Sub New()
        InitializeComponent() : WriteMode = False : FilenameProcessing()
    End Sub

    Public Sub SelectFile()
        If Not WriteMode Then
            Dim ofd = New OpenFileDialog
            With ofd
                .RestoreDirectory = True
                .AddExtension = True
                .DefaultExt = ".*"
                .Filter = "All files (*.*)|*.*"
            End With
            If ofd.ShowDialog() = DialogResult.OK Then
                _toUseCheckBox.Checked = True : _fileTextBox.Text = ofd.FileName
            Else
                _toUseCheckBox.Checked = False
            End If
        Else
            Dim sfd = New SaveFileDialog
            With sfd
                .RestoreDirectory = True
                .AddExtension = True
                .DefaultExt = ".*"
                .Filter = "All files (*.*)|*.*"
            End With
            If sfd.ShowDialog() = DialogResult.OK Then
                _toUseCheckBox.Checked = True : _fileTextBox.Text = sfd.FileName
            Else
                _toUseCheckBox.Checked = False
            End If
        End If
    End Sub

    Private Sub FilenameProcessing()
        If Not _toUseCheckBox.Checked Then _fileTextBox.Text = String.Empty : _fileTextBox.Text = _fileTextBox.Text.Trim()
        If Not _writeMode Then
            If _fileTextBox.Text = String.Empty Then
                _fileTextBox.BackColor = Color.AliceBlue
            Else
                If File.Exists(_fileTextBox.Text) Then
                    _fileTextBox.BackColor = If(_inUseCheckBox.Checked, Color.PaleGreen, Color.LemonChiffon) : FileSize = (New FileInfo(_fileTextBox.Text)).Length
                Else
                    _fileTextBox.BackColor = Color.Salmon : FileSize = 0
                End If
            End If
            _fileSizeTextBox.BackColor = _fileTextBox.BackColor
        Else
            If _fileTextBox.Text = String.Empty Then _toUseCheckBox.Checked = False
            _fileTextBox.BackColor = Color.PaleGreen : _fileSizeTextBox.BackColor = Me.BackColor : _inUseCheckBox.Enabled = False : _fileSizeTextBox.Enabled = False
        End If
    End Sub

    Private Sub _selectButton_Click(sender As Object, e As EventArgs) Handles _selectButton.Click
        SelectFile() : FilenameProcessing()
    End Sub

    Private Sub _toUseCheckBox_Click(sender As Object, e As EventArgs) Handles _toUseCheckBox.Click
        FilenameProcessing()
    End Sub

    Private Sub _fileTextBox_TextChanged(sender As Object, e As EventArgs) Handles _fileTextBox.TextChanged
        FilenameProcessing()
    End Sub
End Class
