using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class PrepayOrderUnpayMsgHelper : TBeanSerializer<PrepayOrderUnpayMsg>
	{
		
		public static PrepayOrderUnpayMsgHelper OBJ = new PrepayOrderUnpayMsgHelper();
		
		public static PrepayOrderUnpayMsgHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PrepayOrderUnpayMsg structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("parentSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetParentSn(value);
					}
					
					
					
					
					
					if ("orderCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderCode(value);
					}
					
					
					
					
					
					if ("vipclub".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipclub(value);
					}
					
					
					
					
					
					if ("endPayTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetEndPayTime(value);
					}
					
					
					
					
					
					if ("startPayTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetStartPayTime(value);
					}
					
					
					
					
					
					if ("addTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddTime(value);
					}
					
					
					
					
					
					if ("saleType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSaleType(value);
					}
					
					
					
					
					
					if ("merItemNoList".Equals(schemeField.Trim())){
						
						needSkip = false;
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
						
						structs.SetMerItemNoList(value);
					}
					
					
					
					
					
					if ("salesNoList".Equals(schemeField.Trim())){
						
						needSkip = false;
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
						
						structs.SetSalesNoList(value);
					}
					
					
					
					
					
					if ("merchandiseNoList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem2;
								elem2 = iprot.ReadString();
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetMerchandiseNoList(value);
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
		
		
		public void Write(PrepayOrderUnpayMsg structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetParentSn() != null) {
				
				oprot.WriteFieldBegin("parentSn");
				oprot.WriteString(structs.GetParentSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCode() != null) {
				
				oprot.WriteFieldBegin("orderCode");
				oprot.WriteString(structs.GetOrderCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipclub() != null) {
				
				oprot.WriteFieldBegin("vipclub");
				oprot.WriteString(structs.GetVipclub());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEndPayTime() != null) {
				
				oprot.WriteFieldBegin("endPayTime");
				oprot.WriteI64((long)structs.GetEndPayTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStartPayTime() != null) {
				
				oprot.WriteFieldBegin("startPayTime");
				oprot.WriteI64((long)structs.GetStartPayTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddTime() != null) {
				
				oprot.WriteFieldBegin("addTime");
				oprot.WriteString(structs.GetAddTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSaleType() != null) {
				
				oprot.WriteFieldBegin("saleType");
				oprot.WriteString(structs.GetSaleType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerItemNoList() != null) {
				
				oprot.WriteFieldBegin("merItemNoList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetMerItemNoList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSalesNoList() != null) {
				
				oprot.WriteFieldBegin("salesNoList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetSalesNoList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerchandiseNoList() != null) {
				
				oprot.WriteFieldBegin("merchandiseNoList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetMerchandiseNoList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PrepayOrderUnpayMsg bean){
			
			
		}
		
	}
	
}