using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class HtProductListResultHelper : TBeanSerializer<HtProductListResult>
	{
		
		public static HtProductListResultHelper OBJ = new HtProductListResultHelper();
		
		public static HtProductListResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtProductListResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("page".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetPage(value);
					}
					
					
					
					
					
					if ("total_page".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal_page(value);
					}
					
					
					
					
					
					if ("product_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.HtProduct> value;
						
						value = new List<vipapis.product.HtProduct>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.HtProduct elem0;
								
								elem0 = new vipapis.product.HtProduct();
								vipapis.product.HtProductHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetProduct_list(value);
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
		
		
		public void Write(HtProductListResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPage() != null) {
				
				oprot.WriteFieldBegin("page");
				oprot.WriteI32((int)structs.GetPage()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("page can not be null!");
			}
			
			
			if(structs.GetTotal_page() != null) {
				
				oprot.WriteFieldBegin("total_page");
				oprot.WriteI32((int)structs.GetTotal_page()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_page can not be null!");
			}
			
			
			if(structs.GetProduct_list() != null) {
				
				oprot.WriteFieldBegin("product_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.HtProduct _item0 in structs.GetProduct_list()){
					
					
					vipapis.product.HtProductHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("product_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtProductListResult bean){
			
			
		}
		
	}
	
}