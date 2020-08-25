using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.fcs.vei.service{
	
	
	
	public class CanInvoicingResModel2Helper : TBeanSerializer<CanInvoicingResModel2>
	{
		
		public static CanInvoicingResModel2Helper OBJ = new CanInvoicingResModel2Helper();
		
		public static CanInvoicingResModel2Helper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CanInvoicingResModel2 structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("canEinvoicePrint".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetCanEinvoicePrint(value);
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
		
		
		public void Write(CanInvoicingResModel2 structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCanEinvoice() != null) {
				
				oprot.WriteFieldBegin("canEinvoice");
				oprot.WriteBool((bool)structs.GetCanEinvoice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCanEinvoicePrint() != null) {
				
				oprot.WriteFieldBegin("canEinvoicePrint");
				oprot.WriteBool((bool)structs.GetCanEinvoicePrint());
				
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
		
		
		public void Validate(CanInvoicingResModel2 bean){
			
			
		}
		
	}
	
}