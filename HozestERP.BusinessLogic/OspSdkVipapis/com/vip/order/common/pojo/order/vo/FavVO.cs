using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class FavVO {
		
		///<summary>
		/// 活动类型
		///</summary>
		
		private int? activeType_;
		
		///<summary>
		/// 活动维度
		///</summary>
		
		private int? activeField_;
		
		///<summary>
		/// 优惠明细
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.FavDetailVO> favDetailList_;
		
		public int? GetActiveType(){
			return this.activeType_;
		}
		
		public void SetActiveType(int? value){
			this.activeType_ = value;
		}
		public int? GetActiveField(){
			return this.activeField_;
		}
		
		public void SetActiveField(int? value){
			this.activeField_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.FavDetailVO> GetFavDetailList(){
			return this.favDetailList_;
		}
		
		public void SetFavDetailList(List<com.vip.order.common.pojo.order.vo.FavDetailVO> value){
			this.favDetailList_ = value;
		}
		
	}
	
}