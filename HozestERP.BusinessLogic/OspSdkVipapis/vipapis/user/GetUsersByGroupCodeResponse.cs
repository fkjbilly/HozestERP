using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.user{
	
	
	
	
	
	public class GetUsersByGroupCodeResponse {
		
		///<summary>
		/// 用户人群数据，ID集合；ID类型在人群创建时候决定，需查看人群信息
		///</summary>
		
		private List<string> users_;
		
		public List<string> GetUsers(){
			return this.users_;
		}
		
		public void SetUsers(List<string> value){
			this.users_ = value;
		}
		
	}
	
}