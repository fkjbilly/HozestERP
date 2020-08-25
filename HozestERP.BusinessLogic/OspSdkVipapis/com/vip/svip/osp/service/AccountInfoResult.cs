using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class AccountInfoResult {
		
		///<summary>
		/// 唯品会账号名
		///</summary>
		
		private string vipAcc_;
		
		///<summary>
		/// 唯品会头像
		///</summary>
		
		private string vipFigureUrl_;
		
		///<summary>
		/// 腾讯昵称
		///</summary>
		
		private string txNickName_;
		
		///<summary>
		/// 腾讯账号类型:1qq 2微信
		///</summary>
		
		private int? txAccType_;
		
		///<summary>
		/// 腾讯openId: qq:openId  wechat:unionId
		///</summary>
		
		private string txOpenId_;
		
		///<summary>
		/// 腾讯头像url
		///</summary>
		
		private string txFigureUrl_;
		
		///<summary>
		/// 绑定状态 0.临时 1.已绑定(不可修改)
		///</summary>
		
		private int? state_;
		
		///<summary>
		/// 腾讯侧appid
		///</summary>
		
		private string txAppId_;
		
		public string GetVipAcc(){
			return this.vipAcc_;
		}
		
		public void SetVipAcc(string value){
			this.vipAcc_ = value;
		}
		public string GetVipFigureUrl(){
			return this.vipFigureUrl_;
		}
		
		public void SetVipFigureUrl(string value){
			this.vipFigureUrl_ = value;
		}
		public string GetTxNickName(){
			return this.txNickName_;
		}
		
		public void SetTxNickName(string value){
			this.txNickName_ = value;
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
		public int? GetState(){
			return this.state_;
		}
		
		public void SetState(int? value){
			this.state_ = value;
		}
		public string GetTxAppId(){
			return this.txAppId_;
		}
		
		public void SetTxAppId(string value){
			this.txAppId_ = value;
		}
		
	}
	
}