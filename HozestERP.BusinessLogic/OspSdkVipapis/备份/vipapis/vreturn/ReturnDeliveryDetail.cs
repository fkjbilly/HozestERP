using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vreturn{
	
	
	
	
	
	public class ReturnDeliveryDetail {
		
		///<summary>
		/// 商品条形码
		/// @sampleValue barcode 
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品名称
		/// @sampleValue product_name 
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 货品等级：100，正常；101，正常，已过可上线日期；102，正常，已过保险期；103，正常，已过失效期；210，一级残次；211，一级残次，已过可上线日期；212，一级残次，已过保险期；213，一级残次，已过失效期；220，二级残次；221，二级残次，已过可上线日期；222，二级残次，已过保险期；223，二级残次，已过失效期；230，三级残次；231，三级残次，已过可上线日期；232，三级残次，已过保险期；233，三级残次，已过失效期
		/// @sampleValue grade 
		///</summary>
		
		private int? grade_;
		
		///<summary>
		/// 采购订单号
		/// @sampleValue po_no 
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 实退数量
		/// @sampleValue qty 
		///</summary>
		
		private double? qty_;
		
		///<summary>
		/// 箱号
		/// @sampleValue box_no 
		///</summary>
		
		private string box_no_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public int? GetGrade(){
			return this.grade_;
		}
		
		public void SetGrade(int? value){
			this.grade_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public double? GetQty(){
			return this.qty_;
		}
		
		public void SetQty(double? value){
			this.qty_ = value;
		}
		public string GetBox_no(){
			return this.box_no_;
		}
		
		public void SetBox_no(string value){
			this.box_no_ = value;
		}
		
	}
	
}