using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class DoubleSvipRequest {
		
		///<summary>
		/// 调用方key
		///</summary>
		
		private string apiKey_;
		
		///<summary>
		/// 调用方签名
		///</summary>
		
		private string apiSign_;
		
		///<summary>
		/// 唯品会用户ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 唯品会用户手机号码
		///</summary>
		
		private string userMobile_;
		
		///<summary>
		/// 唯品会用户账号
		///</summary>
		
		private string userAccount_;
		
		///<summary>
		/// 用户的IP地址
		///</summary>
		
		private string ip_;
		
		///<summary>
		/// 腾讯账号：qq号或微信号
		///</summary>
		
		private string tencentUserId_;
		
		///<summary>
		/// 腾讯账号类型 1 QQ，2 微信
		///</summary>
		
		private int? tencentUserType_;
		
		///<summary>
		/// 唯品会svip开通类型：1年卡
		///</summary>
		
		private int? svipType_;
		
		///<summary>
		/// 腾讯视频开通会员类型：1 季卡；2年卡
		///</summary>
		
		private int? tencentMemberType_;
		
		///<summary>
		/// 开通服务时的订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// vorder订单对应的商品ID
		///</summary>
		
		private string productId_;
		
		///<summary>
		/// 来创建svip的token
		///</summary>
		
		private string svipToken_;
		
		///<summary>
		/// 唯品会用户open id
		///</summary>
		
		private string openId_;
		
		///<summary>
		/// vorder订单对应的商品名称（发短信用）
		///</summary>
		
		private string productName_;
		
		public string GetApiKey(){
			return this.apiKey_;
		}
		
		public void SetApiKey(string value){
			this.apiKey_ = value;
		}
		public string GetApiSign(){
			return this.apiSign_;
		}
		
		public void SetApiSign(string value){
			this.apiSign_ = value;
		}
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetUserMobile(){
			return this.userMobile_;
		}
		
		public void SetUserMobile(string value){
			this.userMobile_ = value;
		}
		public string GetUserAccount(){
			return this.userAccount_;
		}
		
		public void SetUserAccount(string value){
			this.userAccount_ = value;
		}
		public string GetIp(){
			return this.ip_;
		}
		
		public void SetIp(string value){
			this.ip_ = value;
		}
		public string GetTencentUserId(){
			return this.tencentUserId_;
		}
		
		public void SetTencentUserId(string value){
			this.tencentUserId_ = value;
		}
		public int? GetTencentUserType(){
			return this.tencentUserType_;
		}
		
		public void SetTencentUserType(int? value){
			this.tencentUserType_ = value;
		}
		public int? GetSvipType(){
			return this.svipType_;
		}
		
		public void SetSvipType(int? value){
			this.svipType_ = value;
		}
		public int? GetTencentMemberType(){
			return this.tencentMemberType_;
		}
		
		public void SetTencentMemberType(int? value){
			this.tencentMemberType_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetProductId(){
			return this.productId_;
		}
		
		public void SetProductId(string value){
			this.productId_ = value;
		}
		public string GetSvipToken(){
			return this.svipToken_;
		}
		
		public void SetSvipToken(string value){
			this.svipToken_ = value;
		}
		public string GetOpenId(){
			return this.openId_;
		}
		
		public void SetOpenId(string value){
			this.openId_ = value;
		}
		public string GetProductName(){
			return this.productName_;
		}
		
		public void SetProductName(string value){
			this.productName_ = value;
		}
		
	}
	
}