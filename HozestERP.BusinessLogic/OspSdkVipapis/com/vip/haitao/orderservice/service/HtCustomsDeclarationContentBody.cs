using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtCustomsDeclarationContentBody {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 订单申报状态码
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 订单申报状态描述
		///</summary>
		
		private string resultInfo_;
		
		///<summary>
		/// 运单号
		///</summary>
		
		private string transportNo_;
		
		///<summary>
		/// 快递公司名称
		///</summary>
		
		private string transportName_;
		
		///<summary>
		/// 快递公司代码
		///</summary>
		
		private string transportCode_;
		
		///<summary>
		/// 清单号
		///</summary>
		
		private string iventoryNo_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public string GetResultInfo(){
			return this.resultInfo_;
		}
		
		public void SetResultInfo(string value){
			this.resultInfo_ = value;
		}
		public string GetTransportNo(){
			return this.transportNo_;
		}
		
		public void SetTransportNo(string value){
			this.transportNo_ = value;
		}
		public string GetTransportName(){
			return this.transportName_;
		}
		
		public void SetTransportName(string value){
			this.transportName_ = value;
		}
		public string GetTransportCode(){
			return this.transportCode_;
		}
		
		public void SetTransportCode(string value){
			this.transportCode_ = value;
		}
		public string GetIventoryNo(){
			return this.iventoryNo_;
		}
		
		public void SetIventoryNo(string value){
			this.iventoryNo_ = value;
		}
		
	}
	
}