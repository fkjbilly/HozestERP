using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderTransportDetailVO {
		
		///<summary>
		/// 物流id
		///</summary>
		
		private int? transportId_;
		
		///<summary>
		/// 快递号
		///</summary>
		
		private string transportNo_;
		
		///<summary>
		/// 物流状态编码
		///</summary>
		
		private string transportCode_;
		
		///<summary>
		/// 物流详情
		///</summary>
		
		private string transportDetail_;
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string carriersCode_;
		
		///<summary>
		/// 承运商简称
		///</summary>
		
		private string carriersShortName_;
		
		///<summary>
		/// 承运商全称
		///</summary>
		
		private string carriersName_;
		
		///<summary>
		/// 承运商类型
		///</summary>
		
		private string carriersType_;
		
		///<summary>
		/// 仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 支付方式
		///</summary>
		
		private int? payType_;
		
		///<summary>
		/// 
		///</summary>
		
		private string extPayTypeCode_;
		
		///<summary>
		/// 
		///</summary>
		
		private int? extPayType_;
		
		///<summary>
		/// 订单Sn
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private long? time_;
		
		///<summary>
		/// 客退申请单号
		///</summary>
		
		private string backSn_;
		
		///<summary>
		/// 表主键ID
		///</summary>
		
		private long? id_;
		
		public int? GetTransportId(){
			return this.transportId_;
		}
		
		public void SetTransportId(int? value){
			this.transportId_ = value;
		}
		public string GetTransportNo(){
			return this.transportNo_;
		}
		
		public void SetTransportNo(string value){
			this.transportNo_ = value;
		}
		public string GetTransportCode(){
			return this.transportCode_;
		}
		
		public void SetTransportCode(string value){
			this.transportCode_ = value;
		}
		public string GetTransportDetail(){
			return this.transportDetail_;
		}
		
		public void SetTransportDetail(string value){
			this.transportDetail_ = value;
		}
		public string GetCarriersCode(){
			return this.carriersCode_;
		}
		
		public void SetCarriersCode(string value){
			this.carriersCode_ = value;
		}
		public string GetCarriersShortName(){
			return this.carriersShortName_;
		}
		
		public void SetCarriersShortName(string value){
			this.carriersShortName_ = value;
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
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public int? GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(int? value){
			this.payType_ = value;
		}
		public string GetExtPayTypeCode(){
			return this.extPayTypeCode_;
		}
		
		public void SetExtPayTypeCode(string value){
			this.extPayTypeCode_ = value;
		}
		public int? GetExtPayType(){
			return this.extPayType_;
		}
		
		public void SetExtPayType(int? value){
			this.extPayType_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public long? GetTime(){
			return this.time_;
		}
		
		public void SetTime(long? value){
			this.time_ = value;
		}
		public string GetBackSn(){
			return this.backSn_;
		}
		
		public void SetBackSn(string value){
			this.backSn_ = value;
		}
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		
	}
	
}