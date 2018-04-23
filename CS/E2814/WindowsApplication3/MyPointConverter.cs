// Developer Express Code Central Example:
// How to use TypeConverter for converting values displayed in a LookUpEdit dropdown
// 
// LookUpEdit does not support this functionality. However, you can accomplish this
// task by creating an unbound column
// (ms-help://DevExpress.NETv10.2/DevExpress.WindowsForms/CustomDocument1477.htm)
// and by using GridLookUpEdit
// (ms-help://DevExpress.NETv10.2/DevExpress.WindowsForms/clsDevExpressXtraEditorsGridLookUpEdittopic.htm)
// instead. This example illustrates how it can be done.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2814

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using System.Drawing;

namespace DXSample {

    public class MyPointConverter: System.ComponentModel.TypeConverter {
       
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) {
            if (sourceType == typeof(Point))
                return true;
            else
                return base.CanConvertFrom(context, sourceType);
        }

          public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value) {
              if(value is Point) {
                  Point point = (Point)value;
                  return string.Format("MyPoint ({0}, {1})", point.X, point.Y);
              }
              else
                  return base.ConvertFrom(context, culture, value);  
        }

        public override bool CanConvertTo(System.ComponentModel.ITypeDescriptorContext context, Type destinationType) {

            return base.CanConvertTo(context, destinationType);//
        }

        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType) {

            return base.ConvertTo(context, culture, value, destinationType);
         
        }
    }


}