Namespace DeleteItemFromListBox
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim simpleContextButton1 As New DevExpress.Utils.SimpleContextButton()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
			Me.listBoxControl1 = New DevExpress.XtraEditors.ListBoxControl()
			CType(Me.listBoxControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' listBoxControl1
			' 
			Me.listBoxControl1.ContextButtonOptions.AnimationTime = 10
			simpleContextButton1.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center
			simpleContextButton1.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far
			simpleContextButton1.Id = New System.Guid("52771939-cb13-4bfe-b442-085e3fa45e2d")
			simpleContextButton1.ImageOptions.SvgImage = (CType(resources.GetObject("resource.SvgImage"), DevExpress.Utils.Svg.SvgImage))
			simpleContextButton1.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
			simpleContextButton1.Name = "simpleContextButton1"
			Me.listBoxControl1.ContextButtons.Add(simpleContextButton1)
			Me.listBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.listBoxControl1.Location = New System.Drawing.Point(0, 0)
			Me.listBoxControl1.Name = "listBoxControl1"
			Me.listBoxControl1.Size = New System.Drawing.Size(287, 261)
			Me.listBoxControl1.TabIndex = 0
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(287, 261)
			Me.Controls.Add(Me.listBoxControl1)
			Me.Name = "Form1"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "E3397 - DevExpress"
			CType(Me.listBoxControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private listBoxControl1 As DevExpress.XtraEditors.ListBoxControl
	End Class
End Namespace