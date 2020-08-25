using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class DeleteVSpuSizeTableRelationResponse {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 品牌ID
		///</summary>
		
		private int? brand_id_;
		
		///<summary>
		/// 货号
		///</summary>
		
		private string sn_;
		
		///<summary>
		/// 是否删除成功
		///</summary>
		
		private bool? is_success_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public int? GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(int? value){
			this.brand_id_ = value;
		}
		public string GetSn(){
			return this.sn_;
		}
		
		public void SetSn(string value){
			this.sn_ = value;
		}
		public bool? GetIs_success(){
			return this.is_success_;
		}
		
		public void SetIs_success(bool? value){
			this.is_success_ = value;
		}
		
	}
	
}