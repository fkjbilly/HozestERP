using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.merchModel.service{
	
	
	
	public class MaterialModelHelper : TBeanSerializer<MaterialModel>
	{
		
		public static MaterialModelHelper OBJ = new MaterialModelHelper();
		
		public static MaterialModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(MaterialModel structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("isDeleted".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetIsDeleted(value);
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
					
					
					
					
					
					if ("color".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetColor(value);
					}
					
					
					
					
					
					if ("size".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSize(value);
					}
					
					
					
					
					
					if ("_from".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.Set_from(value);
					}
					
					
					
					
					
					if ("jsonModelInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetJsonModelInfo(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("counter".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetCounter(value);
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
		
		
		public void Write(MaterialModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteI64((long)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsDeleted() != null) {
				
				oprot.WriteFieldBegin("isDeleted");
				oprot.WriteByte((byte)structs.GetIsDeleted()); 
				
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
			
			
			if(structs.GetColor() != null) {
				
				oprot.WriteFieldBegin("color");
				oprot.WriteString(structs.GetColor());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSize() != null) {
				
				oprot.WriteFieldBegin("size");
				oprot.WriteI32((int)structs.GetSize()); 
				
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
			
			
			if(structs.GetJsonModelInfo() != null) {
				
				oprot.WriteFieldBegin("jsonModelInfo");
				oprot.WriteString(structs.GetJsonModelInfo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("jsonModelInfo can not be null!");
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteByte((byte)structs.GetStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCounter() != null) {
				
				oprot.WriteFieldBegin("counter");
				oprot.WriteByte((byte)structs.GetCounter()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(MaterialModel bean){
			
			
		}
		
	}
	
}