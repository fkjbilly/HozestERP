using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OrderSeq {
		
		///<summary>
		/// 顺序号
		///</summary>
		
		private string seq_no_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		public string GetSeq_no(){
			return this.seq_no_;
		}
		
		public void SetSeq_no(string value){
			this.seq_no_ = value;
		}
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		
	}
	
}