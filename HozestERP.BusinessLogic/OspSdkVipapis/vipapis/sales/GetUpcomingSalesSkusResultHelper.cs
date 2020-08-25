using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.sales{
	
	
	
	public class GetUpcomingSalesSkusResultHelper : TBeanSerializer<GetUpcomingSalesSkusResult>
	{
		
		public static GetUpcomingSalesSkusResultHelper OBJ = new GetUpcomingSalesSkusResultHelper();
		
		public static GetUpcomingSalesSkusResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetUpcomingSalesSkusResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("upcomingSalesSkus".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.sales.UpcomingSalesSku> value;
						
						value = new List<vipapis.sales.UpcomingSalesSku>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.sales.UpcomingSalesSku elem0;
								
								elem0 = new vipapis.sales.UpcomingSalesSku();
								vipapis.sales.UpcomingSalesSkuHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetUpcomingSalesSkus(value);
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
		
		
		public void Write(GetUpcomingSalesSkusResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			if(structs.GetUpcomingSalesSkus() != null) {
				
				oprot.WriteFieldBegin("upcomingSalesSkus");
				
				oprot.WriteListBegin();
				foreach(vipapis.sales.UpcomingSalesSku _item0 in structs.GetUpcomingSalesSkus()){
					
					
					vipapis.sales.UpcomingSalesSkuHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetUpcomingSalesSkusResult bean){
			
			
		}
		
	}
	
}