using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class ExchangeBackFeeVO {
		
		///<summary>
		/// 主键ID
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 换货申请单ID。对应字段：exchange_id
		///</summary>
		
		private long? applyId_;
		
		///<summary>
		/// 原订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 用户ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 补贴金额
		///</summary>
		
		private string backMoney_;
		
		///<summary>
		/// 处理状态：0:未处理  1:补贴中  2:已补  3:不补
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 赠送时间
		///</summary>
		
		private long? presentTime_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private long? createTime_;
		
		///<summary>
		/// 更新时间
		///</summary>
		
		private long? updateTime_;
		
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
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
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetBackMoney(){
			return this.backMoney_;
		}
		
		public void SetBackMoney(string value){
			this.backMoney_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public long? GetPresentTime(){
			return this.presentTime_;
		}
		
		public void SetPresentTime(long? value){
			this.presentTime_ = value;
		}
		public long? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(long? value){
			this.createTime_ = value;
		}
		public long? GetUpdateTime(){
			return this.updateTime_;
		}
		
		public void SetUpdateTime(long? value){
			this.updateTime_ = value;
		}
		
	}
	
}