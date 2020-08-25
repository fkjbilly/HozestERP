using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutWmsGlobalDeliverBatchParam {
		
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
		/// 请求时间:格式为:yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string createTime_;
		
		///<summary>
		/// 批次号对应的订单列表，建议订单数量不超过1000
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchOrderParam> orders_;
		
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
		public string GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(string value){
			this.createTime_ = value;
		}
		public List<com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchOrderParam> GetOrders(){
			return this.orders_;
		}
		
		public void SetOrders(List<com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchOrderParam> value){
			this.orders_ = value;
		}
		
	}
	
}