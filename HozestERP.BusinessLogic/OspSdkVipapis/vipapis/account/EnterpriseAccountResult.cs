using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.account{
	
	
	
	
	
	public class EnterpriseAccountResult {
		
		///<summary>
		/// 企业员工申请id
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
		/// @sampleValue proc_state 0
		///</summary>
		
		private int? proc_state_;
		
		///<summary>
		/// 申请结果，注：账号升级完成后才有值，完成前值为空
		///</summary>
		
		private string result_code_;
		
		///<summary>
		/// 结果备注信息，注：账号升级完成后才有值，完成前值为空
		///</summary>
		
		private string result_desc_;
		
		///<summary>
		/// 是否删除标记 0：未删除；1：已删除
		/// @sampleValue is_deleted 0
		///</summary>
		
		private int? is_deleted_;
		
		///<summary>
		/// 创建时间
		/// @sampleValue create_time 2014-03-21 12:34:56(格式YYYY-MM-DD HH:mm:ss)
		///</summary>
		
		private string create_time_;
		
		///<summary>
		/// 更新时间
		/// @sampleValue update_time 2014-03-21 12:34:56(格式YYYY-MM-DD HH:mm:ss)
		///</summary>
		
		private string update_time_;
		
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
		public string GetResult_desc(){
			return this.result_desc_;
		}
		
		public void SetResult_desc(string value){
			this.result_desc_ = value;
		}
		public int? GetIs_deleted(){
			return this.is_deleted_;
		}
		
		public void SetIs_deleted(int? value){
			this.is_deleted_ = value;
		}
		public string GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(string value){
			this.create_time_ = value;
		}
		public string GetUpdate_time(){
			return this.update_time_;
		}
		
		public void SetUpdate_time(string value){
			this.update_time_ = value;
		}
		
	}
	
}