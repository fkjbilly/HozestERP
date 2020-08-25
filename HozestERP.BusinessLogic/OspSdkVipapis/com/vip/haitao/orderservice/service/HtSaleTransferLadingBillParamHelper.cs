using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtSaleTransferLadingBillParamHelper : TBeanSerializer<HtSaleTransferLadingBillParam>
	{
		
		public static HtSaleTransferLadingBillParamHelper OBJ = new HtSaleTransferLadingBillParamHelper();
		
		public static HtSaleTransferLadingBillParamHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtSaleTransferLadingBillParam structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
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
						List<com.vip.haitao.orderservice.service.SubLadingBillNumberVo> value;
						
						value = new List<com.vip.haitao.orderservice.service.SubLadingBillNumberVo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.orderservice.service.SubLadingBillNumberVo elem0;
								
								elem0 = new com.vip.haitao.orderservice.service.SubLadingBillNumberVo();
								com.vip.haitao.orderservice.service.SubLadingBillNumberVoHelper.getInstance().Read(elem0, iprot);
								
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
		
		
		public void Write(HtSaleTransferLadingBillParam structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
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
				foreach(com.vip.haitao.orderservice.service.SubLadingBillNumberVo _item0 in structs.GetSubBillNumerList()){
					
					
					com.vip.haitao.orderservice.service.SubLadingBillNumberVoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtSaleTransferLadingBillParam bean){
			
			
		}
		
	}
	
}