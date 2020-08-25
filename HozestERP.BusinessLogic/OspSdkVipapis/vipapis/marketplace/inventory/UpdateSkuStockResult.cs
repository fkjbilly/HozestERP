using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.inventory{
	
	
	
	
	
	public class UpdateSkuStockResult {
		
		///<summary>
		/// 库存更新结果：true代表成功，返回更新后的可销售库存数量（leavings）；false代表失败
		///</summary>
		
		private bool? success_;
		
		///<summary>
		/// 响应码
		///</summary>
		
		private string code_;
		
		///<summary>
		/// 响应消息
		///</summary>
		
		private string msg_;
		
		///<summary>
		/// 可能超卖的数量，大于0表示目前可能已超卖
		///</summary>
		
		private int? oversellingNum_;
		
		public bool? GetSuccess(){
			return this.success_;
		}
		
		public void SetSuccess(bool? value){
			this.success_ = value;
		}
		public string GetCode(){
			return this.code_;
		}
		
		public void SetCode(string value){
			this.code_ = value;
		}
		public string GetMsg(){
			return this.msg_;
		}
		
		public void SetMsg(string value){
			this.msg_ = value;
		}
		public int? GetOversellingNum(){
			return this.oversellingNum_;
		}
		
		public void SetOversellingNum(int? value){
			this.oversellingNum_ = value;
		}
		
	}
	
}