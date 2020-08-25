using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderBizExtAttrVO {
		
		///<summary>
		/// 量体ID
		///</summary>
		
		private long? customBodyId_;
		
		///<summary>
		///  定制信息ID
		///</summary>
		
		private long? customId_;
		
		public long? GetCustomBodyId(){
			return this.customBodyId_;
		}
		
		public void SetCustomBodyId(long? value){
			this.customBodyId_ = value;
		}
		public long? GetCustomId(){
			return this.customId_;
		}
		
		public void SetCustomId(long? value){
			this.customId_ = value;
		}
		
	}
	
}