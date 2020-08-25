using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class BatchModifyOrderInvoiceResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 发票信息修改结果明细
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.ModifyOrderInvoiceRespVO> detailList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.ModifyOrderInvoiceRespVO> GetDetailList(){
			return this.detailList_;
		}
		
		public void SetDetailList(List<com.vip.order.common.pojo.order.vo.ModifyOrderInvoiceRespVO> value){
			this.detailList_ = value;
		}
		
	}
	
}