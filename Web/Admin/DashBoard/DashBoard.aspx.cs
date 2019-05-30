using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web;

namespace Maticsoft.Web.Admin.DashBoard
{
    public partial class DashBoard :PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                Maticsoft.Model.tUsers user = GetIdentityUser();
              
                GetTask(user.dptId);
            }
        }
        protected void GetTask(int dptId)
        {
            //string notifyId = Guid.NewGuid().ToString();
            //string sql = string.Format("select  Id,DptId,TaskId,SavaDpt,SaveContent ,SaveTime,SavePeo ,Title from dbo.v_task_save where DptId ={0} and SavaDpt is null ", dptId.ToString());
            //DataSet ds = DbHelperSQL.Query(sql);
            //string msg = "待处理任务：<a href=\"javascript:openTaskSave('" + notifyId + "');\">" + ds.Tables[0].Rows.Count + "</a>";
            //CreateNotify(msg, "Self", "登录提示", 0, false, notifyId);

        }
    }
}