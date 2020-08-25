using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class Inventory {
		
		///<summary>
		/// 对应size_id
		///</summary>
		
		private long? merItemNo_;
		
		///<summary>
		/// 如果是pos的，posNo是库存占用号
		///</summary>
		
		private string posNo_;
		
		///<summary>
		/// 占用成功的数量
		///</summary>
		
		private int? count_;
		
		public long? GetMerItemNo(){
			return this.merItemNo_;
		}
		
		public void SetMerItemNo(long? value){
			this.merItemNo_ = value;
		}
		public string GetPosNo(){
			return this.posNo_;
		}
		
		public void SetPosNo(string value){
			this.posNo_ = value;
		}
		public int? GetCount(){
			return this.count_;
		}
		
		public void SetCount(int? value){
			this.count_ = value;
		}
		
	}
	
}