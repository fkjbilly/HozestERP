using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.loading.osp.service{
	
	
	
	public class OutRLHandleResultDetailHelper : TBeanSerializer<OutRLHandleResultDetail>
	{
		
		public static OutRLHandleResultDetailHelper OBJ = new OutRLHandleResultDetailHelper();
		
		public static OutRLHandleResultDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutRLHandleResultDetail structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("handleResultCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetHandleResultCode(value);
					}
					
					
					
					
					
					if ("handleResultMsg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetHandleResultMsg(value);
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
		
		
		public void Write(OutRLHandleResultDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orderSn can not be null!");
			}
			
			
			if(structs.GetHandleResultCode() != null) {
				
				oprot.WriteFieldBegin("handleResultCode");
				oprot.WriteString(structs.GetHandleResultCode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("handleResultCode can not be null!");
			}
			
			
			if(structs.GetHandleResultMsg() != null) {
				
				oprot.WriteFieldBegin("handleResultMsg");
				oprot.WriteString(structs.GetHandleResultMsg());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("handleResultMsg can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutRLHandleResultDetail bean){
			
			
		}
		
	}
	
}