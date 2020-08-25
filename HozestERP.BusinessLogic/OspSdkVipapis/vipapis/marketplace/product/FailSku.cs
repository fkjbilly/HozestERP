using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class FailSku {
		
		///<summary>
		/// 外部sku id
		///</summary>
		
		private string outer_sku_id_;
		
		///<summary>
		/// sku的销售属性
		///</summary>
		
		private List<vipapis.marketplace.product.SimpleProperty> simple_sale_props_;
		
		///<summary>
		/// 失败原因
		///</summary>
		
		private string msg_;
		
		public string GetOuter_sku_id(){
			return this.outer_sku_id_;
		}
		
		public void SetOuter_sku_id(string value){
			this.outer_sku_id_ = value;
		}
		public List<vipapis.marketplace.product.SimpleProperty> GetSimple_sale_props(){
			return this.simple_sale_props_;
		}
		
		public void SetSimple_sale_props(List<vipapis.marketplace.product.SimpleProperty> value){
			this.simple_sale_props_ = value;
		}
		public string GetMsg(){
			return this.msg_;
		}
		
		public void SetMsg(string value){
			this.msg_ = value;
		}
		
	}
	
}