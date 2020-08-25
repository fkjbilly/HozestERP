using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.base.osp.service.record{
	
	
	
	public class GoodResultAfterRecordHelper : TBeanSerializer<GoodResultAfterRecord>
	{
		
		public static GoodResultAfterRecordHelper OBJ = new GoodResultAfterRecordHelper();
		
		public static GoodResultAfterRecordHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GoodResultAfterRecord structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("carrierCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrierCode(value);
					}
					
					
					
					
					
					if ("customsCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomsCode(value);
					}
					
					
					
					
					
					if ("recordType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRecordType(value);
					}
					
					
					
					
					
					if ("goodSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodSn(value);
					}
					
					
					
					
					
					if ("recordNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRecordNo(value);
					}
					
					
					
					
					
					if ("resultType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetResultType(value);
					}
					
					
					
					
					
					if ("statusTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetStatusTime(value);
					}
					
					
					
					
					
					if ("cusRecordNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCusRecordNo(value);
					}
					
					
					
					
					
					if ("ciqRecordNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCiqRecordNo(value);
					}
					
					
					
					
					
					if ("parcelTaxNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetParcelTaxNo(value);
					}
					
					
					
					
					
					if ("goodHsCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodHsCode(value);
					}
					
					
					
					
					
					if ("element".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetElement(value);
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
					
					
					
					
					
					if ("statusNote".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStatusNote(value);
					}
					
					
					
					
					
					if ("tjEffect".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTjEffect(value);
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
		
		
		public void Write(GoodResultAfterRecord structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCarrierCode() != null) {
				
				oprot.WriteFieldBegin("carrierCode");
				oprot.WriteString(structs.GetCarrierCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustomsCode() != null) {
				
				oprot.WriteFieldBegin("customsCode");
				oprot.WriteString(structs.GetCustomsCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRecordType() != null) {
				
				oprot.WriteFieldBegin("recordType");
				oprot.WriteString(structs.GetRecordType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodSn() != null) {
				
				oprot.WriteFieldBegin("goodSn");
				oprot.WriteString(structs.GetGoodSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRecordNo() != null) {
				
				oprot.WriteFieldBegin("recordNo");
				oprot.WriteString(structs.GetRecordNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetResultType() != null) {
				
				oprot.WriteFieldBegin("resultType");
				oprot.WriteI32((int)structs.GetResultType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatusTime() != null) {
				
				oprot.WriteFieldBegin("statusTime");
				oprot.WriteI64((long)structs.GetStatusTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCusRecordNo() != null) {
				
				oprot.WriteFieldBegin("cusRecordNo");
				oprot.WriteString(structs.GetCusRecordNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCiqRecordNo() != null) {
				
				oprot.WriteFieldBegin("ciqRecordNo");
				oprot.WriteString(structs.GetCiqRecordNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetParcelTaxNo() != null) {
				
				oprot.WriteFieldBegin("parcelTaxNo");
				oprot.WriteString(structs.GetParcelTaxNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodHsCode() != null) {
				
				oprot.WriteFieldBegin("goodHsCode");
				oprot.WriteString(structs.GetGoodHsCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetElement() != null) {
				
				oprot.WriteFieldBegin("element");
				oprot.WriteString(structs.GetElement());
				
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
			
			
			if(structs.GetStatusNote() != null) {
				
				oprot.WriteFieldBegin("statusNote");
				oprot.WriteString(structs.GetStatusNote());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTjEffect() != null) {
				
				oprot.WriteFieldBegin("tjEffect");
				oprot.WriteString(structs.GetTjEffect());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GoodResultAfterRecord bean){
			
			
		}
		
	}
	
}