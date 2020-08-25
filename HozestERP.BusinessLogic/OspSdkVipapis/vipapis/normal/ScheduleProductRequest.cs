using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class ScheduleProductRequest {
		
		///<summary>
		/// 供应商ID
		/// @sampleValue vendor_id 550
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 供应商仓库代码
		///</summary>
		
		private string warehouse_supplier_;
		
		///<summary>
		/// 查询商品
		///</summary>
		
		private List<vipapis.normal.ScheduleProduct> scheduleProductList_;
		
		///<summary>
		/// 查询时间段的开始时间，返回商品信息同步到VOP数据库的时间在此时间段的结果（Epoch格式）
		/// @sampleValue st_create_time 1473385970
		///</summary>
		
		private long? st_create_time_;
		
		///<summary>
		/// 查询时间段的结束时间，返回商品信息同步到VOP数据库的时间在此时间段的结果（Epoch格式
		/// @sampleValue et_create_time 1473385970
		///</summary>
		
		private long? et_create_time_;
		
		///<summary>
		/// 每页返回记录数,最多200条
		///</summary>
		
		private int? limit_;
		
		///<summary>
		/// 页码
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 常态合作编码
		///</summary>
		
		private int? cooperation_no_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetWarehouse_supplier(){
			return this.warehouse_supplier_;
		}
		
		public void SetWarehouse_supplier(string value){
			this.warehouse_supplier_ = value;
		}
		public List<vipapis.normal.ScheduleProduct> GetScheduleProductList(){
			return this.scheduleProductList_;
		}
		
		public void SetScheduleProductList(List<vipapis.normal.ScheduleProduct> value){
			this.scheduleProductList_ = value;
		}
		public long? GetSt_create_time(){
			return this.st_create_time_;
		}
		
		public void SetSt_create_time(long? value){
			this.st_create_time_ = value;
		}
		public long? GetEt_create_time(){
			return this.et_create_time_;
		}
		
		public void SetEt_create_time(long? value){
			this.et_create_time_ = value;
		}
		public int? GetLimit(){
			return this.limit_;
		}
		
		public void SetLimit(int? value){
			this.limit_ = value;
		}
		public int? GetPage(){
			return this.page_;
		}
		
		public void SetPage(int? value){
			this.page_ = value;
		}
		public int? GetCooperation_no(){
			return this.cooperation_no_;
		}
		
		public void SetCooperation_no(int? value){
			this.cooperation_no_ = value;
		}
		
	}
	
}