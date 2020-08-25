using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class OccupiedOrderRes {
		
		///<summary>
		/// 结果集
		///</summary>
		
		private List<com.vip.isv.tools.OccupiedOrderDo> occupiedOrderDos_;
		
		///<summary>
		/// 记录总条数
		///</summary>
		
		private int? totalCount_;
		
		public List<com.vip.isv.tools.OccupiedOrderDo> GetOccupiedOrderDos(){
			return this.occupiedOrderDos_;
		}
		
		public void SetOccupiedOrderDos(List<com.vip.isv.tools.OccupiedOrderDo> value){
			this.occupiedOrderDos_ = value;
		}
		public int? GetTotalCount(){
			return this.totalCount_;
		}
		
		public void SetTotalCount(int? value){
			this.totalCount_ = value;
		}
		
	}
	
}