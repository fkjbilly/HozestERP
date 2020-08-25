using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutOubShipmentInfoHelper : TBeanSerializer<OutOubShipmentInfo>
	{
		
		public static OutOubShipmentInfoHelper OBJ = new OutOubShipmentInfoHelper();
		
		public static OutOubShipmentInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutOubShipmentInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("warehouseId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouseId(value);
					}
					
					
					
					
					
					if ("version".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVersion(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("outTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOutTime(value);
					}
					
					
					
					
					
					if ("orderZCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderZCode(value);
					}
					
					
					
					
					
					if ("inventoryType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInventoryType(value);
					}
					
					
					
					
					
					if ("detail".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.sce.vlg.osp.wms.service.OutOubShipmentDatailInfo> value;
						
						value = new List<com.vip.sce.vlg.osp.wms.service.OutOubShipmentDatailInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.sce.vlg.osp.wms.service.OutOubShipmentDatailInfo elem1;
								
								elem1 = new com.vip.sce.vlg.osp.wms.service.OutOubShipmentDatailInfo();
								com.vip.sce.vlg.osp.wms.service.OutOubShipmentDatailInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDetail(value);
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
		
		
		public void Write(OutOubShipmentInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetWarehouseId() != null) {
				
				oprot.WriteFieldBegin("warehouseId");
				oprot.WriteString(structs.GetWarehouseId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouseId can not be null!");
			}
			
			
			if(structs.GetVersion() != null) {
				
				oprot.WriteFieldBegin("version");
				oprot.WriteString(structs.GetVersion());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("version can not be null!");
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orderSn can not be null!");
			}
			
			
			if(structs.GetOutTime() != null) {
				
				oprot.WriteFieldBegin("outTime");
				oprot.WriteString(structs.GetOutTime());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("outTime can not be null!");
			}
			
			
			if(structs.GetOrderZCode() != null) {
				
				oprot.WriteFieldBegin("orderZCode");
				oprot.WriteString(structs.GetOrderZCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInventoryType() != null) {
				
				oprot.WriteFieldBegin("inventoryType");
				oprot.WriteString(structs.GetInventoryType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDetail() != null) {
				
				oprot.WriteFieldBegin("detail");
				
				oprot.WriteListBegin();
				foreach(com.vip.sce.vlg.osp.wms.service.OutOubShipmentDatailInfo _item0 in structs.GetDetail()){
					
					
					com.vip.sce.vlg.osp.wms.service.OutOubShipmentDatailInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("detail can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutOubShipmentInfo bean){
			
			
		}
		
	}
	
}