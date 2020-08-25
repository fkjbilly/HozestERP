using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutWmsLadingBillIDLParam {
		
		///<summary>
		/// 提单号
		///</summary>
		
		private string ladingBillNumber_;
		
		///<summary>
		/// 起运国
		///</summary>
		
		private string shipmentCountry_;
		
		///<summary>
		/// 抵达国
		///</summary>
		
		private string arriveCountry_;
		
		///<summary>
		/// 通关模式[BC、BBC...]
		///</summary>
		
		private string customsClearanceMode_;
		
		///<summary>
		/// 重量(默认单位Kg)
		///</summary>
		
		private double? totalWeight_;
		
		///<summary>
		/// 子提单号列表
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.SubLadingBillNumberVo> subBillNumerList_;
		
		public string GetLadingBillNumber(){
			return this.ladingBillNumber_;
		}
		
		public void SetLadingBillNumber(string value){
			this.ladingBillNumber_ = value;
		}
		public string GetShipmentCountry(){
			return this.shipmentCountry_;
		}
		
		public void SetShipmentCountry(string value){
			this.shipmentCountry_ = value;
		}
		public string GetArriveCountry(){
			return this.arriveCountry_;
		}
		
		public void SetArriveCountry(string value){
			this.arriveCountry_ = value;
		}
		public string GetCustomsClearanceMode(){
			return this.customsClearanceMode_;
		}
		
		public void SetCustomsClearanceMode(string value){
			this.customsClearanceMode_ = value;
		}
		public double? GetTotalWeight(){
			return this.totalWeight_;
		}
		
		public void SetTotalWeight(double? value){
			this.totalWeight_ = value;
		}
		public List<com.vip.sce.vlg.osp.wms.service.SubLadingBillNumberVo> GetSubBillNumerList(){
			return this.subBillNumerList_;
		}
		
		public void SetSubBillNumerList(List<com.vip.sce.vlg.osp.wms.service.SubLadingBillNumberVo> value){
			this.subBillNumerList_ = value;
		}
		
	}
	
}