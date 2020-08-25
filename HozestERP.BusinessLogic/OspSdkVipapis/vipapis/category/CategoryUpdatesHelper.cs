using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.category{
	
	
	
	public class CategoryUpdatesHelper : TBeanSerializer<CategoryUpdates>
	{
		
		public static CategoryUpdatesHelper OBJ = new CategoryUpdatesHelper();
		
		public static CategoryUpdatesHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CategoryUpdates structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sinceUpdateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetSinceUpdateTime(value);
					}
					
					
					
					
					
					if ("lastUpdateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetLastUpdateTime(value);
					}
					
					
					
					
					
					if ("categories".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.category.CategoryUpdate> value;
						
						value = new List<vipapis.category.CategoryUpdate>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.category.CategoryUpdate elem0;
								
								elem0 = new vipapis.category.CategoryUpdate();
								vipapis.category.CategoryUpdateHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetCategories(value);
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
		
		
		public void Write(CategoryUpdates structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSinceUpdateTime() != null) {
				
				oprot.WriteFieldBegin("sinceUpdateTime");
				oprot.WriteI64((long)structs.GetSinceUpdateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sinceUpdateTime can not be null!");
			}
			
			
			if(structs.GetLastUpdateTime() != null) {
				
				oprot.WriteFieldBegin("lastUpdateTime");
				oprot.WriteI64((long)structs.GetLastUpdateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("lastUpdateTime can not be null!");
			}
			
			
			if(structs.GetCategories() != null) {
				
				oprot.WriteFieldBegin("categories");
				
				oprot.WriteListBegin();
				foreach(vipapis.category.CategoryUpdate _item0 in structs.GetCategories()){
					
					
					vipapis.category.CategoryUpdateHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CategoryUpdates bean){
			
			
		}
		
	}
	
}