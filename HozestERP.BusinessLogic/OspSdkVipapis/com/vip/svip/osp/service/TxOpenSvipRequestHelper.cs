using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class TxOpenSvipRequestHelper : TBeanSerializer<TxOpenSvipRequest>
	{
		
		public static TxOpenSvipRequestHelper OBJ = new TxOpenSvipRequestHelper();
		
		public static TxOpenSvipRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(TxOpenSvipRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("userIp".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserIp(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("tencentMemberType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTencentMemberType(value);
					}
					
					
					
					
					
					if ("openId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOpenId(value);
					}
					
					
					
					
					
					if ("tencentUserId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTencentUserId(value);
					}
					
					
					
					
					
					if ("tencentUserType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTencentUserType(value);
					}
					
					
					
					
					
					if ("svipType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSvipType(value);
					}
					
					
					
					
					
					if ("dataSign".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDataSign(value);
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
		
		
		public void Write(TxOpenSvipRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserIp() != null) {
				
				oprot.WriteFieldBegin("userIp");
				oprot.WriteString(structs.GetUserIp());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTencentMemberType() != null) {
				
				oprot.WriteFieldBegin("tencentMemberType");
				oprot.WriteString(structs.GetTencentMemberType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOpenId() != null) {
				
				oprot.WriteFieldBegin("openId");
				oprot.WriteString(structs.GetOpenId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTencentUserId() != null) {
				
				oprot.WriteFieldBegin("tencentUserId");
				oprot.WriteString(structs.GetTencentUserId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTencentUserType() != null) {
				
				oprot.WriteFieldBegin("tencentUserType");
				oprot.WriteString(structs.GetTencentUserType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSvipType() != null) {
				
				oprot.WriteFieldBegin("svipType");
				oprot.WriteString(structs.GetSvipType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDataSign() != null) {
				
				oprot.WriteFieldBegin("dataSign");
				oprot.WriteString(structs.GetDataSign());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(TxOpenSvipRequest bean){
			
			
		}
		
	}
	
}