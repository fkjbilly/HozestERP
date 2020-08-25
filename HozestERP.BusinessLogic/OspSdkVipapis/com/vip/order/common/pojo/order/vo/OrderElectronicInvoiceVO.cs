using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.order.common.pojo.order.vo{
	
	
	
	
	
	public class OrderElectronicInvoiceVO {
		
		///<summary>
		/// 发票抬头
		///</summary>
		
		private string title_;
		
		///<summary>
		/// 发票状态
		///</summary>
		
		private int? status_;
		
		///<summary>
		/// 手机号码
		///</summary>
		
		private string phone_;
		
		///<summary>
		/// 发票代码号码
		///</summary>
		
		private string fpFm_;
		
		///<summary>
		/// 扩展字段1
		///</summary>
		
		private string ext1_;
		
		///<summary>
		/// 扩展字段2
		///</summary>
		
		private string ext2_;
		
		///<summary>
		/// 发票id
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 用户id
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 订单编号
		///</summary>
		
		private long? orderId_;
		
		///<summary>
		/// 订单Sn号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 创建时间,格式 yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string createTime_;
		
		///<summary>
		/// 更新时间,格式 yyyy-MM-dd HH:mm:ss
		///</summary>
		
		private string updateTime_;
		
		///<summary>
		/// 电子发票链接
		///</summary>
		
		private string invoiceUrl_;
		
		///<summary>
		/// 纳税人识别号
		///</summary>
		
		private string taxPayerNo_;
		
		///<summary>
		/// 是否删除标志
		///</summary>
		
		private int? isDeleted_;
		
		public string GetTitle(){
			return this.title_;
		}
		
		public void SetTitle(string value){
			this.title_ = value;
		}
		public int? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(int? value){
			this.status_ = value;
		}
		public string GetPhone(){
			return this.phone_;
		}
		
		public void SetPhone(string value){
			this.phone_ = value;
		}
		public string GetFpFm(){
			return this.fpFm_;
		}
		
		public void SetFpFm(string value){
			this.fpFm_ = value;
		}
		public string GetExt1(){
			return this.ext1_;
		}
		
		public void SetExt1(string value){
			this.ext1_ = value;
		}
		public string GetExt2(){
			return this.ext2_;
		}
		
		public void SetExt2(string value){
			this.ext2_ = value;
		}
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
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
		public string GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(string value){
			this.createTime_ = value;
		}
		public string GetUpdateTime(){
			return this.updateTime_;
		}
		
		public void SetUpdateTime(string value){
			this.updateTime_ = value;
		}
		public string GetInvoiceUrl(){
			return this.invoiceUrl_;
		}
		
		public void SetInvoiceUrl(string value){
			this.invoiceUrl_ = value;
		}
		public string GetTaxPayerNo(){
			return this.taxPayerNo_;
		}
		
		public void SetTaxPayerNo(string value){
			this.taxPayerNo_ = value;
		}
		public int? GetIsDeleted(){
			return this.isDeleted_;
		}
		
		public void SetIsDeleted(int? value){
			this.isDeleted_ = value;
		}
		
	}
	
}