using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.fcs.vei.service{
	
	
	
	public class VCanInvoicingResModelHelper : TBeanSerializer<VCanInvoicingResModel>
	{
		
		public static VCanInvoicingResModelHelper OBJ = new VCanInvoicingResModelHelper();
		
		public static VCanInvoicingResModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VCanInvoicingResModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("canEinvoice".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetCanEinvoice(value);
					}
					
					
					
					
					
					if ("restulMesg".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.fcs.vei.service.BaseRetMsg value;
						
						value = new com.vip.fcs.vei.service.BaseRetMsg();
						com.vip.fcs.vei.service.BaseRetMsgHelper.getInstance().Read(value, iprot);
						
						structs.SetRestulMesg(value);
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
		
		
		public void Write(VCanInvoicingResModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCanEinvoice() != null) {
				
				oprot.WriteFieldBegin("canEinvoice");
				oprot.WriteBool((bool)structs.GetCanEinvoice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRestulMesg() != null) {
				
				oprot.WriteFieldBegin("restulMesg");
				
				com.vip.fcs.vei.service.BaseRetMsgHelper.getInstance().Write(structs.GetRestulMesg(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VCanInvoicingResModel bean){
			
			
		}
		
	}
	
}