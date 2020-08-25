using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.vreceipt{
	
	
	
	public class RevinfoHelper : TBeanSerializer<Revinfo>
	{
		
		public static RevinfoHelper OBJ = new RevinfoHelper();
		
		public static RevinfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Revinfo structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("receipt_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceipt_no(value);
					}
					
					
					
					
					
					if ("receipt_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceipt_type(value);
					}
					
					
					
					
					
					if ("vendor_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_code(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("total_po_qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetTotal_po_qty(value);
					}
					
					
					
					
					
					if ("total_shipping_qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetTotal_shipping_qty(value);
					}
					
					
					
					
					
					if ("total_ship_cont_count".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetTotal_ship_cont_count(value);
					}
					
					
					
					
					
					if ("total_inb_qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetTotal_inb_qty(value);
					}
					
					
					
					
					
					if ("receive_complete_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetReceive_complete_time(value);
					}
					
					
					
					
					
					if ("details".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.vreceipt.RevinfoDetail> value;
						
						value = new List<com.vip.isv.vreceipt.RevinfoDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.vreceipt.RevinfoDetail elem0;
								
								elem0 = new com.vip.isv.vreceipt.RevinfoDetail();
								com.vip.isv.vreceipt.RevinfoDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDetails(value);
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
		
		
		public void Write(Revinfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransaction_id() != null) {
				
				oprot.WriteFieldBegin("transaction_id");
				oprot.WriteString(structs.GetTransaction_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transaction_id can not be null!");
			}
			
			
			if(structs.GetReceipt_no() != null) {
				
				oprot.WriteFieldBegin("receipt_no");
				oprot.WriteString(structs.GetReceipt_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("receipt_no can not be null!");
			}
			
			
			if(structs.GetReceipt_type() != null) {
				
				oprot.WriteFieldBegin("receipt_type");
				oprot.WriteString(structs.GetReceipt_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("receipt_type can not be null!");
			}
			
			
			if(structs.GetVendor_code() != null) {
				
				oprot.WriteFieldBegin("vendor_code");
				oprot.WriteString(structs.GetVendor_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_code can not be null!");
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetTotal_po_qty() != null) {
				
				oprot.WriteFieldBegin("total_po_qty");
				oprot.WriteDouble((double)structs.GetTotal_po_qty());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_po_qty can not be null!");
			}
			
			
			if(structs.GetTotal_shipping_qty() != null) {
				
				oprot.WriteFieldBegin("total_shipping_qty");
				oprot.WriteDouble((double)structs.GetTotal_shipping_qty());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_shipping_qty can not be null!");
			}
			
			
			if(structs.GetTotal_ship_cont_count() != null) {
				
				oprot.WriteFieldBegin("total_ship_cont_count");
				oprot.WriteDouble((double)structs.GetTotal_ship_cont_count());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_ship_cont_count can not be null!");
			}
			
			
			if(structs.GetTotal_inb_qty() != null) {
				
				oprot.WriteFieldBegin("total_inb_qty");
				oprot.WriteDouble((double)structs.GetTotal_inb_qty());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_inb_qty can not be null!");
			}
			
			
			if(structs.GetReceive_complete_time() != null) {
				
				oprot.WriteFieldBegin("receive_complete_time");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetReceive_complete_time())); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("receive_complete_time can not be null!");
			}
			
			
			if(structs.GetDetails() != null) {
				
				oprot.WriteFieldBegin("details");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.vreceipt.RevinfoDetail _item0 in structs.GetDetails()){
					
					
					com.vip.isv.vreceipt.RevinfoDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("details can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Revinfo bean){
			
			
		}
		
	}
	
}