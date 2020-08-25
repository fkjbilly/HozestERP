using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.order{
	
	
	
	
	
	public class OrderItemInfo {
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string size_sn_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string name_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 商品单价
		///</summary>
		
		private double? price_;
		
		///<summary>
		/// 品牌名称
		///</summary>
		
		private string brand_name_;
		
		///<summary>
		/// 商品尺码
		///</summary>
		
		private string size_;
		
		///<summary>
		/// 商品前置名
		///</summary>
		
		private string fore_word_;
		
		///<summary>
		/// 档期号
		///</summary>
		
		private string brand_id_;
		
		public string GetSize_sn(){
			return this.size_sn_;
		}
		
		public void SetSize_sn(string value){
			this.size_sn_ = value;
		}
		public string GetName(){
			return this.name_;
		}
		
		public void SetName(string value){
			this.name_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public double? GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(double? value){
			this.price_ = value;
		}
		public string GetBrand_name(){
			return this.brand_name_;
		}
		
		public void SetBrand_name(string value){
			this.brand_name_ = value;
		}
		public string GetSize(){
			return this.size_;
		}
		
		public void SetSize(string value){
			this.size_ = value;
		}
		public string GetFore_word(){
			return this.fore_word_;
		}
		
		public void SetFore_word(string value){
			this.fore_word_ = value;
		}
		public string GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(string value){
			this.brand_id_ = value;
		}
		
	}
	
}