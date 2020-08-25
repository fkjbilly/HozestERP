using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vipcard{
	
	
	
	
	
	public class ApplyGroupResponse {
		
		///<summary>
		/// 批次id
		/// @sampleValue group_id 1211
		///</summary>
		
		private int? group_id_;
		
		public int? GetGroup_id(){
			return this.group_id_;
		}
		
		public void SetGroup_id(int? value){
			this.group_id_ = value;
		}
		
	}
	
}