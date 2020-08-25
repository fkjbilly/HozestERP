using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vipshop.cis.sdk.api.datain.si.request{
	
	
	
	public class SyncVrwIncrInvRequestHelper : TBeanSerializer<SyncVrwIncrInvRequest>
	{
		
		public static SyncVrwIncrInvRequestHelper OBJ = new SyncVrwIncrInvRequestHelper();
		
		public static SyncVrwIncrInvRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SyncVrwIncrInvRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("header".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vipshop.cis.sdk.api.datain.si.request.ChannelRequestHeader value;
						
						value = new com.vipshop.cis.sdk.api.datain.si.request.ChannelRequestHeader();
						com.vipshop.cis.sdk.api.datain.si.request.ChannelRequestHeaderHelper.getInstance().Read(value, iprot);
						
						structs.SetHeader(value);
					}
					
					
					
					
					
					if ("payload".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayload value;
						
						value = new com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayload();
						com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayloadHelper.getInstance().Read(value, iprot);
						
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
		
		
		public void Write(SyncVrwIncrInvRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHeader() != null) {
				
				oprot.WriteFieldBegin("header");
				
				com.vipshop.cis.sdk.api.datain.si.request.ChannelRequestHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("header can not be null!");
			}
			
			
			if(structs.GetPayload() != null) {
				
				oprot.WriteFieldBegin("payload");
				
				com.vipshop.cis.sdk.api.datain.si.request.SyncVrwIncrInvRequestPayloadHelper.getInstance().Write(structs.GetPayload(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("payload can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SyncVrwIncrInvRequest bean){
			
			
		}
		
	}
	
}