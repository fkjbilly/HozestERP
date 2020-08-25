using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.puma{
	
	
	
	
	
	public class Price {
		
		///<summary>
		/// 唯品会销售价格
		///</summary>
		
		private string vip_price_;
		
		///<summary>
		/// 市场价格
		///</summary>
		
		private string market_price_;
		
		///<summary>
		/// 折扣
		///</summary>
		
		private string discount_;
		
		///<summary>
		/// 价格生效时间（Epoch格式秒）
		///</summary>
		
		private long? effective_start_time_;
		
		///<summary>
		/// 价格失效时间（Epoch格式秒）
		///</summary>
		
		private long? effective_end_time_;
		
		public string GetVip_price(){
			return this.vip_price_;
		}
		
		public void SetVip_price(string value){
			this.vip_price_ = value;
		}
		public string GetMarket_price(){
			return this.market_price_;
		}
		
		public void SetMarket_price(string value){
			this.market_price_ = value;
		}
		public string GetDiscount(){
			return this.discount_;
		}
		
		public void SetDiscount(string value){
			this.discount_ = value;
		}
		public long? GetEffective_start_time(){
			return this.effective_start_time_;
		}
		
		public void SetEffective_start_time(long? value){
			this.effective_start_time_ = value;
		}
		public long? GetEffective_end_time(){
			return this.effective_end_time_;
		}
		
		public void SetEffective_end_time(long? value){
			this.effective_end_time_ = value;
		}
		
	}
	
}