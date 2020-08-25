using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class RequestHeader {
		
		///<summary>
		/// 操作
		///</summary>
		
		private string operation_;
		
		///<summary>
		/// 请求方系统代码
		///</summary>
		
		private string sourceSys_;
		
		///<summary>
		/// 交易流水号
		///</summary>
		
		private string transId_;
		
		///<summary>
		/// 交易时间
		///</summary>
		
		private long? transTimestamp_;
		
		///<summary>
		/// 操作人的工号，系统操作填系统标识，客服操作填客服工号
		///</summary>
		
		private string operator_;
		
		///<summary>
		/// 操作人姓名
		///</summary>
		
		private string operatorName_;
		
		///<summary>
		/// 客户端ip
		///</summary>
		
		private string clientIp_;
		
		///<summary>
		/// 移动端版本
		///</summary>
		
		private string appVersion_;
		
		///<summary>
		/// 操作人角色，0：会员，1：客服，2：系统
		///</summary>
		
		private int? operatorRole_;
		
		public string GetOperation(){
			return this.operation_;
		}
		
		public void SetOperation(string value){
			this.operation_ = value;
		}
		public string GetSourceSys(){
			return this.sourceSys_;
		}
		
		public void SetSourceSys(string value){
			this.sourceSys_ = value;
		}
		public string GetTransId(){
			return this.transId_;
		}
		
		public void SetTransId(string value){
			this.transId_ = value;
		}
		public long? GetTransTimestamp(){
			return this.transTimestamp_;
		}
		
		public void SetTransTimestamp(long? value){
			this.transTimestamp_ = value;
		}
		public string GetOperator(){
			return this.operator_;
		}
		
		public void SetOperator(string value){
			this.operator_ = value;
		}
		public string GetOperatorName(){
			return this.operatorName_;
		}
		
		public void SetOperatorName(string value){
			this.operatorName_ = value;
		}
		public string GetClientIp(){
			return this.clientIp_;
		}
		
		public void SetClientIp(string value){
			this.clientIp_ = value;
		}
		public string GetAppVersion(){
			return this.appVersion_;
		}
		
		public void SetAppVersion(string value){
			this.appVersion_ = value;
		}
		public int? GetOperatorRole(){
			return this.operatorRole_;
		}
		
		public void SetOperatorRole(int? value){
			this.operatorRole_ = value;
		}
		
	}
	
}