using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace com.vip.vop.vcloud.product{
	
	
	public class DieselProductSelfServiceHelper {
		
		
		
		public class deleteEmailConfig_args {
			
			///<summary>
			/// 合作伙伴id
			///</summary>
			
			private long? partnerId_;
			
			///<summary>
			/// 邮件地址信息
			///</summary>
			
			private string email_;
			
			public long? GetPartnerId(){
				return this.partnerId_;
			}
			
			public void SetPartnerId(long? value){
				this.partnerId_ = value;
			}
			public string GetEmail(){
				return this.email_;
			}
			
			public void SetEmail(string value){
				this.email_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class pushPriceToVdgByIdList_args {
			
			///<summary>
			/// 价格id列表
			///</summary>
			
			private List<long?> idList_;
			
			public List<long?> GetIdList(){
				return this.idList_;
			}
			
			public void SetIdList(List<long?> value){
				this.idList_ = value;
			}
			
		}
		
		
		
		
		public class pushProductToVdgBySkuIdList_args {
			
			///<summary>
			/// 商品skuId列表
			///</summary>
			
			private List<long?> skuIdList_;
			
			public List<long?> GetSkuIdList(){
				return this.skuIdList_;
			}
			
			public void SetSkuIdList(List<long?> value){
				this.skuIdList_ = value;
			}
			
		}
		
		
		
		
		public class pushProductToVdgBySpuIdList_args {
			
			///<summary>
			/// 商品spuId列表
			///</summary>
			
			private List<long?> spuIdList_;
			
			public List<long?> GetSpuIdList(){
				return this.spuIdList_;
			}
			
			public void SetSpuIdList(List<long?> value){
				this.spuIdList_ = value;
			}
			
		}
		
		
		
		
		public class saveEmailConfig_args {
			
			///<summary>
			/// 邮件地址配置
			///</summary>
			
			private com.vip.vop.vcloud.product.EmailConfig config_;
			
			public com.vip.vop.vcloud.product.EmailConfig GetConfig(){
				return this.config_;
			}
			
			public void SetConfig(com.vip.vop.vcloud.product.EmailConfig value){
				this.config_ = value;
			}
			
		}
		
		
		
		
		public class updateProductSku_args {
			
			///<summary>
			/// skuId
			///</summary>
			
			private long? skuId_;
			
			///<summary>
			/// 商品信息键值对,key为商品在product_sku表的字段名称，值为要更新的值
			///</summary>
			
			private Dictionary<string, string> map_;
			
			public long? GetSkuId(){
				return this.skuId_;
			}
			
			public void SetSkuId(long? value){
				this.skuId_ = value;
			}
			public Dictionary<string, string> GetMap(){
				return this.map_;
			}
			
			public void SetMap(Dictionary<string, string> value){
				this.map_ = value;
			}
			
		}
		
		
		
		
		public class updateProductSkuAttr_args {
			
			///<summary>
			/// skuId
			///</summary>
			
			private long? skuId_;
			
			///<summary>
			/// 商品信息键值对,key为商品在product_sku_attribute表的attr_id的值，值为要更新的值
			///</summary>
			
			private Dictionary<string, string> map_;
			
			public long? GetSkuId(){
				return this.skuId_;
			}
			
			public void SetSkuId(long? value){
				this.skuId_ = value;
			}
			public Dictionary<string, string> GetMap(){
				return this.map_;
			}
			
			public void SetMap(Dictionary<string, string> value){
				this.map_ = value;
			}
			
		}
		
		
		
		
		public class updateProductSkuStatus_args {
			
			///<summary>
			/// 更新条件
			///</summary>
			
			private com.vip.vop.vcloud.product.ProductSkuStatus criteria_;
			
			///<summary>
			/// 更新值
			///</summary>
			
			private com.vip.vop.vcloud.product.ProductSkuStatus skuStatus_;
			
			public com.vip.vop.vcloud.product.ProductSkuStatus GetCriteria(){
				return this.criteria_;
			}
			
			public void SetCriteria(com.vip.vop.vcloud.product.ProductSkuStatus value){
				this.criteria_ = value;
			}
			public com.vip.vop.vcloud.product.ProductSkuStatus GetSkuStatus(){
				return this.skuStatus_;
			}
			
			public void SetSkuStatus(com.vip.vop.vcloud.product.ProductSkuStatus value){
				this.skuStatus_ = value;
			}
			
		}
		
		
		
		
		public class updateProductSpu_args {
			
			///<summary>
			/// spuId
			///</summary>
			
			private long? spuId_;
			
			///<summary>
			/// 商品信息键值对,key为商品在product_spu表的字段名称，值为要更新的值
			///</summary>
			
			private Dictionary<string, string> map_;
			
			public long? GetSpuId(){
				return this.spuId_;
			}
			
			public void SetSpuId(long? value){
				this.spuId_ = value;
			}
			public Dictionary<string, string> GetMap(){
				return this.map_;
			}
			
			public void SetMap(Dictionary<string, string> value){
				this.map_ = value;
			}
			
		}
		
		
		
		
		public class updateProductSpuAttr_args {
			
			///<summary>
			/// spuId
			///</summary>
			
			private long? spuId_;
			
			///<summary>
			/// 商品信息键值对,key为商品在product_spu_attribute表的attr_id的值，值为要更新的值
			///</summary>
			
			private Dictionary<string, string> map_;
			
			public long? GetSpuId(){
				return this.spuId_;
			}
			
			public void SetSpuId(long? value){
				this.spuId_ = value;
			}
			public Dictionary<string, string> GetMap(){
				return this.map_;
			}
			
			public void SetMap(Dictionary<string, string> value){
				this.map_ = value;
			}
			
		}
		
		
		
		
		public class updateSftpFileLog_args {
			
			///<summary>
			/// 日记id列表
			///</summary>
			
			private List<long?> logIdList_;
			
			///<summary>
			/// 日记类型
			///</summary>
			
			private byte? logType_;
			
			///<summary>
			/// 日记新状态
			///</summary>
			
			private byte? status_;
			
			public List<long?> GetLogIdList(){
				return this.logIdList_;
			}
			
			public void SetLogIdList(List<long?> value){
				this.logIdList_ = value;
			}
			public byte? GetLogType(){
				return this.logType_;
			}
			
			public void SetLogType(byte? value){
				this.logType_ = value;
			}
			public byte? GetStatus(){
				return this.status_;
			}
			
			public void SetStatus(byte? value){
				this.status_ = value;
			}
			
		}
		
		
		
		
		public class deleteEmailConfig_result {
			
			
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
		
		
		
		
		public class pushPriceToVdgByIdList_result {
			
			
		}
		
		
		
		
		public class pushProductToVdgBySkuIdList_result {
			
			
		}
		
		
		
		
		public class pushProductToVdgBySpuIdList_result {
			
			
		}
		
		
		
		
		public class saveEmailConfig_result {
			
			
		}
		
		
		
		
		public class updateProductSku_result {
			
			
		}
		
		
		
		
		public class updateProductSkuAttr_result {
			
			
		}
		
		
		
		
		public class updateProductSkuStatus_result {
			
			
		}
		
		
		
		
		public class updateProductSpu_result {
			
			
		}
		
		
		
		
		public class updateProductSpuAttr_result {
			
			
		}
		
		
		
		
		public class updateSftpFileLog_result {
			
			
		}
		
		
		
		
		
		public class deleteEmailConfig_argsHelper : TBeanSerializer<deleteEmailConfig_args>
		{
			
			public static deleteEmailConfig_argsHelper OBJ = new deleteEmailConfig_argsHelper();
			
			public static deleteEmailConfig_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteEmailConfig_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long value;
					value = iprot.ReadI64(); 
					
					structs.SetPartnerId(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetEmail(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteEmailConfig_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetPartnerId() != null) {
					
					oprot.WriteFieldBegin("partnerId");
					oprot.WriteI64((long)structs.GetPartnerId()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("partnerId can not be null!");
				}
				
				
				if(structs.GetEmail() != null) {
					
					oprot.WriteFieldBegin("email");
					oprot.WriteString(structs.GetEmail());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("email can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteEmailConfig_args bean){
				
				
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
		
		
		
		
		public class pushPriceToVdgByIdList_argsHelper : TBeanSerializer<pushPriceToVdgByIdList_args>
		{
			
			public static pushPriceToVdgByIdList_argsHelper OBJ = new pushPriceToVdgByIdList_argsHelper();
			
			public static pushPriceToVdgByIdList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushPriceToVdgByIdList_args structs, Protocol iprot){
				
				
				
				
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
					
					structs.SetIdList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushPriceToVdgByIdList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetIdList() != null) {
					
					oprot.WriteFieldBegin("idList");
					
					oprot.WriteListBegin();
					foreach(long _item0 in structs.GetIdList()){
						
						oprot.WriteI64((long)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("idList can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushPriceToVdgByIdList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushProductToVdgBySkuIdList_argsHelper : TBeanSerializer<pushProductToVdgBySkuIdList_args>
		{
			
			public static pushProductToVdgBySkuIdList_argsHelper OBJ = new pushProductToVdgBySkuIdList_argsHelper();
			
			public static pushProductToVdgBySkuIdList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushProductToVdgBySkuIdList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<long?> value;
					
					value = new List<long?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							long elem1;
							elem1 = iprot.ReadI64(); 
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSkuIdList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushProductToVdgBySkuIdList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSkuIdList() != null) {
					
					oprot.WriteFieldBegin("skuIdList");
					
					oprot.WriteListBegin();
					foreach(long _item0 in structs.GetSkuIdList()){
						
						oprot.WriteI64((long)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("skuIdList can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushProductToVdgBySkuIdList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushProductToVdgBySpuIdList_argsHelper : TBeanSerializer<pushProductToVdgBySpuIdList_args>
		{
			
			public static pushProductToVdgBySpuIdList_argsHelper OBJ = new pushProductToVdgBySpuIdList_argsHelper();
			
			public static pushProductToVdgBySpuIdList_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushProductToVdgBySpuIdList_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<long?> value;
					
					value = new List<long?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							long elem1;
							elem1 = iprot.ReadI64(); 
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetSpuIdList(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushProductToVdgBySpuIdList_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSpuIdList() != null) {
					
					oprot.WriteFieldBegin("spuIdList");
					
					oprot.WriteListBegin();
					foreach(long _item0 in structs.GetSpuIdList()){
						
						oprot.WriteI64((long)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("spuIdList can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushProductToVdgBySpuIdList_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class saveEmailConfig_argsHelper : TBeanSerializer<saveEmailConfig_args>
		{
			
			public static saveEmailConfig_argsHelper OBJ = new saveEmailConfig_argsHelper();
			
			public static saveEmailConfig_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(saveEmailConfig_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.product.EmailConfig value;
					
					value = new com.vip.vop.vcloud.product.EmailConfig();
					com.vip.vop.vcloud.product.EmailConfigHelper.getInstance().Read(value, iprot);
					
					structs.SetConfig(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(saveEmailConfig_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetConfig() != null) {
					
					oprot.WriteFieldBegin("config");
					
					com.vip.vop.vcloud.product.EmailConfigHelper.getInstance().Write(structs.GetConfig(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("config can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(saveEmailConfig_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateProductSku_argsHelper : TBeanSerializer<updateProductSku_args>
		{
			
			public static updateProductSku_argsHelper OBJ = new updateProductSku_argsHelper();
			
			public static updateProductSku_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateProductSku_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetSkuId(value);
				}
				
				
				
				
				
				if(true){
					
					Dictionary<string, string> value;
					
					value = new Dictionary<string, string>();
					iprot.ReadMapBegin();
					while(true){
						
						try{
							
							string _key0;
							string _val0;
							_key0 = iprot.ReadString();
							
							_val0 = iprot.ReadString();
							
							value.Add(_key0, _val0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadMapEnd();
					
					structs.SetMap(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateProductSku_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSkuId() != null) {
					
					oprot.WriteFieldBegin("skuId");
					oprot.WriteI64((long)structs.GetSkuId()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetMap() != null) {
					
					oprot.WriteFieldBegin("map");
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< string, string > _ir0 in structs.GetMap()){
						
						string _key0 = _ir0.Key;
						string _value0 = _ir0.Value;
						oprot.WriteString(_key0);
						
						oprot.WriteString(_value0);
						
					}
					
					oprot.WriteMapEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("map can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateProductSku_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateProductSkuAttr_argsHelper : TBeanSerializer<updateProductSkuAttr_args>
		{
			
			public static updateProductSkuAttr_argsHelper OBJ = new updateProductSkuAttr_argsHelper();
			
			public static updateProductSkuAttr_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateProductSkuAttr_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetSkuId(value);
				}
				
				
				
				
				
				if(true){
					
					Dictionary<string, string> value;
					
					value = new Dictionary<string, string>();
					iprot.ReadMapBegin();
					while(true){
						
						try{
							
							string _key1;
							string _val1;
							_key1 = iprot.ReadString();
							
							_val1 = iprot.ReadString();
							
							value.Add(_key1, _val1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadMapEnd();
					
					structs.SetMap(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateProductSkuAttr_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSkuId() != null) {
					
					oprot.WriteFieldBegin("skuId");
					oprot.WriteI64((long)structs.GetSkuId()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetMap() != null) {
					
					oprot.WriteFieldBegin("map");
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< string, string > _ir0 in structs.GetMap()){
						
						string _key0 = _ir0.Key;
						string _value0 = _ir0.Value;
						oprot.WriteString(_key0);
						
						oprot.WriteString(_value0);
						
					}
					
					oprot.WriteMapEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("map can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateProductSkuAttr_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateProductSkuStatus_argsHelper : TBeanSerializer<updateProductSkuStatus_args>
		{
			
			public static updateProductSkuStatus_argsHelper OBJ = new updateProductSkuStatus_argsHelper();
			
			public static updateProductSkuStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateProductSkuStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.product.ProductSkuStatus value;
					
					value = new com.vip.vop.vcloud.product.ProductSkuStatus();
					com.vip.vop.vcloud.product.ProductSkuStatusHelper.getInstance().Read(value, iprot);
					
					structs.SetCriteria(value);
				}
				
				
				
				
				
				if(true){
					
					com.vip.vop.vcloud.product.ProductSkuStatus value;
					
					value = new com.vip.vop.vcloud.product.ProductSkuStatus();
					com.vip.vop.vcloud.product.ProductSkuStatusHelper.getInstance().Read(value, iprot);
					
					structs.SetSkuStatus(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateProductSkuStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetCriteria() != null) {
					
					oprot.WriteFieldBegin("criteria");
					
					com.vip.vop.vcloud.product.ProductSkuStatusHelper.getInstance().Write(structs.GetCriteria(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("criteria can not be null!");
				}
				
				
				if(structs.GetSkuStatus() != null) {
					
					oprot.WriteFieldBegin("skuStatus");
					
					com.vip.vop.vcloud.product.ProductSkuStatusHelper.getInstance().Write(structs.GetSkuStatus(), oprot);
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("skuStatus can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateProductSkuStatus_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateProductSpu_argsHelper : TBeanSerializer<updateProductSpu_args>
		{
			
			public static updateProductSpu_argsHelper OBJ = new updateProductSpu_argsHelper();
			
			public static updateProductSpu_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateProductSpu_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetSpuId(value);
				}
				
				
				
				
				
				if(true){
					
					Dictionary<string, string> value;
					
					value = new Dictionary<string, string>();
					iprot.ReadMapBegin();
					while(true){
						
						try{
							
							string _key0;
							string _val0;
							_key0 = iprot.ReadString();
							
							_val0 = iprot.ReadString();
							
							value.Add(_key0, _val0);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadMapEnd();
					
					structs.SetMap(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateProductSpu_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSpuId() != null) {
					
					oprot.WriteFieldBegin("spuId");
					oprot.WriteI64((long)structs.GetSpuId()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetMap() != null) {
					
					oprot.WriteFieldBegin("map");
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< string, string > _ir0 in structs.GetMap()){
						
						string _key0 = _ir0.Key;
						string _value0 = _ir0.Value;
						oprot.WriteString(_key0);
						
						oprot.WriteString(_value0);
						
					}
					
					oprot.WriteMapEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("map can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateProductSpu_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateProductSpuAttr_argsHelper : TBeanSerializer<updateProductSpuAttr_args>
		{
			
			public static updateProductSpuAttr_argsHelper OBJ = new updateProductSpuAttr_argsHelper();
			
			public static updateProductSpuAttr_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateProductSpuAttr_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					long? value;
					value = iprot.ReadI64(); 
					
					structs.SetSpuId(value);
				}
				
				
				
				
				
				if(true){
					
					Dictionary<string, string> value;
					
					value = new Dictionary<string, string>();
					iprot.ReadMapBegin();
					while(true){
						
						try{
							
							string _key1;
							string _val1;
							_key1 = iprot.ReadString();
							
							_val1 = iprot.ReadString();
							
							value.Add(_key1, _val1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadMapEnd();
					
					structs.SetMap(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateProductSpuAttr_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSpuId() != null) {
					
					oprot.WriteFieldBegin("spuId");
					oprot.WriteI64((long)structs.GetSpuId()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetMap() != null) {
					
					oprot.WriteFieldBegin("map");
					
					oprot.WriteMapBegin();
					foreach(KeyValuePair< string, string > _ir0 in structs.GetMap()){
						
						string _key0 = _ir0.Key;
						string _value0 = _ir0.Value;
						oprot.WriteString(_key0);
						
						oprot.WriteString(_value0);
						
					}
					
					oprot.WriteMapEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("map can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateProductSpuAttr_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSftpFileLog_argsHelper : TBeanSerializer<updateSftpFileLog_args>
		{
			
			public static updateSftpFileLog_argsHelper OBJ = new updateSftpFileLog_argsHelper();
			
			public static updateSftpFileLog_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSftpFileLog_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<long?> value;
					
					value = new List<long?>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							long elem1;
							elem1 = iprot.ReadI64(); 
							
							value.Add(elem1);
						}
						catch(Exception e){
							
							
							break;
						}
					}
					
					iprot.ReadListEnd();
					
					structs.SetLogIdList(value);
				}
				
				
				
				
				
				if(true){
					
					byte? value;
					value = iprot.ReadByte(); 
					
					structs.SetLogType(value);
				}
				
				
				
				
				
				if(true){
					
					byte? value;
					value = iprot.ReadByte(); 
					
					structs.SetStatus(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSftpFileLog_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetLogIdList() != null) {
					
					oprot.WriteFieldBegin("logIdList");
					
					oprot.WriteListBegin();
					foreach(long _item0 in structs.GetLogIdList()){
						
						oprot.WriteI64((long)_item0); 
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetLogType() != null) {
					
					oprot.WriteFieldBegin("logType");
					oprot.WriteByte((byte)structs.GetLogType()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetStatus() != null) {
					
					oprot.WriteFieldBegin("status");
					oprot.WriteByte((byte)structs.GetStatus()); 
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSftpFileLog_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class deleteEmailConfig_resultHelper : TBeanSerializer<deleteEmailConfig_result>
		{
			
			public static deleteEmailConfig_resultHelper OBJ = new deleteEmailConfig_resultHelper();
			
			public static deleteEmailConfig_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(deleteEmailConfig_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(deleteEmailConfig_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(deleteEmailConfig_result bean){
				
				
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
		
		
		
		
		public class pushPriceToVdgByIdList_resultHelper : TBeanSerializer<pushPriceToVdgByIdList_result>
		{
			
			public static pushPriceToVdgByIdList_resultHelper OBJ = new pushPriceToVdgByIdList_resultHelper();
			
			public static pushPriceToVdgByIdList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushPriceToVdgByIdList_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushPriceToVdgByIdList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushPriceToVdgByIdList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushProductToVdgBySkuIdList_resultHelper : TBeanSerializer<pushProductToVdgBySkuIdList_result>
		{
			
			public static pushProductToVdgBySkuIdList_resultHelper OBJ = new pushProductToVdgBySkuIdList_resultHelper();
			
			public static pushProductToVdgBySkuIdList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushProductToVdgBySkuIdList_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushProductToVdgBySkuIdList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushProductToVdgBySkuIdList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class pushProductToVdgBySpuIdList_resultHelper : TBeanSerializer<pushProductToVdgBySpuIdList_result>
		{
			
			public static pushProductToVdgBySpuIdList_resultHelper OBJ = new pushProductToVdgBySpuIdList_resultHelper();
			
			public static pushProductToVdgBySpuIdList_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(pushProductToVdgBySpuIdList_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(pushProductToVdgBySpuIdList_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(pushProductToVdgBySpuIdList_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class saveEmailConfig_resultHelper : TBeanSerializer<saveEmailConfig_result>
		{
			
			public static saveEmailConfig_resultHelper OBJ = new saveEmailConfig_resultHelper();
			
			public static saveEmailConfig_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(saveEmailConfig_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(saveEmailConfig_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(saveEmailConfig_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateProductSku_resultHelper : TBeanSerializer<updateProductSku_result>
		{
			
			public static updateProductSku_resultHelper OBJ = new updateProductSku_resultHelper();
			
			public static updateProductSku_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateProductSku_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateProductSku_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateProductSku_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateProductSkuAttr_resultHelper : TBeanSerializer<updateProductSkuAttr_result>
		{
			
			public static updateProductSkuAttr_resultHelper OBJ = new updateProductSkuAttr_resultHelper();
			
			public static updateProductSkuAttr_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateProductSkuAttr_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateProductSkuAttr_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateProductSkuAttr_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateProductSkuStatus_resultHelper : TBeanSerializer<updateProductSkuStatus_result>
		{
			
			public static updateProductSkuStatus_resultHelper OBJ = new updateProductSkuStatus_resultHelper();
			
			public static updateProductSkuStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateProductSkuStatus_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateProductSkuStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateProductSkuStatus_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateProductSpu_resultHelper : TBeanSerializer<updateProductSpu_result>
		{
			
			public static updateProductSpu_resultHelper OBJ = new updateProductSpu_resultHelper();
			
			public static updateProductSpu_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateProductSpu_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateProductSpu_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateProductSpu_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateProductSpuAttr_resultHelper : TBeanSerializer<updateProductSpuAttr_result>
		{
			
			public static updateProductSpuAttr_resultHelper OBJ = new updateProductSpuAttr_resultHelper();
			
			public static updateProductSpuAttr_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateProductSpuAttr_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateProductSpuAttr_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateProductSpuAttr_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class updateSftpFileLog_resultHelper : TBeanSerializer<updateSftpFileLog_result>
		{
			
			public static updateSftpFileLog_resultHelper OBJ = new updateSftpFileLog_resultHelper();
			
			public static updateSftpFileLog_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(updateSftpFileLog_result structs, Protocol iprot){
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(updateSftpFileLog_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(updateSftpFileLog_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class DieselProductSelfServiceClient : OspRestStub , DieselProductSelfService  {
			
			
			public DieselProductSelfServiceClient():base("com.vip.vop.vcloud.product.DieselProductSelfService","1.0.0") {
				
				
			}
			
			
			
			public void deleteEmailConfig(long partnerId_,string email_) {
				
				send_deleteEmailConfig(partnerId_,email_);
				recv_deleteEmailConfig();
				
			}
			
			
			private void send_deleteEmailConfig(long partnerId_,string email_){
				
				InitInvocation("deleteEmailConfig");
				
				deleteEmailConfig_args args = new deleteEmailConfig_args();
				args.SetPartnerId(partnerId_);
				args.SetEmail(email_);
				
				SendBase(args, deleteEmailConfig_argsHelper.getInstance());
			}
			
			
			private void recv_deleteEmailConfig(){
				
				deleteEmailConfig_result result = new deleteEmailConfig_result();
				ReceiveBase(result, deleteEmailConfig_resultHelper.getInstance());
				
				
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
			
			
			public void pushPriceToVdgByIdList(List<long?> idList_) {
				
				send_pushPriceToVdgByIdList(idList_);
				recv_pushPriceToVdgByIdList();
				
			}
			
			
			private void send_pushPriceToVdgByIdList(List<long?> idList_){
				
				InitInvocation("pushPriceToVdgByIdList");
				
				pushPriceToVdgByIdList_args args = new pushPriceToVdgByIdList_args();
				args.SetIdList(idList_);
				
				SendBase(args, pushPriceToVdgByIdList_argsHelper.getInstance());
			}
			
			
			private void recv_pushPriceToVdgByIdList(){
				
				pushPriceToVdgByIdList_result result = new pushPriceToVdgByIdList_result();
				ReceiveBase(result, pushPriceToVdgByIdList_resultHelper.getInstance());
				
				
			}
			
			
			public void pushProductToVdgBySkuIdList(List<long?> skuIdList_) {
				
				send_pushProductToVdgBySkuIdList(skuIdList_);
				recv_pushProductToVdgBySkuIdList();
				
			}
			
			
			private void send_pushProductToVdgBySkuIdList(List<long?> skuIdList_){
				
				InitInvocation("pushProductToVdgBySkuIdList");
				
				pushProductToVdgBySkuIdList_args args = new pushProductToVdgBySkuIdList_args();
				args.SetSkuIdList(skuIdList_);
				
				SendBase(args, pushProductToVdgBySkuIdList_argsHelper.getInstance());
			}
			
			
			private void recv_pushProductToVdgBySkuIdList(){
				
				pushProductToVdgBySkuIdList_result result = new pushProductToVdgBySkuIdList_result();
				ReceiveBase(result, pushProductToVdgBySkuIdList_resultHelper.getInstance());
				
				
			}
			
			
			public void pushProductToVdgBySpuIdList(List<long?> spuIdList_) {
				
				send_pushProductToVdgBySpuIdList(spuIdList_);
				recv_pushProductToVdgBySpuIdList();
				
			}
			
			
			private void send_pushProductToVdgBySpuIdList(List<long?> spuIdList_){
				
				InitInvocation("pushProductToVdgBySpuIdList");
				
				pushProductToVdgBySpuIdList_args args = new pushProductToVdgBySpuIdList_args();
				args.SetSpuIdList(spuIdList_);
				
				SendBase(args, pushProductToVdgBySpuIdList_argsHelper.getInstance());
			}
			
			
			private void recv_pushProductToVdgBySpuIdList(){
				
				pushProductToVdgBySpuIdList_result result = new pushProductToVdgBySpuIdList_result();
				ReceiveBase(result, pushProductToVdgBySpuIdList_resultHelper.getInstance());
				
				
			}
			
			
			public void saveEmailConfig(com.vip.vop.vcloud.product.EmailConfig config_) {
				
				send_saveEmailConfig(config_);
				recv_saveEmailConfig();
				
			}
			
			
			private void send_saveEmailConfig(com.vip.vop.vcloud.product.EmailConfig config_){
				
				InitInvocation("saveEmailConfig");
				
				saveEmailConfig_args args = new saveEmailConfig_args();
				args.SetConfig(config_);
				
				SendBase(args, saveEmailConfig_argsHelper.getInstance());
			}
			
			
			private void recv_saveEmailConfig(){
				
				saveEmailConfig_result result = new saveEmailConfig_result();
				ReceiveBase(result, saveEmailConfig_resultHelper.getInstance());
				
				
			}
			
			
			public void updateProductSku(long? skuId_,Dictionary<string, string> map_) {
				
				send_updateProductSku(skuId_,map_);
				recv_updateProductSku();
				
			}
			
			
			private void send_updateProductSku(long? skuId_,Dictionary<string, string> map_){
				
				InitInvocation("updateProductSku");
				
				updateProductSku_args args = new updateProductSku_args();
				args.SetSkuId(skuId_);
				args.SetMap(map_);
				
				SendBase(args, updateProductSku_argsHelper.getInstance());
			}
			
			
			private void recv_updateProductSku(){
				
				updateProductSku_result result = new updateProductSku_result();
				ReceiveBase(result, updateProductSku_resultHelper.getInstance());
				
				
			}
			
			
			public void updateProductSkuAttr(long? skuId_,Dictionary<string, string> map_) {
				
				send_updateProductSkuAttr(skuId_,map_);
				recv_updateProductSkuAttr();
				
			}
			
			
			private void send_updateProductSkuAttr(long? skuId_,Dictionary<string, string> map_){
				
				InitInvocation("updateProductSkuAttr");
				
				updateProductSkuAttr_args args = new updateProductSkuAttr_args();
				args.SetSkuId(skuId_);
				args.SetMap(map_);
				
				SendBase(args, updateProductSkuAttr_argsHelper.getInstance());
			}
			
			
			private void recv_updateProductSkuAttr(){
				
				updateProductSkuAttr_result result = new updateProductSkuAttr_result();
				ReceiveBase(result, updateProductSkuAttr_resultHelper.getInstance());
				
				
			}
			
			
			public void updateProductSkuStatus(com.vip.vop.vcloud.product.ProductSkuStatus criteria_,com.vip.vop.vcloud.product.ProductSkuStatus skuStatus_) {
				
				send_updateProductSkuStatus(criteria_,skuStatus_);
				recv_updateProductSkuStatus();
				
			}
			
			
			private void send_updateProductSkuStatus(com.vip.vop.vcloud.product.ProductSkuStatus criteria_,com.vip.vop.vcloud.product.ProductSkuStatus skuStatus_){
				
				InitInvocation("updateProductSkuStatus");
				
				updateProductSkuStatus_args args = new updateProductSkuStatus_args();
				args.SetCriteria(criteria_);
				args.SetSkuStatus(skuStatus_);
				
				SendBase(args, updateProductSkuStatus_argsHelper.getInstance());
			}
			
			
			private void recv_updateProductSkuStatus(){
				
				updateProductSkuStatus_result result = new updateProductSkuStatus_result();
				ReceiveBase(result, updateProductSkuStatus_resultHelper.getInstance());
				
				
			}
			
			
			public void updateProductSpu(long? spuId_,Dictionary<string, string> map_) {
				
				send_updateProductSpu(spuId_,map_);
				recv_updateProductSpu();
				
			}
			
			
			private void send_updateProductSpu(long? spuId_,Dictionary<string, string> map_){
				
				InitInvocation("updateProductSpu");
				
				updateProductSpu_args args = new updateProductSpu_args();
				args.SetSpuId(spuId_);
				args.SetMap(map_);
				
				SendBase(args, updateProductSpu_argsHelper.getInstance());
			}
			
			
			private void recv_updateProductSpu(){
				
				updateProductSpu_result result = new updateProductSpu_result();
				ReceiveBase(result, updateProductSpu_resultHelper.getInstance());
				
				
			}
			
			
			public void updateProductSpuAttr(long? spuId_,Dictionary<string, string> map_) {
				
				send_updateProductSpuAttr(spuId_,map_);
				recv_updateProductSpuAttr();
				
			}
			
			
			private void send_updateProductSpuAttr(long? spuId_,Dictionary<string, string> map_){
				
				InitInvocation("updateProductSpuAttr");
				
				updateProductSpuAttr_args args = new updateProductSpuAttr_args();
				args.SetSpuId(spuId_);
				args.SetMap(map_);
				
				SendBase(args, updateProductSpuAttr_argsHelper.getInstance());
			}
			
			
			private void recv_updateProductSpuAttr(){
				
				updateProductSpuAttr_result result = new updateProductSpuAttr_result();
				ReceiveBase(result, updateProductSpuAttr_resultHelper.getInstance());
				
				
			}
			
			
			public void updateSftpFileLog(List<long?> logIdList_,byte? logType_,byte? status_) {
				
				send_updateSftpFileLog(logIdList_,logType_,status_);
				recv_updateSftpFileLog();
				
			}
			
			
			private void send_updateSftpFileLog(List<long?> logIdList_,byte? logType_,byte? status_){
				
				InitInvocation("updateSftpFileLog");
				
				updateSftpFileLog_args args = new updateSftpFileLog_args();
				args.SetLogIdList(logIdList_);
				args.SetLogType(logType_);
				args.SetStatus(status_);
				
				SendBase(args, updateSftpFileLog_argsHelper.getInstance());
			}
			
			
			private void recv_updateSftpFileLog(){
				
				updateSftpFileLog_result result = new updateSftpFileLog_result();
				ReceiveBase(result, updateSftpFileLog_resultHelper.getInstance());
				
				
			}
			
			
		}
		
		
	}
	
}