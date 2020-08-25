using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class OrderInvoiceReqHelper : TBeanSerializer<OrderInvoiceReq>
	{
		
		public static OrderInvoiceReqHelper OBJ = new OrderInvoiceReqHelper();
		
		public static OrderInvoiceReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderInvoiceReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("invoice_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetInvoice_type(value);
					}
					
					
					
					
					
					if ("e_invoice".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.order.Einvoice> value;
						
						value = new List<vipapis.order.Einvoice>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.order.Einvoice elem0;
								
								elem0 = new vipapis.order.Einvoice();
								vipapis.order.EinvoiceHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetE_invoice(value);
					}
					
					
					
					
					
					if ("paper_invoice".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.order.PaperInvoice value;
						
						value = new vipapis.order.PaperInvoice();
						vipapis.order.PaperInvoiceHelper.getInstance().Read(value, iprot);
						
						structs.SetPaper_invoice(value);
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
		
		
		public void Write(OrderInvoiceReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_id can not be null!");
			}
			
			
			if(structs.GetInvoice_type() != null) {
				
				oprot.WriteFieldBegin("invoice_type");
				oprot.WriteI32((int)structs.GetInvoice_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("invoice_type can not be null!");
			}
			
			
			if(structs.GetE_invoice() != null) {
				
				oprot.WriteFieldBegin("e_invoice");
				
				oprot.WriteListBegin();
				foreach(vipapis.order.Einvoice _item0 in structs.GetE_invoice()){
					
					
					vipapis.order.EinvoiceHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPaper_invoice() != null) {
				
				oprot.WriteFieldBegin("paper_invoice");
				
				vipapis.order.PaperInvoiceHelper.getInstance().Write(structs.GetPaper_invoice(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderInvoiceReq bean){
			
			
		}
		
	}
	
}