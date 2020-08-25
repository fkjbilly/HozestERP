using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.vreturn{
	
	
	
	
	
	public class GetReturnDeliveryGoodsResponse {
		
		///<summary>
		/// 退供入库商品明细列表
		///</summary>
		
		private List<com.vip.isv.vreturn.ReturnDeliveryGoods> return_delivery_goods_;
		
		///<summary>
		/// 记录总数
		///</summary>
		
		private int? total_;
		
		public List<com.vip.isv.vreturn.ReturnDeliveryGoods> GetReturn_delivery_goods(){
			return this.return_delivery_goods_;
		}
		
		public void SetReturn_delivery_goods(List<com.vip.isv.vreturn.ReturnDeliveryGoods> value){
			this.return_delivery_goods_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}