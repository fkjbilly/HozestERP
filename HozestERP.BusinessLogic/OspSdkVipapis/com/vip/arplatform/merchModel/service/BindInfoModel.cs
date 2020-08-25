using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.arplatform.merchModel.service{
	
	
	
	
	
	public class BindInfoModel {
		
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
		/// sku
		///</summary>
		
		private long? sku_;
		
		///<summary>
		/// spu
		///</summary>
		
		private long? spu_;
		
		///<summary>
		/// barcode
		///</summary>
		
		private string barcode_;
		
		///<summary>
		/// material id
		///</summary>
		
		private long? materialId_;
		
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
		public long? GetSku(){
			return this.sku_;
		}
		
		public void SetSku(long? value){
			this.sku_ = value;
		}
		public long? GetSpu(){
			return this.spu_;
		}
		
		public void SetSpu(long? value){
			this.spu_ = value;
		}
		public string GetBarcode(){
			return this.barcode_;
		}
		
		public void SetBarcode(string value){
			this.barcode_ = value;
		}
		public long? GetMaterialId(){
			return this.materialId_;
		}
		
		public void SetMaterialId(long? value){
			this.materialId_ = value;
		}
		
	}
	
}