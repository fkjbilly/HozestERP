using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.base.osp.service.record{
	
	
	
	public class HtGoodRecordModelHelper : TBeanSerializer<HtGoodRecordModel>
	{
		
		public static HtGoodRecordModelHelper OBJ = new HtGoodRecordModelHelper();
		
		public static HtGoodRecordModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtGoodRecordModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("goodRecordName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodRecordName(value);
					}
					
					
					
					
					
					if ("goodNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodNo(value);
					}
					
					
					
					
					
					if ("goodSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodSn(value);
					}
					
					
					
					
					
					if ("goodHsCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodHsCode(value);
					}
					
					
					
					
					
					if ("parcelTaxRate".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetParcelTaxRate(value);
					}
					
					
					
					
					
					if ("ieflag".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIeflag(value);
					}
					
					
					
					
					
					if ("parcelTaxNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetParcelTaxNo(value);
					}
					
					
					
					
					
					if ("parcelTaxName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetParcelTaxName(value);
					}
					
					
					
					
					
					if ("unit".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUnit(value);
					}
					
					
					
					
					
					if ("recordPrice".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetRecordPrice(value);
					}
					
					
					
					
					
					if ("grossWeight".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetGrossWeight(value);
					}
					
					
					
					
					
					if ("netWeight".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetNetWeight(value);
					}
					
					
					
					
					
					if ("hsTaxRate".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetHsTaxRate(value);
					}
					
					
					
					
					
					if ("customsname".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomsname(value);
					}
					
					
					
					
					
					if ("goodRecordNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodRecordNo(value);
					}
					
					
					
					
					
					if ("carriername".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriername(value);
					}
					
					
					
					
					
					if ("carriercode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriercode(value);
					}
					
					
					
					
					
					if ("customscode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomscode(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
					}
					
					
					
					
					
					if ("goodShelvesName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodShelvesName(value);
					}
					
					
					
					
					
					if ("country".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCountry(value);
					}
					
					
					
					
					
					if ("currency".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCurrency(value);
					}
					
					
					
					
					
					if ("goodName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodName(value);
					}
					
					
					
					
					
					if ("goodDetail".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodDetail(value);
					}
					
					
					
					
					
					if ("standardType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStandardType(value);
					}
					
					
					
					
					
					if ("effect".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEffect(value);
					}
					
					
					
					
					
					if ("packageType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPackageType(value);
					}
					
					
					
					
					
					if ("brand".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand(value);
					}
					
					
					
					
					
					if ("ingredients".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIngredients(value);
					}
					
					
					
					
					
					if ("factory".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFactory(value);
					}
					
					
					
					
					
					if ("batchNumber".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatchNumber(value);
					}
					
					
					
					
					
					if ("ciqUnit".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCiqUnit(value);
					}
					
					
					
					
					
					if ("ciqRecordNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCiqRecordNo(value);
					}
					
					
					
					
					
					if ("gno".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGno(value);
					}
					
					
					
					
					
					if ("customsDistrict".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomsDistrict(value);
					}
					
					
					
					
					
					if ("consumptionTaxRate".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetConsumptionTaxRate(value);
					}
					
					
					
					
					
					if ("valueAddedTaxRate".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetValueAddedTaxRate(value);
					}
					
					
					
					
					
					if ("legalUnitFirst".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLegalUnitFirst(value);
					}
					
					
					
					
					
					if ("legalUnitSecond".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLegalUnitSecond(value);
					}
					
					
					
					
					
					if ("legalAmountFirst".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLegalAmountFirst(value);
					}
					
					
					
					
					
					if ("legalAmountSecond".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLegalAmountSecond(value);
					}
					
					
					
					
					
					if ("recordPartNum".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRecordPartNum(value);
					}
					
					
					
					
					
					if ("expiryDate".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExpiryDate(value);
					}
					
					
					
					
					
					if ("productionStandard".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProductionStandard(value);
					}
					
					
					
					
					
					if ("ciqCountry".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCiqCountry(value);
					}
					
					
					
					
					
					if ("factoryAddress".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFactoryAddress(value);
					}
					
					
					
					
					
					if ("factoryRecord".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFactoryRecord(value);
					}
					
					
					
					
					
					if ("goodsType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodsType(value);
					}
					
					
					
					
					
					if ("frontPicture".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFrontPicture(value);
					}
					
					
					
					
					
					if ("backPicture".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBackPicture(value);
					}
					
					
					
					
					
					if ("labelPicture".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLabelPicture(value);
					}
					
					
					
					
					
					if ("backupPicture".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBackupPicture(value);
					}
					
					
					
					
					
					if ("tarrifNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTarrifNo(value);
					}
					
					
					
					
					
					if ("element".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetElement(value);
					}
					
					
					
					
					
					if ("goodEnglishName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodEnglishName(value);
					}
					
					
					
					
					
					if ("useMethod".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUseMethod(value);
					}
					
					
					
					
					
					if ("applyCrowd".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetApplyCrowd(value);
					}
					
					
					
					
					
					if ("storageCondition".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStorageCondition(value);
					}
					
					
					
					
					
					if ("vipSellCost".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetVipSellCost(value);
					}
					
					
					
					
					
					if ("dateOfManufacture".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetDateOfManufacture(value);
					}
					
					
					
					
					
					if ("manufacturerLinkman".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetManufacturerLinkman(value);
					}
					
					
					
					
					
					if ("manufacturerPhone".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetManufacturerPhone(value);
					}
					
					
					
					
					
					if ("weavingProcess".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWeavingProcess(value);
					}
					
					
					
					
					
					if ("garmentTypes".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGarmentTypes(value);
					}
					
					
					
					
					
					if ("manOrWomensClothing".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetManOrWomensClothing(value);
					}
					
					
					
					
					
					if ("foreignCurrency".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetForeignCurrency(value);
					}
					
					
					
					
					
					if ("foreignPrice".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetForeignPrice(value);
					}
					
					
					
					
					
					if ("typeOfMerchandize".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTypeOfMerchandize(value);
					}
					
					
					
					
					
					if ("isGroup".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsGroup(value);
					}
					
					
					
					
					
					if ("enterpriseName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEnterpriseName(value);
					}
					
					
					
					
					
					if ("enterpriseCusNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEnterpriseCusNo(value);
					}
					
					
					
					
					
					if ("enterpriseCiqNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEnterpriseCiqNo(value);
					}
					
					
					
					
					
					if ("declareCusCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDeclareCusCode(value);
					}
					
					
					
					
					
					if ("declareCiqCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDeclareCiqCode(value);
					}
					
					
					
					
					
					if ("brandType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrandType(value);
					}
					
					
					
					
					
					if ("exportBenefit".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExportBenefit(value);
					}
					
					
					
					
					
					if ("commodityQuality".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCommodityQuality(value);
					}
					
					
					
					
					
					if ("lengthUnit".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetLengthUnit(value);
					}
					
					
					
					
					
					if ("widthUnit".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetWidthUnit(value);
					}
					
					
					
					
					
					if ("heightUnit".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetHeightUnit(value);
					}
					
					
					
					
					
					if ("volumeUnit".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetVolumeUnit(value);
					}
					
					
					
					
					
					if ("businessType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBusinessType(value);
					}
					
					
					
					
					
					if ("unitConvertQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUnitConvertQuantity(value);
					}
					
					
					
					
					
					if ("enterpriseWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEnterpriseWarehouse(value);
					}
					
					
					
					
					
					if ("goodsSaleUrl".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodsSaleUrl(value);
					}
					
					
					
					
					
					if ("isOverFoodAdditives".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsOverFoodAdditives(value);
					}
					
					
					
					
					
					if ("isContainPoison".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsContainPoison(value);
					}
					
					
					
					
					
					if ("isGift".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsGift(value);
					}
					
					
					
					
					
					if ("isSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsSn(value);
					}
					
					
					
					
					
					if ("isLawReview".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsLawReview(value);
					}
					
					
					
					
					
					if ("accordRule".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAccordRule(value);
					}
					
					
					
					
					
					if ("modifyFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetModifyFlag(value);
					}
					
					
					
					
					if(needSkip){
						
						ProtocolUtil.skip(iprot);
					}
					
					iprot.ReadFieldEnd();
				}
				
				iprot.ReadStructEnd();
				Validate(structs);
			}
			else{
				
				throw new OspException();
			}
			
			
		}
		
		
		public void Write(HtGoodRecordModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetGoodRecordName() != null) {
				
				oprot.WriteFieldBegin("goodRecordName");
				oprot.WriteString(structs.GetGoodRecordName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodNo() != null) {
				
				oprot.WriteFieldBegin("goodNo");
				oprot.WriteString(structs.GetGoodNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodSn() != null) {
				
				oprot.WriteFieldBegin("goodSn");
				oprot.WriteString(structs.GetGoodSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodHsCode() != null) {
				
				oprot.WriteFieldBegin("goodHsCode");
				oprot.WriteString(structs.GetGoodHsCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetParcelTaxRate() != null) {
				
				oprot.WriteFieldBegin("parcelTaxRate");
				oprot.WriteDouble((double)structs.GetParcelTaxRate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIeflag() != null) {
				
				oprot.WriteFieldBegin("ieflag");
				oprot.WriteString(structs.GetIeflag());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetParcelTaxNo() != null) {
				
				oprot.WriteFieldBegin("parcelTaxNo");
				oprot.WriteString(structs.GetParcelTaxNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetParcelTaxName() != null) {
				
				oprot.WriteFieldBegin("parcelTaxName");
				oprot.WriteString(structs.GetParcelTaxName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnit() != null) {
				
				oprot.WriteFieldBegin("unit");
				oprot.WriteString(structs.GetUnit());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRecordPrice() != null) {
				
				oprot.WriteFieldBegin("recordPrice");
				oprot.WriteDouble((double)structs.GetRecordPrice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGrossWeight() != null) {
				
				oprot.WriteFieldBegin("grossWeight");
				oprot.WriteDouble((double)structs.GetGrossWeight());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNetWeight() != null) {
				
				oprot.WriteFieldBegin("netWeight");
				oprot.WriteDouble((double)structs.GetNetWeight());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHsTaxRate() != null) {
				
				oprot.WriteFieldBegin("hsTaxRate");
				oprot.WriteDouble((double)structs.GetHsTaxRate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustomsname() != null) {
				
				oprot.WriteFieldBegin("customsname");
				oprot.WriteString(structs.GetCustomsname());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodRecordNo() != null) {
				
				oprot.WriteFieldBegin("goodRecordNo");
				oprot.WriteString(structs.GetGoodRecordNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriername() != null) {
				
				oprot.WriteFieldBegin("carriername");
				oprot.WriteString(structs.GetCarriername());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriercode() != null) {
				
				oprot.WriteFieldBegin("carriercode");
				oprot.WriteString(structs.GetCarriercode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustomscode() != null) {
				
				oprot.WriteFieldBegin("customscode");
				oprot.WriteString(structs.GetCustomscode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodShelvesName() != null) {
				
				oprot.WriteFieldBegin("goodShelvesName");
				oprot.WriteString(structs.GetGoodShelvesName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCountry() != null) {
				
				oprot.WriteFieldBegin("country");
				oprot.WriteString(structs.GetCountry());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCurrency() != null) {
				
				oprot.WriteFieldBegin("currency");
				oprot.WriteString(structs.GetCurrency());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodName() != null) {
				
				oprot.WriteFieldBegin("goodName");
				oprot.WriteString(structs.GetGoodName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodDetail() != null) {
				
				oprot.WriteFieldBegin("goodDetail");
				oprot.WriteString(structs.GetGoodDetail());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStandardType() != null) {
				
				oprot.WriteFieldBegin("standardType");
				oprot.WriteString(structs.GetStandardType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEffect() != null) {
				
				oprot.WriteFieldBegin("effect");
				oprot.WriteString(structs.GetEffect());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPackageType() != null) {
				
				oprot.WriteFieldBegin("packageType");
				oprot.WriteString(structs.GetPackageType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand() != null) {
				
				oprot.WriteFieldBegin("brand");
				oprot.WriteString(structs.GetBrand());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIngredients() != null) {
				
				oprot.WriteFieldBegin("ingredients");
				oprot.WriteString(structs.GetIngredients());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFactory() != null) {
				
				oprot.WriteFieldBegin("factory");
				oprot.WriteString(structs.GetFactory());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBatchNumber() != null) {
				
				oprot.WriteFieldBegin("batchNumber");
				oprot.WriteString(structs.GetBatchNumber());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCiqUnit() != null) {
				
				oprot.WriteFieldBegin("ciqUnit");
				oprot.WriteString(structs.GetCiqUnit());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCiqRecordNo() != null) {
				
				oprot.WriteFieldBegin("ciqRecordNo");
				oprot.WriteString(structs.GetCiqRecordNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGno() != null) {
				
				oprot.WriteFieldBegin("gno");
				oprot.WriteString(structs.GetGno());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustomsDistrict() != null) {
				
				oprot.WriteFieldBegin("customsDistrict");
				oprot.WriteString(structs.GetCustomsDistrict());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetConsumptionTaxRate() != null) {
				
				oprot.WriteFieldBegin("consumptionTaxRate");
				oprot.WriteDouble((double)structs.GetConsumptionTaxRate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetValueAddedTaxRate() != null) {
				
				oprot.WriteFieldBegin("valueAddedTaxRate");
				oprot.WriteDouble((double)structs.GetValueAddedTaxRate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLegalUnitFirst() != null) {
				
				oprot.WriteFieldBegin("legalUnitFirst");
				oprot.WriteString(structs.GetLegalUnitFirst());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLegalUnitSecond() != null) {
				
				oprot.WriteFieldBegin("legalUnitSecond");
				oprot.WriteString(structs.GetLegalUnitSecond());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLegalAmountFirst() != null) {
				
				oprot.WriteFieldBegin("legalAmountFirst");
				oprot.WriteString(structs.GetLegalAmountFirst());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLegalAmountSecond() != null) {
				
				oprot.WriteFieldBegin("legalAmountSecond");
				oprot.WriteString(structs.GetLegalAmountSecond());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRecordPartNum() != null) {
				
				oprot.WriteFieldBegin("recordPartNum");
				oprot.WriteString(structs.GetRecordPartNum());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExpiryDate() != null) {
				
				oprot.WriteFieldBegin("expiryDate");
				oprot.WriteString(structs.GetExpiryDate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProductionStandard() != null) {
				
				oprot.WriteFieldBegin("productionStandard");
				oprot.WriteString(structs.GetProductionStandard());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCiqCountry() != null) {
				
				oprot.WriteFieldBegin("ciqCountry");
				oprot.WriteString(structs.GetCiqCountry());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFactoryAddress() != null) {
				
				oprot.WriteFieldBegin("factoryAddress");
				oprot.WriteString(structs.GetFactoryAddress());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFactoryRecord() != null) {
				
				oprot.WriteFieldBegin("factoryRecord");
				oprot.WriteString(structs.GetFactoryRecord());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsType() != null) {
				
				oprot.WriteFieldBegin("goodsType");
				oprot.WriteString(structs.GetGoodsType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFrontPicture() != null) {
				
				oprot.WriteFieldBegin("frontPicture");
				oprot.WriteString(structs.GetFrontPicture());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBackPicture() != null) {
				
				oprot.WriteFieldBegin("backPicture");
				oprot.WriteString(structs.GetBackPicture());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLabelPicture() != null) {
				
				oprot.WriteFieldBegin("labelPicture");
				oprot.WriteString(structs.GetLabelPicture());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBackupPicture() != null) {
				
				oprot.WriteFieldBegin("backupPicture");
				oprot.WriteString(structs.GetBackupPicture());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTarrifNo() != null) {
				
				oprot.WriteFieldBegin("tarrifNo");
				oprot.WriteString(structs.GetTarrifNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetElement() != null) {
				
				oprot.WriteFieldBegin("element");
				oprot.WriteString(structs.GetElement());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodEnglishName() != null) {
				
				oprot.WriteFieldBegin("goodEnglishName");
				oprot.WriteString(structs.GetGoodEnglishName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUseMethod() != null) {
				
				oprot.WriteFieldBegin("useMethod");
				oprot.WriteString(structs.GetUseMethod());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetApplyCrowd() != null) {
				
				oprot.WriteFieldBegin("applyCrowd");
				oprot.WriteString(structs.GetApplyCrowd());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStorageCondition() != null) {
				
				oprot.WriteFieldBegin("storageCondition");
				oprot.WriteString(structs.GetStorageCondition());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipSellCost() != null) {
				
				oprot.WriteFieldBegin("vipSellCost");
				oprot.WriteDouble((double)structs.GetVipSellCost());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDateOfManufacture() != null) {
				
				oprot.WriteFieldBegin("dateOfManufacture");
				oprot.WriteI64((long)structs.GetDateOfManufacture()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetManufacturerLinkman() != null) {
				
				oprot.WriteFieldBegin("manufacturerLinkman");
				oprot.WriteString(structs.GetManufacturerLinkman());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetManufacturerPhone() != null) {
				
				oprot.WriteFieldBegin("manufacturerPhone");
				oprot.WriteString(structs.GetManufacturerPhone());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWeavingProcess() != null) {
				
				oprot.WriteFieldBegin("weavingProcess");
				oprot.WriteString(structs.GetWeavingProcess());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGarmentTypes() != null) {
				
				oprot.WriteFieldBegin("garmentTypes");
				oprot.WriteString(structs.GetGarmentTypes());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetManOrWomensClothing() != null) {
				
				oprot.WriteFieldBegin("manOrWomensClothing");
				oprot.WriteString(structs.GetManOrWomensClothing());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetForeignCurrency() != null) {
				
				oprot.WriteFieldBegin("foreignCurrency");
				oprot.WriteString(structs.GetForeignCurrency());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetForeignPrice() != null) {
				
				oprot.WriteFieldBegin("foreignPrice");
				oprot.WriteDouble((double)structs.GetForeignPrice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTypeOfMerchandize() != null) {
				
				oprot.WriteFieldBegin("typeOfMerchandize");
				oprot.WriteString(structs.GetTypeOfMerchandize());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsGroup() != null) {
				
				oprot.WriteFieldBegin("isGroup");
				oprot.WriteBool((bool)structs.GetIsGroup());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEnterpriseName() != null) {
				
				oprot.WriteFieldBegin("enterpriseName");
				oprot.WriteString(structs.GetEnterpriseName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEnterpriseCusNo() != null) {
				
				oprot.WriteFieldBegin("enterpriseCusNo");
				oprot.WriteString(structs.GetEnterpriseCusNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEnterpriseCiqNo() != null) {
				
				oprot.WriteFieldBegin("enterpriseCiqNo");
				oprot.WriteString(structs.GetEnterpriseCiqNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDeclareCusCode() != null) {
				
				oprot.WriteFieldBegin("declareCusCode");
				oprot.WriteString(structs.GetDeclareCusCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDeclareCiqCode() != null) {
				
				oprot.WriteFieldBegin("declareCiqCode");
				oprot.WriteString(structs.GetDeclareCiqCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrandType() != null) {
				
				oprot.WriteFieldBegin("brandType");
				oprot.WriteString(structs.GetBrandType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExportBenefit() != null) {
				
				oprot.WriteFieldBegin("exportBenefit");
				oprot.WriteString(structs.GetExportBenefit());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCommodityQuality() != null) {
				
				oprot.WriteFieldBegin("commodityQuality");
				oprot.WriteString(structs.GetCommodityQuality());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLengthUnit() != null) {
				
				oprot.WriteFieldBegin("lengthUnit");
				oprot.WriteDouble((double)structs.GetLengthUnit());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWidthUnit() != null) {
				
				oprot.WriteFieldBegin("widthUnit");
				oprot.WriteDouble((double)structs.GetWidthUnit());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHeightUnit() != null) {
				
				oprot.WriteFieldBegin("heightUnit");
				oprot.WriteDouble((double)structs.GetHeightUnit());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVolumeUnit() != null) {
				
				oprot.WriteFieldBegin("volumeUnit");
				oprot.WriteDouble((double)structs.GetVolumeUnit());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBusinessType() != null) {
				
				oprot.WriteFieldBegin("businessType");
				oprot.WriteString(structs.GetBusinessType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnitConvertQuantity() != null) {
				
				oprot.WriteFieldBegin("unitConvertQuantity");
				oprot.WriteString(structs.GetUnitConvertQuantity());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEnterpriseWarehouse() != null) {
				
				oprot.WriteFieldBegin("enterpriseWarehouse");
				oprot.WriteString(structs.GetEnterpriseWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsSaleUrl() != null) {
				
				oprot.WriteFieldBegin("goodsSaleUrl");
				oprot.WriteString(structs.GetGoodsSaleUrl());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsOverFoodAdditives() != null) {
				
				oprot.WriteFieldBegin("isOverFoodAdditives");
				oprot.WriteBool((bool)structs.GetIsOverFoodAdditives());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsContainPoison() != null) {
				
				oprot.WriteFieldBegin("isContainPoison");
				oprot.WriteBool((bool)structs.GetIsContainPoison());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsGift() != null) {
				
				oprot.WriteFieldBegin("isGift");
				oprot.WriteBool((bool)structs.GetIsGift());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsSn() != null) {
				
				oprot.WriteFieldBegin("isSn");
				oprot.WriteBool((bool)structs.GetIsSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsLawReview() != null) {
				
				oprot.WriteFieldBegin("isLawReview");
				oprot.WriteBool((bool)structs.GetIsLawReview());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAccordRule() != null) {
				
				oprot.WriteFieldBegin("accordRule");
				oprot.WriteString(structs.GetAccordRule());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetModifyFlag() != null) {
				
				oprot.WriteFieldBegin("modifyFlag");
				oprot.WriteI32((int)structs.GetModifyFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtGoodRecordModel bean){
			
			
		}
		
	}
	
}