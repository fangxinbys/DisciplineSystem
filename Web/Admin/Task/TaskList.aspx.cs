using FineUIPro;
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace Maticsoft.Web.Admin.Task
{
    public partial class TaskList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            
                LoadData();

            }
        }

        protected void GridDpt_PageIndexChange(object sender, FineUIPro.GridPageEventArgs e)
        {
            LoadData();
        }
       
        protected void LoadData()
        {
            string dptList = GetChildrenBySelft();


            Maticsoft.BLL.tTask BLL = new Maticsoft.BLL.tTask();
            string sortField = GridDpt.SortField;
            string sortDirection = GridDpt.SortDirection;
     
           
                GridDpt.RecordCount = BLL.GetRecordCount(" SaveDpt in ("+dptList+") ");
                DataView view = BLL.GetListByPage(" SaveDpt in (" + dptList + ") ", " SaveTime desc ", GridDpt.PageIndex * GridDpt.PageSize, (GridDpt.PageIndex + 1) * GridDpt.PageSize).Tables[0].DefaultView;
                view.Sort = String.Format("{0} {1}", sortField, sortDirection);
                GridDpt.DataSource = view.ToTable();
          
            GridDpt.DataBind();

        }

        protected void TreeDpt_NodeCommand(object sender, TreeCommandEventArgs e)
        {
            LoadData();
        }

        protected void GridDpt_RowCommand(object sender, GridCommandEventArgs e)
        {

            int roleID = GetSelectedDataKeyID(GridDpt);


            if (e.CommandName == "Delete")
            {
                
                BLL.tTask BLL = new Maticsoft.BLL.tTask();

                if (BLL.GetModel(roleID).IsCheck == "已审核")
                {
                    Alert.ShowInTop("已经审核,无法删除！");
                    return;
                }
                bool isTrue = BLL.Delete(roleID);
                if (!isTrue)
                {
                    Alert.ShowInTop("删除失败！");
                    return;
                }
                else
                {
                    LoadData();
                }
            }
            else if (e.CommandName == "Check")
            {
                Model.tUsers user = GetIdentityUser();
                BLL.tTask BLL = new Maticsoft.BLL.tTask();

                if (!haveRight(user.userId, "及时任务审批"))
                {
                    Alert.ShowInTop("当前用户没有权限审批！");
                    return;
                }
                Model.tTask top = BLL.GetModel(roleID);

                if (top.IsCheck == "已审核")
                {
                    //if (top.IsCheckPeo != user.usersName)
                    //{
                    //    Alert.ShowInTop("当前用户没有权限审批！");
                    //    return;
                    //}
                    top.IsCheck = "待审核";
                    top.IsCheckPeo = null;
                    top.IsCheckTime = null;
                }
                else
                {

                    top.IsCheck = "已审核";
                    top.IsCheckPeo = user.usersName;
                    top.IsCheckTime = DateTime.Now;
                }


                bool isTrue = BLL.Update(top);
                if (!isTrue)
                {
                    Alert.ShowInTop("操作失败！");
                    return;
                }
                else
                {
                    LoadData();
                }
            }
            else if (e.CommandName == "Edit")
            {
                Window1.Title = "编辑任务";
                string openUrl = String.Format("./TaskEdit.aspx?Id={0}", HttpUtility.UrlEncode(roleID.ToString()));
                PageContext.RegisterStartupScript(Window1.GetSaveStateReference(roleID.ToString()) + Window1.GetShowReference(openUrl));
            }
            else
            {
               
            }

        }

        protected void GridDpt_Sort(object sender, GridSortEventArgs e)
        {
            LoadData();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Window1.Title = "编辑任务";
            PageContext.RegisterStartupScript(Window1.GetShowReference("./TaskEdit.aspx"));
        }

        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            Alert.ShowInTop("保存成功");
      
            LoadData();
        }

        protected void GridDpt_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;

            LinkButtonField checkField = GridDpt.FindColumn("checkField") as LinkButtonField;
            LinkButtonField editField = GridDpt.FindColumn("editField") as LinkButtonField;
            LinkButtonField deleteField = GridDpt.FindColumn("deleteField") as LinkButtonField;

            if (row["IsCheck"].ToString() == "已审核")
            {
                deleteField.Enabled = false;
                checkField.Text = "取消";
                checkField.Icon = Icon.Cancel;
                editField.Text = "查看";
                editField.Icon = Icon.Lock;
            }
            else
            {
                deleteField.Enabled = true;
                checkField.Text = "通过";
                checkField.Icon = Icon.Accept;
                editField.Text = "编辑";
                editField.Icon = Icon.Pencil;
            }
            if (!haveRight(GetIdentityUser().userId, "及时任务审批"))
            {
                checkField.Enabled = false;
            }
            else
            {
                checkField.Enabled = true;
            }
        }
    }
}