using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class CreateDeliveryResponse {
		
		///<summary>
		/// 出仓单号
		///</summary>
		
		private string storageNo_;
		
		///<summary>
		/// 出仓单ID
		///</summary>
		
		private string deliveryId_;
		
		public string GetStorageNo(){
			return this.storageNo_;
		}
		
		public void SetStorageNo(string value){
			this.storageNo_ = value;
		}
		public string GetDeliveryId(){
			return this.deliveryId_;
		}
		
		public void SetDeliveryId(string value){
			this.deliveryId_ = value;
		}
		
	}
	
}