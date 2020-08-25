using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class BatchRsInfo {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private string vendor_id_;
		
		///<summary>
		/// 批次号
		///</summary>
		
		private string batch_no_;
		
		///<summary>
		/// 资料类型
		/// @sampleValue rs_type 0-合同 1-发票 2-提单号 3-子提单号
		///</summary>
		
		private int? rs_type_;
		
		///<summary>
		/// 资料名称
		///</summary>
		
		private string rs_name_;
		
		///<summary>
		/// 资料号
		///</summary>
		
		private string rs_no_;
		
		///<summary>
		/// 图片Base64编码
		///</summary>
		
		private string rs_image_;
		
		///<summary>
		/// 资料主键ID(不为空则更新，为空则新增)
		///</summary>
		
		private int? rs_id_;
		
		///<summary>
		/// 文件名称
		/// @sampleValue file_name 1.jpg
		///</summary>
		
		private string file_name_;
		
		public string GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(string value){
			this.vendor_id_ = value;
		}
		public string GetBatch_no(){
			return this.batch_no_;
		}
		
		public void SetBatch_no(string value){
			this.batch_no_ = value;
		}
		public int? GetRs_type(){
			return this.rs_type_;
		}
		
		public void SetRs_type(int? value){
			this.rs_type_ = value;
		}
		public string GetRs_name(){
			return this.rs_name_;
		}
		
		public void SetRs_name(string value){
			this.rs_name_ = value;
		}
		public string GetRs_no(){
			return this.rs_no_;
		}
		
		public void SetRs_no(string value){
			this.rs_no_ = value;
		}
		public string GetRs_image(){
			return this.rs_image_;
		}
		
		public void SetRs_image(string value){
			this.rs_image_ = value;
		}
		public int? GetRs_id(){
			return this.rs_id_;
		}
		
		public void SetRs_id(int? value){
			this.rs_id_ = value;
		}
		public string GetFile_name(){
			return this.file_name_;
		}
		
		public void SetFile_name(string value){
			this.file_name_ = value;
		}
		
	}
	
}