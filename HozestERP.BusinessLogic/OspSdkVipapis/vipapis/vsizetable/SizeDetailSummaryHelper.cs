using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vsizetable{
	
	
	
	public class SizeDetailSummaryHelper : TBeanSerializer<SizeDetailSummary>
	{
		
		public static SizeDetailSummaryHelper OBJ = new SizeDetailSummaryHelper();
		
		public static SizeDetailSummaryHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SizeDetailSummary structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("size_detail_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize_detail_name(value);
					}
					
					
					
					
					
					if ("size_detail_property_values".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, string> value;
						
						value = new Dictionary<string, string>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key1;
								string _val1;
								_key1 = iprot.ReadString();
								
								_val1 = iprot.ReadString();
								
								value.Add(_key1, _val1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetSize_detail_property_values(value);
					}
					
					
					
					
					
					if ("size_detail_order".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSize_detail_order(value);
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
		
		
		public void Write(SizeDetailSummary structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSize_detail_name() != null) {
				
				oprot.WriteFieldBegin("size_detail_name");
				oprot.WriteString(structs.GetSize_detail_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("size_detail_name can not be null!");
			}
			
			
			if(structs.GetSize_detail_property_values() != null) {
				
				oprot.WriteFieldBegin("size_detail_property_values");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, string > _ir0 in structs.GetSize_detail_property_values()){
					
					string _key0 = _ir0.Key;
					string _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					oprot.WriteString(_value0);
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("size_detail_property_values can not be null!");
			}
			
			
			if(structs.GetSize_detail_order() != null) {
				
				oprot.WriteFieldBegin("size_detail_order");
				oprot.WriteI32((int)structs.GetSize_detail_order()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SizeDetailSummary bean){
			
			
		}
		
	}
	
}