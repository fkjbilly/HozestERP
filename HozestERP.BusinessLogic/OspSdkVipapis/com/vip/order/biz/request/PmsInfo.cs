using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class PmsInfo {
		
		///<summary>
		/// PMS券序列号[只支持免邮卷]
		///</summary>
		
		private string pmsTicketId_;
		
		///<summary>
		/// 是否免邮，值为“true”代表强制免邮，false或不传代表自动根据规则算运费
		///</summary>
		
		private bool? isFreeCarriage_;
		
		public string GetPmsTicketId(){
			return this.pmsTicketId_;
		}
		
		public void SetPmsTicketId(string value){
			this.pmsTicketId_ = value;
		}
		public bool? GetIsFreeCarriage(){
			return this.isFreeCarriage_;
		}
		
		public void SetIsFreeCarriage(bool? value){
			this.isFreeCarriage_ = value;
		}
		
	}
	
}