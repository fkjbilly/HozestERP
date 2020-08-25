using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.fcs.vei.service{
	
	
	
	public class EinvoiceVoHelper : TBeanSerializer<EinvoiceVo>
	{
		
		public static EinvoiceVoHelper OBJ = new EinvoiceVoHelper();
		
		public static EinvoiceVoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(EinvoiceVo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("fpdm".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFpdm(value);
					}
					
					
					
					
					
					if ("fphm".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFphm(value);
					}
					
					
					
					
					
					if ("pdfUrl".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPdfUrl(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("taxRegisterNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTaxRegisterNo(value);
					}
					
					
					
					
					
					if ("dataType".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte value;
						value = iprot.ReadByte(); 
						
						structs.SetDataType(value);
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
		
		
		public void Write(EinvoiceVo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetFpdm() != null) {
				
				oprot.WriteFieldBegin("fpdm");
				oprot.WriteString(structs.GetFpdm());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFphm() != null) {
				
				oprot.WriteFieldBegin("fphm");
				oprot.WriteString(structs.GetFphm());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPdfUrl() != null) {
				
				oprot.WriteFieldBegin("pdfUrl");
				oprot.WriteString(structs.GetPdfUrl());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orderSn can not be null!");
			}
			
			
			if(structs.GetTaxRegisterNo() != null) {
				
				oprot.WriteFieldBegin("taxRegisterNo");
				oprot.WriteString(structs.GetTaxRegisterNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDataType() != null) {
				
				oprot.WriteFieldBegin("dataType");
				oprot.WriteByte((byte)structs.GetDataType()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("dataType can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(EinvoiceVo bean){
			
			
		}
		
	}
	
}