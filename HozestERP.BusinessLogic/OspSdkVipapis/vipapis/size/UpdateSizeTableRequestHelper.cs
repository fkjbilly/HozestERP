using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.size{
	
	
	
	public class UpdateSizeTableRequestHelper : TBeanSerializer<UpdateSizeTableRequest>
	{
		
		public static UpdateSizeTableRequestHelper OBJ = new UpdateSizeTableRequestHelper();
		
		public static UpdateSizeTableRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UpdateSizeTableRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("size_table_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetSize_table_id(value);
					}
					
					
					
					
					
					if ("size_table_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize_table_name(value);
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
					
					
					
					
					
					if ("category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetCategory_id(value);
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
		
		
		public void Write(UpdateSizeTableRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetSize_table_id() != null) {
				
				oprot.WriteFieldBegin("size_table_id");
				oprot.WriteI64((long)structs.GetSize_table_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("size_table_id can not be null!");
			}
			
			
			if(structs.GetSize_table_name() != null) {
				
				oprot.WriteFieldBegin("size_table_name");
				oprot.WriteString(structs.GetSize_table_name());
				
				oprot.WriteFieldEnd();
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
			
			
			if(structs.GetCategory_id() != null) {
				
				oprot.WriteFieldBegin("category_id");
				oprot.WriteI32((int)structs.GetCategory_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("category_id can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(UpdateSizeTableRequest bean){
			
			
		}
		
	}
	
}