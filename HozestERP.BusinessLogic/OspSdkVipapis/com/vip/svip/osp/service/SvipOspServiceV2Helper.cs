using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.svip.osp.service{
	
	
	public class SvipOspServiceV2Helper {
		
		
		
		public class bindTxUserAccount_args {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.BindTxAccRequest request_;
			
			public com.vip.svip.osp.service.BindTxAccRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.svip.osp.service.BindTxAccRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class brandGiftDetailList_args {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.BrandGiftDetailRequest request_;
			
			public com.vip.svip.osp.service.BrandGiftDetailRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.svip.osp.service.BrandGiftDetailRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class checkTxAccLimit_args {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.CheckTxAccLimitRequest request_;
			
			public com.vip.svip.osp.service.CheckTxAccLimitRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.svip.osp.service.CheckTxAccLimitRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getBindAccountInfo_args {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.GetBindAccountRequest request_;
			
			public com.vip.svip.osp.service.GetBindAccountRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.svip.osp.service.GetBindAccountRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getBrandGiftIdList_args {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.BrandGiftRequest request_;
			
			public com.vip.svip.osp.service.BrandGiftRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.svip.osp.service.BrandGiftRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getBuyLimitResult_args {
			
			///<summary>
			/// 请求头
			///</summary>
			
			private com.vip.svip.osp.service.BuyLimitRequestHeader header_;
			
			///<summary>
			/// 请求参数
			///</summary>
			
			private com.vip.svip.osp.service.BuyLimitRequestParam param_;
			
			public com.vip.svip.osp.service.BuyLimitRequestHeader GetHeader(){
				return this.header_;
			}
			
			public void SetHeader(com.vip.svip.osp.service.BuyLimitRequestHeader value){
				this.header_ = value;
			}
			public com.vip.svip.osp.service.BuyLimitRequestParam GetParam(){
				return this.param_;
			}
			
			public void SetParam(com.vip.svip.osp.service.BuyLimitRequestParam value){
				this.param_ = value;
			}
			
		}
		
		
		
		
		public class getSvipMainInfo_args {
			
			///<summary>
			/// 请求头
			///</summary>
			
			private com.vip.svip.osp.service.BaseRequestHeader header_;
			
			public com.vip.svip.osp.service.BaseRequestHeader GetHeader(){
				return this.header_;
			}
			
			public void SetHeader(com.vip.svip.osp.service.BaseRequestHeader value){
				this.header_ = value;
			}
			
		}
		
		
		
		
		public class getTencentVipSvipCardInfo_args {
			
			///<summary>
			///</summary>
			
			private long? userId_;
			
			public long? GetUserId(){
				return this.userId_;
			}
			
			public void SetUserId(long? value){
				this.userId_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class isSvipBuyLimit_args {
			
			///<summary>
			/// 请求头
			///</summary>
			
			private com.vip.svip.osp.service.BuyLimitRequestHeader header_;
			
			///<summary>
			/// 请求参数
			///</summary>
			
			private com.vip.svip.osp.service.BuyLimitRequestParam param_;
			
			public com.vip.svip.osp.service.BuyLimitRequestHeader GetHeader(){
				return this.header_;
			}
			
			public void SetHeader(com.vip.svip.osp.service.BuyLimitRequestHeader value){
				this.header_ = value;
			}
			public com.vip.svip.osp.service.BuyLimitRequestParam GetParam(){
				return this.param_;
			}
			
			public void SetParam(com.vip.svip.osp.service.BuyLimitRequestParam value){
				this.param_ = value;
			}
			
		}
		
		
		
		
		public class isSvipLimitUser_args {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.BuyLimitStateRequest request_;
			
			public com.vip.svip.osp.service.BuyLimitStateRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.svip.osp.service.BuyLimitStateRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class joinSvipForTencentVideoSide_args {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.DoubleSvipRequest request_;
			
			public com.vip.svip.osp.service.DoubleSvipRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.svip.osp.service.DoubleSvipRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class joinTencentVideoMemberAtVipSide_args {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.DoubleSvipRequest request_;
			
			public com.vip.svip.osp.service.DoubleSvipRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.svip.osp.service.DoubleSvipRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class openLimitCheck_args {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.OpenLimitRequest request_;
			
			public com.vip.svip.osp.service.OpenLimitRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.svip.osp.service.OpenLimitRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class prepareDoubleSvipAccess_args {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.DoubleSvipRequest request_;
			
			public com.vip.svip.osp.service.DoubleSvipRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.svip.osp.service.DoubleSvipRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class rejoinTencentMember_args {
			
			///<summary>
			/// 补发流水号
			///</summary>
			
			private string serial_;
			
			///<summary>
			/// 补发操作人员
			///</summary>
			
			private string admin_;
			
			public string GetSerial(){
				return this.serial_;
			}
			
			public void SetSerial(string value){
				this.serial_ = value;
			}
			public string GetAdmin(){
				return this.admin_;
			}
			
			public void SetAdmin(string value){
				this.admin_ = value;
			}
			
		}
		
		
		
		
		public class specialMemberTrySvip_args {
			
			///<summary>
			/// 请求头
			///</summary>
			
			private com.vip.svip.osp.service.SimpleRequestHeader header_;
			
			public com.vip.svip.osp.service.SimpleRequestHeader GetHeader(){
				return this.header_;
			}
			
			public void SetHeader(com.vip.svip.osp.service.SimpleRequestHeader value){
				this.header_ = value;
			}
			
		}
		
		
		
		
		public class txGetSvipToken_args {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.TxGetTokenRequest request_;
			
			public com.vip.svip.osp.service.TxGetTokenRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.svip.osp.service.TxGetTokenRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class txOpenSvip_args {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.TxOpenSvipRequest request_;
			
			public com.vip.svip.osp.service.TxOpenSvipRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.svip.osp.service.TxOpenSvipRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class bindTxUserAccount_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.BaseResult success_;
			
			public com.vip.svip.osp.service.BaseResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.BaseResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class brandGiftDetailList_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.svip.osp.service.BrandGiftItem> success_;
			
			public List<com.vip.svip.osp.service.BrandGiftItem> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.svip.osp.service.BrandGiftItem> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class checkTxAccLimit_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.BaseResult success_;
			
			public com.vip.svip.osp.service.BaseResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.BaseResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getBindAccountInfo_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.AccountInfoResult success_;
			
			public com.vip.svip.osp.service.AccountInfoResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.AccountInfoResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getBrandGiftIdList_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.BrandGiftIdResult success_;
			
			public com.vip.svip.osp.service.BrandGiftIdResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.BrandGiftIdResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getBuyLimitResult_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.BuyLimitResult success_;
			
			public com.vip.svip.osp.service.BuyLimitResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.BuyLimitResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSvipMainInfo_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.KTBaseInfoResult success_;
			
			public com.vip.svip.osp.service.KTBaseInfoResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.KTBaseInfoResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getTencentVipSvipCardInfo_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.TencentSvipGoodsInfo success_;
			
			public com.vip.svip.osp.service.TencentSvipGoodsInfo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.TencentSvipGoodsInfo value){
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
		
		
		
		
		public class isSvipBuyLimit_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.svip.osp.service.BuyLimitResult success_;
			
			public com.vip.svip.osp.service.BuyLimitResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.BuyLimitResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class isSvipLimitUser_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.BuyLimitState success_;
			
			public com.vip.svip.osp.service.BuyLimitState GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.BuyLimitState value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class joinSvipForTencentVideoSide_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.DoubleSvipCreateResponse success_;
			
			public com.vip.svip.osp.service.DoubleSvipCreateResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.DoubleSvipCreateResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class joinTencentVideoMemberAtVipSide_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.BaseResult success_;
			
			public com.vip.svip.osp.service.BaseResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.BaseResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class openLimitCheck_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.BuyLimitResult success_;
			
			public com.vip.svip.osp.service.BuyLimitResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.BuyLimitResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class prepareDoubleSvipAccess_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.DoubleSvipStatus success_;
			
			public com.vip.svip.osp.service.DoubleSvipStatus GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.DoubleSvipStatus value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class rejoinTencentMember_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.BaseResult success_;
			
			public com.vip.svip.osp.service.BaseResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.BaseResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class specialMemberTrySvip_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.BaseResult success_;
			
			public com.vip.svip.osp.service.BaseResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.BaseResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class txGetSvipToken_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.TxGetSvipTokenResult success_;
			
			public com.vip.svip.osp.service.TxGetSvipTokenResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.TxGetSvipTokenResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class txOpenSvip_result {
			
			///<summary>
			///</summary>
			
			private com.vip.svip.osp.service.DoubleSvipCreateResponse success_;
			
			public com.vip.svip.osp.service.DoubleSvipCreateResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.svip.osp.service.DoubleSvipCreateResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class bindTxUserAccount_argsHelper : TBeanSerializer<bindTxUserAccount_args>
		{
			
			public static bindTxUserAccount_argsHelper OBJ = new bindTxUserAccount_argsHelper();
			
			public static bindTxUserAccount_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(bindTxUserAccount_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BindTxAccRequest value;
					
					value = new com.vip.svip.osp.service.BindTxAccRequest();
					com.vip.svip.osp.service.BindTxAccRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(bindTxUserAccount_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.svip.osp.service.BindTxAccRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(bindTxUserAccount_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class brandGiftDetailList_argsHelper : TBeanSerializer<brandGiftDetailList_args>
		{
			
			public static brandGiftDetailList_argsHelper OBJ = new brandGiftDetailList_argsHelper();
			
			public static brandGiftDetailList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(brandGiftDetailList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BrandGiftDetailRequest value;
					
					value = new com.vip.svip.osp.service.BrandGiftDetailRequest();
					com.vip.svip.osp.service.BrandGiftDetailRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(brandGiftDetailList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.svip.osp.service.BrandGiftDetailRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(brandGiftDetailList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class checkTxAccLimit_argsHelper : TBeanSerializer<checkTxAccLimit_args>
		{
			
			public static checkTxAccLimit_argsHelper OBJ = new checkTxAccLimit_argsHelper();
			
			public static checkTxAccLimit_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(checkTxAccLimit_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.CheckTxAccLimitRequest value;
					
					value = new com.vip.svip.osp.service.CheckTxAccLimitRequest();
					com.vip.svip.osp.service.CheckTxAccLimitRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(checkTxAccLimit_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.svip.osp.service.CheckTxAccLimitRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(checkTxAccLimit_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getBindAccountInfo_argsHelper : TBeanSerializer<getBindAccountInfo_args>
		{
			
			public static getBindAccountInfo_argsHelper OBJ = new getBindAccountInfo_argsHelper();
			
			public static getBindAccountInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getBindAccountInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.GetBindAccountRequest value;
					
					value = new com.vip.svip.osp.service.GetBindAccountRequest();
					com.vip.svip.osp.service.GetBindAccountRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getBindAccountInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.svip.osp.service.GetBindAccountRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getBindAccountInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getBrandGiftIdList_argsHelper : TBeanSerializer<getBrandGiftIdList_args>
		{
			
			public static getBrandGiftIdList_argsHelper OBJ = new getBrandGiftIdList_argsHelper();
			
			public static getBrandGiftIdList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getBrandGiftIdList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BrandGiftRequest value;
					
					value = new com.vip.svip.osp.service.BrandGiftRequest();
					com.vip.svip.osp.service.BrandGiftRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getBrandGiftIdList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.svip.osp.service.BrandGiftRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getBrandGiftIdList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getBuyLimitResult_argsHelper : TBeanSerializer<getBuyLimitResult_args>
		{
			
			public static getBuyLimitResult_argsHelper OBJ = new getBuyLimitResult_argsHelper();
			
			public static getBuyLimitResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getBuyLimitResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BuyLimitRequestHeader value;
					
					value = new com.vip.svip.osp.service.BuyLimitRequestHeader();
					com.vip.svip.osp.service.BuyLimitRequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BuyLimitRequestParam value;
					
					value = new com.vip.svip.osp.service.BuyLimitRequestParam();
					com.vip.svip.osp.service.BuyLimitRequestParamHelper.getInstance().Read(value, iprot);
					
					structs.SetParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getBuyLimitResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetHeader() != null) {
					
					oprot.WriteFieldBegin("header");
					
					com.vip.svip.osp.service.BuyLimitRequestHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("header can not be null!");
				}
				
				
				if(structs.GetParam() != null) {
					
					oprot.WriteFieldBegin("param");
					
					com.vip.svip.osp.service.BuyLimitRequestParamHelper.getInstance().Write(structs.GetParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("param can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getBuyLimitResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSvipMainInfo_argsHelper : TBeanSerializer<getSvipMainInfo_args>
		{
			
			public static getSvipMainInfo_argsHelper OBJ = new getSvipMainInfo_argsHelper();
			
			public static getSvipMainInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSvipMainInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BaseRequestHeader value;
					
					value = new com.vip.svip.osp.service.BaseRequestHeader();
					com.vip.svip.osp.service.BaseRequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetHeader(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSvipMainInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetHeader() != null) {
					
					oprot.WriteFieldBegin("header");
					
					com.vip.svip.osp.service.BaseRequestHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("header can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSvipMainInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getTencentVipSvipCardInfo_argsHelper : TBeanSerializer<getTencentVipSvipCardInfo_args>
		{
			
			public static getTencentVipSvipCardInfo_argsHelper OBJ = new getTencentVipSvipCardInfo_argsHelper();
			
			public static getTencentVipSvipCardInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getTencentVipSvipCardInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetUserId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getTencentVipSvipCardInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetUserId() != null) {
					
					oprot.WriteFieldBegin("userId");
					oprot.WriteI64((long)structs.GetUserId()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getTencentVipSvipCardInfo_args bean){
				
				
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
		
		
		
		
		public class isSvipBuyLimit_argsHelper : TBeanSerializer<isSvipBuyLimit_args>
		{
			
			public static isSvipBuyLimit_argsHelper OBJ = new isSvipBuyLimit_argsHelper();
			
			public static isSvipBuyLimit_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(isSvipBuyLimit_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BuyLimitRequestHeader value;
					
					value = new com.vip.svip.osp.service.BuyLimitRequestHeader();
					com.vip.svip.osp.service.BuyLimitRequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetHeader(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BuyLimitRequestParam value;
					
					value = new com.vip.svip.osp.service.BuyLimitRequestParam();
					com.vip.svip.osp.service.BuyLimitRequestParamHelper.getInstance().Read(value, iprot);
					
					structs.SetParam(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(isSvipBuyLimit_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetHeader() != null) {
					
					oprot.WriteFieldBegin("header");
					
					com.vip.svip.osp.service.BuyLimitRequestHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("header can not be null!");
				}
				
				
				if(structs.GetParam() != null) {
					
					oprot.WriteFieldBegin("param");
					
					com.vip.svip.osp.service.BuyLimitRequestParamHelper.getInstance().Write(structs.GetParam(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("param can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(isSvipBuyLimit_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class isSvipLimitUser_argsHelper : TBeanSerializer<isSvipLimitUser_args>
		{
			
			public static isSvipLimitUser_argsHelper OBJ = new isSvipLimitUser_argsHelper();
			
			public static isSvipLimitUser_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(isSvipLimitUser_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BuyLimitStateRequest value;
					
					value = new com.vip.svip.osp.service.BuyLimitStateRequest();
					com.vip.svip.osp.service.BuyLimitStateRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(isSvipLimitUser_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.svip.osp.service.BuyLimitStateRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(isSvipLimitUser_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class joinSvipForTencentVideoSide_argsHelper : TBeanSerializer<joinSvipForTencentVideoSide_args>
		{
			
			public static joinSvipForTencentVideoSide_argsHelper OBJ = new joinSvipForTencentVideoSide_argsHelper();
			
			public static joinSvipForTencentVideoSide_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(joinSvipForTencentVideoSide_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.DoubleSvipRequest value;
					
					value = new com.vip.svip.osp.service.DoubleSvipRequest();
					com.vip.svip.osp.service.DoubleSvipRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(joinSvipForTencentVideoSide_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.svip.osp.service.DoubleSvipRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(joinSvipForTencentVideoSide_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class joinTencentVideoMemberAtVipSide_argsHelper : TBeanSerializer<joinTencentVideoMemberAtVipSide_args>
		{
			
			public static joinTencentVideoMemberAtVipSide_argsHelper OBJ = new joinTencentVideoMemberAtVipSide_argsHelper();
			
			public static joinTencentVideoMemberAtVipSide_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(joinTencentVideoMemberAtVipSide_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.DoubleSvipRequest value;
					
					value = new com.vip.svip.osp.service.DoubleSvipRequest();
					com.vip.svip.osp.service.DoubleSvipRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(joinTencentVideoMemberAtVipSide_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.svip.osp.service.DoubleSvipRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(joinTencentVideoMemberAtVipSide_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class openLimitCheck_argsHelper : TBeanSerializer<openLimitCheck_args>
		{
			
			public static openLimitCheck_argsHelper OBJ = new openLimitCheck_argsHelper();
			
			public static openLimitCheck_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(openLimitCheck_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.OpenLimitRequest value;
					
					value = new com.vip.svip.osp.service.OpenLimitRequest();
					com.vip.svip.osp.service.OpenLimitRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(openLimitCheck_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.svip.osp.service.OpenLimitRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(openLimitCheck_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class prepareDoubleSvipAccess_argsHelper : TBeanSerializer<prepareDoubleSvipAccess_args>
		{
			
			public static prepareDoubleSvipAccess_argsHelper OBJ = new prepareDoubleSvipAccess_argsHelper();
			
			public static prepareDoubleSvipAccess_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(prepareDoubleSvipAccess_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.DoubleSvipRequest value;
					
					value = new com.vip.svip.osp.service.DoubleSvipRequest();
					com.vip.svip.osp.service.DoubleSvipRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(prepareDoubleSvipAccess_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.svip.osp.service.DoubleSvipRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(prepareDoubleSvipAccess_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class rejoinTencentMember_argsHelper : TBeanSerializer<rejoinTencentMember_args>
		{
			
			public static rejoinTencentMember_argsHelper OBJ = new rejoinTencentMember_argsHelper();
			
			public static rejoinTencentMember_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(rejoinTencentMember_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSerial(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetAdmin(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(rejoinTencentMember_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSerial() != null) {
					
					oprot.WriteFieldBegin("serial");
					oprot.WriteString(structs.GetSerial());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("serial can not be null!");
				}
				
				
				if(structs.GetAdmin() != null) {
					
					oprot.WriteFieldBegin("admin");
					oprot.WriteString(structs.GetAdmin());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("admin can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(rejoinTencentMember_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class specialMemberTrySvip_argsHelper : TBeanSerializer<specialMemberTrySvip_args>
		{
			
			public static specialMemberTrySvip_argsHelper OBJ = new specialMemberTrySvip_argsHelper();
			
			public static specialMemberTrySvip_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(specialMemberTrySvip_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.SimpleRequestHeader value;
					
					value = new com.vip.svip.osp.service.SimpleRequestHeader();
					com.vip.svip.osp.service.SimpleRequestHeaderHelper.getInstance().Read(value, iprot);
					
					structs.SetHeader(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(specialMemberTrySvip_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetHeader() != null) {
					
					oprot.WriteFieldBegin("header");
					
					com.vip.svip.osp.service.SimpleRequestHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("header can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(specialMemberTrySvip_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class txGetSvipToken_argsHelper : TBeanSerializer<txGetSvipToken_args>
		{
			
			public static txGetSvipToken_argsHelper OBJ = new txGetSvipToken_argsHelper();
			
			public static txGetSvipToken_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(txGetSvipToken_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.TxGetTokenRequest value;
					
					value = new com.vip.svip.osp.service.TxGetTokenRequest();
					com.vip.svip.osp.service.TxGetTokenRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(txGetSvipToken_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.svip.osp.service.TxGetTokenRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(txGetSvipToken_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class txOpenSvip_argsHelper : TBeanSerializer<txOpenSvip_args>
		{
			
			public static txOpenSvip_argsHelper OBJ = new txOpenSvip_argsHelper();
			
			public static txOpenSvip_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(txOpenSvip_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.TxOpenSvipRequest value;
					
					value = new com.vip.svip.osp.service.TxOpenSvipRequest();
					com.vip.svip.osp.service.TxOpenSvipRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(txOpenSvip_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.svip.osp.service.TxOpenSvipRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(txOpenSvip_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class bindTxUserAccount_resultHelper : TBeanSerializer<bindTxUserAccount_result>
		{
			
			public static bindTxUserAccount_resultHelper OBJ = new bindTxUserAccount_resultHelper();
			
			public static bindTxUserAccount_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(bindTxUserAccount_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BaseResult value;
					
					value = new com.vip.svip.osp.service.BaseResult();
					com.vip.svip.osp.service.BaseResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(bindTxUserAccount_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.BaseResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(bindTxUserAccount_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class brandGiftDetailList_resultHelper : TBeanSerializer<brandGiftDetailList_result>
		{
			
			public static brandGiftDetailList_resultHelper OBJ = new brandGiftDetailList_resultHelper();
			
			public static brandGiftDetailList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(brandGiftDetailList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.svip.osp.service.BrandGiftItem> value;
					
					value = new List<com.vip.svip.osp.service.BrandGiftItem>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.svip.osp.service.BrandGiftItem elem0;
							
							elem0 = new com.vip.svip.osp.service.BrandGiftItem();
							com.vip.svip.osp.service.BrandGiftItemHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(brandGiftDetailList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.svip.osp.service.BrandGiftItem _item0 in structs.GetSuccess()){
						
						
						com.vip.svip.osp.service.BrandGiftItemHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(brandGiftDetailList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class checkTxAccLimit_resultHelper : TBeanSerializer<checkTxAccLimit_result>
		{
			
			public static checkTxAccLimit_resultHelper OBJ = new checkTxAccLimit_resultHelper();
			
			public static checkTxAccLimit_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(checkTxAccLimit_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BaseResult value;
					
					value = new com.vip.svip.osp.service.BaseResult();
					com.vip.svip.osp.service.BaseResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(checkTxAccLimit_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.BaseResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(checkTxAccLimit_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getBindAccountInfo_resultHelper : TBeanSerializer<getBindAccountInfo_result>
		{
			
			public static getBindAccountInfo_resultHelper OBJ = new getBindAccountInfo_resultHelper();
			
			public static getBindAccountInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getBindAccountInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.AccountInfoResult value;
					
					value = new com.vip.svip.osp.service.AccountInfoResult();
					com.vip.svip.osp.service.AccountInfoResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getBindAccountInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.AccountInfoResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getBindAccountInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getBrandGiftIdList_resultHelper : TBeanSerializer<getBrandGiftIdList_result>
		{
			
			public static getBrandGiftIdList_resultHelper OBJ = new getBrandGiftIdList_resultHelper();
			
			public static getBrandGiftIdList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getBrandGiftIdList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BrandGiftIdResult value;
					
					value = new com.vip.svip.osp.service.BrandGiftIdResult();
					com.vip.svip.osp.service.BrandGiftIdResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getBrandGiftIdList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.BrandGiftIdResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getBrandGiftIdList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getBuyLimitResult_resultHelper : TBeanSerializer<getBuyLimitResult_result>
		{
			
			public static getBuyLimitResult_resultHelper OBJ = new getBuyLimitResult_resultHelper();
			
			public static getBuyLimitResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getBuyLimitResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BuyLimitResult value;
					
					value = new com.vip.svip.osp.service.BuyLimitResult();
					com.vip.svip.osp.service.BuyLimitResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getBuyLimitResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.BuyLimitResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getBuyLimitResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSvipMainInfo_resultHelper : TBeanSerializer<getSvipMainInfo_result>
		{
			
			public static getSvipMainInfo_resultHelper OBJ = new getSvipMainInfo_resultHelper();
			
			public static getSvipMainInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSvipMainInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.KTBaseInfoResult value;
					
					value = new com.vip.svip.osp.service.KTBaseInfoResult();
					com.vip.svip.osp.service.KTBaseInfoResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSvipMainInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.KTBaseInfoResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSvipMainInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getTencentVipSvipCardInfo_resultHelper : TBeanSerializer<getTencentVipSvipCardInfo_result>
		{
			
			public static getTencentVipSvipCardInfo_resultHelper OBJ = new getTencentVipSvipCardInfo_resultHelper();
			
			public static getTencentVipSvipCardInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getTencentVipSvipCardInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.TencentSvipGoodsInfo value;
					
					value = new com.vip.svip.osp.service.TencentSvipGoodsInfo();
					com.vip.svip.osp.service.TencentSvipGoodsInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getTencentVipSvipCardInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.TencentSvipGoodsInfoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getTencentVipSvipCardInfo_result bean){
				
				
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
		
		
		
		
		public class isSvipBuyLimit_resultHelper : TBeanSerializer<isSvipBuyLimit_result>
		{
			
			public static isSvipBuyLimit_resultHelper OBJ = new isSvipBuyLimit_resultHelper();
			
			public static isSvipBuyLimit_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(isSvipBuyLimit_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BuyLimitResult value;
					
					value = new com.vip.svip.osp.service.BuyLimitResult();
					com.vip.svip.osp.service.BuyLimitResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(isSvipBuyLimit_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.BuyLimitResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(isSvipBuyLimit_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class isSvipLimitUser_resultHelper : TBeanSerializer<isSvipLimitUser_result>
		{
			
			public static isSvipLimitUser_resultHelper OBJ = new isSvipLimitUser_resultHelper();
			
			public static isSvipLimitUser_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(isSvipLimitUser_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BuyLimitState value;
					
					value = new com.vip.svip.osp.service.BuyLimitState();
					com.vip.svip.osp.service.BuyLimitStateHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(isSvipLimitUser_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.BuyLimitStateHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(isSvipLimitUser_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class joinSvipForTencentVideoSide_resultHelper : TBeanSerializer<joinSvipForTencentVideoSide_result>
		{
			
			public static joinSvipForTencentVideoSide_resultHelper OBJ = new joinSvipForTencentVideoSide_resultHelper();
			
			public static joinSvipForTencentVideoSide_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(joinSvipForTencentVideoSide_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.DoubleSvipCreateResponse value;
					
					value = new com.vip.svip.osp.service.DoubleSvipCreateResponse();
					com.vip.svip.osp.service.DoubleSvipCreateResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(joinSvipForTencentVideoSide_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.DoubleSvipCreateResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(joinSvipForTencentVideoSide_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class joinTencentVideoMemberAtVipSide_resultHelper : TBeanSerializer<joinTencentVideoMemberAtVipSide_result>
		{
			
			public static joinTencentVideoMemberAtVipSide_resultHelper OBJ = new joinTencentVideoMemberAtVipSide_resultHelper();
			
			public static joinTencentVideoMemberAtVipSide_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(joinTencentVideoMemberAtVipSide_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BaseResult value;
					
					value = new com.vip.svip.osp.service.BaseResult();
					com.vip.svip.osp.service.BaseResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(joinTencentVideoMemberAtVipSide_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.BaseResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(joinTencentVideoMemberAtVipSide_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class openLimitCheck_resultHelper : TBeanSerializer<openLimitCheck_result>
		{
			
			public static openLimitCheck_resultHelper OBJ = new openLimitCheck_resultHelper();
			
			public static openLimitCheck_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(openLimitCheck_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BuyLimitResult value;
					
					value = new com.vip.svip.osp.service.BuyLimitResult();
					com.vip.svip.osp.service.BuyLimitResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(openLimitCheck_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.BuyLimitResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(openLimitCheck_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class prepareDoubleSvipAccess_resultHelper : TBeanSerializer<prepareDoubleSvipAccess_result>
		{
			
			public static prepareDoubleSvipAccess_resultHelper OBJ = new prepareDoubleSvipAccess_resultHelper();
			
			public static prepareDoubleSvipAccess_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(prepareDoubleSvipAccess_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.DoubleSvipStatus value;
					
					value = new com.vip.svip.osp.service.DoubleSvipStatus();
					com.vip.svip.osp.service.DoubleSvipStatusHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(prepareDoubleSvipAccess_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.DoubleSvipStatusHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(prepareDoubleSvipAccess_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class rejoinTencentMember_resultHelper : TBeanSerializer<rejoinTencentMember_result>
		{
			
			public static rejoinTencentMember_resultHelper OBJ = new rejoinTencentMember_resultHelper();
			
			public static rejoinTencentMember_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(rejoinTencentMember_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BaseResult value;
					
					value = new com.vip.svip.osp.service.BaseResult();
					com.vip.svip.osp.service.BaseResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(rejoinTencentMember_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.BaseResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(rejoinTencentMember_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class specialMemberTrySvip_resultHelper : TBeanSerializer<specialMemberTrySvip_result>
		{
			
			public static specialMemberTrySvip_resultHelper OBJ = new specialMemberTrySvip_resultHelper();
			
			public static specialMemberTrySvip_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(specialMemberTrySvip_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.BaseResult value;
					
					value = new com.vip.svip.osp.service.BaseResult();
					com.vip.svip.osp.service.BaseResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(specialMemberTrySvip_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.BaseResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(specialMemberTrySvip_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class txGetSvipToken_resultHelper : TBeanSerializer<txGetSvipToken_result>
		{
			
			public static txGetSvipToken_resultHelper OBJ = new txGetSvipToken_resultHelper();
			
			public static txGetSvipToken_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(txGetSvipToken_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.TxGetSvipTokenResult value;
					
					value = new com.vip.svip.osp.service.TxGetSvipTokenResult();
					com.vip.svip.osp.service.TxGetSvipTokenResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(txGetSvipToken_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.TxGetSvipTokenResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(txGetSvipToken_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class txOpenSvip_resultHelper : TBeanSerializer<txOpenSvip_result>
		{
			
			public static txOpenSvip_resultHelper OBJ = new txOpenSvip_resultHelper();
			
			public static txOpenSvip_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(txOpenSvip_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.svip.osp.service.DoubleSvipCreateResponse value;
					
					value = new com.vip.svip.osp.service.DoubleSvipCreateResponse();
					com.vip.svip.osp.service.DoubleSvipCreateResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(txOpenSvip_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.svip.osp.service.DoubleSvipCreateResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(txOpenSvip_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class SvipOspServiceV2Client : OspRestStub , SvipOspServiceV2  {
			
			
			public SvipOspServiceV2Client():base("com.vip.svip.osp.service.SvipOspServiceV2","1.0.0") {
				
				
			}
			
			
			
			public com.vip.svip.osp.service.BaseResult bindTxUserAccount(com.vip.svip.osp.service.BindTxAccRequest request_) {
				
				send_bindTxUserAccount(request_);
				return recv_bindTxUserAccount(); 
				
			}
			
			
			private void send_bindTxUserAccount(com.vip.svip.osp.service.BindTxAccRequest request_){
				
				InitInvocation("bindTxUserAccount");
				
				bindTxUserAccount_args args = new bindTxUserAccount_args();
				args.SetRequest(request_);
				
				SendBase(args, bindTxUserAccount_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.BaseResult recv_bindTxUserAccount(){
				
				bindTxUserAccount_result result = new bindTxUserAccount_result();
				ReceiveBase(result, bindTxUserAccount_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.svip.osp.service.BrandGiftItem> brandGiftDetailList(com.vip.svip.osp.service.BrandGiftDetailRequest request_) {
				
				send_brandGiftDetailList(request_);
				return recv_brandGiftDetailList(); 
				
			}
			
			
			private void send_brandGiftDetailList(com.vip.svip.osp.service.BrandGiftDetailRequest request_){
				
				InitInvocation("brandGiftDetailList");
				
				brandGiftDetailList_args args = new brandGiftDetailList_args();
				args.SetRequest(request_);
				
				SendBase(args, brandGiftDetailList_argsHelper.getInstance());
			}
			
			
			private List<com.vip.svip.osp.service.BrandGiftItem> recv_brandGiftDetailList(){
				
				brandGiftDetailList_result result = new brandGiftDetailList_result();
				ReceiveBase(result, brandGiftDetailList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.svip.osp.service.BaseResult checkTxAccLimit(com.vip.svip.osp.service.CheckTxAccLimitRequest request_) {
				
				send_checkTxAccLimit(request_);
				return recv_checkTxAccLimit(); 
				
			}
			
			
			private void send_checkTxAccLimit(com.vip.svip.osp.service.CheckTxAccLimitRequest request_){
				
				InitInvocation("checkTxAccLimit");
				
				checkTxAccLimit_args args = new checkTxAccLimit_args();
				args.SetRequest(request_);
				
				SendBase(args, checkTxAccLimit_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.BaseResult recv_checkTxAccLimit(){
				
				checkTxAccLimit_result result = new checkTxAccLimit_result();
				ReceiveBase(result, checkTxAccLimit_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.svip.osp.service.AccountInfoResult getBindAccountInfo(com.vip.svip.osp.service.GetBindAccountRequest request_) {
				
				send_getBindAccountInfo(request_);
				return recv_getBindAccountInfo(); 
				
			}
			
			
			private void send_getBindAccountInfo(com.vip.svip.osp.service.GetBindAccountRequest request_){
				
				InitInvocation("getBindAccountInfo");
				
				getBindAccountInfo_args args = new getBindAccountInfo_args();
				args.SetRequest(request_);
				
				SendBase(args, getBindAccountInfo_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.AccountInfoResult recv_getBindAccountInfo(){
				
				getBindAccountInfo_result result = new getBindAccountInfo_result();
				ReceiveBase(result, getBindAccountInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.svip.osp.service.BrandGiftIdResult getBrandGiftIdList(com.vip.svip.osp.service.BrandGiftRequest request_) {
				
				send_getBrandGiftIdList(request_);
				return recv_getBrandGiftIdList(); 
				
			}
			
			
			private void send_getBrandGiftIdList(com.vip.svip.osp.service.BrandGiftRequest request_){
				
				InitInvocation("getBrandGiftIdList");
				
				getBrandGiftIdList_args args = new getBrandGiftIdList_args();
				args.SetRequest(request_);
				
				SendBase(args, getBrandGiftIdList_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.BrandGiftIdResult recv_getBrandGiftIdList(){
				
				getBrandGiftIdList_result result = new getBrandGiftIdList_result();
				ReceiveBase(result, getBrandGiftIdList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.svip.osp.service.BuyLimitResult getBuyLimitResult(com.vip.svip.osp.service.BuyLimitRequestHeader header_,com.vip.svip.osp.service.BuyLimitRequestParam param_) {
				
				send_getBuyLimitResult(header_,param_);
				return recv_getBuyLimitResult(); 
				
			}
			
			
			private void send_getBuyLimitResult(com.vip.svip.osp.service.BuyLimitRequestHeader header_,com.vip.svip.osp.service.BuyLimitRequestParam param_){
				
				InitInvocation("getBuyLimitResult");
				
				getBuyLimitResult_args args = new getBuyLimitResult_args();
				args.SetHeader(header_);
				args.SetParam(param_);
				
				SendBase(args, getBuyLimitResult_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.BuyLimitResult recv_getBuyLimitResult(){
				
				getBuyLimitResult_result result = new getBuyLimitResult_result();
				ReceiveBase(result, getBuyLimitResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.svip.osp.service.KTBaseInfoResult getSvipMainInfo(com.vip.svip.osp.service.BaseRequestHeader header_) {
				
				send_getSvipMainInfo(header_);
				return recv_getSvipMainInfo(); 
				
			}
			
			
			private void send_getSvipMainInfo(com.vip.svip.osp.service.BaseRequestHeader header_){
				
				InitInvocation("getSvipMainInfo");
				
				getSvipMainInfo_args args = new getSvipMainInfo_args();
				args.SetHeader(header_);
				
				SendBase(args, getSvipMainInfo_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.KTBaseInfoResult recv_getSvipMainInfo(){
				
				getSvipMainInfo_result result = new getSvipMainInfo_result();
				ReceiveBase(result, getSvipMainInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.svip.osp.service.TencentSvipGoodsInfo getTencentVipSvipCardInfo(long? userId_) {
				
				send_getTencentVipSvipCardInfo(userId_);
				return recv_getTencentVipSvipCardInfo(); 
				
			}
			
			
			private void send_getTencentVipSvipCardInfo(long? userId_){
				
				InitInvocation("getTencentVipSvipCardInfo");
				
				getTencentVipSvipCardInfo_args args = new getTencentVipSvipCardInfo_args();
				args.SetUserId(userId_);
				
				SendBase(args, getTencentVipSvipCardInfo_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.TencentSvipGoodsInfo recv_getTencentVipSvipCardInfo(){
				
				getTencentVipSvipCardInfo_result result = new getTencentVipSvipCardInfo_result();
				ReceiveBase(result, getTencentVipSvipCardInfo_resultHelper.getInstance());
				
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
			
			
			public com.vip.svip.osp.service.BuyLimitResult isSvipBuyLimit(com.vip.svip.osp.service.BuyLimitRequestHeader header_,com.vip.svip.osp.service.BuyLimitRequestParam param_) {
				
				send_isSvipBuyLimit(header_,param_);
				return recv_isSvipBuyLimit(); 
				
			}
			
			
			private void send_isSvipBuyLimit(com.vip.svip.osp.service.BuyLimitRequestHeader header_,com.vip.svip.osp.service.BuyLimitRequestParam param_){
				
				InitInvocation("isSvipBuyLimit");
				
				isSvipBuyLimit_args args = new isSvipBuyLimit_args();
				args.SetHeader(header_);
				args.SetParam(param_);
				
				SendBase(args, isSvipBuyLimit_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.BuyLimitResult recv_isSvipBuyLimit(){
				
				isSvipBuyLimit_result result = new isSvipBuyLimit_result();
				ReceiveBase(result, isSvipBuyLimit_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.svip.osp.service.BuyLimitState isSvipLimitUser(com.vip.svip.osp.service.BuyLimitStateRequest request_) {
				
				send_isSvipLimitUser(request_);
				return recv_isSvipLimitUser(); 
				
			}
			
			
			private void send_isSvipLimitUser(com.vip.svip.osp.service.BuyLimitStateRequest request_){
				
				InitInvocation("isSvipLimitUser");
				
				isSvipLimitUser_args args = new isSvipLimitUser_args();
				args.SetRequest(request_);
				
				SendBase(args, isSvipLimitUser_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.BuyLimitState recv_isSvipLimitUser(){
				
				isSvipLimitUser_result result = new isSvipLimitUser_result();
				ReceiveBase(result, isSvipLimitUser_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.svip.osp.service.DoubleSvipCreateResponse joinSvipForTencentVideoSide(com.vip.svip.osp.service.DoubleSvipRequest request_) {
				
				send_joinSvipForTencentVideoSide(request_);
				return recv_joinSvipForTencentVideoSide(); 
				
			}
			
			
			private void send_joinSvipForTencentVideoSide(com.vip.svip.osp.service.DoubleSvipRequest request_){
				
				InitInvocation("joinSvipForTencentVideoSide");
				
				joinSvipForTencentVideoSide_args args = new joinSvipForTencentVideoSide_args();
				args.SetRequest(request_);
				
				SendBase(args, joinSvipForTencentVideoSide_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.DoubleSvipCreateResponse recv_joinSvipForTencentVideoSide(){
				
				joinSvipForTencentVideoSide_result result = new joinSvipForTencentVideoSide_result();
				ReceiveBase(result, joinSvipForTencentVideoSide_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.svip.osp.service.BaseResult joinTencentVideoMemberAtVipSide(com.vip.svip.osp.service.DoubleSvipRequest request_) {
				
				send_joinTencentVideoMemberAtVipSide(request_);
				return recv_joinTencentVideoMemberAtVipSide(); 
				
			}
			
			
			private void send_joinTencentVideoMemberAtVipSide(com.vip.svip.osp.service.DoubleSvipRequest request_){
				
				InitInvocation("joinTencentVideoMemberAtVipSide");
				
				joinTencentVideoMemberAtVipSide_args args = new joinTencentVideoMemberAtVipSide_args();
				args.SetRequest(request_);
				
				SendBase(args, joinTencentVideoMemberAtVipSide_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.BaseResult recv_joinTencentVideoMemberAtVipSide(){
				
				joinTencentVideoMemberAtVipSide_result result = new joinTencentVideoMemberAtVipSide_result();
				ReceiveBase(result, joinTencentVideoMemberAtVipSide_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.svip.osp.service.BuyLimitResult openLimitCheck(com.vip.svip.osp.service.OpenLimitRequest request_) {
				
				send_openLimitCheck(request_);
				return recv_openLimitCheck(); 
				
			}
			
			
			private void send_openLimitCheck(com.vip.svip.osp.service.OpenLimitRequest request_){
				
				InitInvocation("openLimitCheck");
				
				openLimitCheck_args args = new openLimitCheck_args();
				args.SetRequest(request_);
				
				SendBase(args, openLimitCheck_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.BuyLimitResult recv_openLimitCheck(){
				
				openLimitCheck_result result = new openLimitCheck_result();
				ReceiveBase(result, openLimitCheck_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.svip.osp.service.DoubleSvipStatus prepareDoubleSvipAccess(com.vip.svip.osp.service.DoubleSvipRequest request_) {
				
				send_prepareDoubleSvipAccess(request_);
				return recv_prepareDoubleSvipAccess(); 
				
			}
			
			
			private void send_prepareDoubleSvipAccess(com.vip.svip.osp.service.DoubleSvipRequest request_){
				
				InitInvocation("prepareDoubleSvipAccess");
				
				prepareDoubleSvipAccess_args args = new prepareDoubleSvipAccess_args();
				args.SetRequest(request_);
				
				SendBase(args, prepareDoubleSvipAccess_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.DoubleSvipStatus recv_prepareDoubleSvipAccess(){
				
				prepareDoubleSvipAccess_result result = new prepareDoubleSvipAccess_result();
				ReceiveBase(result, prepareDoubleSvipAccess_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.svip.osp.service.BaseResult rejoinTencentMember(string serial_,string admin_) {
				
				send_rejoinTencentMember(serial_,admin_);
				return recv_rejoinTencentMember(); 
				
			}
			
			
			private void send_rejoinTencentMember(string serial_,string admin_){
				
				InitInvocation("rejoinTencentMember");
				
				rejoinTencentMember_args args = new rejoinTencentMember_args();
				args.SetSerial(serial_);
				args.SetAdmin(admin_);
				
				SendBase(args, rejoinTencentMember_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.BaseResult recv_rejoinTencentMember(){
				
				rejoinTencentMember_result result = new rejoinTencentMember_result();
				ReceiveBase(result, rejoinTencentMember_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.svip.osp.service.BaseResult specialMemberTrySvip(com.vip.svip.osp.service.SimpleRequestHeader header_) {
				
				send_specialMemberTrySvip(header_);
				return recv_specialMemberTrySvip(); 
				
			}
			
			
			private void send_specialMemberTrySvip(com.vip.svip.osp.service.SimpleRequestHeader header_){
				
				InitInvocation("specialMemberTrySvip");
				
				specialMemberTrySvip_args args = new specialMemberTrySvip_args();
				args.SetHeader(header_);
				
				SendBase(args, specialMemberTrySvip_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.BaseResult recv_specialMemberTrySvip(){
				
				specialMemberTrySvip_result result = new specialMemberTrySvip_result();
				ReceiveBase(result, specialMemberTrySvip_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.svip.osp.service.TxGetSvipTokenResult txGetSvipToken(com.vip.svip.osp.service.TxGetTokenRequest request_) {
				
				send_txGetSvipToken(request_);
				return recv_txGetSvipToken(); 
				
			}
			
			
			private void send_txGetSvipToken(com.vip.svip.osp.service.TxGetTokenRequest request_){
				
				InitInvocation("txGetSvipToken");
				
				txGetSvipToken_args args = new txGetSvipToken_args();
				args.SetRequest(request_);
				
				SendBase(args, txGetSvipToken_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.TxGetSvipTokenResult recv_txGetSvipToken(){
				
				txGetSvipToken_result result = new txGetSvipToken_result();
				ReceiveBase(result, txGetSvipToken_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.svip.osp.service.DoubleSvipCreateResponse txOpenSvip(com.vip.svip.osp.service.TxOpenSvipRequest request_) {
				
				send_txOpenSvip(request_);
				return recv_txOpenSvip(); 
				
			}
			
			
			private void send_txOpenSvip(com.vip.svip.osp.service.TxOpenSvipRequest request_){
				
				InitInvocation("txOpenSvip");
				
				txOpenSvip_args args = new txOpenSvip_args();
				args.SetRequest(request_);
				
				SendBase(args, txOpenSvip_argsHelper.getInstance());
			}
			
			
			private com.vip.svip.osp.service.DoubleSvipCreateResponse recv_txOpenSvip(){
				
				txOpenSvip_result result = new txOpenSvip_result();
				ReceiveBase(result, txOpenSvip_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}