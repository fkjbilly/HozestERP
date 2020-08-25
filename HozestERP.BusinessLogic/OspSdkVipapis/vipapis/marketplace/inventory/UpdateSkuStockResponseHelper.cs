using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.inventory{
	
	
	
	public class UpdateSkuStockResponseHelper : TBeanSerializer<UpdateSkuStockResponse>
	{
		
		public static UpdateSkuStockResponseHelper OBJ = new UpdateSkuStockResponseHelper();
		
		public static UpdateSkuStockResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UpdateSkuStockResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("success".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetSuccess(value);
					}
					
					
					
					
					
					if ("over_sell_quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetOver_sell_quantity(value);
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
		
		
		public void Write(UpdateSkuStockResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSuccess() != null) {
				
				oprot.WriteFieldBegin("success");
				oprot.WriteBool((bool)structs.GetSuccess());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOver_sell_quantity() != null) {
				
				oprot.WriteFieldBegin("over_sell_quantity");
				oprot.WriteI32((int)structs.GetOver_sell_quantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("over_sell_quantity can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(UpdateSkuStockResponse bean){
			
			
		}
		
	}
	
}