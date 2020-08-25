using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtSaleOrderInfoChbModel {
		
		///<summary>
		/// 序号,如:序号需与HTS传订单给总署的序号一致
		///</summary>
		
		private string id_;
		
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
		/// 供应商编码
		///</summary>
		
		private string vendorCode_;
		
		///<summary>
		/// 是否绑定po,1000未知
		///</summary>
		
		private short? noPo_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string hscode_;
		
		///<summary>
		/// 商检商品备案号
		///</summary>
		
		private string ciqGoodNo_;
		
		///<summary>
		/// 法定数量
		///</summary>
		
		private double? qty1_;
		
		///<summary>
		/// 法定第二数量
		///</summary>
		
		private double? qty2_;
		
		///<summary>
		/// 法定计量单位
		///</summary>
		
		private string unit1_;
		
		///<summary>
		/// 法定第二计量单位
		///</summary>
		
		private string unit2_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private string userDefined1_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private string userDefined2_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private string userDefined3_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private string userDefined4_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private long? userDefined5_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private long? userDefined6_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private string userDefined7_;
		
		///<summary>
		/// 用户自定义字段
		///</summary>
		
		private string userDefined8_;
		
		public string GetId(){
			return this.id_;
		}
		
		public void SetId(string value){
			this.id_ = value;
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
		public string GetVendorCode(){
			return this.vendorCode_;
		}
		
		public void SetVendorCode(string value){
			this.vendorCode_ = value;
		}
		public short? GetNoPo(){
			return this.noPo_;
		}
		
		public void SetNoPo(short? value){
			this.noPo_ = value;
		}
		public string GetHscode(){
			return this.hscode_;
		}
		
		public void SetHscode(string value){
			this.hscode_ = value;
		}
		public string GetCiqGoodNo(){
			return this.ciqGoodNo_;
		}
		
		public void SetCiqGoodNo(string value){
			this.ciqGoodNo_ = value;
		}
		public double? GetQty1(){
			return this.qty1_;
		}
		
		public void SetQty1(double? value){
			this.qty1_ = value;
		}
		public double? GetQty2(){
			return this.qty2_;
		}
		
		public void SetQty2(double? value){
			this.qty2_ = value;
		}
		public string GetUnit1(){
			return this.unit1_;
		}
		
		public void SetUnit1(string value){
			this.unit1_ = value;
		}
		public string GetUnit2(){
			return this.unit2_;
		}
		
		public void SetUnit2(string value){
			this.unit2_ = value;
		}
		public string GetUserDefined1(){
			return this.userDefined1_;
		}
		
		public void SetUserDefined1(string value){
			this.userDefined1_ = value;
		}
		public string GetUserDefined2(){
			return this.userDefined2_;
		}
		
		public void SetUserDefined2(string value){
			this.userDefined2_ = value;
		}
		public string GetUserDefined3(){
			return this.userDefined3_;
		}
		
		public void SetUserDefined3(string value){
			this.userDefined3_ = value;
		}
		public string GetUserDefined4(){
			return this.userDefined4_;
		}
		
		public void SetUserDefined4(string value){
			this.userDefined4_ = value;
		}
		public long? GetUserDefined5(){
			return this.userDefined5_;
		}
		
		public void SetUserDefined5(long? value){
			this.userDefined5_ = value;
		}
		public long? GetUserDefined6(){
			return this.userDefined6_;
		}
		
		public void SetUserDefined6(long? value){
			this.userDefined6_ = value;
		}
		public string GetUserDefined7(){
			return this.userDefined7_;
		}
		
		public void SetUserDefined7(string value){
			this.userDefined7_ = value;
		}
		public string GetUserDefined8(){
			return this.userDefined8_;
		}
		
		public void SetUserDefined8(string value){
			this.userDefined8_ = value;
		}
		
	}
	
}