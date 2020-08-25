using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.merchModel.service{
	
	
	
	public class BindInfoModelHelper : TBeanSerializer<BindInfoModel>
	{
		
		public static BindInfoModelHelper OBJ = new BindInfoModelHelper();
		
		public static BindInfoModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BindInfoModel structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("sku".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetSku(value);
					}
					
					
					
					
					
					if ("spu".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetSpu(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("materialId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetMaterialId(value);
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
		
		
		public void Write(BindInfoModel structs, Protocol oprot){
			
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
			
			
			if(structs.GetSku() != null) {
				
				oprot.WriteFieldBegin("sku");
				oprot.WriteI64((long)structs.GetSku()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sku can not be null!");
			}
			
			
			if(structs.GetSpu() != null) {
				
				oprot.WriteFieldBegin("spu");
				oprot.WriteI64((long)structs.GetSpu()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("spu can not be null!");
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMaterialId() != null) {
				
				oprot.WriteFieldBegin("materialId");
				oprot.WriteI64((long)structs.GetMaterialId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("materialId can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BindInfoModel bean){
			
			
		}
		
	}
	
}