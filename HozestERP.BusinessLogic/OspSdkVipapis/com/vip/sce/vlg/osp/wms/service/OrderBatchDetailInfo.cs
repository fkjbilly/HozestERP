using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OrderBatchDetailInfo {
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string oderSn_;
		
		///<summary>
		/// 箱条码/顺序号
		///</summary>
		
		private string seqNo_;
		
		public string GetOderSn(){
			return this.oderSn_;
		}
		
		public void SetOderSn(string value){
			this.oderSn_ = value;
		}
		public string GetSeqNo(){
			return this.seqNo_;
		}
		
		public void SetSeqNo(string value){
			this.seqNo_ = value;
		}
		
	}
	
}