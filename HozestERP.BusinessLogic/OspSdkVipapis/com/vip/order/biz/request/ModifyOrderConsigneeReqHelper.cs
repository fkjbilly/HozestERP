using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class ModifyOrderConsigneeReqHelper : TBeanSerializer<ModifyOrderConsigneeReq>
	{
		
		public static ModifyOrderConsigneeReqHelper OBJ = new ModifyOrderConsigneeReqHelper();
		
		public static ModifyOrderConsigneeReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ModifyOrderConsigneeReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("service".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetService(value);
					}
					
					
					
					
					
					if ("order".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderVO();
						com.vip.order.common.pojo.order.vo.OrderVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrder(value);
					}
					
					
					
					
					
					if ("orderInvoice".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderInvoiceVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderInvoiceVO();
						com.vip.order.common.pojo.order.vo.OrderInvoiceVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderInvoice(value);
					}
					
					
					
					
					
					if ("orderAddress".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderReceiveAddrVO();
						com.vip.order.common.pojo.order.vo.OrderReceiveAddrVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderAddress(value);
					}
					
					
					
					
					
					if ("is4Level".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIs4Level(value);
					}
					
					
					
					
					
					if ("addressId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetAddressId(value);
					}
					
					
					
					
					
					if ("supplierCancel".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSupplierCancel(value);
					}
					
					
					
					
					
					if ("orderCategory".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderCategory(value);
					}
					
					
					
					
					
					if ("orderDeviceInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderDeviceInfoVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderDeviceInfoVO();
						com.vip.order.common.pojo.order.vo.OrderDeviceInfoVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderDeviceInfo(value);
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
		
		
		public void Write(ModifyOrderConsigneeReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetService() != null) {
				
				oprot.WriteFieldBegin("service");
				oprot.WriteString(structs.GetService());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder() != null) {
				
				oprot.WriteFieldBegin("order");
				
				com.vip.order.common.pojo.order.vo.OrderVOHelper.getInstance().Write(structs.GetOrder(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderInvoice() != null) {
				
				oprot.WriteFieldBegin("orderInvoice");
				
				com.vip.order.common.pojo.order.vo.OrderInvoiceVOHelper.getInstance().Write(structs.GetOrderInvoice(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderAddress() != null) {
				
				oprot.WriteFieldBegin("orderAddress");
				
				com.vip.order.common.pojo.order.vo.OrderReceiveAddrVOHelper.getInstance().Write(structs.GetOrderAddress(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIs4Level() != null) {
				
				oprot.WriteFieldBegin("is4Level");
				oprot.WriteI32((int)structs.GetIs4Level()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddressId() != null) {
				
				oprot.WriteFieldBegin("addressId");
				oprot.WriteI64((long)structs.GetAddressId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSupplierCancel() != null) {
				
				oprot.WriteFieldBegin("supplierCancel");
				oprot.WriteI32((int)structs.GetSupplierCancel()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCategory() != null) {
				
				oprot.WriteFieldBegin("orderCategory");
				oprot.WriteI32((int)structs.GetOrderCategory()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderDeviceInfo() != null) {
				
				oprot.WriteFieldBegin("orderDeviceInfo");
				
				com.vip.order.common.pojo.order.vo.OrderDeviceInfoVOHelper.getInstance().Write(structs.GetOrderDeviceInfo(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ModifyOrderConsigneeReq bean){
			
			
		}
		
	}
	
}