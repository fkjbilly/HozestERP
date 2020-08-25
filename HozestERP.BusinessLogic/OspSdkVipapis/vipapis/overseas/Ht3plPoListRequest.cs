using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.overseas{
	
	
	
	
	
	public class Ht3plPoListRequest {
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 请求批次号
		///</summary>
		
		private string batch_no_;
		
		///<summary>
		/// 起始po单id
		///</summary>
		
		private int? start_po_id_;
		
		///<summary>
		/// 读取数量
		/// @sampleValue num 默认为10， 最大为10
		///</summary>
		
		private int? num_;
		
		///<summary>
		/// 销售区域
		/// @sampleValue sale_area sale_area=ZZ
		///</summary>
		
		private vipapis.common.SaleArea? sale_area_;
		
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetBatch_no(){
			return this.batch_no_;
		}
		
		public void SetBatch_no(string value){
			this.batch_no_ = value;
		}
		public int? GetStart_po_id(){
			return this.start_po_id_;
		}
		
		public void SetStart_po_id(int? value){
			this.start_po_id_ = value;
		}
		public int? GetNum(){
			return this.num_;
		}
		
		public void SetNum(int? value){
			this.num_ = value;
		}
		public vipapis.common.SaleArea? GetSale_area(){
			return this.sale_area_;
		}
		
		public void SetSale_area(vipapis.common.SaleArea? value){
			this.sale_area_ = value;
		}
		
	}
	
}