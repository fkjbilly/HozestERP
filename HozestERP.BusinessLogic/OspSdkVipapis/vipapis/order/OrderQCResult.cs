using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OrderQCResult {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 装箱条码
		///</summary>
		
		private string packing_number_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetPacking_number(){
			return this.packing_number_;
		}
		
		public void SetPacking_number(string value){
			this.packing_number_ = value;
		}
		
	}
	
}