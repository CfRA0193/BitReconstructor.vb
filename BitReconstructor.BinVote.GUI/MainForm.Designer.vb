<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits Bwl.Framework.FormAppBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me._processingGroupBox = New System.Windows.Forms.GroupBox()
        Me._processButton = New System.Windows.Forms.Button()
        Me._processProgressBar = New System.Windows.Forms.ProgressBar()
        Me._checkUpTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FileSelector6 = New BitReconstructor.BinVote.GUI.FileSelector()
        Me.FileSelector5 = New BitReconstructor.BinVote.GUI.FileSelector()
        Me.FileSelector4 = New BitReconstructor.BinVote.GUI.FileSelector()
        Me.FileSelector3 = New BitReconstructor.BinVote.GUI.FileSelector()
        Me.FileSelector2 = New BitReconstructor.BinVote.GUI.FileSelector()
        Me.FileSelector1 = New BitReconstructor.BinVote.GUI.FileSelector()
        Me._processingGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'logWriter
        '
        Me.logWriter.Location = New System.Drawing.Point(-1, 414)
        Me.logWriter.Size = New System.Drawing.Size(1050, 246)
        Me.logWriter.TabIndex = 7
        '
        '_processingGroupBox
        '
        Me._processingGroupBox.Controls.Add(Me._processButton)
        Me._processingGroupBox.Controls.Add(Me._processProgressBar)
        Me._processingGroupBox.Enabled = False
        Me._processingGroupBox.Location = New System.Drawing.Point(12, 351)
        Me._processingGroupBox.Name = "_processingGroupBox"
        Me._processingGroupBox.Size = New System.Drawing.Size(1024, 49)
        Me._processingGroupBox.TabIndex = 6
        Me._processingGroupBox.TabStop = False
        Me._processingGroupBox.Text = "Processing / Обработка"
        '
        '_processButton
        '
        Me._processButton.Enabled = False
        Me._processButton.Location = New System.Drawing.Point(6, 19)
        Me._processButton.Name = "_processButton"
        Me._processButton.Size = New System.Drawing.Size(72, 23)
        Me._processButton.TabIndex = 1
        Me._processButton.Text = "Go / Старт"
        Me._processButton.UseVisualStyleBackColor = True
        '
        '_processProgressBar
        '
        Me._processProgressBar.Enabled = False
        Me._processProgressBar.Location = New System.Drawing.Point(84, 19)
        Me._processProgressBar.Name = "_processProgressBar"
        Me._processProgressBar.Size = New System.Drawing.Size(933, 23)
        Me._processProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me._processProgressBar.TabIndex = 0
        '
        '_checkUpTimer
        '
        Me._checkUpTimer.Enabled = True
        Me._checkUpTimer.Interval = 1000
        '
        'FileSelector6
        '
        Me.FileSelector6.Filename = ""
        Me.FileSelector6.InputSize = 0
        Me.FileSelector6.InUse = False
        Me.FileSelector6.Location = New System.Drawing.Point(12, 297)
        Me.FileSelector6.Name = "FileSelector6"
        Me.FileSelector6.Number = 0
        Me.FileSelector6.Size = New System.Drawing.Size(1024, 48)
        Me.FileSelector6.TabIndex = 5
        Me.FileSelector6.ToUse = False
        Me.FileSelector6.WriteMode = True
        '
        'FileSelector5
        '
        Me.FileSelector5.Filename = ""
        Me.FileSelector5.InputSize = 0
        Me.FileSelector5.InUse = False
        Me.FileSelector5.Location = New System.Drawing.Point(12, 243)
        Me.FileSelector5.Name = "FileSelector5"
        Me.FileSelector5.Number = 5
        Me.FileSelector5.Size = New System.Drawing.Size(1024, 48)
        Me.FileSelector5.TabIndex = 4
        Me.FileSelector5.ToUse = False
        Me.FileSelector5.WriteMode = False
        '
        'FileSelector4
        '
        Me.FileSelector4.Filename = ""
        Me.FileSelector4.InputSize = 0
        Me.FileSelector4.InUse = False
        Me.FileSelector4.Location = New System.Drawing.Point(12, 189)
        Me.FileSelector4.Name = "FileSelector4"
        Me.FileSelector4.Number = 4
        Me.FileSelector4.Size = New System.Drawing.Size(1024, 48)
        Me.FileSelector4.TabIndex = 3
        Me.FileSelector4.ToUse = False
        Me.FileSelector4.WriteMode = False
        '
        'FileSelector3
        '
        Me.FileSelector3.Filename = ""
        Me.FileSelector3.InputSize = 0
        Me.FileSelector3.InUse = False
        Me.FileSelector3.Location = New System.Drawing.Point(12, 135)
        Me.FileSelector3.Name = "FileSelector3"
        Me.FileSelector3.Number = 3
        Me.FileSelector3.Size = New System.Drawing.Size(1024, 48)
        Me.FileSelector3.TabIndex = 2
        Me.FileSelector3.ToUse = False
        Me.FileSelector3.WriteMode = False
        '
        'FileSelector2
        '
        Me.FileSelector2.Filename = ""
        Me.FileSelector2.InputSize = 0
        Me.FileSelector2.InUse = False
        Me.FileSelector2.Location = New System.Drawing.Point(12, 81)
        Me.FileSelector2.Name = "FileSelector2"
        Me.FileSelector2.Number = 2
        Me.FileSelector2.Size = New System.Drawing.Size(1024, 48)
        Me.FileSelector2.TabIndex = 1
        Me.FileSelector2.ToUse = False
        Me.FileSelector2.WriteMode = False
        '
        'FileSelector1
        '
        Me.FileSelector1.Filename = ""
        Me.FileSelector1.InputSize = 0
        Me.FileSelector1.InUse = False
        Me.FileSelector1.Location = New System.Drawing.Point(12, 27)
        Me.FileSelector1.Name = "FileSelector1"
        Me.FileSelector1.Number = 1
        Me.FileSelector1.Size = New System.Drawing.Size(1024, 48)
        Me.FileSelector1.TabIndex = 0
        Me.FileSelector1.ToUse = False
        Me.FileSelector1.WriteMode = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1048, 661)
        Me.Controls.Add(Me._processingGroupBox)
        Me.Controls.Add(Me.FileSelector6)
        Me.Controls.Add(Me.FileSelector5)
        Me.Controls.Add(Me.FileSelector4)
        Me.Controls.Add(Me.FileSelector3)
        Me.Controls.Add(Me.FileSelector2)
        Me.Controls.Add(Me.FileSelector1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BitReconstructor.BinVote.GUI"
        Me.Controls.SetChildIndex(Me.logWriter, 0)
        Me.Controls.SetChildIndex(Me.FileSelector1, 0)
        Me.Controls.SetChildIndex(Me.FileSelector2, 0)
        Me.Controls.SetChildIndex(Me.FileSelector3, 0)
        Me.Controls.SetChildIndex(Me.FileSelector4, 0)
        Me.Controls.SetChildIndex(Me.FileSelector5, 0)
        Me.Controls.SetChildIndex(Me.FileSelector6, 0)
        Me.Controls.SetChildIndex(Me._processingGroupBox, 0)
        Me._processingGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FileSelector1 As BitReconstructor.BinVote.GUI.FileSelector
    Friend WithEvents FileSelector2 As BitReconstructor.BinVote.GUI.FileSelector
    Friend WithEvents FileSelector3 As BitReconstructor.BinVote.GUI.FileSelector
    Friend WithEvents FileSelector4 As BitReconstructor.BinVote.GUI.FileSelector
    Friend WithEvents FileSelector5 As BitReconstructor.BinVote.GUI.FileSelector
    Friend WithEvents FileSelector6 As BitReconstructor.BinVote.GUI.FileSelector
    Friend WithEvents _processingGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents _processButton As System.Windows.Forms.Button
    Friend WithEvents _processProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents _checkUpTimer As System.Windows.Forms.Timer

End Class
