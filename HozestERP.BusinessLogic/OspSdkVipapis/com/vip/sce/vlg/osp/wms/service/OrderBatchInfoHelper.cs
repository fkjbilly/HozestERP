using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OrderBatchInfoHelper : TBeanSerializer<OrderBatchInfo>
	{
		
		public static OrderBatchInfoHelper OBJ = new OrderBatchInfoHelper();
		
		public static OrderBatchInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderBatchInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("statusType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStatusType(value);
					}
					
					
					
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("batchNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatchNo(value);
					}
					
					
					
					
					
					if ("details".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.sce.vlg.osp.wms.service.OrderBatchDetailInfo> value;
						
						value = new List<com.vip.sce.vlg.osp.wms.service.OrderBatchDetailInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.sce.vlg.osp.wms.service.OrderBatchDetailInfo elem1;
								
								elem1 = new com.vip.sce.vlg.osp.wms.service.OrderBatchDetailInfo();
								com.vip.sce.vlg.osp.wms.service.OrderBatchDetailInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDetails(value);
					}
					
					
					
					
					
					if ("totalShipments".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTotalShipments(value);
					}
					
					
					
					
					
					if ("totalSku".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTotalSku(value);
					}
					
					
					
					
					
					if ("pickZone".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPickZone(value);
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
		
		
		public void Write(OrderBatchInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetStatusType() != null) {
				
				oprot.WriteFieldBegin("statusType");
				oprot.WriteString(structs.GetStatusType());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("statusType can not be null!");
			}
			
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteString(structs.GetVendorId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendorId can not be null!");
			}
			
			
			if(structs.GetBatchNo() != null) {
				
				oprot.WriteFieldBegin("batchNo");
				oprot.WriteString(structs.GetBatchNo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("batchNo can not be null!");
			}
			
			
			if(structs.GetDetails() != null) {
				
				oprot.WriteFieldBegin("details");
				
				oprot.WriteListBegin();
				foreach(com.vip.sce.vlg.osp.wms.service.OrderBatchDetailInfo _item0 in structs.GetDetails()){
					
					
					com.vip.sce.vlg.osp.wms.service.OrderBatchDetailInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("details can not be null!");
			}
			
			
			if(structs.GetTotalShipments() != null) {
				
				oprot.WriteFieldBegin("totalShipments");
				oprot.WriteString(structs.GetTotalShipments());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalSku() != null) {
				
				oprot.WriteFieldBegin("totalSku");
				oprot.WriteString(structs.GetTotalSku());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPickZone() != null) {
				
				oprot.WriteFieldBegin("pickZone");
				oprot.WriteString(structs.GetPickZone());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderBatchInfo bean){
			
			
		}
		
	}
	
}