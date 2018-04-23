Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Ribbon.Helpers
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Columns
Imports System.Collections
Imports DevExpress.XtraEditors.Repository


Namespace DXSample
	Partial Public Class Main
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub

		Private list As BindingList(Of MyObject), gridList As BindingList(Of MyObject)
		Private helper As TypeConverterHelper
		Public Sub InitData()
			list = New BindingList(Of MyObject)()
			list.Add(New MyObject(1, "A", New Point(1, 1)))
			list.Add(New MyObject(2, "B", New Point(2, 3)))
			list.Add(New MyObject(3, "C", New Point(4, 5)))
			list.Add(New MyObject(4, "D", New Point(6, 7)))
			list.Add(New MyObject(5, "E", New Point(8, 9)))

			gridList = New BindingList(Of MyObject)()
			gridList.Add(New MyObject(1, "A", New Point(1, 1)))
			gridList.Add(New MyObject(2, "B", New Point(2, 3)))
			gridList.Add(New MyObject(3, "C", New Point(4, 5)))
		End Sub

		Private Sub OnFormLoad(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			InitData()
			Dim edit As New RepositoryItemGridLookUpEdit()
			gridControl1.RepositoryItems.Add(edit)
			SetUpEditor(edit)
			SetUpEditor(gridLookUpEdit1.Properties)

			gridControl1.DataSource = gridList
			gridControl1.ForceInitialize()

			gridView1.Columns("ID").ColumnEdit = edit
		End Sub

		Private Sub SetUpEditor(ByVal edit As RepositoryItemGridLookUpEdit)
			edit.DataSource = New BindingSource(list, "")
			edit.ValueMember = "ID"
			edit.DisplayMember = "Text"
			helper = New TypeConverterHelper(edit, "Unbound", "Point")
		End Sub

		Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
			MyBase.OnFormClosing(e)
			If helper IsNot Nothing Then
				helper.RemoveUnboundColumn()
			End If
		End Sub

	End Class

End Namespace
