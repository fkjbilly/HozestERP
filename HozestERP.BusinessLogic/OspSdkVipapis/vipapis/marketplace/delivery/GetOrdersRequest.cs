using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class GetOrdersRequest {
		
		///<summary>
		/// 订单状态. 10:订单已审核, 22:订单已发货, 25:已签收, , 70:已拒收, 97:订单已取消
		///</summary>
		
		private List<string> status_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private List<string> order_ids_;
		
		///<summary>
		/// 导出状态,0:未导出 1：已导出 2：全部
		///</summary>
		
		private string is_export_;
		
		///<summary>
		/// 查询时间段的开始时间,最多支持最近3个月内的订单查询,默认返回最近一个月内的订单,格式:yyyy-MM-dd HH:mm:SS，如'2018-03-01 10:01:30'
		///</summary>
		
		private string query_start_time_;
		
		///<summary>
		/// 查询时间段的结束时间,最多支持最近3个月内的订单查询,格式:yyyy-MM-dd HH:mm:SS，如'2018-03-030 10:01:30'
		///</summary>
		
		private string query_end_time_;
		
		///<summary>
		/// 查询时间类型，默认按修改时间查询。1为按订单创建时间查询；其它数字为按订单最后修改时间 
		///</summary>
		
		private int? date_type_;
		
		///<summary>
		/// 每页数量，默认50 最大200
		///</summary>
		
		private int? limit_;
		
		///<summary>
		/// 页数
		///</summary>
		
		private int? page_;
		
		public List<string> GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(List<string> value){
			this.status_ = value;
		}
		public List<string> GetOrder_ids(){
			return this.order_ids_;
		}
		
		public void SetOrder_ids(List<string> value){
			this.order_ids_ = value;
		}
		public string GetIs_export(){
			return this.is_export_;
		}
		
		public void SetIs_export(string value){
			this.is_export_ = value;
		}
		public string GetQuery_start_time(){
			return this.query_start_time_;
		}
		
		public void SetQuery_start_time(string value){
			this.query_start_time_ = value;
		}
		public string GetQuery_end_time(){
			return this.query_end_time_;
		}
		
		public void SetQuery_end_time(string value){
			this.query_end_time_ = value;
		}
		public int? GetDate_type(){
			return this.date_type_;
		}
		
		public void SetDate_type(int? value){
			this.date_type_ = value;
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