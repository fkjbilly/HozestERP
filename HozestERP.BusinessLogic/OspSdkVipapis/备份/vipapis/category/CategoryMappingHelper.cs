using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.category{
	
	
	
	public class CategoryMappingHelper : BeanSerializer<CategoryMapping>
	{
		
		public static CategoryMappingHelper OBJ = new CategoryMappingHelper();
		
		public static CategoryMappingHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CategoryMapping structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sourcecategory".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.category.Category value;
						
						value = new vipapis.category.Category();
						vipapis.category.CategoryHelper.getInstance().Read(value, iprot);
						
						structs.SetSourcecategory(value);
					}
					
					
					
					
					
					if ("filter".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFilter(value);
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
		
		
		public void Write(CategoryMapping structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSourcecategory() != null) {
				
				oprot.WriteFieldBegin("sourcecategory");
				
				vipapis.category.CategoryHelper.getInstance().Write(structs.GetSourcecategory(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sourcecategory can not be null!");
			}
			
			
			if(structs.GetFilter() != null) {
				
				oprot.WriteFieldBegin("filter");
				oprot.WriteString(structs.GetFilter());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CategoryMapping bean){
			
			
		}
		
	}
	
}