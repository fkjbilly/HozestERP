using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderDeliveryVO {
		
		///<summary>
		/// 地址编码
		///</summary>
		
		private string addressCode_;
		
		///<summary>
		/// 商品销售模式，取值为 [1,2,4]
		///</summary>
		
		private List<int?> saleTypeList_;
		
		///<summary>
		/// 订单仓库
		///</summary>
		
		private string orderWarehouse_;
		
		///<summary>
		/// 商品所在仓库列表
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.GoodsWarehouseVO> goodsWarehouseList_;
		
		public string GetAddressCode(){
			return this.addressCode_;
		}
		
		public void SetAddressCode(string value){
			this.addressCode_ = value;
		}
		public List<int?> GetSaleTypeList(){
			return this.saleTypeList_;
		}
		
		public void SetSaleTypeList(List<int?> value){
			this.saleTypeList_ = value;
		}
		public string GetOrderWarehouse(){
			return this.orderWarehouse_;
		}
		
		public void SetOrderWarehouse(string value){
			this.orderWarehouse_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.GoodsWarehouseVO> GetGoodsWarehouseList(){
			return this.goodsWarehouseList_;
		}
		
		public void SetGoodsWarehouseList(List<com.vip.order.common.pojo.order.vo.GoodsWarehouseVO> value){
			this.goodsWarehouseList_ = value;
		}
		
	}
	
}