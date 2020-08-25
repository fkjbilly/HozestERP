using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.inventory{
	
	
	
	public class GetMpSkuStockRequestHelper : TBeanSerializer<GetMpSkuStockRequest>
	{
		
		public static GetMpSkuStockRequestHelper OBJ = new GetMpSkuStockRequestHelper();
		
		public static GetMpSkuStockRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetMpSkuStockRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sku_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSku_id(value);
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
		
		
		public void Write(GetMpSkuStockRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSku_id() != null) {
				
				oprot.WriteFieldBegin("sku_id");
				oprot.WriteString(structs.GetSku_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sku_id can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetMpSkuStockRequest bean){
			
			
		}
		
	}
	
}