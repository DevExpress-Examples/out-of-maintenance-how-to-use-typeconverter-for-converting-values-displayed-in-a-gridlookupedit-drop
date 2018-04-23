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