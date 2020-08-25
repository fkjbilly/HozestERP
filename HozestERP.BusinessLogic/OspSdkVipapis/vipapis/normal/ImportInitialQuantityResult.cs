using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.normal{
	
	
	
	
	
	public class ImportInitialQuantityResult {
		
		///<summary>
		/// 总记录数
		///</summary>
		
		private int? total_;
		
		///<summary>
		/// 导入初始库存明细
		///</summary>
		
		private List<vipapis.normal.ImportInitialQuantity> importInitialQuantityList_;
		
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		public List<vipapis.normal.ImportInitialQuantity> GetImportInitialQuantityList(){
			return this.importInitialQuantityList_;
		}
		
		public void SetImportInitialQuantityList(List<vipapis.normal.ImportInitialQuantity> value){
			this.importInitialQuantityList_ = value;
		}
		
	}
	
}