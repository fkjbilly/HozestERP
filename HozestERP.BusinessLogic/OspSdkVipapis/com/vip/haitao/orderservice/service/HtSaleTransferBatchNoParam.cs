using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtSaleTransferBatchNoParam {
		
		///<summary>
		/// 仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 国际运输发货批次[批次号唯一]
		///</summary>
		
		private string batchNo_;
		
		///<summary>
		/// 交货数量
		///</summary>
		
		private int? deliveryNum_;
		
		///<summary>
		/// 关口
		///</summary>
		
		private string customsCode_;
		
		///<summary>
		/// 国内贷代
		///</summary>
		
		private string chinaFreightForwarding_;
		
		///<summary>
		/// 国际货代
		///</summary>
		
		private string globalFreightForwarding_;
		
		///<summary>
		/// 通关模式[BC、BBC...]
		///</summary>
		
		private string customsClearanceMode_;
		
		///<summary>
		/// VOP默认当前服务器时间
		///</summary>
		
		private string creatTime_;
		
		///<summary>
		/// 批次号对应的订单列表
		///</summary>
		
		private List<com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder> orders_;
		
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetBatchNo(){
			return this.batchNo_;
		}
		
		public void SetBatchNo(string value){
			this.batchNo_ = value;
		}
		public int? GetDeliveryNum(){
			return this.deliveryNum_;
		}
		
		public void SetDeliveryNum(int? value){
			this.deliveryNum_ = value;
		}
		public string GetCustomsCode(){
			return this.customsCode_;
		}
		
		public void SetCustomsCode(string value){
			this.customsCode_ = value;
		}
		public string GetChinaFreightForwarding(){
			return this.chinaFreightForwarding_;
		}
		
		public void SetChinaFreightForwarding(string value){
			this.chinaFreightForwarding_ = value;
		}
		public string GetGlobalFreightForwarding(){
			return this.globalFreightForwarding_;
		}
		
		public void SetGlobalFreightForwarding(string value){
			this.globalFreightForwarding_ = value;
		}
		public string GetCustomsClearanceMode(){
			return this.customsClearanceMode_;
		}
		
		public void SetCustomsClearanceMode(string value){
			this.customsClearanceMode_ = value;
		}
		public string GetCreatTime(){
			return this.creatTime_;
		}
		
		public void SetCreatTime(string value){
			this.creatTime_ = value;
		}
		public List<com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder> GetOrders(){
			return this.orders_;
		}
		
		public void SetOrders(List<com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder> value){
			this.orders_ = value;
		}
		
	}
	
}