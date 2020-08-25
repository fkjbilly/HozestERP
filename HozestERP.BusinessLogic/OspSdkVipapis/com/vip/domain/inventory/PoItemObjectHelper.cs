using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class PoItemObjectHelper : TBeanSerializer<PoItemObject>
	{
		
		public static PoItemObjectHelper OBJ = new PoItemObjectHelper();
		
		public static PoItemObjectHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PoItemObject structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("warehouseCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouseCode(value);
					}
					
					
					
					
					
					if ("applyQty".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetApplyQty(value);
					}
					
					
					
					
					
					if ("tagPrice".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetTagPrice(value);
					}
					
					
					
					
					
					if ("iqcQty".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetIqcQty(value);
					}
					
					
					
					
					
					if ("shelvesQty".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetShelvesQty(value);
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
		
		
		public void Write(PoItemObject structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetItemCode() != null) {
				
				oprot.WriteFieldBegin("itemCode");
				oprot.WriteString(structs.GetItemCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouseCode() != null) {
				
				oprot.WriteFieldBegin("warehouseCode");
				oprot.WriteString(structs.GetWarehouseCode());
				
				oprot.WriteFieldEnd();
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
				oprot.WriteDouble((double)structs.GetTagPrice());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("tagPrice can not be null!");
			}
			
			
			if(structs.GetIqcQty() != null) {
				
				oprot.WriteFieldBegin("iqcQty");
				oprot.WriteI32((int)structs.GetIqcQty()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("iqcQty can not be null!");
			}
			
			
			if(structs.GetShelvesQty() != null) {
				
				oprot.WriteFieldBegin("shelvesQty");
				oprot.WriteI32((int)structs.GetShelvesQty()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("shelvesQty can not be null!");
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PoItemObject bean){
			
			
		}
		
	}
	
}