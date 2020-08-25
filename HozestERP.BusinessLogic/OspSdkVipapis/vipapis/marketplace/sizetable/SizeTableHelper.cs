using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.sizetable{
	
	
	
	public class SizeTableHelper : TBeanSerializer<SizeTable>
	{
		
		public static SizeTableHelper OBJ = new SizeTableHelper();
		
		public static SizeTableHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SizeTable structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("size_table_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetSize_table_id(value);
					}
					
					
					
					
					
					if ("size_table_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						short value;
						value = iprot.ReadI16(); 
						
						structs.SetSize_table_type(value);
					}
					
					
					
					
					
					if ("size_table_html".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize_table_html(value);
					}
					
					
					
					
					
					if ("size_table_tips".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize_table_tips(value);
					}
					
					
					
					
					
					if ("del_flag".Equals(schemeField.Trim())){
						
						needSkip = false;
						short? value;
						value = iprot.ReadI16(); 
						
						structs.SetDel_flag(value);
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
		
		
		public void Write(SizeTable structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSize_table_id() != null) {
				
				oprot.WriteFieldBegin("size_table_id");
				oprot.WriteI64((long)structs.GetSize_table_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("size_table_id can not be null!");
			}
			
			
			if(structs.GetSize_table_type() != null) {
				
				oprot.WriteFieldBegin("size_table_type");
				oprot.WriteI16((short)structs.GetSize_table_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("size_table_type can not be null!");
			}
			
			
			if(structs.GetSize_table_html() != null) {
				
				oprot.WriteFieldBegin("size_table_html");
				oprot.WriteString(structs.GetSize_table_html());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_table_tips() != null) {
				
				oprot.WriteFieldBegin("size_table_tips");
				oprot.WriteString(structs.GetSize_table_tips());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDel_flag() != null) {
				
				oprot.WriteFieldBegin("del_flag");
				oprot.WriteI16((short)structs.GetDel_flag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SizeTable bean){
			
			
		}
		
	}
	
}