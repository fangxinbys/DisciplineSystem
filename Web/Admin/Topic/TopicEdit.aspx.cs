using FineUIPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace Maticsoft.Web.Admin.Topic
{
    public partial class TopicEdit : PageBase
    {
        BLL.tTopic bll = new BLL.tTopic();
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();

                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    string Id = Request.QueryString["Id"];

                    LoadData(Id);
                }
                if (!string.IsNullOrEmpty(Request.QueryString["dptId"]))
                {
                    string dptId = Request.QueryString["dptId"];
                    BLL.tDepartMent bdpt = new BLL.tDepartMent();
                    txtDptName.Text= bdpt.GetModel(Convert.ToInt32(dptId)).dptName;
                     
                }
                

            }
        }
        protected void LoadData(string Id)
        {

            Model.tTopic m = bll.GetModel(Convert.ToInt32(Id));
            if (m == null)
            {
                Alert.ShowInTop("出错了！"); return;
            }
            hfEditorInitValue2.Text = m.policyFile;
            hfEditorInitValue.Text = m.topicFile;
            txtDptName.Text = m.policyDptName;
            txtTitle.Text = m.topicTitle;
            DateTimeCh.SelectedDate = m.topicTime;
            DateTimeTop.SelectedDate = m.policyTime;
            txtAdress.Text = m.policyAdress;
            txtPeo.Text = m.policyPeople;
            txtProcess.Text = m.policyProcess;
            txtRs.Text = m.policyResult;
            txtDone.Text = m.policyDone;
            if (m.isCheck == "已审核")
            {
                btnSaveClose.Text = "已审核";
                btnSaveClose.Enabled = false; 
            }
        }



        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                string Id = Request.QueryString["Id"];
                Model.tTopic m = bll.GetModel(Convert.ToInt32(Id));
                if (m == null) return;
                string content1 = Request.Form["editorNew"] == null ? "" : Request.Form["editorNew"];
                string content2 = Request.Form["editorNew2"] == null ? "" : Request.Form["editorNew2"];
                m.policyFile = content2;
                m.topicFile = content1;
                m.policyDptName = txtDptName.Text;
                m.topicTitle = txtTitle.Text;
                m.topicTime = DateTimeCh.SelectedDate;
                m.policyTime = DateTimeTop.SelectedDate;
                m.policyAdress = txtAdress.Text;
                m.policyPeople = txtPeo.Text;
                m.policyProcess = txtProcess.Text;
                m.policyResult = txtRs.Text;
                m.policyDone = txtDone.Text;

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
                Model.tTopic m = new Model.tTopic();
                string content1 = Request.Form["editorNew"] == null ? "" : Request.Form["editorNew"];
                string content2 = Request.Form["editorNew2"] == null ? "" : Request.Form["editorNew2"];
                m.policyFile = content2;
                m.topicFile = content1;
                m.policyDptName = txtDptName.Text;
                m.topicTitle = txtTitle.Text;
                m.topicTime = DateTimeCh.SelectedDate;
                m.policyTime = DateTimeTop.SelectedDate;
                m.policyAdress = txtAdress.Text;
                m.policyPeople = txtPeo.Text;
                m.policyProcess = txtProcess.Text;
                m.policyResult = txtRs.Text;
                m.policyDone = txtDone.Text;
                m.policyDptId = int.Parse(Request.QueryString["dptId"]);
                Model.tUsers user = GetIdentityUser();
                m.savePeo = user.usersName;
                m.savePeoId = user.userId;
                m.policyType = int.Parse(Request.QueryString["tId"]);
                int k = bll.Add(m);
               
                if (k > 0)
                {
                    PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                }

            }

        }
    }
}