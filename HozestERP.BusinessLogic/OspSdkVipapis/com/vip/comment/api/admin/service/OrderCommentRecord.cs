using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.comment.api.admin.service{
	
	
	
	
	
	public class OrderCommentRecord {
		
		///<summary>
		/// 订单编号入参必填，出参一定有返回，最大长度50字节
		///</summary>
		
		private string ordersn_;
		
		///<summary>
		/// 承运商编号入参必填，出参一定有返回
		///</summary>
		
		private long? custNo_;
		
		///<summary>
		/// 快递员编号最大长度50字节
		///</summary>
		
		private string deliveryManNo_;
		
		///<summary>
		/// 快递员名字最大长度30字节
		///</summary>
		
		private string deliveryManName_;
		
		///<summary>
		/// 服务态度打分入参必填，出参一定有返回
		///</summary>
		
		private com.vip.comment.api.admin.service.StarScore? serviceStarScore_;
		
		///<summary>
		/// 物流时效打分入参必填，出参一定有返回
		///</summary>
		
		private com.vip.comment.api.admin.service.StarScore? recetimeStarScore_;
		
		///<summary>
		/// 商品包装打分入参必填，出参一定有返回
		///</summary>
		
		private com.vip.comment.api.admin.service.StarScore? packageStarScore_;
		
		///<summary>
		/// 服务满意度
		///</summary>
		
		private com.vip.comment.api.admin.service.Satisfaction? satisfaction_;
		
		///<summary>
		/// 对快递员印象,多个印象标签使用^分开最大长度50字节
		///</summary>
		
		private string impressToDelivery_;
		
		///<summary>
		/// 收件感受限制文字100字符最大长度100字节
		///</summary>
		
		private string feelings_;
		
		///<summary>
		/// 提交时间出参一定有返回
		///</summary>
		
		private long? createTime_;
		
		///<summary>
		/// 提交人入参必填，出参一定有返回 ，最大长度30字节
		///</summary>
		
		private string createBy_;
		
		public string GetOrdersn(){
			return this.ordersn_;
		}
		
		public void SetOrdersn(string value){
			this.ordersn_ = value;
		}
		public long? GetCustNo(){
			return this.custNo_;
		}
		
		public void SetCustNo(long? value){
			this.custNo_ = value;
		}
		public string GetDeliveryManNo(){
			return this.deliveryManNo_;
		}
		
		public void SetDeliveryManNo(string value){
			this.deliveryManNo_ = value;
		}
		public string GetDeliveryManName(){
			return this.deliveryManName_;
		}
		
		public void SetDeliveryManName(string value){
			this.deliveryManName_ = value;
		}
		public com.vip.comment.api.admin.service.StarScore? GetServiceStarScore(){
			return this.serviceStarScore_;
		}
		
		public void SetServiceStarScore(com.vip.comment.api.admin.service.StarScore? value){
			this.serviceStarScore_ = value;
		}
		public com.vip.comment.api.admin.service.StarScore? GetRecetimeStarScore(){
			return this.recetimeStarScore_;
		}
		
		public void SetRecetimeStarScore(com.vip.comment.api.admin.service.StarScore? value){
			this.recetimeStarScore_ = value;
		}
		public com.vip.comment.api.admin.service.StarScore? GetPackageStarScore(){
			return this.packageStarScore_;
		}
		
		public void SetPackageStarScore(com.vip.comment.api.admin.service.StarScore? value){
			this.packageStarScore_ = value;
		}
		public com.vip.comment.api.admin.service.Satisfaction? GetSatisfaction(){
			return this.satisfaction_;
		}
		
		public void SetSatisfaction(com.vip.comment.api.admin.service.Satisfaction? value){
			this.satisfaction_ = value;
		}
		public string GetImpressToDelivery(){
			return this.impressToDelivery_;
		}
		
		public void SetImpressToDelivery(string value){
			this.impressToDelivery_ = value;
		}
		public string GetFeelings(){
			return this.feelings_;
		}
		
		public void SetFeelings(string value){
			this.feelings_ = value;
		}
		public long? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(long? value){
			this.createTime_ = value;
		}
		public string GetCreateBy(){
			return this.createBy_;
		}
		
		public void SetCreateBy(string value){
			this.createBy_ = value;
		}
		
	}
	
}