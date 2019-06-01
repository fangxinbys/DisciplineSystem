using FineUIPro;
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace Maticsoft.Web.Admin.Task
{
    public partial class TaskEditLook : PageBase
    {
        protected string RsMsg = "";
        BLL.tTask bll = new BLL.tTask();
        BLL.tTaskSave bllsave = new BLL.tTaskSave();
        BLL.tDepartMent blldpt = new BLL.tDepartMent();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                if (string.IsNullOrEmpty(Request.QueryString["Id"]))
                {


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
            string Id = Request.QueryString["Id"];
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["dptId"].ToString() == dptId.ToString())
                {
                    FineUIPro.TreeNode node = new FineUIPro.TreeNode();
                    node.NodeID = row["dptId"].ToString();
         
                    node.Text = ("[" + GetIsSave(int.Parse(Id), int.Parse(node.NodeID)) + "]");
                    node.Text += row["dptName"].ToString();
                    node.EnableClickEvent = true;
                    TreeDpt.Nodes.Add(node);
                    ResolveSubTree(row, node);
                }
            }
            TreeDpt.SelectedNodeID = dptId.ToString();
        }
        private void ResolveSubTree(DataRow dataRow, FineUIPro.TreeNode treeNode)
        {
            string Id = Request.QueryString["Id"];
            DataRow[] rows = dataRow.GetChildRows("TreeRelation");
            if (rows.Length > 0)
            {
                // 如果是目录，则默认展开
                treeNode.Expanded = true;
                foreach (DataRow row in rows)
                {
                    FineUIPro.TreeNode node = new FineUIPro.TreeNode();
                    node.NodeID = row["dptId"].ToString();
                    node.Text = ("[" + GetIsSave(int.Parse(Id), int.Parse(node.NodeID)) + "]");
                    node.Text += row["dptName"].ToString(); 

                    node.EnableClickEvent = true;
                    treeNode.Nodes.Add(node);
                    ResolveSubTree(row, node);
                }
            }
        }
       
        protected string GetIsSave(int taskId,int dptId)
        {
    
            List<Model.tTaskSave> list = bllsave.GetModelList(string.Format(" TaskId={0} and SavaDpt={1} ", taskId, dptId));
            if (list.Count == 0)
            {
                return "<span style=\"color:red\" > 未上报</span>";
            }
            else
            {
                return "<span style=\"color:green\">已上报</span>";
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
            LoadDataSave();
        }

        protected void TreeDpt_NodeCommand(object sender, TreeCommandEventArgs e)
        {
            LoadDataSave();
        }
   
        protected void LoadDataSave()
        {
           
         
            StringBuilder sb = new StringBuilder();
            string dptlist = GetTreeNode(TreeDpt.SelectedNode, sb, true).ToString();
            string where =string.Format( " SavaDpt in (" + dptlist.Substring(0, dptlist.Length - 1) + ") and TaskId={0} ",int.Parse(Request.QueryString["Id"])); 
            DataTable dt = bllsave.GetList(where).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               string dptName=  blldpt.GetModel(int.Parse(dt.Rows[i]["SavaDpt"].ToString())).dptName;

                RsMsg += "<font style=\"color:red\">" +dptName+"<font/>"  ;  
                RsMsg += "<br/>";
                RsMsg += "上报时间：" + dt.Rows[i]["SaveTime"].ToString();
                RsMsg += " 上报人：" + dt.Rows[i]["SavePeo"].ToString();
                RsMsg += "<br/>";
                RsMsg += dt.Rows[i]["SaveContent"].ToString();
                RsMsg += "<br/>";
                RsMsg += "<br/>";
                RsMsg += "<hr/>";
            }
            lit_rs.Text = RsMsg;
        }


    }
}