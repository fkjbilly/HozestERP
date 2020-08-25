using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class SpuWithSkusBaseInfoHelper : TBeanSerializer<SpuWithSkusBaseInfo>
	{
		
		public static SpuWithSkusBaseInfoHelper OBJ = new SpuWithSkusBaseInfoHelper();
		
		public static SpuWithSkusBaseInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SpuWithSkusBaseInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetBrand_id(value);
					}
					
					
					
					
					
					if ("sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSn(value);
					}
					
					
					
					
					
					if ("product_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_name(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.product.ProductStatus? value;
						
						value = vipapis.product.ProductStatusUtil.FindByName(iprot.ReadString());
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("sku_base_info_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.SkuBaseInfo> value;
						
						value = new List<vipapis.product.SkuBaseInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.SkuBaseInfo elem1;
								
								elem1 = new vipapis.product.SkuBaseInfo();
								vipapis.product.SkuBaseInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSku_base_info_list(value);
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
		
		
		public void Write(SpuWithSkusBaseInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteI32((int)structs.GetBrand_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSn() != null) {
				
				oprot.WriteFieldBegin("sn");
				oprot.WriteString(structs.GetSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_name() != null) {
				
				oprot.WriteFieldBegin("product_name");
				oprot.WriteString(structs.GetProduct_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteString(structs.GetStatus().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSku_base_info_list() != null) {
				
				oprot.WriteFieldBegin("sku_base_info_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.SkuBaseInfo _item0 in structs.GetSku_base_info_list()){
					
					
					vipapis.product.SkuBaseInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SpuWithSkusBaseInfo bean){
			
			
		}
		
	}
	
}