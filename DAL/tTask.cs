using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tTask
	/// </summary>
	public partial class tTask
	{
		public tTask()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "tTask"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tTask");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.tTask model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tTask(");
			strSql.Append("Title,TaskContent,SaveTime,LockTime,SavaPeo,IsCheck,IsCheckPeo,IsCheckTime,TaskLevel,LookDptString,SaveDpt)");
			strSql.Append(" values (");
			strSql.Append("@Title,@TaskContent,@SaveTime,@LockTime,@SavaPeo,@IsCheck,@IsCheckPeo,@IsCheckTime,@TaskLevel,@LookDptString,@SaveDpt)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,-1),
					new SqlParameter("@TaskContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@SaveTime", SqlDbType.DateTime),
					new SqlParameter("@LockTime", SqlDbType.DateTime),
					new SqlParameter("@SavaPeo", SqlDbType.NVarChar,50),
					new SqlParameter("@IsCheck", SqlDbType.VarChar,50),
					new SqlParameter("@IsCheckPeo", SqlDbType.NVarChar,50),
					new SqlParameter("@IsCheckTime", SqlDbType.DateTime),
					new SqlParameter("@TaskLevel", SqlDbType.NVarChar,150),
					new SqlParameter("@LookDptString", SqlDbType.NVarChar,-1),
					new SqlParameter("@SaveDpt", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.TaskContent;
			parameters[2].Value = model.SaveTime;
			parameters[3].Value = model.LockTime;
			parameters[4].Value = model.SavaPeo;
			parameters[5].Value = model.IsCheck;
			parameters[6].Value = model.IsCheckPeo;
			parameters[7].Value = model.IsCheckTime;
			parameters[8].Value = model.TaskLevel;
			parameters[9].Value = model.LookDptString;
			parameters[10].Value = model.SaveDpt;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.tTask model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tTask set ");
			strSql.Append("Title=@Title,");
			strSql.Append("TaskContent=@TaskContent,");
			strSql.Append("SaveTime=@SaveTime,");
			strSql.Append("LockTime=@LockTime,");
			strSql.Append("SavaPeo=@SavaPeo,");
			strSql.Append("IsCheck=@IsCheck,");
			strSql.Append("IsCheckPeo=@IsCheckPeo,");
			strSql.Append("IsCheckTime=@IsCheckTime,");
			strSql.Append("TaskLevel=@TaskLevel,");
			strSql.Append("LookDptString=@LookDptString,");
			strSql.Append("SaveDpt=@SaveDpt");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,-1),
					new SqlParameter("@TaskContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@SaveTime", SqlDbType.DateTime),
					new SqlParameter("@LockTime", SqlDbType.DateTime),
					new SqlParameter("@SavaPeo", SqlDbType.NVarChar,50),
					new SqlParameter("@IsCheck", SqlDbType.VarChar,50),
					new SqlParameter("@IsCheckPeo", SqlDbType.NVarChar,50),
					new SqlParameter("@IsCheckTime", SqlDbType.DateTime),
					new SqlParameter("@TaskLevel", SqlDbType.NVarChar,150),
					new SqlParameter("@LookDptString", SqlDbType.NVarChar,-1),
					new SqlParameter("@SaveDpt", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.TaskContent;
			parameters[2].Value = model.SaveTime;
			parameters[3].Value = model.LockTime;
			parameters[4].Value = model.SavaPeo;
			parameters[5].Value = model.IsCheck;
			parameters[6].Value = model.IsCheckPeo;
			parameters[7].Value = model.IsCheckTime;
			parameters[8].Value = model.TaskLevel;
			parameters[9].Value = model.LookDptString;
			parameters[10].Value = model.SaveDpt;
			parameters[11].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tTask ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tTask ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tTask GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Title,TaskContent,SaveTime,LockTime,SavaPeo,IsCheck,IsCheckPeo,IsCheckTime,TaskLevel,LookDptString,SaveDpt from tTask ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Maticsoft.Model.tTask model=new Maticsoft.Model.tTask();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.tTask DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tTask model=new Maticsoft.Model.tTask();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["TaskContent"]!=null)
				{
					model.TaskContent=row["TaskContent"].ToString();
				}
				if(row["SaveTime"]!=null && row["SaveTime"].ToString()!="")
				{
					model.SaveTime=DateTime.Parse(row["SaveTime"].ToString());
				}
				if(row["LockTime"]!=null && row["LockTime"].ToString()!="")
				{
					model.LockTime=DateTime.Parse(row["LockTime"].ToString());
				}
				if(row["SavaPeo"]!=null)
				{
					model.SavaPeo=row["SavaPeo"].ToString();
				}
				if(row["IsCheck"]!=null)
				{
					model.IsCheck=row["IsCheck"].ToString();
				}
				if(row["IsCheckPeo"]!=null)
				{
					model.IsCheckPeo=row["IsCheckPeo"].ToString();
				}
				if(row["IsCheckTime"]!=null && row["IsCheckTime"].ToString()!="")
				{
					model.IsCheckTime=DateTime.Parse(row["IsCheckTime"].ToString());
				}
				if(row["TaskLevel"]!=null)
				{
					model.TaskLevel=row["TaskLevel"].ToString();
				}
				if(row["LookDptString"]!=null)
				{
					model.LookDptString=row["LookDptString"].ToString();
				}
				if(row["SaveDpt"]!=null && row["SaveDpt"].ToString()!="")
				{
					model.SaveDpt=int.Parse(row["SaveDpt"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,Title,TaskContent,SaveTime,LockTime,SavaPeo,IsCheck,IsCheckPeo,IsCheckTime,TaskLevel,LookDptString,SaveDpt ");
			strSql.Append(" FROM tTask ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,Title,TaskContent,SaveTime,LockTime,SavaPeo,IsCheck,IsCheckPeo,IsCheckTime,TaskLevel,LookDptString,SaveDpt ");
			strSql.Append(" FROM tTask ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tTask ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from tTask T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tTask";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

