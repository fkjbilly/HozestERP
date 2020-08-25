using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.finance{
	
	
	
	public class GetBasicPickFinancialDataResponseHelper : TBeanSerializer<GetBasicPickFinancialDataResponse>
	{
		
		public static GetBasicPickFinancialDataResponseHelper OBJ = new GetBasicPickFinancialDataResponseHelper();
		
		public static GetBasicPickFinancialDataResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetBasicPickFinancialDataResponse structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("sales_order_details".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.finance.SalesOrderDetail> value;
						
						value = new List<vipapis.finance.SalesOrderDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.finance.SalesOrderDetail elem0;
								
								elem0 = new vipapis.finance.SalesOrderDetail();
								vipapis.finance.SalesOrderDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSales_order_details(value);
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
		
		
		public void Write(GetBasicPickFinancialDataResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSchedule_id() != null) {
				
				oprot.WriteFieldBegin("schedule_id");
				oprot.WriteString(structs.GetSchedule_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSales_order_details() != null) {
				
				oprot.WriteFieldBegin("sales_order_details");
				
				oprot.WriteListBegin();
				foreach(vipapis.finance.SalesOrderDetail _item0 in structs.GetSales_order_details()){
					
					
					vipapis.finance.SalesOrderDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetBasicPickFinancialDataResponse bean){
			
			
		}
		
	}
	
}