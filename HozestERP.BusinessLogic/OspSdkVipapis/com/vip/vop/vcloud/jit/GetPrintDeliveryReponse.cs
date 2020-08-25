using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class GetPrintDeliveryReponse {
		
		///<summary>
		/// 打印页面信息（html）
		///</summary>
		
		private string template_;
		
		///<summary>
		/// 总记录数
		///</summary>
		
		private int? total_;
		
		public string GetTemplate(){
			return this.template_;
		}
		
		public void SetTemplate(string value){
			this.template_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}