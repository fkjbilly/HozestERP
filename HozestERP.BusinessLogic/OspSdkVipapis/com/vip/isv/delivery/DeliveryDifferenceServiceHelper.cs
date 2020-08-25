using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.isv.delivery{
	
	
	public class DeliveryDifferenceServiceHelper {
		
		
		
		public class countByVisReceiptContainerId_args {
			
			///<summary>
			/// 入库详情表的主键ID
			///</summary>
			
			private long? id_;
			
			public long? GetId(){
				return this.id_;
			}
			
			public void SetId(long? value){
				this.id_ = value;
			}
			
		}
		
		
		
		
		public class getDefectiveGoodByReceiptNo_args {
			
			///<summary>
			/// 入库单号
			///</summary>
			
			private string receiptNo_;
			
			public string GetReceiptNo(){
				return this.receiptNo_;
			}
			
			public void SetReceiptNo(string value){
				this.receiptNo_ = value;
			}
			
		}
		
		
		
		
		public class getDetailList_args {
			
			///<summary>
			/// 入库信息表的主键id
			///</summary>
			
			private long? visReceiptContainerId_;
			
			///<summary>
			/// 每次取出的条数
			///</summary>
			
			private int? size_;
			
			public long? GetVisReceiptContainerId(){
				return this.visReceiptContainerId_;
			}
			
			public void SetVisReceiptContainerId(long? value){
				this.visReceiptContainerId_ = value;
			}
			public int? GetSize(){
				return this.size_;
			}
			
			public void SetSize(int? value){
				this.size_ = value;
			}
			
		}
		
		
		
		
		public class getList_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendorId_;
			
			///<summary>
			/// 查询时间（当前时间往前48个小时）
			///</summary>
			
			private System.DateTime? time_;
			
			///<summary>
			/// 每次取出的条数
			///</summary>
			
			private int? size_;
			
			public int? GetVendorId(){
				return this.vendorId_;
			}
			
			public void SetVendorId(int? value){
				this.vendorId_ = value;
			}
			public System.DateTime? GetTime(){
				return this.time_;
			}
			
			public void SetTime(System.DateTime? value){
				this.time_ = value;
			}
			public int? GetSize(){
				return this.size_;
			}
			
			public void SetSize(int? value){
				this.size_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class updateReceiptContainer_args {
			
			///<summary>
			/// 入库信息表的主键ID
			///</summary>
			
			private long? id_;
			
			public long? GetId(){
				return this.id_;
			}
			
			public void SetId(long? value){
				this.id_ = value;
			}
			
		}
		
		
		
		
		public class updateReceiptContainerDetail_args {
			
			///<summary>
			/// 入库详情表的主键ID
			///</summary>
			
			private List<long?> id_;
			
			public List<long?> GetId(){
				return this.id_;
			}
			
			public void SetId(List<long?> value){
				this.id_ = value;
			}
			
		}
		
		
		
		
		public class countByVisReceiptContainerId_result {
			
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
		
		
		
		
		public class getDefectiveGoodByReceiptNo_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.isv.delivery.DefectiveGood> success_;
			
			public List<com.vip.isv.delivery.DefectiveGood> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.isv.delivery.DefectiveGood> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getDetailList_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.isv.delivery.ReceiptDetail> success_;
			
			public List<com.vip.isv.delivery.ReceiptDetail> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.isv.delivery.ReceiptDetail> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getList_result {
			
			///<summary>
			///</summary>
			
			private List<com.vip.isv.delivery.ReceiptInfo> success_;
			
			public List<com.vip.isv.delivery.ReceiptInfo> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<com.vip.isv.delivery.ReceiptInfo> value){
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
		
		
		
		
		public class updateReceiptContainer_result {
			
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
		
		
		
		
		public class updateReceiptContainerDetail_result {
			
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
		
		
		
		
		
		public class countByVisReceiptContainerId_argsHelper : TBeanSerializer<countByVisReceiptContainerId_args>
		{
			
			public static countByVisReceiptContainerId_argsHelper OBJ = new countByVisReceiptContainerId_argsHelper();
			
			public static countByVisReceiptContainerId_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(countByVisReceiptContainerId_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(countByVisReceiptContainerId_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetId() != null) {
					
					oprot.WriteFieldBegin("id");
					oprot.WriteI64((long)structs.GetId()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(countByVisReceiptContainerId_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDefectiveGoodByReceiptNo_argsHelper : TBeanSerializer<getDefectiveGoodByReceiptNo_args>
		{
			
			public static getDefectiveGoodByReceiptNo_argsHelper OBJ = new getDefectiveGoodByReceiptNo_argsHelper();
			
			public static getDefectiveGoodByReceiptNo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDefectiveGoodByReceiptNo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetReceiptNo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDefectiveGoodByReceiptNo_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReceiptNo() != null) {
					
					oprot.WriteFieldBegin("receiptNo");
					oprot.WriteString(structs.GetReceiptNo());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDefectiveGoodByReceiptNo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDetailList_argsHelper : TBeanSerializer<getDetailList_args>
		{
			
			public static getDetailList_argsHelper OBJ = new getDetailList_argsHelper();
			
			public static getDetailList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDetailList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetVisReceiptContainerId(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSize(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDetailList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVisReceiptContainerId() != null) {
					
					oprot.WriteFieldBegin("visReceiptContainerId");
					oprot.WriteI64((long)structs.GetVisReceiptContainerId()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSize() != null) {
					
					oprot.WriteFieldBegin("size");
					oprot.WriteI32((int)structs.GetSize()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("size can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDetailList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getList_argsHelper : TBeanSerializer<getList_args>
		{
			
			public static getList_argsHelper OBJ = new getList_argsHelper();
			
			public static getList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetVendorId(value);
				}
				
				
				
				
				
				if(true){
					
					System.DateTime? value;
					value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
					
					structs.SetTime(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSize(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendorId() != null) {
					
					oprot.WriteFieldBegin("vendorId");
					oprot.WriteI32((int)structs.GetVendorId()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetTime() != null) {
					
					oprot.WriteFieldBegin("time");
					oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetTime())); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSize() != null) {
					
					oprot.WriteFieldBegin("size");
					oprot.WriteI32((int)structs.GetSize()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("size can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getList_args bean){
				
				
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
		
		
		
		
		public class updateReceiptContainer_argsHelper : TBeanSerializer<updateReceiptContainer_args>
		{
			
			public static updateReceiptContainer_argsHelper OBJ = new updateReceiptContainer_argsHelper();
			
			public static updateReceiptContainer_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateReceiptContainer_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateReceiptContainer_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetId() != null) {
					
					oprot.WriteFieldBegin("id");
					oprot.WriteI64((long)structs.GetId()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateReceiptContainer_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateReceiptContainerDetail_argsHelper : TBeanSerializer<updateReceiptContainerDetail_args>
		{
			
			public static updateReceiptContainerDetail_argsHelper OBJ = new updateReceiptContainerDetail_argsHelper();
			
			public static updateReceiptContainerDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateReceiptContainerDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<long?> value;
					
					value = new List<long?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							long elem0;
							elem0 = iprot.ReadI64(); 
							
							value.Add(elem0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetId(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateReceiptContainerDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetId() != null) {
					
					oprot.WriteFieldBegin("id");
					
					oprot.WriteListBegin();
					foreach(long _item0 in structs.GetId()){
						
						oprot.WriteI64((long)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateReceiptContainerDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class countByVisReceiptContainerId_resultHelper : TBeanSerializer<countByVisReceiptContainerId_result>
		{
			
			public static countByVisReceiptContainerId_resultHelper OBJ = new countByVisReceiptContainerId_resultHelper();
			
			public static countByVisReceiptContainerId_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(countByVisReceiptContainerId_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(countByVisReceiptContainerId_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI32((int)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("success can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(countByVisReceiptContainerId_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDefectiveGoodByReceiptNo_resultHelper : TBeanSerializer<getDefectiveGoodByReceiptNo_result>
		{
			
			public static getDefectiveGoodByReceiptNo_resultHelper OBJ = new getDefectiveGoodByReceiptNo_resultHelper();
			
			public static getDefectiveGoodByReceiptNo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDefectiveGoodByReceiptNo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.isv.delivery.DefectiveGood> value;
					
					value = new List<com.vip.isv.delivery.DefectiveGood>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.isv.delivery.DefectiveGood elem0;
							
							elem0 = new com.vip.isv.delivery.DefectiveGood();
							com.vip.isv.delivery.DefectiveGoodHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getDefectiveGoodByReceiptNo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.isv.delivery.DefectiveGood _item0 in structs.GetSuccess()){
						
						
						com.vip.isv.delivery.DefectiveGoodHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDefectiveGoodByReceiptNo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDetailList_resultHelper : TBeanSerializer<getDetailList_result>
		{
			
			public static getDetailList_resultHelper OBJ = new getDetailList_resultHelper();
			
			public static getDetailList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDetailList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.isv.delivery.ReceiptDetail> value;
					
					value = new List<com.vip.isv.delivery.ReceiptDetail>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.isv.delivery.ReceiptDetail elem1;
							
							elem1 = new com.vip.isv.delivery.ReceiptDetail();
							com.vip.isv.delivery.ReceiptDetailHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(getDetailList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.isv.delivery.ReceiptDetail _item0 in structs.GetSuccess()){
						
						
						com.vip.isv.delivery.ReceiptDetailHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDetailList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getList_resultHelper : TBeanSerializer<getList_result>
		{
			
			public static getList_resultHelper OBJ = new getList_resultHelper();
			
			public static getList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<com.vip.isv.delivery.ReceiptInfo> value;
					
					value = new List<com.vip.isv.delivery.ReceiptInfo>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							com.vip.isv.delivery.ReceiptInfo elem1;
							
							elem1 = new com.vip.isv.delivery.ReceiptInfo();
							com.vip.isv.delivery.ReceiptInfoHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(getList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(com.vip.isv.delivery.ReceiptInfo _item0 in structs.GetSuccess()){
						
						
						com.vip.isv.delivery.ReceiptInfoHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getList_result bean){
				
				
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
		
		
		
		
		public class updateReceiptContainer_resultHelper : TBeanSerializer<updateReceiptContainer_result>
		{
			
			public static updateReceiptContainer_resultHelper OBJ = new updateReceiptContainer_resultHelper();
			
			public static updateReceiptContainer_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateReceiptContainer_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateReceiptContainer_result structs, Protocol oprot){
				
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
			
			
			public void Validate(updateReceiptContainer_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateReceiptContainerDetail_resultHelper : TBeanSerializer<updateReceiptContainerDetail_result>
		{
			
			public static updateReceiptContainerDetail_resultHelper OBJ = new updateReceiptContainerDetail_resultHelper();
			
			public static updateReceiptContainerDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateReceiptContainerDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateReceiptContainerDetail_result structs, Protocol oprot){
				
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
			
			
			public void Validate(updateReceiptContainerDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class DeliveryDifferenceServiceClient : OspRestStub , DeliveryDifferenceService  {
			
			
			public DeliveryDifferenceServiceClient():base("com.vip.isv.delivery.DeliveryDifferenceService","1.0.0") {
				
				
			}
			
			
			
			public int? countByVisReceiptContainerId(long? id_) {
				
				send_countByVisReceiptContainerId(id_);
				return recv_countByVisReceiptContainerId(); 
				
			}
			
			
			private void send_countByVisReceiptContainerId(long? id_){
				
				InitInvocation("countByVisReceiptContainerId");
				
				countByVisReceiptContainerId_args args = new countByVisReceiptContainerId_args();
				args.SetId(id_);
				
				SendBase(args, countByVisReceiptContainerId_argsHelper.getInstance());
			}
			
			
			private int? recv_countByVisReceiptContainerId(){
				
				countByVisReceiptContainerId_result result = new countByVisReceiptContainerId_result();
				ReceiveBase(result, countByVisReceiptContainerId_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.isv.delivery.DefectiveGood> getDefectiveGoodByReceiptNo(string receiptNo_) {
				
				send_getDefectiveGoodByReceiptNo(receiptNo_);
				return recv_getDefectiveGoodByReceiptNo(); 
				
			}
			
			
			private void send_getDefectiveGoodByReceiptNo(string receiptNo_){
				
				InitInvocation("getDefectiveGoodByReceiptNo");
				
				getDefectiveGoodByReceiptNo_args args = new getDefectiveGoodByReceiptNo_args();
				args.SetReceiptNo(receiptNo_);
				
				SendBase(args, getDefectiveGoodByReceiptNo_argsHelper.getInstance());
			}
			
			
			private List<com.vip.isv.delivery.DefectiveGood> recv_getDefectiveGoodByReceiptNo(){
				
				getDefectiveGoodByReceiptNo_result result = new getDefectiveGoodByReceiptNo_result();
				ReceiveBase(result, getDefectiveGoodByReceiptNo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.isv.delivery.ReceiptDetail> getDetailList(long? visReceiptContainerId_,int size_) {
				
				send_getDetailList(visReceiptContainerId_,size_);
				return recv_getDetailList(); 
				
			}
			
			
			private void send_getDetailList(long? visReceiptContainerId_,int size_){
				
				InitInvocation("getDetailList");
				
				getDetailList_args args = new getDetailList_args();
				args.SetVisReceiptContainerId(visReceiptContainerId_);
				args.SetSize(size_);
				
				SendBase(args, getDetailList_argsHelper.getInstance());
			}
			
			
			private List<com.vip.isv.delivery.ReceiptDetail> recv_getDetailList(){
				
				getDetailList_result result = new getDetailList_result();
				ReceiveBase(result, getDetailList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<com.vip.isv.delivery.ReceiptInfo> getList(int? vendorId_,System.DateTime? time_,int size_) {
				
				send_getList(vendorId_,time_,size_);
				return recv_getList(); 
				
			}
			
			
			private void send_getList(int? vendorId_,System.DateTime? time_,int size_){
				
				InitInvocation("getList");
				
				getList_args args = new getList_args();
				args.SetVendorId(vendorId_);
				args.SetTime(time_);
				args.SetSize(size_);
				
				SendBase(args, getList_argsHelper.getInstance());
			}
			
			
			private List<com.vip.isv.delivery.ReceiptInfo> recv_getList(){
				
				getList_result result = new getList_result();
				ReceiveBase(result, getList_resultHelper.getInstance());
				
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
			
			
			public bool? updateReceiptContainer(long? id_) {
				
				send_updateReceiptContainer(id_);
				return recv_updateReceiptContainer(); 
				
			}
			
			
			private void send_updateReceiptContainer(long? id_){
				
				InitInvocation("updateReceiptContainer");
				
				updateReceiptContainer_args args = new updateReceiptContainer_args();
				args.SetId(id_);
				
				SendBase(args, updateReceiptContainer_argsHelper.getInstance());
			}
			
			
			private bool? recv_updateReceiptContainer(){
				
				updateReceiptContainer_result result = new updateReceiptContainer_result();
				ReceiveBase(result, updateReceiptContainer_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public bool? updateReceiptContainerDetail(List<long?> id_) {
				
				send_updateReceiptContainerDetail(id_);
				return recv_updateReceiptContainerDetail(); 
				
			}
			
			
			private void send_updateReceiptContainerDetail(List<long?> id_){
				
				InitInvocation("updateReceiptContainerDetail");
				
				updateReceiptContainerDetail_args args = new updateReceiptContainerDetail_args();
				args.SetId(id_);
				
				SendBase(args, updateReceiptContainerDetail_argsHelper.getInstance());
			}
			
			
			private bool? recv_updateReceiptContainerDetail(){
				
				updateReceiptContainerDetail_result result = new updateReceiptContainerDetail_result();
				ReceiveBase(result, updateReceiptContainerDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}