using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OrderGoods {
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string goods_name_;
		
		///<summary>
		/// 尺码ID
		///</summary>
		
		private int? size_id_;
		
		///<summary>
		/// 尺码说明
		///</summary>
		
		private string size_name_;
		
		///<summary>
		/// 商品数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 商品图片链接
		///</summary>
		
		private string pri_url_;
		
		///<summary>
		/// 价格,精确到分
		///</summary>
		
		private int? price_;
		
		public string GetGoods_name(){
			return this.goods_name_;
		}
		
		public void SetGoods_name(string value){
			this.goods_name_ = value;
		}
		public int? GetSize_id(){
			return this.size_id_;
		}
		
		public void SetSize_id(int? value){
			this.size_id_ = value;
		}
		public string GetSize_name(){
			return this.size_name_;
		}
		
		public void SetSize_name(string value){
			this.size_name_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public string GetPri_url(){
			return this.pri_url_;
		}
		
		public void SetPri_url(string value){
			this.pri_url_ = value;
		}
		public int? GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(int? value){
			this.price_ = value;
		}
		
	}
	
}