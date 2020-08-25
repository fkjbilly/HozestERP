using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.schema{
	
	
	
	public class ProductResponseHelper : TBeanSerializer<ProductResponse>
	{
		
		public static ProductResponseHelper OBJ = new ProductResponseHelper();
		
		public static ProductResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ProductResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSn(value);
					}
					
					
					
					
					
					if ("brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetBrand_id(value);
					}
					
					
					
					
					
					if ("error_msg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetError_msg(value);
					}
					
					
					
					
					
					if ("success_sku_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.schema.SuccessSkuItem> value;
						
						value = new List<com.vip.isv.schema.SuccessSkuItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.schema.SuccessSkuItem elem0;
								
								elem0 = new com.vip.isv.schema.SuccessSkuItem();
								com.vip.isv.schema.SuccessSkuItemHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSuccess_sku_list(value);
					}
					
					
					
					
					
					if ("fail_sku_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.schema.VendorProductFailItem> value;
						
						value = new List<com.vip.isv.schema.VendorProductFailItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.schema.VendorProductFailItem elem2;
								
								elem2 = new com.vip.isv.schema.VendorProductFailItem();
								com.vip.isv.schema.VendorProductFailItemHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFail_sku_list(value);
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
		
		
		public void Write(ProductResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSn() != null) {
				
				oprot.WriteFieldBegin("sn");
				oprot.WriteString(structs.GetSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteI32((int)structs.GetBrand_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetError_msg() != null) {
				
				oprot.WriteFieldBegin("error_msg");
				oprot.WriteString(structs.GetError_msg());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSuccess_sku_list() != null) {
				
				oprot.WriteFieldBegin("success_sku_list");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.schema.SuccessSkuItem _item0 in structs.GetSuccess_sku_list()){
					
					
					com.vip.isv.schema.SuccessSkuItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFail_sku_list() != null) {
				
				oprot.WriteFieldBegin("fail_sku_list");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.schema.VendorProductFailItem _item0 in structs.GetFail_sku_list()){
					
					
					com.vip.isv.schema.VendorProductFailItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ProductResponse bean){
			
			
		}
		
	}
	
}