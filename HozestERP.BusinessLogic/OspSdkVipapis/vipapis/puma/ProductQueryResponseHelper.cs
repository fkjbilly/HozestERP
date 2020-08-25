using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.puma{
	
	
	
	public class ProductQueryResponseHelper : TBeanSerializer<ProductQueryResponse>
	{
		
		public static ProductQueryResponseHelper OBJ = new ProductQueryResponseHelper();
		
		public static ProductQueryResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ProductQueryResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("pagination".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.puma.Pagination value;
						
						value = new vipapis.puma.Pagination();
						vipapis.puma.PaginationHelper.getInstance().Read(value, iprot);
						
						structs.SetPagination(value);
					}
					
					
					
					
					
					if ("marketing_products".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.puma.Product> value;
						
						value = new List<vipapis.puma.Product>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.puma.Product elem1;
								
								elem1 = new vipapis.puma.Product();
								vipapis.puma.ProductHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetMarketing_products(value);
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
		
		
		public void Write(ProductQueryResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPagination() != null) {
				
				oprot.WriteFieldBegin("pagination");
				
				vipapis.puma.PaginationHelper.getInstance().Write(structs.GetPagination(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMarketing_products() != null) {
				
				oprot.WriteFieldBegin("marketing_products");
				
				oprot.WriteListBegin();
				foreach(vipapis.puma.Product _item0 in structs.GetMarketing_products()){
					
					
					vipapis.puma.ProductHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ProductQueryResponse bean){
			
			
		}
		
	}
	
}