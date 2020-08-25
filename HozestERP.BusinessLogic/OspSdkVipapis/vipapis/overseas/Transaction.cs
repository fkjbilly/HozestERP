using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class Transaction {
		
		///<summary>
		/// 传输id
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// 预调拨单号
		///</summary>
		
		private string transfer_sn_;
		
		///<summary>
		/// 出仓时间
		///</summary>
		
		private string out_time_;
		
		///<summary>
		/// 总箱数
		///</summary>
		
		private int? total_cases_;
		
		///<summary>
		/// 总商品条码数
		///</summary>
		
		private int? total_skus_;
		
		///<summary>
		/// 总商品数
		///</summary>
		
		private int? total_num_;
		
		///<summary>
		/// 商品清单
		///</summary>
		
		private List<vipapis.overseas.TransactionProduct> product_list_;
		
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		public string GetTransfer_sn(){
			return this.transfer_sn_;
		}
		
		public void SetTransfer_sn(string value){
			this.transfer_sn_ = value;
		}
		public string GetOut_time(){
			return this.out_time_;
		}
		
		public void SetOut_time(string value){
			this.out_time_ = value;
		}
		public int? GetTotal_cases(){
			return this.total_cases_;
		}
		
		public void SetTotal_cases(int? value){
			this.total_cases_ = value;
		}
		public int? GetTotal_skus(){
			return this.total_skus_;
		}
		
		public void SetTotal_skus(int? value){
			this.total_skus_ = value;
		}
		public int? GetTotal_num(){
			return this.total_num_;
		}
		
		public void SetTotal_num(int? value){
			this.total_num_ = value;
		}
		public List<vipapis.overseas.TransactionProduct> GetProduct_list(){
			return this.product_list_;
		}
		
		public void SetProduct_list(List<vipapis.overseas.TransactionProduct> value){
			this.product_list_ = value;
		}
		
	}
	
}