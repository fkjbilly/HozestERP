using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class LinkageCancelOrderInfo {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 退还品牌卷状态
		///</summary>
		
		private byte? returnBrandCouponStatus_;
		
		///<summary>
		/// 退款类型
		///</summary>
		
		private byte? returnType_;
		
		///<summary>
		/// 退还品牌卷状态
		///</summary>
		
		private com.vip.order.biz.response.PreviewInfoResp previewInfo_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public byte? GetReturnBrandCouponStatus(){
			return this.returnBrandCouponStatus_;
		}
		
		public void SetReturnBrandCouponStatus(byte? value){
			this.returnBrandCouponStatus_ = value;
		}
		public byte? GetReturnType(){
			return this.returnType_;
		}
		
		public void SetReturnType(byte? value){
			this.returnType_ = value;
		}
		public com.vip.order.biz.response.PreviewInfoResp GetPreviewInfo(){
			return this.previewInfo_;
		}
		
		public void SetPreviewInfo(com.vip.order.biz.response.PreviewInfoResp value){
			this.previewInfo_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		
	}
	
}