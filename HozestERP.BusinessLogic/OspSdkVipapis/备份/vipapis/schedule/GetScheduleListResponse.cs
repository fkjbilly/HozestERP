using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.schedule{
	
	
	
	
	
	public class GetScheduleListResponse {
		
		///<summary>
		/// 档期列表
		///</summary>
		
		private List<vipapis.schedule.Schedule> schedules_;
		
		///<summary>
		/// 总记录条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.schedule.Schedule> GetSchedules(){
			return this.schedules_;
		}
		
		public void SetSchedules(List<vipapis.schedule.Schedule> value){
			this.schedules_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}