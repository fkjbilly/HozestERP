using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.svip.osp.service{
	
	
	
	
	
	public class TencentSvipGoodsInfo {
		
		///<summary>
		/// tencentCard
		///</summary>
		
		private List<com.vip.svip.osp.service.SvipGoodsInfo> tencentCard_;
		
		///<summary>
		/// svipCard
		///</summary>
		
		private List<com.vip.svip.osp.service.SvipGoodsInfo> svipCard_;
		
		///<summary>
		/// limitStatus
		///</summary>
		
		private int? limitStatus_;
		
		public List<com.vip.svip.osp.service.SvipGoodsInfo> GetTencentCard(){
			return this.tencentCard_;
		}
		
		public void SetTencentCard(List<com.vip.svip.osp.service.SvipGoodsInfo> value){
			this.tencentCard_ = value;
		}
		public List<com.vip.svip.osp.service.SvipGoodsInfo> GetSvipCard(){
			return this.svipCard_;
		}
		
		public void SetSvipCard(List<com.vip.svip.osp.service.SvipGoodsInfo> value){
			this.svipCard_ = value;
		}
		public int? GetLimitStatus(){
			return this.limitStatus_;
		}
		
		public void SetLimitStatus(int? value){
			this.limitStatus_ = value;
		}
		
	}
	
}