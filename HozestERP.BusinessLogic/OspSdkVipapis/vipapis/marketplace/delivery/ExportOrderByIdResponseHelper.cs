using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.delivery{
	
	
	
	public class ExportOrderByIdResponseHelper : TBeanSerializer<ExportOrderByIdResponse>
	{
		
		public static ExportOrderByIdResponseHelper OBJ = new ExportOrderByIdResponseHelper();
		
		public static ExportOrderByIdResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ExportOrderByIdResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.delivery.ExportOrderInfo> value;
						
						value = new List<vipapis.marketplace.delivery.ExportOrderInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.delivery.ExportOrderInfo elem0;
								
								elem0 = new vipapis.marketplace.delivery.ExportOrderInfo();
								vipapis.marketplace.delivery.ExportOrderInfoHelper.getInstance().Read(elem0, iprot);
								
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
		
		
		public void Write(ExportOrderByIdResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrders() != null) {
				
				oprot.WriteFieldBegin("orders");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.delivery.ExportOrderInfo _item0 in structs.GetOrders()){
					
					
					vipapis.marketplace.delivery.ExportOrderInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ExportOrderByIdResponse bean){
			
			
		}
		
	}
	
}