using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class ExportProduct {
		
		///<summary>
		/// 订单编码
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// PO单编号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 货号
		///</summary>
		
		private string art_no_;
		
		///<summary>
		/// 商品尺寸
		///</summary>
		
		private string size_;
		
		///<summary>
		/// 品牌中文名称
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 商品售卖价格
		///</summary>
		
		private string sell_price_;
		
		///<summary>
		/// 是否礼品,G:礼品 NULL:非礼品
		///</summary>
		
		private string is_gift_;
		
		///<summary>
		/// 单位
		///</summary>
		
		private string unit_;
		
		///<summary>
		/// 专场类型
		///</summary>
		
		private int? is_vip_;
		
		///<summary>
		/// 商品图片
		///</summary>
		
		private string product_pic_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private string create_time_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public string GetArt_no(){
			return this.art_no_;
		}
		
		public void SetArt_no(string value){
			this.art_no_ = value;
		}
		public string GetSize(){
			return this.size_;
		}
		
		public void SetSize(string value){
			this.size_ = value;
		}
		public string GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(string value){
			this.brand_name_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public string GetSell_price(){
			return this.sell_price_;
		}
		
		public void SetSell_price(string value){
			this.sell_price_ = value;
		}
		public string GetIs_gift(){
			return this.is_gift_;
		}
		
		public void SetIs_gift(string value){
			this.is_gift_ = value;
		}
		public string GetUnit(){
			return this.unit_;
		}
		
		public void SetUnit(string value){
			this.unit_ = value;
		}
		public int? GetIs_vip(){
			return this.is_vip_;
		}
		
		public void SetIs_vip(int? value){
			this.is_vip_ = value;
		}
		public string GetProduct_pic(){
			return this.product_pic_;
		}
		
		public void SetProduct_pic(string value){
			this.product_pic_ = value;
		}
		public string GetCreate_time(){
			return this.create_time_;
		}
		
		public void SetCreate_time(string value){
			this.create_time_ = value;
		}
		
	}
	
}