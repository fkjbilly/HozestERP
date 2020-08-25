using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderReturnMoneyVOHelper : TBeanSerializer<OrderReturnMoneyVO>
	{
		
		public static OrderReturnMoneyVOHelper OBJ = new OrderReturnMoneyVOHelper();
		
		public static OrderReturnMoneyVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderReturnMoneyVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("returnMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.ReturnMoneyVO value;
						
						value = new com.vip.order.common.pojo.order.vo.ReturnMoneyVO();
						com.vip.order.common.pojo.order.vo.ReturnMoneyVOHelper.getInstance().Read(value, iprot);
						
						structs.SetReturnMoney(value);
					}
					
					
					
					
					
					if ("returnType".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.ReturnTypeVO value;
						
						value = new com.vip.order.common.pojo.order.vo.ReturnTypeVO();
						com.vip.order.common.pojo.order.vo.ReturnTypeVOHelper.getInstance().Read(value, iprot);
						
						structs.SetReturnType(value);
					}
					
					
					
					
					
					if ("returnVirtualMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnVirtualMoney(value);
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
		
		
		public void Write(OrderReturnMoneyVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturnMoney() != null) {
				
				oprot.WriteFieldBegin("returnMoney");
				
				com.vip.order.common.pojo.order.vo.ReturnMoneyVOHelper.getInstance().Write(structs.GetReturnMoney(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnType() != null) {
				
				oprot.WriteFieldBegin("returnType");
				
				com.vip.order.common.pojo.order.vo.ReturnTypeVOHelper.getInstance().Write(structs.GetReturnType(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnVirtualMoney() != null) {
				
				oprot.WriteFieldBegin("returnVirtualMoney");
				oprot.WriteString(structs.GetReturnVirtualMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderReturnMoneyVO bean){
			
			
		}
		
	}
	
}