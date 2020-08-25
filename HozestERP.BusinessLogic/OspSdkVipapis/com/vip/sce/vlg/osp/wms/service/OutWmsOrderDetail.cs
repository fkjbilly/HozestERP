using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutWmsOrderDetail {
		
		///<summary>
		/// PO号,如:5000151199
		///</summary>
		
		private string po_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string sizeSn_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string goodName_;
		
		///<summary>
		/// 海关备案商品名称
		///</summary>
		
		private string goodRecordName_;
		
		///<summary>
		/// 货号
		///</summary>
		
		private string goodSn_;
		
		///<summary>
		/// 规格型号
		///</summary>
		
		private string standardType_;
		
		///<summary>
		/// 档期号
		///</summary>
		
		private string brandId_;
		
		///<summary>
		/// 商品备案号
		///</summary>
		
		private string goodRecordNo_;
		
		///<summary>
		/// 商品单价
		///</summary>
		
		private double? price_;
		
		///<summary>
		/// 不含税单价
		///</summary>
		
		private double? priceTaxfree_;
		
		///<summary>
		/// 打印单价
		///</summary>
		
		private double? printPrice_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 计量单位
		///</summary>
		
		private string unit_;
		
		///<summary>
		/// 商品行邮税号
		///</summary>
		
		private string parcelTaxNo_;
		
		///<summary>
		/// 品牌
		///</summary>
		
		private string brand_;
		
		///<summary>
		/// 原产国
		///</summary>
		
		private string country_;
		
		///<summary>
		/// 净重,单个SKU净重
		///</summary>
		
		private double? netWeight_;
		
		///<summary>
		/// 毛重,单个SKU毛重
		///</summary>
		
		private double? grossWeight_;
		
		///<summary>
		/// hscode
		///</summary>
		
		private string hsCode_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendorCode_;
		
		///<summary>
		/// 是否绑定po,1000未知
		///</summary>
		
		private string noPo_;
		
		///<summary>
		/// 自定义字段1-String类型
		///</summary>
		
		private string userDef1_;
		
		///<summary>
		/// 自定义字段2-String类型
		///</summary>
		
		private string userDef2_;
		
		///<summary>
		/// 自定义字段3-String类型
		///</summary>
		
		private string userDef3_;
		
		///<summary>
		/// 自定义字段4-String类型
		///</summary>
		
		private string userDef4_;
		
		///<summary>
		/// 自定义字段5-Long类型
		///</summary>
		
		private long? userDef5_;
		
		///<summary>
		/// 自定义字段6-Long类型
		///</summary>
		
		private long? userDef6_;
		
		///<summary>
		/// 自定义字段7-String类型(格式：yyyy-MM-dd HH:mm:ss)
		///</summary>
		
		private string userDef7_;
		
		///<summary>
		/// 自定义字段8-String类型(格式：yyyy-MM-dd HH:mm:ss)
		///</summary>
		
		private string userDef8_;
		
		public string GetPo(){
			return this.po_;
		}
		
		public void SetPo(string value){
			this.po_ = value;
		}
		public string GetSizeSn(){
			return this.sizeSn_;
		}
		
		public void SetSizeSn(string value){
			this.sizeSn_ = value;
		}
		public string GetGoodName(){
			return this.goodName_;
		}
		
		public void SetGoodName(string value){
			this.goodName_ = value;
		}
		public string GetGoodRecordName(){
			return this.goodRecordName_;
		}
		
		public void SetGoodRecordName(string value){
			this.goodRecordName_ = value;
		}
		public string GetGoodSn(){
			return this.goodSn_;
		}
		
		public void SetGoodSn(string value){
			this.goodSn_ = value;
		}
		public string GetStandardType(){
			return this.standardType_;
		}
		
		public void SetStandardType(string value){
			this.standardType_ = value;
		}
		public string GetBrandId(){
			return this.brandId_;
		}
		
		public void SetBrandId(string value){
			this.brandId_ = value;
		}
		public string GetGoodRecordNo(){
			return this.goodRecordNo_;
		}
		
		public void SetGoodRecordNo(string value){
			this.goodRecordNo_ = value;
		}
		public double? GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(double? value){
			this.price_ = value;
		}
		public double? GetPriceTaxfree(){
			return this.priceTaxfree_;
		}
		
		public void SetPriceTaxfree(double? value){
			this.priceTaxfree_ = value;
		}
		public double? GetPrintPrice(){
			return this.printPrice_;
		}
		
		public void SetPrintPrice(double? value){
			this.printPrice_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public string GetUnit(){
			return this.unit_;
		}
		
		public void SetUnit(string value){
			this.unit_ = value;
		}
		public string GetParcelTaxNo(){
			return this.parcelTaxNo_;
		}
		
		public void SetParcelTaxNo(string value){
			this.parcelTaxNo_ = value;
		}
		public string GetBrand(){
			return this.brand_;
		}
		
		public void SetBrand(string value){
			this.brand_ = value;
		}
		public string GetCountry(){
			return this.country_;
		}
		
		public void SetCountry(string value){
			this.country_ = value;
		}
		public double? GetNetWeight(){
			return this.netWeight_;
		}
		
		public void SetNetWeight(double? value){
			this.netWeight_ = value;
		}
		public double? GetGrossWeight(){
			return this.grossWeight_;
		}
		
		public void SetGrossWeight(double? value){
			this.grossWeight_ = value;
		}
		public string GetHsCode(){
			return this.hsCode_;
		}
		
		public void SetHsCode(string value){
			this.hsCode_ = value;
		}
		public string GetVendorCode(){
			return this.vendorCode_;
		}
		
		public void SetVendorCode(string value){
			this.vendorCode_ = value;
		}
		public string GetNoPo(){
			return this.noPo_;
		}
		
		public void SetNoPo(string value){
			this.noPo_ = value;
		}
		public string GetUserDef1(){
			return this.userDef1_;
		}
		
		public void SetUserDef1(string value){
			this.userDef1_ = value;
		}
		public string GetUserDef2(){
			return this.userDef2_;
		}
		
		public void SetUserDef2(string value){
			this.userDef2_ = value;
		}
		public string GetUserDef3(){
			return this.userDef3_;
		}
		
		public void SetUserDef3(string value){
			this.userDef3_ = value;
		}
		public string GetUserDef4(){
			return this.userDef4_;
		}
		
		public void SetUserDef4(string value){
			this.userDef4_ = value;
		}
		public long? GetUserDef5(){
			return this.userDef5_;
		}
		
		public void SetUserDef5(long? value){
			this.userDef5_ = value;
		}
		public long? GetUserDef6(){
			return this.userDef6_;
		}
		
		public void SetUserDef6(long? value){
			this.userDef6_ = value;
		}
		public string GetUserDef7(){
			return this.userDef7_;
		}
		
		public void SetUserDef7(string value){
			this.userDef7_ = value;
		}
		public string GetUserDef8(){
			return this.userDef8_;
		}
		
		public void SetUserDef8(string value){
			this.userDef8_ = value;
		}
		
	}
	
}