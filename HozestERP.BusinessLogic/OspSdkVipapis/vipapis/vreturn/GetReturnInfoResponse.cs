using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vreturn{
	
	
	
	
	
	public class GetReturnInfoResponse {
		
		///<summary>
		/// 退供单信息列表
		/// @sampleValue returnInfos 
		///</summary>
		
		private List<vipapis.vreturn.ReturnInfo> returnInfos_;
		
		///<summary>
		/// 退供单号总数
		/// @sampleValue total 
		///</summary>
		
		private int? total_;
		
		public List<vipapis.vreturn.ReturnInfo> GetReturnInfos(){
			return this.returnInfos_;
		}
		
		public void SetReturnInfos(List<vipapis.vreturn.ReturnInfo> value){
			this.returnInfos_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}