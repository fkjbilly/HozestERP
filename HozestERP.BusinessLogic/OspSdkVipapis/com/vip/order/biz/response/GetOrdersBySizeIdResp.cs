using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetOrdersBySizeIdResp {
		
		///<summary>
		/// 返回结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 返回内容
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.GetOrdersBySizeIdInfoVO> infoList_;
		
		///<summary>
		/// 总数
		///</summary>
		
		private int? total_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.GetOrdersBySizeIdInfoVO> GetInfoList(){
			return this.infoList_;
		}
		
		public void SetInfoList(List<com.vip.order.common.pojo.order.vo.GetOrdersBySizeIdInfoVO> value){
			this.infoList_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}