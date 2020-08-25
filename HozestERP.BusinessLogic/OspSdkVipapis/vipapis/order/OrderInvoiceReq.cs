using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.order{
	
	
	
	
	
	public class OrderInvoiceReq {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string order_id_;
		
		///<summary>
		/// 发票类型(1-纸质个人发票,2-纸质公司发票,3-电子发票,4-电子发票纸质版)
		///</summary>
		
		private int? invoice_type_;
		
		///<summary>
		/// 电子发票开票结果列表
		///</summary>
		
		private List<vipapis.order.Einvoice> e_invoice_;
		
		///<summary>
		/// 纸质发票开票结果,当发票类型为1、2、4时，此结构体内字段，按备注必填或选填
		///</summary>
		
		private vipapis.order.PaperInvoice paper_invoice_;
		
		public string GetOrder_id(){
			return this.order_id_;
		}
		
		public void SetOrder_id(string value){
			this.order_id_ = value;
		}
		public int? GetInvoice_type(){
			return this.invoice_type_;
		}
		
		public void SetInvoice_type(int? value){
			this.invoice_type_ = value;
		}
		public List<vipapis.order.Einvoice> GetE_invoice(){
			return this.e_invoice_;
		}
		
		public void SetE_invoice(List<vipapis.order.Einvoice> value){
			this.e_invoice_ = value;
		}
		public vipapis.order.PaperInvoice GetPaper_invoice(){
			return this.paper_invoice_;
		}
		
		public void SetPaper_invoice(vipapis.order.PaperInvoice value){
			this.paper_invoice_ = value;
		}
		
	}
	
}