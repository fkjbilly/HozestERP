using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.omni.inventory{
	
	
	
	
	
	public class InventoryUpdateRequest {
		
		///<summary>
		/// 流水号，需保证流水号唯一，长度不超过20
		///</summary>
		
		private string batch_no_;
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 常态合作编码
		///</summary>
		
		private int? cooperation_no_;
		
		///<summary>
		/// 库存所在区域，如果为门店同步，则该字段为空
		///</summary>
		
		private List<string> area_codes_;
		
		///<summary>
		/// 门店编码，以门店维度进行更新时需要输入此字段
		///</summary>
		
		private string store_sn_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 库存更新数量
		///</summary>
		
		private int? quantity_;
		
		public string GetBatch_no(){
			return this.batch_no_;
		}
		
		public void SetBatch_no(string value){
			this.batch_no_ = value;
		}
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public int? GetCooperation_no(){
			return this.cooperation_no_;
		}
		
		public void SetCooperation_no(int? value){
			this.cooperation_no_ = value;
		}
		public List<string> GetArea_codes(){
			return this.area_codes_;
		}
		
		public void SetArea_codes(List<string> value){
			this.area_codes_ = value;
		}
		public string GetStore_sn(){
			return this.store_sn_;
		}
		
		public void SetStore_sn(string value){
			this.store_sn_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public int? GetQuantity(){
			return this.quantity_;
		}
		
		public void SetQuantity(int? value){
			this.quantity_ = value;
		}
		
	}
	
}