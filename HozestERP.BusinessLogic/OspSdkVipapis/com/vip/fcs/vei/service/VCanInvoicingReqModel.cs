using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class VCanInvoicingReqModel {
		
		///<summary>
		/// 商品类型
		///</summary>
		
		private string merchandiseType_;
		
		public string GetMerchandiseType(){
			return this.merchandiseType_;
		}
		
		public void SetMerchandiseType(string value){
			this.merchandiseType_ = value;
		}
		
	}
	
}