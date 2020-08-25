using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutReturnOrderPackageDetail {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transportNo_;
		
		///<summary>
		/// 客户箱号
		///</summary>
		
		private string custBoxNo_;
		
		///<summary>
		/// 收包类型
		///</summary>
		
		private int? receivingType_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetTransportNo(){
			return this.transportNo_;
		}
		
		public void SetTransportNo(string value){
			this.transportNo_ = value;
		}
		public string GetCustBoxNo(){
			return this.custBoxNo_;
		}
		
		public void SetCustBoxNo(string value){
			this.custBoxNo_ = value;
		}
		public int? GetReceivingType(){
			return this.receivingType_;
		}
		
		public void SetReceivingType(int? value){
			this.receivingType_ = value;
		}
		
	}
	
}