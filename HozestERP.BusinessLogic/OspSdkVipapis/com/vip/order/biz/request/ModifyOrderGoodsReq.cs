using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class ModifyOrderGoodsReq {
		
		///<summary>
		/// 订单类别 
		///</summary>
		
		private byte? orderCategory_;
		
		///<summary>
		/// 订单信息
		///</summary>
		
		private com.vip.order.biz.request.ModifyGoodsOrder modifyGoodsOrder_;
		
		///<summary>
		/// 商品列表 
		///</summary>
		
		private List<com.vip.order.biz.request.NewGoodsInfo> goodsInfoList_;
		
		///<summary>
		/// 收货地址信息 
		///</summary>
		
		private com.vip.order.biz.request.ReceiveAddressInfo receiveAddressInfo_;
		
		///<summary>
		/// PMS信息
		///</summary>
		
		private com.vip.order.biz.request.PmsInfo pmsInfo_;
		
		///<summary>
		/// 支付信息
		///</summary>
		
		private com.vip.order.biz.request.PayAndDiscount payAndDiscount_;
		
		///<summary>
		/// 发票信息
		///</summary>
		
		private com.vip.order.biz.request.InvoiceInfo invoiceInfo_;
		
		///<summary>
		/// 会员来源
		///</summary>
		
		private string customerSrc_;
		
		///<summary>
		/// 是否强制生成一张新订单，前台默认强制生成。值为“true”代表强制生成，false或不传代表不生成
		///</summary>
		
		private bool? isCreateNewOrder_;
		
		///<summary>
		/// 是否满减修改，值为“true”代表是，不传或者值为“false”代表遵循默认规则[一般用于超卖的情况下]
		///</summary>
		
		private bool? isManjianEdit_;
		
		public byte? GetOrderCategory(){
			return this.orderCategory_;
		}
		
		public void SetOrderCategory(byte? value){
			this.orderCategory_ = value;
		}
		public com.vip.order.biz.request.ModifyGoodsOrder GetModifyGoodsOrder(){
			return this.modifyGoodsOrder_;
		}
		
		public void SetModifyGoodsOrder(com.vip.order.biz.request.ModifyGoodsOrder value){
			this.modifyGoodsOrder_ = value;
		}
		public List<com.vip.order.biz.request.NewGoodsInfo> GetGoodsInfoList(){
			return this.goodsInfoList_;
		}
		
		public void SetGoodsInfoList(List<com.vip.order.biz.request.NewGoodsInfo> value){
			this.goodsInfoList_ = value;
		}
		public com.vip.order.biz.request.ReceiveAddressInfo GetReceiveAddressInfo(){
			return this.receiveAddressInfo_;
		}
		
		public void SetReceiveAddressInfo(com.vip.order.biz.request.ReceiveAddressInfo value){
			this.receiveAddressInfo_ = value;
		}
		public com.vip.order.biz.request.PmsInfo GetPmsInfo(){
			return this.pmsInfo_;
		}
		
		public void SetPmsInfo(com.vip.order.biz.request.PmsInfo value){
			this.pmsInfo_ = value;
		}
		public com.vip.order.biz.request.PayAndDiscount GetPayAndDiscount(){
			return this.payAndDiscount_;
		}
		
		public void SetPayAndDiscount(com.vip.order.biz.request.PayAndDiscount value){
			this.payAndDiscount_ = value;
		}
		public com.vip.order.biz.request.InvoiceInfo GetInvoiceInfo(){
			return this.invoiceInfo_;
		}
		
		public void SetInvoiceInfo(com.vip.order.biz.request.InvoiceInfo value){
			this.invoiceInfo_ = value;
		}
		public string GetCustomerSrc(){
			return this.customerSrc_;
		}
		
		public void SetCustomerSrc(string value){
			this.customerSrc_ = value;
		}
		public bool? GetIsCreateNewOrder(){
			return this.isCreateNewOrder_;
		}
		
		public void SetIsCreateNewOrder(bool? value){
			this.isCreateNewOrder_ = value;
		}
		public bool? GetIsManjianEdit(){
			return this.isManjianEdit_;
		}
		
		public void SetIsManjianEdit(bool? value){
			this.isManjianEdit_ = value;
		}
		
	}
	
}