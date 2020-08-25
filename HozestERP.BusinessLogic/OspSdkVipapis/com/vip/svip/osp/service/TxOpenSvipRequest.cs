using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class TxOpenSvipRequest {
		
		///<summary>
		/// userIp
		///</summary>
		
		private string userIp_;
		
		///<summary>
		/// 腾讯订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 腾讯视频会员类型(1:季卡 2:年卡)
		///</summary>
		
		private string tencentMemberType_;
		
		///<summary>
		/// 唯品会用户openId
		///</summary>
		
		private string openId_;
		
		///<summary>
		/// 腾讯账号
		///</summary>
		
		private string tencentUserId_;
		
		///<summary>
		/// 腾讯账号类型
		///</summary>
		
		private string tencentUserType_;
		
		///<summary>
		/// 唯品会svip类型(1:年卡)
		///</summary>
		
		private string svipType_;
		
		///<summary>
		/// 验签
		///</summary>
		
		private string dataSign_;
		
		public string GetUserIp(){
			return this.userIp_;
		}
		
		public void SetUserIp(string value){
			this.userIp_ = value;
		}
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetTencentMemberType(){
			return this.tencentMemberType_;
		}
		
		public void SetTencentMemberType(string value){
			this.tencentMemberType_ = value;
		}
		public string GetOpenId(){
			return this.openId_;
		}
		
		public void SetOpenId(string value){
			this.openId_ = value;
		}
		public string GetTencentUserId(){
			return this.tencentUserId_;
		}
		
		public void SetTencentUserId(string value){
			this.tencentUserId_ = value;
		}
		public string GetTencentUserType(){
			return this.tencentUserType_;
		}
		
		public void SetTencentUserType(string value){
			this.tencentUserType_ = value;
		}
		public string GetSvipType(){
			return this.svipType_;
		}
		
		public void SetSvipType(string value){
			this.svipType_ = value;
		}
		public string GetDataSign(){
			return this.dataSign_;
		}
		
		public void SetDataSign(string value){
			this.dataSign_ = value;
		}
		
	}
	
}