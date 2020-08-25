using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class ExtInfo {
		
		///<summary>
		/// 扩展字段1：可以用来传订单总数
		///</summary>
		
		private string ext_field1_;
		
		///<summary>
		/// 扩展字段2：可以用来传SKU总数
		///</summary>
		
		private string ext_field2_;
		
		///<summary>
		/// 扩展字段3：可以用来传拣货区域
		///</summary>
		
		private string ext_field3_;
		
		public string GetExt_field1(){
			return this.ext_field1_;
		}
		
		public void SetExt_field1(string value){
			this.ext_field1_ = value;
		}
		public string GetExt_field2(){
			return this.ext_field2_;
		}
		
		public void SetExt_field2(string value){
			this.ext_field2_ = value;
		}
		public string GetExt_field3(){
			return this.ext_field3_;
		}
		
		public void SetExt_field3(string value){
			this.ext_field3_ = value;
		}
		
	}
	
}