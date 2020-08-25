using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtCustomsDeclarationResponseMessageBodyHelper : TBeanSerializer<HtCustomsDeclarationResponseMessageBody>
	{
		
		public static HtCustomsDeclarationResponseMessageBodyHelper OBJ = new HtCustomsDeclarationResponseMessageBodyHelper();
		
		public static HtCustomsDeclarationResponseMessageBodyHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtCustomsDeclarationResponseMessageBody structs, Protocol iprot){
			
			
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
						string value;
						value = iprot.ReadString();
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("bizResponseCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBizResponseCode(value);
					}
					
					
					
					
					
					if ("bizResponseMsg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBizResponseMsg(value);
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
		
		
		public void Write(HtCustomsDeclarationResponseMessageBody structs, Protocol oprot){
			
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
				oprot.WriteString(structs.GetStatus());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("status can not be null!");
			}
			
			
			if(structs.GetBizResponseCode() != null) {
				
				oprot.WriteFieldBegin("bizResponseCode");
				oprot.WriteString(structs.GetBizResponseCode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("bizResponseCode can not be null!");
			}
			
			
			if(structs.GetBizResponseMsg() != null) {
				
				oprot.WriteFieldBegin("bizResponseMsg");
				oprot.WriteString(structs.GetBizResponseMsg());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("bizResponseMsg can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtCustomsDeclarationResponseMessageBody bean){
			
			
		}
		
	}
	
}