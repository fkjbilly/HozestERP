using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutInbShipmentInfoHelper : TBeanSerializer<OutInbShipmentInfo>
	{
		
		public static OutInbShipmentInfoHelper OBJ = new OutInbShipmentInfoHelper();
		
		public static OutInbShipmentInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutInbShipmentInfo structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("entInboundId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEntInboundId(value);
					}
					
					
					
					
					
					if ("asnNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAsnNo(value);
					}
					
					
					
					
					
					if ("batchNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatchNo(value);
					}
					
					
					
					
					
					if ("inTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInTime(value);
					}
					
					
					
					
					
					if ("confirmationTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetConfirmationTime(value);
					}
					
					
					
					
					
					if ("custInboundno".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustInboundno(value);
					}
					
					
					
					
					
					if ("icipInboundno".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIcipInboundno(value);
					}
					
					
					
					
					
					if ("blNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBlNo(value);
					}
					
					
					
					
					
					if ("detail".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.sce.vlg.osp.wms.service.OutInbShipmentDatailInfo> value;
						
						value = new List<com.vip.sce.vlg.osp.wms.service.OutInbShipmentDatailInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.sce.vlg.osp.wms.service.OutInbShipmentDatailInfo elem1;
								
								elem1 = new com.vip.sce.vlg.osp.wms.service.OutInbShipmentDatailInfo();
								com.vip.sce.vlg.osp.wms.service.OutInbShipmentDatailInfoHelper.getInstance().Read(elem1, iprot);
								
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
		
		
		public void Write(OutInbShipmentInfo structs, Protocol oprot){
			
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
			
			
			if(structs.GetEntInboundId() != null) {
				
				oprot.WriteFieldBegin("entInboundId");
				oprot.WriteString(structs.GetEntInboundId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("entInboundId can not be null!");
			}
			
			
			if(structs.GetAsnNo() != null) {
				
				oprot.WriteFieldBegin("asnNo");
				oprot.WriteString(structs.GetAsnNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBatchNo() != null) {
				
				oprot.WriteFieldBegin("batchNo");
				oprot.WriteString(structs.GetBatchNo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("batchNo can not be null!");
			}
			
			
			if(structs.GetInTime() != null) {
				
				oprot.WriteFieldBegin("inTime");
				oprot.WriteString(structs.GetInTime());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("inTime can not be null!");
			}
			
			
			if(structs.GetConfirmationTime() != null) {
				
				oprot.WriteFieldBegin("confirmationTime");
				oprot.WriteString(structs.GetConfirmationTime());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("confirmationTime can not be null!");
			}
			
			
			if(structs.GetCustInboundno() != null) {
				
				oprot.WriteFieldBegin("custInboundno");
				oprot.WriteString(structs.GetCustInboundno());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("custInboundno can not be null!");
			}
			
			
			if(structs.GetIcipInboundno() != null) {
				
				oprot.WriteFieldBegin("icipInboundno");
				oprot.WriteString(structs.GetIcipInboundno());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("icipInboundno can not be null!");
			}
			
			
			if(structs.GetBlNo() != null) {
				
				oprot.WriteFieldBegin("blNo");
				oprot.WriteString(structs.GetBlNo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("blNo can not be null!");
			}
			
			
			if(structs.GetDetail() != null) {
				
				oprot.WriteFieldBegin("detail");
				
				oprot.WriteListBegin();
				foreach(com.vip.sce.vlg.osp.wms.service.OutInbShipmentDatailInfo _item0 in structs.GetDetail()){
					
					
					com.vip.sce.vlg.osp.wms.service.OutInbShipmentDatailInfoHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(OutInbShipmentInfo bean){
			
			
		}
		
	}
	
}