using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.order{
	
	
	
	public class OrderInfoHelper : TBeanSerializer<OrderInfo>
	{
		
		public static OrderInfoHelper OBJ = new OrderInfoHelper();
		
		public static OrderInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transaction_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransaction_id(value);
					}
					
					
					
					
					
					if ("sales_platform".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSales_platform(value);
					}
					
					
					
					
					
					if ("erp_order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErp_order_sn(value);
					}
					
					
					
					
					
					if ("third_order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetThird_order_sn(value);
					}
					
					
					
					
					
					if ("old_erp_order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOld_erp_order_sn(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.inventory.WarehouseCode? value;
						
						value = com.vip.domain.inventory.WarehouseCodeUtil.FindByName(iprot.ReadString());
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("buyer".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBuyer(value);
					}
					
					
					
					
					
					if ("country".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCountry(value);
					}
					
					
					
					
					
					if ("state".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetState(value);
					}
					
					
					
					
					
					if ("city".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity(value);
					}
					
					
					
					
					
					if ("region".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRegion(value);
					}
					
					
					
					
					
					if ("town".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTown(value);
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
					
					
					
					
					
					if ("tel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTel(value);
					}
					
					
					
					
					
					if ("mobile".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMobile(value);
					}
					
					
					
					
					
					if ("pay_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.order.OrderPayType? value;
						
						value = com.vip.domain.order.OrderPayTypeUtil.FindByName(iprot.ReadString());
						
						structs.SetPay_type(value);
					}
					
					
					
					
					
					if ("transport_day".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.order.OrderTransportDay? value;
						
						value = com.vip.domain.order.OrderTransportDayUtil.FindByName(iprot.ReadString());
						
						structs.SetTransport_day(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
					}
					
					
					
					
					
					if ("goods_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetGoods_money(value);
					}
					
					
					
					
					
					if ("money".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetMoney(value);
					}
					
					
					
					
					
					if ("carriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetCarriage(value);
					}
					
					
					
					
					
					if ("ext_pay_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.order.OrderExtPayType? value;
						
						value = com.vip.domain.order.OrderExtPayTypeUtil.FindByName(iprot.ReadString());
						
						structs.SetExt_pay_type(value);
					}
					
					
					
					
					
					if ("erp_create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetErp_create_time(value);
					}
					
					
					
					
					
					if ("b2c_add_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetB2c_add_time(value);
					}
					
					
					
					
					
					if ("invoice".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInvoice(value);
					}
					
					
					
					
					
					if ("ex_pay_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetEx_pay_money(value);
					}
					
					
					
					
					
					if ("aigo".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetAigo(value);
					}
					
					
					
					
					
					if ("service_phone".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetService_phone(value);
					}
					
					
					
					
					
					if ("is_printing_price".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.order.OrderIsPrintingPrice? value;
						
						value = com.vip.domain.order.OrderIsPrintingPriceUtil.FindByName(iprot.ReadString());
						
						structs.SetIs_printing_price(value);
					}
					
					
					
					
					
					if ("itemList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.domain.order.OrderItemInfo> value;
						
						value = new List<com.vip.domain.order.OrderItemInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.domain.order.OrderItemInfo elem0;
								
								elem0 = new com.vip.domain.order.OrderItemInfo();
								com.vip.domain.order.OrderItemInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetItemList(value);
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
		
		
		public void Write(OrderInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransaction_id() != null) {
				
				oprot.WriteFieldBegin("transaction_id");
				oprot.WriteString(structs.GetTransaction_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transaction_id can not be null!");
			}
			
			
			if(structs.GetSales_platform() != null) {
				
				oprot.WriteFieldBegin("sales_platform");
				oprot.WriteString(structs.GetSales_platform());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sales_platform can not be null!");
			}
			
			
			if(structs.GetErp_order_sn() != null) {
				
				oprot.WriteFieldBegin("erp_order_sn");
				oprot.WriteString(structs.GetErp_order_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("erp_order_sn can not be null!");
			}
			
			
			if(structs.GetThird_order_sn() != null) {
				
				oprot.WriteFieldBegin("third_order_sn");
				oprot.WriteString(structs.GetThird_order_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("third_order_sn can not be null!");
			}
			
			
			if(structs.GetOld_erp_order_sn() != null) {
				
				oprot.WriteFieldBegin("old_erp_order_sn");
				oprot.WriteString(structs.GetOld_erp_order_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBuyer() != null) {
				
				oprot.WriteFieldBegin("buyer");
				oprot.WriteString(structs.GetBuyer());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("buyer can not be null!");
			}
			
			
			if(structs.GetCountry() != null) {
				
				oprot.WriteFieldBegin("country");
				oprot.WriteString(structs.GetCountry());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("country can not be null!");
			}
			
			
			if(structs.GetState() != null) {
				
				oprot.WriteFieldBegin("state");
				oprot.WriteString(structs.GetState());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("state can not be null!");
			}
			
			
			if(structs.GetCity() != null) {
				
				oprot.WriteFieldBegin("city");
				oprot.WriteString(structs.GetCity());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("city can not be null!");
			}
			
			
			if(structs.GetRegion() != null) {
				
				oprot.WriteFieldBegin("region");
				oprot.WriteString(structs.GetRegion());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTown() != null) {
				
				oprot.WriteFieldBegin("town");
				oprot.WriteString(structs.GetTown());
				
				oprot.WriteFieldEnd();
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
			
			
			if(structs.GetTel() != null) {
				
				oprot.WriteFieldBegin("tel");
				oprot.WriteString(structs.GetTel());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMobile() != null) {
				
				oprot.WriteFieldBegin("mobile");
				oprot.WriteString(structs.GetMobile());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPay_type() != null) {
				
				oprot.WriteFieldBegin("pay_type");
				oprot.WriteString(structs.GetPay_type().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("pay_type can not be null!");
			}
			
			
			if(structs.GetTransport_day() != null) {
				
				oprot.WriteFieldBegin("transport_day");
				oprot.WriteString(structs.GetTransport_day().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transport_day can not be null!");
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoods_money() != null) {
				
				oprot.WriteFieldBegin("goods_money");
				oprot.WriteDouble((double)structs.GetGoods_money());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("goods_money can not be null!");
			}
			
			
			if(structs.GetMoney() != null) {
				
				oprot.WriteFieldBegin("money");
				oprot.WriteDouble((double)structs.GetMoney());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("money can not be null!");
			}
			
			
			if(structs.GetCarriage() != null) {
				
				oprot.WriteFieldBegin("carriage");
				oprot.WriteDouble((double)structs.GetCarriage());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("carriage can not be null!");
			}
			
			
			if(structs.GetExt_pay_type() != null) {
				
				oprot.WriteFieldBegin("ext_pay_type");
				oprot.WriteString(structs.GetExt_pay_type().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("ext_pay_type can not be null!");
			}
			
			
			if(structs.GetErp_create_time() != null) {
				
				oprot.WriteFieldBegin("erp_create_time");
				oprot.WriteString(structs.GetErp_create_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("erp_create_time can not be null!");
			}
			
			
			if(structs.GetB2c_add_time() != null) {
				
				oprot.WriteFieldBegin("b2c_add_time");
				oprot.WriteString(structs.GetB2c_add_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("b2c_add_time can not be null!");
			}
			
			
			if(structs.GetInvoice() != null) {
				
				oprot.WriteFieldBegin("invoice");
				oprot.WriteString(structs.GetInvoice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEx_pay_money() != null) {
				
				oprot.WriteFieldBegin("ex_pay_money");
				oprot.WriteDouble((double)structs.GetEx_pay_money());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAigo() != null) {
				
				oprot.WriteFieldBegin("aigo");
				oprot.WriteDouble((double)structs.GetAigo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetService_phone() != null) {
				
				oprot.WriteFieldBegin("service_phone");
				oprot.WriteString(structs.GetService_phone());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("service_phone can not be null!");
			}
			
			
			if(structs.GetIs_printing_price() != null) {
				
				oprot.WriteFieldBegin("is_printing_price");
				oprot.WriteString(structs.GetIs_printing_price().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_printing_price can not be null!");
			}
			
			
			if(structs.GetItemList() != null) {
				
				oprot.WriteFieldBegin("itemList");
				
				oprot.WriteListBegin();
				foreach(com.vip.domain.order.OrderItemInfo _item0 in structs.GetItemList()){
					
					
					com.vip.domain.order.OrderItemInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderInfo bean){
			
			
		}
		
	}
	
}