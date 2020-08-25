using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.dvd{
	
	
	
	
	
	public class AreaOccupiedOrdersRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private long? vendor_id_;
		
		///<summary>
		/// 常态合作编码
		///</summary>
		
		private int? cooperation_no_;
		
		///<summary>
		/// 查询时间段的开始时间，返回订单产生时间在此时间段内的结果（Epoch格式）
		///</summary>
		
		private long? st_query_time_;
		
		///<summary>
		/// 查询时间段的结束时间，返回订单产生时间在此时间段内的结果（Epoch格式）
		///</summary>
		
		private long? et_query_time_;
		
		///<summary>
		/// 订单类型：0-正向单 1-取消单
		///</summary>
		
		private int? order_type_;
		
		///<summary>
		/// 每页数量，默认20 最大50
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
		public int? GetCooperation_no(){
			return this.cooperation_no_;
		}
		
		public void SetCooperation_no(int? value){
			this.cooperation_no_ = value;
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
		public int? GetOrder_type(){
			return this.order_type_;
		}
		
		public void SetOrder_type(int? value){
			this.order_type_ = value;
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