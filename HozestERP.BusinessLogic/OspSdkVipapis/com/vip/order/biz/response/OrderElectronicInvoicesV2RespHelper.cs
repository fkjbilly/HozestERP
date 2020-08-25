using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class OrderElectronicInvoicesV2RespHelper : TBeanSerializer<OrderElectronicInvoicesV2Resp>
	{
		
		public static OrderElectronicInvoicesV2RespHelper OBJ = new OrderElectronicInvoicesV2RespHelper();
		
		public static OrderElectronicInvoicesV2RespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderElectronicInvoicesV2Resp structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("result".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.result.Result value;
						
						value = new com.vip.order.common.pojo.order.result.Result();
						com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Read(value, iprot);
						
						structs.SetResult(value);
					}
					
					
					
					
					
					if ("orderElectronicInvoiceList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.response.OrderElectronicInvoiceDetailV2Resp> value;
						
						value = new List<com.vip.order.biz.response.OrderElectronicInvoiceDetailV2Resp>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.response.OrderElectronicInvoiceDetailV2Resp elem1;
								
								elem1 = new com.vip.order.biz.response.OrderElectronicInvoiceDetailV2Resp();
								com.vip.order.biz.response.OrderElectronicInvoiceDetailV2RespHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderElectronicInvoiceList(value);
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
		
		
		public void Write(OrderElectronicInvoicesV2Resp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderElectronicInvoiceList() != null) {
				
				oprot.WriteFieldBegin("orderElectronicInvoiceList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.response.OrderElectronicInvoiceDetailV2Resp _item0 in structs.GetOrderElectronicInvoiceList()){
					
					
					com.vip.order.biz.response.OrderElectronicInvoiceDetailV2RespHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderElectronicInvoicesV2Resp bean){
			
			
		}
		
	}
	
}