using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class MergeOrderReq {
		
		///<summary>
		/// 会员id 
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 主订单id 
		///</summary>
		
		private long? mainOrderId_;
		
		///<summary>
		/// 要被合并的订单id列表 
		///</summary>
		
		private List<long?> orderIdList_;
		
		///<summary>
		/// 主订单SN 
		///</summary>
		
		private string mainOrderSn_;
		
		///<summary>
		/// 要被合并的订单SN列表 
		///</summary>
		
		private List<string> orderSnList_;
		
		///<summary>
		/// 新客户来源 
		///</summary>
		
		private string customerSrc_;
		
		///<summary>
		/// 货到付款方式
		///</summary>
		
		private string codType_;
		
		///<summary>
		/// 支付宝钱包到付账号 
		///</summary>
		
		private string codAppAccount_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public long? GetMainOrderId(){
			return this.mainOrderId_;
		}
		
		public void SetMainOrderId(long? value){
			this.mainOrderId_ = value;
		}
		public List<long?> GetOrderIdList(){
			return this.orderIdList_;
		}
		
		public void SetOrderIdList(List<long?> value){
			this.orderIdList_ = value;
		}
		public string GetMainOrderSn(){
			return this.mainOrderSn_;
		}
		
		public void SetMainOrderSn(string value){
			this.mainOrderSn_ = value;
		}
		public List<string> GetOrderSnList(){
			return this.orderSnList_;
		}
		
		public void SetOrderSnList(List<string> value){
			this.orderSnList_ = value;
		}
		public string GetCustomerSrc(){
			return this.customerSrc_;
		}
		
		public void SetCustomerSrc(string value){
			this.customerSrc_ = value;
		}
		public string GetCodType(){
			return this.codType_;
		}
		
		public void SetCodType(string value){
			this.codType_ = value;
		}
		public string GetCodAppAccount(){
			return this.codAppAccount_;
		}
		
		public void SetCodAppAccount(string value){
			this.codAppAccount_ = value;
		}
		
	}
	
}