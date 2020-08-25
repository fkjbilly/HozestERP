using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.orderservice.service{
	
	
	
	
	
	public class BatchNoVo {
		
		///<summary>
		/// 国际运输发货批次
		///</summary>
		
		private string batchNo_;
		
		///<summary>
		/// 重量
		///</summary>
		
		private double? weight_;
		
		public string GetBatchNo(){
			return this.batchNo_;
		}
		
		public void SetBatchNo(string value){
			this.batchNo_ = value;
		}
		public double? GetWeight(){
			return this.weight_;
		}
		
		public void SetWeight(double? value){
			this.weight_ = value;
		}
		
	}
	
}