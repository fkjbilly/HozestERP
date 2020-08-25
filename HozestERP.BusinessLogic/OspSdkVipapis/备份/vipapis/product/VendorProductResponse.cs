using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.product{
	
	
	
	
	
	public class VendorProductResponse {
		
		///<summary>
		/// 操作成功的数量
		/// @sampleValue success_num 1
		///</summary>
		
		private int? success_num_;
		
		///<summary>
		/// 成功数据列表
		///</summary>
		
		private List<string> success_barcode_list_;
		
		///<summary>
		/// 操作失败的数量
		/// @sampleValue fail_num 0
		///</summary>
		
		private int? fail_num_;
		
		///<summary>
		/// 操作失败的数据列表
		///</summary>
		
		private List<vipapis.product.VendorProductFailItem> fail_item_list_;
		
		public int? GetSuccess_num(){
			return this.success_num_;
		}
		
		public void SetSuccess_num(int? value){
			this.success_num_ = value;
		}
		public List<string> GetSuccess_barcode_list(){
			return this.success_barcode_list_;
		}
		
		public void SetSuccess_barcode_list(List<string> value){
			this.success_barcode_list_ = value;
		}
		public int? GetFail_num(){
			return this.fail_num_;
		}
		
		public void SetFail_num(int? value){
			this.fail_num_ = value;
		}
		public List<vipapis.product.VendorProductFailItem> GetFail_item_list(){
			return this.fail_item_list_;
		}
		
		public void SetFail_item_list(List<vipapis.product.VendorProductFailItem> value){
			this.fail_item_list_ = value;
		}
		
	}
	
}