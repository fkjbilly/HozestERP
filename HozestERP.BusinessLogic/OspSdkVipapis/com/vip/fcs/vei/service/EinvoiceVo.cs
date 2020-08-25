using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class EinvoiceVo {
		
		///<summary>
		/// 发票代码
		///</summary>
		
		private string fpdm_;
		
		///<summary>
		/// 发票号码
		///</summary>
		
		private string fphm_;
		
		///<summary>
		/// pdf下载url
		///</summary>
		
		private string pdfUrl_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 卖方纳税人识别号
		///</summary>
		
		private string taxRegisterNo_;
		
		///<summary>
		/// 数据类型
		///</summary>
		
		private byte? dataType_;
		
		public string GetFpdm(){
			return this.fpdm_;
		}
		
		public void SetFpdm(string value){
			this.fpdm_ = value;
		}
		public string GetFphm(){
			return this.fphm_;
		}
		
		public void SetFphm(string value){
			this.fphm_ = value;
		}
		public string GetPdfUrl(){
			return this.pdfUrl_;
		}
		
		public void SetPdfUrl(string value){
			this.pdfUrl_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetTaxRegisterNo(){
			return this.taxRegisterNo_;
		}
		
		public void SetTaxRegisterNo(string value){
			this.taxRegisterNo_ = value;
		}
		public byte? GetDataType(){
			return this.dataType_;
		}
		
		public void SetDataType(byte? value){
			this.dataType_ = value;
		}
		
	}
	
}