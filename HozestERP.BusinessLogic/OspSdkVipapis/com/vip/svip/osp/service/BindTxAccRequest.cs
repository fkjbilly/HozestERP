using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class BindTxAccRequest {
		
		///<summary>
		/// 唯品会用户ID
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// ip
		///</summary>
		
		private string userIp_;
		
		///<summary>
		/// mid
		///</summary>
		
		private string mid_;
		
		///<summary>
		/// 腾讯侧账号类型 (1.QQ openId 2.微信 openId 3.QQ号)
		///</summary>
		
		private int? txAccType_;
		
		///<summary>
		/// 腾讯侧账号(QQ号 或 联登的openId)
		///</summary>
		
		private string txOpenId_;
		
		///<summary>
		/// 腾讯侧头像url
		///</summary>
		
		private string txFigureUrl_;
		
		///<summary>
		/// 腾讯侧昵称
		///</summary>
		
		private string txNickName_;
		
		///<summary>
		/// appid
		///</summary>
		
		private string appId_;
		
		///<summary>
		/// dataSign
		///</summary>
		
		private string dataSign_;
		
		///<summary>
		/// accessToken 腾讯登录态
		///</summary>
		
		private string accessToken_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetUserIp(){
			return this.userIp_;
		}
		
		public void SetUserIp(string value){
			this.userIp_ = value;
		}
		public string GetMid(){
			return this.mid_;
		}
		
		public void SetMid(string value){
			this.mid_ = value;
		}
		public int? GetTxAccType(){
			return this.txAccType_;
		}
		
		public void SetTxAccType(int? value){
			this.txAccType_ = value;
		}
		public string GetTxOpenId(){
			return this.txOpenId_;
		}
		
		public void SetTxOpenId(string value){
			this.txOpenId_ = value;
		}
		public string GetTxFigureUrl(){
			return this.txFigureUrl_;
		}
		
		public void SetTxFigureUrl(string value){
			this.txFigureUrl_ = value;
		}
		public string GetTxNickName(){
			return this.txNickName_;
		}
		
		public void SetTxNickName(string value){
			this.txNickName_ = value;
		}
		public string GetAppId(){
			return this.appId_;
		}
		
		public void SetAppId(string value){
			this.appId_ = value;
		}
		public string GetDataSign(){
			return this.dataSign_;
		}
		
		public void SetDataSign(string value){
			this.dataSign_ = value;
		}
		public string GetAccessToken(){
			return this.accessToken_;
		}
		
		public void SetAccessToken(string value){
			this.accessToken_ = value;
		}
		
	}
	
}