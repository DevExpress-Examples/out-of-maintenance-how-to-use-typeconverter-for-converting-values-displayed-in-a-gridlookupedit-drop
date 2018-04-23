using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using System.Drawing;

namespace DXSample {

    public class MyPointConverter: System.ComponentModel.TypeConverter {
       
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType) {
            if(sourceType == typeof(Point))
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
            return base.ConvertTo(context, culture, value, destinationType);//
        }
    }


}