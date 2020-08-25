using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutWmsZcodeInfo {
		
		///<summary>
		/// 下发批次编号
		///</summary>
		
		private string BATCH_NUM_;
		
		///<summary>
		/// 申请单号
		///</summary>
		
		private string APP_NUM_;
		
		///<summary>
		/// 数量（下发数量）
		///</summary>
		
		private int? AMOUNT_;
		
		///<summary>
		/// 入仓批次明细信息
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.OutWmsZcodeDatailInfo> detail_;
		
		public string GetBATCH_NUM(){
			return this.BATCH_NUM_;
		}
		
		public void SetBATCH_NUM(string value){
			this.BATCH_NUM_ = value;
		}
		public string GetAPP_NUM(){
			return this.APP_NUM_;
		}
		
		public void SetAPP_NUM(string value){
			this.APP_NUM_ = value;
		}
		public int? GetAMOUNT(){
			return this.AMOUNT_;
		}
		
		public void SetAMOUNT(int? value){
			this.AMOUNT_ = value;
		}
		public List<com.vip.sce.vlg.osp.wms.service.OutWmsZcodeDatailInfo> GetDetail(){
			return this.detail_;
		}
		
		public void SetDetail(List<com.vip.sce.vlg.osp.wms.service.OutWmsZcodeDatailInfo> value){
			this.detail_ = value;
		}
		
	}
	
}