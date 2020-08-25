using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class PickDetail {
		
		///<summary>
		/// PO单编号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 档期开始销售时间
		///</summary>
		
		private string sell_st_time_;
		
		///<summary>
		/// 档期结束销售时间
		///</summary>
		
		private string sell_et_time_;
		
		///<summary>
		/// 导出时间
		///</summary>
		
		private string export_time_;
		
		///<summary>
		/// 导出次数
		///</summary>
		
		private int? export_num_;
		
		///<summary>
		/// 送货仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 订单类别
		///</summary>
		
		private string order_cate_;
		
		///<summary>
		/// 拣货单商品信息
		///</summary>
		
		private List<vipapis.delivery.PickProduct> pick_product_list_;
		
		///<summary>
		/// 总记录
		///</summary>
		
		private int? total_;
		
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetSell_st_time(){
			return this.sell_st_time_;
		}
		
		public void SetSell_st_time(string value){
			this.sell_st_time_ = value;
		}
		public string GetSell_et_time(){
			return this.sell_et_time_;
		}
		
		public void SetSell_et_time(string value){
			this.sell_et_time_ = value;
		}
		public string GetExport_time(){
			return this.export_time_;
		}
		
		public void SetExport_time(string value){
			this.export_time_ = value;
		}
		public int? GetExport_num(){
			return this.export_num_;
		}
		
		public void SetExport_num(int? value){
			this.export_num_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetOrder_cate(){
			return this.order_cate_;
		}
		
		public void SetOrder_cate(string value){
			this.order_cate_ = value;
		}
		public List<vipapis.delivery.PickProduct> GetPick_product_list(){
			return this.pick_product_list_;
		}
		
		public void SetPick_product_list(List<vipapis.delivery.PickProduct> value){
			this.pick_product_list_ = value;
		}
		public int? GetTotal(){
			return this.total_;
		}
		
		public void SetTotal(int? value){
			this.total_ = value;
		}
		
	}
	
}