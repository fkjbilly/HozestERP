using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.category{
	
	
	
	public class AttributeHelper : BeanSerializer<Attribute>
	{
		
		public static AttributeHelper OBJ = new AttributeHelper();
		
		public static AttributeHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Attribute structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("attriute_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetAttriute_id(value);
					}
					
					
					
					
					
					if ("attribute_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAttribute_name(value);
					}
					
					
					
					
					
					if ("foreignname".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetForeignname(value);
					}
					
					
					
					
					
					if ("description".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDescription(value);
					}
					
					
					
					
					
					if ("attribute_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.category.AttributeType? value;
						
						value = vipapis.category.AttributeTypeUtil.FindByName(iprot.ReadString());
						
						structs.SetAttribute_type(value);
					}
					
					
					
					
					
					if ("data_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.category.DataType? value;
						
						value = vipapis.category.DataTypeUtil.FindByName(iprot.ReadString());
						
						structs.SetData_type(value);
					}
					
					
					
					
					
					if ("unit".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUnit(value);
					}
					
					
					
					
					
					if ("sort".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSort(value);
					}
					
					
					
					
					
					if ("flags".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetFlags(value);
					}
					
					
					
					
					
					if ("parent_attribute_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetParent_attribute_id(value);
					}
					
					
					
					
					
					if ("options".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.category.Option> value;
						
						value = new List<vipapis.category.Option>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.category.Option elem0;
								
								elem0 = new vipapis.category.Option();
								vipapis.category.OptionHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOptions(value);
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
		
		
		public void Write(Attribute structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetAttriute_id() != null) {
				
				oprot.WriteFieldBegin("attriute_id");
				oprot.WriteI32((int)structs.GetAttriute_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("attriute_id can not be null!");
			}
			
			
			if(structs.GetAttribute_name() != null) {
				
				oprot.WriteFieldBegin("attribute_name");
				oprot.WriteString(structs.GetAttribute_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetForeignname() != null) {
				
				oprot.WriteFieldBegin("foreignname");
				oprot.WriteString(structs.GetForeignname());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDescription() != null) {
				
				oprot.WriteFieldBegin("description");
				oprot.WriteString(structs.GetDescription());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAttribute_type() != null) {
				
				oprot.WriteFieldBegin("attribute_type");
				oprot.WriteString(structs.GetAttribute_type().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetData_type() != null) {
				
				oprot.WriteFieldBegin("data_type");
				oprot.WriteString(structs.GetData_type().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnit() != null) {
				
				oprot.WriteFieldBegin("unit");
				oprot.WriteString(structs.GetUnit());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSort() != null) {
				
				oprot.WriteFieldBegin("sort");
				oprot.WriteI32((int)structs.GetSort()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFlags() != null) {
				
				oprot.WriteFieldBegin("flags");
				oprot.WriteI64((long)structs.GetFlags()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetParent_attribute_id() != null) {
				
				oprot.WriteFieldBegin("parent_attribute_id");
				oprot.WriteI32((int)structs.GetParent_attribute_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOptions() != null) {
				
				oprot.WriteFieldBegin("options");
				
				oprot.WriteListBegin();
				foreach(vipapis.category.Option _item0 in structs.GetOptions()){
					
					
					vipapis.category.OptionHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Attribute bean){
			
			
		}
		
	}
	
}