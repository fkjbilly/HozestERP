using System;
using System.Collections.Generic;
using System.Text;

namespace vipapis.address{
	
	
	
	
	
	public class Address {
		
		///<summary>
		/// 地址编码
		/// @sampleValue address_code 104104
		///</summary>
		
		private string address_code_;
		
		///<summary>
		/// 地址中文名
		/// @sampleValue address_name 广东省
		///</summary>
		
		private string address_name_;
		
		///<summary>
		/// 省市区街道全称
		/// @sampleValue full_name 广东省
		///</summary>
		
		private string full_name_;
		
		///<summary>
		/// 父级地址代码
		/// @sampleValue parent_code 
		///</summary>
		
		private string parent_code_;
		
		///<summary>
		/// 是否存在下级  0否 1是
		/// @sampleValue has_children 1
		///</summary>
		
		private byte? has_children_;
		
		///<summary>
		/// 是否直辖  0否 1是
		/// @sampleValue is_directly 0
		///</summary>
		
		private byte? is_directly_;
		
		///<summary>
		/// 邮资,单位元
		/// @sampleValue postage 10
		///</summary>
		
		private double? postage_;
		
		///<summary>
		/// TMS是否支持货到付款  0否 1是
		/// @sampleValue is_cod 1
		///</summary>
		
		private byte? is_cod_;
		
		///<summary>
		/// 是否支持pos支付  0否 1是
		/// @sampleValue is_pos 0
		///</summary>
		
		private byte? is_pos_;
		
		///<summary>
		/// 是否大件商品  0否 1是
		/// @sampleValue is_big 0
		///</summary>
		
		private byte? is_big_;
		
		///<summary>
		/// 是否支持支付宝钱包货到付款  0否 1是
		/// @sampleValue is_app 0
		///</summary>
		
		private byte? is_app_;
		
		///<summary>
		/// 承运商收取手续费,单位元
		/// @sampleValue cod_fee 0
		///</summary>
		
		private double? cod_fee_;
		
		///<summary>
		/// 是否提供配送服务  0否 1是
		/// @sampleValue is_service 1
		///</summary>
		
		private byte? is_service_;
		
		///<summary>
		/// 是否支持EMS  0否 1是
		/// @sampleValue is_ems 1
		///</summary>
		
		private byte? is_ems_;
		
		///<summary>
		/// 大件商品费,单位元
		/// @sampleValue big_money 5
		///</summary>
		
		private double? big_money_;
		
		///<summary>
		/// 状态： 1正常 ，2无效
		/// @sampleValue state 1
		///</summary>
		
		private byte? state_;
		
		///<summary>
		/// 邮编
		/// @sampleValue post_code 510000
		///</summary>
		
		private string post_code_;
		
		///<summary>
		/// 是否支持多承运商  0否 1是
		/// @sampleValue more_carrier 0
		///</summary>
		
		private byte? more_carrier_;
		
		///<summary>
		/// 默认承运商简称
		/// @sampleValue carrier_name EMS
		///</summary>
		
		private string carrier_name_;
		
		///<summary>
		/// 到货时效
		/// @sampleValue delivery 
		///</summary>
		
		private string delivery_;
		
		///<summary>
		/// 所属仓库
		/// @sampleValue warehouse VIP_NH
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 是否支持空运  0否 1是
		/// @sampleValue is_support_air_embargo 1
		///</summary>
		
		private byte? is_support_air_embargo_;
		
		///<summary>
		/// 地址类型
		/// @sampleValue addr_type 0
		///</summary>
		
		private int? addr_type_;
		
		///<summary>
		/// 区域类型
		/// @sampleValue area_type 0
		///</summary>
		
		private string area_type_;
		
		public string GetAddress_code(){
			return this.address_code_;
		}
		
		public void SetAddress_code(string value){
			this.address_code_ = value;
		}
		public string GetAddress_name(){
			return this.address_name_;
		}
		
		public void SetAddress_name(string value){
			this.address_name_ = value;
		}
		public string GetFull_name(){
			return this.full_name_;
		}
		
		public void SetFull_name(string value){
			this.full_name_ = value;
		}
		public string GetParent_code(){
			return this.parent_code_;
		}
		
		public void SetParent_code(string value){
			this.parent_code_ = value;
		}
		public byte? GetHas_children(){
			return this.has_children_;
		}
		
		public void SetHas_children(byte? value){
			this.has_children_ = value;
		}
		public byte? GetIs_directly(){
			return this.is_directly_;
		}
		
		public void SetIs_directly(byte? value){
			this.is_directly_ = value;
		}
		public double? GetPostage(){
			return this.postage_;
		}
		
		public void SetPostage(double? value){
			this.postage_ = value;
		}
		public byte? GetIs_cod(){
			return this.is_cod_;
		}
		
		public void SetIs_cod(byte? value){
			this.is_cod_ = value;
		}
		public byte? GetIs_pos(){
			return this.is_pos_;
		}
		
		public void SetIs_pos(byte? value){
			this.is_pos_ = value;
		}
		public byte? GetIs_big(){
			return this.is_big_;
		}
		
		public void SetIs_big(byte? value){
			this.is_big_ = value;
		}
		public byte? GetIs_app(){
			return this.is_app_;
		}
		
		public void SetIs_app(byte? value){
			this.is_app_ = value;
		}
		public double? GetCod_fee(){
			return this.cod_fee_;
		}
		
		public void SetCod_fee(double? value){
			this.cod_fee_ = value;
		}
		public byte? GetIs_service(){
			return this.is_service_;
		}
		
		public void SetIs_service(byte? value){
			this.is_service_ = value;
		}
		public byte? GetIs_ems(){
			return this.is_ems_;
		}
		
		public void SetIs_ems(byte? value){
			this.is_ems_ = value;
		}
		public double? GetBig_money(){
			return this.big_money_;
		}
		
		public void SetBig_money(double? value){
			this.big_money_ = value;
		}
		public byte? GetState(){
			return this.state_;
		}
		
		public void SetState(byte? value){
			this.state_ = value;
		}
		public string GetPost_code(){
			return this.post_code_;
		}
		
		public void SetPost_code(string value){
			this.post_code_ = value;
		}
		public byte? GetMore_carrier(){
			return this.more_carrier_;
		}
		
		public void SetMore_carrier(byte? value){
			this.more_carrier_ = value;
		}
		public string GetCarrier_name(){
			return this.carrier_name_;
		}
		
		public void SetCarrier_name(string value){
			this.carrier_name_ = value;
		}
		public string GetDelivery(){
			return this.delivery_;
		}
		
		public void SetDelivery(string value){
			this.delivery_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public byte? GetIs_support_air_embargo(){
			return this.is_support_air_embargo_;
		}
		
		public void SetIs_support_air_embargo(byte? value){
			this.is_support_air_embargo_ = value;
		}
		public int? GetAddr_type(){
			return this.addr_type_;
		}
		
		public void SetAddr_type(int? value){
			this.addr_type_ = value;
		}
		public string GetArea_type(){
			return this.area_type_;
		}
		
		public void SetArea_type(string value){
			this.area_type_ = value;
		}
		
	}
	
}