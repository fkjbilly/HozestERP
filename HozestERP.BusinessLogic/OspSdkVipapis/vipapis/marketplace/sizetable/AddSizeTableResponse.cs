using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.marketplace.sizetable{
	
	
	
	
	
	public class AddSizeTableResponse {
		
		///<summary>
		/// 尺码表ID
		///</summary>
		
		private long? size_table_id_;
		
		public long? GetSize_table_id(){
			return this.size_table_id_;
		}
		
		public void SetSize_table_id(long? value){
			this.size_table_id_ = value;
		}
		
	}
	
}