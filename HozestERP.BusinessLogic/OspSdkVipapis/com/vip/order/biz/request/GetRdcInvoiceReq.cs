using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetRdcInvoiceReq {
		
		///<summary>
		///</summary>
		
		private List<com.vip.order.biz.request.RdcParamVO> rdcParamVOList_;
		
		public List<com.vip.order.biz.request.RdcParamVO> GetRdcParamVOList(){
			return this.rdcParamVOList_;
		}
		
		public void SetRdcParamVOList(List<com.vip.order.biz.request.RdcParamVO> value){
			this.rdcParamVOList_ = value;
		}
		
	}
	
}