using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.fcs.vei.service{
	
	
	
	public class CanInvoicingReqModel3Helper : TBeanSerializer<CanInvoicingReqModel3>
	{
		
		public static CanInvoicingReqModel3Helper OBJ = new CanInvoicingReqModel3Helper();
		
		public static CanInvoicingReqModel3Helper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CanInvoicingReqModel3 structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("saleType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSaleType(value);
					}
					
					
					
					
					
					if ("province".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProvince(value);
					}
					
					
					
					
					
					if ("city".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity(value);
					}
					
					
					
					
					
					if ("sizeIds".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSizeIds(value);
					}
					
					
					
					
					
					if ("giftSizeIds".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGiftSizeIds(value);
					}
					
					
					
					
					
					if ("sourceSystem".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSourceSystem(value);
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
		
		
		public void Write(CanInvoicingReqModel3 structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSaleType() != null) {
				
				oprot.WriteFieldBegin("saleType");
				oprot.WriteString(structs.GetSaleType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProvince() != null) {
				
				oprot.WriteFieldBegin("province");
				oprot.WriteString(structs.GetProvince());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCity() != null) {
				
				oprot.WriteFieldBegin("city");
				oprot.WriteString(structs.GetCity());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizeIds() != null) {
				
				oprot.WriteFieldBegin("sizeIds");
				oprot.WriteString(structs.GetSizeIds());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGiftSizeIds() != null) {
				
				oprot.WriteFieldBegin("giftSizeIds");
				oprot.WriteString(structs.GetGiftSizeIds());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSourceSystem() != null) {
				
				oprot.WriteFieldBegin("sourceSystem");
				oprot.WriteI32((int)structs.GetSourceSystem()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CanInvoicingReqModel3 bean){
			
			
		}
		
	}
	
}