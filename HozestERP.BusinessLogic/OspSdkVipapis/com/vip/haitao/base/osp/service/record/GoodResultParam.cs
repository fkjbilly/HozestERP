using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.base.osp.service.record{
	
	
	
	
	
	public class GoodResultParam {
		
		///<summary>
		/// 备案结果
		///</summary>
		
		private com.vip.haitao.base.osp.service.record.GoodResultAfterRecord goodResultAfterRecord_;
		
		///<summary>
		/// 备案申请条码信息
		///</summary>
		
		private com.vip.haitao.base.osp.service.record.HtGoodRecordModel htGoodRecordModel_;
		
		public com.vip.haitao.base.osp.service.record.GoodResultAfterRecord GetGoodResultAfterRecord(){
			return this.goodResultAfterRecord_;
		}
		
		public void SetGoodResultAfterRecord(com.vip.haitao.base.osp.service.record.GoodResultAfterRecord value){
			this.goodResultAfterRecord_ = value;
		}
		public com.vip.haitao.base.osp.service.record.HtGoodRecordModel GetHtGoodRecordModel(){
			return this.htGoodRecordModel_;
		}
		
		public void SetHtGoodRecordModel(com.vip.haitao.base.osp.service.record.HtGoodRecordModel value){
			this.htGoodRecordModel_ = value;
		}
		
	}
	
}