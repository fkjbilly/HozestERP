using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class UpdateOrderPayResultReqHelper : TBeanSerializer<UpdateOrderPayResultReq>
	{
		
		public static UpdateOrderPayResultReqHelper OBJ = new UpdateOrderPayResultReqHelper();
		
		public static UpdateOrderPayResultReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UpdateOrderPayResultReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("orderCategory".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderCategory(value);
					}
					
					
					
					
					
					if ("orderCodeList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderCodeList(value);
					}
					
					
					
					
					
					if ("orderList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.NotifyRequestOrderVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.NotifyRequestOrderVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.NotifyRequestOrderVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.NotifyRequestOrderVO();
								com.vip.order.common.pojo.order.vo.NotifyRequestOrderVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderList(value);
					}
					
					
					
					
					
					if ("orderInvoice".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderInvoiceVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderInvoiceVO();
						com.vip.order.common.pojo.order.vo.OrderInvoiceVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderInvoice(value);
					}
					
					
					
					
					
					if ("orderPayDetailsList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderPayDetailVO elem4;
								
								elem4 = new com.vip.order.common.pojo.order.vo.OrderPayDetailVO();
								com.vip.order.common.pojo.order.vo.OrderPayDetailVOHelper.getInstance().Read(elem4, iprot);
								
								value.Add(elem4);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderPayDetailsList(value);
					}
					
					
					
					
					
					if ("tradeNumber".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTradeNumber(value);
					}
					
					
					
					
					
					if ("invoiceDeductRemark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInvoiceDeductRemark(value);
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
		
		
		public void Write(UpdateOrderPayResultReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCategory() != null) {
				
				oprot.WriteFieldBegin("orderCategory");
				oprot.WriteI32((int)structs.GetOrderCategory()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCodeList() != null) {
				
				oprot.WriteFieldBegin("orderCodeList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetOrderCodeList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderList() != null) {
				
				oprot.WriteFieldBegin("orderList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.NotifyRequestOrderVO _item0 in structs.GetOrderList()){
					
					
					com.vip.order.common.pojo.order.vo.NotifyRequestOrderVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderInvoice() != null) {
				
				oprot.WriteFieldBegin("orderInvoice");
				
				com.vip.order.common.pojo.order.vo.OrderInvoiceVOHelper.getInstance().Write(structs.GetOrderInvoice(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderPayDetailsList() != null) {
				
				oprot.WriteFieldBegin("orderPayDetailsList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderPayDetailVO _item0 in structs.GetOrderPayDetailsList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderPayDetailVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTradeNumber() != null) {
				
				oprot.WriteFieldBegin("tradeNumber");
				oprot.WriteString(structs.GetTradeNumber());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoiceDeductRemark() != null) {
				
				oprot.WriteFieldBegin("invoiceDeductRemark");
				oprot.WriteString(structs.GetInvoiceDeductRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(UpdateOrderPayResultReq bean){
			
			
		}
		
	}
	
}