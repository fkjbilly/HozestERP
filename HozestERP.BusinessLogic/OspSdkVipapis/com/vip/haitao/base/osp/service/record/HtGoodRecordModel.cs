using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.base.osp.service.record{
	
	
	
	
	
	public class HtGoodRecordModel {
		
		///<summary>
		/// 商品备案名称
		///</summary>
		
		private string goodRecordName_;
		
		///<summary>
		/// 商品货号
		///</summary>
		
		private string goodNo_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string goodSn_;
		
		///<summary>
		/// 商品HS编码
		///</summary>
		
		private string goodHsCode_;
		
		///<summary>
		/// 行邮税率
		///</summary>
		
		private double? parcelTaxRate_;
		
		///<summary>
		/// 进出口标示
		///</summary>
		
		private string ieflag_;
		
		///<summary>
		/// 行邮税号
		///</summary>
		
		private string parcelTaxNo_;
		
		///<summary>
		/// 行邮税名称
		///</summary>
		
		private string parcelTaxName_;
		
		///<summary>
		/// 申报计量单位
		///</summary>
		
		private string unit_;
		
		///<summary>
		/// 备案价格
		///</summary>
		
		private double? recordPrice_;
		
		///<summary>
		/// 毛重
		///</summary>
		
		private double? grossWeight_;
		
		///<summary>
		/// 净重
		///</summary>
		
		private double? netWeight_;
		
		///<summary>
		/// HS税率
		///</summary>
		
		private double? hsTaxRate_;
		
		///<summary>
		/// 备案海关名称
		///</summary>
		
		private string customsname_;
		
		///<summary>
		/// 海关备案号
		///</summary>
		
		private string goodRecordNo_;
		
		///<summary>
		/// 备案承运商名称
		///</summary>
		
		private string carriername_;
		
		///<summary>
		/// 备案承运商代码
		///</summary>
		
		private string carriercode_;
		
		///<summary>
		/// 备案海关代码
		///</summary>
		
		private string customscode_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 商品上架名
		///</summary>
		
		private string goodShelvesName_;
		
		///<summary>
		/// 原产国
		///</summary>
		
		private string country_;
		
		///<summary>
		/// 币制
		///</summary>
		
		private string currency_;
		
		///<summary>
		/// 商品名
		///</summary>
		
		private string goodName_;
		
		///<summary>
		/// 商品描述
		///</summary>
		
		private string goodDetail_;
		
		///<summary>
		/// 规格型号
		///</summary>
		
		private string standardType_;
		
		///<summary>
		/// 用途
		///</summary>
		
		private string effect_;
		
		///<summary>
		/// 包装型号
		///</summary>
		
		private string packageType_;
		
		///<summary>
		/// 品牌
		///</summary>
		
		private string brand_;
		
		///<summary>
		/// 成分含量
		///</summary>
		
		private string ingredients_;
		
		///<summary>
		/// 生产厂家
		///</summary>
		
		private string factory_;
		
		///<summary>
		/// 商品批次号
		///</summary>
		
		private string batchNumber_;
		
		///<summary>
		/// 国检单位
		///</summary>
		
		private string ciqUnit_;
		
		///<summary>
		/// 商检备案号
		///</summary>
		
		private string ciqRecordNo_;
		
		///<summary>
		/// 关联h2010项号
		///</summary>
		
		private string gno_;
		
		///<summary>
		/// 关区代码
		///</summary>
		
		private string customsDistrict_;
		
		///<summary>
		/// 消费税
		///</summary>
		
		private double? consumptionTaxRate_;
		
		///<summary>
		/// 增值税
		///</summary>
		
		private double? valueAddedTaxRate_;
		
		///<summary>
		/// 法定第一计量单位
		///</summary>
		
		private string legalUnitFirst_;
		
		///<summary>
		/// 法定第二计量单位
		///</summary>
		
		private string legalUnitSecond_;
		
		///<summary>
		/// 法定第一数量
		///</summary>
		
		private string legalAmountFirst_;
		
		///<summary>
		/// 法定第二数量
		///</summary>
		
		private string legalAmountSecond_;
		
		///<summary>
		/// 账册备案料号
		///</summary>
		
		private string recordPartNum_;
		
		///<summary>
		/// 保质期
		///</summary>
		
		private string expiryDate_;
		
		///<summary>
		/// 产品适用的生产标准国别
		///</summary>
		
		private string productionStandard_;
		
		///<summary>
		/// 国检原产国/地区
		///</summary>
		
		private string ciqCountry_;
		
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
		/// 声明图片
		///</summary>
		
		private string backupPicture_;
		
		///<summary>
		/// 税则号
		///</summary>
		
		private string tarrifNo_;
		
		///<summary>
		/// 申报要素
		///</summary>
		
		private string element_;
		
		///<summary>
		/// 商品英文名称
		///</summary>
		
		private string goodEnglishName_;
		
		///<summary>
		/// 使用方法
		///</summary>
		
		private string useMethod_;
		
		///<summary>
		/// 适用人群
		///</summary>
		
		private string applyCrowd_;
		
		///<summary>
		/// 储存条件
		///</summary>
		
		private string storageCondition_;
		
		///<summary>
		/// VIP售卖价格
		///</summary>
		
		private double? vipSellCost_;
		
		///<summary>
		/// 生产日期
		///</summary>
		
		private long? dateOfManufacture_;
		
		///<summary>
		/// 生产厂家联系人
		///</summary>
		
		private string manufacturerLinkman_;
		
		///<summary>
		/// 生产厂家联系电话
		///</summary>
		
		private string manufacturerPhone_;
		
		///<summary>
		/// 织造方法：针织，梭织，钩编等
		///</summary>
		
		private string weavingProcess_;
		
		///<summary>
		/// 服装类型：马甲，套装，背心等
		///</summary>
		
		private string garmentTypes_;
		
		///<summary>
		/// 男装或女装：0-女装, 1-男装
		///</summary>
		
		private string manOrWomensClothing_;
		
		///<summary>
		/// 外币币制
		///</summary>
		
		private string foreignCurrency_;
		
		///<summary>
		/// 外币单价
		///</summary>
		
		private double? foreignPrice_;
		
		///<summary>
		/// 商品种类
		///</summary>
		
		private string typeOfMerchandize_;
		
		///<summary>
		/// 是否套装：0-否，1-是
		///</summary>
		
		private bool? isGroup_;
		
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
		/// 申报地海关代码
		///</summary>
		
		private string declareCusCode_;
		
		///<summary>
		/// 申报地国检代码
		///</summary>
		
		private string declareCiqCode_;
		
		///<summary>
		/// 品牌类型
		///</summary>
		
		private string brandType_;
		
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
		/// 业务类型
		///</summary>
		
		private string businessType_;
		
		///<summary>
		/// 入区计量单位折算数量
		///</summary>
		
		private string unitConvertQuantity_;
		
		///<summary>
		/// 仓库企业代码
		///</summary>
		
		private string enterpriseWarehouse_;
		
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
		/// 法检：0-否,1-是
		///</summary>
		
		private bool? isLawReview_;
		
		///<summary>
		/// 符合国家相关法规：Y/N
		///</summary>
		
		private string accordRule_;
		
		///<summary>
		/// 修改标志：0-新增，1-修改，2-删除
		///</summary>
		
		private int? modifyFlag_;
		
		public string GetGoodRecordName(){
			return this.goodRecordName_;
		}
		
		public void SetGoodRecordName(string value){
			this.goodRecordName_ = value;
		}
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
		public string GetGoodHsCode(){
			return this.goodHsCode_;
		}
		
		public void SetGoodHsCode(string value){
			this.goodHsCode_ = value;
		}
		public double? GetParcelTaxRate(){
			return this.parcelTaxRate_;
		}
		
		public void SetParcelTaxRate(double? value){
			this.parcelTaxRate_ = value;
		}
		public string GetIeflag(){
			return this.ieflag_;
		}
		
		public void SetIeflag(string value){
			this.ieflag_ = value;
		}
		public string GetParcelTaxNo(){
			return this.parcelTaxNo_;
		}
		
		public void SetParcelTaxNo(string value){
			this.parcelTaxNo_ = value;
		}
		public string GetParcelTaxName(){
			return this.parcelTaxName_;
		}
		
		public void SetParcelTaxName(string value){
			this.parcelTaxName_ = value;
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
		public double? GetHsTaxRate(){
			return this.hsTaxRate_;
		}
		
		public void SetHsTaxRate(double? value){
			this.hsTaxRate_ = value;
		}
		public string GetCustomsname(){
			return this.customsname_;
		}
		
		public void SetCustomsname(string value){
			this.customsname_ = value;
		}
		public string GetGoodRecordNo(){
			return this.goodRecordNo_;
		}
		
		public void SetGoodRecordNo(string value){
			this.goodRecordNo_ = value;
		}
		public string GetCarriername(){
			return this.carriername_;
		}
		
		public void SetCarriername(string value){
			this.carriername_ = value;
		}
		public string GetCarriercode(){
			return this.carriercode_;
		}
		
		public void SetCarriercode(string value){
			this.carriercode_ = value;
		}
		public string GetCustomscode(){
			return this.customscode_;
		}
		
		public void SetCustomscode(string value){
			this.customscode_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public string GetGoodShelvesName(){
			return this.goodShelvesName_;
		}
		
		public void SetGoodShelvesName(string value){
			this.goodShelvesName_ = value;
		}
		public string GetCountry(){
			return this.country_;
		}
		
		public void SetCountry(string value){
			this.country_ = value;
		}
		public string GetCurrency(){
			return this.currency_;
		}
		
		public void SetCurrency(string value){
			this.currency_ = value;
		}
		public string GetGoodName(){
			return this.goodName_;
		}
		
		public void SetGoodName(string value){
			this.goodName_ = value;
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
		public string GetEffect(){
			return this.effect_;
		}
		
		public void SetEffect(string value){
			this.effect_ = value;
		}
		public string GetPackageType(){
			return this.packageType_;
		}
		
		public void SetPackageType(string value){
			this.packageType_ = value;
		}
		public string GetBrand(){
			return this.brand_;
		}
		
		public void SetBrand(string value){
			this.brand_ = value;
		}
		public string GetIngredients(){
			return this.ingredients_;
		}
		
		public void SetIngredients(string value){
			this.ingredients_ = value;
		}
		public string GetFactory(){
			return this.factory_;
		}
		
		public void SetFactory(string value){
			this.factory_ = value;
		}
		public string GetBatchNumber(){
			return this.batchNumber_;
		}
		
		public void SetBatchNumber(string value){
			this.batchNumber_ = value;
		}
		public string GetCiqUnit(){
			return this.ciqUnit_;
		}
		
		public void SetCiqUnit(string value){
			this.ciqUnit_ = value;
		}
		public string GetCiqRecordNo(){
			return this.ciqRecordNo_;
		}
		
		public void SetCiqRecordNo(string value){
			this.ciqRecordNo_ = value;
		}
		public string GetGno(){
			return this.gno_;
		}
		
		public void SetGno(string value){
			this.gno_ = value;
		}
		public string GetCustomsDistrict(){
			return this.customsDistrict_;
		}
		
		public void SetCustomsDistrict(string value){
			this.customsDistrict_ = value;
		}
		public double? GetConsumptionTaxRate(){
			return this.consumptionTaxRate_;
		}
		
		public void SetConsumptionTaxRate(double? value){
			this.consumptionTaxRate_ = value;
		}
		public double? GetValueAddedTaxRate(){
			return this.valueAddedTaxRate_;
		}
		
		public void SetValueAddedTaxRate(double? value){
			this.valueAddedTaxRate_ = value;
		}
		public string GetLegalUnitFirst(){
			return this.legalUnitFirst_;
		}
		
		public void SetLegalUnitFirst(string value){
			this.legalUnitFirst_ = value;
		}
		public string GetLegalUnitSecond(){
			return this.legalUnitSecond_;
		}
		
		public void SetLegalUnitSecond(string value){
			this.legalUnitSecond_ = value;
		}
		public string GetLegalAmountFirst(){
			return this.legalAmountFirst_;
		}
		
		public void SetLegalAmountFirst(string value){
			this.legalAmountFirst_ = value;
		}
		public string GetLegalAmountSecond(){
			return this.legalAmountSecond_;
		}
		
		public void SetLegalAmountSecond(string value){
			this.legalAmountSecond_ = value;
		}
		public string GetRecordPartNum(){
			return this.recordPartNum_;
		}
		
		public void SetRecordPartNum(string value){
			this.recordPartNum_ = value;
		}
		public string GetExpiryDate(){
			return this.expiryDate_;
		}
		
		public void SetExpiryDate(string value){
			this.expiryDate_ = value;
		}
		public string GetProductionStandard(){
			return this.productionStandard_;
		}
		
		public void SetProductionStandard(string value){
			this.productionStandard_ = value;
		}
		public string GetCiqCountry(){
			return this.ciqCountry_;
		}
		
		public void SetCiqCountry(string value){
			this.ciqCountry_ = value;
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
		public string GetBackupPicture(){
			return this.backupPicture_;
		}
		
		public void SetBackupPicture(string value){
			this.backupPicture_ = value;
		}
		public string GetTarrifNo(){
			return this.tarrifNo_;
		}
		
		public void SetTarrifNo(string value){
			this.tarrifNo_ = value;
		}
		public string GetElement(){
			return this.element_;
		}
		
		public void SetElement(string value){
			this.element_ = value;
		}
		public string GetGoodEnglishName(){
			return this.goodEnglishName_;
		}
		
		public void SetGoodEnglishName(string value){
			this.goodEnglishName_ = value;
		}
		public string GetUseMethod(){
			return this.useMethod_;
		}
		
		public void SetUseMethod(string value){
			this.useMethod_ = value;
		}
		public string GetApplyCrowd(){
			return this.applyCrowd_;
		}
		
		public void SetApplyCrowd(string value){
			this.applyCrowd_ = value;
		}
		public string GetStorageCondition(){
			return this.storageCondition_;
		}
		
		public void SetStorageCondition(string value){
			this.storageCondition_ = value;
		}
		public double? GetVipSellCost(){
			return this.vipSellCost_;
		}
		
		public void SetVipSellCost(double? value){
			this.vipSellCost_ = value;
		}
		public long? GetDateOfManufacture(){
			return this.dateOfManufacture_;
		}
		
		public void SetDateOfManufacture(long? value){
			this.dateOfManufacture_ = value;
		}
		public string GetManufacturerLinkman(){
			return this.manufacturerLinkman_;
		}
		
		public void SetManufacturerLinkman(string value){
			this.manufacturerLinkman_ = value;
		}
		public string GetManufacturerPhone(){
			return this.manufacturerPhone_;
		}
		
		public void SetManufacturerPhone(string value){
			this.manufacturerPhone_ = value;
		}
		public string GetWeavingProcess(){
			return this.weavingProcess_;
		}
		
		public void SetWeavingProcess(string value){
			this.weavingProcess_ = value;
		}
		public string GetGarmentTypes(){
			return this.garmentTypes_;
		}
		
		public void SetGarmentTypes(string value){
			this.garmentTypes_ = value;
		}
		public string GetManOrWomensClothing(){
			return this.manOrWomensClothing_;
		}
		
		public void SetManOrWomensClothing(string value){
			this.manOrWomensClothing_ = value;
		}
		public string GetForeignCurrency(){
			return this.foreignCurrency_;
		}
		
		public void SetForeignCurrency(string value){
			this.foreignCurrency_ = value;
		}
		public double? GetForeignPrice(){
			return this.foreignPrice_;
		}
		
		public void SetForeignPrice(double? value){
			this.foreignPrice_ = value;
		}
		public string GetTypeOfMerchandize(){
			return this.typeOfMerchandize_;
		}
		
		public void SetTypeOfMerchandize(string value){
			this.typeOfMerchandize_ = value;
		}
		public bool? GetIsGroup(){
			return this.isGroup_;
		}
		
		public void SetIsGroup(bool? value){
			this.isGroup_ = value;
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
		public string GetDeclareCusCode(){
			return this.declareCusCode_;
		}
		
		public void SetDeclareCusCode(string value){
			this.declareCusCode_ = value;
		}
		public string GetDeclareCiqCode(){
			return this.declareCiqCode_;
		}
		
		public void SetDeclareCiqCode(string value){
			this.declareCiqCode_ = value;
		}
		public string GetBrandType(){
			return this.brandType_;
		}
		
		public void SetBrandType(string value){
			this.brandType_ = value;
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
		public string GetBusinessType(){
			return this.businessType_;
		}
		
		public void SetBusinessType(string value){
			this.businessType_ = value;
		}
		public string GetUnitConvertQuantity(){
			return this.unitConvertQuantity_;
		}
		
		public void SetUnitConvertQuantity(string value){
			this.unitConvertQuantity_ = value;
		}
		public string GetEnterpriseWarehouse(){
			return this.enterpriseWarehouse_;
		}
		
		public void SetEnterpriseWarehouse(string value){
			this.enterpriseWarehouse_ = value;
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
		public bool? GetIsLawReview(){
			return this.isLawReview_;
		}
		
		public void SetIsLawReview(bool? value){
			this.isLawReview_ = value;
		}
		public string GetAccordRule(){
			return this.accordRule_;
		}
		
		public void SetAccordRule(string value){
			this.accordRule_ = value;
		}
		public int? GetModifyFlag(){
			return this.modifyFlag_;
		}
		
		public void SetModifyFlag(int? value){
			this.modifyFlag_ = value;
		}
		
	}
	
}