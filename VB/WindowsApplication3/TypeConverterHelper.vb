Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports System.Drawing
Imports System.ComponentModel
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports System.Reflection
Imports System.Collections.ObjectModel
Imports DevExpress.XtraEditors.Repository
Imports System.Collections

Namespace DXSample
	Public Class TypeConverterHelper
		Private edit As RepositoryItemGridLookUpEdit
		Private unboundColumnFieldName As String = "UnboundColumn", convertedProperty As String = String.Empty

		Public Sub New(ByVal edit As RepositoryItemGridLookUpEdit, ByVal unboundColumnFieldName As String, ByVal convertedProperty As String)
			Me.edit = edit
			Me.unboundColumnFieldName = unboundColumnFieldName
			Me.convertedProperty = convertedProperty

			CreateUnboundColumn(edit.View, unboundColumnFieldName)

		End Sub

		Private Sub SubscribeToEvents()
			AddHandler edit.View.CustomUnboundColumnData, AddressOf OnCustomUnboundColumnData
		End Sub

		Private Sub CreateUnboundColumn(ByVal view As GridView, ByVal unboundColumnFieldName As String)
			edit.View.PopulateColumns()
			Dim originColumn As GridColumn = view.Columns(convertedProperty)
			If originColumn IsNot Nothing Then
				originColumn.Visible = False
				Dim column As GridColumn = view.Columns.AddField(unboundColumnFieldName)
				column.UnboundType = DevExpress.Data.UnboundColumnType.Object
				column.VisibleIndex = view.VisibleColumns.Count
				SubscribeToEvents()
			End If
		End Sub

		Private Sub OnCustomUnboundColumnData(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
			 If e.Column.FieldName = unboundColumnFieldName Then
				 If e.IsGetData Then
					 Dim dataSource As IList = TryCast(edit.DataSource, IList)
					 Dim obj As Object = dataSource(e.ListSourceRowIndex)
					 If obj Is Nothing Then
						 Return
					 End If
					 Dim descriptor As PropertyDescriptor = TypeDescriptor.GetProperties(obj.GetType())(convertedProperty)
					 If descriptor Is Nothing Then
						 Return
					 End If
					 Dim value As Object = descriptor.GetValue(obj)
					 Dim converter As TypeConverter = descriptor.Converter
					 If converter IsNot Nothing AndAlso converter.CanConvertFrom(value.GetType()) Then
						 e.Value = converter.ConvertFrom(value)
					 End If
				 End If
			 End If
		End Sub

		Private Sub UnsubcribeFromEvents()
			RemoveHandler edit.View.CustomUnboundColumnData, AddressOf OnCustomUnboundColumnData
		End Sub

		Public Sub RemoveUnboundColumn()
			Dim column As GridColumn = edit.View.Columns(unboundColumnFieldName)
			Dim originColumn As GridColumn = edit.View.Columns(convertedProperty)
			If column IsNot Nothing AndAlso originColumn IsNot Nothing Then
				edit.View.Columns.Remove(column)
				originColumn.Visible = True
				UnsubcribeFromEvents()
			End If
		End Sub
	End Class
End Namespace
