using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class AutoBindProductSizeTableRequest {
		
		///<summary>
		/// 商品spu编码
		///</summary>
		
		private string spu_id_;
		
		///<summary>
		/// 尺码表模板id
		///</summary>
		
		private int? size_table_template_id_;
		
		public string GetSpu_id(){
			return this.spu_id_;
		}
		
		public void SetSpu_id(string value){
			this.spu_id_ = value;
		}
		public int? GetSize_table_template_id(){
			return this.size_table_template_id_;
		}
		
		public void SetSize_table_template_id(int? value){
			this.size_table_template_id_ = value;
		}
		
	}
	
}