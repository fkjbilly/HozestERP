using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.hts{
	
	
	public class HtGoodRecordServiceHelper {
		
		
		
		public class getRecordAttach_args {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.base.osp.service.record.GoodRecordAttachParam goodRecordAttachParam_;
			
			public com.vip.haitao.base.osp.service.record.GoodRecordAttachParam GetGoodRecordAttachParam(){
				return this.goodRecordAttachParam_;
			}
			
			public void SetGoodRecordAttachParam(com.vip.haitao.base.osp.service.record.GoodRecordAttachParam value){
				this.goodRecordAttachParam_ = value;
			}
			
		}
		
		
		
		
		public class getRecordGoodsList_args {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.base.osp.service.record.GoodRecordParam goodRecordParam_;
			
			public com.vip.haitao.base.osp.service.record.GoodRecordParam GetGoodRecordParam(){
				return this.goodRecordParam_;
			}
			
			public void SetGoodRecordParam(com.vip.haitao.base.osp.service.record.GoodRecordParam value){
				this.goodRecordParam_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class receiveBatchResult_args {
			
			///<summary>
			///</summary>
			
			private List<com.vip.haitao.base.osp.service.record.GoodResultParam> goodResultParamList_;
			
			public List<com.vip.haitao.base.osp.service.record.GoodResultParam> GetGoodResultParamList(){
				return this.goodResultParamList_;
			}
			
			public void SetGoodResultParamList(List<com.vip.haitao.base.osp.service.record.GoodResultParam> value){
				this.goodResultParamList_ = value;
			}
			
		}
		
		
		
		
		public class receiveRecordResult_args {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.base.osp.service.record.GoodResultParam goodResultParam_;
			
			public com.vip.haitao.base.osp.service.record.GoodResultParam GetGoodResultParam(){
				return this.goodResultParam_;
			}
			
			public void SetGoodResultParam(com.vip.haitao.base.osp.service.record.GoodResultParam value){
				this.goodResultParam_ = value;
			}
			
		}
		
		
		
		
		public class getRecordAttach_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.base.osp.service.record.VipGoodRecordAttachResponse success_;
			
			public com.vip.haitao.base.osp.service.record.VipGoodRecordAttachResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.base.osp.service.record.VipGoodRecordAttachResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getRecordGoodsList_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.base.osp.service.record.VipGoodRecordResponse success_;
			
			public com.vip.haitao.base.osp.service.record.VipGoodRecordResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.base.osp.service.record.VipGoodRecordResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_result {
			
			///<summary>
			///</summary>
			
			private com.vip.hermes.core.health.CheckResult success_;
			
			public com.vip.hermes.core.health.CheckResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.hermes.core.health.CheckResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class receiveBatchResult_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.base.osp.service.record.GoodRecordResponse success_;
			
			public com.vip.haitao.base.osp.service.record.GoodRecordResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.base.osp.service.record.GoodRecordResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class receiveRecordResult_result {
			
			///<summary>
			///</summary>
			
			private com.vip.haitao.base.osp.service.record.GoodRecordResponse success_;
			
			public com.vip.haitao.base.osp.service.record.GoodRecordResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.haitao.base.osp.service.record.GoodRecordResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class getRecordAttach_argsHelper : TBeanSerializer<getRecordAttach_args>
		{
			
			public static getRecordAttach_argsHelper OBJ = new getRecordAttach_argsHelper();
			
			public static getRecordAttach_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRecordAttach_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.base.osp.service.record.GoodRecordAttachParam value;
					
					value = new com.vip.haitao.base.osp.service.record.GoodRecordAttachParam();
					com.vip.haitao.base.osp.service.record.GoodRecordAttachParamHelper.getInstance().Read(value, iprot);
					
					structs.SetGoodRecordAttachParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRecordAttach_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetGoodRecordAttachParam() != null) {
					
					oprot.WriteFieldBegin("goodRecordAttachParam");
					
					com.vip.haitao.base.osp.service.record.GoodRecordAttachParamHelper.getInstance().Write(structs.GetGoodRecordAttachParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("goodRecordAttachParam can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRecordAttach_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getRecordGoodsList_argsHelper : TBeanSerializer<getRecordGoodsList_args>
		{
			
			public static getRecordGoodsList_argsHelper OBJ = new getRecordGoodsList_argsHelper();
			
			public static getRecordGoodsList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRecordGoodsList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.base.osp.service.record.GoodRecordParam value;
					
					value = new com.vip.haitao.base.osp.service.record.GoodRecordParam();
					com.vip.haitao.base.osp.service.record.GoodRecordParamHelper.getInstance().Read(value, iprot);
					
					structs.SetGoodRecordParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRecordGoodsList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetGoodRecordParam() != null) {
					
					oprot.WriteFieldBegin("goodRecordParam");
					
					com.vip.haitao.base.osp.service.record.GoodRecordParamHelper.getInstance().Write(structs.GetGoodRecordParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("goodRecordParam can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRecordGoodsList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_argsHelper : TBeanSerializer<healthCheck_args>
		{
			
			public static healthCheck_argsHelper OBJ = new healthCheck_argsHelper();
			
			public static healthCheck_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class receiveBatchResult_argsHelper : TBeanSerializer<receiveBatchResult_args>
		{
			
			public static receiveBatchResult_argsHelper OBJ = new receiveBatchResult_argsHelper();
			
			public static receiveBatchResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(receiveBatchResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.haitao.base.osp.service.record.GoodResultParam> value;
					
					value = new List<com.vip.haitao.base.osp.service.record.GoodResultParam>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.haitao.base.osp.service.record.GoodResultParam elem0;
							
							elem0 = new com.vip.haitao.base.osp.service.record.GoodResultParam();
							com.vip.haitao.base.osp.service.record.GoodResultParamHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetGoodResultParamList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(receiveBatchResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetGoodResultParamList() != null) {
					
					oprot.WriteFieldBegin("goodResultParamList");
					
					oprot.WriteListBegin();
					foreach(com.vip.haitao.base.osp.service.record.GoodResultParam _item0 in structs.GetGoodResultParamList()){
						
						
						com.vip.haitao.base.osp.service.record.GoodResultParamHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("goodResultParamList can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(receiveBatchResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class receiveRecordResult_argsHelper : TBeanSerializer<receiveRecordResult_args>
		{
			
			public static receiveRecordResult_argsHelper OBJ = new receiveRecordResult_argsHelper();
			
			public static receiveRecordResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(receiveRecordResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.base.osp.service.record.GoodResultParam value;
					
					value = new com.vip.haitao.base.osp.service.record.GoodResultParam();
					com.vip.haitao.base.osp.service.record.GoodResultParamHelper.getInstance().Read(value, iprot);
					
					structs.SetGoodResultParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(receiveRecordResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetGoodResultParam() != null) {
					
					oprot.WriteFieldBegin("goodResultParam");
					
					com.vip.haitao.base.osp.service.record.GoodResultParamHelper.getInstance().Write(structs.GetGoodResultParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("goodResultParam can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(receiveRecordResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getRecordAttach_resultHelper : TBeanSerializer<getRecordAttach_result>
		{
			
			public static getRecordAttach_resultHelper OBJ = new getRecordAttach_resultHelper();
			
			public static getRecordAttach_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRecordAttach_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.base.osp.service.record.VipGoodRecordAttachResponse value;
					
					value = new com.vip.haitao.base.osp.service.record.VipGoodRecordAttachResponse();
					com.vip.haitao.base.osp.service.record.VipGoodRecordAttachResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRecordAttach_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.base.osp.service.record.VipGoodRecordAttachResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRecordAttach_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getRecordGoodsList_resultHelper : TBeanSerializer<getRecordGoodsList_result>
		{
			
			public static getRecordGoodsList_resultHelper OBJ = new getRecordGoodsList_resultHelper();
			
			public static getRecordGoodsList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getRecordGoodsList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.base.osp.service.record.VipGoodRecordResponse value;
					
					value = new com.vip.haitao.base.osp.service.record.VipGoodRecordResponse();
					com.vip.haitao.base.osp.service.record.VipGoodRecordResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getRecordGoodsList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.base.osp.service.record.VipGoodRecordResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getRecordGoodsList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_resultHelper : TBeanSerializer<healthCheck_result>
		{
			
			public static healthCheck_resultHelper OBJ = new healthCheck_resultHelper();
			
			public static healthCheck_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(healthCheck_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.hermes.core.health.CheckResult value;
					
					value = new com.vip.hermes.core.health.CheckResult();
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(healthCheck_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.hermes.core.health.CheckResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(healthCheck_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class receiveBatchResult_resultHelper : TBeanSerializer<receiveBatchResult_result>
		{
			
			public static receiveBatchResult_resultHelper OBJ = new receiveBatchResult_resultHelper();
			
			public static receiveBatchResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(receiveBatchResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.base.osp.service.record.GoodRecordResponse value;
					
					value = new com.vip.haitao.base.osp.service.record.GoodRecordResponse();
					com.vip.haitao.base.osp.service.record.GoodRecordResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(receiveBatchResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.base.osp.service.record.GoodRecordResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(receiveBatchResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class receiveRecordResult_resultHelper : TBeanSerializer<receiveRecordResult_result>
		{
			
			public static receiveRecordResult_resultHelper OBJ = new receiveRecordResult_resultHelper();
			
			public static receiveRecordResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(receiveRecordResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.haitao.base.osp.service.record.GoodRecordResponse value;
					
					value = new com.vip.haitao.base.osp.service.record.GoodRecordResponse();
					com.vip.haitao.base.osp.service.record.GoodRecordResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(receiveRecordResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.haitao.base.osp.service.record.GoodRecordResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(receiveRecordResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class HtGoodRecordServiceClient : OspRestStub , HtGoodRecordService  {
			
			
			public HtGoodRecordServiceClient():base("vipapis.hts.HtGoodRecordService","1.0.0") {
				
				
			}
			
			
			
			public com.vip.haitao.base.osp.service.record.VipGoodRecordAttachResponse getRecordAttach(com.vip.haitao.base.osp.service.record.GoodRecordAttachParam goodRecordAttachParam_) {
				
				send_getRecordAttach(goodRecordAttachParam_);
				return recv_getRecordAttach(); 
				
			}
			
			
			private void send_getRecordAttach(com.vip.haitao.base.osp.service.record.GoodRecordAttachParam goodRecordAttachParam_){
				
				InitInvocation("getRecordAttach");
				
				getRecordAttach_args args = new getRecordAttach_args();
				args.SetGoodRecordAttachParam(goodRecordAttachParam_);
				
				SendBase(args, getRecordAttach_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.base.osp.service.record.VipGoodRecordAttachResponse recv_getRecordAttach(){
				
				getRecordAttach_result result = new getRecordAttach_result();
				ReceiveBase(result, getRecordAttach_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.haitao.base.osp.service.record.VipGoodRecordResponse getRecordGoodsList(com.vip.haitao.base.osp.service.record.GoodRecordParam goodRecordParam_) {
				
				send_getRecordGoodsList(goodRecordParam_);
				return recv_getRecordGoodsList(); 
				
			}
			
			
			private void send_getRecordGoodsList(com.vip.haitao.base.osp.service.record.GoodRecordParam goodRecordParam_){
				
				InitInvocation("getRecordGoodsList");
				
				getRecordGoodsList_args args = new getRecordGoodsList_args();
				args.SetGoodRecordParam(goodRecordParam_);
				
				SendBase(args, getRecordGoodsList_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.base.osp.service.record.VipGoodRecordResponse recv_getRecordGoodsList(){
				
				getRecordGoodsList_result result = new getRecordGoodsList_result();
				ReceiveBase(result, getRecordGoodsList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.hermes.core.health.CheckResult healthCheck() {
				
				send_healthCheck();
				return recv_healthCheck(); 
				
			}
			
			
			private void send_healthCheck(){
				
				InitInvocation("healthCheck");
				
				healthCheck_args args = new healthCheck_args();
				
				SendBase(args, healthCheck_argsHelper.getInstance());
			}
			
			
			private com.vip.hermes.core.health.CheckResult recv_healthCheck(){
				
				healthCheck_result result = new healthCheck_result();
				ReceiveBase(result, healthCheck_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.haitao.base.osp.service.record.GoodRecordResponse receiveBatchResult(List<com.vip.haitao.base.osp.service.record.GoodResultParam> goodResultParamList_) {
				
				send_receiveBatchResult(goodResultParamList_);
				return recv_receiveBatchResult(); 
				
			}
			
			
			private void send_receiveBatchResult(List<com.vip.haitao.base.osp.service.record.GoodResultParam> goodResultParamList_){
				
				InitInvocation("receiveBatchResult");
				
				receiveBatchResult_args args = new receiveBatchResult_args();
				args.SetGoodResultParamList(goodResultParamList_);
				
				SendBase(args, receiveBatchResult_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.base.osp.service.record.GoodRecordResponse recv_receiveBatchResult(){
				
				receiveBatchResult_result result = new receiveBatchResult_result();
				ReceiveBase(result, receiveBatchResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.haitao.base.osp.service.record.GoodRecordResponse receiveRecordResult(com.vip.haitao.base.osp.service.record.GoodResultParam goodResultParam_) {
				
				send_receiveRecordResult(goodResultParam_);
				return recv_receiveRecordResult(); 
				
			}
			
			
			private void send_receiveRecordResult(com.vip.haitao.base.osp.service.record.GoodResultParam goodResultParam_){
				
				InitInvocation("receiveRecordResult");
				
				receiveRecordResult_args args = new receiveRecordResult_args();
				args.SetGoodResultParam(goodResultParam_);
				
				SendBase(args, receiveRecordResult_argsHelper.getInstance());
			}
			
			
			private com.vip.haitao.base.osp.service.record.GoodRecordResponse recv_receiveRecordResult(){
				
				receiveRecordResult_result result = new receiveRecordResult_result();
				ReceiveBase(result, receiveRecordResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}