using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetPickListResponse {
		
		///<summary>
		/// 拣货单信息列表
		///</summary>
		
		private List<vipapis.delivery.Pick> picks_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.delivery.Pick> GetPicks(){
			return this.picks_;
		}
		
		public void SetPicks(List<vipapis.delivery.Pick> value){
			this.picks_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}