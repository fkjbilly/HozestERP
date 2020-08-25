using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.delivery{
	
	
	
	public class ReceiptInfoHelper : TBeanSerializer<ReceiptInfo>
	{
		
		public static ReceiptInfoHelper OBJ = new ReceiptInfoHelper();
		
		public static ReceiptInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ReceiptInfo structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("transactionId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransactionId(value);
					}
					
					
					
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("receiptNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceiptNo(value);
					}
					
					
					
					
					
					if ("totalShippingQty".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetTotalShippingQty(value);
					}
					
					
					
					
					
					if ("totalShipContCount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetTotalShipContCount(value);
					}
					
					
					
					
					
					if ("totalInbQty".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetTotalInbQty(value);
					}
					
					
					
					
					
					if ("receiveCompleteTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetReceiveCompleteTime(value);
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
		
		
		public void Write(ReceiptInfo structs, Protocol oprot){
			
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
			
			
			if(structs.GetTransactionId() != null) {
				
				oprot.WriteFieldBegin("transactionId");
				oprot.WriteString(structs.GetTransactionId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReceiptNo() != null) {
				
				oprot.WriteFieldBegin("receiptNo");
				oprot.WriteString(structs.GetReceiptNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalShippingQty() != null) {
				
				oprot.WriteFieldBegin("totalShippingQty");
				oprot.WriteDouble((double)structs.GetTotalShippingQty());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalShipContCount() != null) {
				
				oprot.WriteFieldBegin("totalShipContCount");
				oprot.WriteDouble((double)structs.GetTotalShipContCount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalInbQty() != null) {
				
				oprot.WriteFieldBegin("totalInbQty");
				oprot.WriteDouble((double)structs.GetTotalInbQty());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReceiveCompleteTime() != null) {
				
				oprot.WriteFieldBegin("receiveCompleteTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetReceiveCompleteTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ReceiptInfo bean){
			
			
		}
		
	}
	
}