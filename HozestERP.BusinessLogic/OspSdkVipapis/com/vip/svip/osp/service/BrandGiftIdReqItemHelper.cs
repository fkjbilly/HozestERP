using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class BrandGiftIdReqItemHelper : TBeanSerializer<BrandGiftIdReqItem>
	{
		
		public static BrandGiftIdReqItemHelper OBJ = new BrandGiftIdReqItemHelper();
		
		public static BrandGiftIdReqItemHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BrandGiftIdReqItem structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("brandId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetBrandId(value);
					}
					
					
					
					
					
					if ("sizeId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
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
		
		
		public void Write(BrandGiftIdReqItem structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetBrandId() != null) {
				
				oprot.WriteFieldBegin("brandId");
				oprot.WriteI64((long)structs.GetBrandId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("brandId can not be null!");
			}
			
			
			if(structs.GetSizeId() != null) {
				
				oprot.WriteFieldBegin("sizeId");
				oprot.WriteI64((long)structs.GetSizeId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sizeId can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BrandGiftIdReqItem bean){
			
			
		}
		
	}
	
}