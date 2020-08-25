using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class DeliveryGoods {
		
		///<summary>
		/// 供应商类型： 只可传：COMMON或3PL
		///</summary>
		
		private string vendor_type_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 供应商箱号
		///</summary>
		
		private string box_no_;
		
		///<summary>
		/// 拣货单号
		///</summary>
		
		private string pick_no_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// po号，创建拣货单时的po单编号，多po用英文逗号隔开
		///</summary>
		
		private string po_no_;
		
		public string GetVendor_type(){
			return this.vendor_type_;
		}
		
		public void SetVendor_type(string value){
			this.vendor_type_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetBox_no(){
			return this.box_no_;
		}
		
		public void SetBox_no(string value){
			this.box_no_ = value;
		}
		public string GetPick_no(){
			return this.pick_no_;
		}
		
		public void SetPick_no(string value){
			this.pick_no_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		
	}
	
}