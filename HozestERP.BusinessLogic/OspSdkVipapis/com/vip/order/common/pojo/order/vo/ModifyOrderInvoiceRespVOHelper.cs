using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class ModifyOrderInvoiceRespVOHelper : TBeanSerializer<ModifyOrderInvoiceRespVO>
	{
		
		public static ModifyOrderInvoiceRespVOHelper OBJ = new ModifyOrderInvoiceRespVOHelper();
		
		public static ModifyOrderInvoiceRespVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ModifyOrderInvoiceRespVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("retCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRetCode(value);
					}
					
					
					
					
					
					if ("retMessage".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRetMessage(value);
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
		
		
		public void Write(ModifyOrderInvoiceRespVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRetCode() != null) {
				
				oprot.WriteFieldBegin("retCode");
				oprot.WriteString(structs.GetRetCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRetMessage() != null) {
				
				oprot.WriteFieldBegin("retMessage");
				oprot.WriteString(structs.GetRetMessage());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ModifyOrderInvoiceRespVO bean){
			
			
		}
		
	}
	
}