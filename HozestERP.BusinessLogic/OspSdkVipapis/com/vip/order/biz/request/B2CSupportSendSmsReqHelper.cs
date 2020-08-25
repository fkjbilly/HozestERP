using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class B2CSupportSendSmsReqHelper : TBeanSerializer<B2CSupportSendSmsReq>
	{
		
		public static B2CSupportSendSmsReqHelper OBJ = new B2CSupportSendSmsReqHelper();
		
		public static B2CSupportSendSmsReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(B2CSupportSendSmsReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("mobiles".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadSetBegin();
						while(true){
							
							try{
								
								string elem1;
								elem1 = iprot.ReadString();
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadSetEnd();
						
						structs.SetMobiles(value);
					}
					
					
					
					
					
					if ("content".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetContent(value);
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
		
		
		public void Write(B2CSupportSendSmsReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetMobiles() != null) {
				
				oprot.WriteFieldBegin("mobiles");
				
				oprot.WriteSetBegin();
				foreach(string _item0 in structs.GetMobiles()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetContent() != null) {
				
				oprot.WriteFieldBegin("content");
				oprot.WriteString(structs.GetContent());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(B2CSupportSendSmsReq bean){
			
			
		}
		
	}
	
}