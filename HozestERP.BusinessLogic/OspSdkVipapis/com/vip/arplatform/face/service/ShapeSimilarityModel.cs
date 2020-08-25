using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.face.service{
	
	
	
	
	
	public class ShapeSimilarityModel {
		
		///<summary>
		/// 原始图片
		///</summary>
		
		private string imgSrc_;
		
		///<summary>
		/// 目标图片
		///</summary>
		
		private string imgTarget_;
		
		///<summary>
		/// 输出图片
		///</summary>
		
		private string imgTargetOut_;
		
		///<summary>
		/// 代码
		///</summary>
		
		private int? code_;
		
		///<summary>
		/// 分值
		///</summary>
		
		private double? simScores_;
		
		///<summary>
		/// 错误信息
		///</summary>
		
		private string message_;
		
		public string GetImgSrc(){
			return this.imgSrc_;
		}
		
		public void SetImgSrc(string value){
			this.imgSrc_ = value;
		}
		public string GetImgTarget(){
			return this.imgTarget_;
		}
		
		public void SetImgTarget(string value){
			this.imgTarget_ = value;
		}
		public string GetImgTargetOut(){
			return this.imgTargetOut_;
		}
		
		public void SetImgTargetOut(string value){
			this.imgTargetOut_ = value;
		}
		public int? GetCode(){
			return this.code_;
		}
		
		public void SetCode(int? value){
			this.code_ = value;
		}
		public double? GetSimScores(){
			return this.simScores_;
		}
		
		public void SetSimScores(double? value){
			this.simScores_ = value;
		}
		public string GetMessage(){
			return this.message_;
		}
		
		public void SetMessage(string value){
			this.message_ = value;
		}
		
	}
	
}