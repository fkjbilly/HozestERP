using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.omni.wo{
	
	
	
	
	
	public class WorkOrderAttach {
		
		///<summary>
		/// 工单号
		///</summary>
		
		private string woNo_;
		
		///<summary>
		/// 用户上传时间
		///</summary>
		
		private System.DateTime? createTime_;
		
		///<summary>
		/// 用户上传文件名
		///</summary>
		
		private string fileName_;
		
		///<summary>
		/// 附件地址
		///</summary>
		
		private string filePath_;
		
		public string GetWoNo(){
			return this.woNo_;
		}
		
		public void SetWoNo(string value){
			this.woNo_ = value;
		}
		public System.DateTime? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(System.DateTime? value){
			this.createTime_ = value;
		}
		public string GetFileName(){
			return this.fileName_;
		}
		
		public void SetFileName(string value){
			this.fileName_ = value;
		}
		public string GetFilePath(){
			return this.filePath_;
		}
		
		public void SetFilePath(string value){
			this.filePath_ = value;
		}
		
	}
	
}