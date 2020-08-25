using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	
	
	public class OutShipContainerResult {
		
		///<summary>
		/// 消息编号
		///</summary>
		
		private string MSG_ID_;
		
		///<summary>
		/// 箱号
		///</summary>
		
		private string TOTE_NBR_;
		
		///<summary>
		/// 包材编码
		///</summary>
		
		private string PACKING_CODE_;
		
		///<summary>
		/// 目标分拣站点
		///</summary>
		
		private string DEST_LOCN_;
		
		///<summary>
		/// 实际分拣站点
		///</summary>
		
		private string WCS_DEST_LOCN_;
		
		///<summary>
		/// 笼车编码
		///</summary>
		
		private string CAGE_CODE_;
		
		///<summary>
		/// 导入台
		///</summary>
		
		private string INDUCTION_;
		
		///<summary>
		/// 分拣机分拣时间(格式：yyyyMMddHHmmss)
		///</summary>
		
		private string ACTUAL_SORT_TIME_;
		
		///<summary>
		/// 包裹异常原因
		///</summary>
		
		private string FAIL_REASON_;
		
		///<summary>
		/// 包裹循环次数
		///</summary>
		
		private int? RECIRCCOUNT_;
		
		///<summary>
		/// 包裹体积
		///</summary>
		
		private string CUBE_;
		
		///<summary>
		/// 包裹重量
		///</summary>
		
		private string WEIGHT_;
		
		///<summary>
		/// TPS消息号
		///</summary>
		
		private string TPS_MSGID_;
		
		public string GetMSG_ID(){
			return this.MSG_ID_;
		}
		
		public void SetMSG_ID(string value){
			this.MSG_ID_ = value;
		}
		public string GetTOTE_NBR(){
			return this.TOTE_NBR_;
		}
		
		public void SetTOTE_NBR(string value){
			this.TOTE_NBR_ = value;
		}
		public string GetPACKING_CODE(){
			return this.PACKING_CODE_;
		}
		
		public void SetPACKING_CODE(string value){
			this.PACKING_CODE_ = value;
		}
		public string GetDEST_LOCN(){
			return this.DEST_LOCN_;
		}
		
		public void SetDEST_LOCN(string value){
			this.DEST_LOCN_ = value;
		}
		public string GetWCS_DEST_LOCN(){
			return this.WCS_DEST_LOCN_;
		}
		
		public void SetWCS_DEST_LOCN(string value){
			this.WCS_DEST_LOCN_ = value;
		}
		public string GetCAGE_CODE(){
			return this.CAGE_CODE_;
		}
		
		public void SetCAGE_CODE(string value){
			this.CAGE_CODE_ = value;
		}
		public string GetINDUCTION(){
			return this.INDUCTION_;
		}
		
		public void SetINDUCTION(string value){
			this.INDUCTION_ = value;
		}
		public string GetACTUAL_SORT_TIME(){
			return this.ACTUAL_SORT_TIME_;
		}
		
		public void SetACTUAL_SORT_TIME(string value){
			this.ACTUAL_SORT_TIME_ = value;
		}
		public string GetFAIL_REASON(){
			return this.FAIL_REASON_;
		}
		
		public void SetFAIL_REASON(string value){
			this.FAIL_REASON_ = value;
		}
		public int? GetRECIRCCOUNT(){
			return this.RECIRCCOUNT_;
		}
		
		public void SetRECIRCCOUNT(int? value){
			this.RECIRCCOUNT_ = value;
		}
		public string GetCUBE(){
			return this.CUBE_;
		}
		
		public void SetCUBE(string value){
			this.CUBE_ = value;
		}
		public string GetWEIGHT(){
			return this.WEIGHT_;
		}
		
		public void SetWEIGHT(string value){
			this.WEIGHT_ = value;
		}
		public string GetTPS_MSGID(){
			return this.TPS_MSGID_;
		}
		
		public void SetTPS_MSGID(string value){
			this.TPS_MSGID_ = value;
		}
		
	}
	
}