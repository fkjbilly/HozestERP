using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderReturnApplyVO {
		
		///<summary>
		/// 订单售后申请ID
		///</summary>
		
		private long? applyId_;
		
		///<summary>
		/// 用户id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 退货原因ID
		///</summary>
		
		private long? returnReasonId_;
		
		///<summary>
		/// 退货原因
		///</summary>
		
		private string returnReasonDetails_;
		
		///<summary>
		/// 是否重发
		///</summary>
		
		private int? resend_;
		
		///<summary>
		/// 关联售后单商品总金额
		///</summary>
		
		private string returnGoodsTotalMoney_;
		
		///<summary>
		/// 关联售后单商品总数量
		///</summary>
		
		private int? returnGoodsTotalAmount_;
		
		///<summary>
		/// 运费价格
		///</summary>
		
		private string returnCarriage_;
		
		///<summary>
		/// 是否退回运费
		///</summary>
		
		private string reimburseBackCarriage_;
		
		///<summary>
		/// 退回唯品卡金额
		///</summary>
		
		private string returnCouponMoney_;
		
		///<summary>
		/// 原路退回金额
		///</summary>
		
		private string returnMoney_;
		
		///<summary>
		/// 退回零钱金额
		///</summary>
		
		private string returnWalletMoney_;
		
		///<summary>
		/// 调整金额
		///</summary>
		
		private string adjuctMoney_;
		
		///<summary>
		/// 退回寄运费的金额
		///</summary>
		
		private string actualBackCarriage_;
		
		///<summary>
		/// 退款方式
		///</summary>
		
		private int? refundType_;
		
		///<summary>
		/// 退货退回时间
		///</summary>
		
		private long? backTime_;
		
		///<summary>
		/// 售后单类型
		///</summary>
		
		private int? orderReturnType_;
		
		///<summary>
		/// 审核状态
		///</summary>
		
		private int? auditStatus_;
		
		///<summary>
		/// 货退返回方式
		///</summary>
		
		private int? goodsBackWay_;
		
		///<summary>
		/// 货退取货时间类型
		///</summary>
		
		private int? returnsWayTime_;
		
		///<summary>
		/// 货退取货区域
		///</summary>
		
		private string returnsAreaName_;
		
		///<summary>
		/// 货退取货时间说明信息
		///</summary>
		
		private string returnsWayTimeInfo_;
		
		///<summary>
		/// 订单售后状态
		///</summary>
		
		private int? orderAfterStatus_;
		
		///<summary>
		/// 订单售后状态更新时间
		///</summary>
		
		private long? orderAfterStatusUpdtime_;
		
		///<summary>
		/// 说明
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 退货时是否可以到付
		///</summary>
		
		private int? backCarriagePayOnCollect_;
		
		///<summary>
		/// 退回的虚拟金额
		///</summary>
		
		private string returnVirtualMoney_;
		
		///<summary>
		/// 售后申请单扩展字段
		///</summary>
		
		private string extra1_;
		
		///<summary>
		/// 是否极速退的标志位:1-不是2-是3-特殊退款4-征信极速退退款5-上门揽退极速退退款
		///</summary>
		
		private int? refundFlag_;
		
		///<summary>
		/// 供应商订单审核标识:1不需要审核2需要审核
		///</summary>
		
		private int? skipAuditFlag_;
		
		///<summary>
		/// 售后申请时间
		///</summary>
		
		private long? applyTime_;
		
		///<summary>
		/// 绑卡id(乐蜂货到付款订单必传)
		///</summary>
		
		private string bankId_;
		
		///<summary>
		/// 收退款银行名称)
		///</summary>
		
		private string bankName_;
		
		///<summary>
		/// 收退款银行支行名称)
		///</summary>
		
		private string bankBranch_;
		
		///<summary>
		/// 收退款银行账号姓名)
		///</summary>
		
		private string bankAccountName_;
		
		///<summary>
		/// 收退款银行账号)
		///</summary>
		
		private string bankAccount_;
		
		///<summary>
		/// 银行区域)
		///</summary>
		
		private string bankArea_;
		
		///<summary>
		/// 收货地址)
		///</summary>
		
		private string backAddress_;
		
		///<summary>
		/// 固定运费
		///</summary>
		
		private string fixCarriage_;
		
		///<summary>
		/// 唯宝红包退红包金额
		///</summary>
		
		private string returnPackageMoney_;
		
		///<summary>
		/// 1退唯品币 2退礼品卡
		///</summary>
		
		private int? returnGiftCardType_;
		
		///<summary>
		/// 退礼品卡转唯品币金额
		///</summary>
		
		private string giftCardToVirtualMoney_;
		
		///<summary>
		/// 回寄运费补贴类型
		///</summary>
		
		private int? backFeeType_;
		
		///<summary>
		/// 礼品卡转唯品币金额
		///</summary>
		
		private string cardVirtualMoney_;
		
		///<summary>
		/// 总商品价格小计
		///</summary>
		
		private string returnSubtotal_;
		
		///<summary>
		/// 乐蜂货到退款绑卡id
		///</summary>
		
		private string returnBankId_;
		
		///<summary>
		/// 乐蜂货到退款开户行
		///</summary>
		
		private string returnBankName_;
		
		///<summary>
		/// 乐蜂货到退款银行卡号
		///</summary>
		
		private string returnBankCard_;
		
		///<summary>
		/// 乐蜂货到退款用户名
		///</summary>
		
		private string returnUserName_;
		
		///<summary>
		/// 乐峰商户号
		///</summary>
		
		private string merchantCode_;
		
		///<summary>
		/// 上门揽退时间段
		///</summary>
		
		private string pickupTime_;
		
		///<summary>
		/// 付费会员标识， 2-是， 1-不是 
		///</summary>
		
		private int? isPremium_;
		
		///<summary>
		/// 0:非供应商审核 1:供应商可审核
		///</summary>
		
		private int? vendorAuditFlag_;
		
		///<summary>
		/// 1:未知 2:PC 3:APP 4:短信 5:CSC 6:内部调用
		///</summary>
		
		private int? sourceType_;
		
		///<summary>
		/// 回寄仓
		///</summary>
		
		private string returnWarehouse_;
		
		///<summary>
		/// 操作人名称
		///</summary>
		
		private string operatorName_;
		
		///<summary>
		/// 退款类型:1-普通退款，2-普通极速退款，3-征信极速退款，4-特殊退款
		///</summary>
		
		private int? returnRefundType_;
		
		///<summary>
		/// 退款状态:1-未发起退款，2-已发起退款，99-无需退款
		///</summary>
		
		private int? returnRefundStatus_;
		
		///<summary>
		/// 售后单SN
		///</summary>
		
		private string afterSaleSn_;
		
		///<summary>
		/// 售后单新状态
		///</summary>
		
		private int? afterSaleStatus_;
		
		///<summary>
		/// 用户填写的备注, 最长250
		///</summary>
		
		private string userRemark_;
		
		///<summary>
		/// 退货单用户上传的图片地址
		///</summary>
		
		private List<string> imageUrls_;
		
		///<summary>
		/// 品仓订单小b店铺id
		///</summary>
		
		private string channelStoreId_;
		
		///<summary>
		/// 退款总金额
		///</summary>
		
		private string refundTotalMoney_;
		
		///<summary>
		/// 退款路径明细
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderRefundWayVO> orderRefundWayList_;
		
		public long? GetApplyId(){
			return this.applyId_;
		}
		
		public void SetApplyId(long? value){
			this.applyId_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public long? GetReturnReasonId(){
			return this.returnReasonId_;
		}
		
		public void SetReturnReasonId(long? value){
			this.returnReasonId_ = value;
		}
		public string GetReturnReasonDetails(){
			return this.returnReasonDetails_;
		}
		
		public void SetReturnReasonDetails(string value){
			this.returnReasonDetails_ = value;
		}
		public int? GetResend(){
			return this.resend_;
		}
		
		public void SetResend(int? value){
			this.resend_ = value;
		}
		public string GetReturnGoodsTotalMoney(){
			return this.returnGoodsTotalMoney_;
		}
		
		public void SetReturnGoodsTotalMoney(string value){
			this.returnGoodsTotalMoney_ = value;
		}
		public int? GetReturnGoodsTotalAmount(){
			return this.returnGoodsTotalAmount_;
		}
		
		public void SetReturnGoodsTotalAmount(int? value){
			this.returnGoodsTotalAmount_ = value;
		}
		public string GetReturnCarriage(){
			return this.returnCarriage_;
		}
		
		public void SetReturnCarriage(string value){
			this.returnCarriage_ = value;
		}
		public string GetReimburseBackCarriage(){
			return this.reimburseBackCarriage_;
		}
		
		public void SetReimburseBackCarriage(string value){
			this.reimburseBackCarriage_ = value;
		}
		public string GetReturnCouponMoney(){
			return this.returnCouponMoney_;
		}
		
		public void SetReturnCouponMoney(string value){
			this.returnCouponMoney_ = value;
		}
		public string GetReturnMoney(){
			return this.returnMoney_;
		}
		
		public void SetReturnMoney(string value){
			this.returnMoney_ = value;
		}
		public string GetReturnWalletMoney(){
			return this.returnWalletMoney_;
		}
		
		public void SetReturnWalletMoney(string value){
			this.returnWalletMoney_ = value;
		}
		public string GetAdjuctMoney(){
			return this.adjuctMoney_;
		}
		
		public void SetAdjuctMoney(string value){
			this.adjuctMoney_ = value;
		}
		public string GetActualBackCarriage(){
			return this.actualBackCarriage_;
		}
		
		public void SetActualBackCarriage(string value){
			this.actualBackCarriage_ = value;
		}
		public int? GetRefundType(){
			return this.refundType_;
		}
		
		public void SetRefundType(int? value){
			this.refundType_ = value;
		}
		public long? GetBackTime(){
			return this.backTime_;
		}
		
		public void SetBackTime(long? value){
			this.backTime_ = value;
		}
		public int? GetOrderReturnType(){
			return this.orderReturnType_;
		}
		
		public void SetOrderReturnType(int? value){
			this.orderReturnType_ = value;
		}
		public int? GetAuditStatus(){
			return this.auditStatus_;
		}
		
		public void SetAuditStatus(int? value){
			this.auditStatus_ = value;
		}
		public int? GetGoodsBackWay(){
			return this.goodsBackWay_;
		}
		
		public void SetGoodsBackWay(int? value){
			this.goodsBackWay_ = value;
		}
		public int? GetReturnsWayTime(){
			return this.returnsWayTime_;
		}
		
		public void SetReturnsWayTime(int? value){
			this.returnsWayTime_ = value;
		}
		public string GetReturnsAreaName(){
			return this.returnsAreaName_;
		}
		
		public void SetReturnsAreaName(string value){
			this.returnsAreaName_ = value;
		}
		public string GetReturnsWayTimeInfo(){
			return this.returnsWayTimeInfo_;
		}
		
		public void SetReturnsWayTimeInfo(string value){
			this.returnsWayTimeInfo_ = value;
		}
		public int? GetOrderAfterStatus(){
			return this.orderAfterStatus_;
		}
		
		public void SetOrderAfterStatus(int? value){
			this.orderAfterStatus_ = value;
		}
		public long? GetOrderAfterStatusUpdtime(){
			return this.orderAfterStatusUpdtime_;
		}
		
		public void SetOrderAfterStatusUpdtime(long? value){
			this.orderAfterStatusUpdtime_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public int? GetBackCarriagePayOnCollect(){
			return this.backCarriagePayOnCollect_;
		}
		
		public void SetBackCarriagePayOnCollect(int? value){
			this.backCarriagePayOnCollect_ = value;
		}
		public string GetReturnVirtualMoney(){
			return this.returnVirtualMoney_;
		}
		
		public void SetReturnVirtualMoney(string value){
			this.returnVirtualMoney_ = value;
		}
		public string GetExtra1(){
			return this.extra1_;
		}
		
		public void SetExtra1(string value){
			this.extra1_ = value;
		}
		public int? GetRefundFlag(){
			return this.refundFlag_;
		}
		
		public void SetRefundFlag(int? value){
			this.refundFlag_ = value;
		}
		public int? GetSkipAuditFlag(){
			return this.skipAuditFlag_;
		}
		
		public void SetSkipAuditFlag(int? value){
			this.skipAuditFlag_ = value;
		}
		public long? GetApplyTime(){
			return this.applyTime_;
		}
		
		public void SetApplyTime(long? value){
			this.applyTime_ = value;
		}
		public string GetBankId(){
			return this.bankId_;
		}
		
		public void SetBankId(string value){
			this.bankId_ = value;
		}
		public string GetBankName(){
			return this.bankName_;
		}
		
		public void SetBankName(string value){
			this.bankName_ = value;
		}
		public string GetBankBranch(){
			return this.bankBranch_;
		}
		
		public void SetBankBranch(string value){
			this.bankBranch_ = value;
		}
		public string GetBankAccountName(){
			return this.bankAccountName_;
		}
		
		public void SetBankAccountName(string value){
			this.bankAccountName_ = value;
		}
		public string GetBankAccount(){
			return this.bankAccount_;
		}
		
		public void SetBankAccount(string value){
			this.bankAccount_ = value;
		}
		public string GetBankArea(){
			return this.bankArea_;
		}
		
		public void SetBankArea(string value){
			this.bankArea_ = value;
		}
		public string GetBackAddress(){
			return this.backAddress_;
		}
		
		public void SetBackAddress(string value){
			this.backAddress_ = value;
		}
		public string GetFixCarriage(){
			return this.fixCarriage_;
		}
		
		public void SetFixCarriage(string value){
			this.fixCarriage_ = value;
		}
		public string GetReturnPackageMoney(){
			return this.returnPackageMoney_;
		}
		
		public void SetReturnPackageMoney(string value){
			this.returnPackageMoney_ = value;
		}
		public int? GetReturnGiftCardType(){
			return this.returnGiftCardType_;
		}
		
		public void SetReturnGiftCardType(int? value){
			this.returnGiftCardType_ = value;
		}
		public string GetGiftCardToVirtualMoney(){
			return this.giftCardToVirtualMoney_;
		}
		
		public void SetGiftCardToVirtualMoney(string value){
			this.giftCardToVirtualMoney_ = value;
		}
		public int? GetBackFeeType(){
			return this.backFeeType_;
		}
		
		public void SetBackFeeType(int? value){
			this.backFeeType_ = value;
		}
		public string GetCardVirtualMoney(){
			return this.cardVirtualMoney_;
		}
		
		public void SetCardVirtualMoney(string value){
			this.cardVirtualMoney_ = value;
		}
		public string GetReturnSubtotal(){
			return this.returnSubtotal_;
		}
		
		public void SetReturnSubtotal(string value){
			this.returnSubtotal_ = value;
		}
		public string GetReturnBankId(){
			return this.returnBankId_;
		}
		
		public void SetReturnBankId(string value){
			this.returnBankId_ = value;
		}
		public string GetReturnBankName(){
			return this.returnBankName_;
		}
		
		public void SetReturnBankName(string value){
			this.returnBankName_ = value;
		}
		public string GetReturnBankCard(){
			return this.returnBankCard_;
		}
		
		public void SetReturnBankCard(string value){
			this.returnBankCard_ = value;
		}
		public string GetReturnUserName(){
			return this.returnUserName_;
		}
		
		public void SetReturnUserName(string value){
			this.returnUserName_ = value;
		}
		public string GetMerchantCode(){
			return this.merchantCode_;
		}
		
		public void SetMerchantCode(string value){
			this.merchantCode_ = value;
		}
		public string GetPickupTime(){
			return this.pickupTime_;
		}
		
		public void SetPickupTime(string value){
			this.pickupTime_ = value;
		}
		public int? GetIsPremium(){
			return this.isPremium_;
		}
		
		public void SetIsPremium(int? value){
			this.isPremium_ = value;
		}
		public int? GetVendorAuditFlag(){
			return this.vendorAuditFlag_;
		}
		
		public void SetVendorAuditFlag(int? value){
			this.vendorAuditFlag_ = value;
		}
		public int? GetSourceType(){
			return this.sourceType_;
		}
		
		public void SetSourceType(int? value){
			this.sourceType_ = value;
		}
		public string GetReturnWarehouse(){
			return this.returnWarehouse_;
		}
		
		public void SetReturnWarehouse(string value){
			this.returnWarehouse_ = value;
		}
		public string GetOperatorName(){
			return this.operatorName_;
		}
		
		public void SetOperatorName(string value){
			this.operatorName_ = value;
		}
		public int? GetReturnRefundType(){
			return this.returnRefundType_;
		}
		
		public void SetReturnRefundType(int? value){
			this.returnRefundType_ = value;
		}
		public int? GetReturnRefundStatus(){
			return this.returnRefundStatus_;
		}
		
		public void SetReturnRefundStatus(int? value){
			this.returnRefundStatus_ = value;
		}
		public string GetAfterSaleSn(){
			return this.afterSaleSn_;
		}
		
		public void SetAfterSaleSn(string value){
			this.afterSaleSn_ = value;
		}
		public int? GetAfterSaleStatus(){
			return this.afterSaleStatus_;
		}
		
		public void SetAfterSaleStatus(int? value){
			this.afterSaleStatus_ = value;
		}
		public string GetUserRemark(){
			return this.userRemark_;
		}
		
		public void SetUserRemark(string value){
			this.userRemark_ = value;
		}
		public List<string> GetImageUrls(){
			return this.imageUrls_;
		}
		
		public void SetImageUrls(List<string> value){
			this.imageUrls_ = value;
		}
		public string GetChannelStoreId(){
			return this.channelStoreId_;
		}
		
		public void SetChannelStoreId(string value){
			this.channelStoreId_ = value;
		}
		public string GetRefundTotalMoney(){
			return this.refundTotalMoney_;
		}
		
		public void SetRefundTotalMoney(string value){
			this.refundTotalMoney_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderRefundWayVO> GetOrderRefundWayList(){
			return this.orderRefundWayList_;
		}
		
		public void SetOrderRefundWayList(List<com.vip.order.common.pojo.order.vo.OrderRefundWayVO> value){
			this.orderRefundWayList_ = value;
		}
		
	}
	
}