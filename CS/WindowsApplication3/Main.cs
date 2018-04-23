using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using System.Collections;
using DevExpress.XtraEditors.Repository;


namespace DXSample {
    public partial class Main: XtraForm {
        public Main() {
            InitializeComponent();
        }

        BindingList<MyObject> list, gridList;
        TypeConverterHelper helper;
        public void InitData() {
            list = new BindingList<MyObject>();
            list.Add(new MyObject(1, "A", new Point(1, 1)));
            list.Add(new MyObject(2, "B", new Point(2, 3)));
            list.Add(new MyObject(3, "C", new Point(4, 5)));
            list.Add(new MyObject(4, "D", new Point(6, 7)));
            list.Add(new MyObject(5, "E", new Point(8, 9)));

            gridList = new BindingList<MyObject>();
            gridList.Add(new MyObject(1, "A", new Point(1, 1)));
            gridList.Add(new MyObject(2, "B", new Point(2, 3)));
            gridList.Add(new MyObject(3, "C", new Point(4, 5)));
        }
       
        private void OnFormLoad(object sender, EventArgs e) {
            InitData();
            RepositoryItemGridLookUpEdit edit = new RepositoryItemGridLookUpEdit();
            gridControl1.RepositoryItems.Add(edit);
            SetUpEditor(edit);
            SetUpEditor(gridLookUpEdit1.Properties);

            gridControl1.DataSource = gridList;
            gridControl1.ForceInitialize();

            gridView1.Columns["ID"].ColumnEdit = edit;
        }
       
        private void SetUpEditor(RepositoryItemGridLookUpEdit edit) {
            edit.DataSource = new BindingSource(list, "");
            edit.ValueMember = "ID";
            edit.DisplayMember = "Text";
            helper = new TypeConverterHelper(edit,
                "Unbound", "Point");
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if(helper != null)
                helper.RemoveUnboundColumn();
        }

    }
       
}
