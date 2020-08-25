using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtCancelledSaleOrderResultModel {
		
		///<summary>
		/// 销售订单
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 关口
		///</summary>
		
		private string customsCode_;
		
		///<summary>
		/// 仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 进出口类型[BC BBC]
		///</summary>
		
		private string orderType_;
		
		///<summary>
		/// 货主
		///</summary>
		
		private string owerCode_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetCustomsCode(){
			return this.customsCode_;
		}
		
		public void SetCustomsCode(string value){
			this.customsCode_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetOrderType(){
			return this.orderType_;
		}
		
		public void SetOrderType(string value){
			this.orderType_ = value;
		}
		public string GetOwerCode(){
			return this.owerCode_;
		}
		
		public void SetOwerCode(string value){
			this.owerCode_ = value;
		}
		
	}
	
}