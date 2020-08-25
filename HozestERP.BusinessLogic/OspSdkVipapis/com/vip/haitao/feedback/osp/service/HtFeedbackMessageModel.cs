using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.feedback.osp.service{
	
	
	
	
	
	public class HtFeedbackMessageModel {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 回执状态
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 回执描述
		///</summary>
		
		private string detail_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public string GetDetail(){
			return this.detail_;
		}
		
		public void SetDetail(string value){
			this.detail_ = value;
		}
		
	}
	
}