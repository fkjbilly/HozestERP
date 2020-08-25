using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request.requirement{
	
	
	
	public class GetOrderLogsRequirementHelper : TBeanSerializer<GetOrderLogsRequirement>
	{
		
		public static GetOrderLogsRequirementHelper OBJ = new GetOrderLogsRequirementHelper();
		
		public static GetOrderLogsRequirementHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderLogsRequirement structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("returnFields".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnFields(value);
					}
					
					
					
					
					
					if ("limit".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetLimit(value);
					}
					
					
					
					
					
					if ("offset".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOffset(value);
					}
					
					
					
					
					
					if ("orderbyList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.request.requirement.GetOrderLogstOrderBy> value;
						
						value = new List<com.vip.order.biz.request.requirement.GetOrderLogstOrderBy>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.request.requirement.GetOrderLogstOrderBy elem0;
								
								elem0 = new com.vip.order.biz.request.requirement.GetOrderLogstOrderBy();
								com.vip.order.biz.request.requirement.GetOrderLogstOrderByHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderbyList(value);
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
		
		
		public void Write(GetOrderLogsRequirement structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturnFields() != null) {
				
				oprot.WriteFieldBegin("returnFields");
				oprot.WriteString(structs.GetReturnFields());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLimit() != null) {
				
				oprot.WriteFieldBegin("limit");
				oprot.WriteI32((int)structs.GetLimit()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOffset() != null) {
				
				oprot.WriteFieldBegin("offset");
				oprot.WriteI32((int)structs.GetOffset()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderbyList() != null) {
				
				oprot.WriteFieldBegin("orderbyList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.request.requirement.GetOrderLogstOrderBy _item0 in structs.GetOrderbyList()){
					
					
					com.vip.order.biz.request.requirement.GetOrderLogstOrderByHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrderLogsRequirement bean){
			
			
		}
		
	}
	
}