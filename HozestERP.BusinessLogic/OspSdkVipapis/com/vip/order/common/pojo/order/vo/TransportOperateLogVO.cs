using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class TransportOperateLogVO {
		
		///<summary>
		/// 操作时间 ，单位：秒
		///</summary>
		
		private long? operateTime_;
		
		///<summary>
		/// 操作角色
		///</summary>
		
		private string user_;
		
		///<summary>
		/// 操作说明
		///</summary>
		
		private string remark_;
		
		public long? GetOperateTime(){
			return this.operateTime_;
		}
		
		public void SetOperateTime(long? value){
			this.operateTime_ = value;
		}
		public string GetUser(){
			return this.user_;
		}
		
		public void SetUser(string value){
			this.user_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		
	}
	
}