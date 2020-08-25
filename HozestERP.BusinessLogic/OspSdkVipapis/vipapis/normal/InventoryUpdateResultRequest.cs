using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class InventoryUpdateResultRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 批次号(<font color='red'>不支持负数,相同供应商ID不允许重复，否则忽略重复请求</font>)
		/// @sampleValue batch_no 123
		///</summary>
		
		private int? batch_no_;
		
		///<summary>
		/// 查询时间段的开始时间，返回库存更新时间在此时间段内的结果（Epoch格式）
		///</summary>
		
		private long? st_query_time_;
		
		///<summary>
		/// 查询时间段的结束时间，返回库存更新时间在此时间段内的结果（Epoch格式）
		///</summary>
		
		private long? et_query_time_;
		
		///<summary>
		/// 每页查询条数（最大200条，默认200条
		///</summary>
		
		private int? limit_;
		
		///<summary>
		/// 页码
		///</summary>
		
		private int? page_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public int? GetBatch_no(){
			return this.batch_no_;
		}
		
		public void SetBatch_no(int? value){
			this.batch_no_ = value;
		}
		public long? GetSt_query_time(){
			return this.st_query_time_;
		}
		
		public void SetSt_query_time(long? value){
			this.st_query_time_ = value;
		}
		public long? GetEt_query_time(){
			return this.et_query_time_;
		}
		
		public void SetEt_query_time(long? value){
			this.et_query_time_ = value;
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
		
	}
	
}