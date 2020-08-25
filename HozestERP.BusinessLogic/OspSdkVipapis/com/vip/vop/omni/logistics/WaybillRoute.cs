using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.omni.logistics{
	
	
	
	
	
	public class WaybillRoute {
		
		///<summary>
		/// 路由节点信息编号
		///</summary>
		
		private string routeId_;
		
		///<summary>
		/// 客户订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transportNo_;
		
		///<summary>
		/// 路由节点产生的时间
		///</summary>
		
		private string acceptTime_;
		
		///<summary>
		/// 路由节点发生的城市
		///</summary>
		
		private string acceptAddress_;
		
		///<summary>
		/// 路由节点具体描述
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 路由节点操作码
		///</summary>
		
		private string opCode_;
		
		public string GetRouteId(){
			return this.routeId_;
		}
		
		public void SetRouteId(string value){
			this.routeId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetTransportNo(){
			return this.transportNo_;
		}
		
		public void SetTransportNo(string value){
			this.transportNo_ = value;
		}
		public string GetAcceptTime(){
			return this.acceptTime_;
		}
		
		public void SetAcceptTime(string value){
			this.acceptTime_ = value;
		}
		public string GetAcceptAddress(){
			return this.acceptAddress_;
		}
		
		public void SetAcceptAddress(string value){
			this.acceptAddress_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public string GetOpCode(){
			return this.opCode_;
		}
		
		public void SetOpCode(string value){
			this.opCode_ = value;
		}
		
	}
	
}