using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderReturnPackageInfoVOHelper : TBeanSerializer<OrderReturnPackageInfoVO>
	{
		
		public static OrderReturnPackageInfoVOHelper OBJ = new OrderReturnPackageInfoVOHelper();
		
		public static OrderReturnPackageInfoVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderReturnPackageInfoVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderReturnTransportId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderReturnTransportId(value);
					}
					
					
					
					
					
					if ("carriersName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriersName(value);
					}
					
					
					
					
					
					if ("transportNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportNo(value);
					}
					
					
					
					
					
					if ("carriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriage(value);
					}
					
					
					
					
					
					if ("carriagePayType".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetCarriagePayType(value);
					}
					
					
					
					
					
					if ("inpackType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInpackType(value);
					}
					
					
					
					
					
					if ("inpackTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetInpackTime(value);
					}
					
					
					
					
					
					if ("goodsBackWay".Equals(schemeField.Trim())){
						
						needSkip = false;
						short? value;
						value = iprot.ReadI16(); 
						
						structs.SetGoodsBackWay(value);
					}
					
					
					
					
					
					if ("hasUpdated".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetHasUpdated(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("applyId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetApplyId(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("operator".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOperator(value);
					}
					
					
					
					
					
					if ("ip".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIp(value);
					}
					
					
					
					
					
					if ("getTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetGetTime(value);
					}
					
					
					
					
					
					if ("addTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetAddTime(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetCreateTime(value);
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
		
		
		public void Write(OrderReturnPackageInfoVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderReturnTransportId() != null) {
				
				oprot.WriteFieldBegin("orderReturnTransportId");
				oprot.WriteI64((long)structs.GetOrderReturnTransportId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriersName() != null) {
				
				oprot.WriteFieldBegin("carriersName");
				oprot.WriteString(structs.GetCarriersName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportNo() != null) {
				
				oprot.WriteFieldBegin("transportNo");
				oprot.WriteString(structs.GetTransportNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriage() != null) {
				
				oprot.WriteFieldBegin("carriage");
				oprot.WriteString(structs.GetCarriage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriagePayType() != null) {
				
				oprot.WriteFieldBegin("carriagePayType");
				oprot.WriteByte((byte)structs.GetCarriagePayType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInpackType() != null) {
				
				oprot.WriteFieldBegin("inpackType");
				oprot.WriteString(structs.GetInpackType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInpackTime() != null) {
				
				oprot.WriteFieldBegin("inpackTime");
				oprot.WriteI64((long)structs.GetInpackTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsBackWay() != null) {
				
				oprot.WriteFieldBegin("goodsBackWay");
				oprot.WriteI16((short)structs.GetGoodsBackWay()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHasUpdated() != null) {
				
				oprot.WriteFieldBegin("hasUpdated");
				oprot.WriteByte((byte)structs.GetHasUpdated()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetApplyId() != null) {
				
				oprot.WriteFieldBegin("applyId");
				oprot.WriteI64((long)structs.GetApplyId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOperator() != null) {
				
				oprot.WriteFieldBegin("operator");
				oprot.WriteString(structs.GetOperator());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIp() != null) {
				
				oprot.WriteFieldBegin("ip");
				oprot.WriteString(structs.GetIp());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGetTime() != null) {
				
				oprot.WriteFieldBegin("getTime");
				oprot.WriteI64((long)structs.GetGetTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddTime() != null) {
				
				oprot.WriteFieldBegin("addTime");
				oprot.WriteI64((long)structs.GetAddTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteI64((long)structs.GetCreateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderReturnPackageInfoVO bean){
			
			
		}
		
	}
	
}