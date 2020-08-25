using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.vcloud.common.api{
	
	
	
	
	
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
		
		///<summary>
		/// 最大id
		///</summary>
		
		private long? maxId_;
		
		///<summary>
		/// 是否有下一页
		///</summary>
		
		private bool? hasNext_;
		
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
		public long? GetMaxId(){
			return this.maxId_;
		}
		
		public void SetMaxId(long? value){
			this.maxId_ = value;
		}
		public bool? GetHasNext(){
			return this.hasNext_;
		}
		
		public void SetHasNext(bool? value){
			this.hasNext_ = value;
		}
		
	}
	
}