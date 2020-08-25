using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetReturnProductResponse {
		
		///<summary>
		/// 退货商品信息列表
		///</summary>
		
		private List<vipapis.delivery.DvdReturnProduct> dvd_return_product_list_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.delivery.DvdReturnProduct> GetDvd_return_product_list(){
			return this.dvd_return_product_list_;
		}
		
		public void SetDvd_return_product_list(List<vipapis.delivery.DvdReturnProduct> value){
			this.dvd_return_product_list_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}