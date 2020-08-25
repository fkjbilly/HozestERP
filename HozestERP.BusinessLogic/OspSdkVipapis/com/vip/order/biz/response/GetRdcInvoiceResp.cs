using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetRdcInvoiceResp {
		
		///<summary>
		/// 返回结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		///</summary>
		
		private List<com.vip.order.biz.response.RdcInvoiceVO> rdcInvoiceVOList_;
		
		///<summary>
		///</summary>
		
		private List<string> failOrderSnList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.biz.response.RdcInvoiceVO> GetRdcInvoiceVOList(){
			return this.rdcInvoiceVOList_;
		}
		
		public void SetRdcInvoiceVOList(List<com.vip.order.biz.response.RdcInvoiceVO> value){
			this.rdcInvoiceVOList_ = value;
		}
		public List<string> GetFailOrderSnList(){
			return this.failOrderSnList_;
		}
		
		public void SetFailOrderSnList(List<string> value){
			this.failOrderSnList_ = value;
		}
		
	}
	
}