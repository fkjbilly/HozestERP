using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.merchModel.service{
	
	
	
	public class Jd3dModelDataHelper : TBeanSerializer<Jd3dModelData>
	{
		
		public static Jd3dModelDataHelper OBJ = new Jd3dModelDataHelper();
		
		public static Jd3dModelDataHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Jd3dModelData structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
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
					
					
					
					
					
					if ("jd3dModelInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.arplatform.merchModel.service.Jd3dModelInfo value;
						
						value = new com.vip.arplatform.merchModel.service.Jd3dModelInfo();
						com.vip.arplatform.merchModel.service.Jd3dModelInfoHelper.getInstance().Read(value, iprot);
						
						structs.SetJd3dModelInfo(value);
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
		
		
		public void Write(Jd3dModelData structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetMid() != null) {
				
				oprot.WriteFieldBegin("mid");
				oprot.WriteString(structs.GetMid());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("mid can not be null!");
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
			
			else{
				throw new ArgumentException("barcode can not be null!");
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
			
			
			if(structs.GetJd3dModelInfo() != null) {
				
				oprot.WriteFieldBegin("jd3dModelInfo");
				
				com.vip.arplatform.merchModel.service.Jd3dModelInfoHelper.getInstance().Write(structs.GetJd3dModelInfo(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("jd3dModelInfo can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Jd3dModelData bean){
			
			
		}
		
	}
	
}