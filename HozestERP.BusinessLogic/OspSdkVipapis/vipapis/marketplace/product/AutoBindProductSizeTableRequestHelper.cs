using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class AutoBindProductSizeTableRequestHelper : TBeanSerializer<AutoBindProductSizeTableRequest>
	{
		
		public static AutoBindProductSizeTableRequestHelper OBJ = new AutoBindProductSizeTableRequestHelper();
		
		public static AutoBindProductSizeTableRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AutoBindProductSizeTableRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("spu_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSpu_id(value);
					}
					
					
					
					
					
					if ("size_table_template_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetSize_table_template_id(value);
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
		
		
		public void Write(AutoBindProductSizeTableRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSpu_id() != null) {
				
				oprot.WriteFieldBegin("spu_id");
				oprot.WriteString(structs.GetSpu_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("spu_id can not be null!");
			}
			
			
			if(structs.GetSize_table_template_id() != null) {
				
				oprot.WriteFieldBegin("size_table_template_id");
				oprot.WriteI32((int)structs.GetSize_table_template_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("size_table_template_id can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AutoBindProductSizeTableRequest bean){
			
			
		}
		
	}
	
}