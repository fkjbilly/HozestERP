using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class BatchUpdateWmsFlagReq {
		
		///<summary>
		/// 用户ID列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> orderSnAndIdVOList_;
		
		///<summary>
		/// 需要批量修改的状态，只能是1或者2
		///</summary>
		
		private int? flag_;
		
		public List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> GetOrderSnAndIdVOList(){
			return this.orderSnAndIdVOList_;
		}
		
		public void SetOrderSnAndIdVOList(List<com.vip.order.common.pojo.order.vo.OrderSnAndIdVO> value){
			this.orderSnAndIdVOList_ = value;
		}
		public int? GetFlag(){
			return this.flag_;
		}
		
		public void SetFlag(int? value){
			this.flag_ = value;
		}
		
	}
	
}