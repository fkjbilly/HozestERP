using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.pg{
	
	
	public class ProcterGambleServiceHelper {
		
		
		
		public class getGoods_args {
			
			///<summary>
			/// Request
			///</summary>
			
			private vipapis.pg.GetProductListRequest request_;
			
			public vipapis.pg.GetProductListRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.pg.GetProductListRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getGoodsStock_args {
			
			///<summary>
			/// Request
			///</summary>
			
			private vipapis.pg.GetProductInventoryListRequest request_;
			
			public vipapis.pg.GetProductInventoryListRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.pg.GetProductInventoryListRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getOrders_args {
			
			///<summary>
			/// Request
			///</summary>
			
			private vipapis.pg.GetOrderListRequest request_;
			
			public vipapis.pg.GetOrderListRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.pg.GetOrderListRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getGoods_result {
			
			///<summary>
			///</summary>
			
			private vipapis.pg.GetProductListResponse success_;
			
			public vipapis.pg.GetProductListResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.pg.GetProductListResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getGoodsStock_result {
			
			///<summary>
			///</summary>
			
			private vipapis.pg.GetProductInventoryListResponse success_;
			
			public vipapis.pg.GetProductInventoryListResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.pg.GetProductInventoryListResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrders_result {
			
			///<summary>
			///</summary>
			
			private vipapis.pg.GetOrderListResponse success_;
			
			public vipapis.pg.GetOrderListResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.pg.GetOrderListResponse value){
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
		
		
		
		
		
		public class getGoods_argsHelper : TBeanSerializer<getGoods_args>
		{
			
			public static getGoods_argsHelper OBJ = new getGoods_argsHelper();
			
			public static getGoods_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getGoods_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.pg.GetProductListRequest value;
					
					value = new vipapis.pg.GetProductListRequest();
					vipapis.pg.GetProductListRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getGoods_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.pg.GetProductListRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getGoods_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getGoodsStock_argsHelper : TBeanSerializer<getGoodsStock_args>
		{
			
			public static getGoodsStock_argsHelper OBJ = new getGoodsStock_argsHelper();
			
			public static getGoodsStock_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getGoodsStock_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.pg.GetProductInventoryListRequest value;
					
					value = new vipapis.pg.GetProductInventoryListRequest();
					vipapis.pg.GetProductInventoryListRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getGoodsStock_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.pg.GetProductInventoryListRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getGoodsStock_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrders_argsHelper : TBeanSerializer<getOrders_args>
		{
			
			public static getOrders_argsHelper OBJ = new getOrders_argsHelper();
			
			public static getOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.pg.GetOrderListRequest value;
					
					value = new vipapis.pg.GetOrderListRequest();
					vipapis.pg.GetOrderListRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.pg.GetOrderListRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrders_args bean){
				
				
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
		
		
		
		
		public class getGoods_resultHelper : TBeanSerializer<getGoods_result>
		{
			
			public static getGoods_resultHelper OBJ = new getGoods_resultHelper();
			
			public static getGoods_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getGoods_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.pg.GetProductListResponse value;
					
					value = new vipapis.pg.GetProductListResponse();
					vipapis.pg.GetProductListResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getGoods_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.pg.GetProductListResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getGoods_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getGoodsStock_resultHelper : TBeanSerializer<getGoodsStock_result>
		{
			
			public static getGoodsStock_resultHelper OBJ = new getGoodsStock_resultHelper();
			
			public static getGoodsStock_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getGoodsStock_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.pg.GetProductInventoryListResponse value;
					
					value = new vipapis.pg.GetProductInventoryListResponse();
					vipapis.pg.GetProductInventoryListResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getGoodsStock_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.pg.GetProductInventoryListResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getGoodsStock_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrders_resultHelper : TBeanSerializer<getOrders_result>
		{
			
			public static getOrders_resultHelper OBJ = new getOrders_resultHelper();
			
			public static getOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.pg.GetOrderListResponse value;
					
					value = new vipapis.pg.GetOrderListResponse();
					vipapis.pg.GetOrderListResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.pg.GetOrderListResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrders_result bean){
				
				
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
		
		
		
		
		public class ProcterGambleServiceClient : OspRestStub , ProcterGambleService  {
			
			
			public ProcterGambleServiceClient():base("vipapis.pg.ProcterGambleService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.pg.GetProductListResponse getGoods(vipapis.pg.GetProductListRequest request_) {
				
				send_getGoods(request_);
				return recv_getGoods(); 
				
			}
			
			
			private void send_getGoods(vipapis.pg.GetProductListRequest request_){
				
				InitInvocation("getGoods");
				
				getGoods_args args = new getGoods_args();
				args.SetRequest(request_);
				
				SendBase(args, getGoods_argsHelper.getInstance());
			}
			
			
			private vipapis.pg.GetProductListResponse recv_getGoods(){
				
				getGoods_result result = new getGoods_result();
				ReceiveBase(result, getGoods_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.pg.GetProductInventoryListResponse getGoodsStock(vipapis.pg.GetProductInventoryListRequest request_) {
				
				send_getGoodsStock(request_);
				return recv_getGoodsStock(); 
				
			}
			
			
			private void send_getGoodsStock(vipapis.pg.GetProductInventoryListRequest request_){
				
				InitInvocation("getGoodsStock");
				
				getGoodsStock_args args = new getGoodsStock_args();
				args.SetRequest(request_);
				
				SendBase(args, getGoodsStock_argsHelper.getInstance());
			}
			
			
			private vipapis.pg.GetProductInventoryListResponse recv_getGoodsStock(){
				
				getGoodsStock_result result = new getGoodsStock_result();
				ReceiveBase(result, getGoodsStock_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.pg.GetOrderListResponse getOrders(vipapis.pg.GetOrderListRequest request_) {
				
				send_getOrders(request_);
				return recv_getOrders(); 
				
			}
			
			
			private void send_getOrders(vipapis.pg.GetOrderListRequest request_){
				
				InitInvocation("getOrders");
				
				getOrders_args args = new getOrders_args();
				args.SetRequest(request_);
				
				SendBase(args, getOrders_argsHelper.getInstance());
			}
			
			
			private vipapis.pg.GetOrderListResponse recv_getOrders(){
				
				getOrders_result result = new getOrders_result();
				ReceiveBase(result, getOrders_resultHelper.getInstance());
				
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