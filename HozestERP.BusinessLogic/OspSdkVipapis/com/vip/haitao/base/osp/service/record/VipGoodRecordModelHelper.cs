using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.base.osp.service.record{
	
	
	
	public class VipGoodRecordModelHelper : TBeanSerializer<VipGoodRecordModel>
	{
		
		public static VipGoodRecordModelHelper OBJ = new VipGoodRecordModelHelper();
		
		public static VipGoodRecordModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VipGoodRecordModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
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
					
					
					
					
					
					if ("goodRecordName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodRecordName(value);
					}
					
					
					
					
					
					if ("goodName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodName(value);
					}
					
					
					
					
					
					if ("goodEnglishName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodEnglishName(value);
					}
					
					
					
					
					
					if ("ingredients".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIngredients(value);
					}
					
					
					
					
					
					if ("commodityFunction".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCommodityFunction(value);
					}
					
					
					
					
					
					if ("effect".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEffect(value);
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
					
					
					
					
					
					if ("expiryDate".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExpiryDate(value);
					}
					
					
					
					
					
					if ("ciqCountry".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCiqCountry(value);
					}
					
					
					
					
					
					if ("country".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCountry(value);
					}
					
					
					
					
					
					if ("productionStandard".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProductionStandard(value);
					}
					
					
					
					
					
					if ("currency".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCurrency(value);
					}
					
					
					
					
					
					if ("brand".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand(value);
					}
					
					
					
					
					
					if ("brandType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrandType(value);
					}
					
					
					
					
					
					if ("factory".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFactory(value);
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
					
					
					
					
					
					if ("ieflag".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIeflag(value);
					}
					
					
					
					
					
					if ("batchNumber".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatchNumber(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
					}
					
					
					
					
					
					if ("recordType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRecordType(value);
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
					
					
					
					
					
					if ("businessType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBusinessType(value);
					}
					
					
					
					
					
					if ("unitConvertQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetUnitConvertQuantity(value);
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
					
					
					
					
					
					if ("accordRule".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAccordRule(value);
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
					
					
					
					
					
					if ("statementPicture".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStatementPicture(value);
					}
					
					
					
					
					
					if ("cosmeticHazardIdTable".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCosmeticHazardIdTable(value);
					}
					
					
					
					
					
					if ("clearanceMode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetClearanceMode(value);
					}
					
					
					
					
					
					if ("ciqUnit".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCiqUnit(value);
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
		
		
		public void Write(VipGoodRecordModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
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
			
			
			if(structs.GetGoodRecordName() != null) {
				
				oprot.WriteFieldBegin("goodRecordName");
				oprot.WriteString(structs.GetGoodRecordName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodName() != null) {
				
				oprot.WriteFieldBegin("goodName");
				oprot.WriteString(structs.GetGoodName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodEnglishName() != null) {
				
				oprot.WriteFieldBegin("goodEnglishName");
				oprot.WriteString(structs.GetGoodEnglishName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIngredients() != null) {
				
				oprot.WriteFieldBegin("ingredients");
				oprot.WriteString(structs.GetIngredients());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCommodityFunction() != null) {
				
				oprot.WriteFieldBegin("commodityFunction");
				oprot.WriteString(structs.GetCommodityFunction());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEffect() != null) {
				
				oprot.WriteFieldBegin("effect");
				oprot.WriteString(structs.GetEffect());
				
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
			
			
			if(structs.GetExpiryDate() != null) {
				
				oprot.WriteFieldBegin("expiryDate");
				oprot.WriteString(structs.GetExpiryDate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCiqCountry() != null) {
				
				oprot.WriteFieldBegin("ciqCountry");
				oprot.WriteString(structs.GetCiqCountry());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCountry() != null) {
				
				oprot.WriteFieldBegin("country");
				oprot.WriteString(structs.GetCountry());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProductionStandard() != null) {
				
				oprot.WriteFieldBegin("productionStandard");
				oprot.WriteString(structs.GetProductionStandard());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCurrency() != null) {
				
				oprot.WriteFieldBegin("currency");
				oprot.WriteString(structs.GetCurrency());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand() != null) {
				
				oprot.WriteFieldBegin("brand");
				oprot.WriteString(structs.GetBrand());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrandType() != null) {
				
				oprot.WriteFieldBegin("brandType");
				oprot.WriteString(structs.GetBrandType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFactory() != null) {
				
				oprot.WriteFieldBegin("factory");
				oprot.WriteString(structs.GetFactory());
				
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
			
			
			if(structs.GetIeflag() != null) {
				
				oprot.WriteFieldBegin("ieflag");
				oprot.WriteString(structs.GetIeflag());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBatchNumber() != null) {
				
				oprot.WriteFieldBegin("batchNumber");
				oprot.WriteString(structs.GetBatchNumber());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRecordType() != null) {
				
				oprot.WriteFieldBegin("recordType");
				oprot.WriteString(structs.GetRecordType());
				
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
			
			
			if(structs.GetBusinessType() != null) {
				
				oprot.WriteFieldBegin("businessType");
				oprot.WriteString(structs.GetBusinessType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnitConvertQuantity() != null) {
				
				oprot.WriteFieldBegin("unitConvertQuantity");
				oprot.WriteI32((int)structs.GetUnitConvertQuantity()); 
				
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
			
			
			if(structs.GetAccordRule() != null) {
				
				oprot.WriteFieldBegin("accordRule");
				oprot.WriteString(structs.GetAccordRule());
				
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
			
			
			if(structs.GetStatementPicture() != null) {
				
				oprot.WriteFieldBegin("statementPicture");
				oprot.WriteString(structs.GetStatementPicture());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCosmeticHazardIdTable() != null) {
				
				oprot.WriteFieldBegin("cosmeticHazardIdTable");
				oprot.WriteString(structs.GetCosmeticHazardIdTable());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetClearanceMode() != null) {
				
				oprot.WriteFieldBegin("clearanceMode");
				oprot.WriteString(structs.GetClearanceMode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCiqUnit() != null) {
				
				oprot.WriteFieldBegin("ciqUnit");
				oprot.WriteString(structs.GetCiqUnit());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VipGoodRecordModel bean){
			
			
		}
		
	}
	
}