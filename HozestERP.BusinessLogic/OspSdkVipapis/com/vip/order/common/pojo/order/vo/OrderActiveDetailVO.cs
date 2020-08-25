using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderActiveDetailVO {
		
		///<summary>
		/// 优惠活动类型
		///</summary>
		
		private int? activeType_;
		
		///<summary>
		/// 优惠活动维度
		///</summary>
		
		private int? activeField_;
		
		///<summary>
		/// 优惠活动编号
		///</summary>
		
		private string activeNo_;
		
		///<summary>
		/// 商品优惠明细列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.GoodsFavInfoVO> goodsFavInfoList_;
		
		///<summary>
		/// 优惠券列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.FavCouponInfoVO> favCouponInfoList_;
		
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
		public string GetActiveNo(){
			return this.activeNo_;
		}
		
		public void SetActiveNo(string value){
			this.activeNo_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.GoodsFavInfoVO> GetGoodsFavInfoList(){
			return this.goodsFavInfoList_;
		}
		
		public void SetGoodsFavInfoList(List<com.vip.order.common.pojo.order.vo.GoodsFavInfoVO> value){
			this.goodsFavInfoList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.FavCouponInfoVO> GetFavCouponInfoList(){
			return this.favCouponInfoList_;
		}
		
		public void SetFavCouponInfoList(List<com.vip.order.common.pojo.order.vo.FavCouponInfoVO> value){
			this.favCouponInfoList_ = value;
		}
		
	}
	
}