using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetReturnOrExchangeGoodsResp {
		
		///<summary>
		/// 返回结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 可操作商品列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO> allowedGoodsList_;
		
		///<summary>
		/// 不可操作商品列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO> unallowedGoodsList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO> GetAllowedGoodsList(){
			return this.allowedGoodsList_;
		}
		
		public void SetAllowedGoodsList(List<com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO> value){
			this.allowedGoodsList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO> GetUnallowedGoodsList(){
			return this.unallowedGoodsList_;
		}
		
		public void SetUnallowedGoodsList(List<com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO> value){
			this.unallowedGoodsList_ = value;
		}
		
	}
	
}