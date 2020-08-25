using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class ConditionItemHelper : TBeanSerializer<ConditionItem>
	{
		
		public static ConditionItemHelper OBJ = new ConditionItemHelper();
		
		public static ConditionItemHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ConditionItem structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("fieldName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFieldName(value);
					}
					
					
					
					
					
					if ("expr".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExpr(value);
					}
					
					
					
					
					
					if ("values".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetValues(value);
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
		
		
		public void Write(ConditionItem structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetFieldName() != null) {
				
				oprot.WriteFieldBegin("fieldName");
				oprot.WriteString(structs.GetFieldName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExpr() != null) {
				
				oprot.WriteFieldBegin("expr");
				oprot.WriteString(structs.GetExpr());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetValues() != null) {
				
				oprot.WriteFieldBegin("values");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetValues()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ConditionItem bean){
			
			
		}
		
	}
	
}