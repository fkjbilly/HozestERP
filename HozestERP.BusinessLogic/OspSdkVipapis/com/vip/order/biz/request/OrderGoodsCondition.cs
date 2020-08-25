using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class OrderGoodsCondition {
		
		///<summary>
		/// order_goods表的id
		///</summary>
		
		private List<long?> orderGoodsIdList_;
		
		///<summary>
		/// 档期ID
		///</summary>
		
		private int? brandId_;
		
		///<summary>
		/// 商品ID
		///</summary>
		
		private long? goodsId_;
		
		///<summary>
		/// 尺码ID
		///</summary>
		
		private int? sizeId_;
		
		///<summary>
		/// 商品状态
		///</summary>
		
		private string goodsStatus_;
		
		///<summary>
		/// 商品类型
		///</summary>
		
		private string goodsType_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private string goodsCount_;
		
		///<summary>
		/// 单价
		///</summary>
		
		private string price_;
		
		public List<long?> GetOrderGoodsIdList(){
			return this.orderGoodsIdList_;
		}
		
		public void SetOrderGoodsIdList(List<long?> value){
			this.orderGoodsIdList_ = value;
		}
		public int? GetBrandId(){
			return this.brandId_;
		}
		
		public void SetBrandId(int? value){
			this.brandId_ = value;
		}
		public long? GetGoodsId(){
			return this.goodsId_;
		}
		
		public void SetGoodsId(long? value){
			this.goodsId_ = value;
		}
		public int? GetSizeId(){
			return this.sizeId_;
		}
		
		public void SetSizeId(int? value){
			this.sizeId_ = value;
		}
		public string GetGoodsStatus(){
			return this.goodsStatus_;
		}
		
		public void SetGoodsStatus(string value){
			this.goodsStatus_ = value;
		}
		public string GetGoodsType(){
			return this.goodsType_;
		}
		
		public void SetGoodsType(string value){
			this.goodsType_ = value;
		}
		public string GetGoodsCount(){
			return this.goodsCount_;
		}
		
		public void SetGoodsCount(string value){
			this.goodsCount_ = value;
		}
		public string GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(string value){
			this.price_ = value;
		}
		
	}
	
}