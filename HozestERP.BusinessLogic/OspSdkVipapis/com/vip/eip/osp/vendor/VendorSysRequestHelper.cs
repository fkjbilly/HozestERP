using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.eip.osp.vendor{
	
	
	
	public class VendorSysRequestHelper : TBeanSerializer<VendorSysRequest>
	{
		
		public static VendorSysRequestHelper OBJ = new VendorSysRequestHelper();
		
		public static VendorSysRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VendorSysRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("msg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMsg(value);
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
		
		
		public void Write(VendorSysRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetMsg() != null) {
				
				oprot.WriteFieldBegin("msg");
				oprot.WriteString(structs.GetMsg());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("msg can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VendorSysRequest bean){
			
			
		}
		
	}
	
}