using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderTransportDetailsAndPackageVO {
		
		///<summary>
		/// 物流id
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderTransportPackageVO orderTransportPackage_;
		
		///<summary>
		/// 快递号
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderTransportDetailVO> orderTransportDetailList_;
		
		public com.vip.order.common.pojo.order.vo.OrderTransportPackageVO GetOrderTransportPackage(){
			return this.orderTransportPackage_;
		}
		
		public void SetOrderTransportPackage(com.vip.order.common.pojo.order.vo.OrderTransportPackageVO value){
			this.orderTransportPackage_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderTransportDetailVO> GetOrderTransportDetailList(){
			return this.orderTransportDetailList_;
		}
		
		public void SetOrderTransportDetailList(List<com.vip.order.common.pojo.order.vo.OrderTransportDetailVO> value){
			this.orderTransportDetailList_ = value;
		}
		
	}
	
}