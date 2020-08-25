using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OrderContainerDetail {
		
		///<summary>
		/// 数据的唯一标识
		///</summary>
		
		private string id_;
		
		///<summary>
		/// 订单号码
		///</summary>
		
		private string order_sn_;
		
		///<summary>
		/// 箱号
		///</summary>
		
		private string box_id_;
		
		///<summary>
		/// 商品条码
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// 商品名称
		///</summary>
		
		private string product_name_;
		
		///<summary>
		/// 箱中商品数量
		///</summary>
		
		private int? num_;
		
		///<summary>
		/// 是否是礼品
		///</summary>
		
		private string is_gift_;
		
		///<summary>
		/// 单价
		///</summary>
		
		private double? price_;
		
		///<summary>
		/// 单位
		///</summary>
		
		private string unit_;
		
		public string GetId(){
			return this.id_;
		}
		
		public void SetId(string value){
			this.id_ = value;
		}
		public string GetOrder_sn(){
			return this.order_sn_;
		}
		
		public void SetOrder_sn(string value){
			this.order_sn_ = value;
		}
		public string GetBox_id(){
			return this.box_id_;
		}
		
		public void SetBox_id(string value){
			this.box_id_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetProduct_name(){
			return this.product_name_;
		}
		
		public void SetProduct_name(string value){
			this.product_name_ = value;
		}
		public int? GetNum(){
			return this.num_;
		}
		
		public void SetNum(int? value){
			this.num_ = value;
		}
		public string GetIs_gift(){
			return this.is_gift_;
		}
		
		public void SetIs_gift(string value){
			this.is_gift_ = value;
		}
		public double? GetPrice(){
			return this.price_;
		}
		
		public void SetPrice(double? value){
			this.price_ = value;
		}
		public string GetUnit(){
			return this.unit_;
		}
		
		public void SetUnit(string value){
			this.unit_ = value;
		}
		
	}
	
}