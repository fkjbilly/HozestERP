using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class SearchOrderElectronicInvoicesReq {
		
		///<summary>
		/// 用户id列表
		///</summary>
		
		private List<long?> userIdList_;
		
		///<summary>
		/// 订单ID列表
		///</summary>
		
		private List<long?> orderIdList_;
		
		///<summary>
		/// 订单序列号列表
		///</summary>
		
		private List<string> orderSnList_;
		
		///<summary>
		/// 电子发票id列表
		///</summary>
		
		private List<long?> idList_;
		
		///<summary>
		/// 电子发票状态
		///</summary>
		
		private List<int?> statusList_;
		
		///<summary>
		/// 电子发票号码
		///</summary>
		
		private string fpFm_;
		
		public List<long?> GetUserIdList(){
			return this.userIdList_;
		}
		
		public void SetUserIdList(List<long?> value){
			this.userIdList_ = value;
		}
		public List<long?> GetOrderIdList(){
			return this.orderIdList_;
		}
		
		public void SetOrderIdList(List<long?> value){
			this.orderIdList_ = value;
		}
		public List<string> GetOrderSnList(){
			return this.orderSnList_;
		}
		
		public void SetOrderSnList(List<string> value){
			this.orderSnList_ = value;
		}
		public List<long?> GetIdList(){
			return this.idList_;
		}
		
		public void SetIdList(List<long?> value){
			this.idList_ = value;
		}
		public List<int?> GetStatusList(){
			return this.statusList_;
		}
		
		public void SetStatusList(List<int?> value){
			this.statusList_ = value;
		}
		public string GetFpFm(){
			return this.fpFm_;
		}
		
		public void SetFpFm(string value){
			this.fpFm_ = value;
		}
		
	}
	
}