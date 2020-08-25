using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class PoSkuHelper : TBeanSerializer<PoSku>
	{
		
		public static PoSkuHelper OBJ = new PoSkuHelper();
		
		public static PoSkuHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PoSku structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("itemCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetItemCode(value);
					}
					
					
					
					
					
					if ("applyQty".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetApplyQty(value);
					}
					
					
					
					
					
					if ("tagPrice".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTagPrice(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
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
		
		
		public void Write(PoSku structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetItemCode() != null) {
				
				oprot.WriteFieldBegin("itemCode");
				oprot.WriteString(structs.GetItemCode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("itemCode can not be null!");
			}
			
			
			if(structs.GetApplyQty() != null) {
				
				oprot.WriteFieldBegin("applyQty");
				oprot.WriteI32((int)structs.GetApplyQty()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("applyQty can not be null!");
			}
			
			
			if(structs.GetTagPrice() != null) {
				
				oprot.WriteFieldBegin("tagPrice");
				oprot.WriteString(structs.GetTagPrice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PoSku bean){
			
			
		}
		
	}
	
}