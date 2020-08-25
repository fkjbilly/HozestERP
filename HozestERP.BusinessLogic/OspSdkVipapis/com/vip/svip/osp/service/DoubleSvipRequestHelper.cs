using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class DoubleSvipRequestHelper : TBeanSerializer<DoubleSvipRequest>
	{
		
		public static DoubleSvipRequestHelper OBJ = new DoubleSvipRequestHelper();
		
		public static DoubleSvipRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DoubleSvipRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("apiKey".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetApiKey(value);
					}
					
					
					
					
					
					if ("apiSign".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetApiSign(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("userMobile".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserMobile(value);
					}
					
					
					
					
					
					if ("userAccount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserAccount(value);
					}
					
					
					
					
					
					if ("ip".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIp(value);
					}
					
					
					
					
					
					if ("tencentUserId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTencentUserId(value);
					}
					
					
					
					
					
					if ("tencentUserType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTencentUserType(value);
					}
					
					
					
					
					
					if ("svipType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSvipType(value);
					}
					
					
					
					
					
					if ("tencentMemberType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTencentMemberType(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("productId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProductId(value);
					}
					
					
					
					
					
					if ("svipToken".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSvipToken(value);
					}
					
					
					
					
					
					if ("openId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOpenId(value);
					}
					
					
					
					
					
					if ("productName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProductName(value);
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
		
		
		public void Write(DoubleSvipRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetApiKey() != null) {
				
				oprot.WriteFieldBegin("apiKey");
				oprot.WriteString(structs.GetApiKey());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetApiSign() != null) {
				
				oprot.WriteFieldBegin("apiSign");
				oprot.WriteString(structs.GetApiSign());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserMobile() != null) {
				
				oprot.WriteFieldBegin("userMobile");
				oprot.WriteString(structs.GetUserMobile());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserAccount() != null) {
				
				oprot.WriteFieldBegin("userAccount");
				oprot.WriteString(structs.GetUserAccount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIp() != null) {
				
				oprot.WriteFieldBegin("ip");
				oprot.WriteString(structs.GetIp());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTencentUserId() != null) {
				
				oprot.WriteFieldBegin("tencentUserId");
				oprot.WriteString(structs.GetTencentUserId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTencentUserType() != null) {
				
				oprot.WriteFieldBegin("tencentUserType");
				oprot.WriteI32((int)structs.GetTencentUserType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSvipType() != null) {
				
				oprot.WriteFieldBegin("svipType");
				oprot.WriteI32((int)structs.GetSvipType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTencentMemberType() != null) {
				
				oprot.WriteFieldBegin("tencentMemberType");
				oprot.WriteI32((int)structs.GetTencentMemberType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProductId() != null) {
				
				oprot.WriteFieldBegin("productId");
				oprot.WriteString(structs.GetProductId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSvipToken() != null) {
				
				oprot.WriteFieldBegin("svipToken");
				oprot.WriteString(structs.GetSvipToken());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOpenId() != null) {
				
				oprot.WriteFieldBegin("openId");
				oprot.WriteString(structs.GetOpenId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProductName() != null) {
				
				oprot.WriteFieldBegin("productName");
				oprot.WriteString(structs.GetProductName());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DoubleSvipRequest bean){
			
			
		}
		
	}
	
}