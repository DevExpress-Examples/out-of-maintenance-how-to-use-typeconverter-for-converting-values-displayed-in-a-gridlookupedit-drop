using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using System.Drawing;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Reflection;
using System.Collections.ObjectModel;
using DevExpress.XtraEditors.Repository;
using System.Collections;

namespace DXSample {
    public class TypeConverterHelper {
        RepositoryItemGridLookUpEdit edit;
        string unboundColumnFieldName = "UnboundColumn",
            convertedProperty = string.Empty;

        public TypeConverterHelper(RepositoryItemGridLookUpEdit edit, string unboundColumnFieldName,
            string convertedProperty){
            this.edit = edit;
            this.unboundColumnFieldName = unboundColumnFieldName;
            this.convertedProperty = convertedProperty;

            CreateUnboundColumn(edit.View, unboundColumnFieldName);
           
        }

        void SubscribeToEvents() {
            edit.View.CustomUnboundColumnData += OnCustomUnboundColumnData;
        }

        private void CreateUnboundColumn(GridView view, string unboundColumnFieldName) {
            edit.View.PopulateColumns();
            GridColumn originColumn = view.Columns[convertedProperty];
            if (originColumn != null)
            {
                originColumn.Visible = false;
                GridColumn column = view.Columns.AddField(unboundColumnFieldName);
                column.UnboundType = DevExpress.Data.UnboundColumnType.Object;
                column.VisibleIndex = view.VisibleColumns.Count;
                SubscribeToEvents();
            }
        }

        void OnCustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e) {
             if(e.Column.FieldName == unboundColumnFieldName) {
                 if(e.IsGetData) {
                     IList dataSource = edit.DataSource as IList;
                     object obj = dataSource[e.ListSourceRowIndex];
                     if (obj == null) return;
                     PropertyDescriptor descriptor = TypeDescriptor.GetProperties(obj.GetType())[convertedProperty];
                     if(descriptor == null) return;
                     object value = descriptor.GetValue(obj);
                     TypeConverter converter = descriptor.Converter;
                     if(converter != null && converter.CanConvertFrom(value.GetType()))
                         e.Value = converter.ConvertFrom(value);
                 }
             }
        }

        void UnsubcribeFromEvents() {
            edit.View.CustomUnboundColumnData -= OnCustomUnboundColumnData;
        }

        public void RemoveUnboundColumn()
        {
            GridColumn column = edit.View.Columns[unboundColumnFieldName];
            GridColumn originColumn = edit.View.Columns[convertedProperty];
            if (column != null && originColumn != null)
            {
                edit.View.Columns.Remove(column);
                originColumn.Visible = true;
                UnsubcribeFromEvents();
            }
        }
    }
}
    