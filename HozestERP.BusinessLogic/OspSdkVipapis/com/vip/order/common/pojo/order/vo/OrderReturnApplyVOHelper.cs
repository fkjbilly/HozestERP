using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderReturnApplyVOHelper : TBeanSerializer<OrderReturnApplyVO>
	{
		
		public static OrderReturnApplyVOHelper OBJ = new OrderReturnApplyVOHelper();
		
		public static OrderReturnApplyVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderReturnApplyVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("applyId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetApplyId(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("returnReasonId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetReturnReasonId(value);
					}
					
					
					
					
					
					if ("returnReasonDetails".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnReasonDetails(value);
					}
					
					
					
					
					
					if ("resend".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetResend(value);
					}
					
					
					
					
					
					if ("returnGoodsTotalMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnGoodsTotalMoney(value);
					}
					
					
					
					
					
					if ("returnGoodsTotalAmount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturnGoodsTotalAmount(value);
					}
					
					
					
					
					
					if ("returnCarriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnCarriage(value);
					}
					
					
					
					
					
					if ("reimburseBackCarriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReimburseBackCarriage(value);
					}
					
					
					
					
					
					if ("returnCouponMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnCouponMoney(value);
					}
					
					
					
					
					
					if ("returnMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnMoney(value);
					}
					
					
					
					
					
					if ("returnWalletMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnWalletMoney(value);
					}
					
					
					
					
					
					if ("adjuctMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAdjuctMoney(value);
					}
					
					
					
					
					
					if ("actualBackCarriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetActualBackCarriage(value);
					}
					
					
					
					
					
					if ("refundType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetRefundType(value);
					}
					
					
					
					
					
					if ("backTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetBackTime(value);
					}
					
					
					
					
					
					if ("orderReturnType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderReturnType(value);
					}
					
					
					
					
					
					if ("auditStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAuditStatus(value);
					}
					
					
					
					
					
					if ("goodsBackWay".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetGoodsBackWay(value);
					}
					
					
					
					
					
					if ("returnsWayTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturnsWayTime(value);
					}
					
					
					
					
					
					if ("returnsAreaName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnsAreaName(value);
					}
					
					
					
					
					
					if ("returnsWayTimeInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnsWayTimeInfo(value);
					}
					
					
					
					
					
					if ("orderAfterStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderAfterStatus(value);
					}
					
					
					
					
					
					if ("orderAfterStatusUpdtime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderAfterStatusUpdtime(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
					}
					
					
					
					
					
					if ("backCarriagePayOnCollect".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetBackCarriagePayOnCollect(value);
					}
					
					
					
					
					
					if ("returnVirtualMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnVirtualMoney(value);
					}
					
					
					
					
					
					if ("extra1".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExtra1(value);
					}
					
					
					
					
					
					if ("refundFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetRefundFlag(value);
					}
					
					
					
					
					
					if ("skipAuditFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSkipAuditFlag(value);
					}
					
					
					
					
					
					if ("applyTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetApplyTime(value);
					}
					
					
					
					
					
					if ("bankId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBankId(value);
					}
					
					
					
					
					
					if ("bankName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBankName(value);
					}
					
					
					
					
					
					if ("bankBranch".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBankBranch(value);
					}
					
					
					
					
					
					if ("bankAccountName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBankAccountName(value);
					}
					
					
					
					
					
					if ("bankAccount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBankAccount(value);
					}
					
					
					
					
					
					if ("bankArea".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBankArea(value);
					}
					
					
					
					
					
					if ("backAddress".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBackAddress(value);
					}
					
					
					
					
					
					if ("fixCarriage".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFixCarriage(value);
					}
					
					
					
					
					
					if ("returnPackageMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnPackageMoney(value);
					}
					
					
					
					
					
					if ("returnGiftCardType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturnGiftCardType(value);
					}
					
					
					
					
					
					if ("giftCardToVirtualMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGiftCardToVirtualMoney(value);
					}
					
					
					
					
					
					if ("backFeeType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetBackFeeType(value);
					}
					
					
					
					
					
					if ("cardVirtualMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCardVirtualMoney(value);
					}
					
					
					
					
					
					if ("returnSubtotal".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnSubtotal(value);
					}
					
					
					
					
					
					if ("returnBankId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnBankId(value);
					}
					
					
					
					
					
					if ("returnBankName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnBankName(value);
					}
					
					
					
					
					
					if ("returnBankCard".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnBankCard(value);
					}
					
					
					
					
					
					if ("returnUserName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnUserName(value);
					}
					
					
					
					
					
					if ("merchantCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMerchantCode(value);
					}
					
					
					
					
					
					if ("pickupTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPickupTime(value);
					}
					
					
					
					
					
					if ("isPremium".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsPremium(value);
					}
					
					
					
					
					
					if ("vendorAuditFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorAuditFlag(value);
					}
					
					
					
					
					
					if ("sourceType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSourceType(value);
					}
					
					
					
					
					
					if ("returnWarehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturnWarehouse(value);
					}
					
					
					
					
					
					if ("operatorName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOperatorName(value);
					}
					
					
					
					
					
					if ("returnRefundType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturnRefundType(value);
					}
					
					
					
					
					
					if ("returnRefundStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetReturnRefundStatus(value);
					}
					
					
					
					
					
					if ("afterSaleSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAfterSaleSn(value);
					}
					
					
					
					
					
					if ("afterSaleStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetAfterSaleStatus(value);
					}
					
					
					
					
					
					if ("userRemark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserRemark(value);
					}
					
					
					
					
					
					if ("imageUrls".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetImageUrls(value);
					}
					
					
					
					
					
					if ("channelStoreId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetChannelStoreId(value);
					}
					
					
					
					
					
					if ("refundTotalMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRefundTotalMoney(value);
					}
					
					
					
					
					
					if ("orderRefundWayList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderRefundWayVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderRefundWayVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderRefundWayVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.OrderRefundWayVO();
								com.vip.order.common.pojo.order.vo.OrderRefundWayVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderRefundWayList(value);
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
		
		
		public void Write(OrderReturnApplyVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetApplyId() != null) {
				
				oprot.WriteFieldBegin("applyId");
				oprot.WriteI64((long)structs.GetApplyId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteI64((long)structs.GetOrderId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnReasonId() != null) {
				
				oprot.WriteFieldBegin("returnReasonId");
				oprot.WriteI64((long)structs.GetReturnReasonId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnReasonDetails() != null) {
				
				oprot.WriteFieldBegin("returnReasonDetails");
				oprot.WriteString(structs.GetReturnReasonDetails());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetResend() != null) {
				
				oprot.WriteFieldBegin("resend");
				oprot.WriteI32((int)structs.GetResend()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnGoodsTotalMoney() != null) {
				
				oprot.WriteFieldBegin("returnGoodsTotalMoney");
				oprot.WriteString(structs.GetReturnGoodsTotalMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnGoodsTotalAmount() != null) {
				
				oprot.WriteFieldBegin("returnGoodsTotalAmount");
				oprot.WriteI32((int)structs.GetReturnGoodsTotalAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnCarriage() != null) {
				
				oprot.WriteFieldBegin("returnCarriage");
				oprot.WriteString(structs.GetReturnCarriage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReimburseBackCarriage() != null) {
				
				oprot.WriteFieldBegin("reimburseBackCarriage");
				oprot.WriteString(structs.GetReimburseBackCarriage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnCouponMoney() != null) {
				
				oprot.WriteFieldBegin("returnCouponMoney");
				oprot.WriteString(structs.GetReturnCouponMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnMoney() != null) {
				
				oprot.WriteFieldBegin("returnMoney");
				oprot.WriteString(structs.GetReturnMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnWalletMoney() != null) {
				
				oprot.WriteFieldBegin("returnWalletMoney");
				oprot.WriteString(structs.GetReturnWalletMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAdjuctMoney() != null) {
				
				oprot.WriteFieldBegin("adjuctMoney");
				oprot.WriteString(structs.GetAdjuctMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActualBackCarriage() != null) {
				
				oprot.WriteFieldBegin("actualBackCarriage");
				oprot.WriteString(structs.GetActualBackCarriage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefundType() != null) {
				
				oprot.WriteFieldBegin("refundType");
				oprot.WriteI32((int)structs.GetRefundType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBackTime() != null) {
				
				oprot.WriteFieldBegin("backTime");
				oprot.WriteI64((long)structs.GetBackTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderReturnType() != null) {
				
				oprot.WriteFieldBegin("orderReturnType");
				oprot.WriteI32((int)structs.GetOrderReturnType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAuditStatus() != null) {
				
				oprot.WriteFieldBegin("auditStatus");
				oprot.WriteI32((int)structs.GetAuditStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsBackWay() != null) {
				
				oprot.WriteFieldBegin("goodsBackWay");
				oprot.WriteI32((int)structs.GetGoodsBackWay()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnsWayTime() != null) {
				
				oprot.WriteFieldBegin("returnsWayTime");
				oprot.WriteI32((int)structs.GetReturnsWayTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnsAreaName() != null) {
				
				oprot.WriteFieldBegin("returnsAreaName");
				oprot.WriteString(structs.GetReturnsAreaName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnsWayTimeInfo() != null) {
				
				oprot.WriteFieldBegin("returnsWayTimeInfo");
				oprot.WriteString(structs.GetReturnsWayTimeInfo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderAfterStatus() != null) {
				
				oprot.WriteFieldBegin("orderAfterStatus");
				oprot.WriteI32((int)structs.GetOrderAfterStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderAfterStatusUpdtime() != null) {
				
				oprot.WriteFieldBegin("orderAfterStatusUpdtime");
				oprot.WriteI64((long)structs.GetOrderAfterStatusUpdtime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBackCarriagePayOnCollect() != null) {
				
				oprot.WriteFieldBegin("backCarriagePayOnCollect");
				oprot.WriteI32((int)structs.GetBackCarriagePayOnCollect()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnVirtualMoney() != null) {
				
				oprot.WriteFieldBegin("returnVirtualMoney");
				oprot.WriteString(structs.GetReturnVirtualMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExtra1() != null) {
				
				oprot.WriteFieldBegin("extra1");
				oprot.WriteString(structs.GetExtra1());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefundFlag() != null) {
				
				oprot.WriteFieldBegin("refundFlag");
				oprot.WriteI32((int)structs.GetRefundFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSkipAuditFlag() != null) {
				
				oprot.WriteFieldBegin("skipAuditFlag");
				oprot.WriteI32((int)structs.GetSkipAuditFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetApplyTime() != null) {
				
				oprot.WriteFieldBegin("applyTime");
				oprot.WriteI64((long)structs.GetApplyTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBankId() != null) {
				
				oprot.WriteFieldBegin("bankId");
				oprot.WriteString(structs.GetBankId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBankName() != null) {
				
				oprot.WriteFieldBegin("bankName");
				oprot.WriteString(structs.GetBankName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBankBranch() != null) {
				
				oprot.WriteFieldBegin("bankBranch");
				oprot.WriteString(structs.GetBankBranch());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBankAccountName() != null) {
				
				oprot.WriteFieldBegin("bankAccountName");
				oprot.WriteString(structs.GetBankAccountName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBankAccount() != null) {
				
				oprot.WriteFieldBegin("bankAccount");
				oprot.WriteString(structs.GetBankAccount());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBankArea() != null) {
				
				oprot.WriteFieldBegin("bankArea");
				oprot.WriteString(structs.GetBankArea());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBackAddress() != null) {
				
				oprot.WriteFieldBegin("backAddress");
				oprot.WriteString(structs.GetBackAddress());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFixCarriage() != null) {
				
				oprot.WriteFieldBegin("fixCarriage");
				oprot.WriteString(structs.GetFixCarriage());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnPackageMoney() != null) {
				
				oprot.WriteFieldBegin("returnPackageMoney");
				oprot.WriteString(structs.GetReturnPackageMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnGiftCardType() != null) {
				
				oprot.WriteFieldBegin("returnGiftCardType");
				oprot.WriteI32((int)structs.GetReturnGiftCardType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGiftCardToVirtualMoney() != null) {
				
				oprot.WriteFieldBegin("giftCardToVirtualMoney");
				oprot.WriteString(structs.GetGiftCardToVirtualMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBackFeeType() != null) {
				
				oprot.WriteFieldBegin("backFeeType");
				oprot.WriteI32((int)structs.GetBackFeeType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCardVirtualMoney() != null) {
				
				oprot.WriteFieldBegin("cardVirtualMoney");
				oprot.WriteString(structs.GetCardVirtualMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnSubtotal() != null) {
				
				oprot.WriteFieldBegin("returnSubtotal");
				oprot.WriteString(structs.GetReturnSubtotal());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnBankId() != null) {
				
				oprot.WriteFieldBegin("returnBankId");
				oprot.WriteString(structs.GetReturnBankId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnBankName() != null) {
				
				oprot.WriteFieldBegin("returnBankName");
				oprot.WriteString(structs.GetReturnBankName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnBankCard() != null) {
				
				oprot.WriteFieldBegin("returnBankCard");
				oprot.WriteString(structs.GetReturnBankCard());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnUserName() != null) {
				
				oprot.WriteFieldBegin("returnUserName");
				oprot.WriteString(structs.GetReturnUserName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerchantCode() != null) {
				
				oprot.WriteFieldBegin("merchantCode");
				oprot.WriteString(structs.GetMerchantCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPickupTime() != null) {
				
				oprot.WriteFieldBegin("pickupTime");
				oprot.WriteString(structs.GetPickupTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsPremium() != null) {
				
				oprot.WriteFieldBegin("isPremium");
				oprot.WriteI32((int)structs.GetIsPremium()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendorAuditFlag() != null) {
				
				oprot.WriteFieldBegin("vendorAuditFlag");
				oprot.WriteI32((int)structs.GetVendorAuditFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSourceType() != null) {
				
				oprot.WriteFieldBegin("sourceType");
				oprot.WriteI32((int)structs.GetSourceType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnWarehouse() != null) {
				
				oprot.WriteFieldBegin("returnWarehouse");
				oprot.WriteString(structs.GetReturnWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOperatorName() != null) {
				
				oprot.WriteFieldBegin("operatorName");
				oprot.WriteString(structs.GetOperatorName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnRefundType() != null) {
				
				oprot.WriteFieldBegin("returnRefundType");
				oprot.WriteI32((int)structs.GetReturnRefundType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnRefundStatus() != null) {
				
				oprot.WriteFieldBegin("returnRefundStatus");
				oprot.WriteI32((int)structs.GetReturnRefundStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAfterSaleSn() != null) {
				
				oprot.WriteFieldBegin("afterSaleSn");
				oprot.WriteString(structs.GetAfterSaleSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAfterSaleStatus() != null) {
				
				oprot.WriteFieldBegin("afterSaleStatus");
				oprot.WriteI32((int)structs.GetAfterSaleStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserRemark() != null) {
				
				oprot.WriteFieldBegin("userRemark");
				oprot.WriteString(structs.GetUserRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetImageUrls() != null) {
				
				oprot.WriteFieldBegin("imageUrls");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetImageUrls()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetChannelStoreId() != null) {
				
				oprot.WriteFieldBegin("channelStoreId");
				oprot.WriteString(structs.GetChannelStoreId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefundTotalMoney() != null) {
				
				oprot.WriteFieldBegin("refundTotalMoney");
				oprot.WriteString(structs.GetRefundTotalMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderRefundWayList() != null) {
				
				oprot.WriteFieldBegin("orderRefundWayList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderRefundWayVO _item0 in structs.GetOrderRefundWayList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderRefundWayVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderReturnApplyVO bean){
			
			
		}
		
	}
	
}