using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderGoodsWarehouseDetailVOHelper : TBeanSerializer<OrderGoodsWarehouseDetailVO>
	{
		
		public static OrderGoodsWarehouseDetailVOHelper OBJ = new OrderGoodsWarehouseDetailVOHelper();
		
		public static OrderGoodsWarehouseDetailVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderGoodsWarehouseDetailVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sizeId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSizeId(value);
					}
					
					
					
					
					
					if ("bondedWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBondedWarehouse(value);
					}
					
					
					
					
					
					if ("sourceWarehouseDetail".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSourceWarehouseDetail(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetCreateTime(value);
					}
					
					
					
					
					
					if ("sizeSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSizeSn(value);
					}
					
					
					
					
					
					if ("brandId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetBrandId(value);
					}
					
					
					
					
					
					if ("saleStyle".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSaleStyle(value);
					}
					
					
					
					
					
					if ("vrOrderType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVrOrderType(value);
					}
					
					
					
					
					
					if ("isDelete".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsDelete(value);
					}
					
					
					
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("parentSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetParentSn(value);
					}
					
					
					
					
					
					if ("merItemNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetMerItemNo(value);
					}
					
					
					
					
					
					if ("salesNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSalesNo(value);
					}
					
					
					
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetId(value);
					}
					
					
					
					
					
					if ("preAllocateId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPreAllocateId(value);
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
		
		
		public void Write(OrderGoodsWarehouseDetailVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSizeId() != null) {
				
				oprot.WriteFieldBegin("sizeId");
				oprot.WriteI64((long)structs.GetSizeId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBondedWarehouse() != null) {
				
				oprot.WriteFieldBegin("bondedWarehouse");
				oprot.WriteString(structs.GetBondedWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSourceWarehouseDetail() != null) {
				
				oprot.WriteFieldBegin("sourceWarehouseDetail");
				oprot.WriteString(structs.GetSourceWarehouseDetail());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteI64((long)structs.GetCreateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizeSn() != null) {
				
				oprot.WriteFieldBegin("sizeSn");
				oprot.WriteString(structs.GetSizeSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrandId() != null) {
				
				oprot.WriteFieldBegin("brandId");
				oprot.WriteI32((int)structs.GetBrandId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSaleStyle() != null) {
				
				oprot.WriteFieldBegin("saleStyle");
				oprot.WriteI32((int)structs.GetSaleStyle()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVrOrderType() != null) {
				
				oprot.WriteFieldBegin("vrOrderType");
				oprot.WriteI32((int)structs.GetVrOrderType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsDelete() != null) {
				
				oprot.WriteFieldBegin("isDelete");
				oprot.WriteI32((int)structs.GetIsDelete()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteI64((long)structs.GetOrderId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetParentSn() != null) {
				
				oprot.WriteFieldBegin("parentSn");
				oprot.WriteString(structs.GetParentSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerItemNo() != null) {
				
				oprot.WriteFieldBegin("merItemNo");
				oprot.WriteI64((long)structs.GetMerItemNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSalesNo() != null) {
				
				oprot.WriteFieldBegin("salesNo");
				oprot.WriteI64((long)structs.GetSalesNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteI64((long)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPreAllocateId() != null) {
				
				oprot.WriteFieldBegin("preAllocateId");
				oprot.WriteI64((long)structs.GetPreAllocateId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderGoodsWarehouseDetailVO bean){
			
			
		}
		
	}
	
}