using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutWmsGlobalDeliverBatchOrderParam {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 档期ID
		///</summary>
		
		private long? brandId_;
		
		///<summary>
		/// 重量[保存4位,重量缺失时使用缺省值:0.0000]
		///</summary>
		
		private double? weight_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public long? GetBrandId(){
			return this.brandId_;
		}
		
		public void SetBrandId(long? value){
			this.brandId_ = value;
		}
		public double? GetWeight(){
			return this.weight_;
		}
		
		public void SetWeight(double? value){
			this.weight_ = value;
		}
		
	}
	
}