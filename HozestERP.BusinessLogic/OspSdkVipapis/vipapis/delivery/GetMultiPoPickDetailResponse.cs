using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetMultiPoPickDetailResponse {
		
		///<summary>
		/// 拣货单商品信息
		///</summary>
		
		private List<vipapis.delivery.MultiPickDetailInfo> pick_detail_list_;
		
		///<summary>
		/// 总记录
		///</summary>
		
		private int? total_;
		
		public List<vipapis.delivery.MultiPickDetailInfo> GetPick_detail_list(){
			return this.pick_detail_list_;
		}
		
		public void SetPick_detail_list(List<vipapis.delivery.MultiPickDetailInfo> value){
			this.pick_detail_list_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}