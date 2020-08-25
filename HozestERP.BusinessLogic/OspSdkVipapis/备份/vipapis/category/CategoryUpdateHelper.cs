using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.category{
	
	
	
	public class CategoryUpdateHelper : BeanSerializer<CategoryUpdate>
	{
		
		public static CategoryUpdateHelper OBJ = new CategoryUpdateHelper();
		
		public static CategoryUpdateHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CategoryUpdate structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("updateType".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.category.UpdateType? value;
						
						value = vipapis.category.UpdateTypeUtil.FindByName(iprot.ReadString());
						
						structs.SetUpdateType(value);
					}
					
					
					
					
					
					if ("category".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.category.Category value;
						
						value = new vipapis.category.Category();
						vipapis.category.CategoryHelper.getInstance().Read(value, iprot);
						
						structs.SetCategory(value);
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
		
		
		public void Write(CategoryUpdate structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUpdateType() != null) {
				
				oprot.WriteFieldBegin("updateType");
				oprot.WriteString(structs.GetUpdateType().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("updateType can not be null!");
			}
			
			
			if(structs.GetCategory() != null) {
				
				oprot.WriteFieldBegin("category");
				
				vipapis.category.CategoryHelper.getInstance().Write(structs.GetCategory(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("category can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CategoryUpdate bean){
			
			
		}
		
	}
	
}