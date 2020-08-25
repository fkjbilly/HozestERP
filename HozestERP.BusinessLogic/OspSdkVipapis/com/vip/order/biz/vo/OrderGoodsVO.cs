using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.vo{
	
	
	
	
	
	public class OrderGoodsVO {
		
		///<summary>
		/// 订单商品ID
		///</summary>
		
		private long? orderGoodsId_;
		
		///<summary>
		/// 商品id(对应:merchandise_id)
		///</summary>
		
		private long? merchandiseNo_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 价格ID
		///</summary>
		
		private long? priceId_;
		
		///<summary>
		/// 商品SKU
		///</summary>
		
		private long? skuId_;
		
		///<summary>
		/// 商品版本
		///</summary>
		
		private int? goodsVersion_;
		
		///<summary>
		/// 档期、专场的id(对应：brand_id)
		///</summary>
		
		private long? salesNo_;
		
		///<summary>
		/// 档期、专场的SKU id(对应：size_id)
		///</summary>
		
		private long? merItemNo_;
		
		///<summary>
		/// 条码
		///</summary>
		
		private string sn_;
		
		///<summary>
		/// 商品售价
		///</summary>
		
		private string sellPrice_;
		
		///<summary>
		/// 商品类型
		///</summary>
		
		private int? goodsType_;
		
		///<summary>
		/// 礼品id
		///</summary>
		
		private int? presentId_;
		
		///<summary>
		/// 礼品名称
		///</summary>
		
		private string presentName_;
		
		///<summary>
		/// 商品备注
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 是否删除标志
		///</summary>
		
		private int? isDelete_;
		
		///<summary>
		/// 活动优惠(单件)
		///</summary>
		
		private string exActSubtotal_;
		
		///<summary>
		/// 支付优惠(单件)
		///</summary>
		
		private string exCouponSubTotal_;
		
		///<summary>
		/// 支付优惠(单件)
		///</summary>
		
		private string exPaySubtotal_;
		
		///<summary>
		/// 优惠总金额（单件）
		///</summary>
		
		private string exAllSubtotal_;
		
		///<summary>
		/// OXO子订单号
		///</summary>
		
		private string subOrderSn_;
		
		///<summary>
		/// 商品状态
		///</summary>
		
		private int? goodsStatus_;
		
		///<summary>
		/// 购买商品总数量
		///</summary>
		
		private int? totalAomunt_;
		
		///<summary>
		/// 商品销售模式
		///</summary>
		
		private int? saleStyle_;
		
		///<summary>
		/// 商品档期所在仓
		///</summary>
		
		private string brandWarehouse_;
		
		///<summary>
		/// 海淘发货仓
		///</summary>
		
		private string bondedWarehouse_;
		
		///<summary>
		/// 成单仓库
		///</summary>
		
		private string orderWarehouse_;
		
		///<summary>
		/// 商品销售模式,取自sales-query,接口batchGetMerItemInfo的main_sales_style字段
		///</summary>
		
		private int? defaultSaleStyle_;
		
		public long? GetOrderGoodsId(){
			return this.orderGoodsId_;
		}
		
		public void SetOrderGoodsId(long? value){
			this.orderGoodsId_ = value;
		}
		public long? GetMerchandiseNo(){
			return this.merchandiseNo_;
		}
		
		public void SetMerchandiseNo(long? value){
			this.merchandiseNo_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public long? GetPriceId(){
			return this.priceId_;
		}
		
		public void SetPriceId(long? value){
			this.priceId_ = value;
		}
		public long? GetSkuId(){
			return this.skuId_;
		}
		
		public void SetSkuId(long? value){
			this.skuId_ = value;
		}
		public int? GetGoodsVersion(){
			return this.goodsVersion_;
		}
		
		public void SetGoodsVersion(int? value){
			this.goodsVersion_ = value;
		}
		public long? GetSalesNo(){
			return this.salesNo_;
		}
		
		public void SetSalesNo(long? value){
			this.salesNo_ = value;
		}
		public long? GetMerItemNo(){
			return this.merItemNo_;
		}
		
		public void SetMerItemNo(long? value){
			this.merItemNo_ = value;
		}
		public string GetSn(){
			return this.sn_;
		}
		
		public void SetSn(string value){
			this.sn_ = value;
		}
		public string GetSellPrice(){
			return this.sellPrice_;
		}
		
		public void SetSellPrice(string value){
			this.sellPrice_ = value;
		}
		public int? GetGoodsType(){
			return this.goodsType_;
		}
		
		public void SetGoodsType(int? value){
			this.goodsType_ = value;
		}
		public int? GetPresentId(){
			return this.presentId_;
		}
		
		public void SetPresentId(int? value){
			this.presentId_ = value;
		}
		public string GetPresentName(){
			return this.presentName_;
		}
		
		public void SetPresentName(string value){
			this.presentName_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public int? GetIsDelete(){
			return this.isDelete_;
		}
		
		public void SetIsDelete(int? value){
			this.isDelete_ = value;
		}
		public string GetExActSubtotal(){
			return this.exActSubtotal_;
		}
		
		public void SetExActSubtotal(string value){
			this.exActSubtotal_ = value;
		}
		public string GetExCouponSubTotal(){
			return this.exCouponSubTotal_;
		}
		
		public void SetExCouponSubTotal(string value){
			this.exCouponSubTotal_ = value;
		}
		public string GetExPaySubtotal(){
			return this.exPaySubtotal_;
		}
		
		public void SetExPaySubtotal(string value){
			this.exPaySubtotal_ = value;
		}
		public string GetExAllSubtotal(){
			return this.exAllSubtotal_;
		}
		
		public void SetExAllSubtotal(string value){
			this.exAllSubtotal_ = value;
		}
		public string GetSubOrderSn(){
			return this.subOrderSn_;
		}
		
		public void SetSubOrderSn(string value){
			this.subOrderSn_ = value;
		}
		public int? GetGoodsStatus(){
			return this.goodsStatus_;
		}
		
		public void SetGoodsStatus(int? value){
			this.goodsStatus_ = value;
		}
		public int? GetTotalAomunt(){
			return this.totalAomunt_;
		}
		
		public void SetTotalAomunt(int? value){
			this.totalAomunt_ = value;
		}
		public int? GetSaleStyle(){
			return this.saleStyle_;
		}
		
		public void SetSaleStyle(int? value){
			this.saleStyle_ = value;
		}
		public string GetBrandWarehouse(){
			return this.brandWarehouse_;
		}
		
		public void SetBrandWarehouse(string value){
			this.brandWarehouse_ = value;
		}
		public string GetBondedWarehouse(){
			return this.bondedWarehouse_;
		}
		
		public void SetBondedWarehouse(string value){
			this.bondedWarehouse_ = value;
		}
		public string GetOrderWarehouse(){
			return this.orderWarehouse_;
		}
		
		public void SetOrderWarehouse(string value){
			this.orderWarehouse_ = value;
		}
		public int? GetDefaultSaleStyle(){
			return this.defaultSaleStyle_;
		}
		
		public void SetDefaultSaleStyle(int? value){
			this.defaultSaleStyle_ = value;
		}
		
	}
	
}