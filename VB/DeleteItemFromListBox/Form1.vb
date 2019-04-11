Imports DevExpress.XtraEditors

Namespace DeleteItemFromListBox
	Partial Public Class Form1
		Inherits XtraForm

		Public Sub New()
			InitializeComponent()

			For i As Integer = 0 To 9
				listBoxControl1.Items.Add("Click the context button to delete this record " & i)
			Next i

			AddHandler listBoxControl1.ContextButtonClick, AddressOf ListBoxControl1_ContextButtonClick
		End Sub

		Private Sub ListBoxControl1_ContextButtonClick(ByVal sender As Object, ByVal e As DevExpress.Utils.ContextItemClickEventArgs)
			Dim listBoxControl = TryCast(sender, ListBoxControl)
			listBoxControl.Items.Remove(e.DataItem)
		End Sub
	End Class
End Namespace
