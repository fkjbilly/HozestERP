using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.omni.wo{
	
	
	
	
	
	public class Attachment {
		
		///<summary>
		/// 附件名称
		///</summary>
		
		private string file_name_;
		
		///<summary>
		/// 附件路径
		///</summary>
		
		private string file_path_;
		
		public string GetFile_name(){
			return this.file_name_;
		}
		
		public void SetFile_name(string value){
			this.file_name_ = value;
		}
		public string GetFile_path(){
			return this.file_path_;
		}
		
		public void SetFile_path(string value){
			this.file_path_ = value;
		}
		
	}
	
}