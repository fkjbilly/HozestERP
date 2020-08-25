using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.category{
	
	
	
	public class VendorCategoryMappingDoHelper : TBeanSerializer<VendorCategoryMappingDo>
	{
		
		public static VendorCategoryMappingDoHelper OBJ = new VendorCategoryMappingDoHelper();
		
		public static VendorCategoryMappingDoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VendorCategoryMappingDo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetId(value);
					}
					
					
					
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("vendorCategoryTreeId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorCategoryTreeId(value);
					}
					
					
					
					
					
					if ("vendorCategoryTreeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorCategoryTreeName(value);
					}
					
					
					
					
					
					if ("vendorCategoryPath".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorCategoryPath(value);
					}
					
					
					
					
					
					if ("vendorCategoryName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorCategoryName(value);
					}
					
					
					
					
					
					if ("vendorCategoryId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendorCategoryId(value);
					}
					
					
					
					
					
					if ("vipCategoryPath".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipCategoryPath(value);
					}
					
					
					
					
					
					if ("vipCategoryPathId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipCategoryPathId(value);
					}
					
					
					
					
					
					if ("vipCategoryName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipCategoryName(value);
					}
					
					
					
					
					
					if ("vipCategoryId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVipCategoryId(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("similarPoint".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetSimilarPoint(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetCreateTime(value);
					}
					
					
					
					
					
					if ("updateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetUpdateTime(value);
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
		
		
		public void Write(VendorCategoryMappingDo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteI32((int)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorCategoryTreeId() != null) {
				
				oprot.WriteFieldBegin("vendorCategoryTreeId");
				oprot.WriteI32((int)structs.GetVendorCategoryTreeId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorCategoryTreeName() != null) {
				
				oprot.WriteFieldBegin("vendorCategoryTreeName");
				oprot.WriteString(structs.GetVendorCategoryTreeName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorCategoryPath() != null) {
				
				oprot.WriteFieldBegin("vendorCategoryPath");
				oprot.WriteString(structs.GetVendorCategoryPath());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorCategoryName() != null) {
				
				oprot.WriteFieldBegin("vendorCategoryName");
				oprot.WriteString(structs.GetVendorCategoryName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorCategoryId() != null) {
				
				oprot.WriteFieldBegin("vendorCategoryId");
				oprot.WriteString(structs.GetVendorCategoryId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipCategoryPath() != null) {
				
				oprot.WriteFieldBegin("vipCategoryPath");
				oprot.WriteString(structs.GetVipCategoryPath());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipCategoryPathId() != null) {
				
				oprot.WriteFieldBegin("vipCategoryPathId");
				oprot.WriteString(structs.GetVipCategoryPathId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipCategoryName() != null) {
				
				oprot.WriteFieldBegin("vipCategoryName");
				oprot.WriteString(structs.GetVipCategoryName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipCategoryId() != null) {
				
				oprot.WriteFieldBegin("vipCategoryId");
				oprot.WriteI32((int)structs.GetVipCategoryId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteI32((int)structs.GetStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSimilarPoint() != null) {
				
				oprot.WriteFieldBegin("similarPoint");
				oprot.WriteDouble((double)structs.GetSimilarPoint());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetCreateTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdateTime() != null) {
				
				oprot.WriteFieldBegin("updateTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetUpdateTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VendorCategoryMappingDo bean){
			
			
		}
		
	}
	
}