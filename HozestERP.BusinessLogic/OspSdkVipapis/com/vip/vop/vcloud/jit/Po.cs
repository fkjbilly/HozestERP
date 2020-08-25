using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class Po {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// PO号
		///</summary>
		
		private string poNo_;
		
		///<summary>
		/// 档期ID
		///</summary>
		
		private long? scheduleId_;
		
		///<summary>
		/// 合作模式
		///</summary>
		
		private string coMode_;
		
		///<summary>
		/// 品牌名称
		///</summary>
		
		private string brandName_;
		
		///<summary>
		/// 档期名称
		///</summary>
		
		private string scheduleName_;
		
		///<summary>
		/// 售卖开始时间
		/// @sampleValue sellTimeStart yyyy-MM-dd hh:mm:ss
		///</summary>
		
		private System.DateTime? sellTimeStart_;
		
		///<summary>
		/// 售卖结束时间
		/// @sampleValue sellTimeEnd yyyy-MM-dd hh:mm:ss
		///</summary>
		
		private System.DateTime? sellTimeEnd_;
		
		///<summary>
		/// po开始时间
		/// @sampleValue poStartTime yyyy-MM-dd hh:mm:ss
		///</summary>
		
		private System.DateTime? poStartTime_;
		
		///<summary>
		/// 总库存
		///</summary>
		
		private int? quantity_;
		
		///<summary>
		/// 销售数
		///</summary>
		
		private int? saleQuantity_;
		
		///<summary>
		/// 未拣货数
		///</summary>
		
		private int? unpickQuantity_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 合作伙伴ID
		///</summary>
		
		private long? partnerId_;
		
		///<summary>
		/// 常态合作编码
		///</summary>
		
		private long? cooperationNo_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetPoNo(){
			return this.poNo_;
		}
		
		public void SetPoNo(string value){
			this.poNo_ = value;
		}
		public long? GetScheduleId(){
			return this.scheduleId_;
		}
		
		public void SetScheduleId(long? value){
			this.scheduleId_ = value;
		}
		public string GetCoMode(){
			return this.coMode_;
		}
		
		public void SetCoMode(string value){
			this.coMode_ = value;
		}
		public string GetBrandName(){
			return this.brandName_;
		}
		
		public void SetBrandName(string value){
			this.brandName_ = value;
		}
		public string GetScheduleName(){
			return this.scheduleName_;
		}
		
		public void SetScheduleName(string value){
			this.scheduleName_ = value;
		}
		public System.DateTime? GetSellTimeStart(){
			return this.sellTimeStart_;
		}
		
		public void SetSellTimeStart(System.DateTime? value){
			this.sellTimeStart_ = value;
		}
		public System.DateTime? GetSellTimeEnd(){
			return this.sellTimeEnd_;
		}
		
		public void SetSellTimeEnd(System.DateTime? value){
			this.sellTimeEnd_ = value;
		}
		public System.DateTime? GetPoStartTime(){
			return this.poStartTime_;
		}
		
		public void SetPoStartTime(System.DateTime? value){
			this.poStartTime_ = value;
		}
		public int? GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(int? value){
			this.quantity_ = value;
		}
		public int? GetSaleQuantity(){
			return this.saleQuantity_;
		}
		
		public void SetSaleQuantity(int? value){
			this.saleQuantity_ = value;
		}
		public int? GetUnpickQuantity(){
			return this.unpickQuantity_;
		}
		
		public void SetUnpickQuantity(int? value){
			this.unpickQuantity_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public long? GetPartnerId(){
			return this.partnerId_;
		}
		
		public void SetPartnerId(long? value){
			this.partnerId_ = value;
		}
		public long? GetCooperationNo(){
			return this.cooperationNo_;
		}
		
		public void SetCooperationNo(long? value){
			this.cooperationNo_ = value;
		}
		
	}
	
}