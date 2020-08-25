using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class GetVendorScheduleFreezeStockResult {
		
		///<summary>
		/// 仓库编号
		/// @sampleValue vendor_warehouse_id 
		///</summary>
		
		private string vendor_warehouse_id_;
		
		///<summary>
		/// 商品条码
		/// @sampleValue barcode 
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 档期ID
		/// @sampleValue schedule_id 
		///</summary>
		
		private string schedule_id_;
		
		///<summary>
		/// 锁定库存数量
		/// @sampleValue freeze_num 
		///</summary>
		
		private string freeze_num_;
		
		///<summary>
		/// 锁定时间
		/// @sampleValue freeze_date 10
		///</summary>
		
		private string freeze_date_;
		
		public string GetVendor_warehouse_id(){
			return this.vendor_warehouse_id_;
		}
		
		public void SetVendor_warehouse_id(string value){
			this.vendor_warehouse_id_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetSchedule_id(){
			return this.schedule_id_;
		}
		
		public void SetSchedule_id(string value){
			this.schedule_id_ = value;
		}
		public string GetFreeze_num(){
			return this.freeze_num_;
		}
		
		public void SetFreeze_num(string value){
			this.freeze_num_ = value;
		}
		public string GetFreeze_date(){
			return this.freeze_date_;
		}
		
		public void SetFreeze_date(string value){
			this.freeze_date_ = value;
		}
		
	}
	
}