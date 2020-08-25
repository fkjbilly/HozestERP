using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class PurchaseOrderBatchInfoHelper : BeanSerializer<PurchaseOrderBatchInfo>
	{
		
		public static PurchaseOrderBatchInfoHelper OBJ = new PurchaseOrderBatchInfoHelper();
		
		public static PurchaseOrderBatchInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PurchaseOrderBatchInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("batch_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetBatch_id(value);
					}
					
					
					
					
					
					if ("batch_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatch_no(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
					}
					
					
					
					
					
					if ("trade_model".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTrade_model(value);
					}
					
					
					
					
					
					if ("delivery_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDelivery_time(value);
					}
					
					
					
					
					
					if ("estimate_arrive_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEstimate_arrive_time(value);
					}
					
					
					
					
					
					if ("po_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_type(value);
					}
					
					
					
					
					
					if ("warehouse_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse_type(value);
					}
					
					
					
					
					
					if ("vendor_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_code(value);
					}
					
					
					
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("vendor_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_name(value);
					}
					
					
					
					
					
					if ("product_List".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.overseas.BatchProduct> value;
						
						value = new List<vipapis.overseas.BatchProduct>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.overseas.BatchProduct elem0;
								
								elem0 = new vipapis.overseas.BatchProduct();
								vipapis.overseas.BatchProductHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetProduct_List(value);
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
		
		
		public void Write(PurchaseOrderBatchInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetBatch_id() != null) {
				
				oprot.WriteFieldBegin("batch_id");
				oprot.WriteI32((int)structs.GetBatch_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("batch_id can not be null!");
			}
			
			
			if(structs.GetBatch_no() != null) {
				
				oprot.WriteFieldBegin("batch_no");
				oprot.WriteString(structs.GetBatch_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("batch_no can not be null!");
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po_no can not be null!");
			}
			
			
			if(structs.GetTrade_model() != null) {
				
				oprot.WriteFieldBegin("trade_model");
				oprot.WriteString(structs.GetTrade_model());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("trade_model can not be null!");
			}
			
			
			if(structs.GetDelivery_time() != null) {
				
				oprot.WriteFieldBegin("delivery_time");
				oprot.WriteString(structs.GetDelivery_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("delivery_time can not be null!");
			}
			
			
			if(structs.GetEstimate_arrive_time() != null) {
				
				oprot.WriteFieldBegin("estimate_arrive_time");
				oprot.WriteString(structs.GetEstimate_arrive_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("estimate_arrive_time can not be null!");
			}
			
			
			if(structs.GetPo_type() != null) {
				
				oprot.WriteFieldBegin("po_type");
				oprot.WriteString(structs.GetPo_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po_type can not be null!");
			}
			
			
			if(structs.GetWarehouse_type() != null) {
				
				oprot.WriteFieldBegin("warehouse_type");
				oprot.WriteString(structs.GetWarehouse_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse_type can not be null!");
			}
			
			
			if(structs.GetVendor_code() != null) {
				
				oprot.WriteFieldBegin("vendor_code");
				oprot.WriteString(structs.GetVendor_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_code can not be null!");
			}
			
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetVendor_name() != null) {
				
				oprot.WriteFieldBegin("vendor_name");
				oprot.WriteString(structs.GetVendor_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_name can not be null!");
			}
			
			
			if(structs.GetProduct_List() != null) {
				
				oprot.WriteFieldBegin("product_List");
				
				oprot.WriteListBegin();
				foreach(vipapis.overseas.BatchProduct _item0 in structs.GetProduct_List()){
					
					
					vipapis.overseas.BatchProductHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("product_List can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PurchaseOrderBatchInfo bean){
			
			
		}
		
	}
	
}