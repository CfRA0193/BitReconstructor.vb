<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileSelector
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me._fileGroupBox = New System.Windows.Forms.GroupBox()
        Me._inUseCheckBox = New System.Windows.Forms.CheckBox()
        Me._inputSizeTextBox = New System.Windows.Forms.TextBox()
        Me._selectButton = New System.Windows.Forms.Button()
        Me._fileTextBox = New System.Windows.Forms.TextBox()
        Me._toUseCheckBox = New System.Windows.Forms.CheckBox()
        Me._fileGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        '_fileGroupBox
        '
        Me._fileGroupBox.Controls.Add(Me._inUseCheckBox)
        Me._fileGroupBox.Controls.Add(Me._inputSizeTextBox)
        Me._fileGroupBox.Controls.Add(Me._selectButton)
        Me._fileGroupBox.Controls.Add(Me._fileTextBox)
        Me._fileGroupBox.Controls.Add(Me._toUseCheckBox)
        Me._fileGroupBox.Location = New System.Drawing.Point(1, 1)
        Me._fileGroupBox.Name = "_fileGroupBox"
        Me._fileGroupBox.Size = New System.Drawing.Size(1023, 45)
        Me._fileGroupBox.TabIndex = 0
        Me._fileGroupBox.TabStop = False
        '
        '_inUseCheckBox
        '
        Me._inUseCheckBox.AutoCheck = False
        Me._inUseCheckBox.AutoSize = True
        Me._inUseCheckBox.Location = New System.Drawing.Point(886, -1)
        Me._inUseCheckBox.Name = "_inUseCheckBox"
        Me._inUseCheckBox.Size = New System.Drawing.Size(97, 17)
        Me._inUseCheckBox.TabIndex = 3
        Me._inUseCheckBox.Text = "[ Input / Вход ]"
        Me._inUseCheckBox.UseVisualStyleBackColor = True
        '
        '_inputSizeTextBox
        '
        Me._inputSizeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._inputSizeTextBox.Location = New System.Drawing.Point(886, 16)
        Me._inputSizeTextBox.Name = "_inputSizeTextBox"
        Me._inputSizeTextBox.ReadOnly = True
        Me._inputSizeTextBox.Size = New System.Drawing.Size(131, 20)
        Me._inputSizeTextBox.TabIndex = 4
        '
        '_selectButton
        '
        Me._selectButton.Location = New System.Drawing.Point(6, 15)
        Me._selectButton.Name = "_selectButton"
        Me._selectButton.Size = New System.Drawing.Size(40, 22)
        Me._selectButton.TabIndex = 1
        Me._selectButton.Text = ">>"
        Me._selectButton.UseVisualStyleBackColor = True
        '
        '_fileTextBox
        '
        Me._fileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me._fileTextBox.Location = New System.Drawing.Point(52, 16)
        Me._fileTextBox.Name = "_fileTextBox"
        Me._fileTextBox.Size = New System.Drawing.Size(828, 20)
        Me._fileTextBox.TabIndex = 2
        '
        '_toUseCheckBox
        '
        Me._toUseCheckBox.AutoSize = True
        Me._toUseCheckBox.Location = New System.Drawing.Point(52, -1)
        Me._toUseCheckBox.Name = "_toUseCheckBox"
        Me._toUseCheckBox.Size = New System.Drawing.Size(145, 17)
        Me._toUseCheckBox.TabIndex = 0
        Me._toUseCheckBox.Text = "[ Source / Источник ] №"
        Me._toUseCheckBox.UseVisualStyleBackColor = True
        '
        'FileSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me._fileGroupBox)
        Me.Name = "FileSelector"
        Me.Size = New System.Drawing.Size(1024, 48)
        Me._fileGroupBox.ResumeLayout(false)
        Me._fileGroupBox.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents _fileGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents _toUseCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents _fileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents _selectButton As System.Windows.Forms.Button
    Friend WithEvents _inputSizeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents _inUseCheckBox As System.Windows.Forms.CheckBox

End Class
