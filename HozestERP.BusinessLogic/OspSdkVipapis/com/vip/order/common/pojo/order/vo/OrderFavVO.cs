using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderFavVO {
		
		///<summary>
		/// 订单sn
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 优惠列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.FavVO> favList_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.FavVO> GetFavList(){
			return this.favList_;
		}
		
		public void SetFavList(List<com.vip.order.common.pojo.order.vo.FavVO> value){
			this.favList_ = value;
		}
		
	}
	
}