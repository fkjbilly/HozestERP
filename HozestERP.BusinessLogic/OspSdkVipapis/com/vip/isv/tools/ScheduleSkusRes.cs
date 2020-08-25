using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class ScheduleSkusRes {
		
		///<summary>
		/// 结果集
		///</summary>
		
		private List<com.vip.isv.tools.ScheduleSkusDo> scheduleSkusDos_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? totalCount_;
		
		public List<com.vip.isv.tools.ScheduleSkusDo> GetScheduleSkusDos(){
			return this.scheduleSkusDos_;
		}
		
		public void SetScheduleSkusDos(List<com.vip.isv.tools.ScheduleSkusDo> value){
			this.scheduleSkusDos_ = value;
		}
		public int? GetTotalCount(){
			return this.totalCount_;
		}
		
		public void SetTotalCount(int? value){
			this.totalCount_ = value;
		}
		
	}
	
}