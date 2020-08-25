using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class GetProductRequestHelper : TBeanSerializer<GetProductRequest>
	{
		
		public static GetProductRequestHelper OBJ = new GetProductRequestHelper();
		
		public static GetProductRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetProductRequest structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("outer_spu_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOuter_spu_id(value);
					}
					
					
					
					
					
					if ("shelf_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetShelf_status(value);
					}
					
					
					
					
					
					if ("audit_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAudit_status(value);
					}
					
					
					
					
					
					if ("limit".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetLimit(value);
					}
					
					
					
					
					
					if ("page".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPage(value);
					}
					
					
					
					
					
					if ("first_category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetFirst_category_id(value);
					}
					
					
					
					
					
					if ("second_category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSecond_category_id(value);
					}
					
					
					
					
					
					if ("third_category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetThird_category_id(value);
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
		
		
		public void Write(GetProductRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSpu_id() != null) {
				
				oprot.WriteFieldBegin("spu_id");
				oprot.WriteString(structs.GetSpu_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOuter_spu_id() != null) {
				
				oprot.WriteFieldBegin("outer_spu_id");
				oprot.WriteString(structs.GetOuter_spu_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetShelf_status() != null) {
				
				oprot.WriteFieldBegin("shelf_status");
				oprot.WriteString(structs.GetShelf_status());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAudit_status() != null) {
				
				oprot.WriteFieldBegin("audit_status");
				oprot.WriteString(structs.GetAudit_status());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLimit() != null) {
				
				oprot.WriteFieldBegin("limit");
				oprot.WriteI32((int)structs.GetLimit()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPage() != null) {
				
				oprot.WriteFieldBegin("page");
				oprot.WriteI32((int)structs.GetPage()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFirst_category_id() != null) {
				
				oprot.WriteFieldBegin("first_category_id");
				oprot.WriteI32((int)structs.GetFirst_category_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSecond_category_id() != null) {
				
				oprot.WriteFieldBegin("second_category_id");
				oprot.WriteI32((int)structs.GetSecond_category_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetThird_category_id() != null) {
				
				oprot.WriteFieldBegin("third_category_id");
				oprot.WriteI32((int)structs.GetThird_category_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetProductRequest bean){
			
			
		}
		
	}
	
}