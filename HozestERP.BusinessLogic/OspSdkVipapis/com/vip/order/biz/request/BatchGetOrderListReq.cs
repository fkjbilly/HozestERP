using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class BatchGetOrderListReq {
		
		///<summary>
		/// 订单状态范围
		///</summary>
		
		private List<int?> orderTypeList_;
		
		///<summary>
		/// 数据库index,支持 0~127
		///</summary>
		
		private int? dbIndex_;
		
		///<summary>
		/// 是否包含逻辑删除的订单
		///</summary>
		
		private int? includeDeletedOrder_;
		
		///<summary>
		/// 订单状态范围
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam orderStatusRange_;
		
		///<summary>
		/// 下单日期范围
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam orderDateRange_;
		
		///<summary>
		/// 下单时间范围
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam orderTimeRange_;
		
		public List<int?> GetOrderTypeList(){
			return this.orderTypeList_;
		}
		
		public void SetOrderTypeList(List<int?> value){
			this.orderTypeList_ = value;
		}
		public int? GetDbIndex(){
			return this.dbIndex_;
		}
		
		public void SetDbIndex(int? value){
			this.dbIndex_ = value;
		}
		public int? GetIncludeDeletedOrder(){
			return this.includeDeletedOrder_;
		}
		
		public void SetIncludeDeletedOrder(int? value){
			this.includeDeletedOrder_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetOrderStatusRange(){
			return this.orderStatusRange_;
		}
		
		public void SetOrderStatusRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.orderStatusRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetOrderDateRange(){
			return this.orderDateRange_;
		}
		
		public void SetOrderDateRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.orderDateRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetOrderTimeRange(){
			return this.orderTimeRange_;
		}
		
		public void SetOrderTimeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.orderTimeRange_ = value;
		}
		
	}
	
}