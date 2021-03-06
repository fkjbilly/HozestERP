using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.loading.osp.service{
	
	
	
	
	
	public class FailOrders {
		
		///<summary>
		/// 失败订单号
		/// @sampleValue orderSn 16002201690754
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 返回失败订单状态码
		/// @sampleValue bizResponseCode B04
		///</summary>
		
		private string bizResponseCode_;
		
		///<summary>
		/// 返回失败订单信息
		/// @sampleValue bizResponseMsg 请求的订单号:16002201690754 不存在
		///</summary>
		
		private string bizResponseMsg_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetBizResponseCode(){
			return this.bizResponseCode_;
		}
		
		public void SetBizResponseCode(string value){
			this.bizResponseCode_ = value;
		}
		public string GetBizResponseMsg(){
			return this.bizResponseMsg_;
		}
		
		public void SetBizResponseMsg(string value){
			this.bizResponseMsg_ = value;
		}
		
	}
	
}