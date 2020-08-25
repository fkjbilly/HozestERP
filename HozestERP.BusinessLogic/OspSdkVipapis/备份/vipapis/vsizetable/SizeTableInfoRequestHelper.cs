using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vsizetable{
	
	
	
	public class SizeTableInfoRequestHelper : BeanSerializer<SizeTableInfoRequest>
	{
		
		public static SizeTableInfoRequestHelper OBJ = new SizeTableInfoRequestHelper();
		
		public static SizeTableInfoRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SizeTableInfoRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sizetable_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSizetable_id(value);
					}
					
					
					
					
					
					if ("sizetable_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						short value;
						value = iprot.ReadI16(); 
						
						structs.SetSizetable_type(value);
					}
					
					
					
					
					
					if ("sizetable_html".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSizetable_html(value);
					}
					
					
					
					
					
					if ("sizetable_tips".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSizetable_tips(value);
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
		
		
		public void Write(SizeTableInfoRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSizetable_id() != null) {
				
				oprot.WriteFieldBegin("sizetable_id");
				oprot.WriteI64((long)structs.GetSizetable_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizetable_type() != null) {
				
				oprot.WriteFieldBegin("sizetable_type");
				oprot.WriteI16((short)structs.GetSizetable_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sizetable_type can not be null!");
			}
			
			
			if(structs.GetSizetable_html() != null) {
				
				oprot.WriteFieldBegin("sizetable_html");
				oprot.WriteString(structs.GetSizetable_html());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizetable_tips() != null) {
				
				oprot.WriteFieldBegin("sizetable_tips");
				oprot.WriteString(structs.GetSizetable_tips());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SizeTableInfoRequest bean){
			
			
		}
		
	}
	
}