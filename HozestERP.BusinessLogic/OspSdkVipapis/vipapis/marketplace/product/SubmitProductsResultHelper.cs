using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class SubmitProductsResultHelper : TBeanSerializer<SubmitProductsResult>
	{
		
		public static SubmitProductsResultHelper OBJ = new SubmitProductsResultHelper();
		
		public static SubmitProductsResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SubmitProductsResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("spu_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSpu_id(value);
					}
					
					
					
					
					
					if ("success".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetSuccess(value);
					}
					
					
					
					
					
					if ("error_msg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetError_msg(value);
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
		
		
		public void Write(SubmitProductsResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSpu_id() != null) {
				
				oprot.WriteFieldBegin("spu_id");
				oprot.WriteString(structs.GetSpu_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("spu_id can not be null!");
			}
			
			
			if(structs.GetSuccess() != null) {
				
				oprot.WriteFieldBegin("success");
				oprot.WriteBool((bool)structs.GetSuccess());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("success can not be null!");
			}
			
			
			if(structs.GetError_msg() != null) {
				
				oprot.WriteFieldBegin("error_msg");
				oprot.WriteString(structs.GetError_msg());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SubmitProductsResult bean){
			
			
		}
		
	}
	
}