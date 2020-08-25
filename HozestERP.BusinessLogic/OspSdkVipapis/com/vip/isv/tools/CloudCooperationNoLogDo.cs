using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.isv.tools{
	
	
	
	
	
	public class CloudCooperationNoLogDo {
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 供应商名称
		///</summary>
		
		private string vendorName_;
		
		///<summary>
		/// 合作编码
		///</summary>
		
		private int? cooperationNo_;
		
		///<summary>
		/// 是否禁用:0正常,1禁用
		///</summary>
		
		private int? forbidden_;
		
		///<summary>
		/// 申请内容（0：申请内测:1：上线运营 2：大促下线: 3：上线后下线）
		///</summary>
		
		private int? applyContent_;
		
		///<summary>
		/// 生效模式（0：立即生效 1、定时生效）
		///</summary>
		
		private int? effectMode_;
		
		///<summary>
		/// 生效时间
		///</summary>
		
		private string effectTime_;
		
		///<summary>
		/// 失效时间
		///</summary>
		
		private string expireTime_;
		
		///<summary>
		/// 申请人
		///</summary>
		
		private string applyBy_;
		
		///<summary>
		/// 申请时间
		///</summary>
		
		private string applyTime_;
		
		///<summary>
		/// 实际审核人
		///</summary>
		
		private string checkBy_;
		
		///<summary>
		/// 审核时间
		///</summary>
		
		private string checkTime_;
		
		///<summary>
		/// 创建时间
		///</summary>
		
		private System.DateTime? createTime_;
		
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public string GetVendorName(){
			return this.vendorName_;
		}
		
		public void SetVendorName(string value){
			this.vendorName_ = value;
		}
		public int? GetCooperationNo(){
			return this.cooperationNo_;
		}
		
		public void SetCooperationNo(int? value){
			this.cooperationNo_ = value;
		}
		public int? GetForbidden(){
			return this.forbidden_;
		}
		
		public void SetForbidden(int? value){
			this.forbidden_ = value;
		}
		public int? GetApplyContent(){
			return this.applyContent_;
		}
		
		public void SetApplyContent(int? value){
			this.applyContent_ = value;
		}
		public int? GetEffectMode(){
			return this.effectMode_;
		}
		
		public void SetEffectMode(int? value){
			this.effectMode_ = value;
		}
		public string GetEffectTime(){
			return this.effectTime_;
		}
		
		public void SetEffectTime(string value){
			this.effectTime_ = value;
		}
		public string GetExpireTime(){
			return this.expireTime_;
		}
		
		public void SetExpireTime(string value){
			this.expireTime_ = value;
		}
		public string GetApplyBy(){
			return this.applyBy_;
		}
		
		public void SetApplyBy(string value){
			this.applyBy_ = value;
		}
		public string GetApplyTime(){
			return this.applyTime_;
		}
		
		public void SetApplyTime(string value){
			this.applyTime_ = value;
		}
		public string GetCheckBy(){
			return this.checkBy_;
		}
		
		public void SetCheckBy(string value){
			this.checkBy_ = value;
		}
		public string GetCheckTime(){
			return this.checkTime_;
		}
		
		public void SetCheckTime(string value){
			this.checkTime_ = value;
		}
		public System.DateTime? GetCreateTime(){
			return this.createTime_;
		}
		
		public void SetCreateTime(System.DateTime? value){
			this.createTime_ = value;
		}
		
	}
	
}