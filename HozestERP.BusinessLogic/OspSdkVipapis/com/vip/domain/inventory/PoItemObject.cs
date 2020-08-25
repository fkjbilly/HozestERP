using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class PoItemObject {
		
		///<summary>
		/// 商品编码
		///</summary>
		
		private string itemCode_;
		
		///<summary>
		/// 作业仓
		///</summary>
		
		private string warehouseCode_;
		
		///<summary>
		/// 计划入库件数
		///</summary>
		
		private int? applyQty_;
		
		///<summary>
		/// 吊牌价
		///</summary>
		
		private double? tagPrice_;
		
		///<summary>
		/// IQC数量
		///</summary>
		
		private int? iqcQty_;
		
		///<summary>
		/// 上架数量
		///</summary>
		
		private int? shelvesQty_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		public string GetItemCode(){
			return this.itemCode_;
		}
		
		public void SetItemCode(string value){
			this.itemCode_ = value;
		}
		public string GetWarehouseCode(){
			return this.warehouseCode_;
		}
		
		public void SetWarehouseCode(string value){
			this.warehouseCode_ = value;
		}
		public int? GetApplyQty(){
			return this.applyQty_;
		}
		
		public void SetApplyQty(int? value){
			this.applyQty_ = value;
		}
		public double? GetTagPrice(){
			return this.tagPrice_;
		}
		
		public void SetTagPrice(double? value){
			this.tagPrice_ = value;
		}
		public int? GetIqcQty(){
			return this.iqcQty_;
		}
		
		public void SetIqcQty(int? value){
			this.iqcQty_ = value;
		}
		public int? GetShelvesQty(){
			return this.shelvesQty_;
		}
		
		public void SetShelvesQty(int? value){
			this.shelvesQty_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		
	}
	
}