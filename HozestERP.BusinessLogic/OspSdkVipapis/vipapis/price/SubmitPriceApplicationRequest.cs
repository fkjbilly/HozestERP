using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.price{
	
	
	
	
	
	public class SubmitPriceApplicationRequest {
		
		///<summary>
		/// 价格申请单的清单ID
		///</summary>
		
		private string application_id_;
		
		///<summary>
		/// 变价生效时间
		///</summary>
		
		private System.DateTime? effective_start_time_;
		
		///<summary>
		/// 变价失效时间，如果是变价，必需且校验
		///</summary>
		
		private System.DateTime? effective_end_time_;
		
		///<summary>
		/// 备注，文本格式
		///</summary>
		
		private string memo_;
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 常态合作编码，目前最大支持五个合作编码
		///</summary>
		
		private List<string> cooperation_nos_;
		
		///<summary>
		/// 清单行信息, 每次最大可以支持500，超过该限制报错
		///</summary>
		
		private List<vipapis.price.SubmitPriceApplicationDetail> price_details_;
		
		public string GetApplication_id(){
			return this.application_id_;
		}
		
		public void SetApplication_id(string value){
			this.application_id_ = value;
		}
		public System.DateTime? GetEffective_start_time(){
			return this.effective_start_time_;
		}
		
		public void SetEffective_start_time(System.DateTime? value){
			this.effective_start_time_ = value;
		}
		public System.DateTime? GetEffective_end_time(){
			return this.effective_end_time_;
		}
		
		public void SetEffective_end_time(System.DateTime? value){
			this.effective_end_time_ = value;
		}
		public string GetMemo(){
			return this.memo_;
		}
		
		public void SetMemo(string value){
			this.memo_ = value;
		}
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public List<string> GetCooperation_nos(){
			return this.cooperation_nos_;
		}
		
		public void SetCooperation_nos(List<string> value){
			this.cooperation_nos_ = value;
		}
		public List<vipapis.price.SubmitPriceApplicationDetail> GetPrice_details(){
			return this.price_details_;
		}
		
		public void SetPrice_details(List<vipapis.price.SubmitPriceApplicationDetail> value){
			this.price_details_ = value;
		}
		
	}
	
}