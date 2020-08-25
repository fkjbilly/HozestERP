using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderActiveDetailVOHelper : TBeanSerializer<OrderActiveDetailVO>
	{
		
		public static OrderActiveDetailVOHelper OBJ = new OrderActiveDetailVOHelper();
		
		public static OrderActiveDetailVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderActiveDetailVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("activeType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetActiveType(value);
					}
					
					
					
					
					
					if ("activeField".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetActiveField(value);
					}
					
					
					
					
					
					if ("activeNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetActiveNo(value);
					}
					
					
					
					
					
					if ("goodsFavInfoList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.GoodsFavInfoVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.GoodsFavInfoVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.GoodsFavInfoVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.GoodsFavInfoVO();
								com.vip.order.common.pojo.order.vo.GoodsFavInfoVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGoodsFavInfoList(value);
					}
					
					
					
					
					
					if ("favCouponInfoList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.FavCouponInfoVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.FavCouponInfoVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.FavCouponInfoVO elem3;
								
								elem3 = new com.vip.order.common.pojo.order.vo.FavCouponInfoVO();
								com.vip.order.common.pojo.order.vo.FavCouponInfoVOHelper.getInstance().Read(elem3, iprot);
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFavCouponInfoList(value);
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
		
		
		public void Write(OrderActiveDetailVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetActiveType() != null) {
				
				oprot.WriteFieldBegin("activeType");
				oprot.WriteI32((int)structs.GetActiveType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActiveField() != null) {
				
				oprot.WriteFieldBegin("activeField");
				oprot.WriteI32((int)structs.GetActiveField()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActiveNo() != null) {
				
				oprot.WriteFieldBegin("activeNo");
				oprot.WriteString(structs.GetActiveNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsFavInfoList() != null) {
				
				oprot.WriteFieldBegin("goodsFavInfoList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.GoodsFavInfoVO _item0 in structs.GetGoodsFavInfoList()){
					
					
					com.vip.order.common.pojo.order.vo.GoodsFavInfoVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFavCouponInfoList() != null) {
				
				oprot.WriteFieldBegin("favCouponInfoList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.FavCouponInfoVO _item0 in structs.GetFavCouponInfoList()){
					
					
					com.vip.order.common.pojo.order.vo.FavCouponInfoVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderActiveDetailVO bean){
			
			
		}
		
	}
	
}