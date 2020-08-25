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
		/// 款号，同一款号商品不区分颜色、尺码
		/// @sampleValue sn 13MP202AHSL
		///</summary>
		
		private string sn_;
		
		///<summary>
		/// 上传返回结果
		///</summary>
		
		private Dictionary<int?, vipapis.product.UploadTaskExecutionResult> upload_result_map_;
		
		///<summary>
		/// 色号，在某一个款号下，区分不同颜色的商品编号，但不区分尺码
		/// @sampleValue group_sn 1434132
		///</summary>
		
		private string group_sn_;
		
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
		public string GetGroup_sn(){
			return this.group_sn_;
		}
		
		public void SetGroup_sn(string value){
			this.group_sn_ = value;
		}
		
	}
	
}