using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.biz.request{
	
	
	
	
	
	public class UpdateOrderPayResultReq {
		
		///<summary>
		/// 用户ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单类别(0:普通，1：预售)
		///</summary>
		
		private int? orderCategory_;
		
		///<summary>
		/// 预付订单流水号列表，预付订单传
		///</summary>
		
		private List<string> orderCodeList_;
		
		///<summary>
		/// 订单列表，普通订单传
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.NotifyRequestOrderVO> orderList_;
		
		///<summary>
		/// 订单发票
		///</summary>
		
		private com.vip.order.common.pojo.order.vo.OrderInvoiceVO orderInvoice_;
		
		///<summary>
		/// 订单支付明细
		///</summary>
		
		private List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO> orderPayDetailsList_;
		
		///<summary>
		/// 支付交易流水号
		///</summary>
		
		private string tradeNumber_;
		
		///<summary>
		/// 不可开具发票金额的描述信息
		///</summary>
		
		private string invoiceDeductRemark_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public int? GetOrderCategory(){
			return this.orderCategory_;
		}
		
		public void SetOrderCategory(int? value){
			this.orderCategory_ = value;
		}
		public List<string> GetOrderCodeList(){
			return this.orderCodeList_;
		}
		
		public void SetOrderCodeList(List<string> value){
			this.orderCodeList_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.NotifyRequestOrderVO> GetOrderList(){
			return this.orderList_;
		}
		
		public void SetOrderList(List<com.vip.order.common.pojo.order.vo.NotifyRequestOrderVO> value){
			this.orderList_ = value;
		}
		public com.vip.order.common.pojo.order.vo.OrderInvoiceVO GetOrderInvoice(){
			return this.orderInvoice_;
		}
		
		public void SetOrderInvoice(com.vip.order.common.pojo.order.vo.OrderInvoiceVO value){
			this.orderInvoice_ = value;
		}
		public List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO> GetOrderPayDetailsList(){
			return this.orderPayDetailsList_;
		}
		
		public void SetOrderPayDetailsList(List<com.vip.order.common.pojo.order.vo.OrderPayDetailVO> value){
			this.orderPayDetailsList_ = value;
		}
		public string GetTradeNumber(){
			return this.tradeNumber_;
		}
		
		public void SetTradeNumber(string value){
			this.tradeNumber_ = value;
		}
		public string GetInvoiceDeductRemark(){
			return this.invoiceDeductRemark_;
		}
		
		public void SetInvoiceDeductRemark(string value){
			this.invoiceDeductRemark_ = value;
		}
		
	}
	
}