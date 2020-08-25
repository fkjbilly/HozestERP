using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class FavDetailVO {
		
		///<summary>
		/// 商品ID
		///</summary>
		
		private long? skuId_;
		
		///<summary>
		/// 金额
		///</summary>
		
		private string money_;
		
		///<summary>
		/// 赠品ID
		///</summary>
		
		private long? zpId_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private int? amount_;
		
		public long? GetSkuId(){
			return this.skuId_;
		}
		
		public void SetSkuId(long? value){
			this.skuId_ = value;
		}
		public string GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(string value){
			this.money_ = value;
		}
		public long? GetZpId(){
			return this.zpId_;
		}
		
		public void SetZpId(long? value){
			this.zpId_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		
	}
	
}