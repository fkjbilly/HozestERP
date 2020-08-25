using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class GetGoodsDispatchWarehouseReqHelper : TBeanSerializer<GetGoodsDispatchWarehouseReq>
	{
		
		public static GetGoodsDispatchWarehouseReqHelper OBJ = new GetGoodsDispatchWarehouseReqHelper();
		
		public static GetGoodsDispatchWarehouseReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetGoodsDispatchWarehouseReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("goodsList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.request.GoodsDispatchWarehouseModel> value;
						
						value = new List<com.vip.order.biz.request.GoodsDispatchWarehouseModel>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.request.GoodsDispatchWarehouseModel elem0;
								
								elem0 = new com.vip.order.biz.request.GoodsDispatchWarehouseModel();
								com.vip.order.biz.request.GoodsDispatchWarehouseModelHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGoodsList(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
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
		
		
		public void Write(GetGoodsDispatchWarehouseReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetGoodsList() != null) {
				
				oprot.WriteFieldBegin("goodsList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.biz.request.GoodsDispatchWarehouseModel _item0 in structs.GetGoodsList()){
					
					
					com.vip.order.biz.request.GoodsDispatchWarehouseModelHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetGoodsDispatchWarehouseReq bean){
			
			
		}
		
	}
	
}