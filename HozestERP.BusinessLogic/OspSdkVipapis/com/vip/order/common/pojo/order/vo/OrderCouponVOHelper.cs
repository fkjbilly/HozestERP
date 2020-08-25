using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderCouponVOHelper : TBeanSerializer<OrderCouponVO>
	{
		
		public static OrderCouponVOHelper OBJ = new OrderCouponVOHelper();
		
		public static OrderCouponVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderCouponVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("couponSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCouponSn(value);
					}
					
					
					
					
					
					if ("couponType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCouponType(value);
					}
					
					
					
					
					
					if ("couponTypename".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCouponTypename(value);
					}
					
					
					
					
					
					if ("couponField".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCouponField(value);
					}
					
					
					
					
					
					if ("couponFieldname".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCouponFieldname(value);
					}
					
					
					
					
					
					if ("couponFavDesc".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCouponFavDesc(value);
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
		
		
		public void Write(OrderCouponVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCouponSn() != null) {
				
				oprot.WriteFieldBegin("couponSn");
				oprot.WriteString(structs.GetCouponSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCouponType() != null) {
				
				oprot.WriteFieldBegin("couponType");
				oprot.WriteString(structs.GetCouponType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCouponTypename() != null) {
				
				oprot.WriteFieldBegin("couponTypename");
				oprot.WriteString(structs.GetCouponTypename());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCouponField() != null) {
				
				oprot.WriteFieldBegin("couponField");
				oprot.WriteString(structs.GetCouponField());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCouponFieldname() != null) {
				
				oprot.WriteFieldBegin("couponFieldname");
				oprot.WriteString(structs.GetCouponFieldname());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCouponFavDesc() != null) {
				
				oprot.WriteFieldBegin("couponFavDesc");
				oprot.WriteString(structs.GetCouponFavDesc());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderCouponVO bean){
			
			
		}
		
	}
	
}