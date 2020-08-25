using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OspOutWmsPoBatchFModelHelper : TBeanSerializer<OspOutWmsPoBatchFModel>
	{
		
		public static OspOutWmsPoBatchFModelHelper OBJ = new OspOutWmsPoBatchFModelHelper();
		
		public static OspOutWmsPoBatchFModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OspOutWmsPoBatchFModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("batchId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetBatchId(value);
					}
					
					
					
					
					
					if ("batchNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatchNo(value);
					}
					
					
					
					
					
					if ("poNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPoNo(value);
					}
					
					
					
					
					
					if ("poType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPoType(value);
					}
					
					
					
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("vendorCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorCode(value);
					}
					
					
					
					
					
					if ("vendorName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorName(value);
					}
					
					
					
					
					
					if ("tradeModel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTradeModel(value);
					}
					
					
					
					
					
					if ("deliveryTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetDeliveryTime(value);
					}
					
					
					
					
					
					if ("estimateArriveTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetEstimateArriveTime(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("warehouseType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouseType(value);
					}
					
					
					
					
					
					if ("product_List".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchDxFModel> value;
						
						value = new List<com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchDxFModel>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchDxFModel elem0;
								
								elem0 = new com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchDxFModel();
								com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchDxFModelHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetProduct_List(value);
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
		
		
		public void Write(OspOutWmsPoBatchFModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetBatchId() != null) {
				
				oprot.WriteFieldBegin("batchId");
				oprot.WriteI32((int)structs.GetBatchId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBatchNo() != null) {
				
				oprot.WriteFieldBegin("batchNo");
				oprot.WriteString(structs.GetBatchNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPoNo() != null) {
				
				oprot.WriteFieldBegin("poNo");
				oprot.WriteString(structs.GetPoNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPoType() != null) {
				
				oprot.WriteFieldBegin("poType");
				oprot.WriteString(structs.GetPoType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorCode() != null) {
				
				oprot.WriteFieldBegin("vendorCode");
				oprot.WriteString(structs.GetVendorCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorName() != null) {
				
				oprot.WriteFieldBegin("vendorName");
				oprot.WriteString(structs.GetVendorName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTradeModel() != null) {
				
				oprot.WriteFieldBegin("tradeModel");
				oprot.WriteString(structs.GetTradeModel());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDeliveryTime() != null) {
				
				oprot.WriteFieldBegin("deliveryTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetDeliveryTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEstimateArriveTime() != null) {
				
				oprot.WriteFieldBegin("estimateArriveTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetEstimateArriveTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetWarehouseType() != null) {
				
				oprot.WriteFieldBegin("warehouseType");
				oprot.WriteString(structs.GetWarehouseType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProduct_List() != null) {
				
				oprot.WriteFieldBegin("product_List");
				
				oprot.WriteListBegin();
				foreach(com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchDxFModel _item0 in structs.GetProduct_List()){
					
					
					com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchDxFModelHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("product_List can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OspOutWmsPoBatchFModel bean){
			
			
		}
		
	}
	
}