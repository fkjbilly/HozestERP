using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class ResultRequirementHelper : TBeanSerializer<ResultRequirement>
	{
		
		public static ResultRequirementHelper OBJ = new ResultRequirementHelper();
		
		public static ResultRequirementHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ResultRequirement structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("returnFieldList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem1;
								elem1 = iprot.ReadString();
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetReturnFieldList(value);
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
						List<com.vip.order.biz.request.OrderBy> value;
						
						value = new List<com.vip.order.biz.request.OrderBy>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.request.OrderBy elem2;
								
								elem2 = new com.vip.order.biz.request.OrderBy();
								com.vip.order.biz.request.OrderByHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
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
		
		
		public void Write(ResultRequirement structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturnFieldList() != null) {
				
				oprot.WriteFieldBegin("returnFieldList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetReturnFieldList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
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
				foreach(com.vip.order.biz.request.OrderBy _item0 in structs.GetOrderbyList()){
					
					
					com.vip.order.biz.request.OrderByHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ResultRequirement bean){
			
			
		}
		
	}
	
}