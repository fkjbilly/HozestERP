using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtLadingBillNumberManagmentModel {
		
		///<summary>
		/// 提单号码
		///</summary>
		
		private string ladingBillNumber_;
		
		///<summary>
		/// 航班线
		///</summary>
		
		private string flightNumber_;
		
		///<summary>
		/// 重量（默认单位Kg)
		///</summary>
		
		private double? totalWeight_;
		
		///<summary>
		/// 发货仓
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 起运港代码
		///</summary>
		
		private string shipmentPort_;
		
		///<summary>
		/// 起运国代码
		///</summary>
		
		private string shipmentCountry_;
		
		///<summary>
		/// 抵运港代码
		///</summary>
		
		private string arrivePort_;
		
		///<summary>
		/// 抵运国代码
		///</summary>
		
		private string arriveCountry_;
		
		///<summary>
		/// 提单附件
		///</summary>
		
		private string attachmentPath_;
		
		///<summary>
		/// 发货人类型(0:未知,1:供应商自主发货,2:合作物流国外提货,3:海外自营仓发货, 4:海外代运营仓发货)
		///</summary>
		
		private int? senderType_;
		
		///<summary>
		/// 通关类型(001:BC,003:BBC,004:快件,005:邮关快件,006:非邮快件)
		///</summary>
		
		private string customsClearanceMode_;
		
		///<summary>
		/// 海关代码(bjhg:北京海关,shhg:广州海关)
		///</summary>
		
		private string customsCode_;
		
		///<summary>
		/// 国内货代(hongyuan:北京宏远)
		///</summary>
		
		private string chinaFreightForwarding_;
		
		///<summary>
		/// 国际货代(DHL, imcosco)
		///</summary>
		
		private string globalFreightForwarding_;
		
		///<summary>
		/// 销售模式(13:海淘外仓 ,17:普通海淘 18:JIT海淘,20:海淘3PL)
		///</summary>
		
		private string saleStyle_;
		
		///<summary>
		/// 提单对应订单总数
		///</summary>
		
		private int? orderCount_;
		
		public string GetLadingBillNumber(){
			return this.ladingBillNumber_;
		}
		
		public void SetLadingBillNumber(string value){
			this.ladingBillNumber_ = value;
		}
		public string GetFlightNumber(){
			return this.flightNumber_;
		}
		
		public void SetFlightNumber(string value){
			this.flightNumber_ = value;
		}
		public double? GetTotalWeight(){
			return this.totalWeight_;
		}
		
		public void SetTotalWeight(double? value){
			this.totalWeight_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetShipmentPort(){
			return this.shipmentPort_;
		}
		
		public void SetShipmentPort(string value){
			this.shipmentPort_ = value;
		}
		public string GetShipmentCountry(){
			return this.shipmentCountry_;
		}
		
		public void SetShipmentCountry(string value){
			this.shipmentCountry_ = value;
		}
		public string GetArrivePort(){
			return this.arrivePort_;
		}
		
		public void SetArrivePort(string value){
			this.arrivePort_ = value;
		}
		public string GetArriveCountry(){
			return this.arriveCountry_;
		}
		
		public void SetArriveCountry(string value){
			this.arriveCountry_ = value;
		}
		public string GetAttachmentPath(){
			return this.attachmentPath_;
		}
		
		public void SetAttachmentPath(string value){
			this.attachmentPath_ = value;
		}
		public int? GetSenderType(){
			return this.senderType_;
		}
		
		public void SetSenderType(int? value){
			this.senderType_ = value;
		}
		public string GetCustomsClearanceMode(){
			return this.customsClearanceMode_;
		}
		
		public void SetCustomsClearanceMode(string value){
			this.customsClearanceMode_ = value;
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
		public string GetSaleStyle(){
			return this.saleStyle_;
		}
		
		public void SetSaleStyle(string value){
			this.saleStyle_ = value;
		}
		public int? GetOrderCount(){
			return this.orderCount_;
		}
		
		public void SetOrderCount(int? value){
			this.orderCount_ = value;
		}
		
	}
	
}