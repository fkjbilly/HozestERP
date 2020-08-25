using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class GetDeliveryGoodsResponse {
		
		///<summary>
		/// 出仓单明细列表
		///</summary>
		
		private List<com.vip.vop.vcloud.jit.DeliveryDetail> deliveryGoodsList_;
		
		///<summary>
		/// 分页
		///</summary>
		
		private com.vip.vop.vcloud.common.api.Pagination pagination_;
		
		public List<com.vip.vop.vcloud.jit.DeliveryDetail> GetDeliveryGoodsList(){
			return this.deliveryGoodsList_;
		}
		
		public void SetDeliveryGoodsList(List<com.vip.vop.vcloud.jit.DeliveryDetail> value){
			this.deliveryGoodsList_ = value;
		}
		public com.vip.vop.vcloud.common.api.Pagination GetPagination(){
			return this.pagination_;
		}
		
		public void SetPagination(com.vip.vop.vcloud.common.api.Pagination value){
			this.pagination_ = value;
		}
		
	}
	
}