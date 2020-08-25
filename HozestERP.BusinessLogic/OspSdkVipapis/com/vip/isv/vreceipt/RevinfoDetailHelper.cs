using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.vreceipt{
	
	
	
	public class RevinfoDetailHelper : TBeanSerializer<RevinfoDetail>
	{
		
		public static RevinfoDetailHelper OBJ = new RevinfoDetailHelper();
		
		public static RevinfoDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(RevinfoDetail structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transaction_detail_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransaction_detail_id(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("sku".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSku(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
					}
					
					
					
					
					
					if ("purchase_case_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPurchase_case_no(value);
					}
					
					
					
					
					
					if ("vis_receipt_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVis_receipt_no(value);
					}
					
					
					
					
					
					if ("po_qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetPo_qty(value);
					}
					
					
					
					
					
					if ("shipping_qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetShipping_qty(value);
					}
					
					
					
					
					
					if ("stock_qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetStock_qty(value);
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
		
		
		public void Write(RevinfoDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransaction_detail_id() != null) {
				
				oprot.WriteFieldBegin("transaction_detail_id");
				oprot.WriteString(structs.GetTransaction_detail_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transaction_detail_id can not be null!");
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetSku() != null) {
				
				oprot.WriteFieldBegin("sku");
				oprot.WriteString(structs.GetSku());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sku can not be null!");
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po_no can not be null!");
			}
			
			
			if(structs.GetPurchase_case_no() != null) {
				
				oprot.WriteFieldBegin("purchase_case_no");
				oprot.WriteString(structs.GetPurchase_case_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("purchase_case_no can not be null!");
			}
			
			
			if(structs.GetVis_receipt_no() != null) {
				
				oprot.WriteFieldBegin("vis_receipt_no");
				oprot.WriteString(structs.GetVis_receipt_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vis_receipt_no can not be null!");
			}
			
			
			if(structs.GetPo_qty() != null) {
				
				oprot.WriteFieldBegin("po_qty");
				oprot.WriteDouble((double)structs.GetPo_qty());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po_qty can not be null!");
			}
			
			
			if(structs.GetShipping_qty() != null) {
				
				oprot.WriteFieldBegin("shipping_qty");
				oprot.WriteDouble((double)structs.GetShipping_qty());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("shipping_qty can not be null!");
			}
			
			
			if(structs.GetStock_qty() != null) {
				
				oprot.WriteFieldBegin("stock_qty");
				oprot.WriteDouble((double)structs.GetStock_qty());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("stock_qty can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(RevinfoDetail bean){
			
			
		}
		
	}
	
}