using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetReturnOrExchangeGoodsRespHelper : TBeanSerializer<GetReturnOrExchangeGoodsResp>
	{
		
		public static GetReturnOrExchangeGoodsRespHelper OBJ = new GetReturnOrExchangeGoodsRespHelper();
		
		public static GetReturnOrExchangeGoodsRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetReturnOrExchangeGoodsResp structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("result".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.result.Result value;
						
						value = new com.vip.order.common.pojo.order.result.Result();
						com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Read(value, iprot);
						
						structs.SetResult(value);
					}
					
					
					
					
					
					if ("allowedGoodsList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO elem2;
								
								elem2 = new com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO();
								com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVOHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetAllowedGoodsList(value);
					}
					
					
					
					
					
					if ("unallowedGoodsList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO elem4;
								
								elem4 = new com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO();
								com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVOHelper.getInstance().Read(elem4, iprot);
								
								value.Add(elem4);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetUnallowedGoodsList(value);
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
		
		
		public void Write(GetReturnOrExchangeGoodsResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAllowedGoodsList() != null) {
				
				oprot.WriteFieldBegin("allowedGoodsList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO _item0 in structs.GetAllowedGoodsList()){
					
					
					com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnallowedGoodsList() != null) {
				
				oprot.WriteFieldBegin("unallowedGoodsList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVO _item0 in structs.GetUnallowedGoodsList()){
					
					
					com.vip.order.common.pojo.order.vo.ReturnOrExchangeGoodsVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetReturnOrExchangeGoodsResp bean){
			
			
		}
		
	}
	
}