using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class EditedPackage {
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transport_no_;
		
		///<summary>
		/// 旧运单号
		///</summary>
		
		private string old_transport_no_;
		
		public string GetTransport_no(){
			return this.transport_no_;
		}
		
		public void SetTransport_no(string value){
			this.transport_no_ = value;
		}
		public string GetOld_transport_no(){
			return this.old_transport_no_;
		}
		
		public void SetOld_transport_no(string value){
			this.old_transport_no_ = value;
		}
		
	}
	
}