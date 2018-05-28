using Xtrim_ERP.RichTextEditor.AppMenuTabs.Items;
using System;
using System.Drawing;
using Xtrim_ERP.Properties;

namespace Xtrim_ERP.RichTextEditor.AppMenuTabs
{
    public partial class OpenTab : AppMenuTabFileList
    {
        public OpenTab()
        {
            Button.ItemImage = Resources.Open_Large;
            Button.ItemText = Resources.Browse_txt;
            Caption = GetElementText(Resources.OpenTab_txt);
        }

        #region override
        protected override void OnMenuItemClick(AppMenuTabItem mi)
        {
            var ribbon = (C1TextEditorRibbon)RibbonApplicationMenu.Ribbon;
            ribbon.OpenDocument(System.IO.Path.Combine(mi.Item.SubText, mi.Item.Text));
            mi.Item.Date = DateTime.Now;
        }

        protected override void OnMenuButtonClick()
        {
            var ribbon = (C1TextEditorRibbon)RibbonApplicationMenu.Ribbon;
            ribbon.OpenDocument();
        }
        #endregion        
    }
}
