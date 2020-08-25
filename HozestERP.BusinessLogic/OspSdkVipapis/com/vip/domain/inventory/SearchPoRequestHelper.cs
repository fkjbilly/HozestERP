using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class SearchPoRequestHelper : TBeanSerializer<SearchPoRequest>
	{
		
		public static SearchPoRequestHelper OBJ = new SearchPoRequestHelper();
		
		public static SearchPoRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SearchPoRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("systemPoNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSystemPoNo(value);
					}
					
					
					
					
					
					if ("clientPoNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetClientPoNo(value);
					}
					
					
					
					
					
					if ("warehouseCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouseCode(value);
					}
					
					
					
					
					
					if ("poStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPoStatus(value);
					}
					
					
					
					
					
					if ("createDateStart".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreateDateStart(value);
					}
					
					
					
					
					
					if ("createDateEnd".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreateDateEnd(value);
					}
					
					
					
					
					
					if ("startOnRacksTimeStart".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStartOnRacksTimeStart(value);
					}
					
					
					
					
					
					if ("startOnRacksTimeEnd".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStartOnRacksTimeEnd(value);
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
		
		
		public void Write(SearchPoRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSystemPoNo() != null) {
				
				oprot.WriteFieldBegin("systemPoNo");
				oprot.WriteString(structs.GetSystemPoNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetClientPoNo() != null) {
				
				oprot.WriteFieldBegin("clientPoNo");
				oprot.WriteString(structs.GetClientPoNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouseCode() != null) {
				
				oprot.WriteFieldBegin("warehouseCode");
				oprot.WriteString(structs.GetWarehouseCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPoStatus() != null) {
				
				oprot.WriteFieldBegin("poStatus");
				oprot.WriteString(structs.GetPoStatus());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateDateStart() != null) {
				
				oprot.WriteFieldBegin("createDateStart");
				oprot.WriteString(structs.GetCreateDateStart());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateDateEnd() != null) {
				
				oprot.WriteFieldBegin("createDateEnd");
				oprot.WriteString(structs.GetCreateDateEnd());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStartOnRacksTimeStart() != null) {
				
				oprot.WriteFieldBegin("startOnRacksTimeStart");
				oprot.WriteString(structs.GetStartOnRacksTimeStart());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStartOnRacksTimeEnd() != null) {
				
				oprot.WriteFieldBegin("startOnRacksTimeEnd");
				oprot.WriteString(structs.GetStartOnRacksTimeEnd());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SearchPoRequest bean){
			
			
		}
		
	}
	
}