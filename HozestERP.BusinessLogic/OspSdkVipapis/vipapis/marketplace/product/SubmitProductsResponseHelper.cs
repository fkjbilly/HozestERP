using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class SubmitProductsResponseHelper : TBeanSerializer<SubmitProductsResponse>
	{
		
		public static SubmitProductsResponseHelper OBJ = new SubmitProductsResponseHelper();
		
		public static SubmitProductsResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SubmitProductsResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("results".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.product.SubmitProductsResult> value;
						
						value = new List<vipapis.marketplace.product.SubmitProductsResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.product.SubmitProductsResult elem0;
								
								elem0 = new vipapis.marketplace.product.SubmitProductsResult();
								vipapis.marketplace.product.SubmitProductsResultHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetResults(value);
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
		
		
		public void Write(SubmitProductsResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResults() != null) {
				
				oprot.WriteFieldBegin("results");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.product.SubmitProductsResult _item0 in structs.GetResults()){
					
					
					vipapis.marketplace.product.SubmitProductsResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SubmitProductsResponse bean){
			
			
		}
		
	}
	
}