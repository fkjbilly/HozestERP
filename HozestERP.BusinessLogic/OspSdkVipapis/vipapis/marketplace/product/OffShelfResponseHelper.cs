using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class OffShelfResponseHelper : TBeanSerializer<OffShelfResponse>
	{
		
		public static OffShelfResponseHelper OBJ = new OffShelfResponseHelper();
		
		public static OffShelfResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OffShelfResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("modify_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetModify_time(value);
					}
					
					
					
					
					
					if ("op_results".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, bool?> value;
						
						value = new Dictionary<string, bool?>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key0;
								bool _val0;
								_key0 = iprot.ReadString();
								
								_val0 = iprot.ReadBool();
								
								value.Add(_key0, _val0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetOp_results(value);
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
		
		
		public void Write(OffShelfResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetModify_time() != null) {
				
				oprot.WriteFieldBegin("modify_time");
				oprot.WriteString(structs.GetModify_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOp_results() != null) {
				
				oprot.WriteFieldBegin("op_results");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, bool? > _ir0 in structs.GetOp_results()){
					
					string _key0 = _ir0.Key;
					bool? _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					oprot.WriteBool((bool)_value0);
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OffShelfResponse bean){
			
			
		}
		
	}
	
}