using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tTopic
	/// </summary>
	public partial class tTopic
	{
		public tTopic()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "tTopic"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tTopic");
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
		public int Add(Maticsoft.Model.tTopic model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tTopic(");
			strSql.Append("topicTitle,topicTime,topicFile,policyTime,policyAdress,policyPeople,policyProcess,policyResult,policyDone,policyFile,policyDptName,policyDptId,isCheck,policyType,isCheckPeo,isCheckTime)");
			strSql.Append(" values (");
			strSql.Append("@topicTitle,@topicTime,@topicFile,@policyTime,@policyAdress,@policyPeople,@policyProcess,@policyResult,@policyDone,@policyFile,@policyDptName,@policyDptId,@isCheck,@policyType,@isCheckPeo,@isCheckTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@topicTitle", SqlDbType.NVarChar,150),
					new SqlParameter("@topicTime", SqlDbType.DateTime),
					new SqlParameter("@topicFile", SqlDbType.NVarChar,-1),
					new SqlParameter("@policyTime", SqlDbType.DateTime),
					new SqlParameter("@policyAdress", SqlDbType.NVarChar,150),
					new SqlParameter("@policyPeople", SqlDbType.NVarChar,550),
					new SqlParameter("@policyProcess", SqlDbType.NVarChar,-1),
					new SqlParameter("@policyResult", SqlDbType.NVarChar,-1),
					new SqlParameter("@policyDone", SqlDbType.NVarChar,-1),
					new SqlParameter("@policyFile", SqlDbType.NVarChar,-1),
					new SqlParameter("@policyDptName", SqlDbType.NVarChar,150),
					new SqlParameter("@policyDptId", SqlDbType.Int,4),
					new SqlParameter("@isCheck", SqlDbType.VarChar,20),
					new SqlParameter("@policyType", SqlDbType.NVarChar,50),
					new SqlParameter("@isCheckPeo", SqlDbType.NVarChar,50),
					new SqlParameter("@isCheckTime", SqlDbType.DateTime)};
			parameters[0].Value = model.topicTitle;
			parameters[1].Value = model.topicTime;
			parameters[2].Value = model.topicFile;
			parameters[3].Value = model.policyTime;
			parameters[4].Value = model.policyAdress;
			parameters[5].Value = model.policyPeople;
			parameters[6].Value = model.policyProcess;
			parameters[7].Value = model.policyResult;
			parameters[8].Value = model.policyDone;
			parameters[9].Value = model.policyFile;
			parameters[10].Value = model.policyDptName;
			parameters[11].Value = model.policyDptId;
			parameters[12].Value = model.isCheck;
			parameters[13].Value = model.policyType;
			parameters[14].Value = model.isCheckPeo;
			parameters[15].Value = model.isCheckTime;

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
		public bool Update(Maticsoft.Model.tTopic model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tTopic set ");
			strSql.Append("topicTitle=@topicTitle,");
			strSql.Append("topicTime=@topicTime,");
			strSql.Append("topicFile=@topicFile,");
			strSql.Append("policyTime=@policyTime,");
			strSql.Append("policyAdress=@policyAdress,");
			strSql.Append("policyPeople=@policyPeople,");
			strSql.Append("policyProcess=@policyProcess,");
			strSql.Append("policyResult=@policyResult,");
			strSql.Append("policyDone=@policyDone,");
			strSql.Append("policyFile=@policyFile,");
			strSql.Append("policyDptName=@policyDptName,");
			strSql.Append("policyDptId=@policyDptId,");
			strSql.Append("isCheck=@isCheck,");
			strSql.Append("policyType=@policyType,");
			strSql.Append("isCheckPeo=@isCheckPeo,");
			strSql.Append("isCheckTime=@isCheckTime");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@topicTitle", SqlDbType.NVarChar,150),
					new SqlParameter("@topicTime", SqlDbType.DateTime),
					new SqlParameter("@topicFile", SqlDbType.NVarChar,-1),
					new SqlParameter("@policyTime", SqlDbType.DateTime),
					new SqlParameter("@policyAdress", SqlDbType.NVarChar,150),
					new SqlParameter("@policyPeople", SqlDbType.NVarChar,550),
					new SqlParameter("@policyProcess", SqlDbType.NVarChar,-1),
					new SqlParameter("@policyResult", SqlDbType.NVarChar,-1),
					new SqlParameter("@policyDone", SqlDbType.NVarChar,-1),
					new SqlParameter("@policyFile", SqlDbType.NVarChar,-1),
					new SqlParameter("@policyDptName", SqlDbType.NVarChar,150),
					new SqlParameter("@policyDptId", SqlDbType.Int,4),
					new SqlParameter("@isCheck", SqlDbType.VarChar,20),
					new SqlParameter("@policyType", SqlDbType.NVarChar,50),
					new SqlParameter("@isCheckPeo", SqlDbType.NVarChar,50),
					new SqlParameter("@isCheckTime", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.topicTitle;
			parameters[1].Value = model.topicTime;
			parameters[2].Value = model.topicFile;
			parameters[3].Value = model.policyTime;
			parameters[4].Value = model.policyAdress;
			parameters[5].Value = model.policyPeople;
			parameters[6].Value = model.policyProcess;
			parameters[7].Value = model.policyResult;
			parameters[8].Value = model.policyDone;
			parameters[9].Value = model.policyFile;
			parameters[10].Value = model.policyDptName;
			parameters[11].Value = model.policyDptId;
			parameters[12].Value = model.isCheck;
			parameters[13].Value = model.policyType;
			parameters[14].Value = model.isCheckPeo;
			parameters[15].Value = model.isCheckTime;
			parameters[16].Value = model.Id;

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
			strSql.Append("delete from tTopic ");
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
			strSql.Append("delete from tTopic ");
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
		public Maticsoft.Model.tTopic GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,topicTitle,topicTime,topicFile,policyTime,policyAdress,policyPeople,policyProcess,policyResult,policyDone,policyFile,policyDptName,policyDptId,isCheck,policyType,isCheckPeo,isCheckTime from tTopic ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Maticsoft.Model.tTopic model=new Maticsoft.Model.tTopic();
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
		public Maticsoft.Model.tTopic DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tTopic model=new Maticsoft.Model.tTopic();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["topicTitle"]!=null)
				{
					model.topicTitle=row["topicTitle"].ToString();
				}
				if(row["topicTime"]!=null && row["topicTime"].ToString()!="")
				{
					model.topicTime=DateTime.Parse(row["topicTime"].ToString());
				}
				if(row["topicFile"]!=null)
				{
					model.topicFile=row["topicFile"].ToString();
				}
				if(row["policyTime"]!=null && row["policyTime"].ToString()!="")
				{
					model.policyTime=DateTime.Parse(row["policyTime"].ToString());
				}
				if(row["policyAdress"]!=null)
				{
					model.policyAdress=row["policyAdress"].ToString();
				}
				if(row["policyPeople"]!=null)
				{
					model.policyPeople=row["policyPeople"].ToString();
				}
				if(row["policyProcess"]!=null)
				{
					model.policyProcess=row["policyProcess"].ToString();
				}
				if(row["policyResult"]!=null)
				{
					model.policyResult=row["policyResult"].ToString();
				}
				if(row["policyDone"]!=null)
				{
					model.policyDone=row["policyDone"].ToString();
				}
				if(row["policyFile"]!=null)
				{
					model.policyFile=row["policyFile"].ToString();
				}
				if(row["policyDptName"]!=null)
				{
					model.policyDptName=row["policyDptName"].ToString();
				}
				if(row["policyDptId"]!=null && row["policyDptId"].ToString()!="")
				{
					model.policyDptId=int.Parse(row["policyDptId"].ToString());
				}
				if(row["isCheck"]!=null)
				{
					model.isCheck=row["isCheck"].ToString();
				}
				if(row["policyType"]!=null)
				{
					model.policyType=row["policyType"].ToString();
				}
				if(row["isCheckPeo"]!=null)
				{
					model.isCheckPeo=row["isCheckPeo"].ToString();
				}
				if(row["isCheckTime"]!=null && row["isCheckTime"].ToString()!="")
				{
					model.isCheckTime=DateTime.Parse(row["isCheckTime"].ToString());
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
			strSql.Append("select Id,topicTitle,topicTime,topicFile,policyTime,policyAdress,policyPeople,policyProcess,policyResult,policyDone,policyFile,policyDptName,policyDptId,isCheck,policyType,isCheckPeo,isCheckTime ");
			strSql.Append(" FROM tTopic ");
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
			strSql.Append(" Id,topicTitle,topicTime,topicFile,policyTime,policyAdress,policyPeople,policyProcess,policyResult,policyDone,policyFile,policyDptName,policyDptId,isCheck,policyType,isCheckPeo,isCheckTime ");
			strSql.Append(" FROM tTopic ");
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
			strSql.Append("select count(1) FROM tTopic ");
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
			strSql.Append(")AS Row, T.*  from tTopic T ");
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
			parameters[0].Value = "tTopic";
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

