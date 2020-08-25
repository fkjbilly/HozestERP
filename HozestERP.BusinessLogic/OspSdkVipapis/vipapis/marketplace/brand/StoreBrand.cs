using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.brand{
	
	
	
	
	
	public class StoreBrand {
		
		///<summary>
		/// 品牌ID
		///</summary>
		
		private string brand_id_;
		
		///<summary>
		/// 品牌中文名
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 品牌英文名
		///</summary>
		
		private string brand_name_eng_;
		
		public string GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(string value){
			this.brand_id_ = value;
		}
		public string GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(string value){
			this.brand_name_ = value;
		}
		public string GetBrand_name_eng(){
			return this.brand_name_eng_;
		}
		
		public void SetBrand_name_eng(string value){
			this.brand_name_eng_ = value;
		}
		
	}
	
}