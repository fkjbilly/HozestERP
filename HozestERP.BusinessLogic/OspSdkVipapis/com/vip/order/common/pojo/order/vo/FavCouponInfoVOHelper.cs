using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class FavCouponInfoVOHelper : TBeanSerializer<FavCouponInfoVO>
	{
		
		public static FavCouponInfoVOHelper OBJ = new FavCouponInfoVOHelper();
		
		public static FavCouponInfoVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(FavCouponInfoVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("couponNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCouponNo(value);
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
		
		
		public void Write(FavCouponInfoVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCouponNo() != null) {
				
				oprot.WriteFieldBegin("couponNo");
				oprot.WriteString(structs.GetCouponNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(FavCouponInfoVO bean){
			
			
		}
		
	}
	
}