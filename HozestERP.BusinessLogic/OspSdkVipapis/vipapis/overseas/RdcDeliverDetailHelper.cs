using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class RdcDeliverDetailHelper : TBeanSerializer<RdcDeliverDetail>
	{
		
		public static RdcDeliverDetailHelper OBJ = new RdcDeliverDetailHelper();
		
		public static RdcDeliverDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(RdcDeliverDetail structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetId(value);
					}
					
					
					
					
					
					if ("source_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSource_id(value);
					}
					
					
					
					
					
					if ("brand_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_id(value);
					}
					
					
					
					
					
					if ("order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_sn(value);
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
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
					}
					
					
					
					
					
					if ("warehouse_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse_type(value);
					}
					
					
					
					
					
					if ("grade".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGrade(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("out_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOut_time(value);
					}
					
					
					
					
					
					if ("num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetNum(value);
					}
					
					
					
					
					
					if ("schedule_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSchedule_id(value);
					}
					
					
					
					
					
					if ("vendor_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_code(value);
					}
					
					
					
					
					
					if ("from_warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFrom_warehouse(value);
					}
					
					
					
					
					
					if ("to_warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTo_warehouse(value);
					}
					
					
					
					
					
					if ("shipment_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetShipment_no(value);
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
		
		
		public void Write(RdcDeliverDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteI64((long)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("id can not be null!");
			}
			
			
			if(structs.GetSource_id() != null) {
				
				oprot.WriteFieldBegin("source_id");
				oprot.WriteString(structs.GetSource_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("source_id can not be null!");
			}
			
			
			if(structs.GetBrand_id() != null) {
				
				oprot.WriteFieldBegin("brand_id");
				oprot.WriteString(structs.GetBrand_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("brand_id can not be null!");
			}
			
			
			if(structs.GetOrder_sn() != null) {
				
				oprot.WriteFieldBegin("order_sn");
				oprot.WriteString(structs.GetOrder_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_sn can not be null!");
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
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po_no can not be null!");
			}
			
			
			if(structs.GetWarehouse_type() != null) {
				
				oprot.WriteFieldBegin("warehouse_type");
				oprot.WriteString(structs.GetWarehouse_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse_type can not be null!");
			}
			
			
			if(structs.GetGrade() != null) {
				
				oprot.WriteFieldBegin("grade");
				oprot.WriteString(structs.GetGrade());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("grade can not be null!");
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteString(structs.GetStatus());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("status can not be null!");
			}
			
			
			if(structs.GetOut_time() != null) {
				
				oprot.WriteFieldBegin("out_time");
				oprot.WriteString(structs.GetOut_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("out_time can not be null!");
			}
			
			
			if(structs.GetNum() != null) {
				
				oprot.WriteFieldBegin("num");
				oprot.WriteI32((int)structs.GetNum()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("num can not be null!");
			}
			
			
			if(structs.GetSchedule_id() != null) {
				
				oprot.WriteFieldBegin("schedule_id");
				oprot.WriteString(structs.GetSchedule_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("schedule_id can not be null!");
			}
			
			
			if(structs.GetVendor_code() != null) {
				
				oprot.WriteFieldBegin("vendor_code");
				oprot.WriteString(structs.GetVendor_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_code can not be null!");
			}
			
			
			if(structs.GetFrom_warehouse() != null) {
				
				oprot.WriteFieldBegin("from_warehouse");
				oprot.WriteString(structs.GetFrom_warehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("from_warehouse can not be null!");
			}
			
			
			if(structs.GetTo_warehouse() != null) {
				
				oprot.WriteFieldBegin("to_warehouse");
				oprot.WriteString(structs.GetTo_warehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("to_warehouse can not be null!");
			}
			
			
			if(structs.GetShipment_no() != null) {
				
				oprot.WriteFieldBegin("shipment_no");
				oprot.WriteString(structs.GetShipment_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("shipment_no can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(RdcDeliverDetail bean){
			
			
		}
		
	}
	
}