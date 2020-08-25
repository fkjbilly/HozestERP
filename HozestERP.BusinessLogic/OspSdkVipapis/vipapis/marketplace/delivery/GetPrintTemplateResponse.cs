using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class GetPrintTemplateResponse {
		
		///<summary>
		/// 订单HTML dom结构，样式在all_print_html中。如果订单商品比较多，一张纸会装不下，所以对这种情况,会有多个dom,因此这里返回List
		///</summary>
		
		private List<string> part_order_list_;
		
		///<summary>
		/// 售后HTML模板，包含所有样式。由店铺商家自己将part_order_list放入该模板中，进行展示，然后打印。
		///</summary>
		
		private string all_print_html_;
		
		public List<string> GetPart_order_list(){
			return this.part_order_list_;
		}
		
		public void SetPart_order_list(List<string> value){
			this.part_order_list_ = value;
		}
		public string GetAll_print_html(){
			return this.all_print_html_;
		}
		
		public void SetAll_print_html(string value){
			this.all_print_html_ = value;
		}
		
	}
	
}