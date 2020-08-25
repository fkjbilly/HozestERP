using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.product{
	
	
	public class ProductSchemaServiceHelper {
		
		
		
		public class createProductBySchema_args {
			
			///<summary>
			/// 创建商品请求参数
			///</summary>
			
			private com.vip.isv.schema.CreateProductBySchemaRequest createProductSchemaRequest_;
			
			public com.vip.isv.schema.CreateProductBySchemaRequest GetCreateProductSchemaRequest(){
				return this.createProductSchemaRequest_;
			}
			
			public void SetCreateProductSchemaRequest(com.vip.isv.schema.CreateProductBySchemaRequest value){
				this.createProductSchemaRequest_ = value;
			}
			
		}
		
		
		
		
		public class getProductSchema_args {
			
			///<summary>
			/// 获取供应商商品模板请求参数
			///</summary>
			
			private com.vip.isv.schema.GetProductSchemaRequest getProductSchemaRequest_;
			
			public com.vip.isv.schema.GetProductSchemaRequest GetGetProductSchemaRequest(){
				return this.getProductSchemaRequest_;
			}
			
			public void SetGetProductSchemaRequest(com.vip.isv.schema.GetProductSchemaRequest value){
				this.getProductSchemaRequest_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class updateProductBySchema_args {
			
			///<summary>
			/// 更新商品请求参数
			///</summary>
			
			private com.vip.isv.schema.UpdateProductBySchemaRequest updateProductSchemaRequest_;
			
			public com.vip.isv.schema.UpdateProductBySchemaRequest GetUpdateProductSchemaRequest(){
				return this.updateProductSchemaRequest_;
			}
			
			public void SetUpdateProductSchemaRequest(com.vip.isv.schema.UpdateProductBySchemaRequest value){
				this.updateProductSchemaRequest_ = value;
			}
			
		}
		
		
		
		
		public class createProductBySchema_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.isv.schema.ProductResponse> success_;
			
			public List<com.vip.isv.schema.ProductResponse> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.isv.schema.ProductResponse> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getProductSchema_result {
			
			///<summary>
			/// 供应商商品模板
			///</summary>
			
			private string success_;
			
			public string GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(string value){
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
		
		
		
		
		public class updateProductBySchema_result {
			
			///<summary>
			///</summary>
			
			private com.vip.isv.schema.ProductResponse success_;
			
			public com.vip.isv.schema.ProductResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.isv.schema.ProductResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class createProductBySchema_argsHelper : TBeanSerializer<createProductBySchema_args>
		{
			
			public static createProductBySchema_argsHelper OBJ = new createProductBySchema_argsHelper();
			
			public static createProductBySchema_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createProductBySchema_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.schema.CreateProductBySchemaRequest value;
					
					value = new com.vip.isv.schema.CreateProductBySchemaRequest();
					com.vip.isv.schema.CreateProductBySchemaRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetCreateProductSchemaRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(createProductBySchema_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCreateProductSchemaRequest() != null) {
					
					oprot.WriteFieldBegin("createProductSchemaRequest");
					
					com.vip.isv.schema.CreateProductBySchemaRequestHelper.getInstance().Write(structs.GetCreateProductSchemaRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("createProductSchemaRequest can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createProductBySchema_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProductSchema_argsHelper : TBeanSerializer<getProductSchema_args>
		{
			
			public static getProductSchema_argsHelper OBJ = new getProductSchema_argsHelper();
			
			public static getProductSchema_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductSchema_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.schema.GetProductSchemaRequest value;
					
					value = new com.vip.isv.schema.GetProductSchemaRequest();
					com.vip.isv.schema.GetProductSchemaRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetGetProductSchemaRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductSchema_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetGetProductSchemaRequest() != null) {
					
					oprot.WriteFieldBegin("getProductSchemaRequest");
					
					com.vip.isv.schema.GetProductSchemaRequestHelper.getInstance().Write(structs.GetGetProductSchemaRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("getProductSchemaRequest can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductSchema_args bean){
				
				
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
		
		
		
		
		public class updateProductBySchema_argsHelper : TBeanSerializer<updateProductBySchema_args>
		{
			
			public static updateProductBySchema_argsHelper OBJ = new updateProductBySchema_argsHelper();
			
			public static updateProductBySchema_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateProductBySchema_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.schema.UpdateProductBySchemaRequest value;
					
					value = new com.vip.isv.schema.UpdateProductBySchemaRequest();
					com.vip.isv.schema.UpdateProductBySchemaRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetUpdateProductSchemaRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateProductBySchema_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetUpdateProductSchemaRequest() != null) {
					
					oprot.WriteFieldBegin("updateProductSchemaRequest");
					
					com.vip.isv.schema.UpdateProductBySchemaRequestHelper.getInstance().Write(structs.GetUpdateProductSchemaRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("updateProductSchemaRequest can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateProductBySchema_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class createProductBySchema_resultHelper : TBeanSerializer<createProductBySchema_result>
		{
			
			public static createProductBySchema_resultHelper OBJ = new createProductBySchema_resultHelper();
			
			public static createProductBySchema_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(createProductBySchema_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.isv.schema.ProductResponse> value;
					
					value = new List<com.vip.isv.schema.ProductResponse>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.isv.schema.ProductResponse elem0;
							
							elem0 = new com.vip.isv.schema.ProductResponse();
							com.vip.isv.schema.ProductResponseHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(createProductBySchema_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.isv.schema.ProductResponse _item0 in structs.GetSuccess()){
						
						
						com.vip.isv.schema.ProductResponseHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(createProductBySchema_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getProductSchema_resultHelper : TBeanSerializer<getProductSchema_result>
		{
			
			public static getProductSchema_resultHelper OBJ = new getProductSchema_resultHelper();
			
			public static getProductSchema_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getProductSchema_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getProductSchema_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteString(structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getProductSchema_result bean){
				
				
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
		
		
		
		
		public class updateProductBySchema_resultHelper : TBeanSerializer<updateProductBySchema_result>
		{
			
			public static updateProductBySchema_resultHelper OBJ = new updateProductBySchema_resultHelper();
			
			public static updateProductBySchema_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateProductBySchema_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.isv.schema.ProductResponse value;
					
					value = new com.vip.isv.schema.ProductResponse();
					com.vip.isv.schema.ProductResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateProductBySchema_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.isv.schema.ProductResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateProductBySchema_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class ProductSchemaServiceClient : OspRestStub , ProductSchemaService  {
			
			
			public ProductSchemaServiceClient():base("vipapis.product.ProductSchemaService","1.0.0") {
				
				
			}
			
			
			
			public List<com.vip.isv.schema.ProductResponse> createProductBySchema(com.vip.isv.schema.CreateProductBySchemaRequest createProductSchemaRequest_) {
				
				send_createProductBySchema(createProductSchemaRequest_);
				return recv_createProductBySchema(); 
				
			}
			
			
			private void send_createProductBySchema(com.vip.isv.schema.CreateProductBySchemaRequest createProductSchemaRequest_){
				
				InitInvocation("createProductBySchema");
				
				createProductBySchema_args args = new createProductBySchema_args();
				args.SetCreateProductSchemaRequest(createProductSchemaRequest_);
				
				SendBase(args, createProductBySchema_argsHelper.getInstance());
			}
			
			
			private List<com.vip.isv.schema.ProductResponse> recv_createProductBySchema(){
				
				createProductBySchema_result result = new createProductBySchema_result();
				ReceiveBase(result, createProductBySchema_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public string getProductSchema(com.vip.isv.schema.GetProductSchemaRequest getProductSchemaRequest_) {
				
				send_getProductSchema(getProductSchemaRequest_);
				return recv_getProductSchema(); 
				
			}
			
			
			private void send_getProductSchema(com.vip.isv.schema.GetProductSchemaRequest getProductSchemaRequest_){
				
				InitInvocation("getProductSchema");
				
				getProductSchema_args args = new getProductSchema_args();
				args.SetGetProductSchemaRequest(getProductSchemaRequest_);
				
				SendBase(args, getProductSchema_argsHelper.getInstance());
			}
			
			
			private string recv_getProductSchema(){
				
				getProductSchema_result result = new getProductSchema_result();
				ReceiveBase(result, getProductSchema_resultHelper.getInstance());
				
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
			
			
			public com.vip.isv.schema.ProductResponse updateProductBySchema(com.vip.isv.schema.UpdateProductBySchemaRequest updateProductSchemaRequest_) {
				
				send_updateProductBySchema(updateProductSchemaRequest_);
				return recv_updateProductBySchema(); 
				
			}
			
			
			private void send_updateProductBySchema(com.vip.isv.schema.UpdateProductBySchemaRequest updateProductSchemaRequest_){
				
				InitInvocation("updateProductBySchema");
				
				updateProductBySchema_args args = new updateProductBySchema_args();
				args.SetUpdateProductSchemaRequest(updateProductSchemaRequest_);
				
				SendBase(args, updateProductBySchema_argsHelper.getInstance());
			}
			
			
			private com.vip.isv.schema.ProductResponse recv_updateProductBySchema(){
				
				updateProductBySchema_result result = new updateProductBySchema_result();
				ReceiveBase(result, updateProductBySchema_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}