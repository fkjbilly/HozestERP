using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.omni.wo{
	
	
	
	
	
	public class WorkOrderReply {
		
		///<summary>
		/// 工单号
		///</summary>
		
		private string wo_no_;
		
		///<summary>
		/// 处理内容
		///</summary>
		
		private string content_;
		
		///<summary>
		/// 承运商ID
		///</summary>
		
		private string carrier_id_;
		
		///<summary>
		/// 处理人
		///</summary>
		
		private string fix_user_;
		
		///<summary>
		/// 处理时间
		///</summary>
		
		private long? fix_time_;
		
		///<summary>
		/// 附件
		///</summary>
		
		private List<com.vip.vop.omni.wo.Attachment> attachments_;
		
		public string GetWo_no(){
			return this.wo_no_;
		}
		
		public void SetWo_no(string value){
			this.wo_no_ = value;
		}
		public string GetContent(){
			return this.content_;
		}
		
		public void SetContent(string value){
			this.content_ = value;
		}
		public string GetCarrier_id(){
			return this.carrier_id_;
		}
		
		public void SetCarrier_id(string value){
			this.carrier_id_ = value;
		}
		public string GetFix_user(){
			return this.fix_user_;
		}
		
		public void SetFix_user(string value){
			this.fix_user_ = value;
		}
		public long? GetFix_time(){
			return this.fix_time_;
		}
		
		public void SetFix_time(long? value){
			this.fix_time_ = value;
		}
		public List<com.vip.vop.omni.wo.Attachment> GetAttachments(){
			return this.attachments_;
		}
		
		public void SetAttachments(List<com.vip.vop.omni.wo.Attachment> value){
			this.attachments_ = value;
		}
		
	}
	
}