Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms

Namespace DeleteItemFromListBox
	Friend Module Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Sub Main()
			DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.Bezier)
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Form1())
		End Sub
	End Module
End Namespace
