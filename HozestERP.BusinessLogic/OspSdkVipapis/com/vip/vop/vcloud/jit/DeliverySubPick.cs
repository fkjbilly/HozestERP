using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class DeliverySubPick {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 门店拣货单号
		///</summary>
		
		private string subPickNo_;
		
		///<summary>
		/// po
		///</summary>
		
		private string poNo_;
		
		///<summary>
		/// 未装箱数
		///</summary>
		
		private int? unboxedQuantity_;
		
		///<summary>
		/// 剩余未装箱数
		///</summary>
		
		private int? leavingUnboxNum_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetSubPickNo(){
			return this.subPickNo_;
		}
		
		public void SetSubPickNo(string value){
			this.subPickNo_ = value;
		}
		public string GetPoNo(){
			return this.poNo_;
		}
		
		public void SetPoNo(string value){
			this.poNo_ = value;
		}
		public int? GetUnboxedQuantity(){
			return this.unboxedQuantity_;
		}
		
		public void SetUnboxedQuantity(int? value){
			this.unboxedQuantity_ = value;
		}
		public int? GetLeavingUnboxNum(){
			return this.leavingUnboxNum_;
		}
		
		public void SetLeavingUnboxNum(int? value){
			this.leavingUnboxNum_ = value;
		}
		
	}
	
}