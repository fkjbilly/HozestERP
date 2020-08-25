using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class SearchOrderReq {
		
		///<summary>
		/// 用户id列表(user_id)（请尽量传入此值，之前没传入的也麻烦尽量补充此字段）
		///</summary>
		
		private List<long?> userIdList_;
		
		///<summary>
		/// 订单ID列表
		///</summary>
		
		private List<long?> orderIdList_;
		
		///<summary>
		/// 订单序列号列表
		///</summary>
		
		private List<string> orderSnList_;
		
		///<summary>
		/// 下单时用户名
		///</summary>
		
		private string userName_;
		
		///<summary>
		/// 销售模式
		///</summary>
		
		private List<int?> saleType_;
		
		///<summary>
		/// 订单类型范围
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam typeRange_;
		
		///<summary>
		/// 订单模式(0:普通，1：预售)
		///</summary>
		
		private List<int?> orderModelList_;
		
		///<summary>
		/// 仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 售卖频道(vipclub) 订单频道来源
		///</summary>
		
		private List<string> vipclubList_;
		
		///<summary>
		/// 订单状态order_status
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam statusRange_;
		
		///<summary>
		/// 订单子状态0无异常 1海淘身份验证未通过
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam subStatusRange_;
		
		///<summary>
		/// 支付状态
		///</summary>
		
		private int? payStatus_;
		
		///<summary>
		/// 收货人姓名
		///</summary>
		
		private string buyer_;
		
		///<summary>
		/// 物流单号(transport_number)
		///</summary>
		
		private string transportSn_;
		
		///<summary>
		/// 物流公司
		///</summary>
		
		private int? transportId_;
		
		///<summary>
		/// 收货人手机号
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 收货人固话
		///</summary>
		
		private string tel_;
		
		///<summary>
		/// 查询数据范围
		///</summary>
		
		private int? queryRange_;
		
		///<summary>
		/// 下单时间段(add_time)
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam orderTimeRange_;
		
		///<summary>
		/// 下单日期(order_date)
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam orderDateRange_;
		
		///<summary>
		/// 更新时间
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam updateTimeRange_;
		
		///<summary>
		/// 支付类型
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam payTypeRange_;
		
		///<summary>
		/// 零钱支付金额
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam walletAmountRange_;
		
		///<summary>
		/// 代金券ID
		///</summary>
		
		private List<string> couponIdList_;
		
		///<summary>
		/// 发票类型
		///</summary>
		
		private List<string> invoiceTypeList_;
		
		///<summary>
		/// 合并订单标识
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam allotTimeRange_;
		
		///<summary>
		/// 退换货标记
		///</summary>
		
		private int? orderFlag_;
		
		///<summary>
		/// 缺货抓取状态
		///</summary>
		
		private int? statusFlag_;
		
		///<summary>
		/// wms抓取状态
		///</summary>
		
		private List<int?> wmsFlagList_;
		
		///<summary>
		/// 保留订单标识
		///</summary>
		
		private int? isHold_;
		
		///<summary>
		/// 
		///</summary>
		
		private int? isSpecial_;
		
		///<summary>
		/// 是否被用户隐藏的订单
		///</summary>
		
		private int? isDisplay_;
		
		///<summary>
		/// 订单来源类型 0:正常下单 1:换货订单 2:修改订单 3:合并订单
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam orderSourceTypeRange_;
		
		///<summary>
		/// 特殊条件
		///</summary>
		
		private com.vip.order.biz.request.SpecialCondition specialCondition_;
		
		///<summary>
		/// amount
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam amountRange_;
		
		///<summary>
		/// 订单种类
		///</summary>
		
		private int? orderCategory_;
		
		///<summary>
		/// order_sn类型 
		///</summary>
		
		private string snType_;
		
		///<summary>
		/// audit_time(预付中使用)
		///</summary>
		
		private com.vip.order.common.pojo.order.request.RangeParam auditTimeRange_;
		
		///<summary>
		/// is_first(预付中使用)
		///</summary>
		
		private int? isFirst_;
		
		///<summary>
		/// is_lock(预付中使用)
		///</summary>
		
		private int? isLock_;
		
		///<summary>
		/// 下单IP
		///</summary>
		
		private string ip_;
		
		///<summary>
		/// 操作人
		///</summary>
		
		private string operator_;
		
		///<summary>
		/// 赔付类型
		///</summary>
		
		private List<int?> deliveryTypeList_;
		
		///<summary>
		/// 慢必赔标识
		///</summary>
		
		private List<int?> compensateFlagList_;
		
		///<summary>
		/// Marketplace店铺ID
		///</summary>
		
		private string storeId_;
		
		public List<long?> GetUserIdList(){
			return this.userIdList_;
		}
		
		public void SetUserIdList(List<long?> value){
			this.userIdList_ = value;
		}
		public List<long?> GetOrderIdList(){
			return this.orderIdList_;
		}
		
		public void SetOrderIdList(List<long?> value){
			this.orderIdList_ = value;
		}
		public List<string> GetOrderSnList(){
			return this.orderSnList_;
		}
		
		public void SetOrderSnList(List<string> value){
			this.orderSnList_ = value;
		}
		public string GetUserName(){
			return this.userName_;
		}
		
		public void SetUserName(string value){
			this.userName_ = value;
		}
		public List<int?> GetSaleType(){
			return this.saleType_;
		}
		
		public void SetSaleType(List<int?> value){
			this.saleType_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetTypeRange(){
			return this.typeRange_;
		}
		
		public void SetTypeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.typeRange_ = value;
		}
		public List<int?> GetOrderModelList(){
			return this.orderModelList_;
		}
		
		public void SetOrderModelList(List<int?> value){
			this.orderModelList_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public List<string> GetVipclubList(){
			return this.vipclubList_;
		}
		
		public void SetVipclubList(List<string> value){
			this.vipclubList_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetStatusRange(){
			return this.statusRange_;
		}
		
		public void SetStatusRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.statusRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetSubStatusRange(){
			return this.subStatusRange_;
		}
		
		public void SetSubStatusRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.subStatusRange_ = value;
		}
		public int? GetPayStatus(){
			return this.payStatus_;
		}
		
		public void SetPayStatus(int? value){
			this.payStatus_ = value;
		}
		public string GetBuyer(){
			return this.buyer_;
		}
		
		public void SetBuyer(string value){
			this.buyer_ = value;
		}
		public string GetTransportSn(){
			return this.transportSn_;
		}
		
		public void SetTransportSn(string value){
			this.transportSn_ = value;
		}
		public int? GetTransportId(){
			return this.transportId_;
		}
		
		public void SetTransportId(int? value){
			this.transportId_ = value;
		}
		public string GetMobile(){
			return this.mobile_;
		}
		
		public void SetMobile(string value){
			this.mobile_ = value;
		}
		public string GetTel(){
			return this.tel_;
		}
		
		public void SetTel(string value){
			this.tel_ = value;
		}
		public int? GetQueryRange(){
			return this.queryRange_;
		}
		
		public void SetQueryRange(int? value){
			this.queryRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetOrderTimeRange(){
			return this.orderTimeRange_;
		}
		
		public void SetOrderTimeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.orderTimeRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetOrderDateRange(){
			return this.orderDateRange_;
		}
		
		public void SetOrderDateRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.orderDateRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetUpdateTimeRange(){
			return this.updateTimeRange_;
		}
		
		public void SetUpdateTimeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.updateTimeRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetPayTypeRange(){
			return this.payTypeRange_;
		}
		
		public void SetPayTypeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.payTypeRange_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetWalletAmountRange(){
			return this.walletAmountRange_;
		}
		
		public void SetWalletAmountRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.walletAmountRange_ = value;
		}
		public List<string> GetCouponIdList(){
			return this.couponIdList_;
		}
		
		public void SetCouponIdList(List<string> value){
			this.couponIdList_ = value;
		}
		public List<string> GetInvoiceTypeList(){
			return this.invoiceTypeList_;
		}
		
		public void SetInvoiceTypeList(List<string> value){
			this.invoiceTypeList_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetAllotTimeRange(){
			return this.allotTimeRange_;
		}
		
		public void SetAllotTimeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.allotTimeRange_ = value;
		}
		public int? GetOrderFlag(){
			return this.orderFlag_;
		}
		
		public void SetOrderFlag(int? value){
			this.orderFlag_ = value;
		}
		public int? GetStatusFlag(){
			return this.statusFlag_;
		}
		
		public void SetStatusFlag(int? value){
			this.statusFlag_ = value;
		}
		public List<int?> GetWmsFlagList(){
			return this.wmsFlagList_;
		}
		
		public void SetWmsFlagList(List<int?> value){
			this.wmsFlagList_ = value;
		}
		public int? GetIsHold(){
			return this.isHold_;
		}
		
		public void SetIsHold(int? value){
			this.isHold_ = value;
		}
		public int? GetIsSpecial(){
			return this.isSpecial_;
		}
		
		public void SetIsSpecial(int? value){
			this.isSpecial_ = value;
		}
		public int? GetIsDisplay(){
			return this.isDisplay_;
		}
		
		public void SetIsDisplay(int? value){
			this.isDisplay_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetOrderSourceTypeRange(){
			return this.orderSourceTypeRange_;
		}
		
		public void SetOrderSourceTypeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.orderSourceTypeRange_ = value;
		}
		public com.vip.order.biz.request.SpecialCondition GetSpecialCondition(){
			return this.specialCondition_;
		}
		
		public void SetSpecialCondition(com.vip.order.biz.request.SpecialCondition value){
			this.specialCondition_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetAmountRange(){
			return this.amountRange_;
		}
		
		public void SetAmountRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.amountRange_ = value;
		}
		public int? GetOrderCategory(){
			return this.orderCategory_;
		}
		
		public void SetOrderCategory(int? value){
			this.orderCategory_ = value;
		}
		public string GetSnType(){
			return this.snType_;
		}
		
		public void SetSnType(string value){
			this.snType_ = value;
		}
		public com.vip.order.common.pojo.order.request.RangeParam GetAuditTimeRange(){
			return this.auditTimeRange_;
		}
		
		public void SetAuditTimeRange(com.vip.order.common.pojo.order.request.RangeParam value){
			this.auditTimeRange_ = value;
		}
		public int? GetIsFirst(){
			return this.isFirst_;
		}
		
		public void SetIsFirst(int? value){
			this.isFirst_ = value;
		}
		public int? GetIsLock(){
			return this.isLock_;
		}
		
		public void SetIsLock(int? value){
			this.isLock_ = value;
		}
		public string GetIp(){
			return this.ip_;
		}
		
		public void SetIp(string value){
			this.ip_ = value;
		}
		public string GetOperator(){
			return this.operator_;
		}
		
		public void SetOperator(string value){
			this.operator_ = value;
		}
		public List<int?> GetDeliveryTypeList(){
			return this.deliveryTypeList_;
		}
		
		public void SetDeliveryTypeList(List<int?> value){
			this.deliveryTypeList_ = value;
		}
		public List<int?> GetCompensateFlagList(){
			return this.compensateFlagList_;
		}
		
		public void SetCompensateFlagList(List<int?> value){
			this.compensateFlagList_ = value;
		}
		public string GetStoreId(){
			return this.storeId_;
		}
		
		public void SetStoreId(string value){
			this.storeId_ = value;
		}
		
	}
	
}