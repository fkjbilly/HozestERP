using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class SkuSaleCountInfoRes {
		
		///<summary>
		/// 结果集
		///</summary>
		
		private List<com.vip.isv.tools.SkuSaleCountInfoDo> skuSaleCountInfoDos_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? totalCount_;
		
		public List<com.vip.isv.tools.SkuSaleCountInfoDo> GetSkuSaleCountInfoDos(){
			return this.skuSaleCountInfoDos_;
		}
		
		public void SetSkuSaleCountInfoDos(List<com.vip.isv.tools.SkuSaleCountInfoDo> value){
			this.skuSaleCountInfoDos_ = value;
		}
		public int? GetTotalCount(){
			return this.totalCount_;
		}
		
		public void SetTotalCount(int? value){
			this.totalCount_ = value;
		}
		
	}
	
}