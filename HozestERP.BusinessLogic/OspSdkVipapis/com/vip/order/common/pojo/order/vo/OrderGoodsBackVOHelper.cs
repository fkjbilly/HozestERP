using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderGoodsBackVOHelper : TBeanSerializer<OrderGoodsBackVO>
	{
		
		public static OrderGoodsBackVOHelper OBJ = new OrderGoodsBackVOHelper();
		
		public static OrderGoodsBackVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderGoodsBackVO structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("orderGoodsId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderGoodsId(value);
					}
					
					
					
					
					
					if ("oldAmount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOldAmount(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("spoilNum".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSpoilNum(value);
					}
					
					
					
					
					
					if ("opType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOpType(value);
					}
					
					
					
					
					
					if ("reason".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReason(value);
					}
					
					
					
					
					
					if ("changeSize".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetChangeSize(value);
					}
					
					
					
					
					
					if ("addTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetAddTime(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
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
		
		
		public void Write(OrderGoodsBackVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteI64((long)structs.GetId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteI64((long)structs.GetOrderId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderGoodsId() != null) {
				
				oprot.WriteFieldBegin("orderGoodsId");
				oprot.WriteI64((long)structs.GetOrderGoodsId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOldAmount() != null) {
				
				oprot.WriteFieldBegin("oldAmount");
				oprot.WriteI32((int)structs.GetOldAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteI32((int)structs.GetAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSpoilNum() != null) {
				
				oprot.WriteFieldBegin("spoilNum");
				oprot.WriteI32((int)structs.GetSpoilNum()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOpType() != null) {
				
				oprot.WriteFieldBegin("opType");
				oprot.WriteI32((int)structs.GetOpType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReason() != null) {
				
				oprot.WriteFieldBegin("reason");
				oprot.WriteString(structs.GetReason());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetChangeSize() != null) {
				
				oprot.WriteFieldBegin("changeSize");
				oprot.WriteString(structs.GetChangeSize());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddTime() != null) {
				
				oprot.WriteFieldBegin("addTime");
				oprot.WriteI64((long)structs.GetAddTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderGoodsBackVO bean){
			
			
		}
		
	}
	
}