using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class OrderInvoiceQueryRespHelper : TBeanSerializer<OrderInvoiceQueryResp>
	{
		
		public static OrderInvoiceQueryRespHelper OBJ = new OrderInvoiceQueryRespHelper();
		
		public static OrderInvoiceQueryRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderInvoiceQueryResp structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("success_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.order.OrderInvoiceResp> value;
						
						value = new List<vipapis.order.OrderInvoiceResp>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.order.OrderInvoiceResp elem1;
								
								elem1 = new vipapis.order.OrderInvoiceResp();
								vipapis.order.OrderInvoiceRespHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSuccess_list(value);
					}
					
					
					
					
					
					if ("fail_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.order.FailQueryItem> value;
						
						value = new List<vipapis.order.FailQueryItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.order.FailQueryItem elem3;
								
								elem3 = new vipapis.order.FailQueryItem();
								vipapis.order.FailQueryItemHelper.getInstance().Read(elem3, iprot);
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFail_list(value);
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
		
		
		public void Write(OrderInvoiceQueryResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSuccess_list() != null) {
				
				oprot.WriteFieldBegin("success_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.order.OrderInvoiceResp _item0 in structs.GetSuccess_list()){
					
					
					vipapis.order.OrderInvoiceRespHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFail_list() != null) {
				
				oprot.WriteFieldBegin("fail_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.order.FailQueryItem _item0 in structs.GetFail_list()){
					
					
					vipapis.order.FailQueryItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderInvoiceQueryResp bean){
			
			
		}
		
	}
	
}