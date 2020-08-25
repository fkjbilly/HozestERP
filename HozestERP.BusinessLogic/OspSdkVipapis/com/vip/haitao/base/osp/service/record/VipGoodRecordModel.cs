using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.base.osp.service.record{
	
	
	
	
	
	public class VipGoodRecordModel {
		
		///<summary>
		/// 商品货号
		///</summary>
		
		private string goodNo_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string goodSn_;
		
		///<summary>
		/// 商品备案名称
		///</summary>
		
		private string goodRecordName_;
		
		///<summary>
		/// 商品名
		///</summary>
		
		private string goodName_;
		
		///<summary>
		/// 商品英文名称
		///</summary>
		
		private string goodEnglishName_;
		
		///<summary>
		/// 成分含量
		///</summary>
		
		private string ingredients_;
		
		///<summary>
		/// 功能
		///</summary>
		
		private string commodityFunction_;
		
		///<summary>
		/// 用途
		///</summary>
		
		private string effect_;
		
		///<summary>
		/// 商品描述
		///</summary>
		
		private string goodDetail_;
		
		///<summary>
		/// 规格型号
		///</summary>
		
		private string standardType_;
		
		///<summary>
		/// 毛重
		///</summary>
		
		private double? grossWeight_;
		
		///<summary>
		/// 净重
		///</summary>
		
		private double? netWeight_;
		
		///<summary>
		/// 申报计量单位
		///</summary>
		
		private string unit_;
		
		///<summary>
		/// 备案价格
		///</summary>
		
		private double? recordPrice_;
		
		///<summary>
		/// 保质期
		///</summary>
		
		private string expiryDate_;
		
		///<summary>
		/// 国检原产国/地区
		///</summary>
		
		private string ciqCountry_;
		
		///<summary>
		/// 原产国
		///</summary>
		
		private string country_;
		
		///<summary>
		/// 产品适用的生产标准国别
		///</summary>
		
		private string productionStandard_;
		
		///<summary>
		/// 币制
		///</summary>
		
		private string currency_;
		
		///<summary>
		/// 品牌
		///</summary>
		
		private string brand_;
		
		///<summary>
		/// 品牌类型
		///</summary>
		
		private string brandType_;
		
		///<summary>
		/// 生厂厂家
		///</summary>
		
		private string factory_;
		
		///<summary>
		/// 生产商注册地址
		///</summary>
		
		private string factoryAddress_;
		
		///<summary>
		/// 生产厂家境内注册号
		///</summary>
		
		private string factoryRecord_;
		
		///<summary>
		/// 商品大类
		///</summary>
		
		private string goodsType_;
		
		///<summary>
		/// 出口享惠情况
		///</summary>
		
		private string exportBenefit_;
		
		///<summary>
		/// 商品品质
		///</summary>
		
		private string commodityQuality_;
		
		///<summary>
		/// 长度
		///</summary>
		
		private double? lengthUnit_;
		
		///<summary>
		/// 宽度
		///</summary>
		
		private double? widthUnit_;
		
		///<summary>
		/// 高度
		///</summary>
		
		private double? heightUnit_;
		
		///<summary>
		/// 体积
		///</summary>
		
		private double? volumeUnit_;
		
		///<summary>
		/// 进出口标示
		///</summary>
		
		private string ieflag_;
		
		///<summary>
		/// 商品批次号
		///</summary>
		
		private string batchNumber_;
		
		///<summary>
		/// 备案申请备注
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 备案类型(000:BC/BBC通用;001:BC;003:BBC)
		///</summary>
		
		private string recordType_;
		
		///<summary>
		/// 电商企业名称
		///</summary>
		
		private string enterpriseName_;
		
		///<summary>
		/// 电商企业海关备案号
		///</summary>
		
		private string enterpriseCusNo_;
		
		///<summary>
		/// 电商企业国检备案号
		///</summary>
		
		private string enterpriseCiqNo_;
		
		///<summary>
		/// 业务类型(重庆)：I20
		///</summary>
		
		private string businessType_;
		
		///<summary>
		/// 入区计量单位折算数量
		///</summary>
		
		private int? unitConvertQuantity_;
		
		///<summary>
		/// 商品销售网站
		///</summary>
		
		private string goodsSaleUrl_;
		
		///<summary>
		/// 超范围使用食品添加剂：0-否,1-是
		///</summary>
		
		private bool? isOverFoodAdditives_;
		
		///<summary>
		/// 含有毒害物质：0-否,1-是
		///</summary>
		
		private bool? isContainPoison_;
		
		///<summary>
		/// 赠品：0-否,1-是
		///</summary>
		
		private bool? isGift_;
		
		///<summary>
		/// 记录序列号：0-否,1-是
		///</summary>
		
		private bool? isSn_;
		
		///<summary>
		/// 符合国家相关法规：Y/N
		///</summary>
		
		private string accordRule_;
		
		///<summary>
		/// 正面图片地址
		///</summary>
		
		private string frontPicture_;
		
		///<summary>
		/// 反面图片地址
		///</summary>
		
		private string backPicture_;
		
		///<summary>
		/// 中文标签图片地址
		///</summary>
		
		private string labelPicture_;
		
		///<summary>
		/// 跨境电商食品化妆品声明地址
		///</summary>
		
		private string statementPicture_;
		
		///<summary>
		/// 化妆品危害物质识别表地址
		///</summary>
		
		private string cosmeticHazardIdTable_;
		
		///<summary>
		/// 清关模式代码
		///</summary>
		
		private string clearanceMode_;
		
		///<summary>
		/// 国检单位
		///</summary>
		
		private string ciqUnit_;
		
		public string GetGoodNo(){
			return this.goodNo_;
		}
		
		public void SetGoodNo(string value){
			this.goodNo_ = value;
		}
		public string GetGoodSn(){
			return this.goodSn_;
		}
		
		public void SetGoodSn(string value){
			this.goodSn_ = value;
		}
		public string GetGoodRecordName(){
			return this.goodRecordName_;
		}
		
		public void SetGoodRecordName(string value){
			this.goodRecordName_ = value;
		}
		public string GetGoodName(){
			return this.goodName_;
		}
		
		public void SetGoodName(string value){
			this.goodName_ = value;
		}
		public string GetGoodEnglishName(){
			return this.goodEnglishName_;
		}
		
		public void SetGoodEnglishName(string value){
			this.goodEnglishName_ = value;
		}
		public string GetIngredients(){
			return this.ingredients_;
		}
		
		public void SetIngredients(string value){
			this.ingredients_ = value;
		}
		public string GetCommodityFunction(){
			return this.commodityFunction_;
		}
		
		public void SetCommodityFunction(string value){
			this.commodityFunction_ = value;
		}
		public string GetEffect(){
			return this.effect_;
		}
		
		public void SetEffect(string value){
			this.effect_ = value;
		}
		public string GetGoodDetail(){
			return this.goodDetail_;
		}
		
		public void SetGoodDetail(string value){
			this.goodDetail_ = value;
		}
		public string GetStandardType(){
			return this.standardType_;
		}
		
		public void SetStandardType(string value){
			this.standardType_ = value;
		}
		public double? GetGrossWeight(){
			return this.grossWeight_;
		}
		
		public void SetGrossWeight(double? value){
			this.grossWeight_ = value;
		}
		public double? GetNetWeight(){
			return this.netWeight_;
		}
		
		public void SetNetWeight(double? value){
			this.netWeight_ = value;
		}
		public string GetUnit(){
			return this.unit_;
		}
		
		public void SetUnit(string value){
			this.unit_ = value;
		}
		public double? GetRecordPrice(){
			return this.recordPrice_;
		}
		
		public void SetRecordPrice(double? value){
			this.recordPrice_ = value;
		}
		public string GetExpiryDate(){
			return this.expiryDate_;
		}
		
		public void SetExpiryDate(string value){
			this.expiryDate_ = value;
		}
		public string GetCiqCountry(){
			return this.ciqCountry_;
		}
		
		public void SetCiqCountry(string value){
			this.ciqCountry_ = value;
		}
		public string GetCountry(){
			return this.country_;
		}
		
		public void SetCountry(string value){
			this.country_ = value;
		}
		public string GetProductionStandard(){
			return this.productionStandard_;
		}
		
		public void SetProductionStandard(string value){
			this.productionStandard_ = value;
		}
		public string GetCurrency(){
			return this.currency_;
		}
		
		public void SetCurrency(string value){
			this.currency_ = value;
		}
		public string GetBrand(){
			return this.brand_;
		}
		
		public void SetBrand(string value){
			this.brand_ = value;
		}
		public string GetBrandType(){
			return this.brandType_;
		}
		
		public void SetBrandType(string value){
			this.brandType_ = value;
		}
		public string GetFactory(){
			return this.factory_;
		}
		
		public void SetFactory(string value){
			this.factory_ = value;
		}
		public string GetFactoryAddress(){
			return this.factoryAddress_;
		}
		
		public void SetFactoryAddress(string value){
			this.factoryAddress_ = value;
		}
		public string GetFactoryRecord(){
			return this.factoryRecord_;
		}
		
		public void SetFactoryRecord(string value){
			this.factoryRecord_ = value;
		}
		public string GetGoodsType(){
			return this.goodsType_;
		}
		
		public void SetGoodsType(string value){
			this.goodsType_ = value;
		}
		public string GetExportBenefit(){
			return this.exportBenefit_;
		}
		
		public void SetExportBenefit(string value){
			this.exportBenefit_ = value;
		}
		public string GetCommodityQuality(){
			return this.commodityQuality_;
		}
		
		public void SetCommodityQuality(string value){
			this.commodityQuality_ = value;
		}
		public double? GetLengthUnit(){
			return this.lengthUnit_;
		}
		
		public void SetLengthUnit(double? value){
			this.lengthUnit_ = value;
		}
		public double? GetWidthUnit(){
			return this.widthUnit_;
		}
		
		public void SetWidthUnit(double? value){
			this.widthUnit_ = value;
		}
		public double? GetHeightUnit(){
			return this.heightUnit_;
		}
		
		public void SetHeightUnit(double? value){
			this.heightUnit_ = value;
		}
		public double? GetVolumeUnit(){
			return this.volumeUnit_;
		}
		
		public void SetVolumeUnit(double? value){
			this.volumeUnit_ = value;
		}
		public string GetIeflag(){
			return this.ieflag_;
		}
		
		public void SetIeflag(string value){
			this.ieflag_ = value;
		}
		public string GetBatchNumber(){
			return this.batchNumber_;
		}
		
		public void SetBatchNumber(string value){
			this.batchNumber_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public string GetRecordType(){
			return this.recordType_;
		}
		
		public void SetRecordType(string value){
			this.recordType_ = value;
		}
		public string GetEnterpriseName(){
			return this.enterpriseName_;
		}
		
		public void SetEnterpriseName(string value){
			this.enterpriseName_ = value;
		}
		public string GetEnterpriseCusNo(){
			return this.enterpriseCusNo_;
		}
		
		public void SetEnterpriseCusNo(string value){
			this.enterpriseCusNo_ = value;
		}
		public string GetEnterpriseCiqNo(){
			return this.enterpriseCiqNo_;
		}
		
		public void SetEnterpriseCiqNo(string value){
			this.enterpriseCiqNo_ = value;
		}
		public string GetBusinessType(){
			return this.businessType_;
		}
		
		public void SetBusinessType(string value){
			this.businessType_ = value;
		}
		public int? GetUnitConvertQuantity(){
			return this.unitConvertQuantity_;
		}
		
		public void SetUnitConvertQuantity(int? value){
			this.unitConvertQuantity_ = value;
		}
		public string GetGoodsSaleUrl(){
			return this.goodsSaleUrl_;
		}
		
		public void SetGoodsSaleUrl(string value){
			this.goodsSaleUrl_ = value;
		}
		public bool? GetIsOverFoodAdditives(){
			return this.isOverFoodAdditives_;
		}
		
		public void SetIsOverFoodAdditives(bool? value){
			this.isOverFoodAdditives_ = value;
		}
		public bool? GetIsContainPoison(){
			return this.isContainPoison_;
		}
		
		public void SetIsContainPoison(bool? value){
			this.isContainPoison_ = value;
		}
		public bool? GetIsGift(){
			return this.isGift_;
		}
		
		public void SetIsGift(bool? value){
			this.isGift_ = value;
		}
		public bool? GetIsSn(){
			return this.isSn_;
		}
		
		public void SetIsSn(bool? value){
			this.isSn_ = value;
		}
		public string GetAccordRule(){
			return this.accordRule_;
		}
		
		public void SetAccordRule(string value){
			this.accordRule_ = value;
		}
		public string GetFrontPicture(){
			return this.frontPicture_;
		}
		
		public void SetFrontPicture(string value){
			this.frontPicture_ = value;
		}
		public string GetBackPicture(){
			return this.backPicture_;
		}
		
		public void SetBackPicture(string value){
			this.backPicture_ = value;
		}
		public string GetLabelPicture(){
			return this.labelPicture_;
		}
		
		public void SetLabelPicture(string value){
			this.labelPicture_ = value;
		}
		public string GetStatementPicture(){
			return this.statementPicture_;
		}
		
		public void SetStatementPicture(string value){
			this.statementPicture_ = value;
		}
		public string GetCosmeticHazardIdTable(){
			return this.cosmeticHazardIdTable_;
		}
		
		public void SetCosmeticHazardIdTable(string value){
			this.cosmeticHazardIdTable_ = value;
		}
		public string GetClearanceMode(){
			return this.clearanceMode_;
		}
		
		public void SetClearanceMode(string value){
			this.clearanceMode_ = value;
		}
		public string GetCiqUnit(){
			return this.ciqUnit_;
		}
		
		public void SetCiqUnit(string value){
			this.ciqUnit_ = value;
		}
		
	}
	
}