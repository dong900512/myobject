﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//     Website: http://ITdos.com/Dos/ORM/Index.html
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Data;
using System.Data.Common;
using Dos.ORM;
using Dos.ORM.Common;

namespace Dos.Model
{

	/// <summary>
	/// 实体类Manager_Groups 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("Manager_Groups")]
	[Serializable]
	public partial class Manager_Groups : Entity 
	{
		#region Model
		private int _Id;
		private string _Name;
		private string _Remark;
		private string _Role;
		private DateTime _AddTime;
		private string _AddUser;
		private DateTime _UpdateTime;
		private string _UpdateUser;
		private int _Status;
		private int _Orders;
		private string _Extend1;
		private string _Extend2;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get{ return _Id; }
			set
			{
				this.OnPropertyValueChange(_.Id,_Id,value);
				this._Id=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get{ return _Name; }
			set
			{
				this.OnPropertyValueChange(_.Name,_Name,value);
				this._Name=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			get{ return _Remark; }
			set
			{
				this.OnPropertyValueChange(_.Remark,_Remark,value);
				this._Remark=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Role
		{
			get{ return _Role; }
			set
			{
				this.OnPropertyValueChange(_.Role,_Role,value);
				this._Role=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			get{ return _AddTime; }
			set
			{
				this.OnPropertyValueChange(_.AddTime,_AddTime,value);
				this._AddTime=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AddUser
		{
			get{ return _AddUser; }
			set
			{
				this.OnPropertyValueChange(_.AddUser,_AddUser,value);
				this._AddUser=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime UpdateTime
		{
			get{ return _UpdateTime; }
			set
			{
				this.OnPropertyValueChange(_.UpdateTime,_UpdateTime,value);
				this._UpdateTime=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UpdateUser
		{
			get{ return _UpdateUser; }
			set
			{
				this.OnPropertyValueChange(_.UpdateUser,_UpdateUser,value);
				this._UpdateUser=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			get{ return _Status; }
			set
			{
				this.OnPropertyValueChange(_.Status,_Status,value);
				this._Status=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Orders
		{
			get{ return _Orders; }
			set
			{
				this.OnPropertyValueChange(_.Orders,_Orders,value);
				this._Orders=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Extend1
		{
			get{ return _Extend1; }
			set
			{
				this.OnPropertyValueChange(_.Extend1,_Extend1,value);
				this._Extend1=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Extend2
		{
			get{ return _Extend2; }
			set
			{
				this.OnPropertyValueChange(_.Extend2,_Extend2,value);
				this._Extend2=value;
			}
		}
		#endregion

		#region Method
		/// <summary>
		/// 获取实体中的标识列
		/// </summary>
		public override Field GetIdentityField()
		{
			return _.Id;
		}
		/// <summary>
		/// 获取实体中的主键列
		/// </summary>
		public override Field[] GetPrimaryKeyFields()
		{
			return new Field[] {
				_.Id};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.Id,
				_.Name,
				_.Remark,
				_.Role,
				_.AddTime,
				_.AddUser,
				_.UpdateTime,
				_.UpdateUser,
				_.Status,
				_.Orders,
				_.Extend1,
				_.Extend2};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._Id,
				this._Name,
				this._Remark,
				this._Role,
				this._AddTime,
				this._AddUser,
				this._UpdateTime,
				this._UpdateUser,
				this._Status,
				this._Orders,
				this._Extend1,
				this._Extend2};
		}
		#endregion

		#region _Field
		/// <summary>
		/// 字段信息
		/// </summary>
		public class _
		{
			/// <summary>
			/// * 
			/// </summary>
			public readonly static Field All = new Field("*","Manager_Groups");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Id = new Field("Id","Manager_Groups","Id");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Name = new Field("Name","Manager_Groups","Name");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Remark = new Field("Remark","Manager_Groups","Remark");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Role = new Field("Role","Manager_Groups","Role");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field AddTime = new Field("AddTime","Manager_Groups","AddTime");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field AddUser = new Field("AddUser","Manager_Groups","AddUser");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UpdateTime = new Field("UpdateTime","Manager_Groups","UpdateTime");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UpdateUser = new Field("UpdateUser","Manager_Groups","UpdateUser");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Status = new Field("Status","Manager_Groups","Status");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Orders = new Field("Orders","Manager_Groups","Orders");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Extend1 = new Field("Extend1","Manager_Groups","Extend1");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Extend2 = new Field("Extend2","Manager_Groups","Extend2");
		}
		#endregion


	}
}

