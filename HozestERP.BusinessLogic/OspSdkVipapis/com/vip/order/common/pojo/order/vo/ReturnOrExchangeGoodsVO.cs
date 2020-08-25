using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class ReturnOrExchangeGoodsVO {
		
		///<summary>
		/// 商品id(对应:merchandise_id)
		///</summary>
		
		private long? merchandiseNo_;
		
		///<summary>
		/// 档期、专场的SKU id(对应：size_id)
		///</summary>
		
		private long? merItemNo_;
		
		///<summary>
		/// 条码
		///</summary>
		
		private string sn_;
		
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
		/// 商品售价
		///</summary>
		
		private string sellPrice_;
		
		///<summary>
		/// 商品类型
		///</summary>
		
		private int? goodsType_;
		
		///<summary>
		/// 不可操作原因状态码
		///</summary>
		
		private string reasonCode_;
		
		///<summary>
		/// 不可操作原因
		///</summary>
		
		private string reason_;
		
		///<summary>
		/// 可换货商品列表，该字段只对普通换，上门揽换（闪电换）有效
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.ExchangeGoodsStockVO> exchangeGoodsStockList_;
		
		///<summary>
		/// 活动优惠(单件)
		///</summary>
		
		private string exActSubtotal_;
		
		public long? GetMerchandiseNo(){
			return this.merchandiseNo_;
		}
		
		public void SetMerchandiseNo(long? value){
			this.merchandiseNo_ = value;
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
		public string GetReasonCode(){
			return this.reasonCode_;
		}
		
		public void SetReasonCode(string value){
			this.reasonCode_ = value;
		}
		public string GetReason(){
			return this.reason_;
		}
		
		public void SetReason(string value){
			this.reason_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.ExchangeGoodsStockVO> GetExchangeGoodsStockList(){
			return this.exchangeGoodsStockList_;
		}
		
		public void SetExchangeGoodsStockList(List<com.vip.order.common.pojo.order.vo.ExchangeGoodsStockVO> value){
			this.exchangeGoodsStockList_ = value;
		}
		public string GetExActSubtotal(){
			return this.exActSubtotal_;
		}
		
		public void SetExActSubtotal(string value){
			this.exActSubtotal_ = value;
		}
		
	}
	
}