using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class ExportOrderByIdResponse {
		
		///<summary>
		/// 成功数量
		/// @sampleValue success_num 
		///</summary>
		
		private int? success_num_;
		
		///<summary>
		/// 成功的数据
		/// @sampleValue success_data 
		///</summary>
		
		private List<vipapis.delivery.ExportOrderInfo> success_data_;
		
		///<summary>
		/// 失败数量
		/// @sampleValue fail_num 
		///</summary>
		
		private int? fail_num_;
		
		///<summary>
		/// 失败的数据
		/// @sampleValue fail_data 
		///</summary>
		
		private List<vipapis.delivery.FailOrderId> fail_data_;
		
		public int? GetSuccess_num(){
			return this.success_num_;
		}
		
		public void SetSuccess_num(int? value){
			this.success_num_ = value;
		}
		public List<vipapis.delivery.ExportOrderInfo> GetSuccess_data(){
			return this.success_data_;
		}
		
		public void SetSuccess_data(List<vipapis.delivery.ExportOrderInfo> value){
			this.success_data_ = value;
		}
		public int? GetFail_num(){
			return this.fail_num_;
		}
		
		public void SetFail_num(int? value){
			this.fail_num_ = value;
		}
		public List<vipapis.delivery.FailOrderId> GetFail_data(){
			return this.fail_data_;
		}
		
		public void SetFail_data(List<vipapis.delivery.FailOrderId> value){
			this.fail_data_ = value;
		}
		
	}
	
}