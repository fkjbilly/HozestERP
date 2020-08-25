using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class DeliveryBox {
		
		///<summary>
		/// 送货单主键ID
		///</summary>
		
		private long? deliveryId_;
		
		///<summary>
		/// 箱号
		///</summary>
		
		private string boxNo_;
		
		///<summary>
		/// 装箱数
		///</summary>
		
		private int? boxedQuantity_;
		
		public long? GetDeliveryId(){
			return this.deliveryId_;
		}
		
		public void SetDeliveryId(long? value){
			this.deliveryId_ = value;
		}
		public string GetBoxNo(){
			return this.boxNo_;
		}
		
		public void SetBoxNo(string value){
			this.boxNo_ = value;
		}
		public int? GetBoxedQuantity(){
			return this.boxedQuantity_;
		}
		
		public void SetBoxedQuantity(int? value){
			this.boxedQuantity_ = value;
		}
		
	}
	
}