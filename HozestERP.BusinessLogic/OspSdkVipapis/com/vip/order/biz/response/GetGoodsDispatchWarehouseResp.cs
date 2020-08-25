using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class GetGoodsDispatchWarehouseResp {
		
		///<summary>
		/// 处理结果
		///</summary>
		
		private com.vip.order.common.pojo.order.result.Result result_;
		
		///<summary>
		/// 仓库列表
		///</summary>
		
		private List<string> warehouseList_;
		
		public com.vip.order.common.pojo.order.result.Result GetResult(){
			return this.result_;
		}
		
		public void SetResult(com.vip.order.common.pojo.order.result.Result value){
			this.result_ = value;
		}
		public List<string> GetWarehouseList(){
			return this.warehouseList_;
		}
		
		public void SetWarehouseList(List<string> value){
			this.warehouseList_ = value;
		}
		
	}
	
}