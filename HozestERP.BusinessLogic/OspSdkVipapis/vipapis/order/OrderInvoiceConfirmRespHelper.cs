using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class OrderInvoiceConfirmRespHelper : TBeanSerializer<OrderInvoiceConfirmResp>
	{
		
		public static OrderInvoiceConfirmRespHelper OBJ = new OrderInvoiceConfirmRespHelper();
		
		public static OrderInvoiceConfirmRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderInvoiceConfirmResp structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("success_list".Equals(schemeField.Trim())){
						
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
						
						structs.SetSuccess_list(value);
					}
					
					
					
					
					
					if ("fail_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.order.FailConfirmItem> value;
						
						value = new List<vipapis.order.FailConfirmItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.order.FailConfirmItem elem1;
								
								elem1 = new vipapis.order.FailConfirmItem();
								vipapis.order.FailConfirmItemHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
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
		
		
		public void Write(OrderInvoiceConfirmResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSuccess_list() != null) {
				
				oprot.WriteFieldBegin("success_list");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetSuccess_list()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFail_list() != null) {
				
				oprot.WriteFieldBegin("fail_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.order.FailConfirmItem _item0 in structs.GetFail_list()){
					
					
					vipapis.order.FailConfirmItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderInvoiceConfirmResp bean){
			
			
		}
		
	}
	
}