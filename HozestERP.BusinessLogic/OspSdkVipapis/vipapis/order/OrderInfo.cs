using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OrderInfo {
		
		///<summary>
		/// 订单SN
		///</summary>
		
		private long? order_sn_;
		
		///<summary>
		/// 下单时间(Epoch格式, 精确到秒)
		///</summary>
		
		private int? order_time_;
		
		///<summary>
		/// 订单状态
		///</summary>
		
		private vipapis.common.OrderStatus? status_;
		
		///<summary>
		/// 订单商品
		///</summary>
		
		private List<vipapis.order.OrderGoods> goods_list_;
		
		public long? GetOrder_sn(){
			return this.order_sn_;
		}
		
		public void SetOrder_sn(long? value){
			this.order_sn_ = value;
		}
		public int? GetOrder_time(){
			return this.order_time_;
		}
		
		public void SetOrder_time(int? value){
			this.order_time_ = value;
		}
		public vipapis.common.OrderStatus? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(vipapis.common.OrderStatus? value){
			this.status_ = value;
		}
		public List<vipapis.order.OrderGoods> GetGoods_list(){
			return this.goods_list_;
		}
		
		public void SetGoods_list(List<vipapis.order.OrderGoods> value){
			this.goods_list_ = value;
		}
		
	}
	
}