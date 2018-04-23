Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms

Namespace DeleteItemFromListBox
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			Dim TempDeleteHelper As DeleteHelper = New DeleteHelper(listBoxControl1)
		End Sub
	End Class
End Namespace
