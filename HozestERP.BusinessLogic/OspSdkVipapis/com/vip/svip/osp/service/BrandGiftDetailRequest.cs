using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class BrandGiftDetailRequest {
		
		///<summary>
		/// userId
		///</summary>
		
		private long? userId_;
		
		///<summary>
		/// 站点
		///</summary>
		
		private string warehouse_;
		
		///<summary>
		/// 业务分组
		///</summary>
		
		private string bizType_;
		
		///<summary>
		/// id 列表
		///</summary>
		
		private List<com.vip.svip.osp.service.BrandGiftIdReqItem> idList_;
		
		public long? GetUserId(){
			return this.userId_;
		}
		
		public void SetUserId(long? value){
			this.userId_ = value;
		}
		public string GetWarehouse(){
			return this.warehouse_;
		}
		
		public void SetWarehouse(string value){
			this.warehouse_ = value;
		}
		public string GetBizType(){
			return this.bizType_;
		}
		
		public void SetBizType(string value){
			this.bizType_ = value;
		}
		public List<com.vip.svip.osp.service.BrandGiftIdReqItem> GetIdList(){
			return this.idList_;
		}
		
		public void SetIdList(List<com.vip.svip.osp.service.BrandGiftIdReqItem> value){
			this.idList_ = value;
		}
		
	}
	
}