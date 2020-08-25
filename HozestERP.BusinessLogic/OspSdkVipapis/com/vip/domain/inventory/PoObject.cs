using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.domain.inventory{
	
	
	
	
	
	public class PoObject {
		
		///<summary>
		/// 系统入库凭证
		///</summary>
		
		private string systemPoNo_;
		
		///<summary>
		/// 客户入库凭证
		///</summary>
		
		private string clientPoNo_;
		
		///<summary>
		/// 收货仓编码
		///</summary>
		
		private string warehouseCode_;
		
		///<summary>
		/// 入库单状态  0-新增。1-同步商务审批，2-商务审核中，3-审核不通过，4-审批成功，5-同步WMS 失败，6-取消中，7-取消成功，8-同步WMS 上架时间
		///</summary>
		
		private string poStatus_;
		
		///<summary>
		/// 销售区域
		///</summary>
		
		private string saleArea_;
		
		///<summary>
		/// 邮政编码
		///</summary>
		
		private string zip_;
		
		///<summary>
		/// 仓库收货人
		///</summary>
		
		private string warehouseContacter_;
		
		///<summary>
		/// 仓库收货人电话
		///</summary>
		
		private string warehouseContacterTel_;
		
		///<summary>
		/// 仓库收货人手机
		///</summary>
		
		private string warehouseContacterMobie_;
		
		///<summary>
		/// 仓库收货国家
		///</summary>
		
		private string warehouseCountry_;
		
		///<summary>
		/// 仓库收货省
		///</summary>
		
		private string warehouseState_;
		
		///<summary>
		/// 仓库收货市
		///</summary>
		
		private string warehouseCity_;
		
		///<summary>
		/// 仓库收货区
		///</summary>
		
		private string warehouseDistrict_;
		
		///<summary>
		/// 仓库收货详细地址
		///</summary>
		
		private string warehouseAddress_;
		
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
		/// 总件数
		///</summary>
		
		private int? itemTotal_;
		
		///<summary>
		/// PO上架时间 (例如:2017-10-27 12:25:26)
		///</summary>
		
		private string onRacksTime_;
		
		///<summary>
		/// 备注
		///</summary>
		
		private string remark_;
		
		///<summary>
		/// 创建人
		///</summary>
		
		private string createUser_;
		
		///<summary>
		/// 创建时间 (例如:2017-10-27 12:25:26)
		///</summary>
		
		private string createdDtmLoc_;
		
		///<summary>
		/// 修改人
		///</summary>
		
		private string updatedUser_;
		
		///<summary>
		/// 修改时间 (例如:2017-10-27 12:25:26)
		///</summary>
		
		private string updatedDtmLoc_;
		
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
		public string GetPoStatus(){
			return this.poStatus_;
		}
		
		public void SetPoStatus(string value){
			this.poStatus_ = value;
		}
		public string GetSaleArea(){
			return this.saleArea_;
		}
		
		public void SetSaleArea(string value){
			this.saleArea_ = value;
		}
		public string GetZip(){
			return this.zip_;
		}
		
		public void SetZip(string value){
			this.zip_ = value;
		}
		public string GetWarehouseContacter(){
			return this.warehouseContacter_;
		}
		
		public void SetWarehouseContacter(string value){
			this.warehouseContacter_ = value;
		}
		public string GetWarehouseContacterTel(){
			return this.warehouseContacterTel_;
		}
		
		public void SetWarehouseContacterTel(string value){
			this.warehouseContacterTel_ = value;
		}
		public string GetWarehouseContacterMobie(){
			return this.warehouseContacterMobie_;
		}
		
		public void SetWarehouseContacterMobie(string value){
			this.warehouseContacterMobie_ = value;
		}
		public string GetWarehouseCountry(){
			return this.warehouseCountry_;
		}
		
		public void SetWarehouseCountry(string value){
			this.warehouseCountry_ = value;
		}
		public string GetWarehouseState(){
			return this.warehouseState_;
		}
		
		public void SetWarehouseState(string value){
			this.warehouseState_ = value;
		}
		public string GetWarehouseCity(){
			return this.warehouseCity_;
		}
		
		public void SetWarehouseCity(string value){
			this.warehouseCity_ = value;
		}
		public string GetWarehouseDistrict(){
			return this.warehouseDistrict_;
		}
		
		public void SetWarehouseDistrict(string value){
			this.warehouseDistrict_ = value;
		}
		public string GetWarehouseAddress(){
			return this.warehouseAddress_;
		}
		
		public void SetWarehouseAddress(string value){
			this.warehouseAddress_ = value;
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
		public int? GetItemTotal(){
			return this.itemTotal_;
		}
		
		public void SetItemTotal(int? value){
			this.itemTotal_ = value;
		}
		public string GetOnRacksTime(){
			return this.onRacksTime_;
		}
		
		public void SetOnRacksTime(string value){
			this.onRacksTime_ = value;
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
		public string GetCreatedDtmLoc(){
			return this.createdDtmLoc_;
		}
		
		public void SetCreatedDtmLoc(string value){
			this.createdDtmLoc_ = value;
		}
		public string GetUpdatedUser(){
			return this.updatedUser_;
		}
		
		public void SetUpdatedUser(string value){
			this.updatedUser_ = value;
		}
		public string GetUpdatedDtmLoc(){
			return this.updatedDtmLoc_;
		}
		
		public void SetUpdatedDtmLoc(string value){
			this.updatedDtmLoc_ = value;
		}
		
	}
	
}