using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class BuyLimitRequestParamHelper : TBeanSerializer<BuyLimitRequestParam>
	{
		
		public static BuyLimitRequestParamHelper OBJ = new BuyLimitRequestParamHelper();
		
		public static BuyLimitRequestParamHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BuyLimitRequestParam structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("productId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetProductId(value);
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
		
		
		public void Write(BuyLimitRequestParam structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetProductId() != null) {
				
				oprot.WriteFieldBegin("productId");
				oprot.WriteI64((long)structs.GetProductId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BuyLimitRequestParam bean){
			
			
		}
		
	}
	
}