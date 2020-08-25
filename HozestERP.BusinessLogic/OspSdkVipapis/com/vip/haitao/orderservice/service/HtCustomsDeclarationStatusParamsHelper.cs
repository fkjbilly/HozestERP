using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtCustomsDeclarationStatusParamsHelper : TBeanSerializer<HtCustomsDeclarationStatusParams>
	{
		
		public static HtCustomsDeclarationStatusParamsHelper OBJ = new HtCustomsDeclarationStatusParamsHelper();
		
		public static HtCustomsDeclarationStatusParamsHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtCustomsDeclarationStatusParams structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("customsCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomsCode(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("body".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody> value;
						
						value = new List<com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody elem0;
								
								elem0 = new com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody();
								com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBodyHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetBody(value);
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
		
		
		public void Write(HtCustomsDeclarationStatusParams structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCustomsCode() != null) {
				
				oprot.WriteFieldBegin("customsCode");
				oprot.WriteString(structs.GetCustomsCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteString(structs.GetUserId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBody() != null) {
				
				oprot.WriteFieldBegin("body");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBody _item0 in structs.GetBody()){
					
					
					com.vip.haitao.orderservice.service.HtCustomsDeclarationContentBodyHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtCustomsDeclarationStatusParams bean){
			
			
		}
		
	}
	
}