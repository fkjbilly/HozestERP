using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderStatusHistoryVO {
		
		///<summary>
		/// 
		///</summary>
		
		private int? preOrderStatus_;
		
		///<summary>
		/// 
		///</summary>
		
		private long? preOrderStatusUpdateTime_;
		
		///<summary>
		/// 
		///</summary>
		
		private int? orderScenario_;
		
		///<summary>
		/// 
		///</summary>
		
		private int? orderStatus_;
		
		///<summary>
		/// 
		///</summary>
		
		private long? orderStatusUpdateTime_;
		
		///<summary>
		/// 
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 
		///</summary>
		
		private int? seq_;
		
		public int? GetPreOrderStatus(){
			return this.preOrderStatus_;
		}
		
		public void SetPreOrderStatus(int? value){
			this.preOrderStatus_ = value;
		}
		public long? GetPreOrderStatusUpdateTime(){
			return this.preOrderStatusUpdateTime_;
		}
		
		public void SetPreOrderStatusUpdateTime(long? value){
			this.preOrderStatusUpdateTime_ = value;
		}
		public int? GetOrderScenario(){
			return this.orderScenario_;
		}
		
		public void SetOrderScenario(int? value){
			this.orderScenario_ = value;
		}
		public int? GetOrderStatus(){
			return this.orderStatus_;
		}
		
		public void SetOrderStatus(int? value){
			this.orderStatus_ = value;
		}
		public long? GetOrderStatusUpdateTime(){
			return this.orderStatusUpdateTime_;
		}
		
		public void SetOrderStatusUpdateTime(long? value){
			this.orderStatusUpdateTime_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public int? GetSeq(){
			return this.seq_;
		}
		
		public void SetSeq(int? value){
			this.seq_ = value;
		}
		
	}
	
}