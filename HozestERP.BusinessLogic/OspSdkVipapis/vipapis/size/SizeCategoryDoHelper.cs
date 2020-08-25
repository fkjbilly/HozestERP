using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.size{
	
	
	
	public class SizeCategoryDoHelper : TBeanSerializer<SizeCategoryDo>
	{
		
		public static SizeCategoryDoHelper OBJ = new SizeCategoryDoHelper();
		
		public static SizeCategoryDoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SizeCategoryDo structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("category_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCategory_id(value);
					}
					
					
					
					
					
					if ("size_pic".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSize_pic(value);
					}
					
					
					
					
					
					if ("size_template_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSize_template_id(value);
					}
					
					
					
					
					
					if ("size_detail_does".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.size.SizeDetailDo> value;
						
						value = new List<vipapis.size.SizeDetailDo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.size.SizeDetailDo elem0;
								
								elem0 = new vipapis.size.SizeDetailDo();
								vipapis.size.SizeDetailDoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSize_detail_does(value);
					}
					
					
					
					
					
					if ("size_template_do".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.size.SizeTemplateDo value;
						
						value = new vipapis.size.SizeTemplateDo();
						vipapis.size.SizeTemplateDoHelper.getInstance().Read(value, iprot);
						
						structs.SetSize_template_do(value);
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
		
		
		public void Write(SizeCategoryDo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteI64((long)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCategory_id() != null) {
				
				oprot.WriteFieldBegin("category_id");
				oprot.WriteI32((int)structs.GetCategory_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_pic() != null) {
				
				oprot.WriteFieldBegin("size_pic");
				oprot.WriteString(structs.GetSize_pic());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_template_id() != null) {
				
				oprot.WriteFieldBegin("size_template_id");
				oprot.WriteI64((long)structs.GetSize_template_id()); 
				
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
			
			
			if(structs.GetSize_template_do() != null) {
				
				oprot.WriteFieldBegin("size_template_do");
				
				vipapis.size.SizeTemplateDoHelper.getInstance().Write(structs.GetSize_template_do(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SizeCategoryDo bean){
			
			
		}
		
	}
	
}