using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.size{
	
	
	
	public class SizeTemplateDoHelper : TBeanSerializer<SizeTemplateDo>
	{
		
		public static SizeTemplateDoHelper OBJ = new SizeTemplateDoHelper();
		
		public static SizeTemplateDoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SizeTemplateDo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetId(value);
					}
					
					
					
					
					
					if ("code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCode(value);
					}
					
					
					
					
					
					if ("name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetName(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("size_detail_does".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.size.SizeDetailDo> value;
						
						value = new List<vipapis.size.SizeDetailDo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.size.SizeDetailDo elem1;
								
								elem1 = new vipapis.size.SizeDetailDo();
								vipapis.size.SizeDetailDoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSize_detail_does(value);
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
		
		
		public void Write(SizeTemplateDo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteI64((long)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCode() != null) {
				
				oprot.WriteFieldBegin("code");
				oprot.WriteString(structs.GetCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetName() != null) {
				
				oprot.WriteFieldBegin("name");
				oprot.WriteString(structs.GetName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteString(structs.GetStatus());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_detail_does() != null) {
				
				oprot.WriteFieldBegin("size_detail_does");
				
				oprot.WriteListBegin();
				foreach(vipapis.size.SizeDetailDo _item0 in structs.GetSize_detail_does()){
					
					
					vipapis.size.SizeDetailDoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SizeTemplateDo bean){
			
			
		}
		
	}
	
}