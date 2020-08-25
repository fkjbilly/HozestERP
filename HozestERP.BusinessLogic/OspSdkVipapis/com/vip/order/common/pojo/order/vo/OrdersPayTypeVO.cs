using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrdersPayTypeVO {
		
		///<summary>
		/// 订单支付类型ID
		///</summary>
		
		private int? id_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 支付类型
		///</summary>
		
		private int? payType_;
		
		///<summary>
		/// 支付ID
		///</summary>
		
		private int? payId_;
		
		///<summary>
		/// 日期
		///</summary>
		
		private long? date_;
		
		///<summary>
		/// 扩展信息
		///</summary>
		
		private string ext_;
		
		///<summary>
		/// 来源
		///</summary>
		
		private int? source_;
		
		public int? GetId(){
			return this.id_;
		}
		
		public void SetId(int? value){
			this.id_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public int? GetPayType(){
			return this.payType_;
		}
		
		public void SetPayType(int? value){
			this.payType_ = value;
		}
		public int? GetPayId(){
			return this.payId_;
		}
		
		public void SetPayId(int? value){
			this.payId_ = value;
		}
		public long? GetDate(){
			return this.date_;
		}
		
		public void SetDate(long? value){
			this.date_ = value;
		}
		public string GetExt(){
			return this.ext_;
		}
		
		public void SetExt(string value){
			this.ext_ = value;
		}
		public int? GetSource(){
			return this.source_;
		}
		
		public void SetSource(int? value){
			this.source_ = value;
		}
		
	}
	
}