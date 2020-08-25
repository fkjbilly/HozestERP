using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.jit{
	
	
	
	
	
	public class DeliveryDetail {
		
		///<summary>
		/// 供应商类型：只可传：COMMON或3PL
		///</summary>
		
		private string vendorType_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 供应商箱号
		///</summary>
		
		private string boxNo_;
		
		///<summary>
		/// 拣货单号
		///</summary>
		
		private string pickNo_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// po号
		///</summary>
		
		private string poNo_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string productName_;
		
		///<summary>
		/// 门店拣货单号
		///</summary>
		
		private string subPickNo_;
		
		///<summary>
		/// 商品图片
		///</summary>
		
		private string imageUrl_;
		
		///<summary>
		/// 颜色代码
		///</summary>
		
		private string color_;
		
		///<summary>
		/// 颜色
		///</summary>
		
		private string colorName_;
		
		///<summary>
		/// 款号
		///</summary>
		
		private string sn_;
		
		public string GetVendorType(){
			return this.vendorType_;
		}
		
		public void SetVendorType(string value){
			this.vendorType_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetBoxNo(){
			return this.boxNo_;
		}
		
		public void SetBoxNo(string value){
			this.boxNo_ = value;
		}
		public string GetPickNo(){
			return this.pickNo_;
		}
		
		public void SetPickNo(string value){
			this.pickNo_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public string GetPoNo(){
			return this.poNo_;
		}
		
		public void SetPoNo(string value){
			this.poNo_ = value;
		}
		public string GetProductName(){
			return this.productName_;
		}
		
		public void SetProductName(string value){
			this.productName_ = value;
		}
		public string GetSubPickNo(){
			return this.subPickNo_;
		}
		
		public void SetSubPickNo(string value){
			this.subPickNo_ = value;
		}
		public string GetImageUrl(){
			return this.imageUrl_;
		}
		
		public void SetImageUrl(string value){
			this.imageUrl_ = value;
		}
		public string GetColor(){
			return this.color_;
		}
		
		public void SetColor(string value){
			this.color_ = value;
		}
		public string GetColorName(){
			return this.colorName_;
		}
		
		public void SetColorName(string value){
			this.colorName_ = value;
		}
		public string GetSn(){
			return this.sn_;
		}
		
		public void SetSn(string value){
			this.sn_ = value;
		}
		
	}
	
}