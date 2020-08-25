using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class OrderActiveDetailResultHelper : TBeanSerializer<OrderActiveDetailResult>
	{
		
		public static OrderActiveDetailResultHelper OBJ = new OrderActiveDetailResultHelper();
		
		public static OrderActiveDetailResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderActiveDetailResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("resultCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetResultCode(value);
					}
					
					
					
					
					
					if ("activeDetailList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderActiveDetailVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderActiveDetailVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderActiveDetailVO elem0;
								
								elem0 = new com.vip.order.common.pojo.order.vo.OrderActiveDetailVO();
								com.vip.order.common.pojo.order.vo.OrderActiveDetailVOHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetActiveDetailList(value);
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
		
		
		public void Write(OrderActiveDetailResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetResultCode() != null) {
				
				oprot.WriteFieldBegin("resultCode");
				oprot.WriteI32((int)structs.GetResultCode()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActiveDetailList() != null) {
				
				oprot.WriteFieldBegin("activeDetailList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderActiveDetailVO _item0 in structs.GetActiveDetailList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderActiveDetailVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderActiveDetailResult bean){
			
			
		}
		
	}
	
}