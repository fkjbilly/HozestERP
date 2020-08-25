using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class GoodsInfoModel {
		
		///<summary>
		/// 销售类型
		///</summary>
		
		private string saleType_;
		
		///<summary>
		/// 商品size id
		///</summary>
		
		private string merItemNo_;
		
		///<summary>
		/// 有库存占用号的商品为必传，没有则可不传
		///</summary>
		
		private string posNo_;
		
		///<summary>
		/// 是否赠品
		///</summary>
		
		private int? goodsType_;
		
		///<summary>
		/// 商品运营属性
		///</summary>
		
		private List<com.vip.fcs.vei.service.GoodsOptPropValue> goodsOptPropValueList_;
		
		///<summary>
		/// 是否属于MP第三方标志
		///</summary>
		
		private string storeSource_;
		
		///<summary>
		/// 第三方店铺ID
		///</summary>
		
		private string storeId_;
		
		public string GetSaleType(){
			return this.saleType_;
		}
		
		public void SetSaleType(string value){
			this.saleType_ = value;
		}
		public string GetMerItemNo(){
			return this.merItemNo_;
		}
		
		public void SetMerItemNo(string value){
			this.merItemNo_ = value;
		}
		public string GetPosNo(){
			return this.posNo_;
		}
		
		public void SetPosNo(string value){
			this.posNo_ = value;
		}
		public int? GetGoodsType(){
			return this.goodsType_;
		}
		
		public void SetGoodsType(int? value){
			this.goodsType_ = value;
		}
		public List<com.vip.fcs.vei.service.GoodsOptPropValue> GetGoodsOptPropValueList(){
			return this.goodsOptPropValueList_;
		}
		
		public void SetGoodsOptPropValueList(List<com.vip.fcs.vei.service.GoodsOptPropValue> value){
			this.goodsOptPropValueList_ = value;
		}
		public string GetStoreSource(){
			return this.storeSource_;
		}
		
		public void SetStoreSource(string value){
			this.storeSource_ = value;
		}
		public string GetStoreId(){
			return this.storeId_;
		}
		
		public void SetStoreId(string value){
			this.storeId_ = value;
		}
		
	}
	
}