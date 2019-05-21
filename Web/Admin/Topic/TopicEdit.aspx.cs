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
        BLL.tDepartMent BLL = new BLL.tDepartMent();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
             
                if (!string.IsNullOrEmpty(Request.QueryString["dptId"]))
                {
                    string dptId = Request.QueryString["dptId"];

                    LoadData(dptId);
                }


            }
        }
        protected void LoadData(string dptId)
        {

            Model.tDepartMent m = BLL.GetModel(Convert.ToInt32(dptId));
            if (m == null)
            {
                Alert.ShowInTop("出错了！"); return;

            }

          
        }



        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["dptId"]))
            {
                string dptId = Request.QueryString["dptId"];
                Model.tDepartMent m = BLL.GetModel(Convert.ToInt32(dptId));
                if (m == null) return;
 
            }
            else
            {
               
            }

        }
    }
}