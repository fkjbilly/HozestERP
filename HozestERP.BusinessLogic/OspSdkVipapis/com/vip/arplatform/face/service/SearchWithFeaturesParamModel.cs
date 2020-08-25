using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.face.service{
	
	
	
	
	
	public class SearchWithFeaturesParamModel {
		
		///<summary>
		/// 人脸集合key
		///</summary>
		
		private string facesetKey_;
		
		///<summary>
		/// 用户图片
		///</summary>
		
		private string imageUrl_;
		
		///<summary>
		/// 透明度，基于（0-100）直接的一个数值，越靠近0和用户图片越相似，越靠近100和目标图片越相似
		///</summary>
		
		private int? opacity_;
		
		///<summary>
		/// 是否同步，0同步；1异步
		///</summary>
		
		private byte? asynchronization_;
		
		public string GetFacesetKey(){
			return this.facesetKey_;
		}
		
		public void SetFacesetKey(string value){
			this.facesetKey_ = value;
		}
		public string GetImageUrl(){
			return this.imageUrl_;
		}
		
		public void SetImageUrl(string value){
			this.imageUrl_ = value;
		}
		public int? GetOpacity(){
			return this.opacity_;
		}
		
		public void SetOpacity(int? value){
			this.opacity_ = value;
		}
		public byte? GetAsynchronization(){
			return this.asynchronization_;
		}
		
		public void SetAsynchronization(byte? value){
			this.asynchronization_ = value;
		}
		
	}
	
}