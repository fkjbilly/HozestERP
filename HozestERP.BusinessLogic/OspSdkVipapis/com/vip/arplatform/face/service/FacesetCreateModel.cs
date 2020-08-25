using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.face.service{
	
	
	
	
	
	public class FacesetCreateModel {
		
		///<summary>
		/// 状态
		///</summary>
		
		private string status_;
		
		///<summary>
		/// 失败
		///</summary>
		
		private List<string> failed_;
		
		///<summary>
		/// 成功
		///</summary>
		
		private List<string> success_;
		
		///<summary>
		/// 进行中
		///</summary>
		
		private List<string> processing_;
		
		public string GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(string value){
			this.status_ = value;
		}
		public List<string> GetFailed(){
			return this.failed_;
		}
		
		public void SetFailed(List<string> value){
			this.failed_ = value;
		}
		public List<string> GetSuccess(){
			return this.success_;
		}
		
		public void SetSuccess(List<string> value){
			this.success_ = value;
		}
		public List<string> GetProcessing(){
			return this.processing_;
		}
		
		public void SetProcessing(List<string> value){
			this.processing_ = value;
		}
		
	}
	
}