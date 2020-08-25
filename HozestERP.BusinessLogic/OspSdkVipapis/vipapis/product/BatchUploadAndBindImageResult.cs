using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class BatchUploadAndBindImageResult {
		
		///<summary>
		/// 上传成功集合
		///</summary>
		
		private List<vipapis.product.UploadSuccessResult> success_list_;
		
		///<summary>
		/// 上传失败集合
		///</summary>
		
		private List<vipapis.product.UploadFailResult> fail_list_;
		
		public List<vipapis.product.UploadSuccessResult> GetSuccess_list(){
			return this.success_list_;
		}
		
		public void SetSuccess_list(List<vipapis.product.UploadSuccessResult> value){
			this.success_list_ = value;
		}
		public List<vipapis.product.UploadFailResult> GetFail_list(){
			return this.fail_list_;
		}
		
		public void SetFail_list(List<vipapis.product.UploadFailResult> value){
			this.fail_list_ = value;
		}
		
	}
	
}