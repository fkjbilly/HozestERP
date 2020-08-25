using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderLogsVO {
		
		///<summary>
		/// 操作类型
		///</summary>
		
		private int? operateType_;
		
		///<summary>
		/// 操作类型中文名
		///</summary>
		
		private string operateTypeName_;
		
		///<summary>
		/// 操作内容说明
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 操作人的工号，系统操作填系统标识，客服操作填客服工号
		///</summary>
		
		private string operator_;
		
		///<summary>
		/// 日志写入时间
		///</summary>
		
		private long? logTime_;
		
		///<summary>
		/// 主键
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单号,如果为预付订单时传orderCode
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 用戶ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 预付订单父sn
		///</summary>
		
		private string parentSn_;
		
		///<summary>
		/// 预付订单order_code
		///</summary>
		
		private string orderCode_;
		
		public int? GetOperateType(){
			return this.operateType_;
		}
		
		public void SetOperateType(int? value){
			this.operateType_ = value;
		}
		public string GetOperateTypeName(){
			return this.operateTypeName_;
		}
		
		public void SetOperateTypeName(string value){
			this.operateTypeName_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public string GetOperator(){
			return this.operator_;
		}
		
		public void SetOperator(string value){
			this.operator_ = value;
		}
		public long? GetLogTime(){
			return this.logTime_;
		}
		
		public void SetLogTime(long? value){
			this.logTime_ = value;
		}
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetParentSn(){
			return this.parentSn_;
		}
		
		public void SetParentSn(string value){
			this.parentSn_ = value;
		}
		public string GetOrderCode(){
			return this.orderCode_;
		}
		
		public void SetOrderCode(string value){
			this.orderCode_ = value;
		}
		
	}
	
}