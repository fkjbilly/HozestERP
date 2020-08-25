using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.size{
	
	
	
	public class SizeMappingHelper : TBeanSerializer<SizeMapping>
	{
		
		public static SizeMappingHelper OBJ = new SizeMappingHelper();
		
		public static SizeMappingHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SizeMapping structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCategory_id(value);
					}
					
					
					
					
					
					if ("category_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCategory_name(value);
					}
					
					
					
					
					
					if ("size_table_attrs".Equals(schemeField.Trim())){
						
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
						
						structs.SetSize_table_attrs(value);
					}
					
					
					
					
					
					if ("illustrative_image".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIllustrative_image(value);
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
		
		
		public void Write(SizeMapping structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCategory_id() != null) {
				
				oprot.WriteFieldBegin("category_id");
				oprot.WriteI32((int)structs.GetCategory_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCategory_name() != null) {
				
				oprot.WriteFieldBegin("category_name");
				oprot.WriteString(structs.GetCategory_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_table_attrs() != null) {
				
				oprot.WriteFieldBegin("size_table_attrs");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetSize_table_attrs()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIllustrative_image() != null) {
				
				oprot.WriteFieldBegin("illustrative_image");
				oprot.WriteString(structs.GetIllustrative_image());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SizeMapping bean){
			
			
		}
		
	}
	
}