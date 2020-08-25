using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class DownloadElectronicInvoiceResModel {
		
		///<summary>
		/// byte[]的base64编码后字符串。将结果用base64解码后可得到电子发票pdf byte[]
		///</summary>
		
		private string pdfContent_;
		
		///<summary>
		/// 结果消息
		///</summary>
		
		private com.vip.fcs.vei.service.BaseRetMsg restulMesg_;
		
		///<summary>
		/// 结果状态
		///</summary>
		
		private bool? result_;
		
		public string GetPdfContent(){
			return this.pdfContent_;
		}
		
		public void SetPdfContent(string value){
			this.pdfContent_ = value;
		}
		public com.vip.fcs.vei.service.BaseRetMsg GetRestulMesg(){
			return this.restulMesg_;
		}
		
		public void SetRestulMesg(com.vip.fcs.vei.service.BaseRetMsg value){
			this.restulMesg_ = value;
		}
		public bool? GetResult(){
			return this.result_;
		}
		
		public void SetResult(bool? value){
			this.result_ = value;
		}
		
	}
	
}