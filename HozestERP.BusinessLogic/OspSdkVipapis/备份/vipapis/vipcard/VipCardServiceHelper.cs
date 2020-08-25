using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;

namespace vipapis.vipcard{
	
	
	public class VipCardServiceHelper {
		
		
		
		public class cancelSoldCard_args {
			
			///<summary>
			/// 店铺名称
			///</summary>
			
			private string shop_name_;
			
			///<summary>
			/// 店铺地址
			///</summary>
			
			private string shop_area_;
			
			///<summary>
			/// 请求client_id
			///</summary>
			
			private int? client_id_;
			
			///<summary>
			/// 商家卡类型编号
			///</summary>
			
			private int? type_;
			
			///<summary>
			/// 唯品卡卡号
			///</summary>
			
			private string card_code_;
			
			///<summary>
			/// 自增流水号，如果小于等于系统记录的最后处理流水号忽略处理
			///</summary>
			
			private int? trans_id_;
			
			///<summary>
			/// 售出唯品卡使用的流水号，该售出流水号一旦冲正成功即无法再次使用
			///</summary>
			
			private int? sale_trans_id_;
			
			public string GetShop_name(){
				return this.shop_name_;
			}
			
			public void SetShop_name(string value){
				this.shop_name_ = value;
			}
			public string GetShop_area(){
				return this.shop_area_;
			}
			
			public void SetShop_area(string value){
				this.shop_area_ = value;
			}
			public int? GetClient_id(){
				return this.client_id_;
			}
			
			public void SetClient_id(int? value){
				this.client_id_ = value;
			}
			public int? GetType(){
				return this.type_;
			}
			
			public void SetType(int? value){
				this.type_ = value;
			}
			public string GetCard_code(){
				return this.card_code_;
			}
			
			public void SetCard_code(string value){
				this.card_code_ = value;
			}
			public int? GetTrans_id(){
				return this.trans_id_;
			}
			
			public void SetTrans_id(int? value){
				this.trans_id_ = value;
			}
			public int? GetSale_trans_id(){
				return this.sale_trans_id_;
			}
			
			public void SetSale_trans_id(int? value){
				this.sale_trans_id_ = value;
			}
			
		}
		
		
		
		
		public class getCardStatus_args {
			
			///<summary>
			/// 店铺名称
			///</summary>
			
			private string shop_name_;
			
			///<summary>
			/// 店铺地址
			///</summary>
			
			private string shop_area_;
			
			///<summary>
			/// 请求clientId
			///</summary>
			
			private int? client_id_;
			
			///<summary>
			/// 商家卡类型编号
			///</summary>
			
			private int? type_;
			
			///<summary>
			/// 唯品卡号，支持批量
			///</summary>
			
			private List<string> card_code_;
			
			public string GetShop_name(){
				return this.shop_name_;
			}
			
			public void SetShop_name(string value){
				this.shop_name_ = value;
			}
			public string GetShop_area(){
				return this.shop_area_;
			}
			
			public void SetShop_area(string value){
				this.shop_area_ = value;
			}
			public int? GetClient_id(){
				return this.client_id_;
			}
			
			public void SetClient_id(int? value){
				this.client_id_ = value;
			}
			public int? GetType(){
				return this.type_;
			}
			
			public void SetType(int? value){
				this.type_ = value;
			}
			public List<string> GetCard_code(){
				return this.card_code_;
			}
			
			public void SetCard_code(List<string> value){
				this.card_code_ = value;
			}
			
		}
		
		
		
		
		public class healthCheck_args {
			
			
		}
		
		
		
		
		public class sellCard_args {
			
			///<summary>
			/// 店铺名称
			///</summary>
			
			private string shop_name_;
			
			///<summary>
			/// 店铺地址
			///</summary>
			
			private string shop_area_;
			
			///<summary>
			/// 请求client_id
			///</summary>
			
			private int? client_id_;
			
			///<summary>
			/// 商家卡类型编号
			///</summary>
			
			private int? type_;
			
			///<summary>
			/// 唯品卡卡号
			///</summary>
			
			private string card_code_;
			
			///<summary>
			/// 自增流水号，如果小于等于系统记录的最后处理流水号忽略处理
			///</summary>
			
			private int? trans_id_;
			
			public string GetShop_name(){
				return this.shop_name_;
			}
			
			public void SetShop_name(string value){
				this.shop_name_ = value;
			}
			public string GetShop_area(){
				return this.shop_area_;
			}
			
			public void SetShop_area(string value){
				this.shop_area_ = value;
			}
			public int? GetClient_id(){
				return this.client_id_;
			}
			
			public void SetClient_id(int? value){
				this.client_id_ = value;
			}
			public int? GetType(){
				return this.type_;
			}
			
			public void SetType(int? value){
				this.type_ = value;
			}
			public string GetCard_code(){
				return this.card_code_;
			}
			
			public void SetCard_code(string value){
				this.card_code_ = value;
			}
			public int? GetTrans_id(){
				return this.trans_id_;
			}
			
			public void SetTrans_id(int? value){
				this.trans_id_ = value;
			}
			
		}
		
		
		
		
		public class cancelSoldCard_result {
			
			///<summary>
			/// 是否取消售出成功，true为成功，false为失败
			///</summary>
			
			private bool? success_;
			
			public bool? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(bool? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		public class getCardStatus_result {
			
			///<summary>
			///</summary>
			
			private List<vipapis.vipcard.VipCard> success_;
			
			public List<vipapis.vipcard.VipCard> GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(List<vipapis.vipcard.VipCard> value){
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
		
		
		
		
		public class sellCard_result {
			
			///<summary>
			/// 是否售出成功，true为成功，false为失败
			///</summary>
			
			private bool? success_;
			
			public bool? GetSuccess(){
				return this.success_;
			}
			
			public void SetSuccess(bool? value){
				this.success_ = value;
			}
			
		}
		
		
		
		
		
		public class cancelSoldCard_argsHelper : BeanSerializer<cancelSoldCard_args>
		{
			
			public static cancelSoldCard_argsHelper OBJ = new cancelSoldCard_argsHelper();
			
			public static cancelSoldCard_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelSoldCard_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetShop_name(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetShop_area(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetClient_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetType(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCard_code(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetTrans_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetSale_trans_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cancelSoldCard_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetShop_name() != null) {
					
					oprot.WriteFieldBegin("shop_name");
					oprot.WriteString(structs.GetShop_name());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("shop_name can not be null!");
				}
				
				
				if(structs.GetShop_area() != null) {
					
					oprot.WriteFieldBegin("shop_area");
					oprot.WriteString(structs.GetShop_area());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("shop_area can not be null!");
				}
				
				
				if(structs.GetClient_id() != null) {
					
					oprot.WriteFieldBegin("client_id");
					oprot.WriteI32((int)structs.GetClient_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("client_id can not be null!");
				}
				
				
				if(structs.GetType() != null) {
					
					oprot.WriteFieldBegin("type");
					oprot.WriteI32((int)structs.GetType()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("type can not be null!");
				}
				
				
				if(structs.GetCard_code() != null) {
					
					oprot.WriteFieldBegin("card_code");
					oprot.WriteString(structs.GetCard_code());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("card_code can not be null!");
				}
				
				
				if(structs.GetTrans_id() != null) {
					
					oprot.WriteFieldBegin("trans_id");
					oprot.WriteI32((int)structs.GetTrans_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("trans_id can not be null!");
				}
				
				
				if(structs.GetSale_trans_id() != null) {
					
					oprot.WriteFieldBegin("sale_trans_id");
					oprot.WriteI32((int)structs.GetSale_trans_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("sale_trans_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cancelSoldCard_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCardStatus_argsHelper : BeanSerializer<getCardStatus_args>
		{
			
			public static getCardStatus_argsHelper OBJ = new getCardStatus_argsHelper();
			
			public static getCardStatus_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCardStatus_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetShop_name(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetShop_area(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetClient_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetType(value);
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
					
					structs.SetCard_code(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(getCardStatus_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetShop_name() != null) {
					
					oprot.WriteFieldBegin("shop_name");
					oprot.WriteString(structs.GetShop_name());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetShop_area() != null) {
					
					oprot.WriteFieldBegin("shop_area");
					oprot.WriteString(structs.GetShop_area());
					
					oprot.WriteFieldEnd();
				}
				
				
				if(structs.GetClient_id() != null) {
					
					oprot.WriteFieldBegin("client_id");
					oprot.WriteI32((int)structs.GetClient_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("client_id can not be null!");
				}
				
				
				if(structs.GetType() != null) {
					
					oprot.WriteFieldBegin("type");
					oprot.WriteI32((int)structs.GetType()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("type can not be null!");
				}
				
				
				if(structs.GetCard_code() != null) {
					
					oprot.WriteFieldBegin("card_code");
					
					oprot.WriteListBegin();
					foreach(string _item0 in structs.GetCard_code()){
						
						oprot.WriteString(_item0);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("card_code can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCardStatus_args bean){
				
				
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
		
		
		
		
		public class sellCard_argsHelper : BeanSerializer<sellCard_args>
		{
			
			public static sellCard_argsHelper OBJ = new sellCard_argsHelper();
			
			public static sellCard_argsHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(sellCard_args structs, Protocol iprot){
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetShop_name(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetShop_area(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetClient_id(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetType(value);
				}
				
				
				
				
				
				if(true){
					
					string value;
					value = iprot.ReadString();
					
					structs.SetCard_code(value);
				}
				
				
				
				
				
				if(true){
					
					int value;
					value = iprot.ReadI32(); 
					
					structs.SetTrans_id(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(sellCard_args structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetShop_name() != null) {
					
					oprot.WriteFieldBegin("shop_name");
					oprot.WriteString(structs.GetShop_name());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("shop_name can not be null!");
				}
				
				
				if(structs.GetShop_area() != null) {
					
					oprot.WriteFieldBegin("shop_area");
					oprot.WriteString(structs.GetShop_area());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("shop_area can not be null!");
				}
				
				
				if(structs.GetClient_id() != null) {
					
					oprot.WriteFieldBegin("client_id");
					oprot.WriteI32((int)structs.GetClient_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("client_id can not be null!");
				}
				
				
				if(structs.GetType() != null) {
					
					oprot.WriteFieldBegin("type");
					oprot.WriteI32((int)structs.GetType()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("type can not be null!");
				}
				
				
				if(structs.GetCard_code() != null) {
					
					oprot.WriteFieldBegin("card_code");
					oprot.WriteString(structs.GetCard_code());
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("card_code can not be null!");
				}
				
				
				if(structs.GetTrans_id() != null) {
					
					oprot.WriteFieldBegin("trans_id");
					oprot.WriteI32((int)structs.GetTrans_id()); 
					
					oprot.WriteFieldEnd();
				}
				
				else{
					throw new ArgumentException("trans_id can not be null!");
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(sellCard_args bean){
				
				
			}
			
			
		}
		
		
		
		
		public class cancelSoldCard_resultHelper : BeanSerializer<cancelSoldCard_result>
		{
			
			public static cancelSoldCard_resultHelper OBJ = new cancelSoldCard_resultHelper();
			
			public static cancelSoldCard_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(cancelSoldCard_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool? value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(cancelSoldCard_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteBool((bool)structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(cancelSoldCard_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class getCardStatus_resultHelper : BeanSerializer<getCardStatus_result>
		{
			
			public static getCardStatus_resultHelper OBJ = new getCardStatus_resultHelper();
			
			public static getCardStatus_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(getCardStatus_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					List<vipapis.vipcard.VipCard> value;
					
					value = new List<vipapis.vipcard.VipCard>();
					iprot.ReadListBegin();
					while(true){
						
						try{
							
							vipapis.vipcard.VipCard elem0;
							
							elem0 = new vipapis.vipcard.VipCard();
							vipapis.vipcard.VipCardHelper.getInstance().Read(elem0, iprot);
							
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
			
			
			public void Write(getCardStatus_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					
					oprot.WriteListBegin();
					foreach(vipapis.vipcard.VipCard _item0 in structs.GetSuccess()){
						
						
						vipapis.vipcard.VipCardHelper.getInstance().Write(_item0, oprot);
						
					}
					
					oprot.WriteListEnd();
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(getCardStatus_result bean){
				
				
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
		
		
		
		
		public class sellCard_resultHelper : BeanSerializer<sellCard_result>
		{
			
			public static sellCard_resultHelper OBJ = new sellCard_resultHelper();
			
			public static sellCard_resultHelper getInstance() {
				
				return OBJ;
			}
			
			
			public void Read(sellCard_result structs, Protocol iprot){
				
				
				
				
				if(true){
					
					bool? value;
					value = iprot.ReadBool();
					
					structs.SetSuccess(value);
				}
				
				
				
				
				Validate(structs);
				
			}
			
			
			public void Write(sellCard_result structs, Protocol oprot){
				
				Validate(structs);
				oprot.WriteStructBegin();
				
				if(structs.GetSuccess() != null) {
					
					oprot.WriteFieldBegin("success");
					oprot.WriteBool((bool)structs.GetSuccess());
					
					oprot.WriteFieldEnd();
				}
				
				
				oprot.WriteFieldStop();
				oprot.WriteStructEnd();
			}
			
			
			public void Validate(sellCard_result bean){
				
				
			}
			
			
		}
		
		
		
		
		public class VipCardServiceClient : OspRestStub , VipCardService  {
			
			
			public VipCardServiceClient():base("vipapis.vipcard.VipCardService","1.0.0") {
				
				
			}
			
			
			
			public bool? cancelSoldCard(string shop_name_,string shop_area_,int client_id_,int type_,string card_code_,int trans_id_,int sale_trans_id_) {
				
				send_cancelSoldCard(shop_name_,shop_area_,client_id_,type_,card_code_,trans_id_,sale_trans_id_);
				return recv_cancelSoldCard(); 
				
			}
			
			
			private void send_cancelSoldCard(string shop_name_,string shop_area_,int client_id_,int type_,string card_code_,int trans_id_,int sale_trans_id_){
				
				InitInvocation("cancelSoldCard");
				
				cancelSoldCard_args args = new cancelSoldCard_args();
				args.SetShop_name(shop_name_);
				args.SetShop_area(shop_area_);
				args.SetClient_id(client_id_);
				args.SetType(type_);
				args.SetCard_code(card_code_);
				args.SetTrans_id(trans_id_);
				args.SetSale_trans_id(sale_trans_id_);
				
				SendBase(args, cancelSoldCard_argsHelper.getInstance());
			}
			
			
			private bool? recv_cancelSoldCard(){
				
				cancelSoldCard_result result = new cancelSoldCard_result();
				ReceiveBase(result, cancelSoldCard_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
			public List<vipapis.vipcard.VipCard> getCardStatus(string shop_name_,string shop_area_,int client_id_,int type_,List<string> card_code_) {
				
				send_getCardStatus(shop_name_,shop_area_,client_id_,type_,card_code_);
				return recv_getCardStatus(); 
				
			}
			
			
			private void send_getCardStatus(string shop_name_,string shop_area_,int client_id_,int type_,List<string> card_code_){
				
				InitInvocation("getCardStatus");
				
				getCardStatus_args args = new getCardStatus_args();
				args.SetShop_name(shop_name_);
				args.SetShop_area(shop_area_);
				args.SetClient_id(client_id_);
				args.SetType(type_);
				args.SetCard_code(card_code_);
				
				SendBase(args, getCardStatus_argsHelper.getInstance());
			}
			
			
			private List<vipapis.vipcard.VipCard> recv_getCardStatus(){
				
				getCardStatus_result result = new getCardStatus_result();
				ReceiveBase(result, getCardStatus_resultHelper.getInstance());
				
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
			
			
			public bool? sellCard(string shop_name_,string shop_area_,int client_id_,int type_,string card_code_,int trans_id_) {
				
				send_sellCard(shop_name_,shop_area_,client_id_,type_,card_code_,trans_id_);
				return recv_sellCard(); 
				
			}
			
			
			private void send_sellCard(string shop_name_,string shop_area_,int client_id_,int type_,string card_code_,int trans_id_){
				
				InitInvocation("sellCard");
				
				sellCard_args args = new sellCard_args();
				args.SetShop_name(shop_name_);
				args.SetShop_area(shop_area_);
				args.SetClient_id(client_id_);
				args.SetType(type_);
				args.SetCard_code(card_code_);
				args.SetTrans_id(trans_id_);
				
				SendBase(args, sellCard_argsHelper.getInstance());
			}
			
			
			private bool? recv_sellCard(){
				
				sellCard_result result = new sellCard_result();
				ReceiveBase(result, sellCard_resultHelper.getInstance());
				
				return result.GetSuccess();
				
			}
			
			
		}
		
		
	}
	
}