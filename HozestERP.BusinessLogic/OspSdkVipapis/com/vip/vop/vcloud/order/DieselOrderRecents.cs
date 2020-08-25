using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.order{
	
	
	
	
	
	public class DieselOrderRecents {
		
		///<summary>
		/// type
		///</summary>
		
		private string type_;
		
		///<summary>
		/// incrementId
		///</summary>
		
		private string incrementId_;
		
		///<summary>
		/// orderIncrementId
		///</summary>
		
		private string orderIncrementId_;
		
		public string GetType(){
			return this.type_;
		}
		
		public void SetType(string value){
			this.type_ = value;
		}
		public string GetIncrementId(){
			return this.incrementId_;
		}
		
		public void SetIncrementId(string value){
			this.incrementId_ = value;
		}
		public string GetOrderIncrementId(){
			return this.orderIncrementId_;
		}
		
		public void SetOrderIncrementId(string value){
			this.orderIncrementId_ = value;
		}
		
	}
	
}