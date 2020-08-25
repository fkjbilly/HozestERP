using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.stock{
	
	
	
	
	
	public class GetVendorScheduleFreezeStock {
		
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
		/// @sampleValue schedule_id 447402
		///</summary>
		
		private string schedule_id_;
		
		///<summary>
		/// 查询开始时间
		/// @sampleValue start_date 2014-06-18 00:00:00
		///</summary>
		
		private string start_date_;
		
		///<summary>
		/// 查询结束时间
		/// @sampleValue end_date 2014-06-20 00:00:00
		///</summary>
		
		private string end_date_;
		
		///<summary>
		/// 页码
		/// @sampleValue page 1
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 每页记录数
		/// @sampleValue limit 10
		///</summary>
		
		private int? limit_;
		
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
		public string GetStart_date(){
			return this.start_date_;
		}
		
		public void SetStart_date(string value){
			this.start_date_ = value;
		}
		public string GetEnd_date(){
			return this.end_date_;
		}
		
		public void SetEnd_date(string value){
			this.end_date_ = value;
		}
		public int? GetPage(){
			return this.page_;
		}
		
		public void SetPage(int? value){
			this.page_ = value;
		}
		public int? GetLimit(){
			return this.limit_;
		}
		
		public void SetLimit(int? value){
			this.limit_ = value;
		}
		
	}
	
}