using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutWmsGlobalDeliverBatchParamHelper : TBeanSerializer<OutWmsGlobalDeliverBatchParam>
	{
		
		public static OutWmsGlobalDeliverBatchParamHelper OBJ = new OutWmsGlobalDeliverBatchParamHelper();
		
		public static OutWmsGlobalDeliverBatchParamHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutWmsGlobalDeliverBatchParam structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
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
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreateTime(value);
					}
					
					
					
					
					
					if ("orders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchOrderParam> value;
						
						value = new List<com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchOrderParam>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchOrderParam elem0;
								
								elem0 = new com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchOrderParam();
								com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchOrderParamHelper.getInstance().Read(elem0, iprot);
								
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
		
		
		public void Write(OutWmsGlobalDeliverBatchParam structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
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
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteString(structs.GetCreateTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrders() != null) {
				
				oprot.WriteFieldBegin("orders");
				
				oprot.WriteListBegin();
				foreach(com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchOrderParam _item0 in structs.GetOrders()){
					
					
					com.vip.sce.vlg.osp.wms.service.OutWmsGlobalDeliverBatchOrderParamHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orders can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutWmsGlobalDeliverBatchParam bean){
			
			
		}
		
	}
	
}