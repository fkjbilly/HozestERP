using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.schedule{
	
	
	public class ScheduleServiceHelper {
		
		
		
		public class getSchedules_args {
			
			///<summary>
			/// 分仓代码
			/// @sampleValue warehouse warehouse=VIP_NH
			///</summary>
			
			private vipapis.common.Warehouse? warehouse_;
			
			///<summary>
			/// 通过sellTimeFrom筛选，查询开始日期(格式yyyy-MM-dd)
			/// @sampleValue start_date start_date=2014-06-18
			///</summary>
			
			private string start_date_;
			
			///<summary>
			/// 通过sellTimeFrom筛选，查询结束日期(格式yyyy-MM-dd)
			/// @sampleValue end_date end_date=2014-06-20
			///</summary>
			
			private string end_date_;
			
			///<summary>
			/// 档期ID
			/// @sampleValue schedule_id 204565
			///</summary>
			
			private string schedule_id_;
			
			///<summary>
			/// 频道ID
			/// @sampleValue channel_id 10
			///</summary>
			
			private string channel_id_;
			
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
			
			public vipapis.common.Warehouse? GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(vipapis.common.Warehouse? value){
				this.warehouse_ = value;
			}
			public string GetStart_date(){
				return this.start_date_;
			}
			
			public void SetStart_date(string value){
				this.start_date_ = value;
			}
			public string GetEnd_date(){
				return this.end_date_;
			}
			
			public void SetEnd_date(string value){
				this.end_date_ = value;
			}
			public string GetSchedule_id(){
				return this.schedule_id_;
			}
			
			public void SetSchedule_id(string value){
				this.schedule_id_ = value;
			}
			public string GetChannel_id(){
				return this.channel_id_;
			}
			
			public void SetChannel_id(string value){
				this.channel_id_ = value;
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
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getSchedules_result {
			
			///<summary>
			///</summary>
			
			private vipapis.schedule.GetScheduleListResponse success_;
			
			public vipapis.schedule.GetScheduleListResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.schedule.GetScheduleListResponse value){
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
		
		
		
		
		
		public class getSchedules_argsHelper : BeanSerializer<getSchedules_args>
		{
			
			public static getSchedules_argsHelper OBJ = new getSchedules_argsHelper();
			
			public static getSchedules_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSchedules_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.common.Warehouse? value;
					
					value = vipapis.common.WarehouseUtil.FindByName(iprot.ReadString());
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetStart_date(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEnd_date(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSchedule_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetChannel_id(value);
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
			
			
			public void Write(getSchedules_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse().ToString());  
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetStart_date() != null) {
					
					oprot.WriteFieldBegin("start_date");
					oprot.WriteString(structs.GetStart_date());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("start_date can not be null!");
				}
				
				
				if(structs.GetEnd_date() != null) {
					
					oprot.WriteFieldBegin("end_date");
					oprot.WriteString(structs.GetEnd_date());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("end_date can not be null!");
				}
				
				
				if(structs.GetSchedule_id() != null) {
					
					oprot.WriteFieldBegin("schedule_id");
					oprot.WriteString(structs.GetSchedule_id());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetChannel_id() != null) {
					
					oprot.WriteFieldBegin("channel_id");
					oprot.WriteString(structs.GetChannel_id());
					
					oprot.WriteFieldEnd();
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
			
			
			public void Validate(getSchedules_args bean){
				
				
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
		
		
		
		
		public class getSchedules_resultHelper : BeanSerializer<getSchedules_result>
		{
			
			public static getSchedules_resultHelper OBJ = new getSchedules_resultHelper();
			
			public static getSchedules_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSchedules_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.schedule.GetScheduleListResponse value;
					
					value = new vipapis.schedule.GetScheduleListResponse();
					vipapis.schedule.GetScheduleListResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSchedules_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.schedule.GetScheduleListResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSchedules_result bean){
				
				
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
		
		
		
		
		public class ScheduleServiceClient : OspRestStub , ScheduleService  {
			
			
			public ScheduleServiceClient():base("vipapis.schedule.ScheduleService","1.0.1") {
				
				
			}
			
			
			
			public vipapis.schedule.GetScheduleListResponse getSchedules(vipapis.common.Warehouse? warehouse_,string start_date_,string end_date_,string schedule_id_,string channel_id_,int? page_,int? limit_) {
				
				send_getSchedules(warehouse_,start_date_,end_date_,schedule_id_,channel_id_,page_,limit_);
				return recv_getSchedules(); 
				
			}
			
			
			private void send_getSchedules(vipapis.common.Warehouse? warehouse_,string start_date_,string end_date_,string schedule_id_,string channel_id_,int? page_,int? limit_){
				
				InitInvocation("getSchedules");
				
				getSchedules_args args = new getSchedules_args();
				args.SetWarehouse(warehouse_);
				args.SetStart_date(start_date_);
				args.SetEnd_date(end_date_);
				args.SetSchedule_id(schedule_id_);
				args.SetChannel_id(channel_id_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getSchedules_argsHelper.getInstance());
			}
			
			
			private vipapis.schedule.GetScheduleListResponse recv_getSchedules(){
				
				getSchedules_result result = new getSchedules_result();
				ReceiveBase(result, getSchedules_resultHelper.getInstance());
				
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