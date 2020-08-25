using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class VendorProductSubmitResult {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 品牌ID
		/// @sampleValue brand_id 123
		///</summary>
		
		private int? brand_id_;
		
		///<summary>
		/// 货号
		/// @sampleValue sn 113113302011
		///</summary>
		
		private string sn_;
		
		///<summary>
		/// 返回结果编码：0:正常；2:图片问题；3:已提交；9:其它
		///</summary>
		
		private int? code_;
		
		///<summary>
		/// 错误信息
		///</summary>
		
		private string error_msg_;
		
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
		public int? GetCode(){
			return this.code_;
		}
		
		public void SetCode(int? value){
			this.code_ = value;
		}
		public string GetError_msg(){
			return this.error_msg_;
		}
		
		public void SetError_msg(string value){
			this.error_msg_ = value;
		}
		
	}
	
}