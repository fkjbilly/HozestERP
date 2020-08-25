using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.order{
	
	
	
	public class OrderHelper : BeanSerializer<Order>
	{
		
		public static OrderHelper OBJ = new OrderHelper();
		
		public static OrderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Order structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetOrder_sn(value);
					}
					
					
					
					
					
					if ("status_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStatus_name(value);
					}
					
					
					
					
					
					if ("order_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetOrder_date(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("buyer_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBuyer_name(value);
					}
					
					
					
					
					
					if ("address".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddress(value);
					}
					
					
					
					
					
					if ("postcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPostcode(value);
					}
					
					
					
					
					
					if ("mobile".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMobile(value);
					}
					
					
					
					
					
					if ("tel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTel(value);
					}
					
					
					
					
					
					if ("transport_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_sn(value);
					}
					
					
					
					
					
					if ("transport_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_name(value);
					}
					
					
					
					
					
					if ("carriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetCarriage(value);
					}
					
					
					
					
					
					if ("goods_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetGoods_amount(value);
					}
					
					
					
					
					
					if ("create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetCreate_time(value);
					}
					
					
					
					
					
					if ("update_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetUpdate_time(value);
					}
					
					
					
					
					
					if ("order_goods".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.order.OrderGoods> value;
						
						value = new List<vipapis.order.OrderGoods>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.order.OrderGoods elem0;
								
								elem0 = new vipapis.order.OrderGoods();
								vipapis.order.OrderGoodsHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrder_goods(value);
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
		
		
		public void Write(Order structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_sn() != null) {
				
				oprot.WriteFieldBegin("order_sn");
				oprot.WriteI64((long)structs.GetOrder_sn()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_sn can not be null!");
			}
			
			
			if(structs.GetStatus_name() != null) {
				
				oprot.WriteFieldBegin("status_name");
				oprot.WriteString(structs.GetStatus_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("status_name can not be null!");
			}
			
			
			if(structs.GetOrder_date() != null) {
				
				oprot.WriteFieldBegin("order_date");
				oprot.WriteI32((int)structs.GetOrder_date()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_date can not be null!");
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteI32((int)structs.GetAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("amount can not be null!");
			}
			
			
			if(structs.GetBuyer_name() != null) {
				
				oprot.WriteFieldBegin("buyer_name");
				oprot.WriteString(structs.GetBuyer_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("buyer_name can not be null!");
			}
			
			
			if(structs.GetAddress() != null) {
				
				oprot.WriteFieldBegin("address");
				oprot.WriteString(structs.GetAddress());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("address can not be null!");
			}
			
			
			if(structs.GetPostcode() != null) {
				
				oprot.WriteFieldBegin("postcode");
				oprot.WriteString(structs.GetPostcode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("postcode can not be null!");
			}
			
			
			if(structs.GetMobile() != null) {
				
				oprot.WriteFieldBegin("mobile");
				oprot.WriteString(structs.GetMobile());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTel() != null) {
				
				oprot.WriteFieldBegin("tel");
				oprot.WriteString(structs.GetTel());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_sn() != null) {
				
				oprot.WriteFieldBegin("transport_sn");
				oprot.WriteString(structs.GetTransport_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_name() != null) {
				
				oprot.WriteFieldBegin("transport_name");
				oprot.WriteString(structs.GetTransport_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriage() != null) {
				
				oprot.WriteFieldBegin("carriage");
				oprot.WriteI32((int)structs.GetCarriage()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("carriage can not be null!");
			}
			
			
			if(structs.GetGoods_amount() != null) {
				
				oprot.WriteFieldBegin("goods_amount");
				oprot.WriteI32((int)structs.GetGoods_amount()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("goods_amount can not be null!");
			}
			
			
			if(structs.GetCreate_time() != null) {
				
				oprot.WriteFieldBegin("create_time");
				oprot.WriteI32((int)structs.GetCreate_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("create_time can not be null!");
			}
			
			
			if(structs.GetUpdate_time() != null) {
				
				oprot.WriteFieldBegin("update_time");
				oprot.WriteI32((int)structs.GetUpdate_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("update_time can not be null!");
			}
			
			
			if(structs.GetOrder_goods() != null) {
				
				oprot.WriteFieldBegin("order_goods");
				
				oprot.WriteListBegin();
				foreach(vipapis.order.OrderGoods _item0 in structs.GetOrder_goods()){
					
					
					vipapis.order.OrderGoodsHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Order bean){
			
			
		}
		
	}
	
}