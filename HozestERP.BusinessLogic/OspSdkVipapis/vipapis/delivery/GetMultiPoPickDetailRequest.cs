using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class GetMultiPoPickDetailRequest {
		
		///<summary>
		/// 供应商ID
		///</summary>
		
		private int? vendor_id_;
		
		///<summary>
		/// 拣货单编号
		///</summary>
		
		private string pick_no_;
		
		///<summary>
		/// 合作模式(海淘用户专用)；JIT分销：jit_4a；普通jit：jit
		///</summary>
		
		private string co_mode_;
		
		///<summary>
		/// 页码参数
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 每页记录条数，默认50，最大100
		///</summary>
		
		private int? limit_;
		
		public int? GetVendor_id(){
			return this.vendor_id_;
		}
		
		public void SetVendor_id(int? value){
			this.vendor_id_ = value;
		}
		public string GetPick_no(){
			return this.pick_no_;
		}
		
		public void SetPick_no(string value){
			this.pick_no_ = value;
		}
		public string GetCo_mode(){
			return this.co_mode_;
		}
		
		public void SetCo_mode(string value){
			this.co_mode_ = value;
		}
		public int? GetPage(){
			return this.page_;
		}
		
		public void SetPage(int? value){
			this.page_ = value;
		}
		public int? GetLimit(){
			return this.limit_;
		}
		
		public void SetLimit(int? value){
			this.limit_ = value;
		}
		
	}
	
}