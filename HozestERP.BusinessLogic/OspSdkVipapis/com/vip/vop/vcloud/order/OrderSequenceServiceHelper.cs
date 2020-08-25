using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.vop.vcloud.order{
	
	
	public class OrderSequenceServiceHelper {
		
		
		
		public class getLastUpdateTime_args {
			
			///<summary>
			///</summary>
			
			private string name_;
			
			public string GetName(){
				return this.name_;
			}
			
			public void SetName(string value){
				this.name_ = value;
			}
			
		}
		
		
		
		
		public class getNextId_args {
			
			///<summary>
			///</summary>
			
			private string name_;
			
			public string GetName(){
				return this.name_;
			}
			
			public void SetName(string value){
				this.name_ = value;
			}
			
		}
		
		
		
		
		public class getNextPid_args {
			
			///<summary>
			///</summary>
			
			private string name_;
			
			public string GetName(){
				return this.name_;
			}
			
			public void SetName(string value){
				this.name_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class insertDieselOrderRecents_args {
			
			///<summary>
			///</summary>
			
			private List<com.vip.vop.vcloud.order.DieselOrderRecents> list_;
			
			public List<com.vip.vop.vcloud.order.DieselOrderRecents> GetList(){
				return this.list_;
			}
			
			public void SetList(List<com.vip.vop.vcloud.order.DieselOrderRecents> value){
				this.list_ = value;
			}
			
		}
		
		
		
		
		public class updateLastUpdateTime_args {
			
			///<summary>
			///</summary>
			
			private com.vip.vop.vcloud.order.OrderSequence sequence_;
			
			public com.vip.vop.vcloud.order.OrderSequence GetSequence(){
				return this.sequence_;
			}
			
			public void SetSequence(com.vip.vop.vcloud.order.OrderSequence value){
				this.sequence_ = value;
			}
			
		}
		
		
		
		
		public class updateSequence_args {
			
			///<summary>
			///</summary>
			
			private com.vip.vop.vcloud.order.OrderSequence sequence_;
			
			public com.vip.vop.vcloud.order.OrderSequence GetSequence(){
				return this.sequence_;
			}
			
			public void SetSequence(com.vip.vop.vcloud.order.OrderSequence value){
				this.sequence_ = value;
			}
			
		}
		
		
		
		
		public class getLastUpdateTime_result {
			
			///<summary>
			///</summary>
			
			private com.vip.vop.vcloud.order.OrderSequence success_;
			
			public com.vip.vop.vcloud.order.OrderSequence GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.vop.vcloud.order.OrderSequence value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getNextId_result {
			
			///<summary>
			///</summary>
			
			private com.vip.vop.vcloud.order.OrderSequence success_;
			
			public com.vip.vop.vcloud.order.OrderSequence GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.vop.vcloud.order.OrderSequence value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getNextPid_result {
			
			///<summary>
			///</summary>
			
			private int? success_;
			
			public int? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(int? value){
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
		
		
		
		
		public class insertDieselOrderRecents_result {
			
			
		}
		
		
		
		
		public class updateLastUpdateTime_result {
			
			
		}
		
		
		
		
		public class updateSequence_result {
			
			
		}
		
		
		
		
		
		public class getLastUpdateTime_argsHelper : TBeanSerializer<getLastUpdateTime_args>
		{
			
			public static getLastUpdateTime_argsHelper OBJ = new getLastUpdateTime_argsHelper();
			
			public static getLastUpdateTime_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getLastUpdateTime_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetName(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getLastUpdateTime_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetName() != null) {
					
					oprot.WriteFieldBegin("name");
					oprot.WriteString(structs.GetName());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("name can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getLastUpdateTime_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getNextId_argsHelper : TBeanSerializer<getNextId_args>
		{
			
			public static getNextId_argsHelper OBJ = new getNextId_argsHelper();
			
			public static getNextId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getNextId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetName(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getNextId_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetName() != null) {
					
					oprot.WriteFieldBegin("name");
					oprot.WriteString(structs.GetName());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("name can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getNextId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getNextPid_argsHelper : TBeanSerializer<getNextPid_args>
		{
			
			public static getNextPid_argsHelper OBJ = new getNextPid_argsHelper();
			
			public static getNextPid_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getNextPid_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetName(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getNextPid_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetName() != null) {
					
					oprot.WriteFieldBegin("name");
					oprot.WriteString(structs.GetName());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("name can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getNextPid_args bean){
				
				
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
		
		
		
		
		public class insertDieselOrderRecents_argsHelper : TBeanSerializer<insertDieselOrderRecents_args>
		{
			
			public static insertDieselOrderRecents_argsHelper OBJ = new insertDieselOrderRecents_argsHelper();
			
			public static insertDieselOrderRecents_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(insertDieselOrderRecents_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.vop.vcloud.order.DieselOrderRecents> value;
					
					value = new List<com.vip.vop.vcloud.order.DieselOrderRecents>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.vop.vcloud.order.DieselOrderRecents elem0;
							
							elem0 = new com.vip.vop.vcloud.order.DieselOrderRecents();
							com.vip.vop.vcloud.order.DieselOrderRecentsHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(insertDieselOrderRecents_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetList() != null) {
					
					oprot.WriteFieldBegin("list");
					
					oprot.WriteListBegin();
					foreach(com.vip.vop.vcloud.order.DieselOrderRecents _item0 in structs.GetList()){
						
						
						com.vip.vop.vcloud.order.DieselOrderRecentsHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("list can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(insertDieselOrderRecents_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateLastUpdateTime_argsHelper : TBeanSerializer<updateLastUpdateTime_args>
		{
			
			public static updateLastUpdateTime_argsHelper OBJ = new updateLastUpdateTime_argsHelper();
			
			public static updateLastUpdateTime_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateLastUpdateTime_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.order.OrderSequence value;
					
					value = new com.vip.vop.vcloud.order.OrderSequence();
					com.vip.vop.vcloud.order.OrderSequenceHelper.getInstance().Read(value, iprot);
					
					structs.SetSequence(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateLastUpdateTime_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSequence() != null) {
					
					oprot.WriteFieldBegin("sequence");
					
					com.vip.vop.vcloud.order.OrderSequenceHelper.getInstance().Write(structs.GetSequence(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateLastUpdateTime_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSequence_argsHelper : TBeanSerializer<updateSequence_args>
		{
			
			public static updateSequence_argsHelper OBJ = new updateSequence_argsHelper();
			
			public static updateSequence_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSequence_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.order.OrderSequence value;
					
					value = new com.vip.vop.vcloud.order.OrderSequence();
					com.vip.vop.vcloud.order.OrderSequenceHelper.getInstance().Read(value, iprot);
					
					structs.SetSequence(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSequence_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSequence() != null) {
					
					oprot.WriteFieldBegin("sequence");
					
					com.vip.vop.vcloud.order.OrderSequenceHelper.getInstance().Write(structs.GetSequence(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSequence_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getLastUpdateTime_resultHelper : TBeanSerializer<getLastUpdateTime_result>
		{
			
			public static getLastUpdateTime_resultHelper OBJ = new getLastUpdateTime_resultHelper();
			
			public static getLastUpdateTime_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getLastUpdateTime_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.order.OrderSequence value;
					
					value = new com.vip.vop.vcloud.order.OrderSequence();
					com.vip.vop.vcloud.order.OrderSequenceHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getLastUpdateTime_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.vop.vcloud.order.OrderSequenceHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getLastUpdateTime_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getNextId_resultHelper : TBeanSerializer<getNextId_result>
		{
			
			public static getNextId_resultHelper OBJ = new getNextId_resultHelper();
			
			public static getNextId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getNextId_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.order.OrderSequence value;
					
					value = new com.vip.vop.vcloud.order.OrderSequence();
					com.vip.vop.vcloud.order.OrderSequenceHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getNextId_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.vop.vcloud.order.OrderSequenceHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getNextId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getNextPid_resultHelper : TBeanSerializer<getNextPid_result>
		{
			
			public static getNextPid_resultHelper OBJ = new getNextPid_resultHelper();
			
			public static getNextPid_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getNextPid_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getNextPid_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI32((int)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getNextPid_result bean){
				
				
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
		
		
		
		
		public class insertDieselOrderRecents_resultHelper : TBeanSerializer<insertDieselOrderRecents_result>
		{
			
			public static insertDieselOrderRecents_resultHelper OBJ = new insertDieselOrderRecents_resultHelper();
			
			public static insertDieselOrderRecents_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(insertDieselOrderRecents_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(insertDieselOrderRecents_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(insertDieselOrderRecents_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateLastUpdateTime_resultHelper : TBeanSerializer<updateLastUpdateTime_result>
		{
			
			public static updateLastUpdateTime_resultHelper OBJ = new updateLastUpdateTime_resultHelper();
			
			public static updateLastUpdateTime_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateLastUpdateTime_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateLastUpdateTime_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateLastUpdateTime_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSequence_resultHelper : TBeanSerializer<updateSequence_result>
		{
			
			public static updateSequence_resultHelper OBJ = new updateSequence_resultHelper();
			
			public static updateSequence_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSequence_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSequence_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSequence_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class OrderSequenceServiceClient : OspRestStub , OrderSequenceService  {
			
			
			public OrderSequenceServiceClient():base("com.vip.vop.vcloud.order.OrderSequenceService","1.0.0") {
				
				
			}
			
			
			
			public com.vip.vop.vcloud.order.OrderSequence getLastUpdateTime(string name_) {
				
				send_getLastUpdateTime(name_);
				return recv_getLastUpdateTime(); 
				
			}
			
			
			private void send_getLastUpdateTime(string name_){
				
				InitInvocation("getLastUpdateTime");
				
				getLastUpdateTime_args args = new getLastUpdateTime_args();
				args.SetName(name_);
				
				SendBase(args, getLastUpdateTime_argsHelper.getInstance());
			}
			
			
			private com.vip.vop.vcloud.order.OrderSequence recv_getLastUpdateTime(){
				
				getLastUpdateTime_result result = new getLastUpdateTime_result();
				ReceiveBase(result, getLastUpdateTime_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.vop.vcloud.order.OrderSequence getNextId(string name_) {
				
				send_getNextId(name_);
				return recv_getNextId(); 
				
			}
			
			
			private void send_getNextId(string name_){
				
				InitInvocation("getNextId");
				
				getNextId_args args = new getNextId_args();
				args.SetName(name_);
				
				SendBase(args, getNextId_argsHelper.getInstance());
			}
			
			
			private com.vip.vop.vcloud.order.OrderSequence recv_getNextId(){
				
				getNextId_result result = new getNextId_result();
				ReceiveBase(result, getNextId_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public int? getNextPid(string name_) {
				
				send_getNextPid(name_);
				return recv_getNextPid(); 
				
			}
			
			
			private void send_getNextPid(string name_){
				
				InitInvocation("getNextPid");
				
				getNextPid_args args = new getNextPid_args();
				args.SetName(name_);
				
				SendBase(args, getNextPid_argsHelper.getInstance());
			}
			
			
			private int? recv_getNextPid(){
				
				getNextPid_result result = new getNextPid_result();
				ReceiveBase(result, getNextPid_resultHelper.getInstance());
				
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
			
			
			public void insertDieselOrderRecents(List<com.vip.vop.vcloud.order.DieselOrderRecents> list_) {
				
				send_insertDieselOrderRecents(list_);
				recv_insertDieselOrderRecents();
				
			}
			
			
			private void send_insertDieselOrderRecents(List<com.vip.vop.vcloud.order.DieselOrderRecents> list_){
				
				InitInvocation("insertDieselOrderRecents");
				
				insertDieselOrderRecents_args args = new insertDieselOrderRecents_args();
				args.SetList(list_);
				
				SendBase(args, insertDieselOrderRecents_argsHelper.getInstance());
			}
			
			
			private void recv_insertDieselOrderRecents(){
				
				insertDieselOrderRecents_result result = new insertDieselOrderRecents_result();
				ReceiveBase(result, insertDieselOrderRecents_resultHelper.getInstance());
				
				
			}
			
			
			public void updateLastUpdateTime(com.vip.vop.vcloud.order.OrderSequence sequence_) {
				
				send_updateLastUpdateTime(sequence_);
				recv_updateLastUpdateTime();
				
			}
			
			
			private void send_updateLastUpdateTime(com.vip.vop.vcloud.order.OrderSequence sequence_){
				
				InitInvocation("updateLastUpdateTime");
				
				updateLastUpdateTime_args args = new updateLastUpdateTime_args();
				args.SetSequence(sequence_);
				
				SendBase(args, updateLastUpdateTime_argsHelper.getInstance());
			}
			
			
			private void recv_updateLastUpdateTime(){
				
				updateLastUpdateTime_result result = new updateLastUpdateTime_result();
				ReceiveBase(result, updateLastUpdateTime_resultHelper.getInstance());
				
				
			}
			
			
			public void updateSequence(com.vip.vop.vcloud.order.OrderSequence sequence_) {
				
				send_updateSequence(sequence_);
				recv_updateSequence();
				
			}
			
			
			private void send_updateSequence(com.vip.vop.vcloud.order.OrderSequence sequence_){
				
				InitInvocation("updateSequence");
				
				updateSequence_args args = new updateSequence_args();
				args.SetSequence(sequence_);
				
				SendBase(args, updateSequence_argsHelper.getInstance());
			}
			
			
			private void recv_updateSequence(){
				
				updateSequence_result result = new updateSequence_result();
				ReceiveBase(result, updateSequence_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}