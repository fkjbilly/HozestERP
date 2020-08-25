using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class CanInvoicingReqModel3 {
		
		///<summary>
		/// 仓库编码（大仓，如：VIP_HZ,VIP_NH等）。多个编码时用分号（;）分隔，如：VIP_HZ;VIP_NH;VIP_BJ
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 销售类型（如：自营0，JIT1等）。多个销售类型时用分号（;）分隔，如：0;1
		///</summary>
		
		private string saleType_;
		
		///<summary>
		/// 收货省份
		///</summary>
		
		private string province_;
		
		///<summary>
		/// 收货市
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 商品SIZE ID（不包含赠品）
		///</summary>
		
		private string sizeIds_;
		
		///<summary>
		/// 赠品SIZE ID
		///</summary>
		
		private string giftSizeIds_;
		
		///<summary>
		/// 系统来源
		///</summary>
		
		private int? sourceSystem_;
		
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetSaleType(){
			return this.saleType_;
		}
		
		public void SetSaleType(string value){
			this.saleType_ = value;
		}
		public string GetProvince(){
			return this.province_;
		}
		
		public void SetProvince(string value){
			this.province_ = value;
		}
		public string GetCity(){
			return this.city_;
		}
		
		public void SetCity(string value){
			this.city_ = value;
		}
		public string GetSizeIds(){
			return this.sizeIds_;
		}
		
		public void SetSizeIds(string value){
			this.sizeIds_ = value;
		}
		public string GetGiftSizeIds(){
			return this.giftSizeIds_;
		}
		
		public void SetGiftSizeIds(string value){
			this.giftSizeIds_ = value;
		}
		public int? GetSourceSystem(){
			return this.sourceSystem_;
		}
		
		public void SetSourceSystem(int? value){
			this.sourceSystem_ = value;
		}
		
	}
	
}