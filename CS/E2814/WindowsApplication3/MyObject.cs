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
using System.ComponentModel;

namespace DXSample {
    public class MyObject {
        int id;
        string text;
        Point point;

        public MyObject(int id, string text, Point point) {
            this.id = id;
            this.text = text;
            this.point = point;
        }

        public int ID {
            get { return id; }
            set { id = value; }
        }

        public string Text {
            get { return text; }
            set { text = value; }
        }

        [TypeConverter(typeof(MyPointConverter))]
        public Point Point {
            get { return point; }
            set { point = value; }
        }
    }
}