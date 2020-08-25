using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.vop.omni.wo{
	
	
	public class WorkOrderServiceHelper {
		
		
		
		public class getNeedPushWorkOrders_args {
			
			///<summary>
			///</summary>
			
			private long? vendorId_;
			
			///<summary>
			///</summary>
			
			private System.DateTime? startTime_;
			
			///<summary>
			///</summary>
			
			private long? lastId_;
			
			///<summary>
			///</summary>
			
			private int? size_;
			
			public long? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(long? value){
				this.vendorId_ = value;
			}
			public System.DateTime? GetStartTime(){
				return this.startTime_;
			}
			
			public void SetStartTime(System.DateTime? value){
				this.startTime_ = value;
			}
			public long? GetLastId(){
				return this.lastId_;
			}
			
			public void SetLastId(long? value){
				this.lastId_ = value;
			}
			public int? GetSize(){
				return this.size_;
			}
			
			public void SetSize(int? value){
				this.size_ = value;
			}
			
		}
		
		
		
		
		public class getOxoOrderCarrier_args {
			
			///<summary>
			/// 订单号
			///</summary>
			
			private string orderSn_;
			
			public string GetOrderSn(){
				return this.orderSn_;
			}
			
			public void SetOrderSn(string value){
				this.orderSn_ = value;
			}
			
		}
		
		
		
		
		public class handleWorkOrder_args {
			
			///<summary>
			/// 工单主数据
			///</summary>
			
			private com.vip.vop.omni.wo.WorkOrder workOrder_;
			
			public com.vip.vop.omni.wo.WorkOrder GetWorkOrder(){
				return this.workOrder_;
			}
			
			public void SetWorkOrder(com.vip.vop.omni.wo.WorkOrder value){
				this.workOrder_ = value;
			}
			
		}
		
		
		
		
		public class handleWorkOrderAttachment_args {
			
			///<summary>
			/// 工单附件
			///</summary>
			
			private com.vip.vop.omni.wo.WorkOrderAttach workOrderAttach_;
			
			public com.vip.vop.omni.wo.WorkOrderAttach GetWorkOrderAttach(){
				return this.workOrderAttach_;
			}
			
			public void SetWorkOrderAttach(com.vip.vop.omni.wo.WorkOrderAttach value){
				this.workOrderAttach_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class pushWorkOrder_args {
			
			///<summary>
			/// 工单主数据
			///</summary>
			
			private com.vip.vop.omni.wo.WorkOrder workOrder_;
			
			public com.vip.vop.omni.wo.WorkOrder GetWorkOrder(){
				return this.workOrder_;
			}
			
			public void SetWorkOrder(com.vip.vop.omni.wo.WorkOrder value){
				this.workOrder_ = value;
			}
			
		}
		
		
		
		
		public class workOrderReply_args {
			
			///<summary>
			/// 工单回复
			///</summary>
			
			private com.vip.vop.omni.wo.WorkOrderReply reply_;
			
			public com.vip.vop.omni.wo.WorkOrderReply GetReply(){
				return this.reply_;
			}
			
			public void SetReply(com.vip.vop.omni.wo.WorkOrderReply value){
				this.reply_ = value;
			}
			
		}
		
		
		
		
		public class getNeedPushWorkOrders_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.vop.omni.wo.WorkOrder> success_;
			
			public List<com.vip.vop.omni.wo.WorkOrder> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.vop.omni.wo.WorkOrder> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOxoOrderCarrier_result {
			
			///<summary>
			///</summary>
			
			private com.vip.vop.omni.wo.OxoOrderCarrierInfo success_;
			
			public com.vip.vop.omni.wo.OxoOrderCarrierInfo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.vop.omni.wo.OxoOrderCarrierInfo value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class handleWorkOrder_result {
			
			///<summary>
			///</summary>
			
			private bool? success_;
			
			public bool? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(bool? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class handleWorkOrderAttachment_result {
			
			///<summary>
			///</summary>
			
			private bool? success_;
			
			public bool? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(bool? value){
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
		
		
		
		
		public class pushWorkOrder_result {
			
			///<summary>
			///</summary>
			
			private bool? success_;
			
			public bool? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(bool? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class workOrderReply_result {
			
			///<summary>
			///</summary>
			
			private bool? success_;
			
			public bool? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(bool? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class getNeedPushWorkOrders_argsHelper : TBeanSerializer<getNeedPushWorkOrders_args>
		{
			
			public static getNeedPushWorkOrders_argsHelper OBJ = new getNeedPushWorkOrders_argsHelper();
			
			public static getNeedPushWorkOrders_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getNeedPushWorkOrders_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				
				if(true){
					
					System.DateTime? value;
					value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
					
					structs.SetStartTime(value);
				}
				
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetLastId(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetSize(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getNeedPushWorkOrders_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendorId() != null) {
					
					oprot.WriteFieldBegin("vendorId");
					oprot.WriteI64((long)structs.GetVendorId()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetStartTime() != null) {
					
					oprot.WriteFieldBegin("startTime");
					oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetStartTime())); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLastId() != null) {
					
					oprot.WriteFieldBegin("lastId");
					oprot.WriteI64((long)structs.GetLastId()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSize() != null) {
					
					oprot.WriteFieldBegin("size");
					oprot.WriteI32((int)structs.GetSize()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getNeedPushWorkOrders_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOxoOrderCarrier_argsHelper : TBeanSerializer<getOxoOrderCarrier_args>
		{
			
			public static getOxoOrderCarrier_argsHelper OBJ = new getOxoOrderCarrier_argsHelper();
			
			public static getOxoOrderCarrier_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOxoOrderCarrier_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetOrderSn(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOxoOrderCarrier_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetOrderSn() != null) {
					
					oprot.WriteFieldBegin("orderSn");
					oprot.WriteString(structs.GetOrderSn());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("orderSn can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOxoOrderCarrier_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class handleWorkOrder_argsHelper : TBeanSerializer<handleWorkOrder_args>
		{
			
			public static handleWorkOrder_argsHelper OBJ = new handleWorkOrder_argsHelper();
			
			public static handleWorkOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(handleWorkOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.omni.wo.WorkOrder value;
					
					value = new com.vip.vop.omni.wo.WorkOrder();
					com.vip.vop.omni.wo.WorkOrderHelper.getInstance().Read(value, iprot);
					
					structs.SetWorkOrder(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(handleWorkOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWorkOrder() != null) {
					
					oprot.WriteFieldBegin("workOrder");
					
					com.vip.vop.omni.wo.WorkOrderHelper.getInstance().Write(structs.GetWorkOrder(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("workOrder can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(handleWorkOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class handleWorkOrderAttachment_argsHelper : TBeanSerializer<handleWorkOrderAttachment_args>
		{
			
			public static handleWorkOrderAttachment_argsHelper OBJ = new handleWorkOrderAttachment_argsHelper();
			
			public static handleWorkOrderAttachment_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(handleWorkOrderAttachment_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.omni.wo.WorkOrderAttach value;
					
					value = new com.vip.vop.omni.wo.WorkOrderAttach();
					com.vip.vop.omni.wo.WorkOrderAttachHelper.getInstance().Read(value, iprot);
					
					structs.SetWorkOrderAttach(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(handleWorkOrderAttachment_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWorkOrderAttach() != null) {
					
					oprot.WriteFieldBegin("workOrderAttach");
					
					com.vip.vop.omni.wo.WorkOrderAttachHelper.getInstance().Write(structs.GetWorkOrderAttach(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("workOrderAttach can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(handleWorkOrderAttachment_args bean){
				
				
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
		
		
		
		
		public class pushWorkOrder_argsHelper : TBeanSerializer<pushWorkOrder_args>
		{
			
			public static pushWorkOrder_argsHelper OBJ = new pushWorkOrder_argsHelper();
			
			public static pushWorkOrder_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushWorkOrder_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.omni.wo.WorkOrder value;
					
					value = new com.vip.vop.omni.wo.WorkOrder();
					com.vip.vop.omni.wo.WorkOrderHelper.getInstance().Read(value, iprot);
					
					structs.SetWorkOrder(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushWorkOrder_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetWorkOrder() != null) {
					
					oprot.WriteFieldBegin("workOrder");
					
					com.vip.vop.omni.wo.WorkOrderHelper.getInstance().Write(structs.GetWorkOrder(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("workOrder can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushWorkOrder_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class workOrderReply_argsHelper : TBeanSerializer<workOrderReply_args>
		{
			
			public static workOrderReply_argsHelper OBJ = new workOrderReply_argsHelper();
			
			public static workOrderReply_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(workOrderReply_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.omni.wo.WorkOrderReply value;
					
					value = new com.vip.vop.omni.wo.WorkOrderReply();
					com.vip.vop.omni.wo.WorkOrderReplyHelper.getInstance().Read(value, iprot);
					
					structs.SetReply(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(workOrderReply_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReply() != null) {
					
					oprot.WriteFieldBegin("reply");
					
					com.vip.vop.omni.wo.WorkOrderReplyHelper.getInstance().Write(structs.GetReply(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("reply can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(workOrderReply_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getNeedPushWorkOrders_resultHelper : TBeanSerializer<getNeedPushWorkOrders_result>
		{
			
			public static getNeedPushWorkOrders_resultHelper OBJ = new getNeedPushWorkOrders_resultHelper();
			
			public static getNeedPushWorkOrders_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getNeedPushWorkOrders_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.vop.omni.wo.WorkOrder> value;
					
					value = new List<com.vip.vop.omni.wo.WorkOrder>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.vop.omni.wo.WorkOrder elem0;
							
							elem0 = new com.vip.vop.omni.wo.WorkOrder();
							com.vip.vop.omni.wo.WorkOrderHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getNeedPushWorkOrders_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.vop.omni.wo.WorkOrder _item0 in structs.GetSuccess()){
						
						
						com.vip.vop.omni.wo.WorkOrderHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getNeedPushWorkOrders_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOxoOrderCarrier_resultHelper : TBeanSerializer<getOxoOrderCarrier_result>
		{
			
			public static getOxoOrderCarrier_resultHelper OBJ = new getOxoOrderCarrier_resultHelper();
			
			public static getOxoOrderCarrier_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOxoOrderCarrier_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.omni.wo.OxoOrderCarrierInfo value;
					
					value = new com.vip.vop.omni.wo.OxoOrderCarrierInfo();
					com.vip.vop.omni.wo.OxoOrderCarrierInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOxoOrderCarrier_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.vop.omni.wo.OxoOrderCarrierInfoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOxoOrderCarrier_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class handleWorkOrder_resultHelper : TBeanSerializer<handleWorkOrder_result>
		{
			
			public static handleWorkOrder_resultHelper OBJ = new handleWorkOrder_resultHelper();
			
			public static handleWorkOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(handleWorkOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(handleWorkOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteBool((bool)structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(handleWorkOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class handleWorkOrderAttachment_resultHelper : TBeanSerializer<handleWorkOrderAttachment_result>
		{
			
			public static handleWorkOrderAttachment_resultHelper OBJ = new handleWorkOrderAttachment_resultHelper();
			
			public static handleWorkOrderAttachment_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(handleWorkOrderAttachment_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(handleWorkOrderAttachment_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteBool((bool)structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(handleWorkOrderAttachment_result bean){
				
				
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
		
		
		
		
		public class pushWorkOrder_resultHelper : TBeanSerializer<pushWorkOrder_result>
		{
			
			public static pushWorkOrder_resultHelper OBJ = new pushWorkOrder_resultHelper();
			
			public static pushWorkOrder_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushWorkOrder_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushWorkOrder_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteBool((bool)structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushWorkOrder_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class workOrderReply_resultHelper : TBeanSerializer<workOrderReply_result>
		{
			
			public static workOrderReply_resultHelper OBJ = new workOrderReply_resultHelper();
			
			public static workOrderReply_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(workOrderReply_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(workOrderReply_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteBool((bool)structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(workOrderReply_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class WorkOrderServiceClient : OspRestStub , WorkOrderService  {
			
			
			public WorkOrderServiceClient():base("com.vip.vop.omni.wo.WorkOrderService","1.0.0") {
				
				
			}
			
			
			
			public List<com.vip.vop.omni.wo.WorkOrder> getNeedPushWorkOrders(long? vendorId_,System.DateTime? startTime_,long? lastId_,int? size_) {
				
				send_getNeedPushWorkOrders(vendorId_,startTime_,lastId_,size_);
				return recv_getNeedPushWorkOrders(); 
				
			}
			
			
			private void send_getNeedPushWorkOrders(long? vendorId_,System.DateTime? startTime_,long? lastId_,int? size_){
				
				InitInvocation("getNeedPushWorkOrders");
				
				getNeedPushWorkOrders_args args = new getNeedPushWorkOrders_args();
				args.SetVendorId(vendorId_);
				args.SetStartTime(startTime_);
				args.SetLastId(lastId_);
				args.SetSize(size_);
				
				SendBase(args, getNeedPushWorkOrders_argsHelper.getInstance());
			}
			
			
			private List<com.vip.vop.omni.wo.WorkOrder> recv_getNeedPushWorkOrders(){
				
				getNeedPushWorkOrders_result result = new getNeedPushWorkOrders_result();
				ReceiveBase(result, getNeedPushWorkOrders_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.vop.omni.wo.OxoOrderCarrierInfo getOxoOrderCarrier(string orderSn_) {
				
				send_getOxoOrderCarrier(orderSn_);
				return recv_getOxoOrderCarrier(); 
				
			}
			
			
			private void send_getOxoOrderCarrier(string orderSn_){
				
				InitInvocation("getOxoOrderCarrier");
				
				getOxoOrderCarrier_args args = new getOxoOrderCarrier_args();
				args.SetOrderSn(orderSn_);
				
				SendBase(args, getOxoOrderCarrier_argsHelper.getInstance());
			}
			
			
			private com.vip.vop.omni.wo.OxoOrderCarrierInfo recv_getOxoOrderCarrier(){
				
				getOxoOrderCarrier_result result = new getOxoOrderCarrier_result();
				ReceiveBase(result, getOxoOrderCarrier_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public bool? handleWorkOrder(com.vip.vop.omni.wo.WorkOrder workOrder_) {
				
				send_handleWorkOrder(workOrder_);
				return recv_handleWorkOrder(); 
				
			}
			
			
			private void send_handleWorkOrder(com.vip.vop.omni.wo.WorkOrder workOrder_){
				
				InitInvocation("handleWorkOrder");
				
				handleWorkOrder_args args = new handleWorkOrder_args();
				args.SetWorkOrder(workOrder_);
				
				SendBase(args, handleWorkOrder_argsHelper.getInstance());
			}
			
			
			private bool? recv_handleWorkOrder(){
				
				handleWorkOrder_result result = new handleWorkOrder_result();
				ReceiveBase(result, handleWorkOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public bool? handleWorkOrderAttachment(com.vip.vop.omni.wo.WorkOrderAttach workOrderAttach_) {
				
				send_handleWorkOrderAttachment(workOrderAttach_);
				return recv_handleWorkOrderAttachment(); 
				
			}
			
			
			private void send_handleWorkOrderAttachment(com.vip.vop.omni.wo.WorkOrderAttach workOrderAttach_){
				
				InitInvocation("handleWorkOrderAttachment");
				
				handleWorkOrderAttachment_args args = new handleWorkOrderAttachment_args();
				args.SetWorkOrderAttach(workOrderAttach_);
				
				SendBase(args, handleWorkOrderAttachment_argsHelper.getInstance());
			}
			
			
			private bool? recv_handleWorkOrderAttachment(){
				
				handleWorkOrderAttachment_result result = new handleWorkOrderAttachment_result();
				ReceiveBase(result, handleWorkOrderAttachment_resultHelper.getInstance());
				
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
			
			
			public bool? pushWorkOrder(com.vip.vop.omni.wo.WorkOrder workOrder_) {
				
				send_pushWorkOrder(workOrder_);
				return recv_pushWorkOrder(); 
				
			}
			
			
			private void send_pushWorkOrder(com.vip.vop.omni.wo.WorkOrder workOrder_){
				
				InitInvocation("pushWorkOrder");
				
				pushWorkOrder_args args = new pushWorkOrder_args();
				args.SetWorkOrder(workOrder_);
				
				SendBase(args, pushWorkOrder_argsHelper.getInstance());
			}
			
			
			private bool? recv_pushWorkOrder(){
				
				pushWorkOrder_result result = new pushWorkOrder_result();
				ReceiveBase(result, pushWorkOrder_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public bool? workOrderReply(com.vip.vop.omni.wo.WorkOrderReply reply_) {
				
				send_workOrderReply(reply_);
				return recv_workOrderReply(); 
				
			}
			
			
			private void send_workOrderReply(com.vip.vop.omni.wo.WorkOrderReply reply_){
				
				InitInvocation("workOrderReply");
				
				workOrderReply_args args = new workOrderReply_args();
				args.SetReply(reply_);
				
				SendBase(args, workOrderReply_argsHelper.getInstance());
			}
			
			
			private bool? recv_workOrderReply(){
				
				workOrderReply_result result = new workOrderReply_result();
				ReceiveBase(result, workOrderReply_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}