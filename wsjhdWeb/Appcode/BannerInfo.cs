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
	/// 实体类BannerInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("BannerInfo")]
	[Serializable]
	public partial class BannerInfo : Entity 
	{
		#region Model
		private int _Id;
		private string _Name;
		private string _EName;
		private string _PicUrl;
		private DateTime _AddTime;
		private DateTime _Updatetime;
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
		public string EName
		{
			get{ return _EName; }
			set
			{
				this.OnPropertyValueChange(_.EName,_EName,value);
				this._EName=value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PicUrl
		{
			get{ return _PicUrl; }
			set
			{
				this.OnPropertyValueChange(_.PicUrl,_PicUrl,value);
				this._PicUrl=value;
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
		public DateTime Updatetime
		{
			get{ return _Updatetime; }
			set
			{
				this.OnPropertyValueChange(_.Updatetime,_Updatetime,value);
				this._Updatetime=value;
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
				_.EName,
				_.PicUrl,
				_.AddTime,
				_.Updatetime,
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
				this._EName,
				this._PicUrl,
				this._AddTime,
				this._Updatetime,
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
			public readonly static Field All = new Field("*","BannerInfo");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Id = new Field("Id","BannerInfo","Id");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Name = new Field("Name","BannerInfo","Name");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field EName = new Field("EName","BannerInfo","EName");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field PicUrl = new Field("PicUrl","BannerInfo","PicUrl");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field AddTime = new Field("AddTime","BannerInfo","AddTime");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Updatetime = new Field("Updatetime","BannerInfo","Updatetime");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Status = new Field("Status","BannerInfo","Status");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Orders = new Field("Orders","BannerInfo","Orders");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Extend1 = new Field("Extend1","BannerInfo","Extend1");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Extend2 = new Field("Extend2","BannerInfo","Extend2");
		}
		#endregion


	}
}

