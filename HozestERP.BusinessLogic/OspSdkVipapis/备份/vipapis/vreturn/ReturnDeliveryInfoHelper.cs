using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vreturn{
	
	
	
	public class ReturnDeliveryInfoHelper : BeanSerializer<ReturnDeliveryInfo>
	{
		
		public static ReturnDeliveryInfoHelper OBJ = new ReturnDeliveryInfoHelper();
		
		public static ReturnDeliveryInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ReturnDeliveryInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("return_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturn_sn(value);
					}
					
					
					
					
					
					if ("out_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOut_time(value);
					}
					
					
					
					
					
					if ("total_cases".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetTotal_cases(value);
					}
					
					
					
					
					
					if ("total_skus".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetTotal_skus(value);
					}
					
					
					
					
					
					if ("total_qtys".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetTotal_qtys(value);
					}
					
					
					
					
					
					if ("delivery_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.vreturn.ReturnDeliveryDetail> value;
						
						value = new List<vipapis.vreturn.ReturnDeliveryDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.vreturn.ReturnDeliveryDetail elem0;
								
								elem0 = new vipapis.vreturn.ReturnDeliveryDetail();
								vipapis.vreturn.ReturnDeliveryDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDelivery_list(value);
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
		
		
		public void Write(ReturnDeliveryInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturn_sn() != null) {
				
				oprot.WriteFieldBegin("return_sn");
				oprot.WriteString(structs.GetReturn_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOut_time() != null) {
				
				oprot.WriteFieldBegin("out_time");
				oprot.WriteString(structs.GetOut_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal_cases() != null) {
				
				oprot.WriteFieldBegin("total_cases");
				oprot.WriteDouble((double)structs.GetTotal_cases());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal_skus() != null) {
				
				oprot.WriteFieldBegin("total_skus");
				oprot.WriteDouble((double)structs.GetTotal_skus());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal_qtys() != null) {
				
				oprot.WriteFieldBegin("total_qtys");
				oprot.WriteDouble((double)structs.GetTotal_qtys());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDelivery_list() != null) {
				
				oprot.WriteFieldBegin("delivery_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.vreturn.ReturnDeliveryDetail _item0 in structs.GetDelivery_list()){
					
					
					vipapis.vreturn.ReturnDeliveryDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ReturnDeliveryInfo bean){
			
			
		}
		
	}
	
}