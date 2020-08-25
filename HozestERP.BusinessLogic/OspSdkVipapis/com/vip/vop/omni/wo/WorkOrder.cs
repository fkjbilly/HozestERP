using System;
using System.Collections.Generic;
using System.Text;

namespace com.vip.vop.omni.wo{
	
	
	
	
	
	public class WorkOrder {
		
		///<summary>
		/// 1表示同步工单主表，2表示同步步骤变化
		///</summary>
		
		private int? syncType_;
		
		///<summary>
		/// 工单号
		///</summary>
		
		private string woNo_;
		
		///<summary>
		/// 供应商id
		///</summary>
		
		private int? vendorId_;
		
		///<summary>
		/// 受理时间
		///</summary>
		
		private long? acceptTime_;
		
		///<summary>
		/// 工单状态（工单主表同步时工单状态：0处理中 、1结案、2放弃）
		///</summary>
		
		private byte? state_;
		
		///<summary>
		/// 工单一级分类名
		///</summary>
		
		private string pc1Name_;
		
		///<summary>
		/// 工单二级分类名
		///</summary>
		
		private string pc2Name_;
		
		///<summary>
		/// 工单三级分类名
		///</summary>
		
		private string pc3Name_;
		
		///<summary>
		/// 问题描述
		///</summary>
		
		private string problemDesc_;
		
		///<summary>
		/// 当前步骤状态（工单步骤同步时状态：-2普通备注，-1加急标示,0.新工单,1.处理中,2.已回复 3.一审核不通过，4.二审不通过，5.介入不通过，6.需复核回复，7.复核回复不通过,8.结案，9.放弃,10已下发，11接管）
		///</summary>
		
		private byte? currentStepState_;
		
		///<summary>
		/// 订单号
		///</summary>
		
		private string sdNo_;
		
		///<summary>
		/// 工单期望结束时间
		///</summary>
		
		private long? expectEndTime_;
		
		///<summary>
		/// 操作类型（finish:结案;abandon:放弃;delivery:下送;takeover:接管;remark:备注;callremark:来电备注;recheck:跟进复核;attachment:附件）
		///</summary>
		
		private string messageType_;
		
		///<summary>
		/// 表扬投诉标识（0-表扬，1-投诉）
		///</summary>
		
		private string expEvaluation_;
		
		///<summary>
		/// ID
		///</summary>
		
		private long? id_;
		
		public int? GetSyncType(){
			return this.syncType_;
		}
		
		public void SetSyncType(int? value){
			this.syncType_ = value;
		}
		public string GetWoNo(){
			return this.woNo_;
		}
		
		public void SetWoNo(string value){
			this.woNo_ = value;
		}
		public int? GetVendorId(){
			return this.vendorId_;
		}
		
		public void SetVendorId(int? value){
			this.vendorId_ = value;
		}
		public long? GetAcceptTime(){
			return this.acceptTime_;
		}
		
		public void SetAcceptTime(long? value){
			this.acceptTime_ = value;
		}
		public byte? GetState(){
			return this.state_;
		}
		
		public void SetState(byte? value){
			this.state_ = value;
		}
		public string GetPc1Name(){
			return this.pc1Name_;
		}
		
		public void SetPc1Name(string value){
			this.pc1Name_ = value;
		}
		public string GetPc2Name(){
			return this.pc2Name_;
		}
		
		public void SetPc2Name(string value){
			this.pc2Name_ = value;
		}
		public string GetPc3Name(){
			return this.pc3Name_;
		}
		
		public void SetPc3Name(string value){
			this.pc3Name_ = value;
		}
		public string GetProblemDesc(){
			return this.problemDesc_;
		}
		
		public void SetProblemDesc(string value){
			this.problemDesc_ = value;
		}
		public byte? GetCurrentStepState(){
			return this.currentStepState_;
		}
		
		public void SetCurrentStepState(byte? value){
			this.currentStepState_ = value;
		}
		public string GetSdNo(){
			return this.sdNo_;
		}
		
		public void SetSdNo(string value){
			this.sdNo_ = value;
		}
		public long? GetExpectEndTime(){
			return this.expectEndTime_;
		}
		
		public void SetExpectEndTime(long? value){
			this.expectEndTime_ = value;
		}
		public string GetMessageType(){
			return this.messageType_;
		}
		
		public void SetMessageType(string value){
			this.messageType_ = value;
		}
		public string GetExpEvaluation(){
			return this.expEvaluation_;
		}
		
		public void SetExpEvaluation(string value){
			this.expEvaluation_ = value;
		}
		public long? GetId(){
			return this.id_;
		}
		
		public void SetId(long? value){
			this.id_ = value;
		}
		
	}
	
}