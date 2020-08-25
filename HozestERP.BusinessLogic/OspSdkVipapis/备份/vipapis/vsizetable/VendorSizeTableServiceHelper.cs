using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.vsizetable{
	
	
	public class VendorSizeTableServiceHelper {
		
		
		
		public class addSizeDetail_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 尺码表详情（必须：name、sizetable_id）
			///</summary>
			
			private vipapis.vsizetable.SizeDetailRequest sizedetail_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public vipapis.vsizetable.SizeDetailRequest GetSizedetail(){
				return this.sizedetail_;
			}
			
			public void SetSizedetail(vipapis.vsizetable.SizeDetailRequest value){
				this.sizedetail_ = value;
			}
			
		}
		
		
		
		
		public class addSizeTableInfo_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 尺码表对象（必须：type）
			///</summary>
			
			private vipapis.vsizetable.SizeTableInfoRequest sizetable_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public vipapis.vsizetable.SizeTableInfoRequest GetSizetable(){
				return this.sizetable_;
			}
			
			public void SetSizetable(vipapis.vsizetable.SizeTableInfoRequest value){
				this.sizetable_ = value;
			}
			
		}
		
		
		
		
		public class deleteSizeDetailByIds_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 尺码表详情Id列表
			///</summary>
			
			private List<long?> sizedetail_ids_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<long?> GetSizedetail_ids(){
				return this.sizedetail_ids_;
			}
			
			public void SetSizedetail_ids(List<long?> value){
				this.sizedetail_ids_ = value;
			}
			
		}
		
		
		
		
		public class deleteSizeTable_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 尺码表ID
			///</summary>
			
			private long? sizetable_id_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public long? GetSizetable_id(){
				return this.sizetable_id_;
			}
			
			public void SetSizetable_id(long? value){
				this.sizetable_id_ = value;
			}
			
		}
		
		
		
		
		public class getSizeDetailList_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 尺码表ID
			///</summary>
			
			private long? sizetable_id_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public long? GetSizetable_id(){
				return this.sizetable_id_;
			}
			
			public void SetSizetable_id(long? value){
				this.sizetable_id_ = value;
			}
			
		}
		
		
		
		
		public class getSizeDetailListByIds_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 尺码表详情Id列表
			///</summary>
			
			private List<long?> sizedetail_ids_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public List<long?> GetSizedetail_ids(){
				return this.sizedetail_ids_;
			}
			
			public void SetSizedetail_ids(List<long?> value){
				this.sizedetail_ids_ = value;
			}
			
		}
		
		
		
		
		public class getSizeTableInfo_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 尺码表ID
			///</summary>
			
			private long? sizetable_id_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public long? GetSizetable_id(){
				return this.sizetable_id_;
			}
			
			public void SetSizetable_id(long? value){
				this.sizetable_id_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class updateSizeDetail_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 尺码表详情（必须：name、sizetable_id）
			///</summary>
			
			private vipapis.vsizetable.SizeDetailRequest sizedetail_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public vipapis.vsizetable.SizeDetailRequest GetSizedetail(){
				return this.sizedetail_;
			}
			
			public void SetSizedetail(vipapis.vsizetable.SizeDetailRequest value){
				this.sizedetail_ = value;
			}
			
		}
		
		
		
		
		public class updateSizeTableInfo_args {
			
			///<summary>
			/// 供应商id
			///</summary>
			
			private int? vendor_id_;
			
			///<summary>
			/// 尺码表对象（必须：id、type）
			///</summary>
			
			private vipapis.vsizetable.SizeTableInfoRequest sizetable_;
			
			public int? GetVendor_id(){
				return this.vendor_id_;
			}
			
			public void SetVendor_id(int? value){
				this.vendor_id_ = value;
			}
			public vipapis.vsizetable.SizeTableInfoRequest GetSizetable(){
				return this.sizetable_;
			}
			
			public void SetSizetable(vipapis.vsizetable.SizeTableInfoRequest value){
				this.sizetable_ = value;
			}
			
		}
		
		
		
		
		public class addSizeDetail_result {
			
			///<summary>
			/// 尺码表详细信息
			///</summary>
			
			private vipapis.vsizetable.SizeDetail success_;
			
			public vipapis.vsizetable.SizeDetail GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.vsizetable.SizeDetail value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class addSizeTableInfo_result {
			
			///<summary>
			///</summary>
			
			private vipapis.vsizetable.SizeTableInfo success_;
			
			public vipapis.vsizetable.SizeTableInfo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.vsizetable.SizeTableInfo value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class deleteSizeDetailByIds_result {
			
			///<summary>
			/// 删除尺码表ID集
			///</summary>
			
			private List<long?> success_;
			
			public List<long?> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<long?> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class deleteSizeTable_result {
			
			///<summary>
			/// 尺码表ID(sizetable_id)
			///</summary>
			
			private long? success_;
			
			public long? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(long? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSizeDetailList_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.vsizetable.SizeDetail> success_;
			
			public List<vipapis.vsizetable.SizeDetail> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.vsizetable.SizeDetail> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSizeDetailListByIds_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.vsizetable.SizeDetail> success_;
			
			public List<vipapis.vsizetable.SizeDetail> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.vsizetable.SizeDetail> value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getSizeTableInfo_result {
			
			///<summary>
			///</summary>
			
			private vipapis.vsizetable.SizeTableInfo success_;
			
			public vipapis.vsizetable.SizeTableInfo GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(vipapis.vsizetable.SizeTableInfo value){
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
		
		
		
		
		public class updateSizeDetail_result {
			
			///<summary>
			/// 尺码表详情ID(sizedetail_id)
			///</summary>
			
			private long? success_;
			
			public long? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(long? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class updateSizeTableInfo_result {
			
			///<summary>
			/// 尺码表ID(sizetable_id)
			///</summary>
			
			private long? success_;
			
			public long? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(long? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class addSizeDetail_argsHelper : BeanSerializer<addSizeDetail_args>
		{
			
			public static addSizeDetail_argsHelper OBJ = new addSizeDetail_argsHelper();
			
			public static addSizeDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.vsizetable.SizeDetailRequest value;
					
					value = new vipapis.vsizetable.SizeDetailRequest();
					vipapis.vsizetable.SizeDetailRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetSizedetail(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeDetail_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSizedetail() != null) {
					
					oprot.WriteFieldBegin("sizedetail");
					
					vipapis.vsizetable.SizeDetailRequestHelper.getInstance().Write(structs.GetSizedetail(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sizedetail can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addSizeTableInfo_argsHelper : BeanSerializer<addSizeTableInfo_args>
		{
			
			public static addSizeTableInfo_argsHelper OBJ = new addSizeTableInfo_argsHelper();
			
			public static addSizeTableInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeTableInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.vsizetable.SizeTableInfoRequest value;
					
					value = new vipapis.vsizetable.SizeTableInfoRequest();
					vipapis.vsizetable.SizeTableInfoRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetSizetable(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeTableInfo_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSizetable() != null) {
					
					oprot.WriteFieldBegin("sizetable");
					
					vipapis.vsizetable.SizeTableInfoRequestHelper.getInstance().Write(structs.GetSizetable(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sizetable can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeTableInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteSizeDetailByIds_argsHelper : BeanSerializer<deleteSizeDetailByIds_args>
		{
			
			public static deleteSizeDetailByIds_argsHelper OBJ = new deleteSizeDetailByIds_argsHelper();
			
			public static deleteSizeDetailByIds_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteSizeDetailByIds_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
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
					
					structs.SetSizedetail_ids(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteSizeDetailByIds_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSizedetail_ids() != null) {
					
					oprot.WriteFieldBegin("sizedetail_ids");
					
					oprot.WriteListBegin();
					foreach(long _item0 in structs.GetSizedetail_ids()){
						
						oprot.WriteI64((long)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sizedetail_ids can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteSizeDetailByIds_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteSizeTable_argsHelper : BeanSerializer<deleteSizeTable_args>
		{
			
			public static deleteSizeTable_argsHelper OBJ = new deleteSizeTable_argsHelper();
			
			public static deleteSizeTable_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteSizeTable_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetSizetable_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteSizeTable_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSizetable_id() != null) {
					
					oprot.WriteFieldBegin("sizetable_id");
					oprot.WriteI64((long)structs.GetSizetable_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sizetable_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteSizeTable_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSizeDetailList_argsHelper : BeanSerializer<getSizeDetailList_args>
		{
			
			public static getSizeDetailList_argsHelper OBJ = new getSizeDetailList_argsHelper();
			
			public static getSizeDetailList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSizeDetailList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetSizetable_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSizeDetailList_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSizetable_id() != null) {
					
					oprot.WriteFieldBegin("sizetable_id");
					oprot.WriteI64((long)structs.GetSizetable_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sizetable_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSizeDetailList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSizeDetailListByIds_argsHelper : BeanSerializer<getSizeDetailListByIds_args>
		{
			
			public static getSizeDetailListByIds_argsHelper OBJ = new getSizeDetailListByIds_argsHelper();
			
			public static getSizeDetailListByIds_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSizeDetailListByIds_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
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
					
					structs.SetSizedetail_ids(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSizeDetailListByIds_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSizedetail_ids() != null) {
					
					oprot.WriteFieldBegin("sizedetail_ids");
					
					oprot.WriteListBegin();
					foreach(long _item0 in structs.GetSizedetail_ids()){
						
						oprot.WriteI64((long)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sizedetail_ids can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSizeDetailListByIds_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSizeTableInfo_argsHelper : BeanSerializer<getSizeTableInfo_args>
		{
			
			public static getSizeTableInfo_argsHelper OBJ = new getSizeTableInfo_argsHelper();
			
			public static getSizeTableInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSizeTableInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetSizetable_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSizeTableInfo_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSizetable_id() != null) {
					
					oprot.WriteFieldBegin("sizetable_id");
					oprot.WriteI64((long)structs.GetSizetable_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sizetable_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSizeTableInfo_args bean){
				
				
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
		
		
		
		
		public class updateSizeDetail_argsHelper : BeanSerializer<updateSizeDetail_args>
		{
			
			public static updateSizeDetail_argsHelper OBJ = new updateSizeDetail_argsHelper();
			
			public static updateSizeDetail_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSizeDetail_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.vsizetable.SizeDetailRequest value;
					
					value = new vipapis.vsizetable.SizeDetailRequest();
					vipapis.vsizetable.SizeDetailRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetSizedetail(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSizeDetail_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSizedetail() != null) {
					
					oprot.WriteFieldBegin("sizedetail");
					
					vipapis.vsizetable.SizeDetailRequestHelper.getInstance().Write(structs.GetSizedetail(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sizedetail can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSizeDetail_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSizeTableInfo_argsHelper : BeanSerializer<updateSizeTableInfo_args>
		{
			
			public static updateSizeTableInfo_argsHelper OBJ = new updateSizeTableInfo_argsHelper();
			
			public static updateSizeTableInfo_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSizeTableInfo_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetVendor_id(value);
				}
				
				
				
				
				
				if(true){
					
					vipapis.vsizetable.SizeTableInfoRequest value;
					
					value = new vipapis.vsizetable.SizeTableInfoRequest();
					vipapis.vsizetable.SizeTableInfoRequestHelper.getInstance().Read(value, iprot);
					
					structs.SetSizetable(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSizeTableInfo_args structs, Protocol oprot){
				
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
				
				
				if(structs.GetSizetable() != null) {
					
					oprot.WriteFieldBegin("sizetable");
					
					vipapis.vsizetable.SizeTableInfoRequestHelper.getInstance().Write(structs.GetSizetable(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sizetable can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSizeTableInfo_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addSizeDetail_resultHelper : BeanSerializer<addSizeDetail_result>
		{
			
			public static addSizeDetail_resultHelper OBJ = new addSizeDetail_resultHelper();
			
			public static addSizeDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.vsizetable.SizeDetail value;
					
					value = new vipapis.vsizetable.SizeDetail();
					vipapis.vsizetable.SizeDetailHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.vsizetable.SizeDetailHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class addSizeTableInfo_resultHelper : BeanSerializer<addSizeTableInfo_result>
		{
			
			public static addSizeTableInfo_resultHelper OBJ = new addSizeTableInfo_resultHelper();
			
			public static addSizeTableInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(addSizeTableInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.vsizetable.SizeTableInfo value;
					
					value = new vipapis.vsizetable.SizeTableInfo();
					vipapis.vsizetable.SizeTableInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(addSizeTableInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.vsizetable.SizeTableInfoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(addSizeTableInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteSizeDetailByIds_resultHelper : BeanSerializer<deleteSizeDetailByIds_result>
		{
			
			public static deleteSizeDetailByIds_resultHelper OBJ = new deleteSizeDetailByIds_resultHelper();
			
			public static deleteSizeDetailByIds_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteSizeDetailByIds_result structs, Protocol iprot){
				
				
				
				
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
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteSizeDetailByIds_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(long _item0 in structs.GetSuccess()){
						
						oprot.WriteI64((long)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteSizeDetailByIds_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteSizeTable_resultHelper : BeanSerializer<deleteSizeTable_result>
		{
			
			public static deleteSizeTable_resultHelper OBJ = new deleteSizeTable_resultHelper();
			
			public static deleteSizeTable_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteSizeTable_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteSizeTable_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI64((long)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteSizeTable_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSizeDetailList_resultHelper : BeanSerializer<getSizeDetailList_result>
		{
			
			public static getSizeDetailList_resultHelper OBJ = new getSizeDetailList_resultHelper();
			
			public static getSizeDetailList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSizeDetailList_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.vsizetable.SizeDetail> value;
					
					value = new List<vipapis.vsizetable.SizeDetail>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.vsizetable.SizeDetail elem0;
							
							elem0 = new vipapis.vsizetable.SizeDetail();
							vipapis.vsizetable.SizeDetailHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getSizeDetailList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.vsizetable.SizeDetail _item0 in structs.GetSuccess()){
						
						
						vipapis.vsizetable.SizeDetailHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSizeDetailList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSizeDetailListByIds_resultHelper : BeanSerializer<getSizeDetailListByIds_result>
		{
			
			public static getSizeDetailListByIds_resultHelper OBJ = new getSizeDetailListByIds_resultHelper();
			
			public static getSizeDetailListByIds_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSizeDetailListByIds_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.vsizetable.SizeDetail> value;
					
					value = new List<vipapis.vsizetable.SizeDetail>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.vsizetable.SizeDetail elem1;
							
							elem1 = new vipapis.vsizetable.SizeDetail();
							vipapis.vsizetable.SizeDetailHelper.getInstance().Read(elem1, iprot);
							
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
			
			
			public void Write(getSizeDetailListByIds_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.vsizetable.SizeDetail _item0 in structs.GetSuccess()){
						
						
						vipapis.vsizetable.SizeDetailHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSizeDetailListByIds_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getSizeTableInfo_resultHelper : BeanSerializer<getSizeTableInfo_result>
		{
			
			public static getSizeTableInfo_resultHelper OBJ = new getSizeTableInfo_resultHelper();
			
			public static getSizeTableInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getSizeTableInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					vipapis.vsizetable.SizeTableInfo value;
					
					value = new vipapis.vsizetable.SizeTableInfo();
					vipapis.vsizetable.SizeTableInfoHelper.getInstance().Read(value, iprot);
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getSizeTableInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					vipapis.vsizetable.SizeTableInfoHelper.getInstance().Write(structs.GetSuccess(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getSizeTableInfo_result bean){
				
				
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
		
		
		
		
		public class updateSizeDetail_resultHelper : BeanSerializer<updateSizeDetail_result>
		{
			
			public static updateSizeDetail_resultHelper OBJ = new updateSizeDetail_resultHelper();
			
			public static updateSizeDetail_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSizeDetail_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSizeDetail_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI64((long)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSizeDetail_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSizeTableInfo_resultHelper : BeanSerializer<updateSizeTableInfo_result>
		{
			
			public static updateSizeTableInfo_resultHelper OBJ = new updateSizeTableInfo_resultHelper();
			
			public static updateSizeTableInfo_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSizeTableInfo_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSizeTableInfo_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteI64((long)structs.GetSuccess()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSizeTableInfo_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VendorSizeTableServiceClient : OspRestStub , VendorSizeTableService  {
			
			
			public VendorSizeTableServiceClient():base("vipapis.vsizetable.VendorSizeTableService","1.0.0") {
				
				
			}
			
			
			
			public vipapis.vsizetable.SizeDetail addSizeDetail(int vendor_id_,vipapis.vsizetable.SizeDetailRequest sizedetail_) {
				
				send_addSizeDetail(vendor_id_,sizedetail_);
				return recv_addSizeDetail(); 
				
			}
			
			
			private void send_addSizeDetail(int vendor_id_,vipapis.vsizetable.SizeDetailRequest sizedetail_){
				
				InitInvocation("addSizeDetail");
				
				addSizeDetail_args args = new addSizeDetail_args();
				args.SetVendor_id(vendor_id_);
				args.SetSizedetail(sizedetail_);
				
				SendBase(args, addSizeDetail_argsHelper.getInstance());
			}
			
			
			private vipapis.vsizetable.SizeDetail recv_addSizeDetail(){
				
				addSizeDetail_result result = new addSizeDetail_result();
				ReceiveBase(result, addSizeDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.vsizetable.SizeTableInfo addSizeTableInfo(int vendor_id_,vipapis.vsizetable.SizeTableInfoRequest sizetable_) {
				
				send_addSizeTableInfo(vendor_id_,sizetable_);
				return recv_addSizeTableInfo(); 
				
			}
			
			
			private void send_addSizeTableInfo(int vendor_id_,vipapis.vsizetable.SizeTableInfoRequest sizetable_){
				
				InitInvocation("addSizeTableInfo");
				
				addSizeTableInfo_args args = new addSizeTableInfo_args();
				args.SetVendor_id(vendor_id_);
				args.SetSizetable(sizetable_);
				
				SendBase(args, addSizeTableInfo_argsHelper.getInstance());
			}
			
			
			private vipapis.vsizetable.SizeTableInfo recv_addSizeTableInfo(){
				
				addSizeTableInfo_result result = new addSizeTableInfo_result();
				ReceiveBase(result, addSizeTableInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<long?> deleteSizeDetailByIds(int vendor_id_,List<long?> sizedetail_ids_) {
				
				send_deleteSizeDetailByIds(vendor_id_,sizedetail_ids_);
				return recv_deleteSizeDetailByIds(); 
				
			}
			
			
			private void send_deleteSizeDetailByIds(int vendor_id_,List<long?> sizedetail_ids_){
				
				InitInvocation("deleteSizeDetailByIds");
				
				deleteSizeDetailByIds_args args = new deleteSizeDetailByIds_args();
				args.SetVendor_id(vendor_id_);
				args.SetSizedetail_ids(sizedetail_ids_);
				
				SendBase(args, deleteSizeDetailByIds_argsHelper.getInstance());
			}
			
			
			private List<long?> recv_deleteSizeDetailByIds(){
				
				deleteSizeDetailByIds_result result = new deleteSizeDetailByIds_result();
				ReceiveBase(result, deleteSizeDetailByIds_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public long? deleteSizeTable(int vendor_id_,long sizetable_id_) {
				
				send_deleteSizeTable(vendor_id_,sizetable_id_);
				return recv_deleteSizeTable(); 
				
			}
			
			
			private void send_deleteSizeTable(int vendor_id_,long sizetable_id_){
				
				InitInvocation("deleteSizeTable");
				
				deleteSizeTable_args args = new deleteSizeTable_args();
				args.SetVendor_id(vendor_id_);
				args.SetSizetable_id(sizetable_id_);
				
				SendBase(args, deleteSizeTable_argsHelper.getInstance());
			}
			
			
			private long? recv_deleteSizeTable(){
				
				deleteSizeTable_result result = new deleteSizeTable_result();
				ReceiveBase(result, deleteSizeTable_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.vsizetable.SizeDetail> getSizeDetailList(int vendor_id_,long sizetable_id_) {
				
				send_getSizeDetailList(vendor_id_,sizetable_id_);
				return recv_getSizeDetailList(); 
				
			}
			
			
			private void send_getSizeDetailList(int vendor_id_,long sizetable_id_){
				
				InitInvocation("getSizeDetailList");
				
				getSizeDetailList_args args = new getSizeDetailList_args();
				args.SetVendor_id(vendor_id_);
				args.SetSizetable_id(sizetable_id_);
				
				SendBase(args, getSizeDetailList_argsHelper.getInstance());
			}
			
			
			private List<vipapis.vsizetable.SizeDetail> recv_getSizeDetailList(){
				
				getSizeDetailList_result result = new getSizeDetailList_result();
				ReceiveBase(result, getSizeDetailList_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.vsizetable.SizeDetail> getSizeDetailListByIds(int vendor_id_,List<long?> sizedetail_ids_) {
				
				send_getSizeDetailListByIds(vendor_id_,sizedetail_ids_);
				return recv_getSizeDetailListByIds(); 
				
			}
			
			
			private void send_getSizeDetailListByIds(int vendor_id_,List<long?> sizedetail_ids_){
				
				InitInvocation("getSizeDetailListByIds");
				
				getSizeDetailListByIds_args args = new getSizeDetailListByIds_args();
				args.SetVendor_id(vendor_id_);
				args.SetSizedetail_ids(sizedetail_ids_);
				
				SendBase(args, getSizeDetailListByIds_argsHelper.getInstance());
			}
			
			
			private List<vipapis.vsizetable.SizeDetail> recv_getSizeDetailListByIds(){
				
				getSizeDetailListByIds_result result = new getSizeDetailListByIds_result();
				ReceiveBase(result, getSizeDetailListByIds_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public vipapis.vsizetable.SizeTableInfo getSizeTableInfo(int vendor_id_,long sizetable_id_) {
				
				send_getSizeTableInfo(vendor_id_,sizetable_id_);
				return recv_getSizeTableInfo(); 
				
			}
			
			
			private void send_getSizeTableInfo(int vendor_id_,long sizetable_id_){
				
				InitInvocation("getSizeTableInfo");
				
				getSizeTableInfo_args args = new getSizeTableInfo_args();
				args.SetVendor_id(vendor_id_);
				args.SetSizetable_id(sizetable_id_);
				
				SendBase(args, getSizeTableInfo_argsHelper.getInstance());
			}
			
			
			private vipapis.vsizetable.SizeTableInfo recv_getSizeTableInfo(){
				
				getSizeTableInfo_result result = new getSizeTableInfo_result();
				ReceiveBase(result, getSizeTableInfo_resultHelper.getInstance());
				
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
			
			
			public long? updateSizeDetail(int vendor_id_,vipapis.vsizetable.SizeDetailRequest sizedetail_) {
				
				send_updateSizeDetail(vendor_id_,sizedetail_);
				return recv_updateSizeDetail(); 
				
			}
			
			
			private void send_updateSizeDetail(int vendor_id_,vipapis.vsizetable.SizeDetailRequest sizedetail_){
				
				InitInvocation("updateSizeDetail");
				
				updateSizeDetail_args args = new updateSizeDetail_args();
				args.SetVendor_id(vendor_id_);
				args.SetSizedetail(sizedetail_);
				
				SendBase(args, updateSizeDetail_argsHelper.getInstance());
			}
			
			
			private long? recv_updateSizeDetail(){
				
				updateSizeDetail_result result = new updateSizeDetail_result();
				ReceiveBase(result, updateSizeDetail_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public long? updateSizeTableInfo(int vendor_id_,vipapis.vsizetable.SizeTableInfoRequest sizetable_) {
				
				send_updateSizeTableInfo(vendor_id_,sizetable_);
				return recv_updateSizeTableInfo(); 
				
			}
			
			
			private void send_updateSizeTableInfo(int vendor_id_,vipapis.vsizetable.SizeTableInfoRequest sizetable_){
				
				InitInvocation("updateSizeTableInfo");
				
				updateSizeTableInfo_args args = new updateSizeTableInfo_args();
				args.SetVendor_id(vendor_id_);
				args.SetSizetable(sizetable_);
				
				SendBase(args, updateSizeTableInfo_argsHelper.getInstance());
			}
			
			
			private long? recv_updateSizeTableInfo(){
				
				updateSizeTableInfo_result result = new updateSizeTableInfo_result();
				ReceiveBase(result, updateSizeTableInfo_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}