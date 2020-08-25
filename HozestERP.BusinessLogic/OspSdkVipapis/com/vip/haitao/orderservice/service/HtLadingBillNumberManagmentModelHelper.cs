using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtLadingBillNumberManagmentModelHelper : TBeanSerializer<HtLadingBillNumberManagmentModel>
	{
		
		public static HtLadingBillNumberManagmentModelHelper OBJ = new HtLadingBillNumberManagmentModelHelper();
		
		public static HtLadingBillNumberManagmentModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtLadingBillNumberManagmentModel structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("flightNumber".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFlightNumber(value);
					}
					
					
					
					
					
					if ("totalWeight".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetTotalWeight(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("shipmentPort".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetShipmentPort(value);
					}
					
					
					
					
					
					if ("shipmentCountry".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetShipmentCountry(value);
					}
					
					
					
					
					
					if ("arrivePort".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArrivePort(value);
					}
					
					
					
					
					
					if ("arriveCountry".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArriveCountry(value);
					}
					
					
					
					
					
					if ("attachmentPath".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAttachmentPath(value);
					}
					
					
					
					
					
					if ("senderType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetSenderType(value);
					}
					
					
					
					
					
					if ("customsClearanceMode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomsClearanceMode(value);
					}
					
					
					
					
					
					if ("customsCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomsCode(value);
					}
					
					
					
					
					
					if ("chinaFreightForwarding".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetChinaFreightForwarding(value);
					}
					
					
					
					
					
					if ("globalFreightForwarding".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGlobalFreightForwarding(value);
					}
					
					
					
					
					
					if ("saleStyle".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSaleStyle(value);
					}
					
					
					
					
					
					if ("orderCount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderCount(value);
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
		
		
		public void Write(HtLadingBillNumberManagmentModel structs, Protocol oprot){
			
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
			
			
			if(structs.GetFlightNumber() != null) {
				
				oprot.WriteFieldBegin("flightNumber");
				oprot.WriteString(structs.GetFlightNumber());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("flightNumber can not be null!");
			}
			
			
			if(structs.GetTotalWeight() != null) {
				
				oprot.WriteFieldBegin("totalWeight");
				oprot.WriteDouble((double)structs.GetTotalWeight());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("totalWeight can not be null!");
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetShipmentPort() != null) {
				
				oprot.WriteFieldBegin("shipmentPort");
				oprot.WriteString(structs.GetShipmentPort());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("shipmentPort can not be null!");
			}
			
			
			if(structs.GetShipmentCountry() != null) {
				
				oprot.WriteFieldBegin("shipmentCountry");
				oprot.WriteString(structs.GetShipmentCountry());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("shipmentCountry can not be null!");
			}
			
			
			if(structs.GetArrivePort() != null) {
				
				oprot.WriteFieldBegin("arrivePort");
				oprot.WriteString(structs.GetArrivePort());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("arrivePort can not be null!");
			}
			
			
			if(structs.GetArriveCountry() != null) {
				
				oprot.WriteFieldBegin("arriveCountry");
				oprot.WriteString(structs.GetArriveCountry());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("arriveCountry can not be null!");
			}
			
			
			if(structs.GetAttachmentPath() != null) {
				
				oprot.WriteFieldBegin("attachmentPath");
				oprot.WriteString(structs.GetAttachmentPath());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("attachmentPath can not be null!");
			}
			
			
			if(structs.GetSenderType() != null) {
				
				oprot.WriteFieldBegin("senderType");
				oprot.WriteI32((int)structs.GetSenderType()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("senderType can not be null!");
			}
			
			
			if(structs.GetCustomsClearanceMode() != null) {
				
				oprot.WriteFieldBegin("customsClearanceMode");
				oprot.WriteString(structs.GetCustomsClearanceMode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("customsClearanceMode can not be null!");
			}
			
			
			if(structs.GetCustomsCode() != null) {
				
				oprot.WriteFieldBegin("customsCode");
				oprot.WriteString(structs.GetCustomsCode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("customsCode can not be null!");
			}
			
			
			if(structs.GetChinaFreightForwarding() != null) {
				
				oprot.WriteFieldBegin("chinaFreightForwarding");
				oprot.WriteString(structs.GetChinaFreightForwarding());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("chinaFreightForwarding can not be null!");
			}
			
			
			if(structs.GetGlobalFreightForwarding() != null) {
				
				oprot.WriteFieldBegin("globalFreightForwarding");
				oprot.WriteString(structs.GetGlobalFreightForwarding());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("globalFreightForwarding can not be null!");
			}
			
			
			if(structs.GetSaleStyle() != null) {
				
				oprot.WriteFieldBegin("saleStyle");
				oprot.WriteString(structs.GetSaleStyle());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("saleStyle can not be null!");
			}
			
			
			if(structs.GetOrderCount() != null) {
				
				oprot.WriteFieldBegin("orderCount");
				oprot.WriteI32((int)structs.GetOrderCount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtLadingBillNumberManagmentModel bean){
			
			
		}
		
	}
	
}