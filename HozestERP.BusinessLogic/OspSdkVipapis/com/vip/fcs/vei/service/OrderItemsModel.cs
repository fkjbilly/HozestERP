using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class OrderItemsModel {
		
		///<summary>
		/// 名称(包含品牌)
		///</summary>
		
		private string name_;
		
		///<summary>
		/// 单位
		///</summary>
		
		private string unit_;
		
		///<summary>
		/// 单价
		///</summary>
		
		private double? price_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private int? number_;
		
		///<summary>
		/// 金额
		///</summary>
		
		private double? amount_;
		
		///<summary>
		/// 型号
		///</summary>
		
		private string model_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string goodsSn_;
		
		///<summary>
		/// 税率。2位小数
		///</summary>
		
		private double? taxRate_;
		
		///<summary>
		/// 商品税目编码。长度为19
		///</summary>
		
		private string goodsTaxClassifyCode_;
		
		public string GetName(){
			return this.name_;
		}
		
		public void SetName(string value){
			this.name_ = value;
		}
		public string GetUnit(){
			return this.unit_;
		}
		
		public void SetUnit(string value){
			this.unit_ = value;
		}
		public double? GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(double? value){
			this.price_ = value;
		}
		public int? GetNumber(){
			return this.number_;
		}
		
		public void SetNumber(int? value){
			this.number_ = value;
		}
		public double? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(double? value){
			this.amount_ = value;
		}
		public string GetModel(){
			return this.model_;
		}
		
		public void SetModel(string value){
			this.model_ = value;
		}
		public string GetGoodsSn(){
			return this.goodsSn_;
		}
		
		public void SetGoodsSn(string value){
			this.goodsSn_ = value;
		}
		public double? GetTaxRate(){
			return this.taxRate_;
		}
		
		public void SetTaxRate(double? value){
			this.taxRate_ = value;
		}
		public string GetGoodsTaxClassifyCode(){
			return this.goodsTaxClassifyCode_;
		}
		
		public void SetGoodsTaxClassifyCode(string value){
			this.goodsTaxClassifyCode_ = value;
		}
		
	}
	
}