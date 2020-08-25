using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.puma{
	
	
	
	
	
	public class Pagination {
		
		///<summary>
		/// 页码
		///</summary>
		
		private int? page_;
		
		///<summary>
		/// 页记录数
		///</summary>
		
		private int? size_;
		
		///<summary>
		/// 总记录数
		///</summary>
		
		private int? total_;
		
		public int? GetPage(){
			return this.page_;
		}
		
		public void SetPage(int? value){
			this.page_ = value;
		}
		public int? GetSize(){
			return this.size_;
		}
		
		public void SetSize(int? value){
			this.size_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}