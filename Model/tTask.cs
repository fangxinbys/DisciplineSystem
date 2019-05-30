using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tTask:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tTask
	{
		public tTask()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _taskcontent;
		private DateTime? _savetime;
		private DateTime? _locktime;
		private string _savapeo;
		private string _ischeck;
		private string _ischeckpeo;
		private DateTime? _ischecktime;
		private string _tasklevel;
		private string _lookdptstring;
		private int? _savedpt;
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
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TaskContent
		{
			set{ _taskcontent=value;}
			get{return _taskcontent;}
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
		public DateTime? LockTime
		{
			set{ _locktime=value;}
			get{return _locktime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SavaPeo
		{
			set{ _savapeo=value;}
			get{return _savapeo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IsCheck
		{
			set{ _ischeck=value;}
			get{return _ischeck;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IsCheckPeo
		{
			set{ _ischeckpeo=value;}
			get{return _ischeckpeo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? IsCheckTime
		{
			set{ _ischecktime=value;}
			get{return _ischecktime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TaskLevel
		{
			set{ _tasklevel=value;}
			get{return _tasklevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LookDptString
		{
			set{ _lookdptstring=value;}
			get{return _lookdptstring;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SaveDpt
		{
			set{ _savedpt=value;}
			get{return _savedpt;}
		}
		#endregion Model

	}
}

