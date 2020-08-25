using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.vop.vcloud.product{
	
	
	public class DieselPriceSynServiceHelper {
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class processPriceItem_args {
			
			
		}
		
		
		
		
		public class pushPriceToVdg_args {
			
			
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
		
		
		
		
		public class processPriceItem_result {
			
			
		}
		
		
		
		
		public class pushPriceToVdg_result {
			
			
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
		
		
		
		
		public class processPriceItem_argsHelper : TBeanSerializer<processPriceItem_args>
		{
			
			public static processPriceItem_argsHelper OBJ = new processPriceItem_argsHelper();
			
			public static processPriceItem_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(processPriceItem_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(processPriceItem_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(processPriceItem_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushPriceToVdg_argsHelper : TBeanSerializer<pushPriceToVdg_args>
		{
			
			public static pushPriceToVdg_argsHelper OBJ = new pushPriceToVdg_argsHelper();
			
			public static pushPriceToVdg_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushPriceToVdg_args structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushPriceToVdg_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushPriceToVdg_args bean){
				
				
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
		
		
		
		
		public class processPriceItem_resultHelper : TBeanSerializer<processPriceItem_result>
		{
			
			public static processPriceItem_resultHelper OBJ = new processPriceItem_resultHelper();
			
			public static processPriceItem_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(processPriceItem_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(processPriceItem_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(processPriceItem_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushPriceToVdg_resultHelper : TBeanSerializer<pushPriceToVdg_result>
		{
			
			public static pushPriceToVdg_resultHelper OBJ = new pushPriceToVdg_resultHelper();
			
			public static pushPriceToVdg_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushPriceToVdg_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushPriceToVdg_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushPriceToVdg_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class DieselPriceSynServiceClient : OspRestStub , DieselPriceSynService  {
			
			
			public DieselPriceSynServiceClient():base("com.vip.vop.vcloud.product.DieselPriceSynService","1.0.0") {
				
				
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
			
			
			public void processPriceItem() {
				
				send_processPriceItem();
				recv_processPriceItem();
				
			}
			
			
			private void send_processPriceItem(){
				
				InitInvocation("processPriceItem");
				
				processPriceItem_args args = new processPriceItem_args();
				
				SendBase(args, processPriceItem_argsHelper.getInstance());
			}
			
			
			private void recv_processPriceItem(){
				
				processPriceItem_result result = new processPriceItem_result();
				ReceiveBase(result, processPriceItem_resultHelper.getInstance());
				
				
			}
			
			
			public void pushPriceToVdg() {
				
				send_pushPriceToVdg();
				recv_pushPriceToVdg();
				
			}
			
			
			private void send_pushPriceToVdg(){
				
				InitInvocation("pushPriceToVdg");
				
				pushPriceToVdg_args args = new pushPriceToVdg_args();
				
				SendBase(args, pushPriceToVdg_argsHelper.getInstance());
			}
			
			
			private void recv_pushPriceToVdg(){
				
				pushPriceToVdg_result result = new pushPriceToVdg_result();
				ReceiveBase(result, pushPriceToVdg_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}