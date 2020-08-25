using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.order{
	
	
	
	
	
	public class CreateCancelCustomerBackOrderInfo {
		
		///<summary>
		/// 唯一标识
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// ERP客退单号
		///</summary>
		
		private string erp_back_sn_;
		
		///<summary>
		/// 创建人
		///</summary>
		
		private string create_user_;
		
		///<summary>
		/// 取消原因
		///</summary>
		
		private string remark_;
		
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		public string GetErp_back_sn(){
			return this.erp_back_sn_;
		}
		
		public void SetErp_back_sn(string value){
			this.erp_back_sn_ = value;
		}
		public string GetCreate_user(){
			return this.create_user_;
		}
		
		public void SetCreate_user(string value){
			this.create_user_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		
	}
	
}