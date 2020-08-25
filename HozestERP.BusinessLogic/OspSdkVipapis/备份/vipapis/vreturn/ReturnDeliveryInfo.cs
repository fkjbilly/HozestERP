using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.vreturn{
	
	
	
	
	
	public class ReturnDeliveryInfo {
		
		///<summary>
		/// 退供单号
		/// @sampleValue return_sn 
		///</summary>
		
		private string return_sn_;
		
		///<summary>
		/// 出仓时间
		/// @sampleValue out_time 
		///</summary>
		
		private string out_time_;
		
		///<summary>
		/// 总箱数
		/// @sampleValue total_cases 
		///</summary>
		
		private double? total_cases_;
		
		///<summary>
		/// 总商品条码数
		/// @sampleValue total_skus 
		///</summary>
		
		private double? total_skus_;
		
		///<summary>
		/// 总商品数
		/// @sampleValue total_qtys 
		///</summary>
		
		private double? total_qtys_;
		
		///<summary>
		/// 出仓商品列表
		/// @sampleValue delivery_list 
		///</summary>
		
		private List<vipapis.vreturn.ReturnDeliveryDetail> delivery_list_;
		
		public string GetReturn_sn(){
			return this.return_sn_;
		}
		
		public void SetReturn_sn(string value){
			this.return_sn_ = value;
		}
		public string GetOut_time(){
			return this.out_time_;
		}
		
		public void SetOut_time(string value){
			this.out_time_ = value;
		}
		public double? GetTotal_cases(){
			return this.total_cases_;
		}
		
		public void SetTotal_cases(double? value){
			this.total_cases_ = value;
		}
		public double? GetTotal_skus(){
			return this.total_skus_;
		}
		
		public void SetTotal_skus(double? value){
			this.total_skus_ = value;
		}
		public double? GetTotal_qtys(){
			return this.total_qtys_;
		}
		
		public void SetTotal_qtys(double? value){
			this.total_qtys_ = value;
		}
		public List<vipapis.vreturn.ReturnDeliveryDetail> GetDelivery_list(){
			return this.delivery_list_;
		}
		
		public void SetDelivery_list(List<vipapis.vreturn.ReturnDeliveryDetail> value){
			this.delivery_list_ = value;
		}
		
	}
	
}