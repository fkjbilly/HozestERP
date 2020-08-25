using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.fcs.vei.service{
	
	
	
	public class InvoiceOrderDataReqModelHelper : TBeanSerializer<InvoiceOrderDataReqModel>
	{
		
		public static InvoiceOrderDataReqModelHelper OBJ = new InvoiceOrderDataReqModelHelper();
		
		public static InvoiceOrderDataReqModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(InvoiceOrderDataReqModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("orderState".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderState(value);
					}
					
					
					
					
					
					if ("orderDate".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderDate(value);
					}
					
					
					
					
					
					if ("orderAmount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetOrderAmount(value);
					}
					
					
					
					
					
					if ("customerTel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomerTel(value);
					}
					
					
					
					
					
					if ("titleType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTitleType(value);
					}
					
					
					
					
					
					if ("title".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTitle(value);
					}
					
					
					
					
					
					if ("payType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPayType(value);
					}
					
					
					
					
					
					if ("consigneeProvinces".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetConsigneeProvinces(value);
					}
					
					
					
					
					
					if ("consigneeCity".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetConsigneeCity(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("payDate".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPayDate(value);
					}
					
					
					
					
					
					if ("otherAmount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetOtherAmount(value);
					}
					
					
					
					
					
					if ("orderid".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderid(value);
					}
					
					
					
					
					
					if ("userid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserid(value);
					}
					
					
					
					
					
					if ("orderElectornicInvoiceId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderElectornicInvoiceId(value);
					}
					
					
					
					
					
					if ("platform".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPlatform(value);
					}
					
					
					
					
					
					if ("discountAmount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetDiscountAmount(value);
					}
					
					
					
					
					
					if ("walletAmount".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetWalletAmount(value);
					}
					
					
					
					
					
					if ("invoiceDeductMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetInvoiceDeductMoney(value);
					}
					
					
					
					
					
					if ("source".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSource(value);
					}
					
					
					
					
					
					if ("sourceRecordId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSourceRecordId(value);
					}
					
					
					
					
					
					if ("invoiceType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetInvoiceType(value);
					}
					
					
					
					
					
					if ("orderItems".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.fcs.vei.service.OrderItemsModel> value;
						
						value = new List<com.vip.fcs.vei.service.OrderItemsModel>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.fcs.vei.service.OrderItemsModel elem0;
								
								elem0 = new com.vip.fcs.vei.service.OrderItemsModel();
								com.vip.fcs.vei.service.OrderItemsModelHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderItems(value);
					}
					
					
					
					
					
					if ("vipClub".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipClub(value);
					}
					
					
					
					
					
					if ("businessType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBusinessType(value);
					}
					
					
					
					
					
					if ("businessSubType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBusinessSubType(value);
					}
					
					
					
					
					
					if ("buyerTaxRegisterNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBuyerTaxRegisterNo(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
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
		
		
		public void Write(InvoiceOrderDataReqModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orderSn can not be null!");
			}
			
			
			if(structs.GetOrderState() != null) {
				
				oprot.WriteFieldBegin("orderState");
				oprot.WriteString(structs.GetOrderState());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orderState can not be null!");
			}
			
			
			if(structs.GetOrderDate() != null) {
				
				oprot.WriteFieldBegin("orderDate");
				oprot.WriteI64((long)structs.GetOrderDate()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderAmount() != null) {
				
				oprot.WriteFieldBegin("orderAmount");
				oprot.WriteDouble((double)structs.GetOrderAmount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustomerTel() != null) {
				
				oprot.WriteFieldBegin("customerTel");
				oprot.WriteString(structs.GetCustomerTel());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTitleType() != null) {
				
				oprot.WriteFieldBegin("titleType");
				oprot.WriteString(structs.GetTitleType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTitle() != null) {
				
				oprot.WriteFieldBegin("title");
				oprot.WriteString(structs.GetTitle());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayType() != null) {
				
				oprot.WriteFieldBegin("payType");
				oprot.WriteString(structs.GetPayType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetConsigneeProvinces() != null) {
				
				oprot.WriteFieldBegin("consigneeProvinces");
				oprot.WriteString(structs.GetConsigneeProvinces());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetConsigneeCity() != null) {
				
				oprot.WriteFieldBegin("consigneeCity");
				oprot.WriteString(structs.GetConsigneeCity());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayDate() != null) {
				
				oprot.WriteFieldBegin("payDate");
				oprot.WriteI64((long)structs.GetPayDate()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOtherAmount() != null) {
				
				oprot.WriteFieldBegin("otherAmount");
				oprot.WriteDouble((double)structs.GetOtherAmount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderid() != null) {
				
				oprot.WriteFieldBegin("orderid");
				oprot.WriteI64((long)structs.GetOrderid()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserid() != null) {
				
				oprot.WriteFieldBegin("userid");
				oprot.WriteString(structs.GetUserid());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderElectornicInvoiceId() != null) {
				
				oprot.WriteFieldBegin("orderElectornicInvoiceId");
				oprot.WriteString(structs.GetOrderElectornicInvoiceId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPlatform() != null) {
				
				oprot.WriteFieldBegin("platform");
				oprot.WriteI32((int)structs.GetPlatform()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDiscountAmount() != null) {
				
				oprot.WriteFieldBegin("discountAmount");
				oprot.WriteDouble((double)structs.GetDiscountAmount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWalletAmount() != null) {
				
				oprot.WriteFieldBegin("walletAmount");
				oprot.WriteDouble((double)structs.GetWalletAmount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoiceDeductMoney() != null) {
				
				oprot.WriteFieldBegin("invoiceDeductMoney");
				oprot.WriteDouble((double)structs.GetInvoiceDeductMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSource() != null) {
				
				oprot.WriteFieldBegin("source");
				oprot.WriteString(structs.GetSource());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("source can not be null!");
			}
			
			
			if(structs.GetSourceRecordId() != null) {
				
				oprot.WriteFieldBegin("sourceRecordId");
				oprot.WriteString(structs.GetSourceRecordId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sourceRecordId can not be null!");
			}
			
			
			if(structs.GetInvoiceType() != null) {
				
				oprot.WriteFieldBegin("invoiceType");
				oprot.WriteI32((int)structs.GetInvoiceType()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("invoiceType can not be null!");
			}
			
			
			if(structs.GetOrderItems() != null) {
				
				oprot.WriteFieldBegin("orderItems");
				
				oprot.WriteListBegin();
				foreach(com.vip.fcs.vei.service.OrderItemsModel _item0 in structs.GetOrderItems()){
					
					
					com.vip.fcs.vei.service.OrderItemsModelHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipClub() != null) {
				
				oprot.WriteFieldBegin("vipClub");
				oprot.WriteString(structs.GetVipClub());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBusinessType() != null) {
				
				oprot.WriteFieldBegin("businessType");
				oprot.WriteString(structs.GetBusinessType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBusinessSubType() != null) {
				
				oprot.WriteFieldBegin("businessSubType");
				oprot.WriteString(structs.GetBusinessSubType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBuyerTaxRegisterNo() != null) {
				
				oprot.WriteFieldBegin("buyerTaxRegisterNo");
				oprot.WriteString(structs.GetBuyerTaxRegisterNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(InvoiceOrderDataReqModel bean){
			
			
		}
		
	}
	
}