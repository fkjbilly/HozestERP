using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class InventoryOccupiedOrdersRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private long? vendor_id_;
		
		///<summary>
		/// 品牌ID
		///</summary>
		
		private long? brand_id_;
		
		///<summary>
		/// 查询时间段的开始时间，返回订单产生时间在此时间段内的结果（Epoch格式）
		///</summary>
		
		private long? st_query_time_;
		
		///<summary>
		/// 查询时间段的结束时间，返回订单产生时间在此时间段内的结果（Epoch格式）
		///</summary>
		
		private long? et_query_time_;
		
		///<summary>
		/// <s><font color='red'>订单状态  0、占用，1、取消(已作废)</font><s>参数无失效，仅返回占用订单
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 每页数量，默认50 最大200
		///</summary>
		
		private int? limit_;
		
		///<summary>
		/// 页码 默认1
		///</summary>
		
		private int? page_;
		
		public long? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(long? value){
			this.vendor_id_ = value;
		}
		public long? GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(long? value){
			this.brand_id_ = value;
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
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
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