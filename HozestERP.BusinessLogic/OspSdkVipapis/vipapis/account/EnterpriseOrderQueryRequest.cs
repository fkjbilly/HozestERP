using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.account{
	
	
	
	
	
	public class EnterpriseOrderQueryRequest {
		
		///<summary>
		/// 企业标记
		/// @sampleValue enterprise_code 16
		///</summary>
		
		private string enterprise_code_;
		
		///<summary>
		/// 企业员工的编号
		/// @sampleValue enterprise_employee_no 78949922
		///</summary>
		
		private string enterprise_employee_no_;
		
		///<summary>
		/// 订单下单时间-起止
		/// @sampleValue start_time 2014-03-21 12:34:56(格式YYYY-MM-DD HH:mm:ss)
		///</summary>
		
		private string start_time_;
		
		///<summary>
		/// 订单下单时间-结束
		/// @sampleValue end_time 2014-03-21 12:34:56(格式YYYY-MM-DD HH:mm:ss)
		///</summary>
		
		private string end_time_;
		
		///<summary>
		/// 分页
		/// @sampleValue page 1
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 每页行数，最大500条
		/// @sampleValue limit 20
		///</summary>
		
		private int? limit_;
		
		public string GetEnterprise_code(){
			return this.enterprise_code_;
		}
		
		public void SetEnterprise_code(string value){
			this.enterprise_code_ = value;
		}
		public string GetEnterprise_employee_no(){
			return this.enterprise_employee_no_;
		}
		
		public void SetEnterprise_employee_no(string value){
			this.enterprise_employee_no_ = value;
		}
		public string GetStart_time(){
			return this.start_time_;
		}
		
		public void SetStart_time(string value){
			this.start_time_ = value;
		}
		public string GetEnd_time(){
			return this.end_time_;
		}
		
		public void SetEnd_time(string value){
			this.end_time_ = value;
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