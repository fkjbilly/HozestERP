using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.order{
	
	
	
	
	
	public class CustomerBackOrderItemInfo {
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string size_sn_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private int? quantity_;
		
		///<summary>
		/// 单位名称
		///</summary>
		
		private string unit_;
		
		///<summary>
		/// 退货原因
		///</summary>
		
		private string return_reason_name_;
		
		public string GetSize_sn(){
			return this.size_sn_;
		}
		
		public void SetSize_sn(string value){
			this.size_sn_ = value;
		}
		public int? GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(int? value){
			this.quantity_ = value;
		}
		public string GetUnit(){
			return this.unit_;
		}
		
		public void SetUnit(string value){
			this.unit_ = value;
		}
		public string GetReturn_reason_name(){
			return this.return_reason_name_;
		}
		
		public void SetReturn_reason_name(string value){
			this.return_reason_name_ = value;
		}
		
	}
	
}