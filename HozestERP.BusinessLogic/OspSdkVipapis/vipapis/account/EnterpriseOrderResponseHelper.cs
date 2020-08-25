using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.account{
	
	
	
	public class EnterpriseOrderResponseHelper : TBeanSerializer<EnterpriseOrderResponse>
	{
		
		public static EnterpriseOrderResponseHelper OBJ = new EnterpriseOrderResponseHelper();
		
		public static EnterpriseOrderResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(EnterpriseOrderResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("enterpriseOrders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.account.EnterpriseOrderInfo> value;
						
						value = new List<vipapis.account.EnterpriseOrderInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.account.EnterpriseOrderInfo elem0;
								
								elem0 = new vipapis.account.EnterpriseOrderInfo();
								vipapis.account.EnterpriseOrderInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetEnterpriseOrders(value);
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
		
		
		public void Write(EnterpriseOrderResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			if(structs.GetEnterpriseOrders() != null) {
				
				oprot.WriteFieldBegin("enterpriseOrders");
				
				oprot.WriteListBegin();
				foreach(vipapis.account.EnterpriseOrderInfo _item0 in structs.GetEnterpriseOrders()){
					
					
					vipapis.account.EnterpriseOrderInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("enterpriseOrders can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(EnterpriseOrderResponse bean){
			
			
		}
		
	}
	
}