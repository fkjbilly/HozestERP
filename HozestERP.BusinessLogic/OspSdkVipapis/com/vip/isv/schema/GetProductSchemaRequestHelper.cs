using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.schema{
	
	
	
	public class GetProductSchemaRequestHelper : TBeanSerializer<GetProductSchemaRequest>
	{
		
		public static GetProductSchemaRequestHelper OBJ = new GetProductSchemaRequestHelper();
		
		public static GetProductSchemaRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetProductSchemaRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetCategory_id(value);
					}
					
					
					
					
					
					if ("schema_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSchema_type(value);
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
		
		
		public void Write(GetProductSchemaRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetCategory_id() != null) {
				
				oprot.WriteFieldBegin("category_id");
				oprot.WriteI32((int)structs.GetCategory_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("category_id can not be null!");
			}
			
			
			if(structs.GetSchema_type() != null) {
				
				oprot.WriteFieldBegin("schema_type");
				oprot.WriteString(structs.GetSchema_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("schema_type can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetProductSchemaRequest bean){
			
			
		}
		
	}
	
}