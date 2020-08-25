using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.puma{
	
	
	
	
	
	public class ChannelProductSelection {
		
		///<summary>
		/// 商品标题
		///</summary>
		
		private string title_;
		
		///<summary>
		/// 描述
		///</summary>
		
		private string desc_;
		
		///<summary>
		/// 市场价格
		///</summary>
		
		private string market_price_;
		
		///<summary>
		/// 唯品会销售价格
		///</summary>
		
		private string price_;
		
		///<summary>
		/// 是否有库存(1:有;0:没有)
		///</summary>
		
		private string stock_;
		
		///<summary>
		/// 运费
		///</summary>
		
		private string freight_;
		
		///<summary>
		/// 商品图片url
		///</summary>
		
		private List<string> pics_;
		
		public string GetTitle(){
			return this.title_;
		}
		
		public void SetTitle(string value){
			this.title_ = value;
		}
		public string GetDesc(){
			return this.desc_;
		}
		
		public void SetDesc(string value){
			this.desc_ = value;
		}
		public string GetMarket_price(){
			return this.market_price_;
		}
		
		public void SetMarket_price(string value){
			this.market_price_ = value;
		}
		public string GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(string value){
			this.price_ = value;
		}
		public string GetStock(){
			return this.stock_;
		}
		
		public void SetStock(string value){
			this.stock_ = value;
		}
		public string GetFreight(){
			return this.freight_;
		}
		
		public void SetFreight(string value){
			this.freight_ = value;
		}
		public List<string> GetPics(){
			return this.pics_;
		}
		
		public void SetPics(List<string> value){
			this.pics_ = value;
		}
		
	}
	
}