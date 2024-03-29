﻿using Native.Csharp.Sdk.Cqp.Enum;
using Native.Csharp.Sdk.Cqp.Expand;
using Native.Csharp.Sdk.Cqp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.Sdk.Cqp.EventArgs
{
	/// <summary>
	/// 提供用于描述酷Q群管理变化事件参数的类
	/// <para/>
	/// Type: 101
	/// </summary>
	public class CQGroupManageChangeEventArgs : CQEventEventArgs
	{
		#region --属性--
		/// <summary>
		/// 获取当前事件的子类型
		/// </summary>
		public CQGroupManageChangeType SubType { get; private set; }

		/// <summary>
		/// 获取当前事件的发送时间
		/// </summary>
		public DateTime SendTime { get; private set; }

		/// <summary>
		/// 获取当前事件的来源群
		/// </summary>
		public Group FromGroup { get; private set; }

		/// <summary>
		/// 被操作的QQ
		/// </summary>
		public QQ BeingOperateQQ { get; private set; }
		#endregion

		#region --构造函数--
		/// <summary>
		/// 初始化 <see cref="CQGroupManageChangeEventArgs"/> 类的新实例
		/// </summary>
		/// <param name="id">事件Id</param>
		/// <param name="type">事件类型</param>
		/// <param name="name">事件名称</param>
		/// <param name="function">函数名称</param>
		/// <param name="priority">默认优先级</param>
		/// <param name="subType">子类型</param>
		/// <param name="sendTime">发送时间</param>
		/// <param name="fromGroup">来源群</param>
		/// <param name="beingOperateQQ">被操作QQ</param>
		/// <param name="api">接口Api实例</param>
		public CQGroupManageChangeEventArgs (int id, int type, string name, string function, uint priority, int subType, int sendTime, long fromGroup, long beingOperateQQ, CQApi api)
			: base (id, type, name, function, priority)
		{
			this.SubType = (CQGroupManageChangeType)subType;
			this.SendTime = sendTime.ToDateTime ();
			this.FromGroup = new Group (api, fromGroup);
			this.BeingOperateQQ = new QQ (api, beingOperateQQ);
		}
		#endregion

		#region --公开函数--
		/// <summary>
		/// 返回表示当前对象的字符串
		/// </summary>
		/// <returns>表示当前对象的字符串</returns>
		public override string ToString ()
		{
			StringBuilder builder = new StringBuilder ();
			builder.AppendLine (string.Format ("ID: {0}", this.Id));
			builder.AppendLine (string.Format ("类型: {0}({1})", this.Type, (int)this.Type));
			builder.AppendLine (string.Format ("名称: {0}", this.Name));
			builder.AppendLine (string.Format ("函数: {0}", this.Function));
			builder.AppendLine (string.Format ("优先级: {0}", this.Priority));
			builder.AppendLine (string.Format ("子类型: {0}({1})", this.SubType, (int)this.SubType));
			builder.AppendLine (string.Format ("发送时间: {0}", this.SendTime));
			builder.AppendLine (string.Format ("来源群: {0}", this.FromGroup.Id));
			builder.AppendFormat ("被操作QQ: {0}", this.BeingOperateQQ.Id);
			return builder.ToString ();
		}
		#endregion
	}
}
