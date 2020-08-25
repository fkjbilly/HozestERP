using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.price{
	
	
	
	
	
	public class UpdatePriceApplicationRequest {
		
		///<summary>
		/// 价格申请单号
		///</summary>
		
		private string application_id_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 需更新的价格申请单明细，每次最大支持100条明细，超过100报错
		///</summary>
		
		private List<vipapis.price.UpdatePriceApplicationDetail> price_details_;
		
		public string GetApplication_id(){
			return this.application_id_;
		}
		
		public void SetApplication_id(string value){
			this.application_id_ = value;
		}
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public List<vipapis.price.UpdatePriceApplicationDetail> GetPrice_details(){
			return this.price_details_;
		}
		
		public void SetPrice_details(List<vipapis.price.UpdatePriceApplicationDetail> value){
			this.price_details_ = value;
		}
		
	}
	
}