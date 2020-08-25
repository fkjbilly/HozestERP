using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.face.service{
	
	
	
	
	
	public class ImageStylizationModel {
		
		///<summary>
		/// 输入图片
		///</summary>
		
		private string imageInPath_;
		
		///<summary>
		/// 输出图片
		///</summary>
		
		private string imageOutPath_;
		
		///<summary>
		/// 风格类型
		///</summary>
		
		private string type_;
		
		public string GetImageInPath(){
			return this.imageInPath_;
		}
		
		public void SetImageInPath(string value){
			this.imageInPath_ = value;
		}
		public string GetImageOutPath(){
			return this.imageOutPath_;
		}
		
		public void SetImageOutPath(string value){
			this.imageOutPath_ = value;
		}
		public string GetType(){
			return this.type_;
		}
		
		public void SetType(string value){
			this.type_ = value;
		}
		
	}
	
}