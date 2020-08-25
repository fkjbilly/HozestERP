using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.finance{
	
	
	
	public class GetOrderFinancialDataResponseHelper : TBeanSerializer<GetOrderFinancialDataResponse>
	{
		
		public static GetOrderFinancialDataResponseHelper OBJ = new GetOrderFinancialDataResponseHelper();
		
		public static GetOrderFinancialDataResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderFinancialDataResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.finance.OrderDetail> value;
						
						value = new List<vipapis.finance.OrderDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.finance.OrderDetail elem0;
								
								elem0 = new vipapis.finance.OrderDetail();
								vipapis.finance.OrderDetailHelper.getInstance().Read(elem0, iprot);
								
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
		
		
		public void Write(GetOrderFinancialDataResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrders() != null) {
				
				oprot.WriteFieldBegin("orders");
				
				oprot.WriteListBegin();
				foreach(vipapis.finance.OrderDetail _item0 in structs.GetOrders()){
					
					
					vipapis.finance.OrderDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrderFinancialDataResponse bean){
			
			
		}
		
	}
	
}