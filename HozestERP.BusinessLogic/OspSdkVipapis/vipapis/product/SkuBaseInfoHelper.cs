using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class SkuBaseInfoHelper : TBeanSerializer<SkuBaseInfo>
	{
		
		public static SkuBaseInfoHelper OBJ = new SkuBaseInfoHelper();
		
		public static SkuBaseInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SkuBaseInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("greoup_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGreoup_sn(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("sale_props_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.SaleProps> value;
						
						value = new List<vipapis.product.SaleProps>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.SaleProps elem0;
								
								elem0 = new vipapis.product.SaleProps();
								vipapis.product.SalePropsHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSale_props_list(value);
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
		
		
		public void Write(SkuBaseInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetGreoup_sn() != null) {
				
				oprot.WriteFieldBegin("greoup_sn");
				oprot.WriteString(structs.GetGreoup_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSale_props_list() != null) {
				
				oprot.WriteFieldBegin("sale_props_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.SaleProps _item0 in structs.GetSale_props_list()){
					
					
					vipapis.product.SalePropsHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SkuBaseInfo bean){
			
			
		}
		
	}
	
}