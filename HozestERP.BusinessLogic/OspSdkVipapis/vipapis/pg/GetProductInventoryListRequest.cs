using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.pg{
	
	
	
	
	
	public class GetProductInventoryListRequest {
		
		///<summary>
		/// startTime
		/// @sampleValue startTime 2015-06-06 10:25:38
		///</summary>
		
		private string startTime_;
		
		///<summary>
		/// endTime
		/// @sampleValue endTime 2015-06-06 10:25:38
		///</summary>
		
		private string endTime_;
		
		///<summary>
		/// page
		/// @sampleValue page page=1
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// limit
		/// @sampleValue limit limit=20
		///</summary>
		
		private int? limit_;
		
		public string GetStartTime(){
			return this.startTime_;
		}
		
		public void SetStartTime(string value){
			this.startTime_ = value;
		}
		public string GetEndTime(){
			return this.endTime_;
		}
		
		public void SetEndTime(string value){
			this.endTime_ = value;
		}
		public int? GetPage(){
			return this.page_;
		}
		
		public void SetPage(int? value){
			this.page_ = value;
		}
		public int? GetLimit(){
			return this.limit_;
		}
		
		public void SetLimit(int? value){
			this.limit_ = value;
		}
		
	}
	
}