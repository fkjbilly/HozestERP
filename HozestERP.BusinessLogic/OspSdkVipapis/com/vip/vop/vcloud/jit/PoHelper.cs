using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.jit{
	
	
	
	public class PoHelper : TBeanSerializer<Po>
	{
		
		public static PoHelper OBJ = new PoHelper();
		
		public static PoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Po structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("poNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPoNo(value);
					}
					
					
					
					
					
					if ("scheduleId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetScheduleId(value);
					}
					
					
					
					
					
					if ("coMode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCoMode(value);
					}
					
					
					
					
					
					if ("brandName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrandName(value);
					}
					
					
					
					
					
					if ("scheduleName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetScheduleName(value);
					}
					
					
					
					
					
					if ("sellTimeStart".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetSellTimeStart(value);
					}
					
					
					
					
					
					if ("sellTimeEnd".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetSellTimeEnd(value);
					}
					
					
					
					
					
					if ("poStartTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetPoStartTime(value);
					}
					
					
					
					
					
					if ("quantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetQuantity(value);
					}
					
					
					
					
					
					if ("saleQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSaleQuantity(value);
					}
					
					
					
					
					
					if ("unpickQuantity".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetUnpickQuantity(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("partnerId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPartnerId(value);
					}
					
					
					
					
					
					if ("cooperationNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetCooperationNo(value);
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
		
		
		public void Write(Po structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendorId can not be null!");
			}
			
			
			if(structs.GetPoNo() != null) {
				
				oprot.WriteFieldBegin("poNo");
				oprot.WriteString(structs.GetPoNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetScheduleId() != null) {
				
				oprot.WriteFieldBegin("scheduleId");
				oprot.WriteI64((long)structs.GetScheduleId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCoMode() != null) {
				
				oprot.WriteFieldBegin("coMode");
				oprot.WriteString(structs.GetCoMode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrandName() != null) {
				
				oprot.WriteFieldBegin("brandName");
				oprot.WriteString(structs.GetBrandName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetScheduleName() != null) {
				
				oprot.WriteFieldBegin("scheduleName");
				oprot.WriteString(structs.GetScheduleName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSellTimeStart() != null) {
				
				oprot.WriteFieldBegin("sellTimeStart");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetSellTimeStart())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSellTimeEnd() != null) {
				
				oprot.WriteFieldBegin("sellTimeEnd");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetSellTimeEnd())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPoStartTime() != null) {
				
				oprot.WriteFieldBegin("poStartTime");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetPoStartTime())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetQuantity() != null) {
				
				oprot.WriteFieldBegin("quantity");
				oprot.WriteI32((int)structs.GetQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSaleQuantity() != null) {
				
				oprot.WriteFieldBegin("saleQuantity");
				oprot.WriteI32((int)structs.GetSaleQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnpickQuantity() != null) {
				
				oprot.WriteFieldBegin("unpickQuantity");
				oprot.WriteI32((int)structs.GetUnpickQuantity()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPartnerId() != null) {
				
				oprot.WriteFieldBegin("partnerId");
				oprot.WriteI64((long)structs.GetPartnerId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCooperationNo() != null) {
				
				oprot.WriteFieldBegin("cooperationNo");
				oprot.WriteI64((long)structs.GetCooperationNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Po bean){
			
			
		}
		
	}
	
}