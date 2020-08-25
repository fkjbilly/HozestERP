using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class EditPoRequest {
		
		///<summary>
		/// 系统入库凭证
		///</summary>
		
		private string systemPoNo_;
		
		///<summary>
		/// 客户入库凭证
		///</summary>
		
		private string clientPoNo_;
		
		///<summary>
		/// 仓库编码
		///</summary>
		
		private string warehouseCode_;
		
		///<summary>
		/// 默认销售渠道 0:待定 1:唯品会 2:非唯品会 3:乐蜂
		///</summary>
		
		private com.vip.domain.inventory.ChannelInventoryChannel? channel_;
		
		///<summary>
		/// 一退联系人
		///</summary>
		
		private string contacter_;
		
		///<summary>
		/// 一退联系人电话
		///</summary>
		
		private string contacterTel_;
		
		///<summary>
		/// 一退联系人手机
		///</summary>
		
		private string contacterMobie_;
		
		///<summary>
		/// 一退国家
		///</summary>
		
		private string country_;
		
		///<summary>
		/// 一退省名称
		///</summary>
		
		private string state_;
		
		///<summary>
		/// 一退市名称
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 一退区名称
		///</summary>
		
		private string district_;
		
		///<summary>
		/// 一退详细地址
		///</summary>
		
		private string address_;
		
		///<summary>
		/// 一退邮箱
		///</summary>
		
		private string email_;
		
		///<summary>
		/// 重量
		///</summary>
		
		private string weight_;
		
		///<summary>
		/// 体积
		///</summary>
		
		private string volume_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 创建人
		///</summary>
		
		private string createUser_;
		
		public string GetSystemPoNo(){
			return this.systemPoNo_;
		}
		
		public void SetSystemPoNo(string value){
			this.systemPoNo_ = value;
		}
		public string GetClientPoNo(){
			return this.clientPoNo_;
		}
		
		public void SetClientPoNo(string value){
			this.clientPoNo_ = value;
		}
		public string GetWarehouseCode(){
			return this.warehouseCode_;
		}
		
		public void SetWarehouseCode(string value){
			this.warehouseCode_ = value;
		}
		public com.vip.domain.inventory.ChannelInventoryChannel? GetChannel(){
			return this.channel_;
		}
		
		public void SetChannel(com.vip.domain.inventory.ChannelInventoryChannel? value){
			this.channel_ = value;
		}
		public string GetContacter(){
			return this.contacter_;
		}
		
		public void SetContacter(string value){
			this.contacter_ = value;
		}
		public string GetContacterTel(){
			return this.contacterTel_;
		}
		
		public void SetContacterTel(string value){
			this.contacterTel_ = value;
		}
		public string GetContacterMobie(){
			return this.contacterMobie_;
		}
		
		public void SetContacterMobie(string value){
			this.contacterMobie_ = value;
		}
		public string GetCountry(){
			return this.country_;
		}
		
		public void SetCountry(string value){
			this.country_ = value;
		}
		public string GetState(){
			return this.state_;
		}
		
		public void SetState(string value){
			this.state_ = value;
		}
		public string GetCity(){
			return this.city_;
		}
		
		public void SetCity(string value){
			this.city_ = value;
		}
		public string GetDistrict(){
			return this.district_;
		}
		
		public void SetDistrict(string value){
			this.district_ = value;
		}
		public string GetAddress(){
			return this.address_;
		}
		
		public void SetAddress(string value){
			this.address_ = value;
		}
		public string GetEmail(){
			return this.email_;
		}
		
		public void SetEmail(string value){
			this.email_ = value;
		}
		public string GetWeight(){
			return this.weight_;
		}
		
		public void SetWeight(string value){
			this.weight_ = value;
		}
		public string GetVolume(){
			return this.volume_;
		}
		
		public void SetVolume(string value){
			this.volume_ = value;
		}
		public string GetRemark(){
			return this.remark_;
		}
		
		public void SetRemark(string value){
			this.remark_ = value;
		}
		public string GetCreateUser(){
			return this.createUser_;
		}
		
		public void SetCreateUser(string value){
			this.createUser_ = value;
		}
		
	}
	
}