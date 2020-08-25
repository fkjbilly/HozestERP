using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutWmsLadingBillIDLParamHelper : TBeanSerializer<OutWmsLadingBillIDLParam>
	{
		
		public static OutWmsLadingBillIDLParamHelper OBJ = new OutWmsLadingBillIDLParamHelper();
		
		public static OutWmsLadingBillIDLParamHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutWmsLadingBillIDLParam structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("ladingBillNumber".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLadingBillNumber(value);
					}
					
					
					
					
					
					if ("shipmentCountry".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetShipmentCountry(value);
					}
					
					
					
					
					
					if ("arriveCountry".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArriveCountry(value);
					}
					
					
					
					
					
					if ("customsClearanceMode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomsClearanceMode(value);
					}
					
					
					
					
					
					if ("totalWeight".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetTotalWeight(value);
					}
					
					
					
					
					
					if ("subBillNumerList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.sce.vlg.osp.wms.service.SubLadingBillNumberVo> value;
						
						value = new List<com.vip.sce.vlg.osp.wms.service.SubLadingBillNumberVo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.sce.vlg.osp.wms.service.SubLadingBillNumberVo elem0;
								
								elem0 = new com.vip.sce.vlg.osp.wms.service.SubLadingBillNumberVo();
								com.vip.sce.vlg.osp.wms.service.SubLadingBillNumberVoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSubBillNumerList(value);
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
		
		
		public void Write(OutWmsLadingBillIDLParam structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetLadingBillNumber() != null) {
				
				oprot.WriteFieldBegin("ladingBillNumber");
				oprot.WriteString(structs.GetLadingBillNumber());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("ladingBillNumber can not be null!");
			}
			
			
			if(structs.GetShipmentCountry() != null) {
				
				oprot.WriteFieldBegin("shipmentCountry");
				oprot.WriteString(structs.GetShipmentCountry());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArriveCountry() != null) {
				
				oprot.WriteFieldBegin("arriveCountry");
				oprot.WriteString(structs.GetArriveCountry());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustomsClearanceMode() != null) {
				
				oprot.WriteFieldBegin("customsClearanceMode");
				oprot.WriteString(structs.GetCustomsClearanceMode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalWeight() != null) {
				
				oprot.WriteFieldBegin("totalWeight");
				oprot.WriteDouble((double)structs.GetTotalWeight());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSubBillNumerList() != null) {
				
				oprot.WriteFieldBegin("subBillNumerList");
				
				oprot.WriteListBegin();
				foreach(com.vip.sce.vlg.osp.wms.service.SubLadingBillNumberVo _item0 in structs.GetSubBillNumerList()){
					
					
					com.vip.sce.vlg.osp.wms.service.SubLadingBillNumberVoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutWmsLadingBillIDLParam bean){
			
			
		}
		
	}
	
}