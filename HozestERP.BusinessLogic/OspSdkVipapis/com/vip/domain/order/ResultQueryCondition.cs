using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.order{
	
	
	
	
	
	public class ResultQueryCondition {
		
		///<summary>
		/// 查找记录的起始序号(返回大于本序号的记录)
		///</summary>
		
		private int? max_id_;
		
		///<summary>
		/// 每页最大数据条数
		///</summary>
		
		private int? count_;
		
		public int? GetMax_id(){
			return this.max_id_;
		}
		
		public void SetMax_id(int? value){
			this.max_id_ = value;
		}
		public int? GetCount(){
			return this.count_;
		}
		
		public void SetCount(int? value){
			this.count_ = value;
		}
		
	}
	
}