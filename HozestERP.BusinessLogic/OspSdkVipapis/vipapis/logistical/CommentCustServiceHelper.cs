using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.logistical{
	
	
	public class CommentCustServiceHelper {
		
		
		
		public class countOrderCommentsByCondition_args {
			
			///<summary>
			/// 承运商编号
			///</summary>
			
			private long? custNo_;
			
			///<summary>
			/// 承运商编号
			///</summary>
			
			private string ordersn_;
			
			///<summary>
			/// 查询的开始订单提交时间
			///</summary>
			
			private long? startPostime_;
			
			///<summary>
			/// 查询的结束订单提交时间
			///</summary>
			
			private long? endPostime_;
			
			public long? GetCustNo(){
				return this.custNo_;
			}
			
			public void SetCustNo(long? value){
				this.custNo_ = value;
			}
			public string GetOrdersn(){
				return this.ordersn_;
			}
			
			public void SetOrdersn(string value){
				this.ordersn_ = value;
			}
			public long? GetStartPostime(){
				return this.startPostime_;
			}
			
			public void SetStartPostime(long? value){
				this.startPostime_ = value;
			}
			public long? GetEndPostime(){
				return this.endPostime_;
			}
			
			public void SetEndPostime(long? value){
				this.endPostime_ = value;
			}
			
		}
		
		
		
		
		public class getCommentsByCustNo_args {
			
			///<summary>
			/// 承运商编号
			///</summary>
			
			private long? custNo_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? curPage_;
			
			///<summary>
			/// 每页大小最大100
			///</summary>
			
			private int? pageSize_;
			
			///<summary>
			/// 查询的开始订单提交时间
			///</summary>
			
			private long? startPostime_;
			
			///<summary>
			/// 查询的结束订单提交时间
			///</summary>
			
			private long? endPostime_;
			
			public long? GetCustNo(){
				return this.custNo_;
			}
			
			public void SetCustNo(long? value){
				this.custNo_ = value;
			}
			public int? GetCurPage(){
				return this.curPage_;
			}
			
			public void SetCurPage(int? value){
				this.curPage_ = value;
			}
			public int? GetPageSize(){
				return this.pageSize_;
			}
			
			public void SetPageSize(int? value){
				this.pageSize_ = value;
			}
			public long? GetStartPostime(){
				return this.startPostime_;
			}
			
			public void SetStartPostime(long? value){
				this.startPostime_ = value;
			}
			public long? GetEndPostime(){
				return this.endPostime_;
			}
			
			public void SetEndPostime(long? value){
				this.endPostime_ = value;
			}
			
		}
		
		
		
		
		public class getOrderCommentsByCondition_args {
			
			///<summary>
			/// 承运商编号
			///</summary>
			
			private long? custNo_;
			
			///<summary>
			/// 承运商编号
			///</summary>
			
			private string ordersn_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? curPage_;
			
			///<summary>
			/// 每页大小最大100
			///</summary>
			
			private int? pageSize_;
			
			///<summary>
			/// 查询的开始订单提交时间
			///</summary>
			
			private long? startPostime_;
			
			///<summary>
			/// 查询的结束订单提交时间
			///</summary>
			
			private long? endPostime_;
			
			///<summary>
			/// createTime排序方向1升序 0 降序
			///</summary>
			
			private int? order_;
			
			public long? GetCustNo(){
				return this.custNo_;
			}
			
			public void SetCustNo(long? value){
				this.custNo_ = value;
			}
			public string GetOrdersn(){
				return this.ordersn_;
			}
			
			public void SetOrdersn(string value){
				this.ordersn_ = value;
			}
			public int? GetCurPage(){
				return this.curPage_;
			}
			
			public void SetCurPage(int? value){
				this.curPage_ = value;
			}
			public int? GetPageSize(){
				return this.pageSize_;
			}
			
			public void SetPageSize(int? value){
				this.pageSize_ = value;
			}
			public long? GetStartPostime(){
				return this.startPostime_;
			}
			
			public void SetStartPostime(long? value){
				this.startPostime_ = value;
			}
			public long? GetEndPostime(){
				return this.endPostime_;
			}
			
			public void SetEndPostime(long? value){
				this.endPostime_ = value;
			}
			public int? GetOrder(){
				return this.order_;
			}
			
			public void SetOrder(int? value){
				this.order_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class countOrderCommentsByCondition_result {
			
			///<summary>
			///</summary>
			
			private long? success_;
			
			public long? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(long? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCommentsByCustNo_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.comment.api.admin.service.OrderCommentRecord> success_;
			
			public List<com.vip.comment.api.admin.service.OrderCommentRecord> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.comment.api.admin.service.OrderCommentRecord> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderCommentsByCondition_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.comment.api.admin.service.OrderCommentRecord> success_;
			
			public List<com.vip.comment.api.admin.service.OrderCommentRecord> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.comment.api.admin.service.OrderCommentRecord> value){
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
		
		
		
		
		
		public class countOrderCommentsByCondition_argsHelper : TBeanSerializer<countOrderCommentsByCondition_args>
		{
			
			public static countOrderCommentsByCondition_argsHelper OBJ = new countOrderCommentsByCondition_argsHelper();
			
			public static countOrderCommentsByCondition_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(countOrderCommentsByCondition_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetCustNo(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrdersn(value);
				}
				
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetStartPostime(value);
				}
				
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetEndPostime(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(countOrderCommentsByCondition_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCustNo() != null) {
					
					oprot.WriteFieldBegin("custNo");
					oprot.WriteI64((long)structs.GetCustNo()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrdersn() != null) {
					
					oprot.WriteFieldBegin("ordersn");
					oprot.WriteString(structs.GetOrdersn());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetStartPostime() != null) {
					
					oprot.WriteFieldBegin("startPostime");
					oprot.WriteI64((long)structs.GetStartPostime()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEndPostime() != null) {
					
					oprot.WriteFieldBegin("endPostime");
					oprot.WriteI64((long)structs.GetEndPostime()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(countOrderCommentsByCondition_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCommentsByCustNo_argsHelper : TBeanSerializer<getCommentsByCustNo_args>
		{
			
			public static getCommentsByCustNo_argsHelper OBJ = new getCommentsByCustNo_argsHelper();
			
			public static getCommentsByCustNo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCommentsByCustNo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetCustNo(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetCurPage(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetPageSize(value);
				}
				
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetStartPostime(value);
				}
				
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetEndPostime(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCommentsByCustNo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCustNo() != null) {
					
					oprot.WriteFieldBegin("custNo");
					oprot.WriteI64((long)structs.GetCustNo()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("custNo can not be null!");
				}
				
				
				if(structs.GetCurPage() != null) {
					
					oprot.WriteFieldBegin("curPage");
					oprot.WriteI32((int)structs.GetCurPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("curPage can not be null!");
				}
				
				
				if(structs.GetPageSize() != null) {
					
					oprot.WriteFieldBegin("pageSize");
					oprot.WriteI32((int)structs.GetPageSize()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("pageSize can not be null!");
				}
				
				
				if(structs.GetStartPostime() != null) {
					
					oprot.WriteFieldBegin("startPostime");
					oprot.WriteI64((long)structs.GetStartPostime()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEndPostime() != null) {
					
					oprot.WriteFieldBegin("endPostime");
					oprot.WriteI64((long)structs.GetEndPostime()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCommentsByCustNo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderCommentsByCondition_argsHelper : TBeanSerializer<getOrderCommentsByCondition_args>
		{
			
			public static getOrderCommentsByCondition_argsHelper OBJ = new getOrderCommentsByCondition_argsHelper();
			
			public static getOrderCommentsByCondition_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderCommentsByCondition_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetCustNo(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrdersn(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetCurPage(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetPageSize(value);
				}
				
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetStartPostime(value);
				}
				
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetEndPostime(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetOrder(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderCommentsByCondition_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCustNo() != null) {
					
					oprot.WriteFieldBegin("custNo");
					oprot.WriteI64((long)structs.GetCustNo()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrdersn() != null) {
					
					oprot.WriteFieldBegin("ordersn");
					oprot.WriteString(structs.GetOrdersn());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetCurPage() != null) {
					
					oprot.WriteFieldBegin("curPage");
					oprot.WriteI32((int)structs.GetCurPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("curPage can not be null!");
				}
				
				
				if(structs.GetPageSize() != null) {
					
					oprot.WriteFieldBegin("pageSize");
					oprot.WriteI32((int)structs.GetPageSize()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("pageSize can not be null!");
				}
				
				
				if(structs.GetStartPostime() != null) {
					
					oprot.WriteFieldBegin("startPostime");
					oprot.WriteI64((long)structs.GetStartPostime()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetEndPostime() != null) {
					
					oprot.WriteFieldBegin("endPostime");
					oprot.WriteI64((long)structs.GetEndPostime()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetOrder() != null) {
					
					oprot.WriteFieldBegin("order");
					oprot.WriteI32((int)structs.GetOrder()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderCommentsByCondition_args bean){
				
				
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
		
		
		
		
		public class countOrderCommentsByCondition_resultHelper : TBeanSerializer<countOrderCommentsByCondition_result>
		{
			
			public static countOrderCommentsByCondition_resultHelper OBJ = new countOrderCommentsByCondition_resultHelper();
			
			public static countOrderCommentsByCondition_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(countOrderCommentsByCondition_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(countOrderCommentsByCondition_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI64((long)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(countOrderCommentsByCondition_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCommentsByCustNo_resultHelper : TBeanSerializer<getCommentsByCustNo_result>
		{
			
			public static getCommentsByCustNo_resultHelper OBJ = new getCommentsByCustNo_resultHelper();
			
			public static getCommentsByCustNo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCommentsByCustNo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.comment.api.admin.service.OrderCommentRecord> value;
					
					value = new List<com.vip.comment.api.admin.service.OrderCommentRecord>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.comment.api.admin.service.OrderCommentRecord elem0;
							
							elem0 = new com.vip.comment.api.admin.service.OrderCommentRecord();
							com.vip.comment.api.admin.service.OrderCommentRecordHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getCommentsByCustNo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.comment.api.admin.service.OrderCommentRecord _item0 in structs.GetSuccess()){
						
						
						com.vip.comment.api.admin.service.OrderCommentRecordHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCommentsByCustNo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderCommentsByCondition_resultHelper : TBeanSerializer<getOrderCommentsByCondition_result>
		{
			
			public static getOrderCommentsByCondition_resultHelper OBJ = new getOrderCommentsByCondition_resultHelper();
			
			public static getOrderCommentsByCondition_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderCommentsByCondition_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.comment.api.admin.service.OrderCommentRecord> value;
					
					value = new List<com.vip.comment.api.admin.service.OrderCommentRecord>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.comment.api.admin.service.OrderCommentRecord elem1;
							
							elem1 = new com.vip.comment.api.admin.service.OrderCommentRecord();
							com.vip.comment.api.admin.service.OrderCommentRecordHelper.getInstance().Read(elem1, iprot);
							
							value.Add(elem1);
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
			
			
			public void Write(getOrderCommentsByCondition_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.comment.api.admin.service.OrderCommentRecord _item0 in structs.GetSuccess()){
						
						
						com.vip.comment.api.admin.service.OrderCommentRecordHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderCommentsByCondition_result bean){
				
				
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
		
		
		
		
		public class CommentCustServiceClient : OspRestStub , CommentCustService  {
			
			
			public CommentCustServiceClient():base("vipapis.logistical.CommentCustService","1.0.4") {
				
				
			}
			
			
			
			public long? countOrderCommentsByCondition(long? custNo_,string ordersn_,long? startPostime_,long? endPostime_) {
				
				send_countOrderCommentsByCondition(custNo_,ordersn_,startPostime_,endPostime_);
				return recv_countOrderCommentsByCondition(); 
				
			}
			
			
			private void send_countOrderCommentsByCondition(long? custNo_,string ordersn_,long? startPostime_,long? endPostime_){
				
				InitInvocation("countOrderCommentsByCondition");
				
				countOrderCommentsByCondition_args args = new countOrderCommentsByCondition_args();
				args.SetCustNo(custNo_);
				args.SetOrdersn(ordersn_);
				args.SetStartPostime(startPostime_);
				args.SetEndPostime(endPostime_);
				
				SendBase(args, countOrderCommentsByCondition_argsHelper.getInstance());
			}
			
			
			private long? recv_countOrderCommentsByCondition(){
				
				countOrderCommentsByCondition_result result = new countOrderCommentsByCondition_result();
				ReceiveBase(result, countOrderCommentsByCondition_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.comment.api.admin.service.OrderCommentRecord> getCommentsByCustNo(long custNo_,int curPage_,int pageSize_,long? startPostime_,long? endPostime_) {
				
				send_getCommentsByCustNo(custNo_,curPage_,pageSize_,startPostime_,endPostime_);
				return recv_getCommentsByCustNo(); 
				
			}
			
			
			private void send_getCommentsByCustNo(long custNo_,int curPage_,int pageSize_,long? startPostime_,long? endPostime_){
				
				InitInvocation("getCommentsByCustNo");
				
				getCommentsByCustNo_args args = new getCommentsByCustNo_args();
				args.SetCustNo(custNo_);
				args.SetCurPage(curPage_);
				args.SetPageSize(pageSize_);
				args.SetStartPostime(startPostime_);
				args.SetEndPostime(endPostime_);
				
				SendBase(args, getCommentsByCustNo_argsHelper.getInstance());
			}
			
			
			private List<com.vip.comment.api.admin.service.OrderCommentRecord> recv_getCommentsByCustNo(){
				
				getCommentsByCustNo_result result = new getCommentsByCustNo_result();
				ReceiveBase(result, getCommentsByCustNo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.comment.api.admin.service.OrderCommentRecord> getOrderCommentsByCondition(long? custNo_,string ordersn_,int curPage_,int pageSize_,long? startPostime_,long? endPostime_,int? order_) {
				
				send_getOrderCommentsByCondition(custNo_,ordersn_,curPage_,pageSize_,startPostime_,endPostime_,order_);
				return recv_getOrderCommentsByCondition(); 
				
			}
			
			
			private void send_getOrderCommentsByCondition(long? custNo_,string ordersn_,int curPage_,int pageSize_,long? startPostime_,long? endPostime_,int? order_){
				
				InitInvocation("getOrderCommentsByCondition");
				
				getOrderCommentsByCondition_args args = new getOrderCommentsByCondition_args();
				args.SetCustNo(custNo_);
				args.SetOrdersn(ordersn_);
				args.SetCurPage(curPage_);
				args.SetPageSize(pageSize_);
				args.SetStartPostime(startPostime_);
				args.SetEndPostime(endPostime_);
				args.SetOrder(order_);
				
				SendBase(args, getOrderCommentsByCondition_argsHelper.getInstance());
			}
			
			
			private List<com.vip.comment.api.admin.service.OrderCommentRecord> recv_getOrderCommentsByCondition(){
				
				getOrderCommentsByCondition_result result = new getOrderCommentsByCondition_result();
				ReceiveBase(result, getOrderCommentsByCondition_resultHelper.getInstance());
				
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