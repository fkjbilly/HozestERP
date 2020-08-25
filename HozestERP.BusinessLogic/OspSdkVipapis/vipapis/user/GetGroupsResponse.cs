using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.user{
	
	
	
	
	
	public class GetGroupsResponse {
		
		///<summary>
		/// 运营在DMP系统中指定给DSP供应商使用的用户人群信息列表
		///</summary>
		
		private List<vipapis.user.GroupInfo> groups_;
		
		///<summary>
		/// 该DSP一共订阅的人群总数（调用方可使用该字段判断是否已经取完和分页）
		///</summary>
		
		private int? total_;
		
		public List<vipapis.user.GroupInfo> GetGroups(){
			return this.groups_;
		}
		
		public void SetGroups(List<vipapis.user.GroupInfo> value){
			this.groups_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}