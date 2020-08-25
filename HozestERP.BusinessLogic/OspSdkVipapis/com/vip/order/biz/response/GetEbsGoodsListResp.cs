using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetEbsGoodsListResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// EBS商品信息列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.EbsGoodsVO> ebsGoodList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.EbsGoodsVO> GetEbsGoodList(){
			return this.ebsGoodList_;
		}
		
		public void SetEbsGoodList(List<com.vip.order.common.pojo.order.vo.EbsGoodsVO> value){
			this.ebsGoodList_ = value;
		}
		
	}
	
}