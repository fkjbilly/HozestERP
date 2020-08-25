using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request.requirement{
	
	
	
	public class GetOrderLogstOrderByHelper : TBeanSerializer<GetOrderLogstOrderBy>
	{
		
		public static GetOrderLogstOrderByHelper OBJ = new GetOrderLogstOrderByHelper();
		
		public static GetOrderLogstOrderByHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderLogstOrderBy structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("field".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.request.requirement.GetOrderLogstOrderByField? value;
						
						value = com.vip.order.biz.request.requirement.GetOrderLogstOrderByFieldUtil.FindByName(iprot.ReadString());
						
						structs.SetField(value);
					}
					
					
					
					
					
					if ("direction".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.request.requirement.OrderByDirection? value;
						
						value = com.vip.order.biz.request.requirement.OrderByDirectionUtil.FindByName(iprot.ReadString());
						
						structs.SetDirection(value);
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
		
		
		public void Write(GetOrderLogstOrderBy structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetField() != null) {
				
				oprot.WriteFieldBegin("field");
				oprot.WriteString(structs.GetField().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDirection() != null) {
				
				oprot.WriteFieldBegin("direction");
				oprot.WriteString(structs.GetDirection().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrderLogstOrderBy bean){
			
			
		}
		
	}
	
}