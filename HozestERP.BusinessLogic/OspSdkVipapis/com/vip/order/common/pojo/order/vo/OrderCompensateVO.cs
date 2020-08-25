using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderCompensateVO {
		
		///<summary>
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 用户ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 赔付类型(0:慢必赔)
		///</summary>
		
		private byte? compensateType_;
		
		///<summary>
		/// 赔付方式（1:唯品币）
		///</summary>
		
		private byte? compensateWay_;
		
		///<summary>
		/// 赔付金额
		///</summary>
		
		private string money_;
		
		///<summary>
		/// 赔偿时间
		///</summary>
		
		private int? compensateTime_;
		
		///<summary>
		/// 赔付原因
		///</summary>
		
		private string reason_;
		
		///<summary>
		/// 赔付状态(0:未赔付，1:已赔付，2:无需赔付)
		///</summary>
		
		private byte? compensateStatus_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private int? addTime_;
		
		///<summary>
		/// 处理次数
		///</summary>
		
		private byte? procTimes_;
		
		///<summary>
		/// 更新时间
		///</summary>
		
		private long? updateTime_;
		
		///<summary>
		/// 逻辑删除标志
		///</summary>
		
		private bool? isDeleted_;
		
		///<summary>
		/// operate_sys
		///</summary>
		
		private string operateSys_;
		
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public byte? GetCompensateType(){
			return this.compensateType_;
		}
		
		public void SetCompensateType(byte? value){
			this.compensateType_ = value;
		}
		public byte? GetCompensateWay(){
			return this.compensateWay_;
		}
		
		public void SetCompensateWay(byte? value){
			this.compensateWay_ = value;
		}
		public string GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(string value){
			this.money_ = value;
		}
		public int? GetCompensateTime(){
			return this.compensateTime_;
		}
		
		public void SetCompensateTime(int? value){
			this.compensateTime_ = value;
		}
		public string GetReason(){
			return this.reason_;
		}
		
		public void SetReason(string value){
			this.reason_ = value;
		}
		public byte? GetCompensateStatus(){
			return this.compensateStatus_;
		}
		
		public void SetCompensateStatus(byte? value){
			this.compensateStatus_ = value;
		}
		public int? GetAddTime(){
			return this.addTime_;
		}
		
		public void SetAddTime(int? value){
			this.addTime_ = value;
		}
		public byte? GetProcTimes(){
			return this.procTimes_;
		}
		
		public void SetProcTimes(byte? value){
			this.procTimes_ = value;
		}
		public long? GetUpdateTime(){
			return this.updateTime_;
		}
		
		public void SetUpdateTime(long? value){
			this.updateTime_ = value;
		}
		public bool? GetIsDeleted(){
			return this.isDeleted_;
		}
		
		public void SetIsDeleted(bool? value){
			this.isDeleted_ = value;
		}
		public string GetOperateSys(){
			return this.operateSys_;
		}
		
		public void SetOperateSys(string value){
			this.operateSys_ = value;
		}
		
	}
	
}