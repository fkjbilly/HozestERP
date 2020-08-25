using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetPickFinancialDataResponse {
		
		///<summary>
		/// 采购档期号
		///</summary>
		
		private string schedule_id_;
		
		///<summary>
		/// 销售明细数据列表
		///</summary>
		
		private List<vipapis.delivery.OrderDetail> order_details_;
		
		///<summary>
		/// 记录总数
		///</summary>
		
		private int? total_;
		
		public string GetSchedule_id(){
			return this.schedule_id_;
		}
		
		public void SetSchedule_id(string value){
			this.schedule_id_ = value;
		}
		public List<vipapis.delivery.OrderDetail> GetOrder_details(){
			return this.order_details_;
		}
		
		public void SetOrder_details(List<vipapis.delivery.OrderDetail> value){
			this.order_details_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}