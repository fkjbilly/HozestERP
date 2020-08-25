using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderReturnPackageInfoVO {
		
		///<summary>
		/// 售后收包物流ID
		///</summary>
		
		private long? orderReturnTransportId_;
		
		///<summary>
		/// 承运商名称
		///</summary>
		
		private string carriersName_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transportNo_;
		
		///<summary>
		/// 快递费
		///</summary>
		
		private string carriage_;
		
		///<summary>
		/// 快递费支付方式
		///</summary>
		
		private byte? carriagePayType_;
		
		///<summary>
		/// 收包类型
		///</summary>
		
		private string inpackType_;
		
		///<summary>
		/// 收包时间
		///</summary>
		
		private long? inpackTime_;
		
		///<summary>
		/// 货退返回方式
		///</summary>
		
		private short? goodsBackWay_;
		
		///<summary>
		/// 是否更新
		///</summary>
		
		private byte? hasUpdated_;
		
		///<summary>
		/// 仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 仓库
		///</summary>
		
		private long? applyId_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 操作者
		///</summary>
		
		private string operator_;
		
		///<summary>
		/// 
		///</summary>
		
		private string ip_;
		
		///<summary>
		/// tms收包时间
		///</summary>
		
		private long? getTime_;
		
		///<summary>
		/// 接口表收包时间
		///</summary>
		
		private long? addTime_;
		
		///<summary>
		/// 
		///</summary>
		
		private long? createTime_;
		
		public long? GetOrderReturnTransportId(){
			return this.orderReturnTransportId_;
		}
		
		public void SetOrderReturnTransportId(long? value){
			this.orderReturnTransportId_ = value;
		}
		public string GetCarriersName(){
			return this.carriersName_;
		}
		
		public void SetCarriersName(string value){
			this.carriersName_ = value;
		}
		public string GetTransportNo(){
			return this.transportNo_;
		}
		
		public void SetTransportNo(string value){
			this.transportNo_ = value;
		}
		public string GetCarriage(){
			return this.carriage_;
		}
		
		public void SetCarriage(string value){
			this.carriage_ = value;
		}
		public byte? GetCarriagePayType(){
			return this.carriagePayType_;
		}
		
		public void SetCarriagePayType(byte? value){
			this.carriagePayType_ = value;
		}
		public string GetInpackType(){
			return this.inpackType_;
		}
		
		public void SetInpackType(string value){
			this.inpackType_ = value;
		}
		public long? GetInpackTime(){
			return this.inpackTime_;
		}
		
		public void SetInpackTime(long? value){
			this.inpackTime_ = value;
		}
		public short? GetGoodsBackWay(){
			return this.goodsBackWay_;
		}
		
		public void SetGoodsBackWay(short? value){
			this.goodsBackWay_ = value;
		}
		public byte? GetHasUpdated(){
			return this.hasUpdated_;
		}
		
		public void SetHasUpdated(byte? value){
			this.hasUpdated_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public long? GetApplyId(){
			return this.applyId_;
		}
		
		public void SetApplyId(long? value){
			this.applyId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetOperator(){
			return this.operator_;
		}
		
		public void SetOperator(string value){
			this.operator_ = value;
		}
		public string GetIp(){
			return this.ip_;
		}
		
		public void SetIp(string value){
			this.ip_ = value;
		}
		public long? GetGetTime(){
			return this.getTime_;
		}
		
		public void SetGetTime(long? value){
			this.getTime_ = value;
		}
		public long? GetAddTime(){
			return this.addTime_;
		}
		
		public void SetAddTime(long? value){
			this.addTime_ = value;
		}
		public long? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(long? value){
			this.createTime_ = value;
		}
		
	}
	
}