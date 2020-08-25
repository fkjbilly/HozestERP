using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class CancelOrderPrivilegeReq {
		
		///<summary>
		/// 取消供应商发货订单权限
		///</summary>
		
		private int? cancelSuppliersOrder_;
		
		///<summary>
		/// 特卖会直发预售生产中订单取消订单权限
		///</summary>
		
		private int? cancelSpecilizePreSaleOrder_;
		
		///<summary>
		/// 取消已打包订单权限
		///</summary>
		
		private int? cancelPackagedOrder_;
		
		///<summary>
		/// 取消海淘订单(针对出仓订单)权限
		///</summary>
		
		private int? cancelOverseasSaleOrder_;
		
		///<summary>
		/// 取消异常订单(针对出仓订单)权限
		///</summary>
		
		private int? cancelOutOfWarehouseOrder_;
		
		public int? GetCancelSuppliersOrder(){
			return this.cancelSuppliersOrder_;
		}
		
		public void SetCancelSuppliersOrder(int? value){
			this.cancelSuppliersOrder_ = value;
		}
		public int? GetCancelSpecilizePreSaleOrder(){
			return this.cancelSpecilizePreSaleOrder_;
		}
		
		public void SetCancelSpecilizePreSaleOrder(int? value){
			this.cancelSpecilizePreSaleOrder_ = value;
		}
		public int? GetCancelPackagedOrder(){
			return this.cancelPackagedOrder_;
		}
		
		public void SetCancelPackagedOrder(int? value){
			this.cancelPackagedOrder_ = value;
		}
		public int? GetCancelOverseasSaleOrder(){
			return this.cancelOverseasSaleOrder_;
		}
		
		public void SetCancelOverseasSaleOrder(int? value){
			this.cancelOverseasSaleOrder_ = value;
		}
		public int? GetCancelOutOfWarehouseOrder(){
			return this.cancelOutOfWarehouseOrder_;
		}
		
		public void SetCancelOutOfWarehouseOrder(int? value){
			this.cancelOutOfWarehouseOrder_ = value;
		}
		
	}
	
}