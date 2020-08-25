using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderPackageDetailVOHelper : TBeanSerializer<OrderPackageDetailVO>
	{
		
		public static OrderPackageDetailVOHelper OBJ = new OrderPackageDetailVOHelper();
		
		public static OrderPackageDetailVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderPackageDetailVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("merItemNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetMerItemNo(value);
					}
					
					
					
					
					
					if ("sizeSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSizeSn(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("vSkuId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetVSkuId(value);
					}
					
					
					
					
					
					if ("goodsVersion".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetGoodsVersion(value);
					}
					
					
					
					
					
					if ("skuName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSkuName(value);
					}
					
					
					
					
					
					if ("sizeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSizeName(value);
					}
					
					
					
					
					
					if ("salesNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSalesNo(value);
					}
					
					
					
					
					
					if ("salesName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSalesName(value);
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
		
		
		public void Write(OrderPackageDetailVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetMerItemNo() != null) {
				
				oprot.WriteFieldBegin("merItemNo");
				oprot.WriteI64((long)structs.GetMerItemNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizeSn() != null) {
				
				oprot.WriteFieldBegin("sizeSn");
				oprot.WriteString(structs.GetSizeSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteI32((int)structs.GetAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVSkuId() != null) {
				
				oprot.WriteFieldBegin("vSkuId");
				oprot.WriteI64((long)structs.GetVSkuId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsVersion() != null) {
				
				oprot.WriteFieldBegin("goodsVersion");
				oprot.WriteI32((int)structs.GetGoodsVersion()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSkuName() != null) {
				
				oprot.WriteFieldBegin("skuName");
				oprot.WriteString(structs.GetSkuName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizeName() != null) {
				
				oprot.WriteFieldBegin("sizeName");
				oprot.WriteString(structs.GetSizeName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSalesNo() != null) {
				
				oprot.WriteFieldBegin("salesNo");
				oprot.WriteI64((long)structs.GetSalesNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSalesName() != null) {
				
				oprot.WriteFieldBegin("salesName");
				oprot.WriteString(structs.GetSalesName());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderPackageDetailVO bean){
			
			
		}
		
	}
	
}