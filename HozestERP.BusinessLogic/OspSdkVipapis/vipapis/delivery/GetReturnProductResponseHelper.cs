using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetReturnProductResponseHelper : TBeanSerializer<GetReturnProductResponse>
	{
		
		public static GetReturnProductResponseHelper OBJ = new GetReturnProductResponseHelper();
		
		public static GetReturnProductResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetReturnProductResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("dvd_return_product_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.DvdReturnProduct> value;
						
						value = new List<vipapis.delivery.DvdReturnProduct>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.DvdReturnProduct elem0;
								
								elem0 = new vipapis.delivery.DvdReturnProduct();
								vipapis.delivery.DvdReturnProductHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDvd_return_product_list(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(GetReturnProductResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDvd_return_product_list() != null) {
				
				oprot.WriteFieldBegin("dvd_return_product_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.DvdReturnProduct _item0 in structs.GetDvd_return_product_list()){
					
					
					vipapis.delivery.DvdReturnProductHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetReturnProductResponse bean){
			
			
		}
		
	}
	
}