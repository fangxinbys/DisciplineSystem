using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tTaskLook:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tTaskLook
	{
		public tTaskLook()
		{}
		#region Model
		private int _id;
		private int? _taskid;
		private int? _dptid;
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
		public int? DptId
		{
			set{ _dptid=value;}
			get{return _dptid;}
		}
		#endregion Model

	}
}

