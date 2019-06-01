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
    public partial class TaskSaveEdit : PageBase
    {
        BLL.tTask bll = new BLL.tTask();
        BLL.tTaskSave bllsave = new BLL.tTaskSave();
        protected string taskCon = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
  
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
               
                DateTimeTop.SelectedDate = DateTime.Now;
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
 
        protected void LoadData(string Id)
        {

            Model.tTask m = bll.GetModel(Convert.ToInt32(Id));
            if (m == null)
            {
                Alert.ShowInTop("出错了！"); return;
            }
            List<Model.tTaskSave> userList = bllsave.GetModelList(string.Format(" TaskId={0} and SavaDpt={1} ", m.Id, GetIdentityUser().dptId));
            Model.tTaskSave msave = userList.Count == 0 ? null : userList[0];
            if (msave == null)
            {
                hfEditorInitValue2.Text = "";
            }
            else
            {
                hfEditorInitValue2.Text = msave.SaveContent;
            }
 

            txtTitle.Text = m.Title;
            DateTimeTop.SelectedDate = m.SaveTime;
            DateTimeLock.SelectedDate = m.LockTime;
            drpSearch.SelectedValue = m.TaskLevel;
            taskCon = m.TaskContent;

            if (DateTime.Now > m.LockTime)
            {
                btnSaveClose.Text = "已截止上报";
                btnSaveClose.Enabled = false;
            }
 


        }



        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            string Id = Request.QueryString["Id"];
            Model.tTask m = bll.GetModel(Convert.ToInt32(Id));
            if (m == null)
            {
                Alert.ShowInTop("出错了！"); return;
            }
            Model.tUsers user = GetIdentityUser();
            int dptId = user.dptId;
            List<Model.tTaskSave> userList = bllsave.GetModelList(string.Format(" TaskId={0} and SavaDpt={1} ", m.Id, dptId));
            Model.tTaskSave msave = userList.Count == 0 ? null : userList[0];
            string content2 = Request.Form["editorNew2"] == null ? "" : Request.Form["editorNew2"];
            if (content2 == "")
            {
                Alert.ShowInTop("上报内容不可为空！"); return;
            }
            if (msave == null)
            {
                Model.tTaskSave model = new Model.tTaskSave();
                model.SavaDpt = dptId;
                model.SaveContent = content2;
                model.SavePeo = user.usersName;
                model.SaveTime = DateTime.Now;
                model.TaskId = m.Id;
                if (bllsave.Add(model)>0)
                {
                    PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                }
            }
            else
            {
                msave.SavaDpt = dptId;
                msave.SaveContent = content2;
                msave.SavePeo = user.usersName;
                msave.SaveTime = DateTime.Now;
                msave.TaskId = m.Id;
                if (bllsave.Update(msave))
                {
                    PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                }
            }
        }

    }
}