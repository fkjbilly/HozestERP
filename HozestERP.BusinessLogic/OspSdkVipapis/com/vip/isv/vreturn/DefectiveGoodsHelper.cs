using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.vreturn{
	
	
	
	public class DefectiveGoodsHelper : TBeanSerializer<DefectiveGoods>
	{
		
		public static DefectiveGoodsHelper OBJ = new DefectiveGoodsHelper();
		
		public static DefectiveGoodsHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DefectiveGoods structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transaction_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransaction_id(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
					}
					
					
					
					
					
					if ("receipt_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceipt_no(value);
					}
					
					
					
					
					
					if ("reference_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReference_no(value);
					}
					
					
					
					
					
					if ("edit_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEdit_type(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("item_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetItem_code(value);
					}
					
					
					
					
					
					if ("item_desc".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetItem_desc(value);
					}
					
					
					
					
					
					if ("reason_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReason_code(value);
					}
					
					
					
					
					
					if ("inventory_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInventory_type(value);
					}
					
					
					
					
					
					if ("purchase_case_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPurchase_case_no(value);
					}
					
					
					
					
					
					if ("qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetQty(value);
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
		
		
		public void Write(DefectiveGoods structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransaction_id() != null) {
				
				oprot.WriteFieldBegin("transaction_id");
				oprot.WriteString(structs.GetTransaction_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReceipt_no() != null) {
				
				oprot.WriteFieldBegin("receipt_no");
				oprot.WriteString(structs.GetReceipt_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReference_no() != null) {
				
				oprot.WriteFieldBegin("reference_no");
				oprot.WriteString(structs.GetReference_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEdit_type() != null) {
				
				oprot.WriteFieldBegin("edit_type");
				oprot.WriteString(structs.GetEdit_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetItem_code() != null) {
				
				oprot.WriteFieldBegin("item_code");
				oprot.WriteString(structs.GetItem_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetItem_desc() != null) {
				
				oprot.WriteFieldBegin("item_desc");
				oprot.WriteString(structs.GetItem_desc());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReason_code() != null) {
				
				oprot.WriteFieldBegin("reason_code");
				oprot.WriteString(structs.GetReason_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInventory_type() != null) {
				
				oprot.WriteFieldBegin("inventory_type");
				oprot.WriteString(structs.GetInventory_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPurchase_case_no() != null) {
				
				oprot.WriteFieldBegin("purchase_case_no");
				oprot.WriteString(structs.GetPurchase_case_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetQty() != null) {
				
				oprot.WriteFieldBegin("qty");
				oprot.WriteI32((int)structs.GetQty()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DefectiveGoods bean){
			
			
		}
		
	}
	
}