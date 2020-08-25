using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderTransportPackageVO {
		
		///<summary>
		/// 主键id
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 订单sn
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 订单id
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 包裹数量
		///</summary>
		
		private int? packageName_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transportNumber_;
		
		///<summary>
		/// 创建时间，单位为秒
		///</summary>
		
		private long? createTime_;
		
		///<summary>
		/// 更新时间，单位为秒
		///</summary>
		
		private long? updateTime_;
		
		///<summary>
		/// sku信息json
		///</summary>
		
		private string detail_;
		
		///<summary>
		/// 状态: 1有效,0无效
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 承运商简称
		///</summary>
		
		private string carriersShortname_;
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string carriersCode_;
		
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public int? GetPackageName(){
			return this.packageName_;
		}
		
		public void SetPackageName(int? value){
			this.packageName_ = value;
		}
		public string GetTransportNumber(){
			return this.transportNumber_;
		}
		
		public void SetTransportNumber(string value){
			this.transportNumber_ = value;
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
		public string GetDetail(){
			return this.detail_;
		}
		
		public void SetDetail(string value){
			this.detail_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public string GetCarriersShortname(){
			return this.carriersShortname_;
		}
		
		public void SetCarriersShortname(string value){
			this.carriersShortname_ = value;
		}
		public string GetCarriersCode(){
			return this.carriersCode_;
		}
		
		public void SetCarriersCode(string value){
			this.carriersCode_ = value;
		}
		
	}
	
}