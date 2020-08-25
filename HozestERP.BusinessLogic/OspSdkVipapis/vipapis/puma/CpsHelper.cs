using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.puma{
	
	
	
	public class CpsHelper : TBeanSerializer<Cps>
	{
		
		public static CpsHelper OBJ = new CpsHelper();
		
		public static CpsHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Cps structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("cps_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCps_url(value);
					}
					
					
					
					
					
					if ("share_title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetShare_title(value);
					}
					
					
					
					
					
					if ("share_desc".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetShare_desc(value);
					}
					
					
					
					
					
					if ("share_image_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetShare_image_url(value);
					}
					
					
					
					
					
					if ("wx_small_program_url".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWx_small_program_url(value);
					}
					
					
					
					
					
					if ("commission_value".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCommission_value(value);
					}
					
					
					
					
					
					if ("commission_value_newcust".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCommission_value_newcust(value);
					}
					
					
					
					
					
					if ("sign".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSign(value);
					}
					
					
					
					
					
					if ("exist_user".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetExist_user(value);
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
		
		
		public void Write(Cps structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCps_url() != null) {
				
				oprot.WriteFieldBegin("cps_url");
				oprot.WriteString(structs.GetCps_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetShare_title() != null) {
				
				oprot.WriteFieldBegin("share_title");
				oprot.WriteString(structs.GetShare_title());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetShare_desc() != null) {
				
				oprot.WriteFieldBegin("share_desc");
				oprot.WriteString(structs.GetShare_desc());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetShare_image_url() != null) {
				
				oprot.WriteFieldBegin("share_image_url");
				oprot.WriteString(structs.GetShare_image_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWx_small_program_url() != null) {
				
				oprot.WriteFieldBegin("wx_small_program_url");
				oprot.WriteString(structs.GetWx_small_program_url());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCommission_value() != null) {
				
				oprot.WriteFieldBegin("commission_value");
				oprot.WriteString(structs.GetCommission_value());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCommission_value_newcust() != null) {
				
				oprot.WriteFieldBegin("commission_value_newcust");
				oprot.WriteString(structs.GetCommission_value_newcust());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSign() != null) {
				
				oprot.WriteFieldBegin("sign");
				oprot.WriteString(structs.GetSign());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExist_user() != null) {
				
				oprot.WriteFieldBegin("exist_user");
				oprot.WriteBool((bool)structs.GetExist_user());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("exist_user can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Cps bean){
			
			
		}
		
	}
	
}