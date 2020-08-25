using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class EditProductResponseHelper : TBeanSerializer<EditProductResponse>
	{
		
		public static EditProductResponseHelper OBJ = new EditProductResponseHelper();
		
		public static EditProductResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(EditProductResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("success".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetSuccess(value);
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
		
		
		public void Write(EditProductResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSuccess() != null) {
				
				oprot.WriteFieldBegin("success");
				oprot.WriteBool((bool)structs.GetSuccess());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("success can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(EditProductResponse bean){
			
			
		}
		
	}
	
}