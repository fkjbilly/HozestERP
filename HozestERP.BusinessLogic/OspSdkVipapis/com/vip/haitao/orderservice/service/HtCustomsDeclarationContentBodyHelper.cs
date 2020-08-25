using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtCustomsDeclarationContentBodyHelper : TBeanSerializer<HtCustomsDeclarationContentBody>
	{
		
		public static HtCustomsDeclarationContentBodyHelper OBJ = new HtCustomsDeclarationContentBodyHelper();
		
		public static HtCustomsDeclarationContentBodyHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtCustomsDeclarationContentBody structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("resultInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetResultInfo(value);
					}
					
					
					
					
					
					if ("transportNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportNo(value);
					}
					
					
					
					
					
					if ("transportName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportName(value);
					}
					
					
					
					
					
					if ("transportCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportCode(value);
					}
					
					
					
					
					
					if ("iventoryNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIventoryNo(value);
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
		
		
		public void Write(HtCustomsDeclarationContentBody structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orderSn can not be null!");
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteI32((int)structs.GetStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("status can not be null!");
			}
			
			
			if(structs.GetResultInfo() != null) {
				
				oprot.WriteFieldBegin("resultInfo");
				oprot.WriteString(structs.GetResultInfo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("resultInfo can not be null!");
			}
			
			
			if(structs.GetTransportNo() != null) {
				
				oprot.WriteFieldBegin("transportNo");
				oprot.WriteString(structs.GetTransportNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportName() != null) {
				
				oprot.WriteFieldBegin("transportName");
				oprot.WriteString(structs.GetTransportName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportCode() != null) {
				
				oprot.WriteFieldBegin("transportCode");
				oprot.WriteString(structs.GetTransportCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIventoryNo() != null) {
				
				oprot.WriteFieldBegin("iventoryNo");
				oprot.WriteString(structs.GetIventoryNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtCustomsDeclarationContentBody bean){
			
			
		}
		
	}
	
}