using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderGoodsAndDescribeVO {
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderGoodsDescribeVO> orderGoodsDescribeList_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderGoodsVO orderGoods_;
		
		public List<com.vip.order.common.pojo.order.vo.OrderGoodsDescribeVO> GetOrderGoodsDescribeList(){
			return this.orderGoodsDescribeList_;
		}
		
		public void SetOrderGoodsDescribeList(List<com.vip.order.common.pojo.order.vo.OrderGoodsDescribeVO> value){
			this.orderGoodsDescribeList_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderGoodsVO GetOrderGoods(){
			return this.orderGoods_;
		}
		
		public void SetOrderGoods(com.vip.order.common.pojo.order.vo.OrderGoodsVO value){
			this.orderGoods_ = value;
		}
		
	}
	
}