using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.fcs.vei.service{
	
	
	
	
	
	public class CanInvoicingReqModel4 {
		
		///<summary>
		/// 仓库编码（大仓，如：VIP_HZ,VIP_NH等）。多个编码时用分号（;）分隔，如：VIP_HZ;VIP_NH;VIP_BJ
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 收货省份
		///</summary>
		
		private string province_;
		
		///<summary>
		/// 收货市
		///</summary>
		
		private string city_;
		
		///<summary>
		/// 商品信息列表(不超过10个)
		///</summary>
		
		private List<com.vip.fcs.vei.service.GoodsInfoModel> goodsInfoList_;
		
		///<summary>
		/// 系统来源
		///</summary>
		
		private int? sourceSystem_;
		
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetProvince(){
			return this.province_;
		}
		
		public void SetProvince(string value){
			this.province_ = value;
		}
		public string GetCity(){
			return this.city_;
		}
		
		public void SetCity(string value){
			this.city_ = value;
		}
		public List<com.vip.fcs.vei.service.GoodsInfoModel> GetGoodsInfoList(){
			return this.goodsInfoList_;
		}
		
		public void SetGoodsInfoList(List<com.vip.fcs.vei.service.GoodsInfoModel> value){
			this.goodsInfoList_ = value;
		}
		public int? GetSourceSystem(){
			return this.sourceSystem_;
		}
		
		public void SetSourceSystem(int? value){
			this.sourceSystem_ = value;
		}
		
	}
	
}