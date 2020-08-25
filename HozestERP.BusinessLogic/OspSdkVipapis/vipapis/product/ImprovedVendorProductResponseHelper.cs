using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class ImprovedVendorProductResponseHelper : TBeanSerializer<ImprovedVendorProductResponse>
	{
		
		public static ImprovedVendorProductResponseHelper OBJ = new ImprovedVendorProductResponseHelper();
		
		public static ImprovedVendorProductResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ImprovedVendorProductResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("success_items".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.ImprovedVendorProductSuccessItem> value;
						
						value = new List<vipapis.product.ImprovedVendorProductSuccessItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.ImprovedVendorProductSuccessItem elem0;
								
								elem0 = new vipapis.product.ImprovedVendorProductSuccessItem();
								vipapis.product.ImprovedVendorProductSuccessItemHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSuccess_items(value);
					}
					
					
					
					
					
					if ("fail_items".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.ImprovedVendorProductFailItem> value;
						
						value = new List<vipapis.product.ImprovedVendorProductFailItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.ImprovedVendorProductFailItem elem2;
								
								elem2 = new vipapis.product.ImprovedVendorProductFailItem();
								vipapis.product.ImprovedVendorProductFailItemHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFail_items(value);
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
		
		
		public void Write(ImprovedVendorProductResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSuccess_items() != null) {
				
				oprot.WriteFieldBegin("success_items");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.ImprovedVendorProductSuccessItem _item0 in structs.GetSuccess_items()){
					
					
					vipapis.product.ImprovedVendorProductSuccessItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFail_items() != null) {
				
				oprot.WriteFieldBegin("fail_items");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.ImprovedVendorProductFailItem _item0 in structs.GetFail_items()){
					
					
					vipapis.product.ImprovedVendorProductFailItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ImprovedVendorProductResponse bean){
			
			
		}
		
	}
	
}