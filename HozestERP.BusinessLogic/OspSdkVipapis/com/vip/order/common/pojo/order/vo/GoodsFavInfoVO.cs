using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class GoodsFavInfoVO {
		
		///<summary>
		/// 单件商品优惠金额，精度保留原始PMS提供的精度(6位小数)
		///</summary>
		
		private string unitDiscountMoney_;
		
		///<summary>
		/// 商品SKU Id(原size_id)
		///</summary>
		
		private long? merItemNo_;
		
		///<summary>
		/// 商品ID(原goods_id)
		///</summary>
		
		private long? merchandiseNo_;
		
		public string GetUnitDiscountMoney(){
			return this.unitDiscountMoney_;
		}
		
		public void SetUnitDiscountMoney(string value){
			this.unitDiscountMoney_ = value;
		}
		public long? GetMerItemNo(){
			return this.merItemNo_;
		}
		
		public void SetMerItemNo(long? value){
			this.merItemNo_ = value;
		}
		public long? GetMerchandiseNo(){
			return this.merchandiseNo_;
		}
		
		public void SetMerchandiseNo(long? value){
			this.merchandiseNo_ = value;
		}
		
	}
	
}