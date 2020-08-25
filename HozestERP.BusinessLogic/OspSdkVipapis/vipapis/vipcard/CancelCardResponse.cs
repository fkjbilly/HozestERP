using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vipcard{
	
	
	
	
	
	public class CancelCardResponse {
		
		///<summary>
		/// 成功数
		/// @sampleValue success_num 50
		///</summary>
		
		private int? success_num_;
		
		///<summary>
		/// 失败数
		/// @sampleValue fail_num 3
		///</summary>
		
		private int? fail_num_;
		
		///<summary>
		/// 唯品卡卡号
		///</summary>
		
		private List<vipapis.vipcard.CancelCardFailMessage> fail_message_;
		
		public int? GetSuccess_num(){
			return this.success_num_;
		}
		
		public void SetSuccess_num(int? value){
			this.success_num_ = value;
		}
		public int? GetFail_num(){
			return this.fail_num_;
		}
		
		public void SetFail_num(int? value){
			this.fail_num_ = value;
		}
		public List<vipapis.vipcard.CancelCardFailMessage> GetFail_message(){
			return this.fail_message_;
		}
		
		public void SetFail_message(List<vipapis.vipcard.CancelCardFailMessage> value){
			this.fail_message_ = value;
		}
		
	}
	
}