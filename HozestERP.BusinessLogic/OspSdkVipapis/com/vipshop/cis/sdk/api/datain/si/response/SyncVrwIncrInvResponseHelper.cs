using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vipshop.cis.sdk.api.datain.si.response{
	
	
	
	public class SyncVrwIncrInvResponseHelper : TBeanSerializer<SyncVrwIncrInvResponse>
	{
		
		public static SyncVrwIncrInvResponseHelper OBJ = new SyncVrwIncrInvResponseHelper();
		
		public static SyncVrwIncrInvResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SyncVrwIncrInvResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("header".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vipshop.cis.sdk.api.datain.si.response.ChannelResponseHeader value;
						
						value = new com.vipshop.cis.sdk.api.datain.si.response.ChannelResponseHeader();
						com.vipshop.cis.sdk.api.datain.si.response.ChannelResponseHeaderHelper.getInstance().Read(value, iprot);
						
						structs.SetHeader(value);
					}
					
					
					
					
					
					if ("payload".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayload value;
						
						value = new com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayload();
						com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayloadHelper.getInstance().Read(value, iprot);
						
						structs.SetPayload(value);
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
		
		
		public void Write(SyncVrwIncrInvResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHeader() != null) {
				
				oprot.WriteFieldBegin("header");
				
				com.vipshop.cis.sdk.api.datain.si.response.ChannelResponseHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("header can not be null!");
			}
			
			
			if(structs.GetPayload() != null) {
				
				oprot.WriteFieldBegin("payload");
				
				com.vipshop.cis.sdk.api.datain.si.response.SyncVrwIncrInvResponsePayloadHelper.getInstance().Write(structs.GetPayload(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SyncVrwIncrInvResponse bean){
			
			
		}
		
	}
	
}