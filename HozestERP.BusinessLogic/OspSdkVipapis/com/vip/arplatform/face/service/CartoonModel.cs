using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.face.service{
	
	
	
	
	
	public class CartoonModel {
		
		///<summary>
		/// 输入图片
		///</summary>
		
		private string imageInPath_;
		
		///<summary>
		/// 输出图片
		///</summary>
		
		private string imageOutPath_;
		
		///<summary>
		/// 脸部图片
		///</summary>
		
		private string faceUrl_;
		
		///<summary>
		/// 无脸图片
		///</summary>
		
		private string faceLessUrl_;
		
		///<summary>
		/// 红色差信号
		///</summary>
		
		private int? cr_;
		
		///<summary>
		/// 蓝色差信号
		///</summary>
		
		private int? cb_;
		
		///<summary>
		/// 三角片坐标组
		///</summary>
		
		private string point_;
		
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
		public string GetFaceUrl(){
			return this.faceUrl_;
		}
		
		public void SetFaceUrl(string value){
			this.faceUrl_ = value;
		}
		public string GetFaceLessUrl(){
			return this.faceLessUrl_;
		}
		
		public void SetFaceLessUrl(string value){
			this.faceLessUrl_ = value;
		}
		public int? GetCr(){
			return this.cr_;
		}
		
		public void SetCr(int? value){
			this.cr_ = value;
		}
		public int? GetCb(){
			return this.cb_;
		}
		
		public void SetCb(int? value){
			this.cb_ = value;
		}
		public string GetPoint(){
			return this.point_;
		}
		
		public void SetPoint(string value){
			this.point_ = value;
		}
		
	}
	
}