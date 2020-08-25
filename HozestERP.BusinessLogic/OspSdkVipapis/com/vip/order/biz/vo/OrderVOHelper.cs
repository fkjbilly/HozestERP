using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.vo{
	
	
	
	public class OrderVOHelper : TBeanSerializer<OrderVO>
	{
		
		public static OrderVOHelper OBJ = new OrderVOHelper();
		
		public static OrderVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
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
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("userName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserName(value);
					}
					
					
					
					
					
					if ("userIp".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserIp(value);
					}
					
					
					
					
					
					if ("unionMark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUnionMark(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("saleType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSaleType(value);
					}
					
					
					
					
					
					if ("source".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSource(value);
					}
					
					
					
					
					
					if ("addrWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddrWarehouse(value);
					}
					
					
					
					
					
					if ("isJf".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsJf(value);
					}
					
					
					
					
					
					if ("platform".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPlatform(value);
					}
					
					
					
					
					
					if ("saleArea".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSaleArea(value);
					}
					
					
					
					
					
					if ("vipCard".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipCard(value);
					}
					
					
					
					
					
					if ("isPos".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsPos(value);
					}
					
					
					
					
					
					if ("carriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarriage(value);
					}
					
					
					
					
					
					if ("orderSourceType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSourceType(value);
					}
					
					
					
					
					
					if ("orderDate".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderDate(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
					}
					
					
					
					
					
					if ("orderUpdateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderUpdateTime(value);
					}
					
					
					
					
					
					if ("orderStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderStatus(value);
					}
					
					
					
					
					
					if ("orderStatusUpdateTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderStatusUpdateTime(value);
					}
					
					
					
					
					
					if ("wmsFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetWmsFlag(value);
					}
					
					
					
					
					
					if ("goodsAmount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetGoodsAmount(value);
					}
					
					
					
					
					
					if ("orderType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderType(value);
					}
					
					
					
					
					
					if ("orderSubStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderSubStatus(value);
					}
					
					
					
					
					
					if ("orderAddTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderAddTime(value);
					}
					
					
					
					
					
					if ("orderModel".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderModel(value);
					}
					
					
					
					
					
					if ("auditTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetAuditTime(value);
					}
					
					
					
					
					
					if ("adminRemark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAdminRemark(value);
					}
					
					
					
					
					
					if ("adminSms".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAdminSms(value);
					}
					
					
					
					
					
					if ("hasAlert".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetHasAlert(value);
					}
					
					
					
					
					
					if ("smsSended".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSmsSended(value);
					}
					
					
					
					
					
					if ("opFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOpFlag(value);
					}
					
					
					
					
					
					if ("operator".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOperator(value);
					}
					
					
					
					
					
					if ("refuseGoodsType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetRefuseGoodsType(value);
					}
					
					
					
					
					
					if ("unpassReason".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUnpassReason(value);
					}
					
					
					
					
					
					if ("transportType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportType(value);
					}
					
					
					
					
					
					if ("specialTransportText".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSpecialTransportText(value);
					}
					
					
					
					
					
					if ("orderFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderFlag(value);
					}
					
					
					
					
					
					if ("isReturnSurplus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsReturnSurplus(value);
					}
					
					
					
					
					
					if ("surplusBack".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSurplusBack(value);
					}
					
					
					
					
					
					if ("transportName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportName(value);
					}
					
					
					
					
					
					if ("transportNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportNo(value);
					}
					
					
					
					
					
					if ("transportId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTransportId(value);
					}
					
					
					
					
					
					if ("presentInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPresentInfo(value);
					}
					
					
					
					
					
					if ("isSpecial".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsSpecial(value);
					}
					
					
					
					
					
					if ("isLink".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsLink(value);
					}
					
					
					
					
					
					if ("isSplit".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsSplit(value);
					}
					
					
					
					
					
					if ("isHold".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsHold(value);
					}
					
					
					
					
					
					if ("isDisplay".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsDisplay(value);
					}
					
					
					
					
					
					if ("vipclub".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipclub(value);
					}
					
					
					
					
					
					if ("posTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetPosTime(value);
					}
					
					
					
					
					
					if ("giftOrPointFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetGiftOrPointFlag(value);
					}
					
					
					
					
					
					if ("allotTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetAllotTime(value);
					}
					
					
					
					
					
					if ("allotUser".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAllotUser(value);
					}
					
					
					
					
					
					if ("firstFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetFirstFlag(value);
					}
					
					
					
					
					
					if ("statusFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetStatusFlag(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetCreateTime(value);
					}
					
					
					
					
					
					if ("posTimeFormat".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPosTimeFormat(value);
					}
					
					
					
					
					
					if ("longTransportId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetLongTransportId(value);
					}
					
					
					
					
					
					if ("orderBizFlagsMap".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, int?> value;
						
						value = new Dictionary<string, int?>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key1;
								int _val1;
								_key1 = iprot.ReadString();
								
								_val1 = iprot.ReadI32(); 
								
								value.Add(_key1, _val1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetOrderBizFlagsMap(value);
					}
					
					
					
					
					
					if ("orderBizFlags".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderBizFlags(value);
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
		
		
		public void Write(OrderVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
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
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserName() != null) {
				
				oprot.WriteFieldBegin("userName");
				oprot.WriteString(structs.GetUserName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserIp() != null) {
				
				oprot.WriteFieldBegin("userIp");
				oprot.WriteString(structs.GetUserIp());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnionMark() != null) {
				
				oprot.WriteFieldBegin("unionMark");
				oprot.WriteString(structs.GetUnionMark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSaleType() != null) {
				
				oprot.WriteFieldBegin("saleType");
				oprot.WriteI32((int)structs.GetSaleType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSource() != null) {
				
				oprot.WriteFieldBegin("source");
				oprot.WriteString(structs.GetSource());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddrWarehouse() != null) {
				
				oprot.WriteFieldBegin("addrWarehouse");
				oprot.WriteString(structs.GetAddrWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsJf() != null) {
				
				oprot.WriteFieldBegin("isJf");
				oprot.WriteI32((int)structs.GetIsJf()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPlatform() != null) {
				
				oprot.WriteFieldBegin("platform");
				oprot.WriteI32((int)structs.GetPlatform()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSaleArea() != null) {
				
				oprot.WriteFieldBegin("saleArea");
				oprot.WriteI32((int)structs.GetSaleArea()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipCard() != null) {
				
				oprot.WriteFieldBegin("vipCard");
				oprot.WriteString(structs.GetVipCard());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsPos() != null) {
				
				oprot.WriteFieldBegin("isPos");
				oprot.WriteI32((int)structs.GetIsPos()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCarriage() != null) {
				
				oprot.WriteFieldBegin("carriage");
				oprot.WriteString(structs.GetCarriage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSourceType() != null) {
				
				oprot.WriteFieldBegin("orderSourceType");
				oprot.WriteString(structs.GetOrderSourceType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderDate() != null) {
				
				oprot.WriteFieldBegin("orderDate");
				oprot.WriteI64((long)structs.GetOrderDate()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderUpdateTime() != null) {
				
				oprot.WriteFieldBegin("orderUpdateTime");
				oprot.WriteI64((long)structs.GetOrderUpdateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderStatus() != null) {
				
				oprot.WriteFieldBegin("orderStatus");
				oprot.WriteI32((int)structs.GetOrderStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderStatusUpdateTime() != null) {
				
				oprot.WriteFieldBegin("orderStatusUpdateTime");
				oprot.WriteI64((long)structs.GetOrderStatusUpdateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWmsFlag() != null) {
				
				oprot.WriteFieldBegin("wmsFlag");
				oprot.WriteI32((int)structs.GetWmsFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsAmount() != null) {
				
				oprot.WriteFieldBegin("goodsAmount");
				oprot.WriteI32((int)structs.GetGoodsAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderType() != null) {
				
				oprot.WriteFieldBegin("orderType");
				oprot.WriteI32((int)structs.GetOrderType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSubStatus() != null) {
				
				oprot.WriteFieldBegin("orderSubStatus");
				oprot.WriteI32((int)structs.GetOrderSubStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderAddTime() != null) {
				
				oprot.WriteFieldBegin("orderAddTime");
				oprot.WriteI64((long)structs.GetOrderAddTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderModel() != null) {
				
				oprot.WriteFieldBegin("orderModel");
				oprot.WriteI32((int)structs.GetOrderModel()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAuditTime() != null) {
				
				oprot.WriteFieldBegin("auditTime");
				oprot.WriteI64((long)structs.GetAuditTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAdminRemark() != null) {
				
				oprot.WriteFieldBegin("adminRemark");
				oprot.WriteString(structs.GetAdminRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAdminSms() != null) {
				
				oprot.WriteFieldBegin("adminSms");
				oprot.WriteString(structs.GetAdminSms());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHasAlert() != null) {
				
				oprot.WriteFieldBegin("hasAlert");
				oprot.WriteString(structs.GetHasAlert());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSmsSended() != null) {
				
				oprot.WriteFieldBegin("smsSended");
				oprot.WriteString(structs.GetSmsSended());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOpFlag() != null) {
				
				oprot.WriteFieldBegin("opFlag");
				oprot.WriteI32((int)structs.GetOpFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOperator() != null) {
				
				oprot.WriteFieldBegin("operator");
				oprot.WriteString(structs.GetOperator());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefuseGoodsType() != null) {
				
				oprot.WriteFieldBegin("refuseGoodsType");
				oprot.WriteI32((int)structs.GetRefuseGoodsType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnpassReason() != null) {
				
				oprot.WriteFieldBegin("unpassReason");
				oprot.WriteString(structs.GetUnpassReason());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportType() != null) {
				
				oprot.WriteFieldBegin("transportType");
				oprot.WriteString(structs.GetTransportType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSpecialTransportText() != null) {
				
				oprot.WriteFieldBegin("specialTransportText");
				oprot.WriteString(structs.GetSpecialTransportText());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderFlag() != null) {
				
				oprot.WriteFieldBegin("orderFlag");
				oprot.WriteString(structs.GetOrderFlag());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsReturnSurplus() != null) {
				
				oprot.WriteFieldBegin("isReturnSurplus");
				oprot.WriteI32((int)structs.GetIsReturnSurplus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSurplusBack() != null) {
				
				oprot.WriteFieldBegin("surplusBack");
				oprot.WriteString(structs.GetSurplusBack());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportName() != null) {
				
				oprot.WriteFieldBegin("transportName");
				oprot.WriteString(structs.GetTransportName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportNo() != null) {
				
				oprot.WriteFieldBegin("transportNo");
				oprot.WriteString(structs.GetTransportNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportId() != null) {
				
				oprot.WriteFieldBegin("transportId");
				oprot.WriteI32((int)structs.GetTransportId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPresentInfo() != null) {
				
				oprot.WriteFieldBegin("presentInfo");
				oprot.WriteString(structs.GetPresentInfo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsSpecial() != null) {
				
				oprot.WriteFieldBegin("isSpecial");
				oprot.WriteI32((int)structs.GetIsSpecial()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsLink() != null) {
				
				oprot.WriteFieldBegin("isLink");
				oprot.WriteI32((int)structs.GetIsLink()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsSplit() != null) {
				
				oprot.WriteFieldBegin("isSplit");
				oprot.WriteI32((int)structs.GetIsSplit()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsHold() != null) {
				
				oprot.WriteFieldBegin("isHold");
				oprot.WriteI32((int)structs.GetIsHold()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsDisplay() != null) {
				
				oprot.WriteFieldBegin("isDisplay");
				oprot.WriteI32((int)structs.GetIsDisplay()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipclub() != null) {
				
				oprot.WriteFieldBegin("vipclub");
				oprot.WriteString(structs.GetVipclub());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPosTime() != null) {
				
				oprot.WriteFieldBegin("posTime");
				oprot.WriteI64((long)structs.GetPosTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGiftOrPointFlag() != null) {
				
				oprot.WriteFieldBegin("giftOrPointFlag");
				oprot.WriteBool((bool)structs.GetGiftOrPointFlag());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAllotTime() != null) {
				
				oprot.WriteFieldBegin("allotTime");
				oprot.WriteI64((long)structs.GetAllotTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAllotUser() != null) {
				
				oprot.WriteFieldBegin("allotUser");
				oprot.WriteString(structs.GetAllotUser());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFirstFlag() != null) {
				
				oprot.WriteFieldBegin("firstFlag");
				oprot.WriteI32((int)structs.GetFirstFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatusFlag() != null) {
				
				oprot.WriteFieldBegin("statusFlag");
				oprot.WriteI32((int)structs.GetStatusFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteI64((long)structs.GetCreateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPosTimeFormat() != null) {
				
				oprot.WriteFieldBegin("posTimeFormat");
				oprot.WriteString(structs.GetPosTimeFormat());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLongTransportId() != null) {
				
				oprot.WriteFieldBegin("longTransportId");
				oprot.WriteI64((long)structs.GetLongTransportId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderBizFlagsMap() != null) {
				
				oprot.WriteFieldBegin("orderBizFlagsMap");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, int? > _ir0 in structs.GetOrderBizFlagsMap()){
					
					string _key0 = _ir0.Key;
					int? _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					oprot.WriteI32((int)_value0); 
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderBizFlags() != null) {
				
				oprot.WriteFieldBegin("orderBizFlags");
				oprot.WriteI32((int)structs.GetOrderBizFlags()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderVO bean){
			
			
		}
		
	}
	
}