using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.isv.vreturn{
	
	
	public class ReturnOrderServiceHelper {
		
		
		
		public class addDefectiveGoods_args {
			
			///<summary>
			/// 插入一退收货数据请求
			///</summary>
			
			private List<com.vip.isv.vreturn.DefectiveGoods> request_;
			
			public List<com.vip.isv.vreturn.DefectiveGoods> GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(List<com.vip.isv.vreturn.DefectiveGoods> value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class doMatch_args {
			
			
		}
		
		
		
		
		public class getReturnDeliveryGoods_args {
			
			///<summary>
			/// 查询退供入库明细请求
			///</summary>
			
			private com.vip.isv.vreturn.GetReturnDeliveryGoodsRequest request_;
			
			public com.vip.isv.vreturn.GetReturnDeliveryGoodsRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.isv.vreturn.GetReturnDeliveryGoodsRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getReturnOrder_args {
			
			///<summary>
			/// 查询退供订单请求
			///</summary>
			
			private com.vip.isv.vreturn.GetReturnOrderRequest request_;
			
			public com.vip.isv.vreturn.GetReturnOrderRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(com.vip.isv.vreturn.GetReturnOrderRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class addDefectiveGoods_result {
			
			///<summary>
			///</summary>
			
			private List<string> success_;
			
			public List<string> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<string> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class doMatch_result {
			
			
		}
		
		
		
		
		public class getReturnDeliveryGoods_result {
			
			///<summary>
			///</summary>
			
			private com.vip.isv.vreturn.GetReturnDeliveryGoodsResponse success_;
			
			public com.vip.isv.vreturn.GetReturnDeliveryGoodsResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.isv.vreturn.GetReturnDeliveryGoodsResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getReturnOrder_result {
			
			///<summary>
			///</summary>
			
			private com.vip.isv.vreturn.GetReturnOrderResponse success_;
			
			public com.vip.isv.vreturn.GetReturnOrderResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.isv.vreturn.GetReturnOrderResponse value){
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
		
		
		
		
		
		public class addDefectiveGoods_argsHelper : TBeanSerializer<addDefectiveGoods_args>
		{
			
			public static addDefectiveGoods_argsHelper OBJ = new addDefectiveGoods_argsHelper();
			
			public static addDefectiveGoods_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addDefectiveGoods_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.isv.vreturn.DefectiveGoods> value;
					
					value = new List<com.vip.isv.vreturn.DefectiveGoods>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.isv.vreturn.DefectiveGoods elem1;
							
							elem1 = new com.vip.isv.vreturn.DefectiveGoods();
							com.vip.isv.vreturn.DefectiveGoodsHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addDefectiveGoods_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					oprot.WriteListBegin();
					foreach(com.vip.isv.vreturn.DefectiveGoods _item0 in structs.GetRequest()){
						
						
						com.vip.isv.vreturn.DefectiveGoodsHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addDefectiveGoods_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class doMatch_argsHelper : TBeanSerializer<doMatch_args>
		{
			
			public static doMatch_argsHelper OBJ = new doMatch_argsHelper();
			
			public static doMatch_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(doMatch_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(doMatch_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(doMatch_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnDeliveryGoods_argsHelper : TBeanSerializer<getReturnDeliveryGoods_args>
		{
			
			public static getReturnDeliveryGoods_argsHelper OBJ = new getReturnDeliveryGoods_argsHelper();
			
			public static getReturnDeliveryGoods_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnDeliveryGoods_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.vreturn.GetReturnDeliveryGoodsRequest value;
					
					value = new com.vip.isv.vreturn.GetReturnDeliveryGoodsRequest();
					com.vip.isv.vreturn.GetReturnDeliveryGoodsRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnDeliveryGoods_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.isv.vreturn.GetReturnDeliveryGoodsRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnDeliveryGoods_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnOrder_argsHelper : TBeanSerializer<getReturnOrder_args>
		{
			
			public static getReturnOrder_argsHelper OBJ = new getReturnOrder_argsHelper();
			
			public static getReturnOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.vreturn.GetReturnOrderRequest value;
					
					value = new com.vip.isv.vreturn.GetReturnOrderRequest();
					com.vip.isv.vreturn.GetReturnOrderRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					com.vip.isv.vreturn.GetReturnOrderRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnOrder_args bean){
				
				
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
		
		
		
		
		public class addDefectiveGoods_resultHelper : TBeanSerializer<addDefectiveGoods_result>
		{
			
			public static addDefectiveGoods_resultHelper OBJ = new addDefectiveGoods_resultHelper();
			
			public static addDefectiveGoods_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addDefectiveGoods_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem0;
							elem0 = iprot.ReadString();
							
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
			
			
			public void Write(addDefectiveGoods_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetSuccess()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addDefectiveGoods_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class doMatch_resultHelper : TBeanSerializer<doMatch_result>
		{
			
			public static doMatch_resultHelper OBJ = new doMatch_resultHelper();
			
			public static doMatch_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(doMatch_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(doMatch_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(doMatch_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnDeliveryGoods_resultHelper : TBeanSerializer<getReturnDeliveryGoods_result>
		{
			
			public static getReturnDeliveryGoods_resultHelper OBJ = new getReturnDeliveryGoods_resultHelper();
			
			public static getReturnDeliveryGoods_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnDeliveryGoods_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.vreturn.GetReturnDeliveryGoodsResponse value;
					
					value = new com.vip.isv.vreturn.GetReturnDeliveryGoodsResponse();
					com.vip.isv.vreturn.GetReturnDeliveryGoodsResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnDeliveryGoods_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.isv.vreturn.GetReturnDeliveryGoodsResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnDeliveryGoods_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getReturnOrder_resultHelper : TBeanSerializer<getReturnOrder_result>
		{
			
			public static getReturnOrder_resultHelper OBJ = new getReturnOrder_resultHelper();
			
			public static getReturnOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getReturnOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.vreturn.GetReturnOrderResponse value;
					
					value = new com.vip.isv.vreturn.GetReturnOrderResponse();
					com.vip.isv.vreturn.GetReturnOrderResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getReturnOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.isv.vreturn.GetReturnOrderResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getReturnOrder_result bean){
				
				
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
		
		
		
		
		public class ReturnOrderServiceClient : OspRestStub , ReturnOrderService  {
			
			
			public ReturnOrderServiceClient():base("com.vip.isv.vreturn.ReturnOrderService","1.0.0") {
				
				
			}
			
			
			
			public List<string> addDefectiveGoods(List<com.vip.isv.vreturn.DefectiveGoods> request_) {
				
				send_addDefectiveGoods(request_);
				return recv_addDefectiveGoods(); 
				
			}
			
			
			private void send_addDefectiveGoods(List<com.vip.isv.vreturn.DefectiveGoods> request_){
				
				InitInvocation("addDefectiveGoods");
				
				addDefectiveGoods_args args = new addDefectiveGoods_args();
				args.SetRequest(request_);
				
				SendBase(args, addDefectiveGoods_argsHelper.getInstance());
			}
			
			
			private List<string> recv_addDefectiveGoods(){
				
				addDefectiveGoods_result result = new addDefectiveGoods_result();
				ReceiveBase(result, addDefectiveGoods_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public void doMatch() {
				
				send_doMatch();
				recv_doMatch();
				
			}
			
			
			private void send_doMatch(){
				
				InitInvocation("doMatch");
				
				doMatch_args args = new doMatch_args();
				
				SendBase(args, doMatch_argsHelper.getInstance());
			}
			
			
			private void recv_doMatch(){
				
				doMatch_result result = new doMatch_result();
				ReceiveBase(result, doMatch_resultHelper.getInstance());
				
				
			}
			
			
			public com.vip.isv.vreturn.GetReturnDeliveryGoodsResponse getReturnDeliveryGoods(com.vip.isv.vreturn.GetReturnDeliveryGoodsRequest request_) {
				
				send_getReturnDeliveryGoods(request_);
				return recv_getReturnDeliveryGoods(); 
				
			}
			
			
			private void send_getReturnDeliveryGoods(com.vip.isv.vreturn.GetReturnDeliveryGoodsRequest request_){
				
				InitInvocation("getReturnDeliveryGoods");
				
				getReturnDeliveryGoods_args args = new getReturnDeliveryGoods_args();
				args.SetRequest(request_);
				
				SendBase(args, getReturnDeliveryGoods_argsHelper.getInstance());
			}
			
			
			private com.vip.isv.vreturn.GetReturnDeliveryGoodsResponse recv_getReturnDeliveryGoods(){
				
				getReturnDeliveryGoods_result result = new getReturnDeliveryGoods_result();
				ReceiveBase(result, getReturnDeliveryGoods_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.isv.vreturn.GetReturnOrderResponse getReturnOrder(com.vip.isv.vreturn.GetReturnOrderRequest request_) {
				
				send_getReturnOrder(request_);
				return recv_getReturnOrder(); 
				
			}
			
			
			private void send_getReturnOrder(com.vip.isv.vreturn.GetReturnOrderRequest request_){
				
				InitInvocation("getReturnOrder");
				
				getReturnOrder_args args = new getReturnOrder_args();
				args.SetRequest(request_);
				
				SendBase(args, getReturnOrder_argsHelper.getInstance());
			}
			
			
			private com.vip.isv.vreturn.GetReturnOrderResponse recv_getReturnOrder(){
				
				getReturnOrder_result result = new getReturnOrder_result();
				ReceiveBase(result, getReturnOrder_resultHelper.getInstance());
				
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
			
			
		}
		
		
	}
	
}