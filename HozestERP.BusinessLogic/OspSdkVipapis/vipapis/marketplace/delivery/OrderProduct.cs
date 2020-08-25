using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.delivery{
	
	
	
	
	
	public class OrderProduct {
		
		///<summary>
		/// 商品sku编码
		///</summary>
		
		private string sku_id_;
		
		///<summary>
		/// 商品spu编码
		///</summary>
		
		private string spu_id_;
		
		///<summary>
		/// 款号（商家新增spu时录入）
		///</summary>
		
		private string outer_spu_id_;
		
		///<summary>
		/// 条码（商家新增sku时录入）
		///</summary>
		
		private string outer_sku_id_;
		
		///<summary>
		/// 订购数量
		///</summary>
		
		private string num_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string title_;
		
		///<summary>
		/// 尺寸
		///</summary>
		
		private string size_;
		
		///<summary>
		/// 单价
		///</summary>
		
		private string price_;
		
		///<summary>
		/// 客户备注信息
		///</summary>
		
		private string customization_;
		
		public string GetSku_id(){
			return this.sku_id_;
		}
		
		public void SetSku_id(string value){
			this.sku_id_ = value;
		}
		public string GetSpu_id(){
			return this.spu_id_;
		}
		
		public void SetSpu_id(string value){
			this.spu_id_ = value;
		}
		public string GetOuter_spu_id(){
			return this.outer_spu_id_;
		}
		
		public void SetOuter_spu_id(string value){
			this.outer_spu_id_ = value;
		}
		public string GetOuter_sku_id(){
			return this.outer_sku_id_;
		}
		
		public void SetOuter_sku_id(string value){
			this.outer_sku_id_ = value;
		}
		public string GetNum(){
			return this.num_;
		}
		
		public void SetNum(string value){
			this.num_ = value;
		}
		public string GetTitle(){
			return this.title_;
		}
		
		public void SetTitle(string value){
			this.title_ = value;
		}
		public string GetSize(){
			return this.size_;
		}
		
		public void SetSize(string value){
			this.size_ = value;
		}
		public string GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(string value){
			this.price_ = value;
		}
		public string GetCustomization(){
			return this.customization_;
		}
		
		public void SetCustomization(string value){
			this.customization_ = value;
		}
		
	}
	
}