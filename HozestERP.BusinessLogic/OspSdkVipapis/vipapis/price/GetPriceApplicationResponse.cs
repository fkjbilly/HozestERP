using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.price{
	
	
	
	
	
	public class GetPriceApplicationResponse {
		
		///<summary>
		/// 价格申请单号
		///</summary>
		
		private string application_id_;
		
		///<summary>
		/// 总记录数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 清单状态
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 异常状态
		///</summary>
		
		private string exception_status_;
		
		///<summary>
		/// 变价生效时间
		///</summary>
		
		private System.DateTime? effective_start_time_;
		
		///<summary>
		/// 变价失效时间
		///</summary>
		
		private System.DateTime? effective_end_time_;
		
		///<summary>
		/// 最新操作记录的memo信息
		///</summary>
		
		private string memo_;
		
		///<summary>
		/// 清单明细信息
		///</summary>
		
		private List<vipapis.price.PriceApplicationDetail> price_details_;
		
		public string GetApplication_id(){
			return this.application_id_;
		}
		
		public void SetApplication_id(string value){
			this.application_id_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public string GetException_status(){
			return this.exception_status_;
		}
		
		public void SetException_status(string value){
			this.exception_status_ = value;
		}
		public System.DateTime? GetEffective_start_time(){
			return this.effective_start_time_;
		}
		
		public void SetEffective_start_time(System.DateTime? value){
			this.effective_start_time_ = value;
		}
		public System.DateTime? GetEffective_end_time(){
			return this.effective_end_time_;
		}
		
		public void SetEffective_end_time(System.DateTime? value){
			this.effective_end_time_ = value;
		}
		public string GetMemo(){
			return this.memo_;
		}
		
		public void SetMemo(string value){
			this.memo_ = value;
		}
		public List<vipapis.price.PriceApplicationDetail> GetPrice_details(){
			return this.price_details_;
		}
		
		public void SetPrice_details(List<vipapis.price.PriceApplicationDetail> value){
			this.price_details_ = value;
		}
		
	}
	
}