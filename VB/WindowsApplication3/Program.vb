' Developer Express Code Central Example:
' How to use TypeConverter for converting values displayed in a LookUpEdit dropdown
' 
' LookUpEdit does not support this functionality. However, you can accomplish this
' task by creating an unbound column
' (ms-help://DevExpress.NETv10.2/DevExpress.WindowsForms/CustomDocument1477.htm)
' and by using GridLookUpEdit
' (ms-help://DevExpress.NETv10.2/DevExpress.WindowsForms/clsDevExpressXtraEditorsGridLookUpEdittopic.htm)
' instead. This example illustrates how it can be done.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2814


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.Skins

Namespace DXSample
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
			SkinManager.EnableFormSkins()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Main())
		End Sub
	End Class
End Namespace