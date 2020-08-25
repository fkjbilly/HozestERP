using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.face.service{
	
	
	
	
	
	public class FacesetCompareResult {
		
		///<summary>
		/// 比较图片耗时
		///</summary>
		
		private long? time_used_;
		
		///<summary>
		/// 图片相似度比较结果中对应的相似度值
		///</summary>
		
		private double? confidence_;
		
		public long? GetTime_used(){
			return this.time_used_;
		}
		
		public void SetTime_used(long? value){
			this.time_used_ = value;
		}
		public double? GetConfidence(){
			return this.confidence_;
		}
		
		public void SetConfidence(double? value){
			this.confidence_ = value;
		}
		
	}
	
}