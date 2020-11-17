using Syncfusion.DataSource;
using Syncfusion.DataSource.Extensions;
using Syncfusion.GridCommon.ScrollAxis;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class Behavior : Behavior<ContentPage>
    {
        #region Fields
        SfListView ListView;
        #endregion

        #region Overrides
        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = bindable.FindByName<SfListView>("listView");
            ListView.DataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "Group",
                KeySelector = (object obj1) =>
                {
                    var item = (obj1 as Contacts);
                    return item.Group;
                },
            });
            ListView.QueryItemSize += ListView_QueryItemSize;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            ListView.QueryItemSize -= ListView_QueryItemSize;
            ListView = null;
            base.OnDetachingFrom(bindable);
        }
        #endregion

        #region Call back
        private void ListView_QueryItemSize(object sender, QueryItemSizeEventArgs e)
        {
            if (e.ItemType == ItemType.Record && (e.ItemData as Contacts).ContactName == "")
            {
                e.ItemSize = 0;
                e.Handled = true;
            }
        }
        #endregion
    }
}