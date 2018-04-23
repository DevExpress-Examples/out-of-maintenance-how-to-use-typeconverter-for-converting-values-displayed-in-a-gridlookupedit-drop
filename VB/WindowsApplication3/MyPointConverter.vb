Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports System.Drawing

Namespace DXSample

	Public Class MyPointConverter
		Inherits System.ComponentModel.TypeConverter

		Public Overrides Overloads Function CanConvertFrom(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal sourceType As System.Type) As Boolean
			If sourceType Is GetType(Point) Then
				Return True
			Else
				Return MyBase.CanConvertFrom(context, sourceType)
			End If
		End Function

		  Public Overrides Overloads Function ConvertFrom(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object) As Object
			  If TypeOf value Is Point Then
				  Dim point As Point = CType(value, Point)
				  Return String.Format("MyPoint ({0}, {1})", point.X, point.Y)
			  Else
				  Return MyBase.ConvertFrom(context, culture, value)
			  End If
		  End Function

		Public Overrides Overloads Function CanConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As Type) As Boolean
			Return MyBase.CanConvertTo(context, destinationType)
		End Function

		Public Overrides Overloads Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
			Return MyBase.ConvertTo(context, culture, value, destinationType)
		End Function
	End Class


End Namespace