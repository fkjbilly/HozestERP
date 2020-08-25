using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.merchModel.service{
	
	
	
	public class Jd3dModelSyncResponseHelper : TBeanSerializer<Jd3dModelSyncResponse>
	{
		
		public static Jd3dModelSyncResponseHelper OBJ = new Jd3dModelSyncResponseHelper();
		
		public static Jd3dModelSyncResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Jd3dModelSyncResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("retCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetRetCode(value);
					}
					
					
					
					
					
					if ("errMsg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErrMsg(value);
					}
					
					
					
					
					
					if ("mids".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetMids(value);
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
		
		
		public void Write(Jd3dModelSyncResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetRetCode() != null) {
				
				oprot.WriteFieldBegin("retCode");
				oprot.WriteI32((int)structs.GetRetCode()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("retCode can not be null!");
			}
			
			
			if(structs.GetErrMsg() != null) {
				
				oprot.WriteFieldBegin("errMsg");
				oprot.WriteString(structs.GetErrMsg());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("errMsg can not be null!");
			}
			
			
			if(structs.GetMids() != null) {
				
				oprot.WriteFieldBegin("mids");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetMids()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("mids can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Jd3dModelSyncResponse bean){
			
			
		}
		
	}
	
}