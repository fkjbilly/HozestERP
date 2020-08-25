using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class GetDeliveryDetailResponse {
		
		///<summary>
		/// 出仓详情
		///</summary>
		
		private com.vip.vop.vcloud.jit.Delivery delivery_;
		
		///<summary>
		/// 导入明细
		///</summary>
		
		private List<com.vip.vop.vcloud.jit.DeliveryDetail> deliveryDetail_;
		
		///<summary>
		/// 物流信息
		///</summary>
		
		private List<com.vip.vop.vcloud.jit.DeliveryTrace> deliveryTrace_;
		
		///<summary>
		/// 导入明细分页
		///</summary>
		
		private com.vip.vop.vcloud.common.api.Pagination pagination_;
		
		public com.vip.vop.vcloud.jit.Delivery GetDelivery(){
			return this.delivery_;
		}
		
		public void SetDelivery(com.vip.vop.vcloud.jit.Delivery value){
			this.delivery_ = value;
		}
		public List<com.vip.vop.vcloud.jit.DeliveryDetail> GetDeliveryDetail(){
			return this.deliveryDetail_;
		}
		
		public void SetDeliveryDetail(List<com.vip.vop.vcloud.jit.DeliveryDetail> value){
			this.deliveryDetail_ = value;
		}
		public List<com.vip.vop.vcloud.jit.DeliveryTrace> GetDeliveryTrace(){
			return this.deliveryTrace_;
		}
		
		public void SetDeliveryTrace(List<com.vip.vop.vcloud.jit.DeliveryTrace> value){
			this.deliveryTrace_ = value;
		}
		public com.vip.vop.vcloud.common.api.Pagination GetPagination(){
			return this.pagination_;
		}
		
		public void SetPagination(com.vip.vop.vcloud.common.api.Pagination value){
			this.pagination_ = value;
		}
		
	}
	
}