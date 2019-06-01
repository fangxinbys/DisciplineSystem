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
    public partial class TaskSaveList : PageBase
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
            int dptId = GetIdentityUser().dptId;


            Maticsoft.BLL.tTask BLL = new Maticsoft.BLL.tTask();
            string sortField = GridDpt.SortField;
            string sortDirection = GridDpt.SortDirection;
            string where = " IsCheck='已审核' ";


            if (drpSearch.SelectedValue == "")
            {
                where += string.Format(" and Id in (select TaskId from v_task_save where DptId={0}) ", dptId);
            }
            else if (drpSearch.SelectedValue == "已上报")
            {
                where += string.Format(" and Id in (select TaskId from v_task_save where DptId={0} and SavaDpt={1}) ", dptId, dptId);
            }
            else
            {
                where += string.Format(" and Id in (select TaskId from v_task_save where DptId={0} and SavaDpt is null) ", dptId);
            }


            if (txtValue.Text.Trim() != "")
            {
                where += " and (Title like '%" + txtValue.Text.Trim() + "%') or (TaskLevel like '%" + txtValue.Text.Trim() + "%') ";
            }


            GridDpt.RecordCount = BLL.GetRecordCount(where);
            DataView view = BLL.GetListByPage(where, " SaveTime desc ", GridDpt.PageIndex * GridDpt.PageSize, (GridDpt.PageIndex + 1) * GridDpt.PageSize).Tables[0].DefaultView;
            view.Sort = String.Format("{0} {1}", sortField, sortDirection);
            GridDpt.DataSource = view.ToTable();

            GridDpt.DataBind();

        }
        protected void drpSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        protected void TreeDpt_NodeCommand(object sender, TreeCommandEventArgs e)
        {
            LoadData();
        }

        protected void GridDpt_RowCommand(object sender, GridCommandEventArgs e)
        {

            int roleID = GetSelectedDataKeyID(GridDpt);

            if (e.CommandName == "Edit")
            {
              
                string openUrl = String.Format("./TaskSaveEdit.aspx?Id={0}", HttpUtility.UrlEncode(roleID.ToString()));
                PageContext.RegisterStartupScript(Window1.GetSaveStateReference(roleID.ToString()) + Window1.GetShowReference(openUrl, "即时上报"));
            }

        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {

            txtValue.Text = "";
            LoadData();
        }
        protected void GridDpt_Sort(object sender, GridSortEventArgs e)
        {
            LoadData();
        }


        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            Alert.ShowInTop("保存成功");

            LoadData();
        }

        protected void GridDpt_PreRowDataBound(object sender, GridPreRowEventArgs e)
        {
            // 如果绑定到 DataTable，那么这里的 DataItem 就是 DataRowView
            DataRowView row = e.DataItem as DataRowView;

            string TaskLevel = row["TaskLevel"].ToString();
            FineUIPro.BoundField bfEntranceYear = GridDpt.FindColumn("TaskLevel") as FineUIPro.BoundField;

            // 首先清空 data-color 属性
            bfEntranceYear.Attributes.Remove("data-color");

            // 然后添加 data-color 属性
            if (TaskLevel == "普通")
            {
                bfEntranceYear.Attributes["data-color"] = "color1";
            }
            else if (TaskLevel == "紧急")
            {
                bfEntranceYear.Attributes["data-color"] = "color2";

            }
            else
            {
                bfEntranceYear.Attributes["data-color"] = "color3";

            }
        }
        BLL.tTaskSave bllsave = new BLL.tTaskSave();
        protected string GetIsSave(string state)
        {
            int dptId = GetIdentityUser().dptId;
            List<Model.tTaskSave> list = bllsave.GetModelList(string.Format(" TaskId={0} and SavaDpt={1} ", int.Parse(state), dptId));
            if (list.Count==0)
            {
                return "<span style=\"color:red\" > 未上报</span>";
            }
            else
            {
                return "<span style=\"color:green\">已上报</span>";
            }
        }

    }
}