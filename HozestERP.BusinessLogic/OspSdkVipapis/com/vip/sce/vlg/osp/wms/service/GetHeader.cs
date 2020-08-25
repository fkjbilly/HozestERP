using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class GetHeader {
		
		///<summary>
		/// 返回时间(yyyy-mm-dd hh:MM:ss)
		///</summary>
		
		private string returnHeaderTime_;
		
		///<summary>
		/// 返回编码
		///</summary>
		
		private string returnHeaderCode_;
		
		///<summary>
		/// 返回消息
		///</summary>
		
		private string retrunHeaderMessage_;
		
		public string GetReturnHeaderTime(){
			return this.returnHeaderTime_;
		}
		
		public void SetReturnHeaderTime(string value){
			this.returnHeaderTime_ = value;
		}
		public string GetReturnHeaderCode(){
			return this.returnHeaderCode_;
		}
		
		public void SetReturnHeaderCode(string value){
			this.returnHeaderCode_ = value;
		}
		public string GetRetrunHeaderMessage(){
			return this.retrunHeaderMessage_;
		}
		
		public void SetRetrunHeaderMessage(string value){
			this.retrunHeaderMessage_ = value;
		}
		
	}
	
}