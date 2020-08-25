using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class ImageUploadResult {
		
		///<summary>
		/// 供应商ID
		/// @sampleValue vendor_id 550
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 品牌ID
		/// @sampleValue brand_id 20000311
		///</summary>
		
		private int? brand_id_;
		
		///<summary>
		/// 货号
		/// @sampleValue sn 13MP202AHSL
		///</summary>
		
		private string sn_;
		
		///<summary>
		/// 上传返回结果
		/// @sampleValue upload_result_map key为图片index,value为图片上传结果
		///</summary>
		
		private Dictionary<int?, vipapis.product.UploadTaskExecutionResult> upload_result_map_;
		
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
		public Dictionary<int?, vipapis.product.UploadTaskExecutionResult> GetUpload_result_map(){
			return this.upload_result_map_;
		}
		
		public void SetUpload_result_map(Dictionary<int?, vipapis.product.UploadTaskExecutionResult> value){
			this.upload_result_map_ = value;
		}
		
	}
	
}