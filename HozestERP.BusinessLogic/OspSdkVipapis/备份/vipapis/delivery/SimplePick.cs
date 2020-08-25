using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class SimplePick {
		
		///<summary>
		/// 拣货单编号
		///</summary>
		
		private string pick_no_;
		
		///<summary>
		/// 拣货单类别
		///</summary>
		
		private string pick_type_;
		
		///<summary>
		/// 送货仓库
		///</summary>
		
		private string warehouse_;
		
		public string GetPick_no(){
			return this.pick_no_;
		}
		
		public void SetPick_no(string value){
			this.pick_no_ = value;
		}
		public string GetPick_type(){
			return this.pick_type_;
		}
		
		public void SetPick_type(string value){
			this.pick_type_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		
	}
	
}