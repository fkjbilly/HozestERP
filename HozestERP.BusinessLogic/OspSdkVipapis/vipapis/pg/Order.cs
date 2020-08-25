using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.pg{
	
	
	
	
	
	public class Order {
		
		///<summary>
		/// VIP订单号
		///</summary>
		
		private string order_sn_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string goods_name_;
		
		///<summary>
		/// 产品条码
		///</summary>
		
		private string goods_barcode_;
		
		///<summary>
		/// 一级品类名称
		///</summary>
		
		private string cat1_name_;
		
		///<summary>
		/// 所属仓库
		///</summary>
		
		private string warehouse_code_;
		
		///<summary>
		/// 订单创建时间
		///</summary>
		
		private string order_date_;
		
		///<summary>
		/// 采购数量
		///</summary>
		
		private int? purchase_quantity_;
		
		///<summary>
		/// 订单状态
		///</summary>
		
		private string order_status_;
		
		///<summary>
		/// 实际订单数量
		///</summary>
		
		private int? order_quantity_;
		
		///<summary>
		/// 实际收货数量
		///</summary>
		
		private string receive_quantity_;
		
		///<summary>
		/// 到货时间
		///</summary>
		
		private string arrival_time_;
		
		///<summary>
		/// 库存日期
		///</summary>
		
		private string stock_date_;
		
		///<summary>
		/// 最后修改时间
		///</summary>
		
		private string modified_time_;
		
		public string GetOrder_sn(){
			return this.order_sn_;
		}
		
		public void SetOrder_sn(string value){
			this.order_sn_ = value;
		}
		public string GetGoods_name(){
			return this.goods_name_;
		}
		
		public void SetGoods_name(string value){
			this.goods_name_ = value;
		}
		public string GetGoods_barcode(){
			return this.goods_barcode_;
		}
		
		public void SetGoods_barcode(string value){
			this.goods_barcode_ = value;
		}
		public string GetCat1_name(){
			return this.cat1_name_;
		}
		
		public void SetCat1_name(string value){
			this.cat1_name_ = value;
		}
		public string GetWarehouse_code(){
			return this.warehouse_code_;
		}
		
		public void SetWarehouse_code(string value){
			this.warehouse_code_ = value;
		}
		public string GetOrder_date(){
			return this.order_date_;
		}
		
		public void SetOrder_date(string value){
			this.order_date_ = value;
		}
		public int? GetPurchase_quantity(){
			return this.purchase_quantity_;
		}
		
		public void SetPurchase_quantity(int? value){
			this.purchase_quantity_ = value;
		}
		public string GetOrder_status(){
			return this.order_status_;
		}
		
		public void SetOrder_status(string value){
			this.order_status_ = value;
		}
		public int? GetOrder_quantity(){
			return this.order_quantity_;
		}
		
		public void SetOrder_quantity(int? value){
			this.order_quantity_ = value;
		}
		public string GetReceive_quantity(){
			return this.receive_quantity_;
		}
		
		public void SetReceive_quantity(string value){
			this.receive_quantity_ = value;
		}
		public string GetArrival_time(){
			return this.arrival_time_;
		}
		
		public void SetArrival_time(string value){
			this.arrival_time_ = value;
		}
		public string GetStock_date(){
			return this.stock_date_;
		}
		
		public void SetStock_date(string value){
			this.stock_date_ = value;
		}
		public string GetModified_time(){
			return this.modified_time_;
		}
		
		public void SetModified_time(string value){
			this.modified_time_ = value;
		}
		
	}
	
}