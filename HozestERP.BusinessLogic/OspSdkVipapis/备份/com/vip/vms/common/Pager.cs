using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vms.common{
	
	
	
	
	
	public class Pager {
		
		///<summary>
		/// 页码
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 每次获取记录数
		///</summary>
		
		private int? limit_;
		
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