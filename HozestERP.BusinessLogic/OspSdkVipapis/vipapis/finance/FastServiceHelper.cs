using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.finance{
	
	
	public class FastServiceHelper {
		
		
		
		public class getBasicPickFinancialData_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// po号
			///</summary>
			
			private string po_no_;
			
			///<summary>
			/// 拣货单号（不支持混PO创建的拣货单)
			///</summary>
			
			private string pick_no_;
			
			///<summary>
			/// 页码,默认：1
			///</summary>
			
			private int? page_;
			
			///<summary>
			/// 每页记录数，最大支持50，默认为：50
			///</summary>
			
			private int? limit_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			public string GetPick_no(){
				return this.pick_no_;
			}
			
			public void SetPick_no(string value){
				this.pick_no_ = value;
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
		
		
		
		
		public class getDvdFinancialDetail_args {
			
			///<summary>
			/// 直发财务明细请求
			///</summary>
			
			private vipapis.finance.FinancialDetailRequest detailRequest_;
			
			public vipapis.finance.FinancialDetailRequest GetDetailRequest(){
				return this.detailRequest_;
			}
			
			public void SetDetailRequest(vipapis.finance.FinancialDetailRequest value){
				this.detailRequest_ = value;
			}
			
		}
		
		
		
		
		public class getOrderFinancialData_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 订单号列表（最大支持50）
			///</summary>
			
			private List<string> order_ids_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<string> GetOrder_ids(){
				return this.order_ids_;
			}
			
			public void SetOrder_ids(List<string> value){
				this.order_ids_ = value;
			}
			
		}
		
		
		
		
		public class getPoFinancialDetail_args {
			
			///<summary>
			/// 获取经销业务财务对账数据请求
			///</summary>
			
			private vipapis.finance.GetPoFinancialDetailRequest request_;
			
			public vipapis.finance.GetPoFinancialDetailRequest GetRequest(){
				return this.request_;
			}
			
			public void SetRequest(vipapis.finance.GetPoFinancialDetailRequest value){
				this.request_ = value;
			}
			
		}
		
		
		
		
		public class getSaleDetailData_args {
			
			///<summary>
			/// 供应商ID
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// po号
			///</summary>
			
			private string po_no_;
			
			///<summary>
			/// 查询时间段的开始时间，返回销售明细生成时间在此时间段内的结果（Epoch格式
			///</summary>
			
			private long? st_query_time_;
			
			///<summary>
			/// 查询时间段的结束时间，返回销售明细在此时间段内的结果（Epoch格式)
			///</summary>
			
			private long? et_query_time_;
			
			///<summary>
			/// 每次获取记录数，默认20
			///</summary>
			
			private int? limit_;
			
			///<summary>
			/// 页码
			///</summary>
			
			private int? page_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public string GetPo_no(){
				return this.po_no_;
			}
			
			public void SetPo_no(string value){
				this.po_no_ = value;
			}
			public long? GetSt_query_time(){
				return this.st_query_time_;
			}
			
			public void SetSt_query_time(long? value){
				this.st_query_time_ = value;
			}
			public long? GetEt_query_time(){
				return this.et_query_time_;
			}
			
			public void SetEt_query_time(long? value){
				this.et_query_time_ = value;
			}
			public int? GetLimit(){
				return this.limit_;
			}
			
			public void SetLimit(int? value){
				this.limit_ = value;
			}
			public int? GetPage(){
				return this.page_;
			}
			
			public void SetPage(int? value){
				this.page_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class getBasicPickFinancialData_result {
			
			///<summary>
			/// 查询JIT拣货单下销售明细数据返回
			///</summary>
			
			private vipapis.finance.GetBasicPickFinancialDataResponse success_;
			
			public vipapis.finance.GetBasicPickFinancialDataResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.finance.GetBasicPickFinancialDataResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getDvdFinancialDetail_result {
			
			///<summary>
			/// 返回直发业务财务对账数据
			///</summary>
			
			private vipapis.finance.FinancialDetailResponse success_;
			
			public vipapis.finance.FinancialDetailResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.finance.FinancialDetailResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getOrderFinancialData_result {
			
			///<summary>
			/// 查询直发订单下销售明细数据返回
			///</summary>
			
			private vipapis.finance.GetOrderFinancialDataResponse success_;
			
			public vipapis.finance.GetOrderFinancialDataResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.finance.GetOrderFinancialDataResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getPoFinancialDetail_result {
			
			///<summary>
			/// 返回经销业务财务对账数据
			///</summary>
			
			private vipapis.finance.GetPoFinancialDetailResponse success_;
			
			public vipapis.finance.GetPoFinancialDetailResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.finance.GetPoFinancialDetailResponse value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSaleDetailData_result {
			
			///<summary>
			///</summary>
			
			private vipapis.finance.GetSaleDetailResponse success_;
			
			public vipapis.finance.GetSaleDetailResponse GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.finance.GetSaleDetailResponse value){
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
		
		
		
		
		
		public class getBasicPickFinancialData_argsHelper : TBeanSerializer<getBasicPickFinancialData_args>
		{
			
			public static getBasicPickFinancialData_argsHelper OBJ = new getBasicPickFinancialData_argsHelper();
			
			public static getBasicPickFinancialData_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getBasicPickFinancialData_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPick_no(value);
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
			
			
			public void Write(getBasicPickFinancialData_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("po_no can not be null!");
				}
				
				
				if(structs.GetPick_no() != null) {
					
					oprot.WriteFieldBegin("pick_no");
					oprot.WriteString(structs.GetPick_no());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("pick_no can not be null!");
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
			
			
			public void Validate(getBasicPickFinancialData_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDvdFinancialDetail_argsHelper : TBeanSerializer<getDvdFinancialDetail_args>
		{
			
			public static getDvdFinancialDetail_argsHelper OBJ = new getDvdFinancialDetail_argsHelper();
			
			public static getDvdFinancialDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDvdFinancialDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.finance.FinancialDetailRequest value;
					
					value = new vipapis.finance.FinancialDetailRequest();
					vipapis.finance.FinancialDetailRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetDetailRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDvdFinancialDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetDetailRequest() != null) {
					
					oprot.WriteFieldBegin("detailRequest");
					
					vipapis.finance.FinancialDetailRequestHelper.getInstance().Write(structs.GetDetailRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("detailRequest can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDvdFinancialDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderFinancialData_argsHelper : TBeanSerializer<getOrderFinancialData_args>
		{
			
			public static getOrderFinancialData_argsHelper OBJ = new getOrderFinancialData_argsHelper();
			
			public static getOrderFinancialData_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderFinancialData_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
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
					
					structs.SetOrder_ids(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderFinancialData_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetOrder_ids() != null) {
					
					oprot.WriteFieldBegin("order_ids");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetOrder_ids()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("order_ids can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderFinancialData_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPoFinancialDetail_argsHelper : TBeanSerializer<getPoFinancialDetail_args>
		{
			
			public static getPoFinancialDetail_argsHelper OBJ = new getPoFinancialDetail_argsHelper();
			
			public static getPoFinancialDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPoFinancialDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.finance.GetPoFinancialDetailRequest value;
					
					value = new vipapis.finance.GetPoFinancialDetailRequest();
					vipapis.finance.GetPoFinancialDetailRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetRequest(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPoFinancialDetail_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetRequest() != null) {
					
					oprot.WriteFieldBegin("request");
					
					vipapis.finance.GetPoFinancialDetailRequestHelper.getInstance().Write(structs.GetRequest(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("request can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPoFinancialDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleDetailData_argsHelper : TBeanSerializer<getSaleDetailData_args>
		{
			
			public static getSaleDetailData_argsHelper OBJ = new getSaleDetailData_argsHelper();
			
			public static getSaleDetailData_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleDetailData_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetPo_no(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetSt_query_time(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetEt_query_time(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetLimit(value);
				}
				
				
				
				
				
				if(true){
					
					int? value;
					value = iprot.ReadI32(); 
					
					structs.SetPage(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleDetailData_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetVendor_id() != null) {
					
					oprot.WriteFieldBegin("vendor_id");
					oprot.WriteI32((int)structs.GetVendor_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("vendor_id can not be null!");
				}
				
				
				if(structs.GetPo_no() != null) {
					
					oprot.WriteFieldBegin("po_no");
					oprot.WriteString(structs.GetPo_no());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetSt_query_time() != null) {
					
					oprot.WriteFieldBegin("st_query_time");
					oprot.WriteI64((long)structs.GetSt_query_time()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("st_query_time can not be null!");
				}
				
				
				if(structs.GetEt_query_time() != null) {
					
					oprot.WriteFieldBegin("et_query_time");
					oprot.WriteI64((long)structs.GetEt_query_time()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("et_query_time can not be null!");
				}
				
				
				if(structs.GetLimit() != null) {
					
					oprot.WriteFieldBegin("limit");
					oprot.WriteI32((int)structs.GetLimit()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetPage() != null) {
					
					oprot.WriteFieldBegin("page");
					oprot.WriteI32((int)structs.GetPage()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleDetailData_args bean){
				
				
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
		
		
		
		
		public class getBasicPickFinancialData_resultHelper : TBeanSerializer<getBasicPickFinancialData_result>
		{
			
			public static getBasicPickFinancialData_resultHelper OBJ = new getBasicPickFinancialData_resultHelper();
			
			public static getBasicPickFinancialData_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getBasicPickFinancialData_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.finance.GetBasicPickFinancialDataResponse value;
					
					value = new vipapis.finance.GetBasicPickFinancialDataResponse();
					vipapis.finance.GetBasicPickFinancialDataResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getBasicPickFinancialData_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.finance.GetBasicPickFinancialDataResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getBasicPickFinancialData_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getDvdFinancialDetail_resultHelper : TBeanSerializer<getDvdFinancialDetail_result>
		{
			
			public static getDvdFinancialDetail_resultHelper OBJ = new getDvdFinancialDetail_resultHelper();
			
			public static getDvdFinancialDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getDvdFinancialDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.finance.FinancialDetailResponse value;
					
					value = new vipapis.finance.FinancialDetailResponse();
					vipapis.finance.FinancialDetailResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getDvdFinancialDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.finance.FinancialDetailResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getDvdFinancialDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getOrderFinancialData_resultHelper : TBeanSerializer<getOrderFinancialData_result>
		{
			
			public static getOrderFinancialData_resultHelper OBJ = new getOrderFinancialData_resultHelper();
			
			public static getOrderFinancialData_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getOrderFinancialData_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.finance.GetOrderFinancialDataResponse value;
					
					value = new vipapis.finance.GetOrderFinancialDataResponse();
					vipapis.finance.GetOrderFinancialDataResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getOrderFinancialData_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.finance.GetOrderFinancialDataResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getOrderFinancialData_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getPoFinancialDetail_resultHelper : TBeanSerializer<getPoFinancialDetail_result>
		{
			
			public static getPoFinancialDetail_resultHelper OBJ = new getPoFinancialDetail_resultHelper();
			
			public static getPoFinancialDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getPoFinancialDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.finance.GetPoFinancialDetailResponse value;
					
					value = new vipapis.finance.GetPoFinancialDetailResponse();
					vipapis.finance.GetPoFinancialDetailResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getPoFinancialDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.finance.GetPoFinancialDetailResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getPoFinancialDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSaleDetailData_resultHelper : TBeanSerializer<getSaleDetailData_result>
		{
			
			public static getSaleDetailData_resultHelper OBJ = new getSaleDetailData_resultHelper();
			
			public static getSaleDetailData_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSaleDetailData_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.finance.GetSaleDetailResponse value;
					
					value = new vipapis.finance.GetSaleDetailResponse();
					vipapis.finance.GetSaleDetailResponseHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSaleDetailData_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.finance.GetSaleDetailResponseHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSaleDetailData_result bean){
				
				
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
		
		
		
		
		public class FastServiceClient : OspRestStub , FastService  {
			
			
			public FastServiceClient():base("vipapis.finance.FastService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.finance.GetBasicPickFinancialDataResponse getBasicPickFinancialData(int vendor_id_,string po_no_,string pick_no_,int? page_,int? limit_) {
				
				send_getBasicPickFinancialData(vendor_id_,po_no_,pick_no_,page_,limit_);
				return recv_getBasicPickFinancialData(); 
				
			}
			
			
			private void send_getBasicPickFinancialData(int vendor_id_,string po_no_,string pick_no_,int? page_,int? limit_){
				
				InitInvocation("getBasicPickFinancialData");
				
				getBasicPickFinancialData_args args = new getBasicPickFinancialData_args();
				args.SetVendor_id(vendor_id_);
				args.SetPo_no(po_no_);
				args.SetPick_no(pick_no_);
				args.SetPage(page_);
				args.SetLimit(limit_);
				
				SendBase(args, getBasicPickFinancialData_argsHelper.getInstance());
			}
			
			
			private vipapis.finance.GetBasicPickFinancialDataResponse recv_getBasicPickFinancialData(){
				
				getBasicPickFinancialData_result result = new getBasicPickFinancialData_result();
				ReceiveBase(result, getBasicPickFinancialData_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.finance.FinancialDetailResponse getDvdFinancialDetail(vipapis.finance.FinancialDetailRequest detailRequest_) {
				
				send_getDvdFinancialDetail(detailRequest_);
				return recv_getDvdFinancialDetail(); 
				
			}
			
			
			private void send_getDvdFinancialDetail(vipapis.finance.FinancialDetailRequest detailRequest_){
				
				InitInvocation("getDvdFinancialDetail");
				
				getDvdFinancialDetail_args args = new getDvdFinancialDetail_args();
				args.SetDetailRequest(detailRequest_);
				
				SendBase(args, getDvdFinancialDetail_argsHelper.getInstance());
			}
			
			
			private vipapis.finance.FinancialDetailResponse recv_getDvdFinancialDetail(){
				
				getDvdFinancialDetail_result result = new getDvdFinancialDetail_result();
				ReceiveBase(result, getDvdFinancialDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.finance.GetOrderFinancialDataResponse getOrderFinancialData(int vendor_id_,List<string> order_ids_) {
				
				send_getOrderFinancialData(vendor_id_,order_ids_);
				return recv_getOrderFinancialData(); 
				
			}
			
			
			private void send_getOrderFinancialData(int vendor_id_,List<string> order_ids_){
				
				InitInvocation("getOrderFinancialData");
				
				getOrderFinancialData_args args = new getOrderFinancialData_args();
				args.SetVendor_id(vendor_id_);
				args.SetOrder_ids(order_ids_);
				
				SendBase(args, getOrderFinancialData_argsHelper.getInstance());
			}
			
			
			private vipapis.finance.GetOrderFinancialDataResponse recv_getOrderFinancialData(){
				
				getOrderFinancialData_result result = new getOrderFinancialData_result();
				ReceiveBase(result, getOrderFinancialData_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.finance.GetPoFinancialDetailResponse getPoFinancialDetail(vipapis.finance.GetPoFinancialDetailRequest request_) {
				
				send_getPoFinancialDetail(request_);
				return recv_getPoFinancialDetail(); 
				
			}
			
			
			private void send_getPoFinancialDetail(vipapis.finance.GetPoFinancialDetailRequest request_){
				
				InitInvocation("getPoFinancialDetail");
				
				getPoFinancialDetail_args args = new getPoFinancialDetail_args();
				args.SetRequest(request_);
				
				SendBase(args, getPoFinancialDetail_argsHelper.getInstance());
			}
			
			
			private vipapis.finance.GetPoFinancialDetailResponse recv_getPoFinancialDetail(){
				
				getPoFinancialDetail_result result = new getPoFinancialDetail_result();
				ReceiveBase(result, getPoFinancialDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.finance.GetSaleDetailResponse getSaleDetailData(int vendor_id_,string po_no_,long st_query_time_,long et_query_time_,int? limit_,int? page_) {
				
				send_getSaleDetailData(vendor_id_,po_no_,st_query_time_,et_query_time_,limit_,page_);
				return recv_getSaleDetailData(); 
				
			}
			
			
			private void send_getSaleDetailData(int vendor_id_,string po_no_,long st_query_time_,long et_query_time_,int? limit_,int? page_){
				
				InitInvocation("getSaleDetailData");
				
				getSaleDetailData_args args = new getSaleDetailData_args();
				args.SetVendor_id(vendor_id_);
				args.SetPo_no(po_no_);
				args.SetSt_query_time(st_query_time_);
				args.SetEt_query_time(et_query_time_);
				args.SetLimit(limit_);
				args.SetPage(page_);
				
				SendBase(args, getSaleDetailData_argsHelper.getInstance());
			}
			
			
			private vipapis.finance.GetSaleDetailResponse recv_getSaleDetailData(){
				
				getSaleDetailData_result result = new getSaleDetailData_result();
				ReceiveBase(result, getSaleDetailData_resultHelper.getInstance());
				
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