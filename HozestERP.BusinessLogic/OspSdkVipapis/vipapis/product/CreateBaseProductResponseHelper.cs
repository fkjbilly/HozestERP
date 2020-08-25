using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class CreateBaseProductResponseHelper : TBeanSerializer<CreateBaseProductResponse>
	{
		
		public static CreateBaseProductResponseHelper OBJ = new CreateBaseProductResponseHelper();
		
		public static CreateBaseProductResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CreateBaseProductResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("success_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.CreateBaseProductResult> value;
						
						value = new List<vipapis.product.CreateBaseProductResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.CreateBaseProductResult elem0;
								
								elem0 = new vipapis.product.CreateBaseProductResult();
								vipapis.product.CreateBaseProductResultHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSuccess_list(value);
					}
					
					
					
					
					
					if ("failed_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.CreateBaseProductResult> value;
						
						value = new List<vipapis.product.CreateBaseProductResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.CreateBaseProductResult elem2;
								
								elem2 = new vipapis.product.CreateBaseProductResult();
								vipapis.product.CreateBaseProductResultHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFailed_list(value);
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
		
		
		public void Write(CreateBaseProductResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSuccess_list() != null) {
				
				oprot.WriteFieldBegin("success_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.CreateBaseProductResult _item0 in structs.GetSuccess_list()){
					
					
					vipapis.product.CreateBaseProductResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFailed_list() != null) {
				
				oprot.WriteFieldBegin("failed_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.CreateBaseProductResult _item0 in structs.GetFailed_list()){
					
					
					vipapis.product.CreateBaseProductResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CreateBaseProductResponse bean){
			
			
		}
		
	}
	
}