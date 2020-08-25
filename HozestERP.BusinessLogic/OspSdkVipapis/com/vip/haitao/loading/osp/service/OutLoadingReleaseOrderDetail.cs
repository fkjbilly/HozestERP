using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.loading.osp.service{
	
	
	
	
	
	public class OutLoadingReleaseOrderDetail {
		
		///<summary>
		/// 箱号
		///</summary>
		
		private string boxId_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string sizeSn_;
		
		///<summary>
		/// 商品备案号
		///</summary>
		
		private string customsNo_;
		
		///<summary>
		/// 商品描述
		///</summary>
		
		private string name_;
		
		///<summary>
		/// 箱中商品数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 单价
		///</summary>
		
		private double? price_;
		
		public string GetBoxId(){
			return this.boxId_;
		}
		
		public void SetBoxId(string value){
			this.boxId_ = value;
		}
		public string GetSizeSn(){
			return this.sizeSn_;
		}
		
		public void SetSizeSn(string value){
			this.sizeSn_ = value;
		}
		public string GetCustomsNo(){
			return this.customsNo_;
		}
		
		public void SetCustomsNo(string value){
			this.customsNo_ = value;
		}
		public string GetName(){
			return this.name_;
		}
		
		public void SetName(string value){
			this.name_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public double? GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(double? value){
			this.price_ = value;
		}
		
	}
	
}