using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.feedback.osp.service{
	
	
	
	
	
	public class HtFeedbackMessageResponse {
		
		///<summary>
		/// 响应代码：200 接收成功
		///400 请求参数有误
		///500 处理异常
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 响应描述
		///</summary>
		
		private string desc_;
		
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public string GetDesc(){
			return this.desc_;
		}
		
		public void SetDesc(string value){
			this.desc_ = value;
		}
		
	}
	
}