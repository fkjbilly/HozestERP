using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.response{
	
	
	
	
	
	public class PreviewInfoResp {
		
		///<summary>
		/// 唯品币
		///</summary>
		
		private string virtualMoney_;
		
		///<summary>
		/// 退红包金额
		///</summary>
		
		private string totalPacketMoney_;
		
		///<summary>
		/// 退款总金额
		///</summary>
		
		private string total_;
		
		///<summary>
		/// 退零钱
		///</summary>
		
		private string surplus_;
		
		///<summary>
		/// 原路退金额
		///</summary>
		
		private string money_;
		
		///<summary>
		/// 券的金额
		///</summary>
		
		private string favourableMoney_;
		
		///<summary>
		/// 券的id在订单取消之后会丢失
		///</summary>
		
		private long? favourableId_;
		
		public string GetVirtualMoney(){
			return this.virtualMoney_;
		}
		
		public void SetVirtualMoney(string value){
			this.virtualMoney_ = value;
		}
		public string GetTotalPacketMoney(){
			return this.totalPacketMoney_;
		}
		
		public void SetTotalPacketMoney(string value){
			this.totalPacketMoney_ = value;
		}
		public string GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(string value){
			this.total_ = value;
		}
		public string GetSurplus(){
			return this.surplus_;
		}
		
		public void SetSurplus(string value){
			this.surplus_ = value;
		}
		public string GetMoney(){
			return this.money_;
		}
		
		public void SetMoney(string value){
			this.money_ = value;
		}
		public string GetFavourableMoney(){
			return this.favourableMoney_;
		}
		
		public void SetFavourableMoney(string value){
			this.favourableMoney_ = value;
		}
		public long? GetFavourableId(){
			return this.favourableId_;
		}
		
		public void SetFavourableId(long? value){
			this.favourableId_ = value;
		}
		
	}
	
}