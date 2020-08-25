using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class ModifyOrderConsigneeReq {
		
		///<summary>
		/// 接口名
		///</summary>
		
		private string service_;
		
		///<summary>
		/// 订单信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderVO order_;
		
		///<summary>
		/// 发票信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderInvoiceVO orderInvoice_;
		
		///<summary>
		/// 地址信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO orderAddress_;
		
		///<summary>
		/// 四级地址
		///</summary>
		
		private int? is4Level_;
		
		///<summary>
		/// 地址ID
		///</summary>
		
		private long? addressId_;
		
		///<summary>
		/// 供应商取消权限
		///</summary>
		
		private int? supplierCancel_;
		
		///<summary>
		/// 订单类型，0-普通订单，1-预付订单
		///</summary>
		
		private int? orderCategory_;
		
		///<summary>
		/// 下单设备号信息
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderDeviceInfoVO orderDeviceInfo_;
		
		public string GetService(){
			return this.service_;
		}
		
		public void SetService(string value){
			this.service_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderVO GetOrder(){
			return this.order_;
		}
		
		public void SetOrder(com.vip.order.common.pojo.order.vo.OrderVO value){
			this.order_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderInvoiceVO GetOrderInvoice(){
			return this.orderInvoice_;
		}
		
		public void SetOrderInvoice(com.vip.order.common.pojo.order.vo.OrderInvoiceVO value){
			this.orderInvoice_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO GetOrderAddress(){
			return this.orderAddress_;
		}
		
		public void SetOrderAddress(com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO value){
			this.orderAddress_ = value;
		}
		public int? GetIs4Level(){
			return this.is4Level_;
		}
		
		public void SetIs4Level(int? value){
			this.is4Level_ = value;
		}
		public long? GetAddressId(){
			return this.addressId_;
		}
		
		public void SetAddressId(long? value){
			this.addressId_ = value;
		}
		public int? GetSupplierCancel(){
			return this.supplierCancel_;
		}
		
		public void SetSupplierCancel(int? value){
			this.supplierCancel_ = value;
		}
		public int? GetOrderCategory(){
			return this.orderCategory_;
		}
		
		public void SetOrderCategory(int? value){
			this.orderCategory_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderDeviceInfoVO GetOrderDeviceInfo(){
			return this.orderDeviceInfo_;
		}
		
		public void SetOrderDeviceInfo(com.vip.order.common.pojo.order.vo.OrderDeviceInfoVO value){
			this.orderDeviceInfo_ = value;
		}
		
	}
	
}