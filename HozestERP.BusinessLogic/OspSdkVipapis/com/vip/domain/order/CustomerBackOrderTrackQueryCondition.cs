using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.order{
	
	
	
	
	
	public class CustomerBackOrderTrackQueryCondition {
		
		///<summary>
		/// ERP客退单号
		///</summary>
		
		private string erp_back_sn_;
		
		public string GetErp_back_sn(){
			return this.erp_back_sn_;
		}
		
		public void SetErp_back_sn(string value){
			this.erp_back_sn_ = value;
		}
		
	}
	
}