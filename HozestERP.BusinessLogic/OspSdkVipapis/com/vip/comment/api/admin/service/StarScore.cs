using System;

namespace com.vip.comment.api.admin.service{
	
	
	public enum StarScore {
		
		
		///<summary>
		/// 一星非常不满意
		///</summary>
		OneStart = 1, 
		
		///<summary>
		/// 二星不满意
		///</summary>
		TwoStarts = 2, 
		
		///<summary>
		/// 三星一般
		///</summary>
		ThreeStarts = 3, 
		
		///<summary>
		/// 四星满意
		///</summary>
		FourStarts = 4, 
		
		///<summary>
		/// 五星非常满意
		///</summary>
		FiveStarts = 5 
	}
	
	public class StarScoreUtil{
		
		private readonly int value;
		private StarScoreUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static StarScore? FindByValue(int value){
			
			switch(value){
				
				case 1: return StarScore.OneStart; 
				case 2: return StarScore.TwoStarts; 
				case 3: return StarScore.ThreeStarts; 
				case 4: return StarScore.FourStarts; 
				case 5: return StarScore.FiveStarts; 
				
				default: return null; 
				
			}
			
		}
		
		public static StarScore? FindByName(string name){
			
			if(StarScore.OneStart.ToString().Equals(name)){
				
				return StarScore.OneStart; 
			}
			
			if(StarScore.TwoStarts.ToString().Equals(name)){
				
				return StarScore.TwoStarts; 
			}
			
			if(StarScore.ThreeStarts.ToString().Equals(name)){
				
				return StarScore.ThreeStarts; 
			}
			
			if(StarScore.FourStarts.ToString().Equals(name)){
				
				return StarScore.FourStarts; 
			}
			
			if(StarScore.FiveStarts.ToString().Equals(name)){
				
				return StarScore.FiveStarts; 
			}
			
			
			return null;
			
		}
		
	}
	
}