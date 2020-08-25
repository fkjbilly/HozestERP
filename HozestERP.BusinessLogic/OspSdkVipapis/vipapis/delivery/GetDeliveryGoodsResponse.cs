using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetDeliveryGoodsResponse {
		
		///<summary>
		/// po单下送货单信息列表
		///</summary>
		
		private List<vipapis.delivery.DeliveryGoodsList> delivery_goods_list_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? total_;
		
		public List<vipapis.delivery.DeliveryGoodsList> GetDelivery_goods_list(){
			return this.delivery_goods_list_;
		}
		
		public void SetDelivery_goods_list(List<vipapis.delivery.DeliveryGoodsList> value){
			this.delivery_goods_list_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}