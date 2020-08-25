using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.puma{
	
	
	
	
	
	public class Cps {
		
		///<summary>
		/// 分享链接
		///</summary>
		
		private string cps_url_;
		
		///<summary>
		/// 分享标题
		///</summary>
		
		private string share_title_;
		
		///<summary>
		/// 分享描述
		///</summary>
		
		private string share_desc_;
		
		///<summary>
		/// 分享缩略图
		///</summary>
		
		private string share_image_url_;
		
		///<summary>
		/// 微信小程序链接
		///</summary>
		
		private string wx_small_program_url_;
		
		///<summary>
		/// 老客佣金, 保留2位小数
		///</summary>
		
		private string commission_value_;
		
		///<summary>
		/// 新客佣金, 保留2位小数
		///</summary>
		
		private string commission_value_newcust_;
		
		///<summary>
		/// 符号,%或￥
		///</summary>
		
		private string sign_;
		
		///<summary>
		/// 是否cps用户
		///</summary>
		
		private bool? exist_user_;
		
		public string GetCps_url(){
			return this.cps_url_;
		}
		
		public void SetCps_url(string value){
			this.cps_url_ = value;
		}
		public string GetShare_title(){
			return this.share_title_;
		}
		
		public void SetShare_title(string value){
			this.share_title_ = value;
		}
		public string GetShare_desc(){
			return this.share_desc_;
		}
		
		public void SetShare_desc(string value){
			this.share_desc_ = value;
		}
		public string GetShare_image_url(){
			return this.share_image_url_;
		}
		
		public void SetShare_image_url(string value){
			this.share_image_url_ = value;
		}
		public string GetWx_small_program_url(){
			return this.wx_small_program_url_;
		}
		
		public void SetWx_small_program_url(string value){
			this.wx_small_program_url_ = value;
		}
		public string GetCommission_value(){
			return this.commission_value_;
		}
		
		public void SetCommission_value(string value){
			this.commission_value_ = value;
		}
		public string GetCommission_value_newcust(){
			return this.commission_value_newcust_;
		}
		
		public void SetCommission_value_newcust(string value){
			this.commission_value_newcust_ = value;
		}
		public string GetSign(){
			return this.sign_;
		}
		
		public void SetSign(string value){
			this.sign_ = value;
		}
		public bool? GetExist_user(){
			return this.exist_user_;
		}
		
		public void SetExist_user(bool? value){
			this.exist_user_ = value;
		}
		
	}
	
}