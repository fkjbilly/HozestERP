using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.fcs.vei.service{
	
	
	
	public class GoodsInfoModelHelper : TBeanSerializer<GoodsInfoModel>
	{
		
		public static GoodsInfoModelHelper OBJ = new GoodsInfoModelHelper();
		
		public static GoodsInfoModelHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GoodsInfoModel structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("saleType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSaleType(value);
					}
					
					
					
					
					
					if ("merItemNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMerItemNo(value);
					}
					
					
					
					
					
					if ("posNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPosNo(value);
					}
					
					
					
					
					
					if ("goodsType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetGoodsType(value);
					}
					
					
					
					
					
					if ("goodsOptPropValueList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.fcs.vei.service.GoodsOptPropValue> value;
						
						value = new List<com.vip.fcs.vei.service.GoodsOptPropValue>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.fcs.vei.service.GoodsOptPropValue elem0;
								
								elem0 = new com.vip.fcs.vei.service.GoodsOptPropValue();
								com.vip.fcs.vei.service.GoodsOptPropValueHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGoodsOptPropValueList(value);
					}
					
					
					
					
					
					if ("storeSource".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStoreSource(value);
					}
					
					
					
					
					
					if ("storeId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStoreId(value);
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
		
		
		public void Write(GoodsInfoModel structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSaleType() != null) {
				
				oprot.WriteFieldBegin("saleType");
				oprot.WriteString(structs.GetSaleType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerItemNo() != null) {
				
				oprot.WriteFieldBegin("merItemNo");
				oprot.WriteString(structs.GetMerItemNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPosNo() != null) {
				
				oprot.WriteFieldBegin("posNo");
				oprot.WriteString(structs.GetPosNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsType() != null) {
				
				oprot.WriteFieldBegin("goodsType");
				oprot.WriteI32((int)structs.GetGoodsType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsOptPropValueList() != null) {
				
				oprot.WriteFieldBegin("goodsOptPropValueList");
				
				oprot.WriteListBegin();
				foreach(com.vip.fcs.vei.service.GoodsOptPropValue _item0 in structs.GetGoodsOptPropValueList()){
					
					
					com.vip.fcs.vei.service.GoodsOptPropValueHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStoreSource() != null) {
				
				oprot.WriteFieldBegin("storeSource");
				oprot.WriteString(structs.GetStoreSource());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStoreId() != null) {
				
				oprot.WriteFieldBegin("storeId");
				oprot.WriteString(structs.GetStoreId());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GoodsInfoModel bean){
			
			
		}
		
	}
	
}