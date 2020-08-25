using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class BatchInfo {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private string vendor_id_;
		
		///<summary>
		/// PO单编号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 合作模式
		///</summary>
		
		private string co_mode_;
		
		///<summary>
		/// 贸易模式
		///</summary>
		
		private string trade_mode_;
		
		///<summary>
		/// 托盘类型
		///</summary>
		
		private string pallet_;
		
		///<summary>
		/// 档期ID
		///</summary>
		
		private string schedule_id_;
		
		///<summary>
		/// 商品明细列表
		///</summary>
		
		private List<vipapis.overseas.BatchDetailInfo> product_list_;
		
		public string GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(string value){
			this.vendor_id_ = value;
		}
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetCo_mode(){
			return this.co_mode_;
		}
		
		public void SetCo_mode(string value){
			this.co_mode_ = value;
		}
		public string GetTrade_mode(){
			return this.trade_mode_;
		}
		
		public void SetTrade_mode(string value){
			this.trade_mode_ = value;
		}
		public string GetPallet(){
			return this.pallet_;
		}
		
		public void SetPallet(string value){
			this.pallet_ = value;
		}
		public string GetSchedule_id(){
			return this.schedule_id_;
		}
		
		public void SetSchedule_id(string value){
			this.schedule_id_ = value;
		}
		public List<vipapis.overseas.BatchDetailInfo> GetProduct_list(){
			return this.product_list_;
		}
		
		public void SetProduct_list(List<vipapis.overseas.BatchDetailInfo> value){
			this.product_list_ = value;
		}
		
	}
	
}