using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OrdersVo {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 交接状态, 1:成功   0:失败 不允许有其他值
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 交接时间,格式：yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string connectTime_;
		
		///<summary>
		/// 描述:一般指失败的原因
		///</summary>
		
		private string message_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public string GetConnectTime(){
			return this.connectTime_;
		}
		
		public void SetConnectTime(string value){
			this.connectTime_ = value;
		}
		public string GetMessage(){
			return this.message_;
		}
		
		public void SetMessage(string value){
			this.message_ = value;
		}
		
	}
	
}