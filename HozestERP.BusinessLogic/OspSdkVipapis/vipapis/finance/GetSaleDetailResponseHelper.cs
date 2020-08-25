using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.finance{
	
	
	
	public class GetSaleDetailResponseHelper : TBeanSerializer<GetSaleDetailResponse>
	{
		
		public static GetSaleDetailResponseHelper OBJ = new GetSaleDetailResponseHelper();
		
		public static GetSaleDetailResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetSaleDetailResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_item_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.finance.OrderItem> value;
						
						value = new List<vipapis.finance.OrderItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.finance.OrderItem elem0;
								
								elem0 = new vipapis.finance.OrderItem();
								vipapis.finance.OrderItemHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrder_item_list(value);
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
		
		
		public void Write(GetSaleDetailResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_item_list() != null) {
				
				oprot.WriteFieldBegin("order_item_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.finance.OrderItem _item0 in structs.GetOrder_item_list()){
					
					
					vipapis.finance.OrderItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetSaleDetailResponse bean){
			
			
		}
		
	}
	
}