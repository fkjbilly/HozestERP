using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.omni.wo{
	
	
	
	
	
	public class OxoOrderCarrierInfo {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 业务类型(1.oxo-jit,2.仓中仓,3.oxo直发)
		///</summary>
		
		private byte? businessType_;
		
		///<summary>
		/// 是否已经下发承运商
		///</summary>
		
		private bool? isDelivered_;
		
		///<summary>
		/// 承运商
		///</summary>
		
		private string carrier_;
		
		///<summary>
		/// 承运商编码
		///</summary>
		
		private string carrierCode_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public byte? GetBusinessType(){
			return this.businessType_;
		}
		
		public void SetBusinessType(byte? value){
			this.businessType_ = value;
		}
		public bool? GetIsDelivered(){
			return this.isDelivered_;
		}
		
		public void SetIsDelivered(bool? value){
			this.isDelivered_ = value;
		}
		public string GetCarrier(){
			return this.carrier_;
		}
		
		public void SetCarrier(string value){
			this.carrier_ = value;
		}
		public string GetCarrierCode(){
			return this.carrierCode_;
		}
		
		public void SetCarrierCode(string value){
			this.carrierCode_ = value;
		}
		
	}
	
}