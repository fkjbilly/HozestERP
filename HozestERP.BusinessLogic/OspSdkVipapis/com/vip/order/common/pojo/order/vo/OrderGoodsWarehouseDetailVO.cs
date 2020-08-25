using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderGoodsWarehouseDetailVO {
		
		///<summary>
		/// 商品尺码(~~~~~已弃用,请使用merItemNo~~~~~)
		///</summary>
		
		private long? sizeId_;
		
		///<summary>
		/// 发货仓
		///</summary>
		
		private string bondedWarehouse_;
		
		///<summary>
		/// 尺码货源仓明细 格式 {"VIP_NH":2,"VIP_SH":1}
		///</summary>
		
		private string sourceWarehouseDetail_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private long? createTime_;
		
		///<summary>
		/// 商品编号
		///</summary>
		
		private string sizeSn_;
		
		///<summary>
		/// 商品档期ID(~~~~~已弃用,请使用salesNo~~~~~)
		///</summary>
		
		private int? brandId_;
		
		///<summary>
		/// 销售模式,0为普通模式，1为JIT
		///</summary>
		
		private int? saleStyle_;
		
		///<summary>
		/// 拆单引擎虚拟订单类型 0普通 1:海淘虚拟仓订单 2:全国库存共享
		///</summary>
		
		private int? vrOrderType_;
		
		///<summary>
		/// 是否已删除，0/1，1已删除
		///</summary>
		
		private int? isDelete_;
		
		///<summary>
		/// 订单ID
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 用户ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// parentSn
		///</summary>
		
		private string parentSn_;
		
		///<summary>
		/// 专场的SKU id(对应：size_id)
		///</summary>
		
		private long? merItemNo_;
		
		///<summary>
		/// 档期id(对应：brand_id)
		///</summary>
		
		private long? salesNo_;
		
		///<summary>
		/// ID
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// preAllocateId
		///</summary>
		
		private long? preAllocateId_;
		
		public long? GetSizeId(){
			return this.sizeId_;
		}
		
		public void SetSizeId(long? value){
			this.sizeId_ = value;
		}
		public string GetBondedWarehouse(){
			return this.bondedWarehouse_;
		}
		
		public void SetBondedWarehouse(string value){
			this.bondedWarehouse_ = value;
		}
		public string GetSourceWarehouseDetail(){
			return this.sourceWarehouseDetail_;
		}
		
		public void SetSourceWarehouseDetail(string value){
			this.sourceWarehouseDetail_ = value;
		}
		public long? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(long? value){
			this.createTime_ = value;
		}
		public string GetSizeSn(){
			return this.sizeSn_;
		}
		
		public void SetSizeSn(string value){
			this.sizeSn_ = value;
		}
		public int? GetBrandId(){
			return this.brandId_;
		}
		
		public void SetBrandId(int? value){
			this.brandId_ = value;
		}
		public int? GetSaleStyle(){
			return this.saleStyle_;
		}
		
		public void SetSaleStyle(int? value){
			this.saleStyle_ = value;
		}
		public int? GetVrOrderType(){
			return this.vrOrderType_;
		}
		
		public void SetVrOrderType(int? value){
			this.vrOrderType_ = value;
		}
		public int? GetIsDelete(){
			return this.isDelete_;
		}
		
		public void SetIsDelete(int? value){
			this.isDelete_ = value;
		}
		public long? GetOrderId(){
			return this.orderId_;
		}
		
		public void SetOrderId(long? value){
			this.orderId_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetParentSn(){
			return this.parentSn_;
		}
		
		public void SetParentSn(string value){
			this.parentSn_ = value;
		}
		public long? GetMerItemNo(){
			return this.merItemNo_;
		}
		
		public void SetMerItemNo(long? value){
			this.merItemNo_ = value;
		}
		public long? GetSalesNo(){
			return this.salesNo_;
		}
		
		public void SetSalesNo(long? value){
			this.salesNo_ = value;
		}
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public long? GetPreAllocateId(){
			return this.preAllocateId_;
		}
		
		public void SetPreAllocateId(long? value){
			this.preAllocateId_ = value;
		}
		
	}
	
}