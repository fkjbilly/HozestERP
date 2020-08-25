using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class CloudCooperationNoLogRes {
		
		///<summary>
		/// 结果集
		///</summary>
		
		private List<com.vip.isv.tools.CloudCooperationNoLogDo> cloudCooperationNoLogDos_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? totalCount_;
		
		public List<com.vip.isv.tools.CloudCooperationNoLogDo> GetCloudCooperationNoLogDos(){
			return this.cloudCooperationNoLogDos_;
		}
		
		public void SetCloudCooperationNoLogDos(List<com.vip.isv.tools.CloudCooperationNoLogDo> value){
			this.cloudCooperationNoLogDos_ = value;
		}
		public int? GetTotalCount(){
			return this.totalCount_;
		}
		
		public void SetTotalCount(int? value){
			this.totalCount_ = value;
		}
		
	}
	
}