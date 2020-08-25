using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetPoOrdersResponse {
		
		///<summary>
		/// 商品清单列表
		///</summary>
		
		private List<vipapis.delivery.PoOrder> po_orders_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.delivery.PoOrder> GetPo_orders(){
			return this.po_orders_;
		}
		
		public void SetPo_orders(List<vipapis.delivery.PoOrder> value){
			this.po_orders_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}