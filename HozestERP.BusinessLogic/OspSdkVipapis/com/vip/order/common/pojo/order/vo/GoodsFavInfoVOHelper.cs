using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class GoodsFavInfoVOHelper : TBeanSerializer<GoodsFavInfoVO>
	{
		
		public static GoodsFavInfoVOHelper OBJ = new GoodsFavInfoVOHelper();
		
		public static GoodsFavInfoVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GoodsFavInfoVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("unitDiscountMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUnitDiscountMoney(value);
					}
					
					
					
					
					
					if ("merItemNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetMerItemNo(value);
					}
					
					
					
					
					
					if ("merchandiseNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetMerchandiseNo(value);
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
		
		
		public void Write(GoodsFavInfoVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUnitDiscountMoney() != null) {
				
				oprot.WriteFieldBegin("unitDiscountMoney");
				oprot.WriteString(structs.GetUnitDiscountMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerItemNo() != null) {
				
				oprot.WriteFieldBegin("merItemNo");
				oprot.WriteI64((long)structs.GetMerItemNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerchandiseNo() != null) {
				
				oprot.WriteFieldBegin("merchandiseNo");
				oprot.WriteI64((long)structs.GetMerchandiseNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GoodsFavInfoVO bean){
			
			
		}
		
	}
	
}