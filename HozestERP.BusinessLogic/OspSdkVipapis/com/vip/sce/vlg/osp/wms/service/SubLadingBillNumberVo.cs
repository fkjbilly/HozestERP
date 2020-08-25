using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class SubLadingBillNumberVo {
		
		///<summary>
		/// 子提单号
		///</summary>
		
		private string subLadingBillNumber_;
		
		///<summary>
		/// 重量
		///</summary>
		
		private double? weight_;
		
		///<summary>
		/// 批次号列表
		///</summary>
		
		private List<com.vip.sce.vlg.osp.wms.service.BatchNoVo> batchNolist_;
		
		public string GetSubLadingBillNumber(){
			return this.subLadingBillNumber_;
		}
		
		public void SetSubLadingBillNumber(string value){
			this.subLadingBillNumber_ = value;
		}
		public double? GetWeight(){
			return this.weight_;
		}
		
		public void SetWeight(double? value){
			this.weight_ = value;
		}
		public List<com.vip.sce.vlg.osp.wms.service.BatchNoVo> GetBatchNolist(){
			return this.batchNolist_;
		}
		
		public void SetBatchNolist(List<com.vip.sce.vlg.osp.wms.service.BatchNoVo> value){
			this.batchNolist_ = value;
		}
		
	}
	
}