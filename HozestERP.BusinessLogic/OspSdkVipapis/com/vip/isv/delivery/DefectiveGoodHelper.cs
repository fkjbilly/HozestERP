using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.delivery{
	
	
	
	public class DefectiveGoodHelper : TBeanSerializer<DefectiveGood>
	{
		
		public static DefectiveGoodHelper OBJ = new DefectiveGoodHelper();
		
		public static DefectiveGoodHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DefectiveGood structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("poNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPoNo(value);
					}
					
					
					
					
					
					if ("receiptNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReceiptNo(value);
					}
					
					
					
					
					
					if ("purchaseCaseNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPurchaseCaseNo(value);
					}
					
					
					
					
					
					if ("itemCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetItemCode(value);
					}
					
					
					
					
					
					if ("qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetQty(value);
					}
					
					
					
					
					
					if ("reasonCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReasonCode(value);
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
		
		
		public void Write(DefectiveGood structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPoNo() != null) {
				
				oprot.WriteFieldBegin("poNo");
				oprot.WriteString(structs.GetPoNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReceiptNo() != null) {
				
				oprot.WriteFieldBegin("receiptNo");
				oprot.WriteString(structs.GetReceiptNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPurchaseCaseNo() != null) {
				
				oprot.WriteFieldBegin("purchaseCaseNo");
				oprot.WriteString(structs.GetPurchaseCaseNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetItemCode() != null) {
				
				oprot.WriteFieldBegin("itemCode");
				oprot.WriteString(structs.GetItemCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetQty() != null) {
				
				oprot.WriteFieldBegin("qty");
				oprot.WriteI32((int)structs.GetQty()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("qty can not be null!");
			}
			
			
			if(structs.GetReasonCode() != null) {
				
				oprot.WriteFieldBegin("reasonCode");
				oprot.WriteString(structs.GetReasonCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DefectiveGood bean){
			
			
		}
		
	}
	
}