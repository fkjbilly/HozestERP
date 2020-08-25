using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.account{
	
	
	
	
	
	public class EnterpriseAccountQueryRequest {
		
		///<summary>
		/// 大企业员工申请id
		/// @sampleValue apply_id 16
		///</summary>
		
		private long? apply_id_;
		
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
		/// 员工手机号
		/// @sampleValue phone_no 13810281234
		///</summary>
		
		private string phone_no_;
		
		///<summary>
		/// 账号状态
		/// @sampleValue account_type 0
		///</summary>
		
		private int? account_type_;
		
		///<summary>
		/// 数据处理状态,0:已申请,1:已拉取,2:已审核,3:已执行
		/// @sampleValue proc_state 1
		///</summary>
		
		private int? proc_state_;
		
		///<summary>
		/// 申请结果
		///</summary>
		
		private string result_code_;
		
		///<summary>
		/// 账号申请时间-开始，开始和结束时间请同时传入或不传
		/// @sampleValue start_time 2014-03-21 12:34:56(格式YYYY-MM-DD HH:mm:ss)
		///</summary>
		
		private string start_time_;
		
		///<summary>
		/// 账号申请时间-结束，开始和结束时间请同时传入或不传
		/// @sampleValue end_time 2014-03-21 12:34:56(格式YYYY-MM-DD HH:mm:ss)
		///</summary>
		
		private string end_time_;
		
		///<summary>
		/// 分页
		/// @sampleValue page 1
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 每页行数，最大100条
		/// @sampleValue limit 20
		///</summary>
		
		private int? limit_;
		
		public long? GetApply_id(){
			return this.apply_id_;
		}
		
		public void SetApply_id(long? value){
			this.apply_id_ = value;
		}
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
		public string GetPhone_no(){
			return this.phone_no_;
		}
		
		public void SetPhone_no(string value){
			this.phone_no_ = value;
		}
		public int? GetAccount_type(){
			return this.account_type_;
		}
		
		public void SetAccount_type(int? value){
			this.account_type_ = value;
		}
		public int? GetProc_state(){
			return this.proc_state_;
		}
		
		public void SetProc_state(int? value){
			this.proc_state_ = value;
		}
		public string GetResult_code(){
			return this.result_code_;
		}
		
		public void SetResult_code(string value){
			this.result_code_ = value;
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