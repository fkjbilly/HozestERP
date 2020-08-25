using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.category{
	
	
	
	public class GetStoreCategoriesResponseHelper : TBeanSerializer<GetStoreCategoriesResponse>
	{
		
		public static GetStoreCategoriesResponseHelper OBJ = new GetStoreCategoriesResponseHelper();
		
		public static GetStoreCategoriesResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetStoreCategoriesResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("categories".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.category.StoreCategory> value;
						
						value = new List<vipapis.marketplace.category.StoreCategory>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.category.StoreCategory elem0;
								
								elem0 = new vipapis.marketplace.category.StoreCategory();
								vipapis.marketplace.category.StoreCategoryHelper.getInstance().Read(elem0, iprot);
								
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
		
		
		public void Write(GetStoreCategoriesResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCategories() != null) {
				
				oprot.WriteFieldBegin("categories");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.category.StoreCategory _item0 in structs.GetCategories()){
					
					
					vipapis.marketplace.category.StoreCategoryHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("categories can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetStoreCategoriesResponse bean){
			
			
		}
		
	}
	
}