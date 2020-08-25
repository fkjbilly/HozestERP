using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.brand{
	
	
	public class BrandServiceHelper {
		
		
		
		public class getBrandInfo_args {
			
			///<summary>
			/// 品牌id
			/// @sampleValue brand_id brand_id=E456413215
			///</summary>
			
			private string brand_id_;
			
			public string GetBrand_id(){
				return this.brand_id_;
			}
			
			public void SetBrand_id(string value){
				this.brand_id_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class multiGetBrand_args {
			
			///<summary>
			/// 检索类型
			/// @sampleValue search_type search_type=brand_name
			///</summary>
			
			private vipapis.brand.BrandSearchType? search_type_;
			
			///<summary>
			/// 检索关键词
			/// @sampleValue word word=耐克
			///</summary>
			
			private string word_;
			
			///<summary>
			/// 页码
			/// @sampleValue page page=1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数
			/// @sampleValue limit limit=20
			///</summary>
			
			private int? limit_;
			
			public vipapis.brand.BrandSearchType? GetSearch_type(){
				return this.search_type_;
			}
			
			public void SetSearch_type(vipapis.brand.BrandSearchType? value){
				this.search_type_ = value;
			}
			public string GetWord(){
				return this.word_;
			}
			
			public void SetWord(string value){
				this.word_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			
		}
		
		
		
		
		public class getBrandInfo_result {
			
			///<summary>
			///</summary>
			
			private vipapis.brand.BrandInfo success_;
			
			public vipapis.brand.BrandInfo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.brand.BrandInfo value){
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
		
		
		
		
		public class multiGetBrand_result {
			
			///<summary>
			///</summary>
			
			private vipapis.brand.MultiGetBrandResponse success_;
			
			public vipapis.brand.MultiGetBrandResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.brand.MultiGetBrandResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class getBrandInfo_argsHelper : BeanSerializer<getBrandInfo_args>
		{
			
			public static getBrandInfo_argsHelper OBJ = new getBrandInfo_argsHelper();
			
			public static getBrandInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getBrandInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBrand_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getBrandInfo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetBrand_id() != null) {
					
					oprot.WriteFieldBegin("brand_id");
					oprot.WriteString(structs.GetBrand_id());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("brand_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getBrandInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_argsHelper : BeanSerializer<healthCheck_args>
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
		
		
		
		
		public class multiGetBrand_argsHelper : BeanSerializer<multiGetBrand_args>
		{
			
			public static multiGetBrand_argsHelper OBJ = new multiGetBrand_argsHelper();
			
			public static multiGetBrand_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(multiGetBrand_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.brand.BrandSearchType? value;
					
					value = vipapis.brand.BrandSearchTypeUtil.FindByName(iprot.ReadString());
					
					structs.SetSearch_type(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWord(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(multiGetBrand_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSearch_type() != null) {
					
					oprot.WriteFieldBegin("search_type");
					oprot.WriteString(structs.GetSearch_type().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("search_type can not be null!");
				}
				
				
				if(structs.GetWord() != null) {
					
					oprot.WriteFieldBegin("word");
					oprot.WriteString(structs.GetWord());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("word can not be null!");
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(multiGetBrand_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getBrandInfo_resultHelper : BeanSerializer<getBrandInfo_result>
		{
			
			public static getBrandInfo_resultHelper OBJ = new getBrandInfo_resultHelper();
			
			public static getBrandInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getBrandInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.brand.BrandInfo value;
					
					value = new vipapis.brand.BrandInfo();
					vipapis.brand.BrandInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getBrandInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.brand.BrandInfoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getBrandInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class healthCheck_resultHelper : BeanSerializer<healthCheck_result>
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
		
		
		
		
		public class multiGetBrand_resultHelper : BeanSerializer<multiGetBrand_result>
		{
			
			public static multiGetBrand_resultHelper OBJ = new multiGetBrand_resultHelper();
			
			public static multiGetBrand_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(multiGetBrand_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.brand.MultiGetBrandResponse value;
					
					value = new vipapis.brand.MultiGetBrandResponse();
					vipapis.brand.MultiGetBrandResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(multiGetBrand_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.brand.MultiGetBrandResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(multiGetBrand_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class BrandServiceClient : OspRestStub , BrandService  {
			
			
			public BrandServiceClient():base("vipapis.brand.BrandService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.brand.BrandInfo getBrandInfo(string brand_id_) {
				
				send_getBrandInfo(brand_id_);
				return recv_getBrandInfo(); 
				
			}
			
			
			private void send_getBrandInfo(string brand_id_){
				
				InitInvocation("getBrandInfo");
				
				getBrandInfo_args args = new getBrandInfo_args();
				args.SetBrand_id(brand_id_);
				
				SendBase(args, getBrandInfo_argsHelper.getInstance());
			}
			
			
			private vipapis.brand.BrandInfo recv_getBrandInfo(){
				
				getBrandInfo_result result = new getBrandInfo_result();
				ReceiveBase(result, getBrandInfo_resultHelper.getInstance());
				
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
			
			
			public vipapis.brand.MultiGetBrandResponse multiGetBrand(vipapis.brand.BrandSearchType? search_type_,string word_,int? page_,int? limit_) {
				
				send_multiGetBrand(search_type_,word_,page_,limit_);
				return recv_multiGetBrand(); 
				
			}
			
			
			private void send_multiGetBrand(vipapis.brand.BrandSearchType? search_type_,string word_,int? page_,int? limit_){
				
				InitInvocation("multiGetBrand");
				
				multiGetBrand_args args = new multiGetBrand_args();
				args.SetSearch_type(search_type_);
				args.SetWord(word_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, multiGetBrand_argsHelper.getInstance());
			}
			
			
			private vipapis.brand.MultiGetBrandResponse recv_multiGetBrand(){
				
				multiGetBrand_result result = new multiGetBrand_result();
				ReceiveBase(result, multiGetBrand_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}