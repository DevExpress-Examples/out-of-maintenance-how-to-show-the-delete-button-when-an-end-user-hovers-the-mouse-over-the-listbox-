Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports System.Windows.Forms
Imports System.Drawing
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors.ViewInfo

Namespace DeleteItemFromListBox
	Public Class DeleteHelper
		Private _list As ListBoxControl
		Private itemIndex As Integer = -1
		Private repository As RepositoryItemButtonEdit
		Private editorButton As EditorButton
		Private size As Integer = 18
		Private state As ObjectState

		Public Sub New(ByVal list As ListBoxControl)
			_list = list
			AddHandler _list.MouseMove, AddressOf _MouseMove
			AddHandler _list.DrawItem, AddressOf _DrawItem
			AddHandler _list.MouseClick, AddressOf _MouseClick
			AddHandler _list.MouseDown, AddressOf _MouseDown
			_list.ItemHeight = size + 1
			repository = New RepositoryItemButtonEdit()
			repository.Buttons.Clear()
			editorButton = New EditorButton(ButtonPredefines.Close)
			repository.Buttons.Add(editorButton)
			repository.TextEditStyle = TextEditStyles.HideTextEditor
			repository.BorderStyle = BorderStyles.NoBorder
		End Sub

		Private Sub _MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
			If itemIndex < 0 Then
				Return
			End If
			If IsButton(e.Location) Then
				state = ObjectState.Pressed
				Redraw()
			End If
		End Sub

		Private Sub _MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
			If itemIndex < 0 Then
				Return
			End If
			If IsButton(e.Location) Then
				_list.Items.RemoveAt(itemIndex)
			End If
		End Sub

		Private Sub DrawButton(ByVal e As ListBoxDrawItemEventArgs)
			Dim bounds As Rectangle = GetRectangle(e.Bounds)
			Dim buttonEditViewInfo As ButtonEditViewInfo = CType(repository.CreateViewInfo(), ButtonEditViewInfo)
			buttonEditViewInfo.Bounds = bounds
			buttonEditViewInfo.CalcViewInfo(e.Graphics)
			Dim buttonInfoByButton As DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs = buttonEditViewInfo.ButtonInfoByButton(editorButton)
			buttonInfoByButton.State = state
			Dim info As New DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(buttonEditViewInfo, e.Cache, bounds)
			repository.CreatePainter().Draw(info)
		End Sub

		Private Shared Sub DrawContent(ByVal e As ListBoxDrawItemEventArgs)
			e.Appearance.FillRectangle(e.Cache, e.Bounds)
			Dim textRect As Rectangle = Rectangle.Inflate(e.Bounds, -2, 0)
			e.Appearance.DrawString(e.Cache, e.Item.ToString(), textRect)
		End Sub

		Private Sub _DrawItem(ByVal sender As Object, ByVal e As ListBoxDrawItemEventArgs)
			If itemIndex < 0 OrElse e.Index <> itemIndex Then
				Return
			End If
			DrawContent(e)
			DrawButton(e)
			e.Handled = True
		End Sub

		Private Sub _MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			Dim newIndex As Integer = _list.IndexFromPoint(e.Location)
			If itemIndex >= 0 Then
				Redraw()
			End If
			itemIndex = newIndex
			If itemIndex < 0 Then
				Return
			End If
			If IsButton(e.Location) Then
				state = ObjectState.Hot
			Else
				state = ObjectState.Normal
			End If
			Redraw()
		End Sub

		Private Function GetRectangle(ByVal source As Rectangle) As Rectangle
			Dim result As Rectangle = source
			result.X = source.Right - size
			result.Width = size
			result.Height = size
			Return result
		End Function

		Private Sub Redraw()
			_list.Invalidate(_list.GetItemRectangle(itemIndex - 1))
			_list.Invalidate(_list.GetItemRectangle(itemIndex))
		End Sub

		Private Function IsButton(ByVal p As Point) As Boolean
			Return GetRectangle(_list.GetItemRectangle(itemIndex)).Contains(p)
		End Function
	End Class
End Namespace
