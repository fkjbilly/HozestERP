using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetPickFinancialDataResponseHelper : TBeanSerializer<GetPickFinancialDataResponse>
	{
		
		public static GetPickFinancialDataResponseHelper OBJ = new GetPickFinancialDataResponseHelper();
		
		public static GetPickFinancialDataResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetPickFinancialDataResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("schedule_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSchedule_id(value);
					}
					
					
					
					
					
					if ("order_details".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.OrderDetail> value;
						
						value = new List<vipapis.delivery.OrderDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.OrderDetail elem0;
								
								elem0 = new vipapis.delivery.OrderDetail();
								vipapis.delivery.OrderDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrder_details(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(GetPickFinancialDataResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSchedule_id() != null) {
				
				oprot.WriteFieldBegin("schedule_id");
				oprot.WriteString(structs.GetSchedule_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_details() != null) {
				
				oprot.WriteFieldBegin("order_details");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.OrderDetail _item0 in structs.GetOrder_details()){
					
					
					vipapis.delivery.OrderDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetPickFinancialDataResponse bean){
			
			
		}
		
	}
	
}