using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.sizetable{
	
	
	
	
	
	public class AddSizeDetailResponse {
		
		///<summary>
		/// 尺码表详情ID
		///</summary>
		
		private long? size_detail_id_;
		
		public long? GetSize_detail_id(){
			return this.size_detail_id_;
		}
		
		public void SetSize_detail_id(long? value){
			this.size_detail_id_ = value;
		}
		
	}
	
}