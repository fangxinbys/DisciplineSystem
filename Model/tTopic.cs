using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tTopic:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tTopic
	{
		public tTopic()
		{}
		#region Model
		private int _id;
		private string _topictitle;
		private DateTime? _topictime;
		private string _topicfile;
		private DateTime? _policytime;
		private string _policyadress;
		private string _policypeople;
		private string _policyprocess;
		private string _policyresult;
		private string _policydone;
		private string _policyfile;
		private string _policydptname;
		private int? _policydptid;
		private string _ischeck="待审批";
		private string _policytype;
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
		public string topicTitle
		{
			set{ _topictitle=value;}
			get{return _topictitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? topicTime
		{
			set{ _topictime=value;}
			get{return _topictime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string topicFile
		{
			set{ _topicfile=value;}
			get{return _topicfile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? policyTime
		{
			set{ _policytime=value;}
			get{return _policytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string policyAdress
		{
			set{ _policyadress=value;}
			get{return _policyadress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string policyPeople
		{
			set{ _policypeople=value;}
			get{return _policypeople;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string policyProcess
		{
			set{ _policyprocess=value;}
			get{return _policyprocess;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string policyResult
		{
			set{ _policyresult=value;}
			get{return _policyresult;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string policyDone
		{
			set{ _policydone=value;}
			get{return _policydone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string policyFile
		{
			set{ _policyfile=value;}
			get{return _policyfile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string policyDptName
		{
			set{ _policydptname=value;}
			get{return _policydptname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? policyDptId
		{
			set{ _policydptid=value;}
			get{return _policydptid;}
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
		public string policyType
		{
			set{ _policytype=value;}
			get{return _policytype;}
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

