using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.vo{
	
	
	
	
	
	public class OrderActiveVO {
		
		///<summary>
		/// 活动维度
		///</summary>
		
		private int? activeField_;
		
		///<summary>
		/// 活动名称
		///</summary>
		
		private string activeName_;
		
		///<summary>
		/// 活动编号
		///</summary>
		
		private string activeNo_;
		
		///<summary>
		/// 活动类型
		///</summary>
		
		private int? activeType_;
		
		///<summary>
		/// 活动明细json
		///</summary>
		
		private string detail_;
		
		///<summary>
		/// 是否删除标志
		///</summary>
		
		private int? isDelete_;
		
		///<summary>
		/// 添加时间
		///</summary>
		
		private long? addTime_;
		
		///<summary>
		/// 更新时间,格式'2016-07-05 09:25:36'
		///</summary>
		
		private string updateTime_;
		
		public int? GetActiveField(){
			return this.activeField_;
		}
		
		public void SetActiveField(int? value){
			this.activeField_ = value;
		}
		public string GetActiveName(){
			return this.activeName_;
		}
		
		public void SetActiveName(string value){
			this.activeName_ = value;
		}
		public string GetActiveNo(){
			return this.activeNo_;
		}
		
		public void SetActiveNo(string value){
			this.activeNo_ = value;
		}
		public int? GetActiveType(){
			return this.activeType_;
		}
		
		public void SetActiveType(int? value){
			this.activeType_ = value;
		}
		public string GetDetail(){
			return this.detail_;
		}
		
		public void SetDetail(string value){
			this.detail_ = value;
		}
		public int? GetIsDelete(){
			return this.isDelete_;
		}
		
		public void SetIsDelete(int? value){
			this.isDelete_ = value;
		}
		public long? GetAddTime(){
			return this.addTime_;
		}
		
		public void SetAddTime(long? value){
			this.addTime_ = value;
		}
		public string GetUpdateTime(){
			return this.updateTime_;
		}
		
		public void SetUpdateTime(string value){
			this.updateTime_ = value;
		}
		
	}
	
}