using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.category{
	
	
	
	public class CategoryHelper : TBeanSerializer<Category>
	{
		
		public static CategoryHelper OBJ = new CategoryHelper();
		
		public static CategoryHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Category structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetCategory_id(value);
					}
					
					
					
					
					
					if ("category_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCategory_name(value);
					}
					
					
					
					
					
					if ("foreignname".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetForeignname(value);
					}
					
					
					
					
					
					if ("description".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDescription(value);
					}
					
					
					
					
					
					if ("category_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.category.CategoryType? value;
						
						value = vipapis.category.CategoryTypeUtil.FindByName(iprot.ReadString());
						
						structs.SetCategory_type(value);
					}
					
					
					
					
					
					if ("keywords".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetKeywords(value);
					}
					
					
					
					
					
					if ("flags".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetFlags(value);
					}
					
					
					
					
					
					if ("hierarchy_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetHierarchy_id(value);
					}
					
					
					
					
					
					if ("last_updatetime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetLast_updatetime(value);
					}
					
					
					
					
					
					if ("related_categories".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								int elem0;
								elem0 = iprot.ReadI32(); 
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetRelated_categories(value);
					}
					
					
					
					
					
					if ("children".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.category.Category> value;
						
						value = new List<vipapis.category.Category>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.category.Category elem1;
								
								elem1 = new vipapis.category.Category();
								vipapis.category.CategoryHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetChildren(value);
					}
					
					
					
					
					
					if ("mapping".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.category.CategoryMapping> value;
						
						value = new List<vipapis.category.CategoryMapping>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.category.CategoryMapping elem3;
								
								elem3 = new vipapis.category.CategoryMapping();
								vipapis.category.CategoryMappingHelper.getInstance().Read(elem3, iprot);
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetMapping(value);
					}
					
					
					
					
					
					if ("major_parent_category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetMajor_parent_category_id(value);
					}
					
					
					
					
					
					if ("salve_parent_category_ids".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								int elem5;
								elem5 = iprot.ReadI32(); 
								
								value.Add(elem5);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSalve_parent_category_ids(value);
					}
					
					
					
					
					
					if ("attributes".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.category.Attribute> value;
						
						value = new List<vipapis.category.Attribute>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.category.Attribute elem6;
								
								elem6 = new vipapis.category.Attribute();
								vipapis.category.AttributeHelper.getInstance().Read(elem6, iprot);
								
								value.Add(elem6);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetAttributes(value);
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
		
		
		public void Write(Category structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCategory_id() != null) {
				
				oprot.WriteFieldBegin("category_id");
				oprot.WriteI32((int)structs.GetCategory_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("category_id can not be null!");
			}
			
			
			if(structs.GetCategory_name() != null) {
				
				oprot.WriteFieldBegin("category_name");
				oprot.WriteString(structs.GetCategory_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetForeignname() != null) {
				
				oprot.WriteFieldBegin("foreignname");
				oprot.WriteString(structs.GetForeignname());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDescription() != null) {
				
				oprot.WriteFieldBegin("description");
				oprot.WriteString(structs.GetDescription());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCategory_type() != null) {
				
				oprot.WriteFieldBegin("category_type");
				oprot.WriteString(structs.GetCategory_type().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetKeywords() != null) {
				
				oprot.WriteFieldBegin("keywords");
				oprot.WriteString(structs.GetKeywords());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFlags() != null) {
				
				oprot.WriteFieldBegin("flags");
				oprot.WriteI64((long)structs.GetFlags()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHierarchy_id() != null) {
				
				oprot.WriteFieldBegin("hierarchy_id");
				oprot.WriteI32((int)structs.GetHierarchy_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLast_updatetime() != null) {
				
				oprot.WriteFieldBegin("last_updatetime");
				oprot.WriteI64((long)structs.GetLast_updatetime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRelated_categories() != null) {
				
				oprot.WriteFieldBegin("related_categories");
				
				oprot.WriteListBegin();
				foreach(int _item0 in structs.GetRelated_categories()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetChildren() != null) {
				
				oprot.WriteFieldBegin("children");
				
				oprot.WriteListBegin();
				foreach(vipapis.category.Category _item0 in structs.GetChildren()){
					
					
					vipapis.category.CategoryHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMapping() != null) {
				
				oprot.WriteFieldBegin("mapping");
				
				oprot.WriteListBegin();
				foreach(vipapis.category.CategoryMapping _item0 in structs.GetMapping()){
					
					
					vipapis.category.CategoryMappingHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMajor_parent_category_id() != null) {
				
				oprot.WriteFieldBegin("major_parent_category_id");
				oprot.WriteI32((int)structs.GetMajor_parent_category_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSalve_parent_category_ids() != null) {
				
				oprot.WriteFieldBegin("salve_parent_category_ids");
				
				oprot.WriteListBegin();
				foreach(int _item0 in structs.GetSalve_parent_category_ids()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAttributes() != null) {
				
				oprot.WriteFieldBegin("attributes");
				
				oprot.WriteListBegin();
				foreach(vipapis.category.Attribute _item0 in structs.GetAttributes()){
					
					
					vipapis.category.AttributeHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Category bean){
			
			
		}
		
	}
	
}