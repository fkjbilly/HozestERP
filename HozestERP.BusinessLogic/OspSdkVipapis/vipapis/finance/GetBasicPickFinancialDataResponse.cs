using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.finance{
	
	
	
	
	
	public class GetBasicPickFinancialDataResponse {
		
		///<summary>
		/// 采购档期号
		///</summary>
		
		private string schedule_id_;
		
		///<summary>
		/// 记录总数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 销售订单详情列表
		///</summary>
		
		private List<vipapis.finance.SalesOrderDetail> sales_order_details_;
		
		public string GetSchedule_id(){
			return this.schedule_id_;
		}
		
		public void SetSchedule_id(string value){
			this.schedule_id_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<vipapis.finance.SalesOrderDetail> GetSales_order_details(){
			return this.sales_order_details_;
		}
		
		public void SetSales_order_details(List<vipapis.finance.SalesOrderDetail> value){
			this.sales_order_details_ = value;
		}
		
	}
	
}