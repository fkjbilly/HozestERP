using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class MultiPickDetailInfo {
		
		///<summary>
		/// po单编号
		///</summary>
		
		private string po_no_;
		
		///<summary>
		/// 拣货单编号
		///</summary>
		
		private string pick_no_;
		
		///<summary>
		/// 送货仓库
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 货号
		///</summary>
		
		private string sn_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 尺码
		///</summary>
		
		private string size_;
		
		///<summary>
		/// 商品拣货数
		///</summary>
		
		private int? pick_num_;
		
		///<summary>
		/// 商品未发货数
		///</summary>
		
		private int? not_delivery_num_;
		
		///<summary>
		/// 门店号
		///</summary>
		
		private string store_sn_;
		
		///<summary>
		/// <s><font>是否已参与专场活动 false、未加入 true、加入(作废)</font></s>
		///</summary>
		
		private bool? is_attended_activities_;
		
		///<summary>
		/// jit类型，1：OXO ，2：仓中仓，<br>返回空时，则为普通jit
		///</summary>
		
		private int? jit_type_;
		
		public string GetPo_no(){
			return this.po_no_;
		}
		
		public void SetPo_no(string value){
			this.po_no_ = value;
		}
		public string GetPick_no(){
			return this.pick_no_;
		}
		
		public void SetPick_no(string value){
			this.pick_no_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetSn(){
			return this.sn_;
		}
		
		public void SetSn(string value){
			this.sn_ = value;
		}
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public string GetSize(){
			return this.size_;
		}
		
		public void SetSize(string value){
			this.size_ = value;
		}
		public int? GetPick_num(){
			return this.pick_num_;
		}
		
		public void SetPick_num(int? value){
			this.pick_num_ = value;
		}
		public int? GetNot_delivery_num(){
			return this.not_delivery_num_;
		}
		
		public void SetNot_delivery_num(int? value){
			this.not_delivery_num_ = value;
		}
		public string GetStore_sn(){
			return this.store_sn_;
		}
		
		public void SetStore_sn(string value){
			this.store_sn_ = value;
		}
		public bool? GetIs_attended_activities(){
			return this.is_attended_activities_;
		}
		
		public void SetIs_attended_activities(bool? value){
			this.is_attended_activities_ = value;
		}
		public int? GetJit_type(){
			return this.jit_type_;
		}
		
		public void SetJit_type(int? value){
			this.jit_type_ = value;
		}
		
	}
	
}