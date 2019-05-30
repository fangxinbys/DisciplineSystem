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
    public partial class TaskEdit : PageBase
    {
        BLL.tTask bll = new BLL.tTask();
 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
  
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
               
                DateTimeTop.SelectedDate = DateTime.Now;
                if (string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    int dptId = GetIdentityUser().dptId;
                    BindTree(dptId);

                }
                else
                {
                    string Id = Request.QueryString["Id"];

                    LoadData(Id);
                  
                }
         

            }
        }
        protected void BindTree(int dptId)
        {
            TreeDpt.Nodes.Clear();
            BLL.tMenu BLL = new BLL.tMenu();
          
            IDataParameter[] parameters = new IDataParameter[] { new SqlParameter("@dptId", dptId) };
            DataSet ds = DbHelperSQL.RunProcedure("GetChildrenDptTree", parameters, "dptTree");
            ds.Relations.Add("TreeRelation", ds.Tables[0].Columns["dptId"], ds.Tables[0].Columns["dptFatherId"], false);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["dptId"].ToString() == dptId.ToString())
                {
                    FineUIPro.TreeNode node = new FineUIPro.TreeNode();
                    node.NodeID = row["dptId"].ToString();
                    node.Text = row["dptName"].ToString();
                  
                    node.EnableCheckBox = true;
                    node.EnableCheckEvent = true;
                    TreeDpt.Nodes.Add(node);
                    ResolveSubTree(row, node);
                }
            }
        }
        private void ResolveSubTree(DataRow dataRow, FineUIPro.TreeNode treeNode)
        {
            DataRow[] rows = dataRow.GetChildRows("TreeRelation");
            if (rows.Length > 0)
            {
                // 如果是目录，则默认展开
                treeNode.Expanded = true;
                foreach (DataRow row in rows)
                {
                    FineUIPro.TreeNode node = new FineUIPro.TreeNode();
                    node.NodeID = row["dptId"].ToString();
                    node.Text = row["dptName"].ToString();
 
                    node.EnableCheckBox = true;
                    node.EnableCheckEvent = true;
                    treeNode.Nodes.Add(node);
                    ResolveSubTree(row, node);
                }
            }
        }

        protected void TreeDpt_NodeCheck(object sender, TreeCheckEventArgs e)
        {
            if (e.Checked)
            {


                TreeDpt.CheckAllNodes(e.Node.Nodes);
                if (TreeDpt.FindNode(e.NodeID).ParentNode == null) return;

                if (TreeDpt.FindNode(e.NodeID).ParentNode.Checked == false)
                {
                    TreeDpt.FindNode(e.NodeID).ParentNode.Checked = true;
                }
            }
            else
            {
                TreeDpt.UncheckAllNodes(e.Node.Nodes);
            }
        }
        protected void LoadData(string Id)
        {

            Model.tTask m = bll.GetModel(Convert.ToInt32(Id));
            if (m == null)
            {
                Alert.ShowInTop("出错了！"); return;
            }
            BindTree((int)m.SaveDpt);
            hfEditorInitValue2.Text = m.TaskContent;
            txtTitle.Text = m.Title;
            DateTimeTop.SelectedDate = m.SaveTime;
            DateTimeLock.SelectedDate = m.LockTime;
            drpSearch.SelectedValue = m.TaskLevel;
          
            if (m.IsCheck == "已审核")
            {
                btnSaveClose.Text = "已审核";
                btnSaveClose.Enabled = false;
            }

            string[] dptlist = m.LookDptString.Split(',');
            foreach (string str in dptlist)
            {
                TreeDpt.FindNode(str).Checked = true;
            }
 

        }



        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
        
            FineUIPro.TreeNode[] nodes = TreeDpt.GetCheckedNodes();


            if (nodes.Length <= 0)
            {
                Alert.ShowInTop("请选择接收单位！");
                return;
            }
            string dptlist = "";
            foreach (FineUIPro.TreeNode node in nodes)
            {
                dptlist += node.NodeID.ToString() +",";   
            }
            dptlist = dptlist.Substring(0, dptlist.Length - 1);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                string Id = Request.QueryString["Id"];
                Model.tTask m = bll.GetModel(Convert.ToInt32(Id));
                if (m == null) return;
                string content2 = Request.Form["editorNew2"] == null ? "" : Request.Form["editorNew2"];
                m.TaskContent = content2;
                m.Title = txtTitle.Text;
                m.SaveTime = DateTimeTop.SelectedDate;
                m.LockTime = DateTimeLock.SelectedDate;
                m.TaskLevel = drpSearch.SelectedValue;
                m.LookDptString = dptlist;
                if (bll.Update(m) == true)
                {
                    PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                }
                else
                {
                    Alert.ShowInTop("出错了！");
                }
            }
            else
            {
                Model.tTask m = new Model.tTask(); 
                string content2 = Request.Form["editorNew2"] == null ? "" : Request.Form["editorNew2"];
                m.TaskContent = content2;
                m.Title = txtTitle.Text;
                m.SaveTime = DateTimeTop.SelectedDate;
                m.LockTime = DateTimeLock.SelectedDate;
                m.TaskLevel = drpSearch.SelectedValue;
                m.LookDptString = dptlist;

                m.SavaPeo = GetIdentityUser().usersName;
                m.SaveDpt = GetIdentityUser().dptId;
                int k = bll.Add(m);

                if (k > 0)
                {
                    PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                }

            }

        }
 
    }
}