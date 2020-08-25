using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vipcard{
	
	
	
	public class CancelCardResponseHelper : TBeanSerializer<CancelCardResponse>
	{
		
		public static CancelCardResponseHelper OBJ = new CancelCardResponseHelper();
		
		public static CancelCardResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CancelCardResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("success_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetSuccess_num(value);
					}
					
					
					
					
					
					if ("fail_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetFail_num(value);
					}
					
					
					
					
					
					if ("fail_message".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.vipcard.CancelCardFailMessage> value;
						
						value = new List<vipapis.vipcard.CancelCardFailMessage>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.vipcard.CancelCardFailMessage elem0;
								
								elem0 = new vipapis.vipcard.CancelCardFailMessage();
								vipapis.vipcard.CancelCardFailMessageHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFail_message(value);
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
		
		
		public void Write(CancelCardResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSuccess_num() != null) {
				
				oprot.WriteFieldBegin("success_num");
				oprot.WriteI32((int)structs.GetSuccess_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("success_num can not be null!");
			}
			
			
			if(structs.GetFail_num() != null) {
				
				oprot.WriteFieldBegin("fail_num");
				oprot.WriteI32((int)structs.GetFail_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("fail_num can not be null!");
			}
			
			
			if(structs.GetFail_message() != null) {
				
				oprot.WriteFieldBegin("fail_message");
				
				oprot.WriteListBegin();
				foreach(vipapis.vipcard.CancelCardFailMessage _item0 in structs.GetFail_message()){
					
					
					vipapis.vipcard.CancelCardFailMessageHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CancelCardResponse bean){
			
			
		}
		
	}
	
}