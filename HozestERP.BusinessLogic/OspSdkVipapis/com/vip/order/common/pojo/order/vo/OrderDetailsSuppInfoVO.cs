using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderDetailsSuppInfoVO {
		
		///<summary>
		/// 支付方式中文名
		///</summary>
		
		private string payTypeName_;
		
		///<summary>
		/// 真实的支付方式中文名
		///</summary>
		
		private string realPayTypeName_;
		
		///<summary>
		/// 多笔支付的支付方式组合
		///</summary>
		
		private string mulPayTypeName_;
		
		///<summary>
		/// 订单状态中文名
		///</summary>
		
		private string orderStatusName_;
		
		///<summary>
		/// 海淘订单状态中文名
		///</summary>
		
		private string haitaoStatusName_;
		
		///<summary>
		/// 订单类型中文名
		///</summary>
		
		private string orderTypeName_;
		
		///<summary>
		/// 支付状态中文名
		///</summary>
		
		private string payStatusName_;
		
		///<summary>
		/// 销售区域
		///</summary>
		
		private string areaFlagName_;
		
		///<summary>
		/// 虚拟金额转换的唯品币
		///</summary>
		
		private string virtualIntegral_;
		
		///<summary>
		/// 客服端类型
		///</summary>
		
		private int? clientType_;
		
		///<summary>
		/// 是否是购物车拆单：0:未拆单、1:已拆单
		///</summary>
		
		private int? isCartSplitOrder_;
		
		///<summary>
		/// 购物车拆单订单号
		///</summary>
		
		private string splitOrders_;
		
		///<summary>
		/// 原始订单号
		///</summary>
		
		private string originSns_;
		
		///<summary>
		/// OXO子单号
		///</summary>
		
		private string oxoSubSns_;
		
		///<summary>
		/// 唯宝总红包退款金额
		///</summary>
		
		private string totalPacketRefundMoney_;
		
		///<summary>
		/// 唯宝总红包支付金额
		///</summary>
		
		private string totalPacketMoney_;
		
		///<summary>
		/// 上次支付类型
		///</summary>
		
		private int? lastPayType_;
		
		///<summary>
		/// 是否需要拆单
		///</summary>
		
		private int? needSplit_;
		
		///<summary>
		/// 拆分订单母单sn
		///</summary>
		
		private string splitParentSn_;
		
		///<summary>
		/// 拆分订单子单sn列表
		///</summary>
		
		private List<string> splitChildrenSns_;
		
		///<summary>
		/// 换货订单原订单号
		///</summary>
		
		private string exchangeOriginOrdersn_;
		
		public string GetPayTypeName(){
			return this.payTypeName_;
		}
		
		public void SetPayTypeName(string value){
			this.payTypeName_ = value;
		}
		public string GetRealPayTypeName(){
			return this.realPayTypeName_;
		}
		
		public void SetRealPayTypeName(string value){
			this.realPayTypeName_ = value;
		}
		public string GetMulPayTypeName(){
			return this.mulPayTypeName_;
		}
		
		public void SetMulPayTypeName(string value){
			this.mulPayTypeName_ = value;
		}
		public string GetOrderStatusName(){
			return this.orderStatusName_;
		}
		
		public void SetOrderStatusName(string value){
			this.orderStatusName_ = value;
		}
		public string GetHaitaoStatusName(){
			return this.haitaoStatusName_;
		}
		
		public void SetHaitaoStatusName(string value){
			this.haitaoStatusName_ = value;
		}
		public string GetOrderTypeName(){
			return this.orderTypeName_;
		}
		
		public void SetOrderTypeName(string value){
			this.orderTypeName_ = value;
		}
		public string GetPayStatusName(){
			return this.payStatusName_;
		}
		
		public void SetPayStatusName(string value){
			this.payStatusName_ = value;
		}
		public string GetAreaFlagName(){
			return this.areaFlagName_;
		}
		
		public void SetAreaFlagName(string value){
			this.areaFlagName_ = value;
		}
		public string GetVirtualIntegral(){
			return this.virtualIntegral_;
		}
		
		public void SetVirtualIntegral(string value){
			this.virtualIntegral_ = value;
		}
		public int? GetClientType(){
			return this.clientType_;
		}
		
		public void SetClientType(int? value){
			this.clientType_ = value;
		}
		public int? GetIsCartSplitOrder(){
			return this.isCartSplitOrder_;
		}
		
		public void SetIsCartSplitOrder(int? value){
			this.isCartSplitOrder_ = value;
		}
		public string GetSplitOrders(){
			return this.splitOrders_;
		}
		
		public void SetSplitOrders(string value){
			this.splitOrders_ = value;
		}
		public string GetOriginSns(){
			return this.originSns_;
		}
		
		public void SetOriginSns(string value){
			this.originSns_ = value;
		}
		public string GetOxoSubSns(){
			return this.oxoSubSns_;
		}
		
		public void SetOxoSubSns(string value){
			this.oxoSubSns_ = value;
		}
		public string GetTotalPacketRefundMoney(){
			return this.totalPacketRefundMoney_;
		}
		
		public void SetTotalPacketRefundMoney(string value){
			this.totalPacketRefundMoney_ = value;
		}
		public string GetTotalPacketMoney(){
			return this.totalPacketMoney_;
		}
		
		public void SetTotalPacketMoney(string value){
			this.totalPacketMoney_ = value;
		}
		public int? GetLastPayType(){
			return this.lastPayType_;
		}
		
		public void SetLastPayType(int? value){
			this.lastPayType_ = value;
		}
		public int? GetNeedSplit(){
			return this.needSplit_;
		}
		
		public void SetNeedSplit(int? value){
			this.needSplit_ = value;
		}
		public string GetSplitParentSn(){
			return this.splitParentSn_;
		}
		
		public void SetSplitParentSn(string value){
			this.splitParentSn_ = value;
		}
		public List<string> GetSplitChildrenSns(){
			return this.splitChildrenSns_;
		}
		
		public void SetSplitChildrenSns(List<string> value){
			this.splitChildrenSns_ = value;
		}
		public string GetExchangeOriginOrdersn(){
			return this.exchangeOriginOrdersn_;
		}
		
		public void SetExchangeOriginOrdersn(string value){
			this.exchangeOriginOrdersn_ = value;
		}
		
	}
	
}