using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtSaleOrderInfoChbModelHelper : TBeanSerializer<HtSaleOrderInfoChbModel>
	{
		
		public static HtSaleOrderInfoChbModelHelper OBJ = new HtSaleOrderInfoChbModelHelper();
		
		public static HtSaleOrderInfoChbModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtSaleOrderInfoChbModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetId(value);
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
					
					
					
					
					
					if ("vendorCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorCode(value);
					}
					
					
					
					
					
					if ("noPo".Equals(schemeField.Trim())){
						
						needSkip = false;
						short? value;
						value = iprot.ReadI16(); 
						
						structs.SetNoPo(value);
					}
					
					
					
					
					
					if ("hscode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetHscode(value);
					}
					
					
					
					
					
					if ("ciqGoodNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCiqGoodNo(value);
					}
					
					
					
					
					
					if ("qty1".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetQty1(value);
					}
					
					
					
					
					
					if ("qty2".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetQty2(value);
					}
					
					
					
					
					
					if ("unit1".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUnit1(value);
					}
					
					
					
					
					
					if ("unit2".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUnit2(value);
					}
					
					
					
					
					
					if ("userDefined1".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDefined1(value);
					}
					
					
					
					
					
					if ("userDefined2".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDefined2(value);
					}
					
					
					
					
					
					if ("userDefined3".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDefined3(value);
					}
					
					
					
					
					
					if ("userDefined4".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDefined4(value);
					}
					
					
					
					
					
					if ("userDefined5".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserDefined5(value);
					}
					
					
					
					
					
					if ("userDefined6".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserDefined6(value);
					}
					
					
					
					
					
					if ("userDefined7".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDefined7(value);
					}
					
					
					
					
					
					if ("userDefined8".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserDefined8(value);
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
		
		
		public void Write(HtSaleOrderInfoChbModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteString(structs.GetId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizeSn() != null) {
				
				oprot.WriteFieldBegin("sizeSn");
				oprot.WriteString(structs.GetSizeSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodName() != null) {
				
				oprot.WriteFieldBegin("goodName");
				oprot.WriteString(structs.GetGoodName());
				
				oprot.WriteFieldEnd();
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
			
			
			if(structs.GetVendorCode() != null) {
				
				oprot.WriteFieldBegin("vendorCode");
				oprot.WriteString(structs.GetVendorCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNoPo() != null) {
				
				oprot.WriteFieldBegin("noPo");
				oprot.WriteI16((short)structs.GetNoPo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHscode() != null) {
				
				oprot.WriteFieldBegin("hscode");
				oprot.WriteString(structs.GetHscode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCiqGoodNo() != null) {
				
				oprot.WriteFieldBegin("ciqGoodNo");
				oprot.WriteString(structs.GetCiqGoodNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetQty1() != null) {
				
				oprot.WriteFieldBegin("qty1");
				oprot.WriteDouble((double)structs.GetQty1());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetQty2() != null) {
				
				oprot.WriteFieldBegin("qty2");
				oprot.WriteDouble((double)structs.GetQty2());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnit1() != null) {
				
				oprot.WriteFieldBegin("unit1");
				oprot.WriteString(structs.GetUnit1());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnit2() != null) {
				
				oprot.WriteFieldBegin("unit2");
				oprot.WriteString(structs.GetUnit2());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDefined1() != null) {
				
				oprot.WriteFieldBegin("userDefined1");
				oprot.WriteString(structs.GetUserDefined1());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDefined2() != null) {
				
				oprot.WriteFieldBegin("userDefined2");
				oprot.WriteString(structs.GetUserDefined2());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDefined3() != null) {
				
				oprot.WriteFieldBegin("userDefined3");
				oprot.WriteString(structs.GetUserDefined3());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDefined4() != null) {
				
				oprot.WriteFieldBegin("userDefined4");
				oprot.WriteString(structs.GetUserDefined4());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDefined5() != null) {
				
				oprot.WriteFieldBegin("userDefined5");
				oprot.WriteI64((long)structs.GetUserDefined5()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDefined6() != null) {
				
				oprot.WriteFieldBegin("userDefined6");
				oprot.WriteI64((long)structs.GetUserDefined6()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDefined7() != null) {
				
				oprot.WriteFieldBegin("userDefined7");
				oprot.WriteString(structs.GetUserDefined7());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserDefined8() != null) {
				
				oprot.WriteFieldBegin("userDefined8");
				oprot.WriteString(structs.GetUserDefined8());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtSaleOrderInfoChbModel bean){
			
			
		}
		
	}
	
}