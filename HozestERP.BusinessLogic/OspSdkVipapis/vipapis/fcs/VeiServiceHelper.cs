using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.fcs{
	
	
	public class VeiServiceHelper {
		
		
		
		public class acceptExternalInvoiceData_args {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.EinvoiceVo einvoiceVo_;
			
			public com.vip.fcs.vei.service.EinvoiceVo GetEinvoiceVo(){
				return this.einvoiceVo_;
			}
			
			public void SetEinvoiceVo(com.vip.fcs.vei.service.EinvoiceVo value){
				this.einvoiceVo_ = value;
			}
			
		}
		
		
		
		
		public class canInvoicing_args {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.CanInvoicingReqModel canInvoicingReqModel_;
			
			public com.vip.fcs.vei.service.CanInvoicingReqModel GetCanInvoicingReqModel(){
				return this.canInvoicingReqModel_;
			}
			
			public void SetCanInvoicingReqModel(com.vip.fcs.vei.service.CanInvoicingReqModel value){
				this.canInvoicingReqModel_ = value;
			}
			
		}
		
		
		
		
		public class canInvoicing2_args {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.CanInvoicingReqModel canInvoicingReqModel_;
			
			public com.vip.fcs.vei.service.CanInvoicingReqModel GetCanInvoicingReqModel(){
				return this.canInvoicingReqModel_;
			}
			
			public void SetCanInvoicingReqModel(com.vip.fcs.vei.service.CanInvoicingReqModel value){
				this.canInvoicingReqModel_ = value;
			}
			
		}
		
		
		
		
		public class canInvoicing3_args {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.CanInvoicingReqModel3 canInvoicingReqModel_;
			
			public com.vip.fcs.vei.service.CanInvoicingReqModel3 GetCanInvoicingReqModel(){
				return this.canInvoicingReqModel_;
			}
			
			public void SetCanInvoicingReqModel(com.vip.fcs.vei.service.CanInvoicingReqModel3 value){
				this.canInvoicingReqModel_ = value;
			}
			
		}
		
		
		
		
		public class canInvoicing4_args {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.CanInvoicingReqModel4 canInvoicingReqModel_;
			
			public com.vip.fcs.vei.service.CanInvoicingReqModel4 GetCanInvoicingReqModel(){
				return this.canInvoicingReqModel_;
			}
			
			public void SetCanInvoicingReqModel(com.vip.fcs.vei.service.CanInvoicingReqModel4 value){
				this.canInvoicingReqModel_ = value;
			}
			
		}
		
		
		
		
		public class downloadElectronicInvoice_args {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel reqModel_;
			
			public com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel GetReqModel(){
				return this.reqModel_;
			}
			
			public void SetReqModel(com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel value){
				this.reqModel_ = value;
			}
			
		}
		
		
		
		
		public class downloadElectronicInvoice2_args {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2 reqModel_;
			
			public com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2 GetReqModel(){
				return this.reqModel_;
			}
			
			public void SetReqModel(com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2 value){
				this.reqModel_ = value;
			}
			
		}
		
		
		
		
		public class downloadElectronicInvoicePicture_args {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.DownloadElectronicInvoicePictureReqModel reqModel_;
			
			public com.vip.fcs.vei.service.DownloadElectronicInvoicePictureReqModel GetReqModel(){
				return this.reqModel_;
			}
			
			public void SetReqModel(com.vip.fcs.vei.service.DownloadElectronicInvoicePictureReqModel value){
				this.reqModel_ = value;
			}
			
		}
		
		
		
		
		public class downloadMedicineElectronicInvoice_args {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2 reqModel_;
			
			public com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2 GetReqModel(){
				return this.reqModel_;
			}
			
			public void SetReqModel(com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2 value){
				this.reqModel_ = value;
			}
			
		}
		
		
		
		
		public class downloadRedElectronicInvoice_args {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel reqModel_;
			
			public com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel GetReqModel(){
				return this.reqModel_;
			}
			
			public void SetReqModel(com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel value){
				this.reqModel_ = value;
			}
			
		}
		
		
		
		
		public class getExternalInvoiceHandleState_args {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.ExternalInvoiceHandleStateReqModel reqModel_;
			
			public com.vip.fcs.vei.service.ExternalInvoiceHandleStateReqModel GetReqModel(){
				return this.reqModel_;
			}
			
			public void SetReqModel(com.vip.fcs.vei.service.ExternalInvoiceHandleStateReqModel value){
				this.reqModel_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class invoiceOrderData_args {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.InvoiceOrderDataReqModel reqModel_;
			
			public com.vip.fcs.vei.service.InvoiceOrderDataReqModel GetReqModel(){
				return this.reqModel_;
			}
			
			public void SetReqModel(com.vip.fcs.vei.service.InvoiceOrderDataReqModel value){
				this.reqModel_ = value;
			}
			
		}
		
		
		
		
		public class vCanInvoicing_args {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.VCanInvoicingReqModel reqModel_;
			
			public com.vip.fcs.vei.service.VCanInvoicingReqModel GetReqModel(){
				return this.reqModel_;
			}
			
			public void SetReqModel(com.vip.fcs.vei.service.VCanInvoicingReqModel value){
				this.reqModel_ = value;
			}
			
		}
		
		
		
		
		public class acceptExternalInvoiceData_result {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.BaseRetMsg success_;
			
			public com.vip.fcs.vei.service.BaseRetMsg GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.fcs.vei.service.BaseRetMsg value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class canInvoicing_result {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.CanInvoicingResModel success_;
			
			public com.vip.fcs.vei.service.CanInvoicingResModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.fcs.vei.service.CanInvoicingResModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class canInvoicing2_result {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.CanInvoicingResModel2 success_;
			
			public com.vip.fcs.vei.service.CanInvoicingResModel2 GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.fcs.vei.service.CanInvoicingResModel2 value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class canInvoicing3_result {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.CanInvoicingResModel3 success_;
			
			public com.vip.fcs.vei.service.CanInvoicingResModel3 GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.fcs.vei.service.CanInvoicingResModel3 value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class canInvoicing4_result {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.CanInvoicingResModel4 success_;
			
			public com.vip.fcs.vei.service.CanInvoicingResModel4 GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.fcs.vei.service.CanInvoicingResModel4 value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class downloadElectronicInvoice_result {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel success_;
			
			public com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class downloadElectronicInvoice2_result {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel success_;
			
			public com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class downloadElectronicInvoicePicture_result {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.DownloadElectronicInvoicePictureResModel success_;
			
			public com.vip.fcs.vei.service.DownloadElectronicInvoicePictureResModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.fcs.vei.service.DownloadElectronicInvoicePictureResModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class downloadMedicineElectronicInvoice_result {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel success_;
			
			public com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class downloadRedElectronicInvoice_result {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel success_;
			
			public com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getExternalInvoiceHandleState_result {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.ExternalInvoiceHandleStateResModel success_;
			
			public com.vip.fcs.vei.service.ExternalInvoiceHandleStateResModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.fcs.vei.service.ExternalInvoiceHandleStateResModel value){
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
		
		
		
		
		public class invoiceOrderData_result {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.InvoiceOrderDataResModel success_;
			
			public com.vip.fcs.vei.service.InvoiceOrderDataResModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.fcs.vei.service.InvoiceOrderDataResModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class vCanInvoicing_result {
			
			///<summary>
			///</summary>
			
			private com.vip.fcs.vei.service.VCanInvoicingResModel success_;
			
			public com.vip.fcs.vei.service.VCanInvoicingResModel GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(com.vip.fcs.vei.service.VCanInvoicingResModel value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class acceptExternalInvoiceData_argsHelper : TBeanSerializer<acceptExternalInvoiceData_args>
		{
			
			public static acceptExternalInvoiceData_argsHelper OBJ = new acceptExternalInvoiceData_argsHelper();
			
			public static acceptExternalInvoiceData_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(acceptExternalInvoiceData_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.EinvoiceVo value;
					
					value = new com.vip.fcs.vei.service.EinvoiceVo();
					com.vip.fcs.vei.service.EinvoiceVoHelper.getInstance().Read(value, iprot);
					
					structs.SetEinvoiceVo(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(acceptExternalInvoiceData_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetEinvoiceVo() != null) {
					
					oprot.WriteFieldBegin("einvoiceVo");
					
					com.vip.fcs.vei.service.EinvoiceVoHelper.getInstance().Write(structs.GetEinvoiceVo(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("einvoiceVo can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(acceptExternalInvoiceData_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class canInvoicing_argsHelper : TBeanSerializer<canInvoicing_args>
		{
			
			public static canInvoicing_argsHelper OBJ = new canInvoicing_argsHelper();
			
			public static canInvoicing_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(canInvoicing_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.CanInvoicingReqModel value;
					
					value = new com.vip.fcs.vei.service.CanInvoicingReqModel();
					com.vip.fcs.vei.service.CanInvoicingReqModelHelper.getInstance().Read(value, iprot);
					
					structs.SetCanInvoicingReqModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(canInvoicing_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCanInvoicingReqModel() != null) {
					
					oprot.WriteFieldBegin("canInvoicingReqModel");
					
					com.vip.fcs.vei.service.CanInvoicingReqModelHelper.getInstance().Write(structs.GetCanInvoicingReqModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(canInvoicing_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class canInvoicing2_argsHelper : TBeanSerializer<canInvoicing2_args>
		{
			
			public static canInvoicing2_argsHelper OBJ = new canInvoicing2_argsHelper();
			
			public static canInvoicing2_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(canInvoicing2_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.CanInvoicingReqModel value;
					
					value = new com.vip.fcs.vei.service.CanInvoicingReqModel();
					com.vip.fcs.vei.service.CanInvoicingReqModelHelper.getInstance().Read(value, iprot);
					
					structs.SetCanInvoicingReqModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(canInvoicing2_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCanInvoicingReqModel() != null) {
					
					oprot.WriteFieldBegin("canInvoicingReqModel");
					
					com.vip.fcs.vei.service.CanInvoicingReqModelHelper.getInstance().Write(structs.GetCanInvoicingReqModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(canInvoicing2_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class canInvoicing3_argsHelper : TBeanSerializer<canInvoicing3_args>
		{
			
			public static canInvoicing3_argsHelper OBJ = new canInvoicing3_argsHelper();
			
			public static canInvoicing3_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(canInvoicing3_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.CanInvoicingReqModel3 value;
					
					value = new com.vip.fcs.vei.service.CanInvoicingReqModel3();
					com.vip.fcs.vei.service.CanInvoicingReqModel3Helper.getInstance().Read(value, iprot);
					
					structs.SetCanInvoicingReqModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(canInvoicing3_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCanInvoicingReqModel() != null) {
					
					oprot.WriteFieldBegin("canInvoicingReqModel");
					
					com.vip.fcs.vei.service.CanInvoicingReqModel3Helper.getInstance().Write(structs.GetCanInvoicingReqModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(canInvoicing3_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class canInvoicing4_argsHelper : TBeanSerializer<canInvoicing4_args>
		{
			
			public static canInvoicing4_argsHelper OBJ = new canInvoicing4_argsHelper();
			
			public static canInvoicing4_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(canInvoicing4_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.CanInvoicingReqModel4 value;
					
					value = new com.vip.fcs.vei.service.CanInvoicingReqModel4();
					com.vip.fcs.vei.service.CanInvoicingReqModel4Helper.getInstance().Read(value, iprot);
					
					structs.SetCanInvoicingReqModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(canInvoicing4_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCanInvoicingReqModel() != null) {
					
					oprot.WriteFieldBegin("canInvoicingReqModel");
					
					com.vip.fcs.vei.service.CanInvoicingReqModel4Helper.getInstance().Write(structs.GetCanInvoicingReqModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(canInvoicing4_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class downloadElectronicInvoice_argsHelper : TBeanSerializer<downloadElectronicInvoice_args>
		{
			
			public static downloadElectronicInvoice_argsHelper OBJ = new downloadElectronicInvoice_argsHelper();
			
			public static downloadElectronicInvoice_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(downloadElectronicInvoice_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel value;
					
					value = new com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel();
					com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModelHelper.getInstance().Read(value, iprot);
					
					structs.SetReqModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(downloadElectronicInvoice_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReqModel() != null) {
					
					oprot.WriteFieldBegin("reqModel");
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModelHelper.getInstance().Write(structs.GetReqModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("reqModel can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(downloadElectronicInvoice_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class downloadElectronicInvoice2_argsHelper : TBeanSerializer<downloadElectronicInvoice2_args>
		{
			
			public static downloadElectronicInvoice2_argsHelper OBJ = new downloadElectronicInvoice2_argsHelper();
			
			public static downloadElectronicInvoice2_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(downloadElectronicInvoice2_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2 value;
					
					value = new com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2();
					com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2Helper.getInstance().Read(value, iprot);
					
					structs.SetReqModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(downloadElectronicInvoice2_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReqModel() != null) {
					
					oprot.WriteFieldBegin("reqModel");
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2Helper.getInstance().Write(structs.GetReqModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("reqModel can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(downloadElectronicInvoice2_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class downloadElectronicInvoicePicture_argsHelper : TBeanSerializer<downloadElectronicInvoicePicture_args>
		{
			
			public static downloadElectronicInvoicePicture_argsHelper OBJ = new downloadElectronicInvoicePicture_argsHelper();
			
			public static downloadElectronicInvoicePicture_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(downloadElectronicInvoicePicture_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.DownloadElectronicInvoicePictureReqModel value;
					
					value = new com.vip.fcs.vei.service.DownloadElectronicInvoicePictureReqModel();
					com.vip.fcs.vei.service.DownloadElectronicInvoicePictureReqModelHelper.getInstance().Read(value, iprot);
					
					structs.SetReqModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(downloadElectronicInvoicePicture_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReqModel() != null) {
					
					oprot.WriteFieldBegin("reqModel");
					
					com.vip.fcs.vei.service.DownloadElectronicInvoicePictureReqModelHelper.getInstance().Write(structs.GetReqModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("reqModel can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(downloadElectronicInvoicePicture_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class downloadMedicineElectronicInvoice_argsHelper : TBeanSerializer<downloadMedicineElectronicInvoice_args>
		{
			
			public static downloadMedicineElectronicInvoice_argsHelper OBJ = new downloadMedicineElectronicInvoice_argsHelper();
			
			public static downloadMedicineElectronicInvoice_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(downloadMedicineElectronicInvoice_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2 value;
					
					value = new com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2();
					com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2Helper.getInstance().Read(value, iprot);
					
					structs.SetReqModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(downloadMedicineElectronicInvoice_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReqModel() != null) {
					
					oprot.WriteFieldBegin("reqModel");
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2Helper.getInstance().Write(structs.GetReqModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("reqModel can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(downloadMedicineElectronicInvoice_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class downloadRedElectronicInvoice_argsHelper : TBeanSerializer<downloadRedElectronicInvoice_args>
		{
			
			public static downloadRedElectronicInvoice_argsHelper OBJ = new downloadRedElectronicInvoice_argsHelper();
			
			public static downloadRedElectronicInvoice_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(downloadRedElectronicInvoice_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel value;
					
					value = new com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel();
					com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModelHelper.getInstance().Read(value, iprot);
					
					structs.SetReqModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(downloadRedElectronicInvoice_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReqModel() != null) {
					
					oprot.WriteFieldBegin("reqModel");
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModelHelper.getInstance().Write(structs.GetReqModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("reqModel can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(downloadRedElectronicInvoice_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getExternalInvoiceHandleState_argsHelper : TBeanSerializer<getExternalInvoiceHandleState_args>
		{
			
			public static getExternalInvoiceHandleState_argsHelper OBJ = new getExternalInvoiceHandleState_argsHelper();
			
			public static getExternalInvoiceHandleState_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getExternalInvoiceHandleState_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.ExternalInvoiceHandleStateReqModel value;
					
					value = new com.vip.fcs.vei.service.ExternalInvoiceHandleStateReqModel();
					com.vip.fcs.vei.service.ExternalInvoiceHandleStateReqModelHelper.getInstance().Read(value, iprot);
					
					structs.SetReqModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getExternalInvoiceHandleState_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReqModel() != null) {
					
					oprot.WriteFieldBegin("reqModel");
					
					com.vip.fcs.vei.service.ExternalInvoiceHandleStateReqModelHelper.getInstance().Write(structs.GetReqModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("reqModel can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getExternalInvoiceHandleState_args bean){
				
				
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
		
		
		
		
		public class invoiceOrderData_argsHelper : TBeanSerializer<invoiceOrderData_args>
		{
			
			public static invoiceOrderData_argsHelper OBJ = new invoiceOrderData_argsHelper();
			
			public static invoiceOrderData_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(invoiceOrderData_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.InvoiceOrderDataReqModel value;
					
					value = new com.vip.fcs.vei.service.InvoiceOrderDataReqModel();
					com.vip.fcs.vei.service.InvoiceOrderDataReqModelHelper.getInstance().Read(value, iprot);
					
					structs.SetReqModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(invoiceOrderData_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReqModel() != null) {
					
					oprot.WriteFieldBegin("reqModel");
					
					com.vip.fcs.vei.service.InvoiceOrderDataReqModelHelper.getInstance().Write(structs.GetReqModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("reqModel can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(invoiceOrderData_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class vCanInvoicing_argsHelper : TBeanSerializer<vCanInvoicing_args>
		{
			
			public static vCanInvoicing_argsHelper OBJ = new vCanInvoicing_argsHelper();
			
			public static vCanInvoicing_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(vCanInvoicing_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.VCanInvoicingReqModel value;
					
					value = new com.vip.fcs.vei.service.VCanInvoicingReqModel();
					com.vip.fcs.vei.service.VCanInvoicingReqModelHelper.getInstance().Read(value, iprot);
					
					structs.SetReqModel(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(vCanInvoicing_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetReqModel() != null) {
					
					oprot.WriteFieldBegin("reqModel");
					
					com.vip.fcs.vei.service.VCanInvoicingReqModelHelper.getInstance().Write(structs.GetReqModel(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("reqModel can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(vCanInvoicing_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class acceptExternalInvoiceData_resultHelper : TBeanSerializer<acceptExternalInvoiceData_result>
		{
			
			public static acceptExternalInvoiceData_resultHelper OBJ = new acceptExternalInvoiceData_resultHelper();
			
			public static acceptExternalInvoiceData_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(acceptExternalInvoiceData_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.BaseRetMsg value;
					
					value = new com.vip.fcs.vei.service.BaseRetMsg();
					com.vip.fcs.vei.service.BaseRetMsgHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(acceptExternalInvoiceData_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.fcs.vei.service.BaseRetMsgHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(acceptExternalInvoiceData_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class canInvoicing_resultHelper : TBeanSerializer<canInvoicing_result>
		{
			
			public static canInvoicing_resultHelper OBJ = new canInvoicing_resultHelper();
			
			public static canInvoicing_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(canInvoicing_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.CanInvoicingResModel value;
					
					value = new com.vip.fcs.vei.service.CanInvoicingResModel();
					com.vip.fcs.vei.service.CanInvoicingResModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(canInvoicing_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.fcs.vei.service.CanInvoicingResModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(canInvoicing_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class canInvoicing2_resultHelper : TBeanSerializer<canInvoicing2_result>
		{
			
			public static canInvoicing2_resultHelper OBJ = new canInvoicing2_resultHelper();
			
			public static canInvoicing2_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(canInvoicing2_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.CanInvoicingResModel2 value;
					
					value = new com.vip.fcs.vei.service.CanInvoicingResModel2();
					com.vip.fcs.vei.service.CanInvoicingResModel2Helper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(canInvoicing2_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.fcs.vei.service.CanInvoicingResModel2Helper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(canInvoicing2_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class canInvoicing3_resultHelper : TBeanSerializer<canInvoicing3_result>
		{
			
			public static canInvoicing3_resultHelper OBJ = new canInvoicing3_resultHelper();
			
			public static canInvoicing3_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(canInvoicing3_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.CanInvoicingResModel3 value;
					
					value = new com.vip.fcs.vei.service.CanInvoicingResModel3();
					com.vip.fcs.vei.service.CanInvoicingResModel3Helper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(canInvoicing3_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.fcs.vei.service.CanInvoicingResModel3Helper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(canInvoicing3_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class canInvoicing4_resultHelper : TBeanSerializer<canInvoicing4_result>
		{
			
			public static canInvoicing4_resultHelper OBJ = new canInvoicing4_resultHelper();
			
			public static canInvoicing4_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(canInvoicing4_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.CanInvoicingResModel4 value;
					
					value = new com.vip.fcs.vei.service.CanInvoicingResModel4();
					com.vip.fcs.vei.service.CanInvoicingResModel4Helper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(canInvoicing4_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.fcs.vei.service.CanInvoicingResModel4Helper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(canInvoicing4_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class downloadElectronicInvoice_resultHelper : TBeanSerializer<downloadElectronicInvoice_result>
		{
			
			public static downloadElectronicInvoice_resultHelper OBJ = new downloadElectronicInvoice_resultHelper();
			
			public static downloadElectronicInvoice_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(downloadElectronicInvoice_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel value;
					
					value = new com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel();
					com.vip.fcs.vei.service.DownloadElectronicInvoiceResModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(downloadElectronicInvoice_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceResModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(downloadElectronicInvoice_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class downloadElectronicInvoice2_resultHelper : TBeanSerializer<downloadElectronicInvoice2_result>
		{
			
			public static downloadElectronicInvoice2_resultHelper OBJ = new downloadElectronicInvoice2_resultHelper();
			
			public static downloadElectronicInvoice2_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(downloadElectronicInvoice2_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel value;
					
					value = new com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel();
					com.vip.fcs.vei.service.DownloadElectronicInvoiceResModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(downloadElectronicInvoice2_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceResModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(downloadElectronicInvoice2_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class downloadElectronicInvoicePicture_resultHelper : TBeanSerializer<downloadElectronicInvoicePicture_result>
		{
			
			public static downloadElectronicInvoicePicture_resultHelper OBJ = new downloadElectronicInvoicePicture_resultHelper();
			
			public static downloadElectronicInvoicePicture_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(downloadElectronicInvoicePicture_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.DownloadElectronicInvoicePictureResModel value;
					
					value = new com.vip.fcs.vei.service.DownloadElectronicInvoicePictureResModel();
					com.vip.fcs.vei.service.DownloadElectronicInvoicePictureResModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(downloadElectronicInvoicePicture_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.fcs.vei.service.DownloadElectronicInvoicePictureResModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(downloadElectronicInvoicePicture_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class downloadMedicineElectronicInvoice_resultHelper : TBeanSerializer<downloadMedicineElectronicInvoice_result>
		{
			
			public static downloadMedicineElectronicInvoice_resultHelper OBJ = new downloadMedicineElectronicInvoice_resultHelper();
			
			public static downloadMedicineElectronicInvoice_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(downloadMedicineElectronicInvoice_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel value;
					
					value = new com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel();
					com.vip.fcs.vei.service.DownloadElectronicInvoiceResModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(downloadMedicineElectronicInvoice_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceResModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(downloadMedicineElectronicInvoice_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class downloadRedElectronicInvoice_resultHelper : TBeanSerializer<downloadRedElectronicInvoice_result>
		{
			
			public static downloadRedElectronicInvoice_resultHelper OBJ = new downloadRedElectronicInvoice_resultHelper();
			
			public static downloadRedElectronicInvoice_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(downloadRedElectronicInvoice_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel value;
					
					value = new com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel();
					com.vip.fcs.vei.service.DownloadElectronicInvoiceResModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(downloadRedElectronicInvoice_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.fcs.vei.service.DownloadElectronicInvoiceResModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(downloadRedElectronicInvoice_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getExternalInvoiceHandleState_resultHelper : TBeanSerializer<getExternalInvoiceHandleState_result>
		{
			
			public static getExternalInvoiceHandleState_resultHelper OBJ = new getExternalInvoiceHandleState_resultHelper();
			
			public static getExternalInvoiceHandleState_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getExternalInvoiceHandleState_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.ExternalInvoiceHandleStateResModel value;
					
					value = new com.vip.fcs.vei.service.ExternalInvoiceHandleStateResModel();
					com.vip.fcs.vei.service.ExternalInvoiceHandleStateResModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getExternalInvoiceHandleState_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.fcs.vei.service.ExternalInvoiceHandleStateResModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getExternalInvoiceHandleState_result bean){
				
				
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
		
		
		
		
		public class invoiceOrderData_resultHelper : TBeanSerializer<invoiceOrderData_result>
		{
			
			public static invoiceOrderData_resultHelper OBJ = new invoiceOrderData_resultHelper();
			
			public static invoiceOrderData_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(invoiceOrderData_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.InvoiceOrderDataResModel value;
					
					value = new com.vip.fcs.vei.service.InvoiceOrderDataResModel();
					com.vip.fcs.vei.service.InvoiceOrderDataResModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(invoiceOrderData_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.fcs.vei.service.InvoiceOrderDataResModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(invoiceOrderData_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class vCanInvoicing_resultHelper : TBeanSerializer<vCanInvoicing_result>
		{
			
			public static vCanInvoicing_resultHelper OBJ = new vCanInvoicing_resultHelper();
			
			public static vCanInvoicing_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(vCanInvoicing_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.fcs.vei.service.VCanInvoicingResModel value;
					
					value = new com.vip.fcs.vei.service.VCanInvoicingResModel();
					com.vip.fcs.vei.service.VCanInvoicingResModelHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(vCanInvoicing_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					com.vip.fcs.vei.service.VCanInvoicingResModelHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(vCanInvoicing_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VeiServiceClient : OspRestStub , VeiService  {
			
			
			public VeiServiceClient():base("vipapis.fcs.VeiService","1.0.0") {
				
				
			}
			
			
			
			public com.vip.fcs.vei.service.BaseRetMsg acceptExternalInvoiceData(com.vip.fcs.vei.service.EinvoiceVo einvoiceVo_) {
				
				send_acceptExternalInvoiceData(einvoiceVo_);
				return recv_acceptExternalInvoiceData(); 
				
			}
			
			
			private void send_acceptExternalInvoiceData(com.vip.fcs.vei.service.EinvoiceVo einvoiceVo_){
				
				InitInvocation("acceptExternalInvoiceData");
				
				acceptExternalInvoiceData_args args = new acceptExternalInvoiceData_args();
				args.SetEinvoiceVo(einvoiceVo_);
				
				SendBase(args, acceptExternalInvoiceData_argsHelper.getInstance());
			}
			
			
			private com.vip.fcs.vei.service.BaseRetMsg recv_acceptExternalInvoiceData(){
				
				acceptExternalInvoiceData_result result = new acceptExternalInvoiceData_result();
				ReceiveBase(result, acceptExternalInvoiceData_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.fcs.vei.service.CanInvoicingResModel canInvoicing(com.vip.fcs.vei.service.CanInvoicingReqModel canInvoicingReqModel_) {
				
				send_canInvoicing(canInvoicingReqModel_);
				return recv_canInvoicing(); 
				
			}
			
			
			private void send_canInvoicing(com.vip.fcs.vei.service.CanInvoicingReqModel canInvoicingReqModel_){
				
				InitInvocation("canInvoicing");
				
				canInvoicing_args args = new canInvoicing_args();
				args.SetCanInvoicingReqModel(canInvoicingReqModel_);
				
				SendBase(args, canInvoicing_argsHelper.getInstance());
			}
			
			
			private com.vip.fcs.vei.service.CanInvoicingResModel recv_canInvoicing(){
				
				canInvoicing_result result = new canInvoicing_result();
				ReceiveBase(result, canInvoicing_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.fcs.vei.service.CanInvoicingResModel2 canInvoicing2(com.vip.fcs.vei.service.CanInvoicingReqModel canInvoicingReqModel_) {
				
				send_canInvoicing2(canInvoicingReqModel_);
				return recv_canInvoicing2(); 
				
			}
			
			
			private void send_canInvoicing2(com.vip.fcs.vei.service.CanInvoicingReqModel canInvoicingReqModel_){
				
				InitInvocation("canInvoicing2");
				
				canInvoicing2_args args = new canInvoicing2_args();
				args.SetCanInvoicingReqModel(canInvoicingReqModel_);
				
				SendBase(args, canInvoicing2_argsHelper.getInstance());
			}
			
			
			private com.vip.fcs.vei.service.CanInvoicingResModel2 recv_canInvoicing2(){
				
				canInvoicing2_result result = new canInvoicing2_result();
				ReceiveBase(result, canInvoicing2_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.fcs.vei.service.CanInvoicingResModel3 canInvoicing3(com.vip.fcs.vei.service.CanInvoicingReqModel3 canInvoicingReqModel_) {
				
				send_canInvoicing3(canInvoicingReqModel_);
				return recv_canInvoicing3(); 
				
			}
			
			
			private void send_canInvoicing3(com.vip.fcs.vei.service.CanInvoicingReqModel3 canInvoicingReqModel_){
				
				InitInvocation("canInvoicing3");
				
				canInvoicing3_args args = new canInvoicing3_args();
				args.SetCanInvoicingReqModel(canInvoicingReqModel_);
				
				SendBase(args, canInvoicing3_argsHelper.getInstance());
			}
			
			
			private com.vip.fcs.vei.service.CanInvoicingResModel3 recv_canInvoicing3(){
				
				canInvoicing3_result result = new canInvoicing3_result();
				ReceiveBase(result, canInvoicing3_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.fcs.vei.service.CanInvoicingResModel4 canInvoicing4(com.vip.fcs.vei.service.CanInvoicingReqModel4 canInvoicingReqModel_) {
				
				send_canInvoicing4(canInvoicingReqModel_);
				return recv_canInvoicing4(); 
				
			}
			
			
			private void send_canInvoicing4(com.vip.fcs.vei.service.CanInvoicingReqModel4 canInvoicingReqModel_){
				
				InitInvocation("canInvoicing4");
				
				canInvoicing4_args args = new canInvoicing4_args();
				args.SetCanInvoicingReqModel(canInvoicingReqModel_);
				
				SendBase(args, canInvoicing4_argsHelper.getInstance());
			}
			
			
			private com.vip.fcs.vei.service.CanInvoicingResModel4 recv_canInvoicing4(){
				
				canInvoicing4_result result = new canInvoicing4_result();
				ReceiveBase(result, canInvoicing4_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel downloadElectronicInvoice(com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel reqModel_) {
				
				send_downloadElectronicInvoice(reqModel_);
				return recv_downloadElectronicInvoice(); 
				
			}
			
			
			private void send_downloadElectronicInvoice(com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel reqModel_){
				
				InitInvocation("downloadElectronicInvoice");
				
				downloadElectronicInvoice_args args = new downloadElectronicInvoice_args();
				args.SetReqModel(reqModel_);
				
				SendBase(args, downloadElectronicInvoice_argsHelper.getInstance());
			}
			
			
			private com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel recv_downloadElectronicInvoice(){
				
				downloadElectronicInvoice_result result = new downloadElectronicInvoice_result();
				ReceiveBase(result, downloadElectronicInvoice_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel downloadElectronicInvoice2(com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2 reqModel_) {
				
				send_downloadElectronicInvoice2(reqModel_);
				return recv_downloadElectronicInvoice2(); 
				
			}
			
			
			private void send_downloadElectronicInvoice2(com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2 reqModel_){
				
				InitInvocation("downloadElectronicInvoice2");
				
				downloadElectronicInvoice2_args args = new downloadElectronicInvoice2_args();
				args.SetReqModel(reqModel_);
				
				SendBase(args, downloadElectronicInvoice2_argsHelper.getInstance());
			}
			
			
			private com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel recv_downloadElectronicInvoice2(){
				
				downloadElectronicInvoice2_result result = new downloadElectronicInvoice2_result();
				ReceiveBase(result, downloadElectronicInvoice2_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.fcs.vei.service.DownloadElectronicInvoicePictureResModel downloadElectronicInvoicePicture(com.vip.fcs.vei.service.DownloadElectronicInvoicePictureReqModel reqModel_) {
				
				send_downloadElectronicInvoicePicture(reqModel_);
				return recv_downloadElectronicInvoicePicture(); 
				
			}
			
			
			private void send_downloadElectronicInvoicePicture(com.vip.fcs.vei.service.DownloadElectronicInvoicePictureReqModel reqModel_){
				
				InitInvocation("downloadElectronicInvoicePicture");
				
				downloadElectronicInvoicePicture_args args = new downloadElectronicInvoicePicture_args();
				args.SetReqModel(reqModel_);
				
				SendBase(args, downloadElectronicInvoicePicture_argsHelper.getInstance());
			}
			
			
			private com.vip.fcs.vei.service.DownloadElectronicInvoicePictureResModel recv_downloadElectronicInvoicePicture(){
				
				downloadElectronicInvoicePicture_result result = new downloadElectronicInvoicePicture_result();
				ReceiveBase(result, downloadElectronicInvoicePicture_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel downloadMedicineElectronicInvoice(com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2 reqModel_) {
				
				send_downloadMedicineElectronicInvoice(reqModel_);
				return recv_downloadMedicineElectronicInvoice(); 
				
			}
			
			
			private void send_downloadMedicineElectronicInvoice(com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel2 reqModel_){
				
				InitInvocation("downloadMedicineElectronicInvoice");
				
				downloadMedicineElectronicInvoice_args args = new downloadMedicineElectronicInvoice_args();
				args.SetReqModel(reqModel_);
				
				SendBase(args, downloadMedicineElectronicInvoice_argsHelper.getInstance());
			}
			
			
			private com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel recv_downloadMedicineElectronicInvoice(){
				
				downloadMedicineElectronicInvoice_result result = new downloadMedicineElectronicInvoice_result();
				ReceiveBase(result, downloadMedicineElectronicInvoice_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel downloadRedElectronicInvoice(com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel reqModel_) {
				
				send_downloadRedElectronicInvoice(reqModel_);
				return recv_downloadRedElectronicInvoice(); 
				
			}
			
			
			private void send_downloadRedElectronicInvoice(com.vip.fcs.vei.service.DownloadElectronicInvoiceReqModel reqModel_){
				
				InitInvocation("downloadRedElectronicInvoice");
				
				downloadRedElectronicInvoice_args args = new downloadRedElectronicInvoice_args();
				args.SetReqModel(reqModel_);
				
				SendBase(args, downloadRedElectronicInvoice_argsHelper.getInstance());
			}
			
			
			private com.vip.fcs.vei.service.DownloadElectronicInvoiceResModel recv_downloadRedElectronicInvoice(){
				
				downloadRedElectronicInvoice_result result = new downloadRedElectronicInvoice_result();
				ReceiveBase(result, downloadRedElectronicInvoice_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.fcs.vei.service.ExternalInvoiceHandleStateResModel getExternalInvoiceHandleState(com.vip.fcs.vei.service.ExternalInvoiceHandleStateReqModel reqModel_) {
				
				send_getExternalInvoiceHandleState(reqModel_);
				return recv_getExternalInvoiceHandleState(); 
				
			}
			
			
			private void send_getExternalInvoiceHandleState(com.vip.fcs.vei.service.ExternalInvoiceHandleStateReqModel reqModel_){
				
				InitInvocation("getExternalInvoiceHandleState");
				
				getExternalInvoiceHandleState_args args = new getExternalInvoiceHandleState_args();
				args.SetReqModel(reqModel_);
				
				SendBase(args, getExternalInvoiceHandleState_argsHelper.getInstance());
			}
			
			
			private com.vip.fcs.vei.service.ExternalInvoiceHandleStateResModel recv_getExternalInvoiceHandleState(){
				
				getExternalInvoiceHandleState_result result = new getExternalInvoiceHandleState_result();
				ReceiveBase(result, getExternalInvoiceHandleState_resultHelper.getInstance());
				
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
			
			
			public com.vip.fcs.vei.service.InvoiceOrderDataResModel invoiceOrderData(com.vip.fcs.vei.service.InvoiceOrderDataReqModel reqModel_) {
				
				send_invoiceOrderData(reqModel_);
				return recv_invoiceOrderData(); 
				
			}
			
			
			private void send_invoiceOrderData(com.vip.fcs.vei.service.InvoiceOrderDataReqModel reqModel_){
				
				InitInvocation("invoiceOrderData");
				
				invoiceOrderData_args args = new invoiceOrderData_args();
				args.SetReqModel(reqModel_);
				
				SendBase(args, invoiceOrderData_argsHelper.getInstance());
			}
			
			
			private com.vip.fcs.vei.service.InvoiceOrderDataResModel recv_invoiceOrderData(){
				
				invoiceOrderData_result result = new invoiceOrderData_result();
				ReceiveBase(result, invoiceOrderData_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public com.vip.fcs.vei.service.VCanInvoicingResModel vCanInvoicing(com.vip.fcs.vei.service.VCanInvoicingReqModel reqModel_) {
				
				send_vCanInvoicing(reqModel_);
				return recv_vCanInvoicing(); 
				
			}
			
			
			private void send_vCanInvoicing(com.vip.fcs.vei.service.VCanInvoicingReqModel reqModel_){
				
				InitInvocation("vCanInvoicing");
				
				vCanInvoicing_args args = new vCanInvoicing_args();
				args.SetReqModel(reqModel_);
				
				SendBase(args, vCanInvoicing_argsHelper.getInstance());
			}
			
			
			private com.vip.fcs.vei.service.VCanInvoicingResModel recv_vCanInvoicing(){
				
				vCanInvoicing_result result = new vCanInvoicing_result();
				ReceiveBase(result, vCanInvoicing_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}