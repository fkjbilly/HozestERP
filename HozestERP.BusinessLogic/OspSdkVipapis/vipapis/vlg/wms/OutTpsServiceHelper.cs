using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.vlg.wms{
	
	
	public class OutTpsServiceHelper {
		
		
		
		public class callbackOutShipContainerResult_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 消息编号集合
			///</summary>
			
			private List<string> msgIds_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<string> GetMsgIds(){
				return this.msgIds_;
			}
			
			public void SetMsgIds(List<string> value){
				this.msgIds_ = value;
			}
			
		}
		
		
		
		
		public class getOutReturnOrderPackageResult_args {
			
			///<summary>
			/// 调用端名称,默认：TPS
			///</summary>
			
			private string appName_;
			
			///<summary>
			/// 当前最大记录ID
			///</summary>
			
			private long? maxId_;
			
			///<summary>
			/// 最大拉取记录数，此值不能大于500
			///</summary>
			
			private int? maxSize_;
			
			public string GetAppName(){
				return this.appName_;
			}
			
			public void SetAppName(string value){
				this.appName_ = value;
			}
			public long? GetMaxId(){
				return this.maxId_;
			}
			
			public void SetMaxId(long? value){
				this.maxId_ = value;
			}
			public int? GetMaxSize(){
				return this.maxSize_;
			}
			
			public void SetMaxSize(int? value){
				this.maxSize_ = value;
			}
			
		}
		
		
		
		
		public class getOutShipContainerResult_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 请求数据条数，默认：200，最大2000条
			///</summary>
			
			private int? pageSize_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public int? GetPageSize(){
				return this.pageSize_;
			}
			
			public void SetPageSize(int? value){
				this.pageSize_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class pushOutReturnOrderPackage_args {
			
			///<summary>
			/// 客退大包信息
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackage outReturnOrderPackage_;
			
			public com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackage GetOutReturnOrderPackage(){
				return this.outReturnOrderPackage_;
			}
			
			public void SetOutReturnOrderPackage(com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackage value){
				this.outReturnOrderPackage_ = value;
			}
			
		}
		
		
		
		
		public class pushOutShipContainer_args {
			
			///<summary>
			/// 系统KEY
			///</summary>
			
			private string sysKey_;
			
			///<summary>
			/// 调用方的仓库编码
			///</summary>
			
			private string warehouse_;
			
			///<summary>
			/// 分拨指令集合
			///</summary>
			
			private List<com.vip.sce.vlg.osp.wms.service.OutShipContainer> outShipContainers_;
			
			public string GetSysKey(){
				return this.sysKey_;
			}
			
			public void SetSysKey(string value){
				this.sysKey_ = value;
			}
			public string GetWarehouse(){
				return this.warehouse_;
			}
			
			public void SetWarehouse(string value){
				this.warehouse_ = value;
			}
			public List<com.vip.sce.vlg.osp.wms.service.OutShipContainer> GetOutShipContainers(){
				return this.outShipContainers_;
			}
			
			public void SetOutShipContainers(List<com.vip.sce.vlg.osp.wms.service.OutShipContainer> value){
				this.outShipContainers_ = value;
			}
			
		}
		
		
		
		
		public class callbackOutShipContainerResult_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOutReturnOrderPackageResult_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.GetOutReturnOrderPackageResultResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.GetOutReturnOrderPackageResultResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.GetOutReturnOrderPackageResultResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOutShipContainerResult_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.GetOutShipContainerResultResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.GetOutShipContainerResultResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.GetOutShipContainerResultResponse value){
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
		
		
		
		
		public class pushOutReturnOrderPackage_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class pushOutShipContainer_result {
			
			///<summary>
			///</summary>
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse success_;
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.sce.vlg.osp.wms.service.PostResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class callbackOutShipContainerResult_argsHelper : TBeanSerializer<callbackOutShipContainerResult_args>
		{
			
			public static callbackOutShipContainerResult_argsHelper OBJ = new callbackOutShipContainerResult_argsHelper();
			
			public static callbackOutShipContainerResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(callbackOutShipContainerResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<string> value;
					
					value = new List<string>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							string elem1;
							elem1 = iprot.ReadString();
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetMsgIds(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(callbackOutShipContainerResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetMsgIds() != null) {
					
					oprot.WriteFieldBegin("msgIds");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetMsgIds()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("msgIds can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(callbackOutShipContainerResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOutReturnOrderPackageResult_argsHelper : TBeanSerializer<getOutReturnOrderPackageResult_args>
		{
			
			public static getOutReturnOrderPackageResult_argsHelper OBJ = new getOutReturnOrderPackageResult_argsHelper();
			
			public static getOutReturnOrderPackageResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOutReturnOrderPackageResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetAppName(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetMaxId(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetMaxSize(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOutReturnOrderPackageResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetAppName() != null) {
					
					oprot.WriteFieldBegin("appName");
					oprot.WriteString(structs.GetAppName());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("appName can not be null!");
				}
				
				
				if(structs.GetMaxId() != null) {
					
					oprot.WriteFieldBegin("maxId");
					oprot.WriteI64((long)structs.GetMaxId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("maxId can not be null!");
				}
				
				
				if(structs.GetMaxSize() != null) {
					
					oprot.WriteFieldBegin("maxSize");
					oprot.WriteI32((int)structs.GetMaxSize()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("maxSize can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOutReturnOrderPackageResult_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOutShipContainerResult_argsHelper : TBeanSerializer<getOutShipContainerResult_args>
		{
			
			public static getOutShipContainerResult_argsHelper OBJ = new getOutShipContainerResult_argsHelper();
			
			public static getOutShipContainerResult_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOutShipContainerResult_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetPageSize(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOutShipContainerResult_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetPageSize() != null) {
					
					oprot.WriteFieldBegin("pageSize");
					oprot.WriteI32((int)structs.GetPageSize()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("pageSize can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOutShipContainerResult_args bean){
				
				
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
		
		
		
		
		public class pushOutReturnOrderPackage_argsHelper : TBeanSerializer<pushOutReturnOrderPackage_args>
		{
			
			public static pushOutReturnOrderPackage_argsHelper OBJ = new pushOutReturnOrderPackage_argsHelper();
			
			public static pushOutReturnOrderPackage_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOutReturnOrderPackage_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackage value;
					
					value = new com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackage();
					com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackageHelper.getInstance().Read(value, iprot);
					
					structs.SetOutReturnOrderPackage(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushOutReturnOrderPackage_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetOutReturnOrderPackage() != null) {
					
					oprot.WriteFieldBegin("outReturnOrderPackage");
					
					com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackageHelper.getInstance().Write(structs.GetOutReturnOrderPackage(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("outReturnOrderPackage can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushOutReturnOrderPackage_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushOutShipContainer_argsHelper : TBeanSerializer<pushOutShipContainer_args>
		{
			
			public static pushOutShipContainer_argsHelper OBJ = new pushOutShipContainer_argsHelper();
			
			public static pushOutShipContainer_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOutShipContainer_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetSysKey(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetWarehouse(value);
				}
				
				
				
				
				
				if(true){
					
					List<com.vip.sce.vlg.osp.wms.service.OutShipContainer> value;
					
					value = new List<com.vip.sce.vlg.osp.wms.service.OutShipContainer>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.sce.vlg.osp.wms.service.OutShipContainer elem0;
							
							elem0 = new com.vip.sce.vlg.osp.wms.service.OutShipContainer();
							com.vip.sce.vlg.osp.wms.service.OutShipContainerHelper.getInstance().Read(elem0, iprot);
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetOutShipContainers(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushOutShipContainer_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSysKey() != null) {
					
					oprot.WriteFieldBegin("sysKey");
					oprot.WriteString(structs.GetSysKey());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sysKey can not be null!");
				}
				
				
				if(structs.GetWarehouse() != null) {
					
					oprot.WriteFieldBegin("warehouse");
					oprot.WriteString(structs.GetWarehouse());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("warehouse can not be null!");
				}
				
				
				if(structs.GetOutShipContainers() != null) {
					
					oprot.WriteFieldBegin("outShipContainers");
					
					oprot.WriteListBegin();
					foreach(com.vip.sce.vlg.osp.wms.service.OutShipContainer _item0 in structs.GetOutShipContainers()){
						
						
						com.vip.sce.vlg.osp.wms.service.OutShipContainerHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("outShipContainers can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushOutShipContainer_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class callbackOutShipContainerResult_resultHelper : TBeanSerializer<callbackOutShipContainerResult_result>
		{
			
			public static callbackOutShipContainerResult_resultHelper OBJ = new callbackOutShipContainerResult_resultHelper();
			
			public static callbackOutShipContainerResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(callbackOutShipContainerResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(callbackOutShipContainerResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(callbackOutShipContainerResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOutReturnOrderPackageResult_resultHelper : TBeanSerializer<getOutReturnOrderPackageResult_result>
		{
			
			public static getOutReturnOrderPackageResult_resultHelper OBJ = new getOutReturnOrderPackageResult_resultHelper();
			
			public static getOutReturnOrderPackageResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOutReturnOrderPackageResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.GetOutReturnOrderPackageResultResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.GetOutReturnOrderPackageResultResponse();
					com.vip.sce.vlg.osp.wms.service.GetOutReturnOrderPackageResultResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOutReturnOrderPackageResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.GetOutReturnOrderPackageResultResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOutReturnOrderPackageResult_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOutShipContainerResult_resultHelper : TBeanSerializer<getOutShipContainerResult_result>
		{
			
			public static getOutShipContainerResult_resultHelper OBJ = new getOutShipContainerResult_resultHelper();
			
			public static getOutShipContainerResult_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOutShipContainerResult_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.GetOutShipContainerResultResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.GetOutShipContainerResultResponse();
					com.vip.sce.vlg.osp.wms.service.GetOutShipContainerResultResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOutShipContainerResult_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.GetOutShipContainerResultResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOutShipContainerResult_result bean){
				
				
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
		
		
		
		
		public class pushOutReturnOrderPackage_resultHelper : TBeanSerializer<pushOutReturnOrderPackage_result>
		{
			
			public static pushOutReturnOrderPackage_resultHelper OBJ = new pushOutReturnOrderPackage_resultHelper();
			
			public static pushOutReturnOrderPackage_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOutReturnOrderPackage_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushOutReturnOrderPackage_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushOutReturnOrderPackage_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushOutShipContainer_resultHelper : TBeanSerializer<pushOutShipContainer_result>
		{
			
			public static pushOutShipContainer_resultHelper OBJ = new pushOutShipContainer_resultHelper();
			
			public static pushOutShipContainer_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushOutShipContainer_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.sce.vlg.osp.wms.service.PostResponse value;
					
					value = new com.vip.sce.vlg.osp.wms.service.PostResponse();
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushOutShipContainer_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.sce.vlg.osp.wms.service.PostResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushOutShipContainer_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class OutTpsServiceClient : OspRestStub , OutTpsService  {
			
			
			public OutTpsServiceClient():base("vipapis.vlg.wms.OutTpsService","1.0.0") {
				
				
			}
			
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse callbackOutShipContainerResult(string sysKey_,string warehouse_,List<string> msgIds_) {
				
				send_callbackOutShipContainerResult(sysKey_,warehouse_,msgIds_);
				return recv_callbackOutShipContainerResult(); 
				
			}
			
			
			private void send_callbackOutShipContainerResult(string sysKey_,string warehouse_,List<string> msgIds_){
				
				InitInvocation("callbackOutShipContainerResult");
				
				callbackOutShipContainerResult_args args = new callbackOutShipContainerResult_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetMsgIds(msgIds_);
				
				SendBase(args, callbackOutShipContainerResult_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_callbackOutShipContainerResult(){
				
				callbackOutShipContainerResult_result result = new callbackOutShipContainerResult_result();
				ReceiveBase(result, callbackOutShipContainerResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.GetOutReturnOrderPackageResultResponse getOutReturnOrderPackageResult(string appName_,long maxId_,int maxSize_) {
				
				send_getOutReturnOrderPackageResult(appName_,maxId_,maxSize_);
				return recv_getOutReturnOrderPackageResult(); 
				
			}
			
			
			private void send_getOutReturnOrderPackageResult(string appName_,long maxId_,int maxSize_){
				
				InitInvocation("getOutReturnOrderPackageResult");
				
				getOutReturnOrderPackageResult_args args = new getOutReturnOrderPackageResult_args();
				args.SetAppName(appName_);
				args.SetMaxId(maxId_);
				args.SetMaxSize(maxSize_);
				
				SendBase(args, getOutReturnOrderPackageResult_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.GetOutReturnOrderPackageResultResponse recv_getOutReturnOrderPackageResult(){
				
				getOutReturnOrderPackageResult_result result = new getOutReturnOrderPackageResult_result();
				ReceiveBase(result, getOutReturnOrderPackageResult_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.GetOutShipContainerResultResponse getOutShipContainerResult(string sysKey_,string warehouse_,int pageSize_) {
				
				send_getOutShipContainerResult(sysKey_,warehouse_,pageSize_);
				return recv_getOutShipContainerResult(); 
				
			}
			
			
			private void send_getOutShipContainerResult(string sysKey_,string warehouse_,int pageSize_){
				
				InitInvocation("getOutShipContainerResult");
				
				getOutShipContainerResult_args args = new getOutShipContainerResult_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetPageSize(pageSize_);
				
				SendBase(args, getOutShipContainerResult_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.GetOutShipContainerResultResponse recv_getOutShipContainerResult(){
				
				getOutShipContainerResult_result result = new getOutShipContainerResult_result();
				ReceiveBase(result, getOutShipContainerResult_resultHelper.getInstance());
				
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
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse pushOutReturnOrderPackage(com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackage outReturnOrderPackage_) {
				
				send_pushOutReturnOrderPackage(outReturnOrderPackage_);
				return recv_pushOutReturnOrderPackage(); 
				
			}
			
			
			private void send_pushOutReturnOrderPackage(com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackage outReturnOrderPackage_){
				
				InitInvocation("pushOutReturnOrderPackage");
				
				pushOutReturnOrderPackage_args args = new pushOutReturnOrderPackage_args();
				args.SetOutReturnOrderPackage(outReturnOrderPackage_);
				
				SendBase(args, pushOutReturnOrderPackage_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_pushOutReturnOrderPackage(){
				
				pushOutReturnOrderPackage_result result = new pushOutReturnOrderPackage_result();
				ReceiveBase(result, pushOutReturnOrderPackage_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.sce.vlg.osp.wms.service.PostResponse pushOutShipContainer(string sysKey_,string warehouse_,List<com.vip.sce.vlg.osp.wms.service.OutShipContainer> outShipContainers_) {
				
				send_pushOutShipContainer(sysKey_,warehouse_,outShipContainers_);
				return recv_pushOutShipContainer(); 
				
			}
			
			
			private void send_pushOutShipContainer(string sysKey_,string warehouse_,List<com.vip.sce.vlg.osp.wms.service.OutShipContainer> outShipContainers_){
				
				InitInvocation("pushOutShipContainer");
				
				pushOutShipContainer_args args = new pushOutShipContainer_args();
				args.SetSysKey(sysKey_);
				args.SetWarehouse(warehouse_);
				args.SetOutShipContainers(outShipContainers_);
				
				SendBase(args, pushOutShipContainer_argsHelper.getInstance());
			}
			
			
			private com.vip.sce.vlg.osp.wms.service.PostResponse recv_pushOutShipContainer(){
				
				pushOutShipContainer_result result = new pushOutShipContainer_result();
				ReceiveBase(result, pushOutShipContainer_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}