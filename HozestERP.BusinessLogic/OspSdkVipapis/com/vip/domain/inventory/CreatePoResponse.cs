using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class CreatePoResponse {
		
		///<summary>
		/// 操作结果
		///</summary>
		
		private com.vip.domain.inventory.PoResult? opResult_;
		
		///<summary>
		/// 系统入库凭证
		///</summary>
		
		private string systemPoNo_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		public com.vip.domain.inventory.PoResult? GetOpResult(){
			return this.opResult_;
		}
		
		public void SetOpResult(com.vip.domain.inventory.PoResult? value){
			this.opResult_ = value;
		}
		public string GetSystemPoNo(){
			return this.systemPoNo_;
		}
		
		public void SetSystemPoNo(string value){
			this.systemPoNo_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		
	}
	
}