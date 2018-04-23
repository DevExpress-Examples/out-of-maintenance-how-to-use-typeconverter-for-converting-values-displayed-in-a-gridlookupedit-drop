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
Namespace DXSample
	Partial Public Class Main
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
			Me.components = New System.ComponentModel.Container()
			Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.gridLookUpEdit1 = New DevExpress.XtraEditors.GridLookUpEdit()
			Me.gridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' defaultLookAndFeel1
			' 
			Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins"
			' 
			' gridControl1
			' 
			Me.gridControl1.Location = New System.Drawing.Point(33, 76)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(691, 353)
			Me.gridControl1.TabIndex = 1
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			' 
			' gridLookUpEdit1
			' 
			Me.gridLookUpEdit1.Location = New System.Drawing.Point(33, 30)
			Me.gridLookUpEdit1.Name = "gridLookUpEdit1"
			Me.gridLookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.gridLookUpEdit1.Properties.View = Me.gridLookUpEdit1View
			Me.gridLookUpEdit1.Size = New System.Drawing.Size(323, 20)
			Me.gridLookUpEdit1.TabIndex = 2
			' 
			' gridLookUpEdit1View
			' 
			Me.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
			Me.gridLookUpEdit1View.Name = "gridLookUpEdit1View"
			Me.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
			Me.gridLookUpEdit1View.OptionsView.ShowGroupPanel = False
			' 
			' Main
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(771, 441)
			Me.Controls.Add(Me.gridLookUpEdit1)
			Me.Controls.Add(Me.gridControl1)
			Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
			Me.Name = "Main"
			Me.Text = "MyPointConverter"
'			Me.Load += New System.EventHandler(Me.OnFormLoad);
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private gridLookUpEdit1 As DevExpress.XtraEditors.GridLookUpEdit
		Private gridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
	End Class
End Namespace

