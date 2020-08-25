using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class GetDeliveryListResponse {
		
		///<summary>
		/// 出仓列表
		///</summary>
		
		private List<com.vip.vop.vcloud.jit.Delivery> deliveryList_;
		
		///<summary>
		/// 分页信息
		///</summary>
		
		private com.vip.vop.vcloud.common.api.Pagination pagination_;
		
		public List<com.vip.vop.vcloud.jit.Delivery> GetDeliveryList(){
			return this.deliveryList_;
		}
		
		public void SetDeliveryList(List<com.vip.vop.vcloud.jit.Delivery> value){
			this.deliveryList_ = value;
		}
		public com.vip.vop.vcloud.common.api.Pagination GetPagination(){
			return this.pagination_;
		}
		
		public void SetPagination(com.vip.vop.vcloud.common.api.Pagination value){
			this.pagination_ = value;
		}
		
	}
	
}