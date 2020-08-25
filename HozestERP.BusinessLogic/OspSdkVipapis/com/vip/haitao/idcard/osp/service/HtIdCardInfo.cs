using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.idcard.osp.service{
	
	
	
	
	
	public class HtIdCardInfo {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 证件类型
		///</summary>
		
		private int? idCardType_;
		
		///<summary>
		/// 照片正面（有图像的一面）
		///</summary>
		
		private string imageFront_;
		
		///<summary>
		/// 照片背面（有有效期的一面）
		///</summary>
		
		private string imageBack_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public int? GetIdCardType(){
			return this.idCardType_;
		}
		
		public void SetIdCardType(int? value){
			this.idCardType_ = value;
		}
		public string GetImageFront(){
			return this.imageFront_;
		}
		
		public void SetImageFront(string value){
			this.imageFront_ = value;
		}
		public string GetImageBack(){
			return this.imageBack_;
		}
		
		public void SetImageBack(string value){
			this.imageBack_ = value;
		}
		
	}
	
}