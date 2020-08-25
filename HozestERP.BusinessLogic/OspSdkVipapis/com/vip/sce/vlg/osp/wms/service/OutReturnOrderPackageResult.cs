using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutReturnOrderPackageResult {
		
		///<summary>
		/// vlg数据ID
		///</summary>
		
		private string vlgID_;
		
		///<summary>
		/// 批次号
		///</summary>
		
		private string batchNo_;
		
		///<summary>
		/// 大包号
		///</summary>
		
		private string packageNo_;
		
		///<summary>
		/// 收包时间
		///</summary>
		
		private string receivingTime_;
		
		///<summary>
		/// 收包类型
		///</summary>
		
		private string handleType_;
		
		public string GetVlgID(){
			return this.vlgID_;
		}
		
		public void SetVlgID(string value){
			this.vlgID_ = value;
		}
		public string GetBatchNo(){
			return this.batchNo_;
		}
		
		public void SetBatchNo(string value){
			this.batchNo_ = value;
		}
		public string GetPackageNo(){
			return this.packageNo_;
		}
		
		public void SetPackageNo(string value){
			this.packageNo_ = value;
		}
		public string GetReceivingTime(){
			return this.receivingTime_;
		}
		
		public void SetReceivingTime(string value){
			this.receivingTime_ = value;
		}
		public string GetHandleType(){
			return this.handleType_;
		}
		
		public void SetHandleType(string value){
			this.handleType_ = value;
		}
		
	}
	
}