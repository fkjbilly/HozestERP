using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class ReturnHelper : TBeanSerializer<Return>
	{
		
		public static ReturnHelper OBJ = new ReturnHelper();
		
		public static ReturnHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Return structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_return_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_return_id(value);
					}
					
					
					
					
					
					if ("return_goods_details".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.ReturnGoodsDetail> value;
						
						value = new List<vipapis.delivery.ReturnGoodsDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.ReturnGoodsDetail elem0;
								
								elem0 = new vipapis.delivery.ReturnGoodsDetail();
								vipapis.delivery.ReturnGoodsDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetReturn_goods_details(value);
					}
					
					
					
					
					
					if ("refund_amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRefund_amount(value);
					}
					
					
					
					
					if(needSkip){
						
						ProtocolUtil.skip(iprot);
					}
					
					iprot.ReadFieldEnd();
				}
				
				iprot.ReadStructEnd();
				Validate(structs);
			}
			else{
				
				throw new OspException();
			}
			
			
		}
		
		
		public void Write(Return structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_return_id() != null) {
				
				oprot.WriteFieldBegin("order_return_id");
				oprot.WriteString(structs.GetOrder_return_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturn_goods_details() != null) {
				
				oprot.WriteFieldBegin("return_goods_details");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.ReturnGoodsDetail _item0 in structs.GetReturn_goods_details()){
					
					
					vipapis.delivery.ReturnGoodsDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRefund_amount() != null) {
				
				oprot.WriteFieldBegin("refund_amount");
				oprot.WriteString(structs.GetRefund_amount());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Return bean){
			
			
		}
		
	}
	
}