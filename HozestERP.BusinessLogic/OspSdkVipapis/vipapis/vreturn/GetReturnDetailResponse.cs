using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vreturn{
	
	
	
	
	
	public class GetReturnDetailResponse {
		
		///<summary>
		/// 退供单出仓信息列表
		/// @sampleValue returnDeliveryInfos 
		///</summary>
		
		private List<vipapis.vreturn.ReturnDeliveryInfo> returnDeliveryInfos_;
		
		///<summary>
		/// 退供单出仓信息总数
		/// @sampleValue total 
		///</summary>
		
		private int? total_;
		
		public List<vipapis.vreturn.ReturnDeliveryInfo> GetReturnDeliveryInfos(){
			return this.returnDeliveryInfos_;
		}
		
		public void SetReturnDeliveryInfos(List<vipapis.vreturn.ReturnDeliveryInfo> value){
			this.returnDeliveryInfos_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}