using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class ReturnOutInfo {
		
		///<summary>
		/// 传输id
		/// @sampleValue transaction_id 1234567810
		///</summary>
		
		private string transaction_id_;
		
		///<summary>
		/// 供应商编码
		///</summary>
		
		private string vendor_code_;
		
		///<summary>
		/// 退供单号
		///</summary>
		
		private string return_sn_;
		
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
		/// 订单详细列表
		///</summary>
		
		private List<vipapis.overseas.ReturnOutDetail> order_detail_list_;
		
		public string GetTransaction_id(){
			return this.transaction_id_;
		}
		
		public void SetTransaction_id(string value){
			this.transaction_id_ = value;
		}
		public string GetVendor_code(){
			return this.vendor_code_;
		}
		
		public void SetVendor_code(string value){
			this.vendor_code_ = value;
		}
		public string GetReturn_sn(){
			return this.return_sn_;
		}
		
		public void SetReturn_sn(string value){
			this.return_sn_ = value;
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
		public List<vipapis.overseas.ReturnOutDetail> GetOrder_detail_list(){
			return this.order_detail_list_;
		}
		
		public void SetOrder_detail_list(List<vipapis.overseas.ReturnOutDetail> value){
			this.order_detail_list_ = value;
		}
		
	}
	
}