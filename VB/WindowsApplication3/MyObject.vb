Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports System.Drawing
Imports System.ComponentModel

Namespace DXSample
	Public Class MyObject
		Private id_Renamed As Integer
		Private text_Renamed As String
		Private point_Renamed As Point

		Public Sub New(ByVal id As Integer, ByVal text As String, ByVal point As Point)
			Me.id_Renamed = id
			Me.text_Renamed = text
			Me.point_Renamed = point
		End Sub

		Public Property ID() As Integer
			Get
				Return id_Renamed
			End Get
			Set(ByVal value As Integer)
				id_Renamed = value
			End Set
		End Property

		Public Property Text() As String
			Get
				Return text_Renamed
			End Get
			Set(ByVal value As String)
				text_Renamed = value
			End Set
		End Property

		<TypeConverter(GetType(MyPointConverter))> _
		Public Property Point() As Point
			Get
				Return point_Renamed
			End Get
			Set(ByVal value As Point)
				point_Renamed = value
			End Set
		End Property
	End Class
End Namespace