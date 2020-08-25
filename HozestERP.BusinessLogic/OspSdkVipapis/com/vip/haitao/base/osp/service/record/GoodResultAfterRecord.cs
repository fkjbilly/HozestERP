using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.base.osp.service.record{
	
	
	
	
	
	public class GoodResultAfterRecord {
		
		///<summary>
		/// 报关行编码
		///</summary>
		
		private string carrierCode_;
		
		///<summary>
		/// 关口编码
		///</summary>
		
		private string customsCode_;
		
		///<summary>
		/// 备案类型
		///</summary>
		
		private string recordType_;
		
		///<summary>
		/// 商品条形码
		///</summary>
		
		private string goodSn_;
		
		///<summary>
		/// 备案申请号
		///</summary>
		
		private string recordNo_;
		
		///<summary>
		/// 备案结果类型：1-接收成功，2-接收失败，3-审核通过，4-审核不通过，5-海关成功，6-海关失败，7-国检成功，8-国检失败，9-备案完成，10-备案失败
		///</summary>
		
		private int? resultType_;
		
		///<summary>
		/// 状态产生时间
		///</summary>
		
		private long? statusTime_;
		
		///<summary>
		/// 海关备案号
		///</summary>
		
		private string cusRecordNo_;
		
		///<summary>
		/// 国检备案号
		///</summary>
		
		private string ciqRecordNo_;
		
		///<summary>
		/// 行邮税号
		///</summary>
		
		private string parcelTaxNo_;
		
		///<summary>
		/// HS编码
		///</summary>
		
		private string goodHsCode_;
		
		///<summary>
		/// 申报要素
		///</summary>
		
		private string element_;
		
		///<summary>
		/// 法定第一计量单位
		///</summary>
		
		private string legalUnitFirst_;
		
		///<summary>
		/// 法定第二计量单位
		///</summary>
		
		private string legalUnitSecond_;
		
		///<summary>
		/// 法定第一数量
		///</summary>
		
		private string legalAmountFirst_;
		
		///<summary>
		/// 法定第二数量
		///</summary>
		
		private string legalAmountSecond_;
		
		///<summary>
		/// 审核意见
		///</summary>
		
		private string statusNote_;
		
		///<summary>
		/// 天津用途
		///</summary>
		
		private string tjEffect_;
		
		public string GetCarrierCode(){
			return this.carrierCode_;
		}
		
		public void SetCarrierCode(string value){
			this.carrierCode_ = value;
		}
		public string GetCustomsCode(){
			return this.customsCode_;
		}
		
		public void SetCustomsCode(string value){
			this.customsCode_ = value;
		}
		public string GetRecordType(){
			return this.recordType_;
		}
		
		public void SetRecordType(string value){
			this.recordType_ = value;
		}
		public string GetGoodSn(){
			return this.goodSn_;
		}
		
		public void SetGoodSn(string value){
			this.goodSn_ = value;
		}
		public string GetRecordNo(){
			return this.recordNo_;
		}
		
		public void SetRecordNo(string value){
			this.recordNo_ = value;
		}
		public int? GetResultType(){
			return this.resultType_;
		}
		
		public void SetResultType(int? value){
			this.resultType_ = value;
		}
		public long? GetStatusTime(){
			return this.statusTime_;
		}
		
		public void SetStatusTime(long? value){
			this.statusTime_ = value;
		}
		public string GetCusRecordNo(){
			return this.cusRecordNo_;
		}
		
		public void SetCusRecordNo(string value){
			this.cusRecordNo_ = value;
		}
		public string GetCiqRecordNo(){
			return this.ciqRecordNo_;
		}
		
		public void SetCiqRecordNo(string value){
			this.ciqRecordNo_ = value;
		}
		public string GetParcelTaxNo(){
			return this.parcelTaxNo_;
		}
		
		public void SetParcelTaxNo(string value){
			this.parcelTaxNo_ = value;
		}
		public string GetGoodHsCode(){
			return this.goodHsCode_;
		}
		
		public void SetGoodHsCode(string value){
			this.goodHsCode_ = value;
		}
		public string GetElement(){
			return this.element_;
		}
		
		public void SetElement(string value){
			this.element_ = value;
		}
		public string GetLegalUnitFirst(){
			return this.legalUnitFirst_;
		}
		
		public void SetLegalUnitFirst(string value){
			this.legalUnitFirst_ = value;
		}
		public string GetLegalUnitSecond(){
			return this.legalUnitSecond_;
		}
		
		public void SetLegalUnitSecond(string value){
			this.legalUnitSecond_ = value;
		}
		public string GetLegalAmountFirst(){
			return this.legalAmountFirst_;
		}
		
		public void SetLegalAmountFirst(string value){
			this.legalAmountFirst_ = value;
		}
		public string GetLegalAmountSecond(){
			return this.legalAmountSecond_;
		}
		
		public void SetLegalAmountSecond(string value){
			this.legalAmountSecond_ = value;
		}
		public string GetStatusNote(){
			return this.statusNote_;
		}
		
		public void SetStatusNote(string value){
			this.statusNote_ = value;
		}
		public string GetTjEffect(){
			return this.tjEffect_;
		}
		
		public void SetTjEffect(string value){
			this.tjEffect_ = value;
		}
		
	}
	
}