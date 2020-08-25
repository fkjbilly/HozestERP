using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetReturnListResponse {
		
		///<summary>
		/// 退货信息列表
		///</summary>
		
		private List<vipapis.delivery.DvdReturn> dvd_return_list_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.delivery.DvdReturn> GetDvd_return_list(){
			return this.dvd_return_list_;
		}
		
		public void SetDvd_return_list(List<vipapis.delivery.DvdReturn> value){
			this.dvd_return_list_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}