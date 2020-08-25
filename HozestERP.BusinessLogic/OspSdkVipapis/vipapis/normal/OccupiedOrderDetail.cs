using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class OccupiedOrderDetail {
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 数量
		///</summary>
		
		private int? amount_;
		
		///<summary>
		/// 品牌ID
		///</summary>
		
		private long? brand_id_;
		
		///<summary>
		/// 库存预扣减标识：0、共享库存(全渠道一盘货)，1、独享库存(唯品会单渠道货)
		///</summary>
		
		private int? stock_reserve_source_;
		
		///<summary>
		/// 常态合作编码
		///</summary>
		
		private int? cooperation_no_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public int? GetAmount(){
			return this.amount_;
		}
		
		public void SetAmount(int? value){
			this.amount_ = value;
		}
		public long? GetBrand_id(){
			return this.brand_id_;
		}
		
		public void SetBrand_id(long? value){
			this.brand_id_ = value;
		}
		public int? GetStock_reserve_source(){
			return this.stock_reserve_source_;
		}
		
		public void SetStock_reserve_source(int? value){
			this.stock_reserve_source_ = value;
		}
		public int? GetCooperation_no(){
			return this.cooperation_no_;
		}
		
		public void SetCooperation_no(int? value){
			this.cooperation_no_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		
	}
	
}