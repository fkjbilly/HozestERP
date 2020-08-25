using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class SaleOrdersHelper : BeanSerializer<SaleOrders>
	{
		
		public static SaleOrdersHelper OBJ = new SaleOrdersHelper();
		
		public static SaleOrdersHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SaleOrders structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("out_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOut_time(value);
					}
					
					
					
					
					
					if ("order_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.overseas.SaleOrderInfo> value;
						
						value = new List<vipapis.overseas.SaleOrderInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.overseas.SaleOrderInfo elem0;
								
								elem0 = new vipapis.overseas.SaleOrderInfo();
								vipapis.overseas.SaleOrderInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrder_list(value);
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
		
		
		public void Write(SaleOrders structs, Protocol oprot){
			
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
			
			
			if(structs.GetOut_time() != null) {
				
				oprot.WriteFieldBegin("out_time");
				oprot.WriteString(structs.GetOut_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("out_time can not be null!");
			}
			
			
			if(structs.GetOrder_list() != null) {
				
				oprot.WriteFieldBegin("order_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.overseas.SaleOrderInfo _item0 in structs.GetOrder_list()){
					
					
					vipapis.overseas.SaleOrderInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SaleOrders bean){
			
			
		}
		
	}
	
}