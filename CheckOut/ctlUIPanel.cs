using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentCheckOut
{
    public partial class ctlUIPanel : UserControl
    {
        private int folderID = 0;
        public int CurrentUserID = 0;

        private enum ActionButtons
        {
            AddNew = 1,
            Edit = 2,
            Export = 3
        }

        public ctlUIPanel()
        {
            InitializeComponent();
        }
        
        public int FolderID
        {
            get { return folderID; }
            set 
            { 
                folderID = value;
            }
        }

        public virtual void AddNew()
        {
        }

        public virtual void EditItem()
        {
        }

        public virtual void ExportItem()
        {
        }

        public virtual void RefreshList()
        {
        }

        public virtual bool AllowEdit(int FolderID)
        {
            return AllowAction(ActionButtons.Edit, FolderID);
        }

        public virtual bool AllowNew(int FolderID)
        {
            return AllowAction(ActionButtons.AddNew, FolderID);
        }

        public virtual bool AllowExport(int FolderID)
        {
            return AllowAction(ActionButtons.Export, FolderID);
        }

        private bool AllowAction(ActionButtons Action, int folderId)
        {
            return new CFolderPermissions().FolderActionByUser(CurrentUserID, folderId, (int)Action);
            //bool ret = false;
            //using (DataTable fp = new CFolderPermissions().FoldersByUser(CurrentUserID, false))
            //{
            //    foreach (DataRow frow in fp.Rows)
            //    {
            //        if ((int)frow["ID"] == folderId)
            //        {
            //            using (DataTable bp = new CButtonPermissions().ButtonsByFolderPermissionID((int)frow["PermissionID"]))
            //            {
            //                foreach (DataRow brow in bp.Rows)
            //                {
            //                    if ((int)brow["ID"] == (int)Action)
            //                    {
            //                        ret = true;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //return ret;
        }
    }
}
