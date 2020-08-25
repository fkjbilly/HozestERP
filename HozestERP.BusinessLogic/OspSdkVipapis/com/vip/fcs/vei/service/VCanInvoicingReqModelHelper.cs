using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.fcs.vei.service{
	
	
	
	public class VCanInvoicingReqModelHelper : TBeanSerializer<VCanInvoicingReqModel>
	{
		
		public static VCanInvoicingReqModelHelper OBJ = new VCanInvoicingReqModelHelper();
		
		public static VCanInvoicingReqModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VCanInvoicingReqModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("merchandiseType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMerchandiseType(value);
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
		
		
		public void Write(VCanInvoicingReqModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetMerchandiseType() != null) {
				
				oprot.WriteFieldBegin("merchandiseType");
				oprot.WriteString(structs.GetMerchandiseType());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VCanInvoicingReqModel bean){
			
			
		}
		
	}
	
}