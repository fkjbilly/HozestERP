using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.request{
	
	
	
	public class RangeParamHelper : TBeanSerializer<RangeParam>
	{
		
		public static RangeParamHelper OBJ = new RangeParamHelper();
		
		public static RangeParamHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(RangeParam structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("inclusion".Equals(schemeField.Trim())){
						
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
						
						structs.SetInclusion(value);
					}
					
					
					
					
					
					if ("exclusion".Equals(schemeField.Trim())){
						
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
						
						structs.SetExclusion(value);
					}
					
					
					
					
					
					if ("begin".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBegin(value);
					}
					
					
					
					
					
					if ("end".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEnd(value);
					}
					
					
					
					
					
					if ("beginInclusive".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetBeginInclusive(value);
					}
					
					
					
					
					
					if ("endInclusive".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetEndInclusive(value);
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
		
		
		public void Write(RangeParam structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetInclusion() != null) {
				
				oprot.WriteFieldBegin("inclusion");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetInclusion()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExclusion() != null) {
				
				oprot.WriteFieldBegin("exclusion");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetExclusion()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBegin() != null) {
				
				oprot.WriteFieldBegin("begin");
				oprot.WriteString(structs.GetBegin());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEnd() != null) {
				
				oprot.WriteFieldBegin("end");
				oprot.WriteString(structs.GetEnd());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBeginInclusive() != null) {
				
				oprot.WriteFieldBegin("beginInclusive");
				oprot.WriteBool((bool)structs.GetBeginInclusive());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEndInclusive() != null) {
				
				oprot.WriteFieldBegin("endInclusive");
				oprot.WriteBool((bool)structs.GetEndInclusive());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(RangeParam bean){
			
			
		}
		
	}
	
}