using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vsizetable{
	
	
	
	public class AddSizeTableTemplateRequestHelper : TBeanSerializer<AddSizeTableTemplateRequest>
	{
		
		public static AddSizeTableTemplateRequestHelper OBJ = new AddSizeTableTemplateRequestHelper();
		
		public static AddSizeTableTemplateRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AddSizeTableTemplateRequest structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("type".Equals(schemeField.Trim())){
						
						needSkip = false;
						short value;
						value = iprot.ReadI16(); 
						
						structs.SetType(value);
					}
					
					
					
					
					
					if ("template_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTemplate_name(value);
					}
					
					
					
					
					
					if ("tips".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTips(value);
					}
					
					
					
					
					
					if ("template_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTemplate_type(value);
					}
					
					
					
					
					
					if ("html".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetHtml(value);
					}
					
					
					
					
					
					if ("size_detail_summaries".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.vsizetable.SizeDetailSummary> value;
						
						value = new List<vipapis.vsizetable.SizeDetailSummary>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.vsizetable.SizeDetailSummary elem0;
								
								elem0 = new vipapis.vsizetable.SizeDetailSummary();
								vipapis.vsizetable.SizeDetailSummaryHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSize_detail_summaries(value);
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
		
		
		public void Write(AddSizeTableTemplateRequest structs, Protocol oprot){
			
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
			
			
			if(structs.GetType() != null) {
				
				oprot.WriteFieldBegin("type");
				oprot.WriteI16((short)structs.GetType()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("type can not be null!");
			}
			
			
			if(structs.GetTemplate_name() != null) {
				
				oprot.WriteFieldBegin("template_name");
				oprot.WriteString(structs.GetTemplate_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("template_name can not be null!");
			}
			
			
			if(structs.GetTips() != null) {
				
				oprot.WriteFieldBegin("tips");
				oprot.WriteString(structs.GetTips());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTemplate_type() != null) {
				
				oprot.WriteFieldBegin("template_type");
				oprot.WriteI32((int)structs.GetTemplate_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("template_type can not be null!");
			}
			
			
			if(structs.GetHtml() != null) {
				
				oprot.WriteFieldBegin("html");
				oprot.WriteString(structs.GetHtml());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize_detail_summaries() != null) {
				
				oprot.WriteFieldBegin("size_detail_summaries");
				
				oprot.WriteListBegin();
				foreach(vipapis.vsizetable.SizeDetailSummary _item0 in structs.GetSize_detail_summaries()){
					
					
					vipapis.vsizetable.SizeDetailSummaryHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AddSizeTableTemplateRequest bean){
			
			
		}
		
	}
	
}