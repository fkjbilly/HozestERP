using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vipshop.cis.sdk.api.datain.si.request{
	
	
	
	public class SyncVrwIncrInvRequestPayloadHelper : TBeanSerializer<SyncVrwIncrInvRequestPayload>
	{
		
		public static SyncVrwIncrInvRequestPayloadHelper OBJ = new SyncVrwIncrInvRequestPayloadHelper();
		
		public static SyncVrwIncrInvRequestPayloadHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SyncVrwIncrInvRequestPayload structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("data_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayloadItem> value;
						
						value = new List<com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayloadItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayloadItem elem1;
								
								elem1 = new com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayloadItem();
								com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayloadItemHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
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
		
		
		public void Write(SyncVrwIncrInvRequestPayload structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetData_list() != null) {
				
				oprot.WriteFieldBegin("data_list");
				
				oprot.WriteListBegin();
				foreach(com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayloadItem _item0 in structs.GetData_list()){
					
					
					com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayloadItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("data_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SyncVrwIncrInvRequestPayload bean){
			
			
		}
		
	}
	
}