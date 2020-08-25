using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.merchModel.service{
	
	
	
	public class SearchParamsHelper : TBeanSerializer<SearchParams>
	{
		
		public static SearchParamsHelper OBJ = new SearchParamsHelper();
		
		public static SearchParamsHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SearchParams structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("serviceType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetServiceType(value);
					}
					
					
					
					
					
					if ("mid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMid(value);
					}
					
					
					
					
					
					if ("category".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCategory(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("osn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOsn(value);
					}
					
					
					
					
					
					if ("brandName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrandName(value);
					}
					
					
					
					
					
					if ("title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTitle(value);
					}
					
					
					
					
					
					if ("_from".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.Set_from(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte value;
						value = iprot.ReadByte(); 
						
						structs.SetStatus(value);
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
		
		
		public void Write(SearchParams structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetServiceType() != null) {
				
				oprot.WriteFieldBegin("serviceType");
				oprot.WriteI32((int)structs.GetServiceType()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("serviceType can not be null!");
			}
			
			
			if(structs.GetMid() != null) {
				
				oprot.WriteFieldBegin("mid");
				oprot.WriteString(structs.GetMid());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCategory() != null) {
				
				oprot.WriteFieldBegin("category");
				oprot.WriteString(structs.GetCategory());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOsn() != null) {
				
				oprot.WriteFieldBegin("osn");
				oprot.WriteString(structs.GetOsn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrandName() != null) {
				
				oprot.WriteFieldBegin("brandName");
				oprot.WriteString(structs.GetBrandName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTitle() != null) {
				
				oprot.WriteFieldBegin("title");
				oprot.WriteString(structs.GetTitle());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.Get_from() != null) {
				
				oprot.WriteFieldBegin("_from");
				oprot.WriteString(structs.Get_from());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("_from can not be null!");
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteByte((byte)structs.GetStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("status can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SearchParams bean){
			
			
		}
		
	}
	
}