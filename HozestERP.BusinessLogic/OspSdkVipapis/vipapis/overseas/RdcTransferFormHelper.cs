using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class RdcTransferFormHelper : TBeanSerializer<RdcTransferForm>
	{
		
		public static RdcTransferFormHelper OBJ = new RdcTransferFormHelper();
		
		public static RdcTransferFormHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(RdcTransferForm structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("rdc_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetRdc_id(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("product_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProduct_name(value);
					}
					
					
					
					
					
					if ("schedule_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSchedule_id(value);
					}
					
					
					
					
					
					if ("num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetNum(value);
					}
					
					
					
					
					
					if ("to_warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTo_warehouse(value);
					}
					
					
					
					
					
					if ("from_warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFrom_warehouse(value);
					}
					
					
					
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_sn(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("priority".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPriority(value);
					}
					
					
					
					
					
					if ("data_source".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetData_source(value);
					}
					
					
					
					
					
					if ("order_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_type(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
					}
					
					
					
					
					
					if ("detail_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetDetail_id(value);
					}
					
					
					
					
					
					if ("sale_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSale_type(value);
					}
					
					
					
					
					
					if ("no_po".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetNo_po(value);
					}
					
					
					
					
					
					if ("po_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_type(value);
					}
					
					
					
					
					
					if ("vendor_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_code(value);
					}
					
					
					
					
					
					if ("create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreate_time(value);
					}
					
					
					
					
					
					if ("allocated_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAllocated_num(value);
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
		
		
		public void Write(RdcTransferForm structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetRdc_id() != null) {
				
				oprot.WriteFieldBegin("rdc_id");
				oprot.WriteI64((long)structs.GetRdc_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("rdc_id can not be null!");
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("barcode can not be null!");
			}
			
			
			if(structs.GetProduct_name() != null) {
				
				oprot.WriteFieldBegin("product_name");
				oprot.WriteString(structs.GetProduct_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("product_name can not be null!");
			}
			
			
			if(structs.GetSchedule_id() != null) {
				
				oprot.WriteFieldBegin("schedule_id");
				oprot.WriteString(structs.GetSchedule_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("schedule_id can not be null!");
			}
			
			
			if(structs.GetNum() != null) {
				
				oprot.WriteFieldBegin("num");
				oprot.WriteI32((int)structs.GetNum()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("num can not be null!");
			}
			
			
			if(structs.GetTo_warehouse() != null) {
				
				oprot.WriteFieldBegin("to_warehouse");
				oprot.WriteString(structs.GetTo_warehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("to_warehouse can not be null!");
			}
			
			
			if(structs.GetFrom_warehouse() != null) {
				
				oprot.WriteFieldBegin("from_warehouse");
				oprot.WriteString(structs.GetFrom_warehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("from_warehouse can not be null!");
			}
			
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteI64((long)structs.GetOrder_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_sn() != null) {
				
				oprot.WriteFieldBegin("order_sn");
				oprot.WriteString(structs.GetOrder_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_sn can not be null!");
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteString(structs.GetStatus());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("status can not be null!");
			}
			
			
			if(structs.GetPriority() != null) {
				
				oprot.WriteFieldBegin("priority");
				oprot.WriteString(structs.GetPriority());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("priority can not be null!");
			}
			
			
			if(structs.GetData_source() != null) {
				
				oprot.WriteFieldBegin("data_source");
				oprot.WriteString(structs.GetData_source());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("data_source can not be null!");
			}
			
			
			if(structs.GetOrder_type() != null) {
				
				oprot.WriteFieldBegin("order_type");
				oprot.WriteString(structs.GetOrder_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_type can not be null!");
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDetail_id() != null) {
				
				oprot.WriteFieldBegin("detail_id");
				oprot.WriteI32((int)structs.GetDetail_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSale_type() != null) {
				
				oprot.WriteFieldBegin("sale_type");
				oprot.WriteString(structs.GetSale_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNo_po() != null) {
				
				oprot.WriteFieldBegin("no_po");
				oprot.WriteString(structs.GetNo_po());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo_type() != null) {
				
				oprot.WriteFieldBegin("po_type");
				oprot.WriteString(structs.GetPo_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_code() != null) {
				
				oprot.WriteFieldBegin("vendor_code");
				oprot.WriteString(structs.GetVendor_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreate_time() != null) {
				
				oprot.WriteFieldBegin("create_time");
				oprot.WriteString(structs.GetCreate_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAllocated_num() != null) {
				
				oprot.WriteFieldBegin("allocated_num");
				oprot.WriteI32((int)structs.GetAllocated_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(RdcTransferForm bean){
			
			
		}
		
	}
	
}