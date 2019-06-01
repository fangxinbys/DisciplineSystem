using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tTaskSave:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tTaskSave
	{
		public tTaskSave()
		{}
		#region Model
		private int _id;
		private int? _taskid;
		private int? _savadpt;
		private string _savecontent;
		private DateTime? _savetime= DateTime.Now;
		private string _savepeo;
		private string _ischeck;
		private string _ischeckpeo;
		private DateTime? _ischecktime;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TaskId
		{
			set{ _taskid=value;}
			get{return _taskid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SavaDpt
		{
			set{ _savadpt=value;}
			get{return _savadpt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SaveContent
		{
			set{ _savecontent=value;}
			get{return _savecontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SaveTime
		{
			set{ _savetime=value;}
			get{return _savetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SavePeo
		{
			set{ _savepeo=value;}
			get{return _savepeo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string isCheck
		{
			set{ _ischeck=value;}
			get{return _ischeck;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string isCheckPeo
		{
			set{ _ischeckpeo=value;}
			get{return _ischeckpeo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? isCheckTime
		{
			set{ _ischecktime=value;}
			get{return _ischecktime;}
		}
		#endregion Model

	}
}

