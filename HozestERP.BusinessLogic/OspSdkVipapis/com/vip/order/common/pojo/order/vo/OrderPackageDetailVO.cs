using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderPackageDetailVO {
		
		///<summary>
		/// 档期、专场的SKU id(原m_size_id,订单DB字段名size_id)
		///</summary>
		
		private long? merItemNo_;
		
		///<summary>
		/// 商品编号
		///</summary>
		
		private string sizeSn_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 商品SKU
		///</summary>
		
		private long? vSkuId_;
		
		///<summary>
		/// 商品版本
		///</summary>
		
		private int? goodsVersion_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string skuName_;
		
		///<summary>
		/// 规格名称
		///</summary>
		
		private string sizeName_;
		
		///<summary>
		/// 档期、专场ID(原brand_id)
		///</summary>
		
		private long? salesNo_;
		
		///<summary>
		/// 档期、专场名称(原brand_name)
		///</summary>
		
		private string salesName_;
		
		public long? GetMerItemNo(){
			return this.merItemNo_;
		}
		
		public void SetMerItemNo(long? value){
			this.merItemNo_ = value;
		}
		public string GetSizeSn(){
			return this.sizeSn_;
		}
		
		public void SetSizeSn(string value){
			this.sizeSn_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public long? GetVSkuId(){
			return this.vSkuId_;
		}
		
		public void SetVSkuId(long? value){
			this.vSkuId_ = value;
		}
		public int? GetGoodsVersion(){
			return this.goodsVersion_;
		}
		
		public void SetGoodsVersion(int? value){
			this.goodsVersion_ = value;
		}
		public string GetSkuName(){
			return this.skuName_;
		}
		
		public void SetSkuName(string value){
			this.skuName_ = value;
		}
		public string GetSizeName(){
			return this.sizeName_;
		}
		
		public void SetSizeName(string value){
			this.sizeName_ = value;
		}
		public long? GetSalesNo(){
			return this.salesNo_;
		}
		
		public void SetSalesNo(long? value){
			this.salesNo_ = value;
		}
		public string GetSalesName(){
			return this.salesName_;
		}
		
		public void SetSalesName(string value){
			this.salesName_ = value;
		}
		
	}
	
}