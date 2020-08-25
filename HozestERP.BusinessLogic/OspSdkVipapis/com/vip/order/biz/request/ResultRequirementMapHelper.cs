using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class ResultRequirementMapHelper : TBeanSerializer<ResultRequirementMap>
	{
		
		public static ResultRequirementMapHelper OBJ = new ResultRequirementMapHelper();
		
		public static ResultRequirementMapHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ResultRequirementMap structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("returnFields".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, string> value;
						
						value = new Dictionary<string, string>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key0;
								string _val0;
								_key0 = iprot.ReadString();
								
								_val0 = iprot.ReadString();
								
								value.Add(_key0, _val0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
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
					
					
					
					
					
					if ("orderby".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.request.OrderBy> value;
						
						value = new List<com.vip.order.biz.request.OrderBy>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.request.OrderBy elem1;
								
								elem1 = new com.vip.order.biz.request.OrderBy();
								com.vip.order.biz.request.OrderByHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderby(value);
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
		
		
		public void Write(ResultRequirementMap structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturnFields() != null) {
				
				oprot.WriteFieldBegin("returnFields");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, string > _ir0 in structs.GetReturnFields()){
					
					string _key0 = _ir0.Key;
					string _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					oprot.WriteString(_value0);
					
				}
				
				oprot.WriteMapEnd();
				
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
			
			
			if(structs.GetOrderby() != null) {
				
				oprot.WriteFieldBegin("orderby");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.request.OrderBy _item0 in structs.GetOrderby()){
					
					
					com.vip.order.biz.request.OrderByHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ResultRequirementMap bean){
			
			
		}
		
	}
	
}