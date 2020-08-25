using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class Ht3plPoListResponse {
		
		///<summary>
		/// po信息
		///</summary>
		
		private List<vipapis.overseas.PoInfo> po_list_;
		
		///<summary>
		/// 返回po数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.overseas.PoInfo> GetPo_list(){
			return this.po_list_;
		}
		
		public void SetPo_list(List<vipapis.overseas.PoInfo> value){
			this.po_list_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}