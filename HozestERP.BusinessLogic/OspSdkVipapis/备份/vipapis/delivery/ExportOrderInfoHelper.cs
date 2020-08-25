using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class ExportOrderInfoHelper : BeanSerializer<ExportOrderInfo>
	{
		
		public static ExportOrderInfoHelper OBJ = new ExportOrderInfoHelper();
		
		public static ExportOrderInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ExportOrderInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("order_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_status(value);
					}
					
					
					
					
					
					if ("warehouse_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse_name(value);
					}
					
					
					
					
					
					if ("ebs_warehouse_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEbs_warehouse_code(value);
					}
					
					
					
					
					
					if ("b2c_warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetB2c_warehouse(value);
					}
					
					
					
					
					
					if ("user_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetUser_type(value);
					}
					
					
					
					
					
					if ("user_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUser_name(value);
					}
					
					
					
					
					
					if ("buyer_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetBuyer_id(value);
					}
					
					
					
					
					
					if ("address".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddress(value);
					}
					
					
					
					
					
					if ("buyer".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBuyer(value);
					}
					
					
					
					
					
					if ("area_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArea_id(value);
					}
					
					
					
					
					
					if ("postcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPostcode(value);
					}
					
					
					
					
					
					if ("city".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity(value);
					}
					
					
					
					
					
					if ("province".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProvince(value);
					}
					
					
					
					
					
					if ("country_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCountry_id(value);
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
						string value;
						value = iprot.ReadString();
						
						structs.SetPay_type(value);
					}
					
					
					
					
					
					if ("pos".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPos(value);
					}
					
					
					
					
					
					if ("transport_day".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_day(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
					}
					
					
					
					
					
					if ("order_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_type(value);
					}
					
					
					
					
					
					if ("vipclub".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipclub(value);
					}
					
					
					
					
					
					if ("invoice".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetInvoice(value);
					}
					
					
					
					
					
					if ("goods_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGoods_money(value);
					}
					
					
					
					
					
					if ("money".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMoney(value);
					}
					
					
					
					
					
					if ("agio".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAgio(value);
					}
					
					
					
					
					
					if ("discount_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDiscount_amount(value);
					}
					
					
					
					
					
					if ("promo_discount_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPromo_discount_amount(value);
					}
					
					
					
					
					
					if ("surplus".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSurplus(value);
					}
					
					
					
					
					
					if ("carriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriage(value);
					}
					
					
					
					
					
					if ("transport_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_no(value);
					}
					
					
					
					
					
					if ("carrier_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier_code(value);
					}
					
					
					
					
					
					if ("carrier_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier_name(value);
					}
					
					
					
					
					
					if ("transport_detail".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_detail(value);
					}
					
					
					
					
					
					if ("b2c_transport_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetB2c_transport_code(value);
					}
					
					
					
					
					
					if ("transport_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_id(value);
					}
					
					
					
					
					
					if ("transport_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_type(value);
					}
					
					
					
					
					
					if ("vendor_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_code(value);
					}
					
					
					
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("vendor_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_name(value);
					}
					
					
					
					
					
					if ("brand_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_name(value);
					}
					
					
					
					
					
					if ("goods_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.ExportProduct> value;
						
						value = new List<vipapis.delivery.ExportProduct>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.ExportProduct elem0;
								
								elem0 = new vipapis.delivery.ExportProduct();
								vipapis.delivery.ExportProductHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGoods_list(value);
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
		
		
		public void Write(ExportOrderInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_status() != null) {
				
				oprot.WriteFieldBegin("order_status");
				oprot.WriteString(structs.GetOrder_status());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse_name() != null) {
				
				oprot.WriteFieldBegin("warehouse_name");
				oprot.WriteString(structs.GetWarehouse_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEbs_warehouse_code() != null) {
				
				oprot.WriteFieldBegin("ebs_warehouse_code");
				oprot.WriteString(structs.GetEbs_warehouse_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetB2c_warehouse() != null) {
				
				oprot.WriteFieldBegin("b2c_warehouse");
				oprot.WriteString(structs.GetB2c_warehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUser_type() != null) {
				
				oprot.WriteFieldBegin("user_type");
				oprot.WriteI32((int)structs.GetUser_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUser_name() != null) {
				
				oprot.WriteFieldBegin("user_name");
				oprot.WriteString(structs.GetUser_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBuyer_id() != null) {
				
				oprot.WriteFieldBegin("buyer_id");
				oprot.WriteI32((int)structs.GetBuyer_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddress() != null) {
				
				oprot.WriteFieldBegin("address");
				oprot.WriteString(structs.GetAddress());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBuyer() != null) {
				
				oprot.WriteFieldBegin("buyer");
				oprot.WriteString(structs.GetBuyer());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArea_id() != null) {
				
				oprot.WriteFieldBegin("area_id");
				oprot.WriteString(structs.GetArea_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPostcode() != null) {
				
				oprot.WriteFieldBegin("postcode");
				oprot.WriteString(structs.GetPostcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCity() != null) {
				
				oprot.WriteFieldBegin("city");
				oprot.WriteString(structs.GetCity());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProvince() != null) {
				
				oprot.WriteFieldBegin("province");
				oprot.WriteString(structs.GetProvince());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCountry_id() != null) {
				
				oprot.WriteFieldBegin("country_id");
				oprot.WriteString(structs.GetCountry_id());
				
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
				oprot.WriteString(structs.GetPay_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPos() != null) {
				
				oprot.WriteFieldBegin("pos");
				oprot.WriteI32((int)structs.GetPos()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_day() != null) {
				
				oprot.WriteFieldBegin("transport_day");
				oprot.WriteString(structs.GetTransport_day());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_type() != null) {
				
				oprot.WriteFieldBegin("order_type");
				oprot.WriteString(structs.GetOrder_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipclub() != null) {
				
				oprot.WriteFieldBegin("vipclub");
				oprot.WriteString(structs.GetVipclub());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoice() != null) {
				
				oprot.WriteFieldBegin("invoice");
				oprot.WriteString(structs.GetInvoice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoods_money() != null) {
				
				oprot.WriteFieldBegin("goods_money");
				oprot.WriteString(structs.GetGoods_money());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMoney() != null) {
				
				oprot.WriteFieldBegin("money");
				oprot.WriteString(structs.GetMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAgio() != null) {
				
				oprot.WriteFieldBegin("agio");
				oprot.WriteString(structs.GetAgio());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDiscount_amount() != null) {
				
				oprot.WriteFieldBegin("discount_amount");
				oprot.WriteString(structs.GetDiscount_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPromo_discount_amount() != null) {
				
				oprot.WriteFieldBegin("promo_discount_amount");
				oprot.WriteString(structs.GetPromo_discount_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSurplus() != null) {
				
				oprot.WriteFieldBegin("surplus");
				oprot.WriteString(structs.GetSurplus());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriage() != null) {
				
				oprot.WriteFieldBegin("carriage");
				oprot.WriteString(structs.GetCarriage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_no() != null) {
				
				oprot.WriteFieldBegin("transport_no");
				oprot.WriteString(structs.GetTransport_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarrier_code() != null) {
				
				oprot.WriteFieldBegin("carrier_code");
				oprot.WriteString(structs.GetCarrier_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarrier_name() != null) {
				
				oprot.WriteFieldBegin("carrier_name");
				oprot.WriteString(structs.GetCarrier_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_detail() != null) {
				
				oprot.WriteFieldBegin("transport_detail");
				oprot.WriteString(structs.GetTransport_detail());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetB2c_transport_code() != null) {
				
				oprot.WriteFieldBegin("b2c_transport_code");
				oprot.WriteI32((int)structs.GetB2c_transport_code()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_id() != null) {
				
				oprot.WriteFieldBegin("transport_id");
				oprot.WriteString(structs.GetTransport_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_type() != null) {
				
				oprot.WriteFieldBegin("transport_type");
				oprot.WriteString(structs.GetTransport_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_code() != null) {
				
				oprot.WriteFieldBegin("vendor_code");
				oprot.WriteString(structs.GetVendor_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_name() != null) {
				
				oprot.WriteFieldBegin("vendor_name");
				oprot.WriteString(structs.GetVendor_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_name() != null) {
				
				oprot.WriteFieldBegin("brand_name");
				oprot.WriteString(structs.GetBrand_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoods_list() != null) {
				
				oprot.WriteFieldBegin("goods_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.ExportProduct _item0 in structs.GetGoods_list()){
					
					
					vipapis.delivery.ExportProductHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ExportOrderInfo bean){
			
			
		}
		
	}
	
}