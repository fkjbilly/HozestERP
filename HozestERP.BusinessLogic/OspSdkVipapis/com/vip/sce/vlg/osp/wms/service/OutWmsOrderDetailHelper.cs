using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutWmsOrderDetailHelper : TBeanSerializer<OutWmsOrderDetail>
	{
		
		public static OutWmsOrderDetailHelper OBJ = new OutWmsOrderDetailHelper();
		
		public static OutWmsOrderDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutWmsOrderDetail structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("po".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo(value);
					}
					
					
					
					
					
					if ("sizeSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSizeSn(value);
					}
					
					
					
					
					
					if ("goodName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodName(value);
					}
					
					
					
					
					
					if ("goodRecordName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodRecordName(value);
					}
					
					
					
					
					
					if ("goodSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodSn(value);
					}
					
					
					
					
					
					if ("standardType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStandardType(value);
					}
					
					
					
					
					
					if ("brandId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrandId(value);
					}
					
					
					
					
					
					if ("goodRecordNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodRecordNo(value);
					}
					
					
					
					
					
					if ("price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetPrice(value);
					}
					
					
					
					
					
					if ("priceTaxfree".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetPriceTaxfree(value);
					}
					
					
					
					
					
					if ("printPrice".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetPrintPrice(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("unit".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUnit(value);
					}
					
					
					
					
					
					if ("parcelTaxNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetParcelTaxNo(value);
					}
					
					
					
					
					
					if ("brand".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand(value);
					}
					
					
					
					
					
					if ("country".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCountry(value);
					}
					
					
					
					
					
					if ("netWeight".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetNetWeight(value);
					}
					
					
					
					
					
					if ("grossWeight".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetGrossWeight(value);
					}
					
					
					
					
					
					if ("hsCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetHsCode(value);
					}
					
					
					
					
					
					if ("vendorCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorCode(value);
					}
					
					
					
					
					
					if ("noPo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetNoPo(value);
					}
					
					
					
					
					
					if ("userDef1".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDef1(value);
					}
					
					
					
					
					
					if ("userDef2".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDef2(value);
					}
					
					
					
					
					
					if ("userDef3".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDef3(value);
					}
					
					
					
					
					
					if ("userDef4".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDef4(value);
					}
					
					
					
					
					
					if ("userDef5".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserDef5(value);
					}
					
					
					
					
					
					if ("userDef6".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserDef6(value);
					}
					
					
					
					
					
					if ("userDef7".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDef7(value);
					}
					
					
					
					
					
					if ("userDef8".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDef8(value);
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
		
		
		public void Write(OutWmsOrderDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPo() != null) {
				
				oprot.WriteFieldBegin("po");
				oprot.WriteString(structs.GetPo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po can not be null!");
			}
			
			
			if(structs.GetSizeSn() != null) {
				
				oprot.WriteFieldBegin("sizeSn");
				oprot.WriteString(structs.GetSizeSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sizeSn can not be null!");
			}
			
			
			if(structs.GetGoodName() != null) {
				
				oprot.WriteFieldBegin("goodName");
				oprot.WriteString(structs.GetGoodName());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("goodName can not be null!");
			}
			
			
			if(structs.GetGoodRecordName() != null) {
				
				oprot.WriteFieldBegin("goodRecordName");
				oprot.WriteString(structs.GetGoodRecordName());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("goodRecordName can not be null!");
			}
			
			
			if(structs.GetGoodSn() != null) {
				
				oprot.WriteFieldBegin("goodSn");
				oprot.WriteString(structs.GetGoodSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStandardType() != null) {
				
				oprot.WriteFieldBegin("standardType");
				oprot.WriteString(structs.GetStandardType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrandId() != null) {
				
				oprot.WriteFieldBegin("brandId");
				oprot.WriteString(structs.GetBrandId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("brandId can not be null!");
			}
			
			
			if(structs.GetGoodRecordNo() != null) {
				
				oprot.WriteFieldBegin("goodRecordNo");
				oprot.WriteString(structs.GetGoodRecordNo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("goodRecordNo can not be null!");
			}
			
			
			if(structs.GetPrice() != null) {
				
				oprot.WriteFieldBegin("price");
				oprot.WriteDouble((double)structs.GetPrice());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("price can not be null!");
			}
			
			
			if(structs.GetPriceTaxfree() != null) {
				
				oprot.WriteFieldBegin("priceTaxfree");
				oprot.WriteDouble((double)structs.GetPriceTaxfree());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("priceTaxfree can not be null!");
			}
			
			
			if(structs.GetPrintPrice() != null) {
				
				oprot.WriteFieldBegin("printPrice");
				oprot.WriteDouble((double)structs.GetPrintPrice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteI32((int)structs.GetAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("amount can not be null!");
			}
			
			
			if(structs.GetUnit() != null) {
				
				oprot.WriteFieldBegin("unit");
				oprot.WriteString(structs.GetUnit());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetParcelTaxNo() != null) {
				
				oprot.WriteFieldBegin("parcelTaxNo");
				oprot.WriteString(structs.GetParcelTaxNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand() != null) {
				
				oprot.WriteFieldBegin("brand");
				oprot.WriteString(structs.GetBrand());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCountry() != null) {
				
				oprot.WriteFieldBegin("country");
				oprot.WriteString(structs.GetCountry());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNetWeight() != null) {
				
				oprot.WriteFieldBegin("netWeight");
				oprot.WriteDouble((double)structs.GetNetWeight());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGrossWeight() != null) {
				
				oprot.WriteFieldBegin("grossWeight");
				oprot.WriteDouble((double)structs.GetGrossWeight());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHsCode() != null) {
				
				oprot.WriteFieldBegin("hsCode");
				oprot.WriteString(structs.GetHsCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorCode() != null) {
				
				oprot.WriteFieldBegin("vendorCode");
				oprot.WriteString(structs.GetVendorCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNoPo() != null) {
				
				oprot.WriteFieldBegin("noPo");
				oprot.WriteString(structs.GetNoPo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef1() != null) {
				
				oprot.WriteFieldBegin("userDef1");
				oprot.WriteString(structs.GetUserDef1());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef2() != null) {
				
				oprot.WriteFieldBegin("userDef2");
				oprot.WriteString(structs.GetUserDef2());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef3() != null) {
				
				oprot.WriteFieldBegin("userDef3");
				oprot.WriteString(structs.GetUserDef3());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef4() != null) {
				
				oprot.WriteFieldBegin("userDef4");
				oprot.WriteString(structs.GetUserDef4());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef5() != null) {
				
				oprot.WriteFieldBegin("userDef5");
				oprot.WriteI64((long)structs.GetUserDef5()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef6() != null) {
				
				oprot.WriteFieldBegin("userDef6");
				oprot.WriteI64((long)structs.GetUserDef6()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef7() != null) {
				
				oprot.WriteFieldBegin("userDef7");
				oprot.WriteString(structs.GetUserDef7());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDef8() != null) {
				
				oprot.WriteFieldBegin("userDef8");
				oprot.WriteString(structs.GetUserDef8());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutWmsOrderDetail bean){
			
			
		}
		
	}
	
}