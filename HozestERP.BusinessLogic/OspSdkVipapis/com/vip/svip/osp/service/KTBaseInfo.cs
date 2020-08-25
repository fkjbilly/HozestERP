using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class KTBaseInfo {
		
		///<summary>
		/// 虚拟商品id
		///</summary>
		
		private string vpid_;
		
		///<summary>
		/// 用户名
		///</summary>
		
		private string nickName_;
		
		///<summary>
		/// 用户状态
		///</summary>
		
		private int? userStatus_;
		
		///<summary>
		/// 是否可试用
		///</summary>
		
		private bool? canTrial_;
		
		///<summary>
		/// 是否可开通
		///</summary>
		
		private bool? canOpen_;
		
		///<summary>
		/// 试用|付费 到期时间
		///</summary>
		
		private long? expireTime_;
		
		///<summary>
		/// 剩余天数
		///</summary>
		
		private int? remainingDays_;
		
		///<summary>
		/// 用户等级
		///</summary>
		
		private string userLv_;
		
		///<summary>
		/// 当用户订单优惠金额大于或等于用户平均优惠金额时返回0， 否则返回1
		///</summary>
		
		private int? averComp_;
		
		///<summary>
		/// 未开通付费会员预计订单优惠金额 或 已开通会员实际节省金额 http://wiki.corp.vipshop.com/x/yxaOD
		///</summary>
		
		private string saveAmount_;
		
		///<summary>
		/// 未开通付费会员预计节省的运费 或 已开通会员实际节省运费金额 http://wiki.corp.vipshop.com/x/yxaOD
		///</summary>
		
		private string saveCarriageAmount_;
		
		///<summary>
		/// 会员价格
		///</summary>
		
		private string price_;
		
		///<summary>
		/// 权益升级状态,其实就是风控
		///</summary>
		
		private int? updating_;
		
		///<summary>
		/// 是否即将过期的状态: 后台配置的剩余m天 
		///</summary>
		
		private bool? imminentExpiry_;
		
		public string GetVpid(){
			return this.vpid_;
		}
		
		public void SetVpid(string value){
			this.vpid_ = value;
		}
		public string GetNickName(){
			return this.nickName_;
		}
		
		public void SetNickName(string value){
			this.nickName_ = value;
		}
		public int? GetUserStatus(){
			return this.userStatus_;
		}
		
		public void SetUserStatus(int? value){
			this.userStatus_ = value;
		}
		public bool? GetCanTrial(){
			return this.canTrial_;
		}
		
		public void SetCanTrial(bool? value){
			this.canTrial_ = value;
		}
		public bool? GetCanOpen(){
			return this.canOpen_;
		}
		
		public void SetCanOpen(bool? value){
			this.canOpen_ = value;
		}
		public long? GetExpireTime(){
			return this.expireTime_;
		}
		
		public void SetExpireTime(long? value){
			this.expireTime_ = value;
		}
		public int? GetRemainingDays(){
			return this.remainingDays_;
		}
		
		public void SetRemainingDays(int? value){
			this.remainingDays_ = value;
		}
		public string GetUserLv(){
			return this.userLv_;
		}
		
		public void SetUserLv(string value){
			this.userLv_ = value;
		}
		public int? GetAverComp(){
			return this.averComp_;
		}
		
		public void SetAverComp(int? value){
			this.averComp_ = value;
		}
		public string GetSaveAmount(){
			return this.saveAmount_;
		}
		
		public void SetSaveAmount(string value){
			this.saveAmount_ = value;
		}
		public string GetSaveCarriageAmount(){
			return this.saveCarriageAmount_;
		}
		
		public void SetSaveCarriageAmount(string value){
			this.saveCarriageAmount_ = value;
		}
		public string GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(string value){
			this.price_ = value;
		}
		public int? GetUpdating(){
			return this.updating_;
		}
		
		public void SetUpdating(int? value){
			this.updating_ = value;
		}
		public bool? GetImminentExpiry(){
			return this.imminentExpiry_;
		}
		
		public void SetImminentExpiry(bool? value){
			this.imminentExpiry_ = value;
		}
		
	}
	
}