using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtSaleTransferBatchNoParamHelper : TBeanSerializer<HtSaleTransferBatchNoParam>
	{
		
		public static HtSaleTransferBatchNoParamHelper OBJ = new HtSaleTransferBatchNoParamHelper();
		
		public static HtSaleTransferBatchNoParamHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtSaleTransferBatchNoParam structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("batchNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatchNo(value);
					}
					
					
					
					
					
					if ("deliveryNum".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetDeliveryNum(value);
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
					
					
					
					
					
					if ("customsClearanceMode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomsClearanceMode(value);
					}
					
					
					
					
					
					if ("creatTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreatTime(value);
					}
					
					
					
					
					
					if ("orders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder> value;
						
						value = new List<com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder elem0;
								
								elem0 = new com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder();
								com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrderHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrders(value);
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
		
		
		public void Write(HtSaleTransferBatchNoParam structs, Protocol oprot){
			
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
			
			
			if(structs.GetBatchNo() != null) {
				
				oprot.WriteFieldBegin("batchNo");
				oprot.WriteString(structs.GetBatchNo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("batchNo can not be null!");
			}
			
			
			if(structs.GetDeliveryNum() != null) {
				
				oprot.WriteFieldBegin("deliveryNum");
				oprot.WriteI32((int)structs.GetDeliveryNum()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("deliveryNum can not be null!");
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
			
			
			if(structs.GetCustomsClearanceMode() != null) {
				
				oprot.WriteFieldBegin("customsClearanceMode");
				oprot.WriteString(structs.GetCustomsClearanceMode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("customsClearanceMode can not be null!");
			}
			
			
			if(structs.GetCreatTime() != null) {
				
				oprot.WriteFieldBegin("creatTime");
				oprot.WriteString(structs.GetCreatTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrders() != null) {
				
				oprot.WriteFieldBegin("orders");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrder _item0 in structs.GetOrders()){
					
					
					com.vip.haitao.orderservice.service.HtSaleTransferBatchNoReOrderHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtSaleTransferBatchNoParam bean){
			
			
		}
		
	}
	
}