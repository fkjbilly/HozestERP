using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.category{
	
	
	
	public class OptionHelper : TBeanSerializer<Option>
	{
		
		public static OptionHelper OBJ = new OptionHelper();
		
		public static OptionHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Option structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("attributeId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetAttributeId(value);
					}
					
					
					
					
					
					if ("optionId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetOptionId(value);
					}
					
					
					
					
					
					if ("name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetName(value);
					}
					
					
					
					
					
					if ("description".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDescription(value);
					}
					
					
					
					
					
					if ("hierarchyGroup".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetHierarchyGroup(value);
					}
					
					
					
					
					
					if ("sort".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSort(value);
					}
					
					
					
					
					
					if ("parentOptionId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetParentOptionId(value);
					}
					
					
					
					
					
					if ("isVirtual".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsVirtual(value);
					}
					
					
					
					
					
					if ("realOptions".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								int elem1;
								elem1 = iprot.ReadI32(); 
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetRealOptions(value);
					}
					
					
					
					
					
					if ("foreignname".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetForeignname(value);
					}
					
					
					
					
					
					if ("externaldata".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExternaldata(value);
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
		
		
		public void Write(Option structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetAttributeId() != null) {
				
				oprot.WriteFieldBegin("attributeId");
				oprot.WriteI32((int)structs.GetAttributeId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("attributeId can not be null!");
			}
			
			
			if(structs.GetOptionId() != null) {
				
				oprot.WriteFieldBegin("optionId");
				oprot.WriteI32((int)structs.GetOptionId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("optionId can not be null!");
			}
			
			
			if(structs.GetName() != null) {
				
				oprot.WriteFieldBegin("name");
				oprot.WriteString(structs.GetName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDescription() != null) {
				
				oprot.WriteFieldBegin("description");
				oprot.WriteString(structs.GetDescription());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHierarchyGroup() != null) {
				
				oprot.WriteFieldBegin("hierarchyGroup");
				oprot.WriteString(structs.GetHierarchyGroup());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSort() != null) {
				
				oprot.WriteFieldBegin("sort");
				oprot.WriteI32((int)structs.GetSort()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetParentOptionId() != null) {
				
				oprot.WriteFieldBegin("parentOptionId");
				oprot.WriteI32((int)structs.GetParentOptionId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsVirtual() != null) {
				
				oprot.WriteFieldBegin("isVirtual");
				oprot.WriteBool((bool)structs.GetIsVirtual());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRealOptions() != null) {
				
				oprot.WriteFieldBegin("realOptions");
				
				oprot.WriteListBegin();
				foreach(int _item0 in structs.GetRealOptions()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetForeignname() != null) {
				
				oprot.WriteFieldBegin("foreignname");
				oprot.WriteString(structs.GetForeignname());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExternaldata() != null) {
				
				oprot.WriteFieldBegin("externaldata");
				oprot.WriteString(structs.GetExternaldata());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Option bean){
			
			
		}
		
	}
	
}