using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.fcs.vei.service{
	
	
	
	public class ExternalInvoiceHandleStateResModelHelper : TBeanSerializer<ExternalInvoiceHandleStateResModel>
	{
		
		public static ExternalInvoiceHandleStateResModelHelper OBJ = new ExternalInvoiceHandleStateResModelHelper();
		
		public static ExternalInvoiceHandleStateResModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ExternalInvoiceHandleStateResModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("externalInvoiceHandleStateList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.fcs.vei.service.ExternalInvoiceHandleState> value;
						
						value = new List<com.vip.fcs.vei.service.ExternalInvoiceHandleState>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.fcs.vei.service.ExternalInvoiceHandleState elem0;
								
								elem0 = new com.vip.fcs.vei.service.ExternalInvoiceHandleState();
								com.vip.fcs.vei.service.ExternalInvoiceHandleStateHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetExternalInvoiceHandleStateList(value);
					}
					
					
					
					
					
					if ("retMsg".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.fcs.vei.service.BaseRetMsg value;
						
						value = new com.vip.fcs.vei.service.BaseRetMsg();
						com.vip.fcs.vei.service.BaseRetMsgHelper.getInstance().Read(value, iprot);
						
						structs.SetRetMsg(value);
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
		
		
		public void Write(ExternalInvoiceHandleStateResModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetExternalInvoiceHandleStateList() != null) {
				
				oprot.WriteFieldBegin("externalInvoiceHandleStateList");
				
				oprot.WriteListBegin();
				foreach(com.vip.fcs.vei.service.ExternalInvoiceHandleState _item0 in structs.GetExternalInvoiceHandleStateList()){
					
					
					com.vip.fcs.vei.service.ExternalInvoiceHandleStateHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRetMsg() != null) {
				
				oprot.WriteFieldBegin("retMsg");
				
				com.vip.fcs.vei.service.BaseRetMsgHelper.getInstance().Write(structs.GetRetMsg(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ExternalInvoiceHandleStateResModel bean){
			
			
		}
		
	}
	
}