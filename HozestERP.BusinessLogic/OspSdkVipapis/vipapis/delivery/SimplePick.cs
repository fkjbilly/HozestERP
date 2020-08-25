using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class SimplePick {
		
		///<summary>
		/// 拣货单编号，正常拣货单：PICK-<br>补货单：BHPICK-<br>多po拣货单：MULPICK-
		///</summary>
		
		private string pick_no_;
		
		///<summary>
		/// 拣货单类别: <br>JIT分销：jit_4a<br>普通jit：jit
		///</summary>
		
		private string pick_type_;
		
		///<summary>
		/// 送货仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 门店编码
		///</summary>
		
		private string store_sn_;
		
		///<summary>
		/// jit类型，1：OXO ，2：仓中仓，<br>返回空时，则为普通jit
		///</summary>
		
		private int? jit_type_;
		
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
		public string GetStore_sn(){
			return this.store_sn_;
		}
		
		public void SetStore_sn(string value){
			this.store_sn_ = value;
		}
		public int? GetJit_type(){
			return this.jit_type_;
		}
		
		public void SetJit_type(int? value){
			this.jit_type_ = value;
		}
		
	}
	
}