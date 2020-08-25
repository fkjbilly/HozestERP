using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderReturnTransportInfoVO {
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string carriersCode_;
		
		///<summary>
		/// 承运商简称
		///</summary>
		
		private string carriersShortname_;
		
		///<summary>
		/// 承运商全称
		///</summary>
		
		private string carriersName_;
		
		///<summary>
		/// 承运商类型
		///</summary>
		
		private string carriersType_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transportNo_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 顺序号
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 申请id
		///</summary>
		
		private long? applyId_;
		
		///<summary>
		/// 订单id
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 申请时间
		///</summary>
		
		private long? createTime_;
		
		///<summary>
		/// 修改时间
		///</summary>
		
		private long? updateTime_;
		
		public string GetCarriersCode(){
			return this.carriersCode_;
		}
		
		public void SetCarriersCode(string value){
			this.carriersCode_ = value;
		}
		public string GetCarriersShortname(){
			return this.carriersShortname_;
		}
		
		public void SetCarriersShortname(string value){
			this.carriersShortname_ = value;
		}
		public string GetCarriersName(){
			return this.carriersName_;
		}
		
		public void SetCarriersName(string value){
			this.carriersName_ = value;
		}
		public string GetCarriersType(){
			return this.carriersType_;
		}
		
		public void SetCarriersType(string value){
			this.carriersType_ = value;
		}
		public string GetTransportNo(){
			return this.transportNo_;
		}
		
		public void SetTransportNo(string value){
			this.transportNo_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public long? GetApplyId(){
			return this.applyId_;
		}
		
		public void SetApplyId(long? value){
			this.applyId_ = value;
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
		public long? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(long? value){
			this.createTime_ = value;
		}
		public long? GetUpdateTime(){
			return this.updateTime_;
		}
		
		public void SetUpdateTime(long? value){
			this.updateTime_ = value;
		}
		
	}
	
}