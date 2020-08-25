using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class CarrierInfoRequestHelper : TBeanSerializer<CarrierInfoRequest>
	{
		
		public static CarrierInfoRequestHelper OBJ = new CarrierInfoRequestHelper();
		
		public static CarrierInfoRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CarrierInfoRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("request_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRequest_time(value);
					}
					
					
					
					
					
					if ("cust_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCust_code(value);
					}
					
					
					
					
					
					if ("carrier_info_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.overseas.CarrierInfo> value;
						
						value = new List<vipapis.overseas.CarrierInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.overseas.CarrierInfo elem1;
								
								elem1 = new vipapis.overseas.CarrierInfo();
								vipapis.overseas.CarrierInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetCarrier_info_list(value);
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
		
		
		public void Write(CarrierInfoRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetRequest_time() != null) {
				
				oprot.WriteFieldBegin("request_time");
				oprot.WriteString(structs.GetRequest_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("request_time can not be null!");
			}
			
			
			if(structs.GetCust_code() != null) {
				
				oprot.WriteFieldBegin("cust_code");
				oprot.WriteString(structs.GetCust_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("cust_code can not be null!");
			}
			
			
			if(structs.GetCarrier_info_list() != null) {
				
				oprot.WriteFieldBegin("carrier_info_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.overseas.CarrierInfo _item0 in structs.GetCarrier_info_list()){
					
					
					vipapis.overseas.CarrierInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("carrier_info_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CarrierInfoRequest bean){
			
			
		}
		
	}
	
}