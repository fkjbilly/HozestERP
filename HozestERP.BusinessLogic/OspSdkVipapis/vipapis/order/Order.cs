using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class Order {
		
		///<summary>
		/// 订单编号
		///</summary>
		
		private long? order_sn_;
		
		///<summary>
		/// 订单状态中文名
		///</summary>
		
		private string status_name_;
		
		///<summary>
		/// 下单时间, 精确到秒
		///</summary>
		
		private int? order_date_;
		
		///<summary>
		/// 订单金额(在线支付部分), 精确到分
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 收货人姓名
		///</summary>
		
		private string buyer_name_;
		
		///<summary>
		/// 收货人地址
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 收货人邮编
		///</summary>
		
		private string postcode_;
		
		///<summary>
		/// 收货人手机
		///</summary>
		
		private string mobile_;
		
		///<summary>
		/// 收货人电话
		///</summary>
		
		private string tel_;
		
		///<summary>
		/// 物流单号
		///</summary>
		
		private string transport_sn_;
		
		///<summary>
		/// 物流公司
		///</summary>
		
		private string transport_name_;
		
		///<summary>
		/// 运费, 精确到分
		///</summary>
		
		private int? carriage_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private int? goods_amount_;
		
		///<summary>
		/// 订单生成时间, 精确到秒
		///</summary>
		
		private int? create_time_;
		
		///<summary>
		/// 最近一次更新时间, 精确到秒
		///</summary>
		
		private int? update_time_;
		
		///<summary>
		/// 订单商品
		///</summary>
		
		private List<vipapis.order.OrderGoods> order_goods_;
		
		public long? GetOrder_sn(){
			return this.order_sn_;
		}
		
		public void SetOrder_sn(long? value){
			this.order_sn_ = value;
		}
		public string GetStatus_name(){
			return this.status_name_;
		}
		
		public void SetStatus_name(string value){
			this.status_name_ = value;
		}
		public int? GetOrder_date(){
			return this.order_date_;
		}
		
		public void SetOrder_date(int? value){
			this.order_date_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public string GetBuyer_name(){
			return this.buyer_name_;
		}
		
		public void SetBuyer_name(string value){
			this.buyer_name_ = value;
		}
		public string GetAddress(){
			return this.address_;
		}
		
		public void SetAddress(string value){
			this.address_ = value;
		}
		public string GetPostcode(){
			return this.postcode_;
		}
		
		public void SetPostcode(string value){
			this.postcode_ = value;
		}
		public string GetMobile(){
			return this.mobile_;
		}
		
		public void SetMobile(string value){
			this.mobile_ = value;
		}
		public string GetTel(){
			return this.tel_;
		}
		
		public void SetTel(string value){
			this.tel_ = value;
		}
		public string GetTransport_sn(){
			return this.transport_sn_;
		}
		
		public void SetTransport_sn(string value){
			this.transport_sn_ = value;
		}
		public string GetTransport_name(){
			return this.transport_name_;
		}
		
		public void SetTransport_name(string value){
			this.transport_name_ = value;
		}
		public int? GetCarriage(){
			return this.carriage_;
		}
		
		public void SetCarriage(int? value){
			this.carriage_ = value;
		}
		public int? GetGoods_amount(){
			return this.goods_amount_;
		}
		
		public void SetGoods_amount(int? value){
			this.goods_amount_ = value;
		}
		public int? GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(int? value){
			this.create_time_ = value;
		}
		public int? GetUpdate_time(){
			return this.update_time_;
		}
		
		public void SetUpdate_time(int? value){
			this.update_time_ = value;
		}
		public List<vipapis.order.OrderGoods> GetOrder_goods(){
			return this.order_goods_;
		}
		
		public void SetOrder_goods(List<vipapis.order.OrderGoods> value){
			this.order_goods_ = value;
		}
		
	}
	
}