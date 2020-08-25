using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtCustomsDeclarationResponseMessageHelper : TBeanSerializer<HtCustomsDeclarationResponseMessage>
	{
		
		public static HtCustomsDeclarationResponseMessageHelper OBJ = new HtCustomsDeclarationResponseMessageHelper();
		
		public static HtCustomsDeclarationResponseMessageHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtCustomsDeclarationResponseMessage structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("head".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.haitao.orderservice.service.Head value;
						
						value = new com.vip.haitao.orderservice.service.Head();
						com.vip.haitao.orderservice.service.HeadHelper.getInstance().Read(value, iprot);
						
						structs.SetHead(value);
					}
					
					
					
					
					
					if ("body".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessageBody> value;
						
						value = new List<com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessageBody>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessageBody elem1;
								
								elem1 = new com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessageBody();
								com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessageBodyHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
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
		
		
		public void Write(HtCustomsDeclarationResponseMessage structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHead() != null) {
				
				oprot.WriteFieldBegin("head");
				
				com.vip.haitao.orderservice.service.HeadHelper.getInstance().Write(structs.GetHead(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("head can not be null!");
			}
			
			
			if(structs.GetBody() != null) {
				
				oprot.WriteFieldBegin("body");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessageBody _item0 in structs.GetBody()){
					
					
					com.vip.haitao.orderservice.service.HtCustomsDeclarationResponseMessageBodyHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("body can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtCustomsDeclarationResponseMessage bean){
			
			
		}
		
	}
	
}