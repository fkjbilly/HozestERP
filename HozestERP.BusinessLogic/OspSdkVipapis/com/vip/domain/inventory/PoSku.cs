using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class PoSku {
		
		///<summary>
		/// 商品编码
		///</summary>
		
		private string itemCode_;
		
		///<summary>
		/// 计划入库件数
		///</summary>
		
		private int? applyQty_;
		
		///<summary>
		/// 吊牌价
		///</summary>
		
		private string tagPrice_;
		
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
		public int? GetApplyQty(){
			return this.applyQty_;
		}
		
		public void SetApplyQty(int? value){
			this.applyQty_ = value;
		}
		public string GetTagPrice(){
			return this.tagPrice_;
		}
		
		public void SetTagPrice(string value){
			this.tagPrice_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		
	}
	
}