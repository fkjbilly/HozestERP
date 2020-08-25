using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.base.osp.service.record{
	
	
	
	
	
	public class VipGoodRecordResult {
		
		///<summary>
		/// 备案信息头部
		///</summary>
		
		private com.vip.haitao.base.osp.service.record.VipGoodRecordHeader header_;
		
		///<summary>
		/// 备案条码列表
		///</summary>
		
		private List<com.vip.haitao.base.osp.service.record.VipGoodRecordModel> dataList_;
		
		public com.vip.haitao.base.osp.service.record.VipGoodRecordHeader GetHeader(){
			return this.header_;
		}
		
		public void SetHeader(com.vip.haitao.base.osp.service.record.VipGoodRecordHeader value){
			this.header_ = value;
		}
		public List<com.vip.haitao.base.osp.service.record.VipGoodRecordModel> GetDataList(){
			return this.dataList_;
		}
		
		public void SetDataList(List<com.vip.haitao.base.osp.service.record.VipGoodRecordModel> value){
			this.dataList_ = value;
		}
		
	}
	
}