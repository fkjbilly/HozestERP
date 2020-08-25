using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class GetLimitedOrderGoodsCountReq {
		
		///<summary>
		/// 会员ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 销售专场编号(原接口brand_id)列表，与商品编号列表不能同时为空，二选一
		///</summary>
		
		private List<long?> salesNoList_;
		
		///<summary>
		/// 商品编号(原接口goods_id)列表，与销售专场编号列表不能同时为空，二选一
		///</summary>
		
		private List<long?> merchandiseNoList_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public List<long?> GetSalesNoList(){
			return this.salesNoList_;
		}
		
		public void SetSalesNoList(List<long?> value){
			this.salesNoList_ = value;
		}
		public List<long?> GetMerchandiseNoList(){
			return this.merchandiseNoList_;
		}
		
		public void SetMerchandiseNoList(List<long?> value){
			this.merchandiseNoList_ = value;
		}
		
	}
	
}