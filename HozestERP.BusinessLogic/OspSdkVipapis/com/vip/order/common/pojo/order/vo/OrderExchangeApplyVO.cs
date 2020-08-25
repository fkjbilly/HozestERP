using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderExchangeApplyVO {
		
		///<summary>
		/// 自增主键id
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
		/// 操作人
		///</summary>
		
		private string operator_;
		
		///<summary>
		/// 说明
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 订单售后状态.0:初始化（未审核）1:待审核 2：审核通过 3:已返仓 4:已拆包 5:已生成新单 6:已发货 7:已完成 8:取消 9:扣库存中 10:扣库存异常
		///</summary>
		
		private int? orderAfterStatus_;
		
		///<summary>
		/// 订单售后状态更新时间
		///</summary>
		
		private long? orderAfterStatusUpdtime_;
		
		///<summary>
		/// 售后申请时间
		///</summary>
		
		private long? applyTime_;
		
		///<summary>
		/// 新订单号
		///</summary>
		
		private string newOrderSn_;
		
		///<summary>
		/// 换货方式：0 自行寄回， 1 上门揽换
		///</summary>
		
		private int? returnMethod_;
		
		///<summary>
		/// 上门揽换流程状态: 0:默认值 1: 待扣库存 2:扣库存完成，待创建 3: 创建完成 4:扣款和扣减商品完成 10：修改换货扣库存中
		///</summary>
		
		private int? exchangeProcessStatus_;
		
		///<summary>
		/// 退货运单号
		///</summary>
		
		private string returnTransportNo_;
		
		///<summary>
		/// 记录更新时间
		///</summary>
		
		private long? updateTime_;
		
		///<summary>
		/// IP
		///</summary>
		
		private string ip_;
		
		///<summary>
		/// 内部程序处理子状态标识
		///</summary>
		
		private int? subExchangeStatus_;
		
		///<summary>
		/// 换货运维，0：现付【向会员收取运费】 1：到付【公司负责运费
		///</summary>
		
		private int? returnsPayType_;
		
		///<summary>
		/// 回寄仓
		///</summary>
		
		private string returnWarehouse_;
		
		///<summary>
		/// 售后单SN
		///</summary>
		
		private string afterSaleSn_;
		
		///<summary>
		/// 售后单新状态
		///</summary>
		
		private int? afterSaleStatus_;
		
		///<summary>
		/// 是否已删除: 0 - 未删除, 1 - 已删除
		///</summary>
		
		private int? isDeleted_;
		
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
		public string GetOperator(){
			return this.operator_;
		}
		
		public void SetOperator(string value){
			this.operator_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
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
		public long? GetApplyTime(){
			return this.applyTime_;
		}
		
		public void SetApplyTime(long? value){
			this.applyTime_ = value;
		}
		public string GetNewOrderSn(){
			return this.newOrderSn_;
		}
		
		public void SetNewOrderSn(string value){
			this.newOrderSn_ = value;
		}
		public int? GetReturnMethod(){
			return this.returnMethod_;
		}
		
		public void SetReturnMethod(int? value){
			this.returnMethod_ = value;
		}
		public int? GetExchangeProcessStatus(){
			return this.exchangeProcessStatus_;
		}
		
		public void SetExchangeProcessStatus(int? value){
			this.exchangeProcessStatus_ = value;
		}
		public string GetReturnTransportNo(){
			return this.returnTransportNo_;
		}
		
		public void SetReturnTransportNo(string value){
			this.returnTransportNo_ = value;
		}
		public long? GetUpdateTime(){
			return this.updateTime_;
		}
		
		public void SetUpdateTime(long? value){
			this.updateTime_ = value;
		}
		public string GetIp(){
			return this.ip_;
		}
		
		public void SetIp(string value){
			this.ip_ = value;
		}
		public int? GetSubExchangeStatus(){
			return this.subExchangeStatus_;
		}
		
		public void SetSubExchangeStatus(int? value){
			this.subExchangeStatus_ = value;
		}
		public int? GetReturnsPayType(){
			return this.returnsPayType_;
		}
		
		public void SetReturnsPayType(int? value){
			this.returnsPayType_ = value;
		}
		public string GetReturnWarehouse(){
			return this.returnWarehouse_;
		}
		
		public void SetReturnWarehouse(string value){
			this.returnWarehouse_ = value;
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
		public int? GetIsDeleted(){
			return this.isDeleted_;
		}
		
		public void SetIsDeleted(int? value){
			this.isDeleted_ = value;
		}
		
	}
	
}