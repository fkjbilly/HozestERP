using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vipshop.cis.sdk.api.datain.si.response{
	
	
	
	public class SyncVrwIncrInvResponsePayloadHelper : TBeanSerializer<SyncVrwIncrInvResponsePayload>
	{
		
		public static SyncVrwIncrInvResponsePayloadHelper OBJ = new SyncVrwIncrInvResponsePayloadHelper();
		
		public static SyncVrwIncrInvResponsePayloadHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SyncVrwIncrInvResponsePayload structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("data_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayloadItem> value;
						
						value = new List<com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayloadItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayloadItem elem0;
								
								elem0 = new com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayloadItem();
								com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayloadItemHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetData_list(value);
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
		
		
		public void Write(SyncVrwIncrInvResponsePayload structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetData_list() != null) {
				
				oprot.WriteFieldBegin("data_list");
				
				oprot.WriteListBegin();
				foreach(com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayloadItem _item0 in structs.GetData_list()){
					
					
					com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayloadItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SyncVrwIncrInvResponsePayload bean){
			
			
		}
		
	}
	
}