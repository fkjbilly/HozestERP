using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.pg{
	
	
	
	
	
	public class Inventory {
		
		///<summary>
		/// 产品名称
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
		/// 库存数量
		///</summary>
		
		private int? stock_quantity_;
		
		///<summary>
		/// 库存天数
		///</summary>
		
		private int? stock_day_;
		
		///<summary>
		/// 所属仓库
		///</summary>
		
		private string warehouse_code_;
		
		///<summary>
		/// 供货商
		///</summary>
		
		private string vendor_name_;
		
		///<summary>
		/// 7天平均日销
		///</summary>
		
		private double? day_sale_average_one_week_;
		
		///<summary>
		/// 14天平均日销
		///</summary>
		
		private double? day_sale_average_two_week_;
		
		///<summary>
		/// 28天平均日销
		///</summary>
		
		private double? day_sale_average_four_week_;
		
		///<summary>
		/// 库存日期
		///</summary>
		
		private string stock_date_;
		
		///<summary>
		/// 库龄
		///</summary>
		
		private int? stock_age_;
		
		///<summary>
		/// 入库凭证
		///</summary>
		
		private string po_;
		
		///<summary>
		/// 库存类型
		///</summary>
		
		private string stock_type_;
		
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
		public int? GetStock_quantity(){
			return this.stock_quantity_;
		}
		
		public void SetStock_quantity(int? value){
			this.stock_quantity_ = value;
		}
		public int? GetStock_day(){
			return this.stock_day_;
		}
		
		public void SetStock_day(int? value){
			this.stock_day_ = value;
		}
		public string GetWarehouse_code(){
			return this.warehouse_code_;
		}
		
		public void SetWarehouse_code(string value){
			this.warehouse_code_ = value;
		}
		public string GetVendor_name(){
			return this.vendor_name_;
		}
		
		public void SetVendor_name(string value){
			this.vendor_name_ = value;
		}
		public double? GetDay_sale_average_one_week(){
			return this.day_sale_average_one_week_;
		}
		
		public void SetDay_sale_average_one_week(double? value){
			this.day_sale_average_one_week_ = value;
		}
		public double? GetDay_sale_average_two_week(){
			return this.day_sale_average_two_week_;
		}
		
		public void SetDay_sale_average_two_week(double? value){
			this.day_sale_average_two_week_ = value;
		}
		public double? GetDay_sale_average_four_week(){
			return this.day_sale_average_four_week_;
		}
		
		public void SetDay_sale_average_four_week(double? value){
			this.day_sale_average_four_week_ = value;
		}
		public string GetStock_date(){
			return this.stock_date_;
		}
		
		public void SetStock_date(string value){
			this.stock_date_ = value;
		}
		public int? GetStock_age(){
			return this.stock_age_;
		}
		
		public void SetStock_age(int? value){
			this.stock_age_ = value;
		}
		public string GetPo(){
			return this.po_;
		}
		
		public void SetPo(string value){
			this.po_ = value;
		}
		public string GetStock_type(){
			return this.stock_type_;
		}
		
		public void SetStock_type(string value){
			this.stock_type_ = value;
		}
		
	}
	
}