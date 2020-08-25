using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class CancelReturnOrderResponse {
		
		///<summary>
		/// 退供/调拨单号
		///</summary>
		
		private string return_sn_;
		
		///<summary>
		/// 取消状态：1，取消成功；0，取消失败
		///</summary>
		
		private string response_code_;
		
		///<summary>
		/// 失败原因
		///</summary>
		
		private string remark_;
		
		public string GetReturn_sn(){
			return this.return_sn_;
		}
		
		public void SetReturn_sn(string value){
			this.return_sn_ = value;
		}
		public string GetResponse_code(){
			return this.response_code_;
		}
		
		public void SetResponse_code(string value){
			this.response_code_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		
	}
	
}