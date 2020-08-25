using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.order{
	
	
	
	
	
	public class CreateCancelCustomerBackOrderResult {
		
		///<summary>
		/// 唯一标识
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// 当前记录的序号
		///</summary>
		
		private long? max_id_;
		
		///<summary>
		/// ERP客退单号
		///</summary>
		
		private string erp_back_sn_;
		
		///<summary>
		/// 状态
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		public long? GetMax_id(){
			return this.max_id_;
		}
		
		public void SetMax_id(long? value){
			this.max_id_ = value;
		}
		public string GetErp_back_sn(){
			return this.erp_back_sn_;
		}
		
		public void SetErp_back_sn(string value){
			this.erp_back_sn_ = value;
		}
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		
	}
	
}