using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.haitao.base.osp.service.record{
	
	
	
	
	
	public class VipGoodRecordHeader {
		
		///<summary>
		/// 备案类型(000:BC/BBC通用;001:BC;003:BBC)
		///</summary>
		
		private string recordType_;
		
		///<summary>
		/// 备案申请名称
		///</summary>
		
		private string recordName_;
		
		///<summary>
		/// 备案申请号
		///</summary>
		
		private string recordNo_;
		
		///<summary>
		/// 备案规则 1=条码 2=商品大类
		///</summary>
		
		private string recordRule_;
		
		///<summary>
		/// 修改标志：0-新增，1-修改，2-删除
		///</summary>
		
		private int? modifyFlag_;
		
		public string GetRecordType(){
			return this.recordType_;
		}
		
		public void SetRecordType(string value){
			this.recordType_ = value;
		}
		public string GetRecordName(){
			return this.recordName_;
		}
		
		public void SetRecordName(string value){
			this.recordName_ = value;
		}
		public string GetRecordNo(){
			return this.recordNo_;
		}
		
		public void SetRecordNo(string value){
			this.recordNo_ = value;
		}
		public string GetRecordRule(){
			return this.recordRule_;
		}
		
		public void SetRecordRule(string value){
			this.recordRule_ = value;
		}
		public int? GetModifyFlag(){
			return this.modifyFlag_;
		}
		
		public void SetModifyFlag(int? value){
			this.modifyFlag_ = value;
		}
		
	}
	
}