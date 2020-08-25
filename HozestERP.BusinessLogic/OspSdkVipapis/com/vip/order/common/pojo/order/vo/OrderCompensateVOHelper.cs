using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderCompensateVOHelper : TBeanSerializer<OrderCompensateVO>
	{
		
		public static OrderCompensateVOHelper OBJ = new OrderCompensateVOHelper();
		
		public static OrderCompensateVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderCompensateVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetId(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("compensateType".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetCompensateType(value);
					}
					
					
					
					
					
					if ("compensateWay".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetCompensateWay(value);
					}
					
					
					
					
					
					if ("money".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMoney(value);
					}
					
					
					
					
					
					if ("compensateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCompensateTime(value);
					}
					
					
					
					
					
					if ("reason".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReason(value);
					}
					
					
					
					
					
					if ("compensateStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetCompensateStatus(value);
					}
					
					
					
					
					
					if ("addTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAddTime(value);
					}
					
					
					
					
					
					if ("procTimes".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetProcTimes(value);
					}
					
					
					
					
					
					if ("updateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUpdateTime(value);
					}
					
					
					
					
					
					if ("isDeleted".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsDeleted(value);
					}
					
					
					
					
					
					if ("operateSys".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOperateSys(value);
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
		
		
		public void Write(OrderCompensateVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteI64((long)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteI64((long)structs.GetOrderId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCompensateType() != null) {
				
				oprot.WriteFieldBegin("compensateType");
				oprot.WriteByte((byte)structs.GetCompensateType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCompensateWay() != null) {
				
				oprot.WriteFieldBegin("compensateWay");
				oprot.WriteByte((byte)structs.GetCompensateWay()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMoney() != null) {
				
				oprot.WriteFieldBegin("money");
				oprot.WriteString(structs.GetMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCompensateTime() != null) {
				
				oprot.WriteFieldBegin("compensateTime");
				oprot.WriteI32((int)structs.GetCompensateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReason() != null) {
				
				oprot.WriteFieldBegin("reason");
				oprot.WriteString(structs.GetReason());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCompensateStatus() != null) {
				
				oprot.WriteFieldBegin("compensateStatus");
				oprot.WriteByte((byte)structs.GetCompensateStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddTime() != null) {
				
				oprot.WriteFieldBegin("addTime");
				oprot.WriteI32((int)structs.GetAddTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProcTimes() != null) {
				
				oprot.WriteFieldBegin("procTimes");
				oprot.WriteByte((byte)structs.GetProcTimes()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdateTime() != null) {
				
				oprot.WriteFieldBegin("updateTime");
				oprot.WriteI64((long)structs.GetUpdateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsDeleted() != null) {
				
				oprot.WriteFieldBegin("isDeleted");
				oprot.WriteBool((bool)structs.GetIsDeleted());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOperateSys() != null) {
				
				oprot.WriteFieldBegin("operateSys");
				oprot.WriteString(structs.GetOperateSys());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderCompensateVO bean){
			
			
		}
		
	}
	
}