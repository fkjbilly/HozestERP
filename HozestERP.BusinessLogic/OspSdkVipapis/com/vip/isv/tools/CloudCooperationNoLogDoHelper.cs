using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.tools{
	
	
	
	public class CloudCooperationNoLogDoHelper : TBeanSerializer<CloudCooperationNoLogDo>
	{
		
		public static CloudCooperationNoLogDoHelper OBJ = new CloudCooperationNoLogDoHelper();
		
		public static CloudCooperationNoLogDoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CloudCooperationNoLogDo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("vendorName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorName(value);
					}
					
					
					
					
					
					if ("cooperationNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCooperationNo(value);
					}
					
					
					
					
					
					if ("forbidden".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetForbidden(value);
					}
					
					
					
					
					
					if ("applyContent".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetApplyContent(value);
					}
					
					
					
					
					
					if ("effectMode".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetEffectMode(value);
					}
					
					
					
					
					
					if ("effectTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEffectTime(value);
					}
					
					
					
					
					
					if ("expireTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExpireTime(value);
					}
					
					
					
					
					
					if ("applyBy".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetApplyBy(value);
					}
					
					
					
					
					
					if ("applyTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetApplyTime(value);
					}
					
					
					
					
					
					if ("checkBy".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCheckBy(value);
					}
					
					
					
					
					
					if ("checkTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCheckTime(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetCreateTime(value);
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
		
		
		public void Write(CloudCooperationNoLogDo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorName() != null) {
				
				oprot.WriteFieldBegin("vendorName");
				oprot.WriteString(structs.GetVendorName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCooperationNo() != null) {
				
				oprot.WriteFieldBegin("cooperationNo");
				oprot.WriteI32((int)structs.GetCooperationNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetForbidden() != null) {
				
				oprot.WriteFieldBegin("forbidden");
				oprot.WriteI32((int)structs.GetForbidden()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetApplyContent() != null) {
				
				oprot.WriteFieldBegin("applyContent");
				oprot.WriteI32((int)structs.GetApplyContent()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEffectMode() != null) {
				
				oprot.WriteFieldBegin("effectMode");
				oprot.WriteI32((int)structs.GetEffectMode()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEffectTime() != null) {
				
				oprot.WriteFieldBegin("effectTime");
				oprot.WriteString(structs.GetEffectTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExpireTime() != null) {
				
				oprot.WriteFieldBegin("expireTime");
				oprot.WriteString(structs.GetExpireTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetApplyBy() != null) {
				
				oprot.WriteFieldBegin("applyBy");
				oprot.WriteString(structs.GetApplyBy());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetApplyTime() != null) {
				
				oprot.WriteFieldBegin("applyTime");
				oprot.WriteString(structs.GetApplyTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCheckBy() != null) {
				
				oprot.WriteFieldBegin("checkBy");
				oprot.WriteString(structs.GetCheckBy());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCheckTime() != null) {
				
				oprot.WriteFieldBegin("checkTime");
				oprot.WriteString(structs.GetCheckTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetCreateTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CloudCooperationNoLogDo bean){
			
			
		}
		
	}
	
}