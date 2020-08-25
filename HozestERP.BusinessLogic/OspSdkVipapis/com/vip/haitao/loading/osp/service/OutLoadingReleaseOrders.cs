using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.loading.osp.service{
	
	
	
	
	
	public class OutLoadingReleaseOrders {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string orderSn_;
		
		///<summary>
		/// 箱号
		///</summary>
		
		private string boxId_;
		
		///<summary>
		/// 总箱数
		///</summary>
		
		private int? boxNum_;
		
		///<summary>
		/// 打包时间
		///</summary>
		
		private string oqcDate_;
		
		///<summary>
		/// 高度
		///</summary>
		
		private double? height_;
		
		///<summary>
		/// 体积
		///</summary>
		
		private double? volume_;
		
		///<summary>
		/// 重量
		///</summary>
		
		private double? weight_;
		
		///<summary>
		/// 宽度
		///</summary>
		
		private double? width_;
		
		///<summary>
		/// 重量单位
		///</summary>
		
		private string weightUm_;
		
		///<summary>
		/// 长度
		///</summary>
		
		private double? length_;
		
		///<summary>
		/// 尺寸单位
		///</summary>
		
		private string dimensioUm_;
		
		///<summary>
		/// 体积单位
		///</summary>
		
		private string volumeUm_;
		
		///<summary>
		/// 打包人员id
		///</summary>
		
		private string userCode_;
		
		///<summary>
		/// 打包人员姓名
		///</summary>
		
		private string userName_;
		
		///<summary>
		/// 核放订单商品详情
		///</summary>
		
		private List<com.vip.haitao.loading.osp.service.OutLoadingReleaseOrderDetail> orderDetails_;
		
		public string GetOrderSn(){
			return this.orderSn_;
		}
		
		public void SetOrderSn(string value){
			this.orderSn_ = value;
		}
		public string GetBoxId(){
			return this.boxId_;
		}
		
		public void SetBoxId(string value){
			this.boxId_ = value;
		}
		public int? GetBoxNum(){
			return this.boxNum_;
		}
		
		public void SetBoxNum(int? value){
			this.boxNum_ = value;
		}
		public string GetOqcDate(){
			return this.oqcDate_;
		}
		
		public void SetOqcDate(string value){
			this.oqcDate_ = value;
		}
		public double? GetHeight(){
			return this.height_;
		}
		
		public void SetHeight(double? value){
			this.height_ = value;
		}
		public double? GetVolume(){
			return this.volume_;
		}
		
		public void SetVolume(double? value){
			this.volume_ = value;
		}
		public double? GetWeight(){
			return this.weight_;
		}
		
		public void SetWeight(double? value){
			this.weight_ = value;
		}
		public double? GetWidth(){
			return this.width_;
		}
		
		public void SetWidth(double? value){
			this.width_ = value;
		}
		public string GetWeightUm(){
			return this.weightUm_;
		}
		
		public void SetWeightUm(string value){
			this.weightUm_ = value;
		}
		public double? GetLength(){
			return this.length_;
		}
		
		public void SetLength(double? value){
			this.length_ = value;
		}
		public string GetDimensioUm(){
			return this.dimensioUm_;
		}
		
		public void SetDimensioUm(string value){
			this.dimensioUm_ = value;
		}
		public string GetVolumeUm(){
			return this.volumeUm_;
		}
		
		public void SetVolumeUm(string value){
			this.volumeUm_ = value;
		}
		public string GetUserCode(){
			return this.userCode_;
		}
		
		public void SetUserCode(string value){
			this.userCode_ = value;
		}
		public string GetUserName(){
			return this.userName_;
		}
		
		public void SetUserName(string value){
			this.userName_ = value;
		}
		public List<com.vip.haitao.loading.osp.service.OutLoadingReleaseOrderDetail> GetOrderDetails(){
			return this.orderDetails_;
		}
		
		public void SetOrderDetails(List<com.vip.haitao.loading.osp.service.OutLoadingReleaseOrderDetail> value){
			this.orderDetails_ = value;
		}
		
	}
	
}