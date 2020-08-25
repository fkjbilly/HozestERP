using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.delivery{
	
	
	
	
	
	public class Return {
		
		///<summary>
		/// 客退申请单号
		///</summary>
		
		private string order_return_id_;
		
		///<summary>
		/// 退货商品列表
		///</summary>
		
		private List<vipapis.delivery.ReturnGoodsDetail> return_goods_details_;
		
		///<summary>
		/// 客退金额（实际退给用户金额）暂时返回空字符串
		///</summary>
		
		private string refund_amount_;
		
		public string GetOrder_return_id(){
			return this.order_return_id_;
		}
		
		public void SetOrder_return_id(string value){
			this.order_return_id_ = value;
		}
		public List<vipapis.delivery.ReturnGoodsDetail> GetReturn_goods_details(){
			return this.return_goods_details_;
		}
		
		public void SetReturn_goods_details(List<vipapis.delivery.ReturnGoodsDetail> value){
			this.return_goods_details_ = value;
		}
		public string GetRefund_amount(){
			return this.refund_amount_;
		}
		
		public void SetRefund_amount(string value){
			this.refund_amount_ = value;
		}
		
	}
	
}