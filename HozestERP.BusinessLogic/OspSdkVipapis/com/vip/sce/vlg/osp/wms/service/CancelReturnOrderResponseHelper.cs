using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class CancelReturnOrderResponseHelper : TBeanSerializer<CancelReturnOrderResponse>
	{
		
		public static CancelReturnOrderResponseHelper OBJ = new CancelReturnOrderResponseHelper();
		
		public static CancelReturnOrderResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CancelReturnOrderResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("return_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturn_sn(value);
					}
					
					
					
					
					
					if ("response_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetResponse_code(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
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
		
		
		public void Write(CancelReturnOrderResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturn_sn() != null) {
				
				oprot.WriteFieldBegin("return_sn");
				oprot.WriteString(structs.GetReturn_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("return_sn can not be null!");
			}
			
			
			if(structs.GetResponse_code() != null) {
				
				oprot.WriteFieldBegin("response_code");
				oprot.WriteString(structs.GetResponse_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("response_code can not be null!");
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("remark can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CancelReturnOrderResponse bean){
			
			
		}
		
	}
	
}