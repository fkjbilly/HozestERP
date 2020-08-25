using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.product{
	
	
	
	
	
	public class SimpleProperty {
		
		///<summary>
		/// 属性id
		///</summary>
		
		private int? pid_;
		
		///<summary>
		/// 属性值id
		///</summary>
		
		private int? vid_;
		
		///<summary>
		/// 属性别名
		///</summary>
		
		private string alias_;
		
		public int? GetPid(){
			return this.pid_;
		}
		
		public void SetPid(int? value){
			this.pid_ = value;
		}
		public int? GetVid(){
			return this.vid_;
		}
		
		public void SetVid(int? value){
			this.vid_ = value;
		}
		public string GetAlias(){
			return this.alias_;
		}
		
		public void SetAlias(string value){
			this.alias_ = value;
		}
		
	}
	
}