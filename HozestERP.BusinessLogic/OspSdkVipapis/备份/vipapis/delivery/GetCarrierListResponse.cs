using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetCarrierListResponse {
		
		///<summary>
		/// 承运商信息
		///</summary>
		
		private List<vipapis.delivery.Carrier> carriers_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.delivery.Carrier> GetCarriers(){
			return this.carriers_;
		}
		
		public void SetCarriers(List<vipapis.delivery.Carrier> value){
			this.carriers_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}