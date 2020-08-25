using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class ReturnSaleOrderRes {
		
		///<summary>
		/// 结果集
		///</summary>
		
		private List<com.vip.isv.tools.ReturnSaleOrderDo> returnSaleOrderDos_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? totalCount_;
		
		public List<com.vip.isv.tools.ReturnSaleOrderDo> GetReturnSaleOrderDos(){
			return this.returnSaleOrderDos_;
		}
		
		public void SetReturnSaleOrderDos(List<com.vip.isv.tools.ReturnSaleOrderDo> value){
			this.returnSaleOrderDos_ = value;
		}
		public int? GetTotalCount(){
			return this.totalCount_;
		}
		
		public void SetTotalCount(int? value){
			this.totalCount_ = value;
		}
		
	}
	
}