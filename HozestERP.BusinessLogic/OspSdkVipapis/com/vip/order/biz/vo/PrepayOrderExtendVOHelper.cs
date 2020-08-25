using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.vo{
	
	
	
	public class PrepayOrderExtendVOHelper : TBeanSerializer<PrepayOrderExtendVO>
	{
		
		public static PrepayOrderExtendVOHelper OBJ = new PrepayOrderExtendVOHelper();
		
		public static PrepayOrderExtendVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PrepayOrderExtendVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("parentSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetParentSn(value);
					}
					
					
					
					
					
					if ("orderCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderCode(value);
					}
					
					
					
					
					
					if ("periods".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPeriods(value);
					}
					
					
					
					
					
					if ("isFirst".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsFirst(value);
					}
					
					
					
					
					
					if ("isLast".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsLast(value);
					}
					
					
					
					
					
					if ("isLock".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsLock(value);
					}
					
					
					
					
					
					if ("payId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPayId(value);
					}
					
					
					
					
					
					if ("totalMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTotalMoney(value);
					}
					
					
					
					
					
					if ("startPayTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetStartPayTime(value);
					}
					
					
					
					
					
					if ("endPayTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetEndPayTime(value);
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
		
		
		public void Write(PrepayOrderExtendVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetParentSn() != null) {
				
				oprot.WriteFieldBegin("parentSn");
				oprot.WriteString(structs.GetParentSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCode() != null) {
				
				oprot.WriteFieldBegin("orderCode");
				oprot.WriteString(structs.GetOrderCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPeriods() != null) {
				
				oprot.WriteFieldBegin("periods");
				oprot.WriteI32((int)structs.GetPeriods()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsFirst() != null) {
				
				oprot.WriteFieldBegin("isFirst");
				oprot.WriteI32((int)structs.GetIsFirst()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsLast() != null) {
				
				oprot.WriteFieldBegin("isLast");
				oprot.WriteI32((int)structs.GetIsLast()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsLock() != null) {
				
				oprot.WriteFieldBegin("isLock");
				oprot.WriteI32((int)structs.GetIsLock()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayId() != null) {
				
				oprot.WriteFieldBegin("payId");
				oprot.WriteI64((long)structs.GetPayId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalMoney() != null) {
				
				oprot.WriteFieldBegin("totalMoney");
				oprot.WriteString(structs.GetTotalMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStartPayTime() != null) {
				
				oprot.WriteFieldBegin("startPayTime");
				oprot.WriteI64((long)structs.GetStartPayTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEndPayTime() != null) {
				
				oprot.WriteFieldBegin("endPayTime");
				oprot.WriteI64((long)structs.GetEndPayTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PrepayOrderExtendVO bean){
			
			
		}
		
	}
	
}