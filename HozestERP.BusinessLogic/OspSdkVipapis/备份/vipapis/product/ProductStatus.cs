using System;

namespace vipapis.product{
	
	
	public enum ProductStatus {
		
		
		///<summary>
		/// 主档待提交(已停用)
		///</summary>
		MASTER_DRAFT = -11, 
		
		///<summary>
		/// 待提交(已停用)
		///</summary>
		MASTER_PENDING = -12, 
		
		///<summary>
		/// 主档审核通过(已停用)
		///</summary>
		MASTER_PASS = -13, 
		
		///<summary>
		/// 主档审不通过(已停用)
		///</summary>
		MASTER_REJECT = -14, 
		
		///<summary>
		/// 可售待提交(已停用)
		///</summary>
		SALE_DRAFT = 21, 
		
		///<summary>
		/// 可售待审核(已停用)
		///</summary>
		SALE_PENDING = 22, 
		
		///<summary>
		/// 可售审核通过(已停用)
		///</summary>
		SALE_PASS = 23, 
		
		///<summary>
		/// 可售审核不通过(已停用)
		///</summary>
		SALE_REJECT = 24, 
		
		///<summary>
		/// 标示是否维护
		///</summary>
		DEFAULT = 0, 
		
		///<summary>
		/// 待提交
		///</summary>
		DRAFT = 11, 
		
		///<summary>
		/// 待审核
		///</summary>
		PENDING = 12, 
		
		///<summary>
		/// 审核通过
		///</summary>
		PASS = 13, 
		
		///<summary>
		/// 审核不通过
		///</summary>
		REJECT = 14, 
		
		///<summary>
		/// 删除
		///</summary>
		DELETED = -1, 
		
		///<summary>
		/// 禁售
		///</summary>
		OUTSALE = 3 
	}
	
	public class ProductStatusUtil{
		
		private readonly int value;
		private ProductStatusUtil(int value){
			this.value = value;
		}
		
		public int getValue() {
			return value;
		}
		
		
		public static ProductStatus? FindByValue(int value){
			
			switch(value){
				
				case -11: return ProductStatus.MASTER_DRAFT; 
				case -12: return ProductStatus.MASTER_PENDING; 
				case -13: return ProductStatus.MASTER_PASS; 
				case -14: return ProductStatus.MASTER_REJECT; 
				case 21: return ProductStatus.SALE_DRAFT; 
				case 22: return ProductStatus.SALE_PENDING; 
				case 23: return ProductStatus.SALE_PASS; 
				case 24: return ProductStatus.SALE_REJECT; 
				case 0: return ProductStatus.DEFAULT; 
				case 11: return ProductStatus.DRAFT; 
				case 12: return ProductStatus.PENDING; 
				case 13: return ProductStatus.PASS; 
				case 14: return ProductStatus.REJECT; 
				case -1: return ProductStatus.DELETED; 
				case 3: return ProductStatus.OUTSALE; 
				
				default: return null; 
				
			}
			
		}
		
		public static ProductStatus? FindByName(string name){
			
			if(ProductStatus.MASTER_DRAFT.ToString().Equals(name)){
				
				return ProductStatus.MASTER_DRAFT; 
			}
			
			if(ProductStatus.MASTER_PENDING.ToString().Equals(name)){
				
				return ProductStatus.MASTER_PENDING; 
			}
			
			if(ProductStatus.MASTER_PASS.ToString().Equals(name)){
				
				return ProductStatus.MASTER_PASS; 
			}
			
			if(ProductStatus.MASTER_REJECT.ToString().Equals(name)){
				
				return ProductStatus.MASTER_REJECT; 
			}
			
			if(ProductStatus.SALE_DRAFT.ToString().Equals(name)){
				
				return ProductStatus.SALE_DRAFT; 
			}
			
			if(ProductStatus.SALE_PENDING.ToString().Equals(name)){
				
				return ProductStatus.SALE_PENDING; 
			}
			
			if(ProductStatus.SALE_PASS.ToString().Equals(name)){
				
				return ProductStatus.SALE_PASS; 
			}
			
			if(ProductStatus.SALE_REJECT.ToString().Equals(name)){
				
				return ProductStatus.SALE_REJECT; 
			}
			
			if(ProductStatus.DEFAULT.ToString().Equals(name)){
				
				return ProductStatus.DEFAULT; 
			}
			
			if(ProductStatus.DRAFT.ToString().Equals(name)){
				
				return ProductStatus.DRAFT; 
			}
			
			if(ProductStatus.PENDING.ToString().Equals(name)){
				
				return ProductStatus.PENDING; 
			}
			
			if(ProductStatus.PASS.ToString().Equals(name)){
				
				return ProductStatus.PASS; 
			}
			
			if(ProductStatus.REJECT.ToString().Equals(name)){
				
				return ProductStatus.REJECT; 
			}
			
			if(ProductStatus.DELETED.ToString().Equals(name)){
				
				return ProductStatus.DELETED; 
			}
			
			if(ProductStatus.OUTSALE.ToString().Equals(name)){
				
				return ProductStatus.OUTSALE; 
			}
			
			
			return null;
			
		}
		
	}
	
}