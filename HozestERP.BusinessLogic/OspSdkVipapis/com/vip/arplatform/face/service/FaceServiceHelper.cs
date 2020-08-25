using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.arplatform.face.service{
	
	
	public class FaceServiceHelper {
		
		
		
		public class faceCartoon_args {
			
			///<summary>
			/// 输入图片
			///</summary>
			
			private string imageInPath_;
			
			///<summary>
			/// 脸部图片
			///</summary>
			
			private string faceUrl_;
			
			///<summary>
			/// 无脸图片
			///</summary>
			
			private string facelessUrl_;
			
			///<summary>
			/// 红色差信号
			///</summary>
			
			private int? cr_;
			
			///<summary>
			/// 蓝色差信号
			///</summary>
			
			private int? cb_;
			
			///<summary>
			/// 三角片坐标组
			///</summary>
			
			private string point_;
			
			public string GetImageInPath(){
				return this.imageInPath_;
			}
			
			public void SetImageInPath(string value){
				this.imageInPath_ = value;
			}
			public string GetFaceUrl(){
				return this.faceUrl_;
			}
			
			public void SetFaceUrl(string value){
				this.faceUrl_ = value;
			}
			public string GetFacelessUrl(){
				return this.facelessUrl_;
			}
			
			public void SetFacelessUrl(string value){
				this.facelessUrl_ = value;
			}
			public int? GetCr(){
				return this.cr_;
			}
			
			public void SetCr(int? value){
				this.cr_ = value;
			}
			public int? GetCb(){
				return this.cb_;
			}
			
			public void SetCb(int? value){
				this.cb_ = value;
			}
			public string GetPoint(){
				return this.point_;
			}
			
			public void SetPoint(string value){
				this.point_ = value;
			}
			
		}
		
		
		
		
		public class faceSimilarity_args {
			
			///<summary>
			/// 人脸图片url1
			///</summary>
			
			private string image_url1_;
			
			///<summary>
			/// 人脸图片url2
			///</summary>
			
			private string image_url2_;
			
			public string GetImage_url1(){
				return this.image_url1_;
			}
			
			public void SetImage_url1(string value){
				this.image_url1_ = value;
			}
			public string GetImage_url2(){
				return this.image_url2_;
			}
			
			public void SetImage_url2(string value){
				this.image_url2_ = value;
			}
			
		}
		
		
		
		
		public class facesetCreate_args {
			
			///<summary>
			/// 人脸集合key
			///</summary>
			
			private string faceset_key_;
			
			///<summary>
			/// 人脸图片url列表
			///</summary>
			
			private string image_urls_;
			
			public string GetFaceset_key(){
				return this.faceset_key_;
			}
			
			public void SetFaceset_key(string value){
				this.faceset_key_ = value;
			}
			public string GetImage_urls(){
				return this.image_urls_;
			}
			
			public void SetImage_urls(string value){
				this.image_urls_ = value;
			}
			
		}
		
		
		
		
		public class facesetDelete_args {
			
			///<summary>
			/// 人脸集合key
			///</summary>
			
			private string faceset_key_;
			
			///<summary>
			/// 人脸图片url列表
			///</summary>
			
			private string image_urls_;
			
			public string GetFaceset_key(){
				return this.faceset_key_;
			}
			
			public void SetFaceset_key(string value){
				this.faceset_key_ = value;
			}
			public string GetImage_urls(){
				return this.image_urls_;
			}
			
			public void SetImage_urls(string value){
				this.image_urls_ = value;
			}
			
		}
		
		
		
		
		public class facesetStatus_args {
			
			///<summary>
			/// 人脸集合key
			///</summary>
			
			private string faceset_key_;
			
			public string GetFaceset_key(){
				return this.faceset_key_;
			}
			
			public void SetFaceset_key(string value){
				this.faceset_key_ = value;
			}
			
		}
		
		
		
		
		public class facesetUpdate_args {
			
			///<summary>
			/// 人脸集合key
			///</summary>
			
			private string faceset_key_;
			
			///<summary>
			/// 人脸图片url列表
			///</summary>
			
			private string image_urls_;
			
			public string GetFaceset_key(){
				return this.faceset_key_;
			}
			
			public void SetFaceset_key(string value){
				this.faceset_key_ = value;
			}
			public string GetImage_urls(){
				return this.image_urls_;
			}
			
			public void SetImage_urls(string value){
				this.image_urls_ = value;
			}
			
		}
		
		
		
		
		public class getCrCb_args {
			
			///<summary>
			/// 无脸图
			///</summary>
			
			private string facelessUrl_;
			
			///<summary>
			/// 三角片坐标组
			///</summary>
			
			private string point_;
			
			public string GetFacelessUrl(){
				return this.facelessUrl_;
			}
			
			public void SetFacelessUrl(string value){
				this.facelessUrl_ = value;
			}
			public string GetPoint(){
				return this.point_;
			}
			
			public void SetPoint(string value){
				this.point_ = value;
			}
			
		}
		
		
		
		
		public class getFacesetUrl_args {
			
			///<summary>
			/// 人脸集合key
			///</summary>
			
			private string faceset_key_;
			
			public string GetFaceset_key(){
				return this.faceset_key_;
			}
			
			public void SetFaceset_key(string value){
				this.faceset_key_ = value;
			}
			
		}
		
		
		
		
		public class getSearchResult_args {
			
			///<summary>
			/// 人脸相似结果查询的token
			///</summary>
			
			private string token_;
			
			public string GetToken(){
				return this.token_;
			}
			
			public void SetToken(string value){
				this.token_ = value;
			}
			
		}
		
		
		
		
		public class getSearchWithFeaturesResult_args {
			
			///<summary>
			/// 人脸相似搜索带融合过程的请求对象
			///</summary>
			
			private com.vip.arplatform.face.service.GetSearchWithFeaturesParamResultModel getSearchWithFeaturesParamResultModel_;
			
			public com.vip.arplatform.face.service.GetSearchWithFeaturesParamResultModel GetGetSearchWithFeaturesParamResultModel(){
				return this.getSearchWithFeaturesParamResultModel_;
			}
			
			public void SetGetSearchWithFeaturesParamResultModel(com.vip.arplatform.face.service.GetSearchWithFeaturesParamResultModel value){
				this.getSearchWithFeaturesParamResultModel_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class imageStylize_args {
			
			///<summary>
			/// 输入图片
			///</summary>
			
			private string imageInPath_;
			
			///<summary>
			/// 风格化类型
			///</summary>
			
			private string type_;
			
			public string GetImageInPath(){
				return this.imageInPath_;
			}
			
			public void SetImageInPath(string value){
				this.imageInPath_ = value;
			}
			public string GetType(){
				return this.type_;
			}
			
			public void SetType(string value){
				this.type_ = value;
			}
			
		}
		
		
		
		
		public class search_args {
			
			///<summary>
			/// 人脸集合key
			///</summary>
			
			private string faceset_key_;
			
			///<summary>
			/// 人脸图片url
			///</summary>
			
			private string image_url_;
			
			///<summary>
			/// 人脸集合返回的相似图片数量
			///</summary>
			
			private int? results_count_;
			
			///<summary>
			/// 是否同步0：同步，1：异步
			///</summary>
			
			private int? asynchronization_;
			
			public string GetFaceset_key(){
				return this.faceset_key_;
			}
			
			public void SetFaceset_key(string value){
				this.faceset_key_ = value;
			}
			public string GetImage_url(){
				return this.image_url_;
			}
			
			public void SetImage_url(string value){
				this.image_url_ = value;
			}
			public int? GetResults_count(){
				return this.results_count_;
			}
			
			public void SetResults_count(int? value){
				this.results_count_ = value;
			}
			public int? GetAsynchronization(){
				return this.asynchronization_;
			}
			
			public void SetAsynchronization(int? value){
				this.asynchronization_ = value;
			}
			
		}
		
		
		
		
		public class searchWithFeatures_args {
			
			///<summary>
			/// 人脸相似搜索的请求对象
			///</summary>
			
			private com.vip.arplatform.face.service.SearchWithFeaturesParamModel searchWithFeaturesParamModel_;
			
			public com.vip.arplatform.face.service.SearchWithFeaturesParamModel GetSearchWithFeaturesParamModel(){
				return this.searchWithFeaturesParamModel_;
			}
			
			public void SetSearchWithFeaturesParamModel(com.vip.arplatform.face.service.SearchWithFeaturesParamModel value){
				this.searchWithFeaturesParamModel_ = value;
			}
			
		}
		
		
		
		
		public class shapeSimilarity_args {
			
			///<summary>
			/// 原始图片
			///</summary>
			
			private string img_src_;
			
			///<summary>
			/// 目标图片
			///</summary>
			
			private string img_target_;
			
			public string GetImg_src(){
				return this.img_src_;
			}
			
			public void SetImg_src(string value){
				this.img_src_ = value;
			}
			public string GetImg_target(){
				return this.img_target_;
			}
			
			public void SetImg_target(string value){
				this.img_target_ = value;
			}
			
		}
		
		
		
		
		public class faceCartoon_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.arplatform.face.service.CartoonModel success_;
			
			public com.vip.arplatform.face.service.CartoonModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.arplatform.face.service.CartoonModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class faceSimilarity_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.arplatform.face.service.FacesetCompareResult success_;
			
			public com.vip.arplatform.face.service.FacesetCompareResult GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.arplatform.face.service.FacesetCompareResult value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class facesetCreate_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.arplatform.face.service.FacesetCreateModel success_;
			
			public com.vip.arplatform.face.service.FacesetCreateModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.arplatform.face.service.FacesetCreateModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class facesetDelete_result {
			
			///<summary>
			/// 被删除的人脸集合URL
			///</summary>
			
			private List<string> success_;
			
			public List<string> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<string> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class facesetStatus_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.arplatform.face.service.FacesetCreateModel success_;
			
			public com.vip.arplatform.face.service.FacesetCreateModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.arplatform.face.service.FacesetCreateModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class facesetUpdate_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.arplatform.face.service.FacesetCreateModel success_;
			
			public com.vip.arplatform.face.service.FacesetCreateModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.arplatform.face.service.FacesetCreateModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCrCb_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.arplatform.face.service.CrCbModel success_;
			
			public com.vip.arplatform.face.service.CrCbModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.arplatform.face.service.CrCbModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getFacesetUrl_result {
			
			///<summary>
			/// 人脸集合URL
			///</summary>
			
			private List<string> success_;
			
			public List<string> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<string> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSearchResult_result {
			
			///<summary>
			/// 相似度最高的几张图片的分数和URL {code: 200, data: [{score:..., url:...}, ...]}
			///</summary>
			
			private com.vip.arplatform.face.service.CompareResponse success_;
			
			public com.vip.arplatform.face.service.CompareResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.arplatform.face.service.CompareResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSearchWithFeaturesResult_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.arplatform.face.service.SearchWithFeaturesResultModel success_;
			
			public com.vip.arplatform.face.service.SearchWithFeaturesResultModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.arplatform.face.service.SearchWithFeaturesResultModel value){
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
		
		
		
		
		public class imageStylize_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.arplatform.face.service.ImageStylizationModel success_;
			
			public com.vip.arplatform.face.service.ImageStylizationModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.arplatform.face.service.ImageStylizationModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class search_result {
			
			///<summary>
			/// 同步调用返回相似度最高的几张图片的分数和URL {code: 200, data: [{score:..., url:...}, ...]}
			///    异步调用返回 {code: 1123, msg: <request-token>}
			///</summary>
			
			private com.vip.arplatform.face.service.CompareResponse success_;
			
			public com.vip.arplatform.face.service.CompareResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.arplatform.face.service.CompareResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class searchWithFeatures_result {
			
			///<summary>
			/// 
			///</summary>
			
			private com.vip.arplatform.face.service.SearchWithFeaturesResultModel success_;
			
			public com.vip.arplatform.face.service.SearchWithFeaturesResultModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.arplatform.face.service.SearchWithFeaturesResultModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class shapeSimilarity_result {
			
			///<summary>
			///</summary>
			
			private com.vip.arplatform.face.service.ShapeSimilarityModel success_;
			
			public com.vip.arplatform.face.service.ShapeSimilarityModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.arplatform.face.service.ShapeSimilarityModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class faceCartoon_argsHelper : TBeanSerializer<faceCartoon_args>
		{
			
			public static faceCartoon_argsHelper OBJ = new faceCartoon_argsHelper();
			
			public static faceCartoon_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(faceCartoon_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetImageInPath(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetFaceUrl(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetFacelessUrl(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetCr(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetCb(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPoint(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(faceCartoon_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetImageInPath() != null) {
					
					oprot.WriteFieldBegin("imageInPath");
					oprot.WriteString(structs.GetImageInPath());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("imageInPath can not be null!");
				}
				
				
				if(structs.GetFaceUrl() != null) {
					
					oprot.WriteFieldBegin("faceUrl");
					oprot.WriteString(structs.GetFaceUrl());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("faceUrl can not be null!");
				}
				
				
				if(structs.GetFacelessUrl() != null) {
					
					oprot.WriteFieldBegin("facelessUrl");
					oprot.WriteString(structs.GetFacelessUrl());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("facelessUrl can not be null!");
				}
				
				
				if(structs.GetCr() != null) {
					
					oprot.WriteFieldBegin("cr");
					oprot.WriteI32((int)structs.GetCr()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCb() != null) {
					
					oprot.WriteFieldBegin("cb");
					oprot.WriteI32((int)structs.GetCb()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPoint() != null) {
					
					oprot.WriteFieldBegin("point");
					oprot.WriteString(structs.GetPoint());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("point can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(faceCartoon_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class faceSimilarity_argsHelper : TBeanSerializer<faceSimilarity_args>
		{
			
			public static faceSimilarity_argsHelper OBJ = new faceSimilarity_argsHelper();
			
			public static faceSimilarity_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(faceSimilarity_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetImage_url1(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetImage_url2(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(faceSimilarity_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetImage_url1() != null) {
					
					oprot.WriteFieldBegin("image_url1");
					oprot.WriteString(structs.GetImage_url1());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("image_url1 can not be null!");
				}
				
				
				if(structs.GetImage_url2() != null) {
					
					oprot.WriteFieldBegin("image_url2");
					oprot.WriteString(structs.GetImage_url2());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("image_url2 can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(faceSimilarity_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class facesetCreate_argsHelper : TBeanSerializer<facesetCreate_args>
		{
			
			public static facesetCreate_argsHelper OBJ = new facesetCreate_argsHelper();
			
			public static facesetCreate_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(facesetCreate_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetFaceset_key(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetImage_urls(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(facesetCreate_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetFaceset_key() != null) {
					
					oprot.WriteFieldBegin("faceset_key");
					oprot.WriteString(structs.GetFaceset_key());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("faceset_key can not be null!");
				}
				
				
				if(structs.GetImage_urls() != null) {
					
					oprot.WriteFieldBegin("image_urls");
					oprot.WriteString(structs.GetImage_urls());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("image_urls can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(facesetCreate_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class facesetDelete_argsHelper : TBeanSerializer<facesetDelete_args>
		{
			
			public static facesetDelete_argsHelper OBJ = new facesetDelete_argsHelper();
			
			public static facesetDelete_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(facesetDelete_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetFaceset_key(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetImage_urls(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(facesetDelete_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetFaceset_key() != null) {
					
					oprot.WriteFieldBegin("faceset_key");
					oprot.WriteString(structs.GetFaceset_key());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("faceset_key can not be null!");
				}
				
				
				if(structs.GetImage_urls() != null) {
					
					oprot.WriteFieldBegin("image_urls");
					oprot.WriteString(structs.GetImage_urls());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(facesetDelete_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class facesetStatus_argsHelper : TBeanSerializer<facesetStatus_args>
		{
			
			public static facesetStatus_argsHelper OBJ = new facesetStatus_argsHelper();
			
			public static facesetStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(facesetStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetFaceset_key(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(facesetStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetFaceset_key() != null) {
					
					oprot.WriteFieldBegin("faceset_key");
					oprot.WriteString(structs.GetFaceset_key());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("faceset_key can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(facesetStatus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class facesetUpdate_argsHelper : TBeanSerializer<facesetUpdate_args>
		{
			
			public static facesetUpdate_argsHelper OBJ = new facesetUpdate_argsHelper();
			
			public static facesetUpdate_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(facesetUpdate_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetFaceset_key(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetImage_urls(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(facesetUpdate_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetFaceset_key() != null) {
					
					oprot.WriteFieldBegin("faceset_key");
					oprot.WriteString(structs.GetFaceset_key());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("faceset_key can not be null!");
				}
				
				
				if(structs.GetImage_urls() != null) {
					
					oprot.WriteFieldBegin("image_urls");
					oprot.WriteString(structs.GetImage_urls());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("image_urls can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(facesetUpdate_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCrCb_argsHelper : TBeanSerializer<getCrCb_args>
		{
			
			public static getCrCb_argsHelper OBJ = new getCrCb_argsHelper();
			
			public static getCrCb_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCrCb_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetFacelessUrl(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPoint(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCrCb_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetFacelessUrl() != null) {
					
					oprot.WriteFieldBegin("facelessUrl");
					oprot.WriteString(structs.GetFacelessUrl());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("facelessUrl can not be null!");
				}
				
				
				if(structs.GetPoint() != null) {
					
					oprot.WriteFieldBegin("point");
					oprot.WriteString(structs.GetPoint());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("point can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCrCb_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getFacesetUrl_argsHelper : TBeanSerializer<getFacesetUrl_args>
		{
			
			public static getFacesetUrl_argsHelper OBJ = new getFacesetUrl_argsHelper();
			
			public static getFacesetUrl_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getFacesetUrl_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetFaceset_key(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getFacesetUrl_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetFaceset_key() != null) {
					
					oprot.WriteFieldBegin("faceset_key");
					oprot.WriteString(structs.GetFaceset_key());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("faceset_key can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getFacesetUrl_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSearchResult_argsHelper : TBeanSerializer<getSearchResult_args>
		{
			
			public static getSearchResult_argsHelper OBJ = new getSearchResult_argsHelper();
			
			public static getSearchResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSearchResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetToken(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSearchResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetToken() != null) {
					
					oprot.WriteFieldBegin("token");
					oprot.WriteString(structs.GetToken());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("token can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSearchResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSearchWithFeaturesResult_argsHelper : TBeanSerializer<getSearchWithFeaturesResult_args>
		{
			
			public static getSearchWithFeaturesResult_argsHelper OBJ = new getSearchWithFeaturesResult_argsHelper();
			
			public static getSearchWithFeaturesResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSearchWithFeaturesResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.arplatform.face.service.GetSearchWithFeaturesParamResultModel value;
					
					value = new com.vip.arplatform.face.service.GetSearchWithFeaturesParamResultModel();
					com.vip.arplatform.face.service.GetSearchWithFeaturesParamResultModelHelper.getInstance().Read(value, iprot);
					
					structs.SetGetSearchWithFeaturesParamResultModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSearchWithFeaturesResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetGetSearchWithFeaturesParamResultModel() != null) {
					
					oprot.WriteFieldBegin("getSearchWithFeaturesParamResultModel");
					
					com.vip.arplatform.face.service.GetSearchWithFeaturesParamResultModelHelper.getInstance().Write(structs.GetGetSearchWithFeaturesParamResultModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("getSearchWithFeaturesParamResultModel can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSearchWithFeaturesResult_args bean){
				
				
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
		
		
		
		
		public class imageStylize_argsHelper : TBeanSerializer<imageStylize_args>
		{
			
			public static imageStylize_argsHelper OBJ = new imageStylize_argsHelper();
			
			public static imageStylize_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(imageStylize_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetImageInPath(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetType(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(imageStylize_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetImageInPath() != null) {
					
					oprot.WriteFieldBegin("imageInPath");
					oprot.WriteString(structs.GetImageInPath());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("imageInPath can not be null!");
				}
				
				
				if(structs.GetType() != null) {
					
					oprot.WriteFieldBegin("type");
					oprot.WriteString(structs.GetType());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(imageStylize_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class search_argsHelper : TBeanSerializer<search_args>
		{
			
			public static search_argsHelper OBJ = new search_argsHelper();
			
			public static search_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(search_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetFaceset_key(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetImage_url(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetResults_count(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetAsynchronization(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(search_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetFaceset_key() != null) {
					
					oprot.WriteFieldBegin("faceset_key");
					oprot.WriteString(structs.GetFaceset_key());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("faceset_key can not be null!");
				}
				
				
				if(structs.GetImage_url() != null) {
					
					oprot.WriteFieldBegin("image_url");
					oprot.WriteString(structs.GetImage_url());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("image_url can not be null!");
				}
				
				
				if(structs.GetResults_count() != null) {
					
					oprot.WriteFieldBegin("results_count");
					oprot.WriteI32((int)structs.GetResults_count()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("results_count can not be null!");
				}
				
				
				if(structs.GetAsynchronization() != null) {
					
					oprot.WriteFieldBegin("asynchronization");
					oprot.WriteI32((int)structs.GetAsynchronization()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("asynchronization can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(search_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class searchWithFeatures_argsHelper : TBeanSerializer<searchWithFeatures_args>
		{
			
			public static searchWithFeatures_argsHelper OBJ = new searchWithFeatures_argsHelper();
			
			public static searchWithFeatures_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(searchWithFeatures_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.arplatform.face.service.SearchWithFeaturesParamModel value;
					
					value = new com.vip.arplatform.face.service.SearchWithFeaturesParamModel();
					com.vip.arplatform.face.service.SearchWithFeaturesParamModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSearchWithFeaturesParamModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(searchWithFeatures_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSearchWithFeaturesParamModel() != null) {
					
					oprot.WriteFieldBegin("searchWithFeaturesParamModel");
					
					com.vip.arplatform.face.service.SearchWithFeaturesParamModelHelper.getInstance().Write(structs.GetSearchWithFeaturesParamModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("searchWithFeaturesParamModel can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(searchWithFeatures_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class shapeSimilarity_argsHelper : TBeanSerializer<shapeSimilarity_args>
		{
			
			public static shapeSimilarity_argsHelper OBJ = new shapeSimilarity_argsHelper();
			
			public static shapeSimilarity_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(shapeSimilarity_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetImg_src(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetImg_target(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(shapeSimilarity_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetImg_src() != null) {
					
					oprot.WriteFieldBegin("img_src");
					oprot.WriteString(structs.GetImg_src());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("img_src can not be null!");
				}
				
				
				if(structs.GetImg_target() != null) {
					
					oprot.WriteFieldBegin("img_target");
					oprot.WriteString(structs.GetImg_target());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("img_target can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(shapeSimilarity_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class faceCartoon_resultHelper : TBeanSerializer<faceCartoon_result>
		{
			
			public static faceCartoon_resultHelper OBJ = new faceCartoon_resultHelper();
			
			public static faceCartoon_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(faceCartoon_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.arplatform.face.service.CartoonModel value;
					
					value = new com.vip.arplatform.face.service.CartoonModel();
					com.vip.arplatform.face.service.CartoonModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(faceCartoon_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.arplatform.face.service.CartoonModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(faceCartoon_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class faceSimilarity_resultHelper : TBeanSerializer<faceSimilarity_result>
		{
			
			public static faceSimilarity_resultHelper OBJ = new faceSimilarity_resultHelper();
			
			public static faceSimilarity_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(faceSimilarity_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.arplatform.face.service.FacesetCompareResult value;
					
					value = new com.vip.arplatform.face.service.FacesetCompareResult();
					com.vip.arplatform.face.service.FacesetCompareResultHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(faceSimilarity_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.arplatform.face.service.FacesetCompareResultHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(faceSimilarity_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class facesetCreate_resultHelper : TBeanSerializer<facesetCreate_result>
		{
			
			public static facesetCreate_resultHelper OBJ = new facesetCreate_resultHelper();
			
			public static facesetCreate_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(facesetCreate_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.arplatform.face.service.FacesetCreateModel value;
					
					value = new com.vip.arplatform.face.service.FacesetCreateModel();
					com.vip.arplatform.face.service.FacesetCreateModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(facesetCreate_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.arplatform.face.service.FacesetCreateModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(facesetCreate_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class facesetDelete_resultHelper : TBeanSerializer<facesetDelete_result>
		{
			
			public static facesetDelete_resultHelper OBJ = new facesetDelete_resultHelper();
			
			public static facesetDelete_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(facesetDelete_result structs, Protocol iprot){
				
				
				
				
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
			
			
			public void Write(facesetDelete_result structs, Protocol oprot){
				
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
			
			
			public void Validate(facesetDelete_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class facesetStatus_resultHelper : TBeanSerializer<facesetStatus_result>
		{
			
			public static facesetStatus_resultHelper OBJ = new facesetStatus_resultHelper();
			
			public static facesetStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(facesetStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.arplatform.face.service.FacesetCreateModel value;
					
					value = new com.vip.arplatform.face.service.FacesetCreateModel();
					com.vip.arplatform.face.service.FacesetCreateModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(facesetStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.arplatform.face.service.FacesetCreateModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(facesetStatus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class facesetUpdate_resultHelper : TBeanSerializer<facesetUpdate_result>
		{
			
			public static facesetUpdate_resultHelper OBJ = new facesetUpdate_resultHelper();
			
			public static facesetUpdate_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(facesetUpdate_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.arplatform.face.service.FacesetCreateModel value;
					
					value = new com.vip.arplatform.face.service.FacesetCreateModel();
					com.vip.arplatform.face.service.FacesetCreateModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(facesetUpdate_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.arplatform.face.service.FacesetCreateModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(facesetUpdate_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCrCb_resultHelper : TBeanSerializer<getCrCb_result>
		{
			
			public static getCrCb_resultHelper OBJ = new getCrCb_resultHelper();
			
			public static getCrCb_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCrCb_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.arplatform.face.service.CrCbModel value;
					
					value = new com.vip.arplatform.face.service.CrCbModel();
					com.vip.arplatform.face.service.CrCbModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCrCb_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.arplatform.face.service.CrCbModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCrCb_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getFacesetUrl_resultHelper : TBeanSerializer<getFacesetUrl_result>
		{
			
			public static getFacesetUrl_resultHelper OBJ = new getFacesetUrl_resultHelper();
			
			public static getFacesetUrl_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getFacesetUrl_result structs, Protocol iprot){
				
				
				
				
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
			
			
			public void Write(getFacesetUrl_result structs, Protocol oprot){
				
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
			
			
			public void Validate(getFacesetUrl_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSearchResult_resultHelper : TBeanSerializer<getSearchResult_result>
		{
			
			public static getSearchResult_resultHelper OBJ = new getSearchResult_resultHelper();
			
			public static getSearchResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSearchResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.arplatform.face.service.CompareResponse value;
					
					value = new com.vip.arplatform.face.service.CompareResponse();
					com.vip.arplatform.face.service.CompareResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSearchResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.arplatform.face.service.CompareResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSearchResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSearchWithFeaturesResult_resultHelper : TBeanSerializer<getSearchWithFeaturesResult_result>
		{
			
			public static getSearchWithFeaturesResult_resultHelper OBJ = new getSearchWithFeaturesResult_resultHelper();
			
			public static getSearchWithFeaturesResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSearchWithFeaturesResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.arplatform.face.service.SearchWithFeaturesResultModel value;
					
					value = new com.vip.arplatform.face.service.SearchWithFeaturesResultModel();
					com.vip.arplatform.face.service.SearchWithFeaturesResultModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSearchWithFeaturesResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.arplatform.face.service.SearchWithFeaturesResultModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSearchWithFeaturesResult_result bean){
				
				
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
		
		
		
		
		public class imageStylize_resultHelper : TBeanSerializer<imageStylize_result>
		{
			
			public static imageStylize_resultHelper OBJ = new imageStylize_resultHelper();
			
			public static imageStylize_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(imageStylize_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.arplatform.face.service.ImageStylizationModel value;
					
					value = new com.vip.arplatform.face.service.ImageStylizationModel();
					com.vip.arplatform.face.service.ImageStylizationModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(imageStylize_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.arplatform.face.service.ImageStylizationModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(imageStylize_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class search_resultHelper : TBeanSerializer<search_result>
		{
			
			public static search_resultHelper OBJ = new search_resultHelper();
			
			public static search_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(search_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.arplatform.face.service.CompareResponse value;
					
					value = new com.vip.arplatform.face.service.CompareResponse();
					com.vip.arplatform.face.service.CompareResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(search_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.arplatform.face.service.CompareResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(search_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class searchWithFeatures_resultHelper : TBeanSerializer<searchWithFeatures_result>
		{
			
			public static searchWithFeatures_resultHelper OBJ = new searchWithFeatures_resultHelper();
			
			public static searchWithFeatures_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(searchWithFeatures_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.arplatform.face.service.SearchWithFeaturesResultModel value;
					
					value = new com.vip.arplatform.face.service.SearchWithFeaturesResultModel();
					com.vip.arplatform.face.service.SearchWithFeaturesResultModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(searchWithFeatures_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.arplatform.face.service.SearchWithFeaturesResultModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(searchWithFeatures_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class shapeSimilarity_resultHelper : TBeanSerializer<shapeSimilarity_result>
		{
			
			public static shapeSimilarity_resultHelper OBJ = new shapeSimilarity_resultHelper();
			
			public static shapeSimilarity_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(shapeSimilarity_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.arplatform.face.service.ShapeSimilarityModel value;
					
					value = new com.vip.arplatform.face.service.ShapeSimilarityModel();
					com.vip.arplatform.face.service.ShapeSimilarityModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(shapeSimilarity_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.arplatform.face.service.ShapeSimilarityModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(shapeSimilarity_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class FaceServiceClient : OspRestStub , FaceService  {
			
			
			public FaceServiceClient():base("com.vip.arplatform.face.service.FaceService","1.0.0") {
				
				
			}
			
			
			
			public com.vip.arplatform.face.service.CartoonModel faceCartoon(string imageInPath_,string faceUrl_,string facelessUrl_,int? cr_,int? cb_,string point_) {
				
				send_faceCartoon(imageInPath_,faceUrl_,facelessUrl_,cr_,cb_,point_);
				return recv_faceCartoon(); 
				
			}
			
			
			private void send_faceCartoon(string imageInPath_,string faceUrl_,string facelessUrl_,int? cr_,int? cb_,string point_){
				
				InitInvocation("faceCartoon");
				
				faceCartoon_args args = new faceCartoon_args();
				args.SetImageInPath(imageInPath_);
				args.SetFaceUrl(faceUrl_);
				args.SetFacelessUrl(facelessUrl_);
				args.SetCr(cr_);
				args.SetCb(cb_);
				args.SetPoint(point_);
				
				SendBase(args, faceCartoon_argsHelper.getInstance());
			}
			
			
			private com.vip.arplatform.face.service.CartoonModel recv_faceCartoon(){
				
				faceCartoon_result result = new faceCartoon_result();
				ReceiveBase(result, faceCartoon_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.arplatform.face.service.FacesetCompareResult faceSimilarity(string image_url1_,string image_url2_) {
				
				send_faceSimilarity(image_url1_,image_url2_);
				return recv_faceSimilarity(); 
				
			}
			
			
			private void send_faceSimilarity(string image_url1_,string image_url2_){
				
				InitInvocation("faceSimilarity");
				
				faceSimilarity_args args = new faceSimilarity_args();
				args.SetImage_url1(image_url1_);
				args.SetImage_url2(image_url2_);
				
				SendBase(args, faceSimilarity_argsHelper.getInstance());
			}
			
			
			private com.vip.arplatform.face.service.FacesetCompareResult recv_faceSimilarity(){
				
				faceSimilarity_result result = new faceSimilarity_result();
				ReceiveBase(result, faceSimilarity_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.arplatform.face.service.FacesetCreateModel facesetCreate(string faceset_key_,string image_urls_) {
				
				send_facesetCreate(faceset_key_,image_urls_);
				return recv_facesetCreate(); 
				
			}
			
			
			private void send_facesetCreate(string faceset_key_,string image_urls_){
				
				InitInvocation("facesetCreate");
				
				facesetCreate_args args = new facesetCreate_args();
				args.SetFaceset_key(faceset_key_);
				args.SetImage_urls(image_urls_);
				
				SendBase(args, facesetCreate_argsHelper.getInstance());
			}
			
			
			private com.vip.arplatform.face.service.FacesetCreateModel recv_facesetCreate(){
				
				facesetCreate_result result = new facesetCreate_result();
				ReceiveBase(result, facesetCreate_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<string> facesetDelete(string faceset_key_,string image_urls_) {
				
				send_facesetDelete(faceset_key_,image_urls_);
				return recv_facesetDelete(); 
				
			}
			
			
			private void send_facesetDelete(string faceset_key_,string image_urls_){
				
				InitInvocation("facesetDelete");
				
				facesetDelete_args args = new facesetDelete_args();
				args.SetFaceset_key(faceset_key_);
				args.SetImage_urls(image_urls_);
				
				SendBase(args, facesetDelete_argsHelper.getInstance());
			}
			
			
			private List<string> recv_facesetDelete(){
				
				facesetDelete_result result = new facesetDelete_result();
				ReceiveBase(result, facesetDelete_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.arplatform.face.service.FacesetCreateModel facesetStatus(string faceset_key_) {
				
				send_facesetStatus(faceset_key_);
				return recv_facesetStatus(); 
				
			}
			
			
			private void send_facesetStatus(string faceset_key_){
				
				InitInvocation("facesetStatus");
				
				facesetStatus_args args = new facesetStatus_args();
				args.SetFaceset_key(faceset_key_);
				
				SendBase(args, facesetStatus_argsHelper.getInstance());
			}
			
			
			private com.vip.arplatform.face.service.FacesetCreateModel recv_facesetStatus(){
				
				facesetStatus_result result = new facesetStatus_result();
				ReceiveBase(result, facesetStatus_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.arplatform.face.service.FacesetCreateModel facesetUpdate(string faceset_key_,string image_urls_) {
				
				send_facesetUpdate(faceset_key_,image_urls_);
				return recv_facesetUpdate(); 
				
			}
			
			
			private void send_facesetUpdate(string faceset_key_,string image_urls_){
				
				InitInvocation("facesetUpdate");
				
				facesetUpdate_args args = new facesetUpdate_args();
				args.SetFaceset_key(faceset_key_);
				args.SetImage_urls(image_urls_);
				
				SendBase(args, facesetUpdate_argsHelper.getInstance());
			}
			
			
			private com.vip.arplatform.face.service.FacesetCreateModel recv_facesetUpdate(){
				
				facesetUpdate_result result = new facesetUpdate_result();
				ReceiveBase(result, facesetUpdate_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.arplatform.face.service.CrCbModel getCrCb(string facelessUrl_,string point_) {
				
				send_getCrCb(facelessUrl_,point_);
				return recv_getCrCb(); 
				
			}
			
			
			private void send_getCrCb(string facelessUrl_,string point_){
				
				InitInvocation("getCrCb");
				
				getCrCb_args args = new getCrCb_args();
				args.SetFacelessUrl(facelessUrl_);
				args.SetPoint(point_);
				
				SendBase(args, getCrCb_argsHelper.getInstance());
			}
			
			
			private com.vip.arplatform.face.service.CrCbModel recv_getCrCb(){
				
				getCrCb_result result = new getCrCb_result();
				ReceiveBase(result, getCrCb_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<string> getFacesetUrl(string faceset_key_) {
				
				send_getFacesetUrl(faceset_key_);
				return recv_getFacesetUrl(); 
				
			}
			
			
			private void send_getFacesetUrl(string faceset_key_){
				
				InitInvocation("getFacesetUrl");
				
				getFacesetUrl_args args = new getFacesetUrl_args();
				args.SetFaceset_key(faceset_key_);
				
				SendBase(args, getFacesetUrl_argsHelper.getInstance());
			}
			
			
			private List<string> recv_getFacesetUrl(){
				
				getFacesetUrl_result result = new getFacesetUrl_result();
				ReceiveBase(result, getFacesetUrl_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.arplatform.face.service.CompareResponse getSearchResult(string token_) {
				
				send_getSearchResult(token_);
				return recv_getSearchResult(); 
				
			}
			
			
			private void send_getSearchResult(string token_){
				
				InitInvocation("getSearchResult");
				
				getSearchResult_args args = new getSearchResult_args();
				args.SetToken(token_);
				
				SendBase(args, getSearchResult_argsHelper.getInstance());
			}
			
			
			private com.vip.arplatform.face.service.CompareResponse recv_getSearchResult(){
				
				getSearchResult_result result = new getSearchResult_result();
				ReceiveBase(result, getSearchResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.arplatform.face.service.SearchWithFeaturesResultModel getSearchWithFeaturesResult(com.vip.arplatform.face.service.GetSearchWithFeaturesParamResultModel getSearchWithFeaturesParamResultModel_) {
				
				send_getSearchWithFeaturesResult(getSearchWithFeaturesParamResultModel_);
				return recv_getSearchWithFeaturesResult(); 
				
			}
			
			
			private void send_getSearchWithFeaturesResult(com.vip.arplatform.face.service.GetSearchWithFeaturesParamResultModel getSearchWithFeaturesParamResultModel_){
				
				InitInvocation("getSearchWithFeaturesResult");
				
				getSearchWithFeaturesResult_args args = new getSearchWithFeaturesResult_args();
				args.SetGetSearchWithFeaturesParamResultModel(getSearchWithFeaturesParamResultModel_);
				
				SendBase(args, getSearchWithFeaturesResult_argsHelper.getInstance());
			}
			
			
			private com.vip.arplatform.face.service.SearchWithFeaturesResultModel recv_getSearchWithFeaturesResult(){
				
				getSearchWithFeaturesResult_result result = new getSearchWithFeaturesResult_result();
				ReceiveBase(result, getSearchWithFeaturesResult_resultHelper.getInstance());
				
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
			
			
			public com.vip.arplatform.face.service.ImageStylizationModel imageStylize(string imageInPath_,string type_) {
				
				send_imageStylize(imageInPath_,type_);
				return recv_imageStylize(); 
				
			}
			
			
			private void send_imageStylize(string imageInPath_,string type_){
				
				InitInvocation("imageStylize");
				
				imageStylize_args args = new imageStylize_args();
				args.SetImageInPath(imageInPath_);
				args.SetType(type_);
				
				SendBase(args, imageStylize_argsHelper.getInstance());
			}
			
			
			private com.vip.arplatform.face.service.ImageStylizationModel recv_imageStylize(){
				
				imageStylize_result result = new imageStylize_result();
				ReceiveBase(result, imageStylize_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.arplatform.face.service.CompareResponse search(string faceset_key_,string image_url_,int results_count_,int asynchronization_) {
				
				send_search(faceset_key_,image_url_,results_count_,asynchronization_);
				return recv_search(); 
				
			}
			
			
			private void send_search(string faceset_key_,string image_url_,int results_count_,int asynchronization_){
				
				InitInvocation("search");
				
				search_args args = new search_args();
				args.SetFaceset_key(faceset_key_);
				args.SetImage_url(image_url_);
				args.SetResults_count(results_count_);
				args.SetAsynchronization(asynchronization_);
				
				SendBase(args, search_argsHelper.getInstance());
			}
			
			
			private com.vip.arplatform.face.service.CompareResponse recv_search(){
				
				search_result result = new search_result();
				ReceiveBase(result, search_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.arplatform.face.service.SearchWithFeaturesResultModel searchWithFeatures(com.vip.arplatform.face.service.SearchWithFeaturesParamModel searchWithFeaturesParamModel_) {
				
				send_searchWithFeatures(searchWithFeaturesParamModel_);
				return recv_searchWithFeatures(); 
				
			}
			
			
			private void send_searchWithFeatures(com.vip.arplatform.face.service.SearchWithFeaturesParamModel searchWithFeaturesParamModel_){
				
				InitInvocation("searchWithFeatures");
				
				searchWithFeatures_args args = new searchWithFeatures_args();
				args.SetSearchWithFeaturesParamModel(searchWithFeaturesParamModel_);
				
				SendBase(args, searchWithFeatures_argsHelper.getInstance());
			}
			
			
			private com.vip.arplatform.face.service.SearchWithFeaturesResultModel recv_searchWithFeatures(){
				
				searchWithFeatures_result result = new searchWithFeatures_result();
				ReceiveBase(result, searchWithFeatures_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.arplatform.face.service.ShapeSimilarityModel shapeSimilarity(string img_src_,string img_target_) {
				
				send_shapeSimilarity(img_src_,img_target_);
				return recv_shapeSimilarity(); 
				
			}
			
			
			private void send_shapeSimilarity(string img_src_,string img_target_){
				
				InitInvocation("shapeSimilarity");
				
				shapeSimilarity_args args = new shapeSimilarity_args();
				args.SetImg_src(img_src_);
				args.SetImg_target(img_target_);
				
				SendBase(args, shapeSimilarity_argsHelper.getInstance());
			}
			
			
			private com.vip.arplatform.face.service.ShapeSimilarityModel recv_shapeSimilarity(){
				
				shapeSimilarity_result result = new shapeSimilarity_result();
				ReceiveBase(result, shapeSimilarity_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}