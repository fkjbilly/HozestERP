using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class ReturnMoneyVOHelper : TBeanSerializer<ReturnMoneyVO>
	{
		
		public static ReturnMoneyVOHelper OBJ = new ReturnMoneyVOHelper();
		
		public static ReturnMoneyVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ReturnMoneyVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("goodsMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoodsMoney(value);
					}
					
					
					
					
					
					if ("discount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDiscount(value);
					}
					
					
					
					
					
					if ("transportFee".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportFee(value);
					}
					
					
					
					
					
					if ("returnFee".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnFee(value);
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
		
		
		public void Write(ReturnMoneyVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetGoodsMoney() != null) {
				
				oprot.WriteFieldBegin("goodsMoney");
				oprot.WriteString(structs.GetGoodsMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDiscount() != null) {
				
				oprot.WriteFieldBegin("discount");
				oprot.WriteString(structs.GetDiscount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportFee() != null) {
				
				oprot.WriteFieldBegin("transportFee");
				oprot.WriteString(structs.GetTransportFee());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnFee() != null) {
				
				oprot.WriteFieldBegin("returnFee");
				oprot.WriteString(structs.GetReturnFee());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ReturnMoneyVO bean){
			
			
		}
		
	}
	
}