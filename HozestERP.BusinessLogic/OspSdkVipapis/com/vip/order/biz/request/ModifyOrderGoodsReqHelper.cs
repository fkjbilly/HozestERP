using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class ModifyOrderGoodsReqHelper : TBeanSerializer<ModifyOrderGoodsReq>
	{
		
		public static ModifyOrderGoodsReqHelper OBJ = new ModifyOrderGoodsReqHelper();
		
		public static ModifyOrderGoodsReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ModifyOrderGoodsReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderCategory".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte? value;
						value = iprot.ReadByte(); 
						
						structs.SetOrderCategory(value);
					}
					
					
					
					
					
					if ("modifyGoodsOrder".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.request.ModifyGoodsOrder value;
						
						value = new com.vip.order.biz.request.ModifyGoodsOrder();
						com.vip.order.biz.request.ModifyGoodsOrderHelper.getInstance().Read(value, iprot);
						
						structs.SetModifyGoodsOrder(value);
					}
					
					
					
					
					
					if ("goodsInfoList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.request.NewGoodsInfo> value;
						
						value = new List<com.vip.order.biz.request.NewGoodsInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.request.NewGoodsInfo elem1;
								
								elem1 = new com.vip.order.biz.request.NewGoodsInfo();
								com.vip.order.biz.request.NewGoodsInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGoodsInfoList(value);
					}
					
					
					
					
					
					if ("receiveAddressInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.request.ReceiveAddressInfo value;
						
						value = new com.vip.order.biz.request.ReceiveAddressInfo();
						com.vip.order.biz.request.ReceiveAddressInfoHelper.getInstance().Read(value, iprot);
						
						structs.SetReceiveAddressInfo(value);
					}
					
					
					
					
					
					if ("pmsInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.request.PmsInfo value;
						
						value = new com.vip.order.biz.request.PmsInfo();
						com.vip.order.biz.request.PmsInfoHelper.getInstance().Read(value, iprot);
						
						structs.SetPmsInfo(value);
					}
					
					
					
					
					
					if ("payAndDiscount".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.request.PayAndDiscount value;
						
						value = new com.vip.order.biz.request.PayAndDiscount();
						com.vip.order.biz.request.PayAndDiscountHelper.getInstance().Read(value, iprot);
						
						structs.SetPayAndDiscount(value);
					}
					
					
					
					
					
					if ("invoiceInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.request.InvoiceInfo value;
						
						value = new com.vip.order.biz.request.InvoiceInfo();
						com.vip.order.biz.request.InvoiceInfoHelper.getInstance().Read(value, iprot);
						
						structs.SetInvoiceInfo(value);
					}
					
					
					
					
					
					if ("customerSrc".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomerSrc(value);
					}
					
					
					
					
					
					if ("isCreateNewOrder".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsCreateNewOrder(value);
					}
					
					
					
					
					
					if ("isManjianEdit".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetIsManjianEdit(value);
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
		
		
		public void Write(ModifyOrderGoodsReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderCategory() != null) {
				
				oprot.WriteFieldBegin("orderCategory");
				oprot.WriteByte((byte)structs.GetOrderCategory()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetModifyGoodsOrder() != null) {
				
				oprot.WriteFieldBegin("modifyGoodsOrder");
				
				com.vip.order.biz.request.ModifyGoodsOrderHelper.getInstance().Write(structs.GetModifyGoodsOrder(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsInfoList() != null) {
				
				oprot.WriteFieldBegin("goodsInfoList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.request.NewGoodsInfo _item0 in structs.GetGoodsInfoList()){
					
					
					com.vip.order.biz.request.NewGoodsInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReceiveAddressInfo() != null) {
				
				oprot.WriteFieldBegin("receiveAddressInfo");
				
				com.vip.order.biz.request.ReceiveAddressInfoHelper.getInstance().Write(structs.GetReceiveAddressInfo(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPmsInfo() != null) {
				
				oprot.WriteFieldBegin("pmsInfo");
				
				com.vip.order.biz.request.PmsInfoHelper.getInstance().Write(structs.GetPmsInfo(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayAndDiscount() != null) {
				
				oprot.WriteFieldBegin("payAndDiscount");
				
				com.vip.order.biz.request.PayAndDiscountHelper.getInstance().Write(structs.GetPayAndDiscount(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoiceInfo() != null) {
				
				oprot.WriteFieldBegin("invoiceInfo");
				
				com.vip.order.biz.request.InvoiceInfoHelper.getInstance().Write(structs.GetInvoiceInfo(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustomerSrc() != null) {
				
				oprot.WriteFieldBegin("customerSrc");
				oprot.WriteString(structs.GetCustomerSrc());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsCreateNewOrder() != null) {
				
				oprot.WriteFieldBegin("isCreateNewOrder");
				oprot.WriteBool((bool)structs.GetIsCreateNewOrder());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsManjianEdit() != null) {
				
				oprot.WriteFieldBegin("isManjianEdit");
				oprot.WriteBool((bool)structs.GetIsManjianEdit());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ModifyOrderGoodsReq bean){
			
			
		}
		
	}
	
}