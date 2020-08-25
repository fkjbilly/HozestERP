using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.merchModel.service{
	
	
	
	
	
	public class MaterialModel {
		
		///<summary>
		/// 主键id
		///</summary>
		
		private long? id_;
		
		///<summary>
		/// 是否删除
		///</summary>
		
		private byte? isDeleted_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private System.DateTime? createTime_;
		
		///<summary>
		/// 更新时间
		///</summary>
		
		private System.DateTime? updateTime_;
		
		///<summary>
		/// serviceType, 参见EnumServiceType
		///</summary>
		
		private int? serviceType_;
		
		///<summary>
		/// 模型ID
		///</summary>
		
		private string mid_;
		
		///<summary>
		/// category
		///</summary>
		
		private string category_;
		
		///<summary>
		/// barcode
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// osn
		///</summary>
		
		private string osn_;
		
		///<summary>
		/// brand_name
		///</summary>
		
		private string brandName_;
		
		///<summary>
		/// title
		///</summary>
		
		private string title_;
		
		///<summary>
		/// color
		///</summary>
		
		private string color_;
		
		///<summary>
		/// size
		///</summary>
		
		private int? size_;
		
		///<summary>
		/// 模型来源，JD / vendor
		///</summary>
		
		private string _from_;
		
		///<summary>
		/// 模型信息， JD: {'url': xxx, 'cost': xxx}
		///</summary>
		
		private string jsonModelInfo_;
		
		///<summary>
		/// 启用状态, 1=启用,0=关闭
		///</summary>
		
		private byte? status_;
		
		///<summary>
		/// 使用计数
		///</summary>
		
		private byte? counter_;
		
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		public byte? GetIsDeleted(){
			return this.isDeleted_;
		}
		
		public void SetIsDeleted(byte? value){
			this.isDeleted_ = value;
		}
		public System.DateTime? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(System.DateTime? value){
			this.createTime_ = value;
		}
		public System.DateTime? GetUpdateTime(){
			return this.updateTime_;
		}
		
		public void SetUpdateTime(System.DateTime? value){
			this.updateTime_ = value;
		}
		public int? GetServiceType(){
			return this.serviceType_;
		}
		
		public void SetServiceType(int? value){
			this.serviceType_ = value;
		}
		public string GetMid(){
			return this.mid_;
		}
		
		public void SetMid(string value){
			this.mid_ = value;
		}
		public string GetCategory(){
			return this.category_;
		}
		
		public void SetCategory(string value){
			this.category_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public string GetOsn(){
			return this.osn_;
		}
		
		public void SetOsn(string value){
			this.osn_ = value;
		}
		public string GetBrandName(){
			return this.brandName_;
		}
		
		public void SetBrandName(string value){
			this.brandName_ = value;
		}
		public string GetTitle(){
			return this.title_;
		}
		
		public void SetTitle(string value){
			this.title_ = value;
		}
		public string GetColor(){
			return this.color_;
		}
		
		public void SetColor(string value){
			this.color_ = value;
		}
		public int? GetSize(){
			return this.size_;
		}
		
		public void SetSize(int? value){
			this.size_ = value;
		}
		public string Get_from(){
			return this._from_;
		}
		
		public void Set_from(string value){
			this._from_ = value;
		}
		public string GetJsonModelInfo(){
			return this.jsonModelInfo_;
		}
		
		public void SetJsonModelInfo(string value){
			this.jsonModelInfo_ = value;
		}
		public byte? GetStatus(){
			return this.status_;
		}
		
		public void SetStatus(byte? value){
			this.status_ = value;
		}
		public byte? GetCounter(){
			return this.counter_;
		}
		
		public void SetCounter(byte? value){
			this.counter_ = value;
		}
		
	}
	
}