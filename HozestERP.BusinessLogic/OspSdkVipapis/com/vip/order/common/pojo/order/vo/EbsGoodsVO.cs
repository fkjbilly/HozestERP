using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class EbsGoodsVO {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 订单商品状态
		///</summary>
		
		private int? goodsStatus_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string sizeSn_;
		
		///<summary>
		/// 档期id
		///</summary>
		
		private string brandId_;
		
		///<summary>
		/// 商品条码对应的档期
		///</summary>
		
		private string mimsId_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public int? GetGoodsStatus(){
			return this.goodsStatus_;
		}
		
		public void SetGoodsStatus(int? value){
			this.goodsStatus_ = value;
		}
		public string GetSizeSn(){
			return this.sizeSn_;
		}
		
		public void SetSizeSn(string value){
			this.sizeSn_ = value;
		}
		public string GetBrandId(){
			return this.brandId_;
		}
		
		public void SetBrandId(string value){
			this.brandId_ = value;
		}
		public string GetMimsId(){
			return this.mimsId_;
		}
		
		public void SetMimsId(string value){
			this.mimsId_ = value;
		}
		
	}
	
}