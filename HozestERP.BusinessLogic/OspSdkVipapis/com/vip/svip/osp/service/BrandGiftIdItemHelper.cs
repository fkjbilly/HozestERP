using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class BrandGiftIdItemHelper : TBeanSerializer<BrandGiftIdItem>
	{
		
		public static BrandGiftIdItemHelper OBJ = new BrandGiftIdItemHelper();
		
		public static BrandGiftIdItemHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BrandGiftIdItem structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("brandId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrandId(value);
					}
					
					
					
					
					
					if ("sizeId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSizeId(value);
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
		
		
		public void Write(BrandGiftIdItem structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetBrandId() != null) {
				
				oprot.WriteFieldBegin("brandId");
				oprot.WriteString(structs.GetBrandId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizeId() != null) {
				
				oprot.WriteFieldBegin("sizeId");
				oprot.WriteString(structs.GetSizeId());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BrandGiftIdItem bean){
			
			
		}
		
	}
	
}