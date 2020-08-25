using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class DownloadElectronicInvoicePictureResModel {
		
		///<summary>
		/// byte[]的base64编码后字符串。将结果用base64解码后可得到电子发票pdf byte[]
		///</summary>
		
		private string pictureContent_;
		
		///<summary>
		/// 结果消息
		///</summary>
		
		private com.vip.fcs.vei.service.BaseRetMsg restulMesg_;
		
		public string GetPictureContent(){
			return this.pictureContent_;
		}
		
		public void SetPictureContent(string value){
			this.pictureContent_ = value;
		}
		public com.vip.fcs.vei.service.BaseRetMsg GetRestulMesg(){
			return this.restulMesg_;
		}
		
		public void SetRestulMesg(com.vip.fcs.vei.service.BaseRetMsg value){
			this.restulMesg_ = value;
		}
		
	}
	
}