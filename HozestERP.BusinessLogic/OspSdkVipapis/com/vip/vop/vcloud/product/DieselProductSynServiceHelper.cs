using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.vop.vcloud.product{
	
	
	public class DieselProductSynServiceHelper {
		
		
		
		public class dataMigration_args {
			
			///<summary>
			/// 目标文件bucket名称
			///</summary>
			
			private string bucket_;
			
			///<summary>
			/// 目标文件的key
			///</summary>
			
			private string key_;
			
			public string GetBucket(){
				return this.bucket_;
			}
			
			public void SetBucket(string value){
				this.bucket_ = value;
			}
			public string GetKey(){
				return this.key_;
			}
			
			public void SetKey(string value){
				this.key_ = value;
			}
			
		}
		
		
		
		
		public class download_args {
			
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class processImageItem_args {
			
			
		}
		
		
		
		
		public class processMasterItem_args {
			
			
		}
		
		
		
		
		public class pushProductToVdg_args {
			
			
		}
		
		
		
		
		public class replyDiesel_args {
			
			
		}
		
		
		
		
		public class validateProduct_args {
			
			
		}
		
		
		
		
		public class validateProductByConfig_args {
			
			
		}
		
		
		
		
		public class dataMigration_result {
			
			
		}
		
		
		
		
		public class download_result {
			
			
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
		
		
		
		
		public class processImageItem_result {
			
			
		}
		
		
		
		
		public class processMasterItem_result {
			
			
		}
		
		
		
		
		public class pushProductToVdg_result {
			
			
		}
		
		
		
		
		public class replyDiesel_result {
			
			
		}
		
		
		
		
		public class validateProduct_result {
			
			
		}
		
		
		
		
		public class validateProductByConfig_result {
			
			
		}
		
		
		
		
		
		public class dataMigration_argsHelper : TBeanSerializer<dataMigration_args>
		{
			
			public static dataMigration_argsHelper OBJ = new dataMigration_argsHelper();
			
			public static dataMigration_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(dataMigration_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetBucket(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetKey(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(dataMigration_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetBucket() != null) {
					
					oprot.WriteFieldBegin("bucket");
					oprot.WriteString(structs.GetBucket());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("bucket can not be null!");
				}
				
				
				if(structs.GetKey() != null) {
					
					oprot.WriteFieldBegin("key");
					oprot.WriteString(structs.GetKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("key can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(dataMigration_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class download_argsHelper : TBeanSerializer<download_args>
		{
			
			public static download_argsHelper OBJ = new download_argsHelper();
			
			public static download_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(download_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(download_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(download_args bean){
				
				
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
		
		
		
		
		public class processImageItem_argsHelper : TBeanSerializer<processImageItem_args>
		{
			
			public static processImageItem_argsHelper OBJ = new processImageItem_argsHelper();
			
			public static processImageItem_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(processImageItem_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(processImageItem_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(processImageItem_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class processMasterItem_argsHelper : TBeanSerializer<processMasterItem_args>
		{
			
			public static processMasterItem_argsHelper OBJ = new processMasterItem_argsHelper();
			
			public static processMasterItem_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(processMasterItem_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(processMasterItem_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(processMasterItem_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushProductToVdg_argsHelper : TBeanSerializer<pushProductToVdg_args>
		{
			
			public static pushProductToVdg_argsHelper OBJ = new pushProductToVdg_argsHelper();
			
			public static pushProductToVdg_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushProductToVdg_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushProductToVdg_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushProductToVdg_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class replyDiesel_argsHelper : TBeanSerializer<replyDiesel_args>
		{
			
			public static replyDiesel_argsHelper OBJ = new replyDiesel_argsHelper();
			
			public static replyDiesel_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(replyDiesel_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(replyDiesel_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(replyDiesel_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class validateProduct_argsHelper : TBeanSerializer<validateProduct_args>
		{
			
			public static validateProduct_argsHelper OBJ = new validateProduct_argsHelper();
			
			public static validateProduct_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(validateProduct_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(validateProduct_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(validateProduct_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class validateProductByConfig_argsHelper : TBeanSerializer<validateProductByConfig_args>
		{
			
			public static validateProductByConfig_argsHelper OBJ = new validateProductByConfig_argsHelper();
			
			public static validateProductByConfig_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(validateProductByConfig_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(validateProductByConfig_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(validateProductByConfig_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class dataMigration_resultHelper : TBeanSerializer<dataMigration_result>
		{
			
			public static dataMigration_resultHelper OBJ = new dataMigration_resultHelper();
			
			public static dataMigration_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(dataMigration_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(dataMigration_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(dataMigration_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class download_resultHelper : TBeanSerializer<download_result>
		{
			
			public static download_resultHelper OBJ = new download_resultHelper();
			
			public static download_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(download_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(download_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(download_result bean){
				
				
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
		
		
		
		
		public class processImageItem_resultHelper : TBeanSerializer<processImageItem_result>
		{
			
			public static processImageItem_resultHelper OBJ = new processImageItem_resultHelper();
			
			public static processImageItem_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(processImageItem_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(processImageItem_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(processImageItem_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class processMasterItem_resultHelper : TBeanSerializer<processMasterItem_result>
		{
			
			public static processMasterItem_resultHelper OBJ = new processMasterItem_resultHelper();
			
			public static processMasterItem_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(processMasterItem_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(processMasterItem_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(processMasterItem_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushProductToVdg_resultHelper : TBeanSerializer<pushProductToVdg_result>
		{
			
			public static pushProductToVdg_resultHelper OBJ = new pushProductToVdg_resultHelper();
			
			public static pushProductToVdg_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushProductToVdg_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushProductToVdg_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushProductToVdg_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class replyDiesel_resultHelper : TBeanSerializer<replyDiesel_result>
		{
			
			public static replyDiesel_resultHelper OBJ = new replyDiesel_resultHelper();
			
			public static replyDiesel_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(replyDiesel_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(replyDiesel_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(replyDiesel_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class validateProduct_resultHelper : TBeanSerializer<validateProduct_result>
		{
			
			public static validateProduct_resultHelper OBJ = new validateProduct_resultHelper();
			
			public static validateProduct_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(validateProduct_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(validateProduct_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(validateProduct_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class validateProductByConfig_resultHelper : TBeanSerializer<validateProductByConfig_result>
		{
			
			public static validateProductByConfig_resultHelper OBJ = new validateProductByConfig_resultHelper();
			
			public static validateProductByConfig_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(validateProductByConfig_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(validateProductByConfig_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(validateProductByConfig_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class DieselProductSynServiceClient : OspRestStub , DieselProductSynService  {
			
			
			public DieselProductSynServiceClient():base("com.vip.vop.vcloud.product.DieselProductSynService","1.0.0") {
				
				
			}
			
			
			
			public void dataMigration(string bucket_,string key_) {
				
				send_dataMigration(bucket_,key_);
				recv_dataMigration();
				
			}
			
			
			private void send_dataMigration(string bucket_,string key_){
				
				InitInvocation("dataMigration");
				
				dataMigration_args args = new dataMigration_args();
				args.SetBucket(bucket_);
				args.SetKey(key_);
				
				SendBase(args, dataMigration_argsHelper.getInstance());
			}
			
			
			private void recv_dataMigration(){
				
				dataMigration_result result = new dataMigration_result();
				ReceiveBase(result, dataMigration_resultHelper.getInstance());
				
				
			}
			
			
			public void download() {
				
				send_download();
				recv_download();
				
			}
			
			
			private void send_download(){
				
				InitInvocation("download");
				
				download_args args = new download_args();
				
				SendBase(args, download_argsHelper.getInstance());
			}
			
			
			private void recv_download(){
				
				download_result result = new download_result();
				ReceiveBase(result, download_resultHelper.getInstance());
				
				
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
			
			
			public void processImageItem() {
				
				send_processImageItem();
				recv_processImageItem();
				
			}
			
			
			private void send_processImageItem(){
				
				InitInvocation("processImageItem");
				
				processImageItem_args args = new processImageItem_args();
				
				SendBase(args, processImageItem_argsHelper.getInstance());
			}
			
			
			private void recv_processImageItem(){
				
				processImageItem_result result = new processImageItem_result();
				ReceiveBase(result, processImageItem_resultHelper.getInstance());
				
				
			}
			
			
			public void processMasterItem() {
				
				send_processMasterItem();
				recv_processMasterItem();
				
			}
			
			
			private void send_processMasterItem(){
				
				InitInvocation("processMasterItem");
				
				processMasterItem_args args = new processMasterItem_args();
				
				SendBase(args, processMasterItem_argsHelper.getInstance());
			}
			
			
			private void recv_processMasterItem(){
				
				processMasterItem_result result = new processMasterItem_result();
				ReceiveBase(result, processMasterItem_resultHelper.getInstance());
				
				
			}
			
			
			public void pushProductToVdg() {
				
				send_pushProductToVdg();
				recv_pushProductToVdg();
				
			}
			
			
			private void send_pushProductToVdg(){
				
				InitInvocation("pushProductToVdg");
				
				pushProductToVdg_args args = new pushProductToVdg_args();
				
				SendBase(args, pushProductToVdg_argsHelper.getInstance());
			}
			
			
			private void recv_pushProductToVdg(){
				
				pushProductToVdg_result result = new pushProductToVdg_result();
				ReceiveBase(result, pushProductToVdg_resultHelper.getInstance());
				
				
			}
			
			
			public void replyDiesel() {
				
				send_replyDiesel();
				recv_replyDiesel();
				
			}
			
			
			private void send_replyDiesel(){
				
				InitInvocation("replyDiesel");
				
				replyDiesel_args args = new replyDiesel_args();
				
				SendBase(args, replyDiesel_argsHelper.getInstance());
			}
			
			
			private void recv_replyDiesel(){
				
				replyDiesel_result result = new replyDiesel_result();
				ReceiveBase(result, replyDiesel_resultHelper.getInstance());
				
				
			}
			
			
			public void validateProduct() {
				
				send_validateProduct();
				recv_validateProduct();
				
			}
			
			
			private void send_validateProduct(){
				
				InitInvocation("validateProduct");
				
				validateProduct_args args = new validateProduct_args();
				
				SendBase(args, validateProduct_argsHelper.getInstance());
			}
			
			
			private void recv_validateProduct(){
				
				validateProduct_result result = new validateProduct_result();
				ReceiveBase(result, validateProduct_resultHelper.getInstance());
				
				
			}
			
			
			public void validateProductByConfig() {
				
				send_validateProductByConfig();
				recv_validateProductByConfig();
				
			}
			
			
			private void send_validateProductByConfig(){
				
				InitInvocation("validateProductByConfig");
				
				validateProductByConfig_args args = new validateProductByConfig_args();
				
				SendBase(args, validateProductByConfig_argsHelper.getInstance());
			}
			
			
			private void recv_validateProductByConfig(){
				
				validateProductByConfig_result result = new validateProductByConfig_result();
				ReceiveBase(result, validateProductByConfig_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}