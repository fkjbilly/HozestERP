using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class HtSaleOrderParamModel {
		
		///<summary>
		/// 仓库编码,如:云仓代运营 HT_NBYC
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 订单号,多个订单号用英文逗号分开
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 数量,这里默认为不传默认为:100,最大只返回100条
		///</summary>
		
		private int? num_;
		
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public int? GetNum(){
			return this.num_;
		}
		
		public void SetNum(int? value){
			this.num_ = value;
		}
		
	}
	
}