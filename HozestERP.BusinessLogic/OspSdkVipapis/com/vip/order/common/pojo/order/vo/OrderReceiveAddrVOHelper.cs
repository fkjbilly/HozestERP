using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderReceiveAddrVOHelper : TBeanSerializer<OrderReceiveAddrVO>
	{
		
		public static OrderReceiveAddrVOHelper OBJ = new OrderReceiveAddrVOHelper();
		
		public static OrderReceiveAddrVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderReceiveAddrVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("address".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddress(value);
					}
					
					
					
					
					
					if ("addressType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddressType(value);
					}
					
					
					
					
					
					if ("areaId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAreaId(value);
					}
					
					
					
					
					
					if ("areaName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAreaName(value);
					}
					
					
					
					
					
					if ("consignee".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetConsignee(value);
					}
					
					
					
					
					
					if ("mobile".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMobile(value);
					}
					
					
					
					
					
					if ("postcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPostcode(value);
					}
					
					
					
					
					
					if ("tel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTel(value);
					}
					
					
					
					
					
					if ("transportDay".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTransportDay(value);
					}
					
					
					
					
					
					if ("transportTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTransportTime(value);
					}
					
					
					
					
					
					if ("countryId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCountryId(value);
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
		
		
		public void Write(OrderReceiveAddrVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetAddress() != null) {
				
				oprot.WriteFieldBegin("address");
				oprot.WriteString(structs.GetAddress());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddressType() != null) {
				
				oprot.WriteFieldBegin("addressType");
				oprot.WriteString(structs.GetAddressType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAreaId() != null) {
				
				oprot.WriteFieldBegin("areaId");
				oprot.WriteString(structs.GetAreaId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAreaName() != null) {
				
				oprot.WriteFieldBegin("areaName");
				oprot.WriteString(structs.GetAreaName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetConsignee() != null) {
				
				oprot.WriteFieldBegin("consignee");
				oprot.WriteString(structs.GetConsignee());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMobile() != null) {
				
				oprot.WriteFieldBegin("mobile");
				oprot.WriteString(structs.GetMobile());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPostcode() != null) {
				
				oprot.WriteFieldBegin("postcode");
				oprot.WriteString(structs.GetPostcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTel() != null) {
				
				oprot.WriteFieldBegin("tel");
				oprot.WriteString(structs.GetTel());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportDay() != null) {
				
				oprot.WriteFieldBegin("transportDay");
				oprot.WriteI32((int)structs.GetTransportDay()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportTime() != null) {
				
				oprot.WriteFieldBegin("transportTime");
				oprot.WriteI32((int)structs.GetTransportTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCountryId() != null) {
				
				oprot.WriteFieldBegin("countryId");
				oprot.WriteI32((int)structs.GetCountryId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderReceiveAddrVO bean){
			
			
		}
		
	}
	
}